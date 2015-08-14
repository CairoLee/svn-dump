package com.google.analytics.v4
{
    import com.google.analytics.campaign.*;
    import com.google.analytics.core.*;
    import com.google.analytics.data.*;
    import com.google.analytics.debug.*;
    import com.google.analytics.external.*;
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;

    public class Tracker extends Object implements GoogleAnalyticsAPI
    {
        private var _adSense:AdSenseGlobals;
        private const EVENT_TRACKER_LABEL_KEY_NUM:int = 3;
        private var _eventTracker:X10;
        private const EVENT_TRACKER_VALUE_VALUE_NUM:int = 1;
        private var _noSessionInformation:Boolean = false;
        private var _browserInfo:BrowserInfo;
        private var _debug:DebugConfiguration;
        private var _isNewVisitor:Boolean = false;
        private var _buffer:Buffer;
        private var _config:Configuration;
        private var _x10Module:X10;
        private var _campaign:CampaignManager;
        private var _formatedReferrer:String;
        private var _timeStamp:Number;
        private var _info:Environment;
        private var _domainHash:Number;
        private const EVENT_TRACKER_PROJECT_ID:int = 5;
        private var _campaignInfo:CampaignInfo;
        private const EVENT_TRACKER_OBJECT_NAME_KEY_NUM:int = 1;
        private var _gifRequest:GIFRequest;
        private const EVENT_TRACKER_TYPE_KEY_NUM:int = 2;
        private var _hasInitData:Boolean = false;
        private var _account:String;

        public function Tracker(param1:String, param2:Configuration, param3:DebugConfiguration, param4:Environment, param5:Buffer, param6:GIFRequest, param7:AdSenseGlobals)
        {
            var _loc_8:String = null;
            _account = param1;
            _config = param2;
            _debug = param3;
            _info = param4;
            _buffer = param5;
            _gifRequest = param6;
            _adSense = param7;
            if (!Utils.validateAccount(param1))
            {
                _loc_8 = "Account \"" + param1 + "\" is not valid.";
                _debug.warning(_loc_8);
                throw new Error(_loc_8);
            }
            _initData();
            return;
        }// end function

        private function _doTracking() : Boolean
        {
            if (_info.protocol != Protocols.file && _info.protocol != Protocols.none && _isNotGoogleSearch())
            {
                return true;
            }
            if (_config.allowLocalTracking)
            {
                return true;
            }
            return false;
        }// end function

        public function addOrganic(param1:String, param2:String) : void
        {
            _debug.info("addOrganic( " + [param1, param2].join(", ") + " )");
            _config.organic.addSource(param1, param2);
            return;
        }// end function

        public function setAllowLinker(param1:Boolean) : void
        {
            _config.allowLinker = param1;
            _debug.info("setAllowLinker( " + _config.allowLinker + " )");
            return;
        }// end function

        public function trackEvent(param1:String, param2:String, param3:String = null, param4:Number = NaN) : Boolean
        {
            var _loc_5:Boolean = true;
            var _loc_6:int = 2;
            if (param1 != "" && param2 != "")
            {
                _eventTracker.clearKey(EVENT_TRACKER_PROJECT_ID);
                _eventTracker.clearValue(EVENT_TRACKER_PROJECT_ID);
                _loc_5 = _eventTracker.setKey(EVENT_TRACKER_PROJECT_ID, EVENT_TRACKER_OBJECT_NAME_KEY_NUM, param1);
                _loc_5 = _eventTracker.setKey(EVENT_TRACKER_PROJECT_ID, EVENT_TRACKER_TYPE_KEY_NUM, param2);
                if (param3 && param3 != "")
                {
                    _loc_5 = _eventTracker.setKey(EVENT_TRACKER_PROJECT_ID, EVENT_TRACKER_LABEL_KEY_NUM, param3);
                    _loc_6 = 3;
                    if (!isNaN(param4))
                    {
                        _loc_5 = _eventTracker.setValue(EVENT_TRACKER_PROJECT_ID, EVENT_TRACKER_VALUE_VALUE_NUM, param4);
                        _loc_6 = 4;
                    }
                }
                if (_loc_5)
                {
                    _debug.info("valid event tracking call\ncategory: " + param1 + "\naction: " + param2, VisualDebugMode.geek);
                    _sendXEvent(_eventTracker);
                }
            }
            else
            {
                _debug.warning("event tracking call is not valid, failed!\ncategory: " + param1 + "\naction: " + param2, VisualDebugMode.geek);
                _loc_5 = false;
            }
            switch(_loc_6)
            {
                case 4:
                {
                    _debug.info("trackEvent( " + [param1, param2, param3, param4].join(", ") + " )");
                    break;
                }
                case 3:
                {
                    _debug.info("trackEvent( " + [param1, param2, param3].join(", ") + " )");
                    break;
                }
                case 2:
                {
                }
                default:
                {
                    _debug.info("trackEvent( " + [param1, param2].join(", ") + " )");
                    break;
                }
            }
            return _loc_5;
        }// end function

        public function trackPageview(param1:String = "") : void
        {
            _debug.info("trackPageview( " + param1 + " )");
            if (_doTracking())
            {
                _initData();
                _trackMetrics(param1);
                _noSessionInformation = false;
            }
            else
            {
                _debug.warning("trackPageview( " + param1 + " ) failed");
            }
            return;
        }// end function

        public function setCookieTimeout(param1:int) : void
        {
            _config.conversionTimeout = param1;
            _debug.info("setCookieTimeout( " + _config.conversionTimeout + " )");
            return;
        }// end function

        public function trackTrans() : void
        {
            _debug.warning("trackTrans() not implemented");
            return;
        }// end function

        public function setClientInfo(param1:Boolean) : void
        {
            _config.detectClientInfo = param1;
            _debug.info("setClientInfo( " + _config.detectClientInfo + " )");
            return;
        }// end function

        public function linkByPost(param1:Object, param2:Boolean = false) : void
        {
            _debug.warning("linkByPost( " + [param1, param2].join(", ") + " ) not implemented");
            return;
        }// end function

        private function _initData() : void
        {
            var _loc_1:String = null;
            var _loc_2:String = null;
            if (!_hasInitData)
            {
                _updateDomainName();
                _domainHash = _getDomainHash();
                _timeStamp = Math.round(new Date().getTime() / 1000);
                if (_debug.verbose)
                {
                    _loc_1 = "";
                    _loc_1 = _loc_1 + "_initData 0";
                    _loc_1 = _loc_1 + ("\ndomain name: " + _config.domainName);
                    _loc_1 = _loc_1 + ("\ndomain hash: " + _domainHash);
                    _loc_1 = _loc_1 + ("\ntimestamp:   " + _timeStamp + " (" + new Date(_timeStamp * 1000) + ")");
                    _debug.info(_loc_1, VisualDebugMode.geek);
                }
            }
            if (_doTracking())
            {
                _handleCookie();
            }
            if (!_hasInitData)
            {
                if (_doTracking())
                {
                    _formatedReferrer = _formatReferrer();
                    _browserInfo = new BrowserInfo(_config, _info);
                    _debug.info("browserInfo: " + _browserInfo.toURLString(), VisualDebugMode.advanced);
                    if (_config.campaignTracking)
                    {
                        _campaign = new CampaignManager(_config, _debug, _buffer, _domainHash, _formatedReferrer, _timeStamp);
                        _campaignInfo = _campaign.getCampaignInformation(_info.locationSearch, _noSessionInformation);
                        _debug.info("campaignInfo: " + _campaignInfo.toURLString(), VisualDebugMode.advanced);
                    }
                }
                _x10Module = new X10();
                _eventTracker = new X10();
                _hasInitData = true;
            }
            if (_config.hasSiteOverlay)
            {
                _debug.warning("Site Overlay is not supported");
            }
            if (_debug.verbose)
            {
                _loc_2 = "";
                _loc_2 = _loc_2 + "_initData (misc)";
                _loc_2 = _loc_2 + ("\nflash version: " + _info.flashVersion.toString(4));
                _loc_2 = _loc_2 + ("\nprotocol: " + _info.protocol);
                _loc_2 = _loc_2 + ("\ndefault domain name (auto): \"" + _info.domainName + "\"");
                _loc_2 = _loc_2 + ("\nlanguage: " + _info.language);
                _loc_2 = _loc_2 + ("\ndomain hash: " + _getDomainHash());
                _loc_2 = _loc_2 + ("\nuser-agent: " + _info.userAgent);
                _debug.info(_loc_2, VisualDebugMode.geek);
            }
            return;
        }// end function

        public function getDetectTitle() : Boolean
        {
            _debug.info("getDetectTitle()");
            return _config.detectTitle;
        }// end function

        public function resetSession() : void
        {
            _debug.info("resetSession()");
            _buffer.resetCurrentSession();
            return;
        }// end function

        public function getClientInfo() : Boolean
        {
            _debug.info("getClientInfo()");
            return _config.detectClientInfo;
        }// end function

        private function _sendXEvent(param1:X10 = null) : void
        {
            var _loc_2:Variables = null;
            var _loc_3:EventInfo = null;
            var _loc_4:Variables = null;
            var _loc_5:Variables = null;
            _initData();
            if (_takeSample())
            {
                _loc_2 = new Variables();
                _loc_2.URIencode = true;
                _loc_3 = new EventInfo(true, _x10Module, param1);
                _loc_4 = _loc_3.toVariables();
                _loc_5 = _renderMetricsSearchVariables();
                _loc_2.join(_loc_4, _loc_5);
                _gifRequest.send(_account, _loc_2, false, true);
            }
            return;
        }// end function

        public function setDetectFlash(param1:Boolean) : void
        {
            _config.detectFlash = param1;
            _debug.info("setDetectFlash( " + _config.detectFlash + " )");
            return;
        }// end function

        public function setCampNameKey(param1:String) : void
        {
            _config.campaignKey.UCCN = param1;
            var _loc_2:* = "setCampNameKey( " + _config.campaignKey.UCCN + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCCN]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        private function _formatReferrer() : String
        {
            var _loc_2:String = null;
            var _loc_3:URL = null;
            var _loc_4:URL = null;
            var _loc_1:* = _info.referrer;
            if (_loc_1 == "" || _loc_1 == "localhost")
            {
                _loc_1 = "-";
            }
            else
            {
                _loc_2 = _info.domainName;
                _loc_3 = new URL(_loc_1);
                _loc_4 = new URL("http://" + _loc_2);
                if (_loc_3.hostName == _loc_2)
                {
                    return "-";
                }
                if (_loc_4.domain == _loc_3.domain)
                {
                    if (_loc_4.subDomain != _loc_3.subDomain)
                    {
                        _loc_1 = "0";
                    }
                }
                if (_loc_1.charAt(0) == "[" && _loc_1.charAt((_loc_1.length - 1)))
                {
                    _loc_1 = "-";
                }
            }
            _debug.info("formated referrer: " + _loc_1, VisualDebugMode.advanced);
            return _loc_1;
        }// end function

        private function _visitCode() : Number
        {
            if (_debug.verbose)
            {
                _debug.info("visitCode: " + _buffer.utma.sessionId, VisualDebugMode.geek);
            }
            return _buffer.utma.sessionId;
        }// end function

        public function createEventTracker(param1:String) : EventTracker
        {
            _debug.info("createEventTracker( " + param1 + " )");
            return new EventTracker(param1, this);
        }// end function

        public function addItem(param1:String, param2:String, param3:String, param4:String, param5:Number, param6:int) : void
        {
            _debug.warning("addItem( " + [param1, param2, param3, param4, param5, param6].join(", ") + " ) not implemented");
            return;
        }// end function

        public function clearIgnoredOrganic() : void
        {
            _debug.info("clearIgnoredOrganic()");
            _config.organic.clearIgnoredKeywords();
            return;
        }// end function

        public function setVar(param1:String) : void
        {
            var _loc_2:Variables = null;
            if (param1 != "" && _isNotGoogleSearch())
            {
                _initData();
                _buffer.utmv.domainHash = _domainHash;
                _buffer.utmv.value = param1;
                if (_debug.verbose)
                {
                    _debug.info(_buffer.utmv.toString(), VisualDebugMode.geek);
                }
                _debug.info("setVar( " + param1 + " )");
                if (_takeSample())
                {
                    _loc_2 = new Variables();
                    _loc_2.utmt = "var";
                    _gifRequest.send(_account, _loc_2);
                }
            }
            else
            {
                _debug.warning("setVar \"" + param1 + "\" is ignored");
            }
            return;
        }// end function

        public function setDomainName(param1:String) : void
        {
            if (param1 == "auto")
            {
                _config.domain.mode = DomainNameMode.auto;
            }
            else if (param1 == "none")
            {
                _config.domain.mode = DomainNameMode.none;
            }
            else
            {
                _config.domain.mode = DomainNameMode.custom;
                _config.domain.name = param1;
            }
            _updateDomainName();
            _debug.info("setDomainName( " + _config.domainName + " )");
            return;
        }// end function

        private function _updateDomainName() : void
        {
            var _loc_1:String = null;
            if (_config.domain.mode == DomainNameMode.auto)
            {
                _loc_1 = _info.domainName;
                if (_loc_1.substring(0, 4) == "www.")
                {
                    _loc_1 = _loc_1.substring(4);
                }
                _config.domain.name = _loc_1;
            }
            _config.domainName = _config.domain.name.toLowerCase();
            _debug.info("domain name: " + _config.domainName, VisualDebugMode.advanced);
            return;
        }// end function

        public function addTrans(param1:String, param2:String, param3:Number, param4:Number, param5:Number, param6:String, param7:String, param8:String) : Object
        {
            _debug.warning("addTrans( " + [param1, param2, param3, param4, param5, param6, param7, param8].join(", ") + " ) not implemented");
            return null;
        }// end function

        private function _renderMetricsSearchVariables(param1:String = "") : Variables
        {
            var _loc_4:Variables = null;
            var _loc_2:* = new Variables();
            _loc_2.URIencode = true;
            var _loc_3:* = new DocumentInfo(_config, _info, _formatedReferrer, param1, _adSense);
            _debug.info("docInfo: " + _loc_3.toURLString(), VisualDebugMode.geek);
            if (_config.campaignTracking)
            {
                _loc_4 = _campaignInfo.toVariables();
            }
            var _loc_5:* = _browserInfo.toVariables();
            _loc_2.join(_loc_3.toVariables(), _loc_5, _loc_4);
            return _loc_2;
        }// end function

        public function setCampContentKey(param1:String) : void
        {
            _config.campaignKey.UCCT = param1;
            var _loc_2:* = "setCampContentKey( " + _config.campaignKey.UCCT + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCCT]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        private function _handleCookie() : void
        {
            var _loc_1:String = null;
            var _loc_2:String = null;
            var _loc_3:Array = null;
            var _loc_4:String = null;
            if (_config.allowLinker)
            {
            }
            if (_buffer.hasUTMA() && !_buffer.utma.isEmpty())
            {
                if (!_buffer.hasUTMB() || !_buffer.hasUTMC())
                {
                    _buffer.updateUTMA(_timeStamp);
                    _noSessionInformation = true;
                }
                if (_debug.verbose)
                {
                    _debug.info("from cookie " + _buffer.utma.toString(), VisualDebugMode.geek);
                }
            }
            else
            {
                _debug.info("create a new utma", VisualDebugMode.advanced);
                _buffer.utma.domainHash = _domainHash;
                _buffer.utma.sessionId = _getUniqueSessionId();
                _buffer.utma.firstTime = _timeStamp;
                _buffer.utma.lastTime = _timeStamp;
                _buffer.utma.currentTime = _timeStamp;
                _buffer.utma.sessionCount = 1;
                if (_debug.verbose)
                {
                    _debug.info(_buffer.utma.toString(), VisualDebugMode.geek);
                }
                _noSessionInformation = true;
                _isNewVisitor = true;
            }
            if (_adSense.gaGlobal && _adSense.dh == String(_domainHash))
            {
                if (_adSense.sid)
                {
                    _buffer.utma.currentTime = Number(_adSense.sid);
                    if (_debug.verbose)
                    {
                        _loc_1 = "";
                        _loc_1 = _loc_1 + "AdSense sid found\n";
                        _loc_1 = _loc_1 + ("Override currentTime(" + _buffer.utma.currentTime + ") from AdSense sid(" + Number(_adSense.sid) + ")");
                        _debug.info(_loc_1, VisualDebugMode.geek);
                    }
                }
                if (_isNewVisitor)
                {
                    if (_adSense.sid)
                    {
                        _buffer.utma.lastTime = Number(_adSense.sid);
                        if (_debug.verbose)
                        {
                            _loc_2 = "";
                            _loc_2 = _loc_2 + "AdSense sid found (new visitor)\n";
                            _loc_2 = _loc_2 + ("Override lastTime(" + _buffer.utma.lastTime + ") from AdSense sid(" + Number(_adSense.sid) + ")");
                            _debug.info(_loc_2, VisualDebugMode.geek);
                        }
                    }
                    if (_adSense.vid)
                    {
                        _loc_3 = _adSense.vid.split(".");
                        _buffer.utma.sessionId = Number(_loc_3[0]);
                        _buffer.utma.firstTime = Number(_loc_3[1]);
                        if (_debug.verbose)
                        {
                            _loc_4 = "";
                            _loc_4 = _loc_4 + "AdSense vid found (new visitor)\n";
                            _loc_4 = _loc_4 + ("Override sessionId(" + _buffer.utma.sessionId + ") from AdSense vid(" + Number(_loc_3[0]) + ")\n");
                            _loc_4 = _loc_4 + ("Override firstTime(" + _buffer.utma.firstTime + ") from AdSense vid(" + Number(_loc_3[1]) + ")");
                            _debug.info(_loc_4, VisualDebugMode.geek);
                        }
                    }
                    if (_debug.verbose)
                    {
                        _debug.info("AdSense modified : " + _buffer.utma.toString(), VisualDebugMode.geek);
                    }
                }
            }
            _buffer.utmb.domainHash = _domainHash;
            if (isNaN(_buffer.utmb.trackCount))
            {
                _buffer.utmb.trackCount = 0;
            }
            if (isNaN(_buffer.utmb.token))
            {
                _buffer.utmb.token = _config.tokenCliff;
            }
            if (isNaN(_buffer.utmb.lastTime))
            {
                _buffer.utmb.lastTime = _buffer.utma.currentTime;
            }
            _buffer.utmc.domainHash = _domainHash;
            if (_debug.verbose)
            {
                _debug.info(_buffer.utmb.toString(), VisualDebugMode.advanced);
                _debug.info(_buffer.utmc.toString(), VisualDebugMode.advanced);
            }
            return;
        }// end function

        public function setLocalServerMode() : void
        {
            _config.serverMode = ServerOperationMode.local;
            _debug.info("setLocalServerMode()");
            return;
        }// end function

        public function clearIgnoredRef() : void
        {
            _debug.info("clearIgnoredRef()");
            _config.organic.clearIgnoredReferrals();
            return;
        }// end function

        public function setCampSourceKey(param1:String) : void
        {
            _config.campaignKey.UCSR = param1;
            var _loc_2:* = "setCampSourceKey( " + _config.campaignKey.UCSR + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCSR]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        public function getLocalGifPath() : String
        {
            _debug.info("getLocalGifPath()");
            return _config.localGIFpath;
        }// end function

        public function setLocalGifPath(param1:String) : void
        {
            _config.localGIFpath = param1;
            _debug.info("setLocalGifPath( " + _config.localGIFpath + " )");
            return;
        }// end function

        public function getVersion() : String
        {
            _debug.info("getVersion()");
            return _config.version;
        }// end function

        public function setAllowAnchor(param1:Boolean) : void
        {
            _config.allowAnchor = param1;
            _debug.info("setAllowAnchor( " + _config.allowAnchor + " )");
            return;
        }// end function

        private function _isNotGoogleSearch() : Boolean
        {
            var _loc_1:* = _config.domainName;
            var _loc_2:* = _loc_1.indexOf("www.google.") < 0;
            var _loc_3:* = _loc_1.indexOf(".google.") < 0;
            var _loc_4:* = _loc_1.indexOf("google.") < 0;
            var _loc_5:* = _loc_1.indexOf("google.org") > -1;
            return _loc_2 || _loc_3 || _loc_4 || _config.cookiePath != "/" || _loc_5;
        }// end function

        public function setSampleRate(param1:Number) : void
        {
            if (param1 < 0)
            {
                _debug.warning("sample rate can not be negative, ignoring value.");
            }
            else
            {
                _config.sampleRate = param1;
            }
            _debug.info("setSampleRate( " + _config.sampleRate + " )");
            return;
        }// end function

        private function _takeSample() : Boolean
        {
            if (_debug.verbose)
            {
                _debug.info("takeSample: (" + _visitCode() % 10000 + ") < (" + _config.sampleRate * 10000 + ")", VisualDebugMode.geek);
            }
            return _visitCode() % 10000 < _config.sampleRate * 10000;
        }// end function

        public function setCookiePath(param1:String) : void
        {
            _config.cookiePath = param1;
            _debug.info("setCookiePath( " + _config.cookiePath + " )");
            return;
        }// end function

        public function setAllowHash(param1:Boolean) : void
        {
            _config.allowDomainHash = param1;
            _debug.info("setAllowHash( " + _config.allowDomainHash + " )");
            return;
        }// end function

        private function _generateUserDataHash() : Number
        {
            var _loc_1:String = "";
            _loc_1 = _loc_1 + _info.appName;
            _loc_1 = _loc_1 + _info.appVersion;
            _loc_1 = _loc_1 + _info.language;
            _loc_1 = _loc_1 + _info.platform;
            _loc_1 = _loc_1 + _info.userAgent.toString();
            _loc_1 = _loc_1 + (_info.screenWidth + "x" + _info.screenHeight + _info.screenColorDepth);
            _loc_1 = _loc_1 + _info.referrer;
            return Utils.generateHash(_loc_1);
        }// end function

        public function setCampNOKey(param1:String) : void
        {
            _config.campaignKey.UCNO = param1;
            var _loc_2:* = "setCampNOKey( " + _config.campaignKey.UCNO + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCNO]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        public function addIgnoredOrganic(param1:String) : void
        {
            _debug.info("addIgnoredOrganic( " + param1 + " )");
            _config.organic.addIgnoredKeyword(param1);
            return;
        }// end function

        public function setLocalRemoteServerMode() : void
        {
            _config.serverMode = ServerOperationMode.both;
            _debug.info("setLocalRemoteServerMode()");
            return;
        }// end function

        public function cookiePathCopy(param1:String) : void
        {
            _debug.warning("cookiePathCopy( " + param1 + " ) not implemented");
            return;
        }// end function

        public function setDetectTitle(param1:Boolean) : void
        {
            _config.detectTitle = param1;
            _debug.info("setDetectTitle( " + _config.detectTitle + " )");
            return;
        }// end function

        public function setCampTermKey(param1:String) : void
        {
            _config.campaignKey.UCTR = param1;
            var _loc_2:* = "setCampTermKey( " + _config.campaignKey.UCTR + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCTR]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        public function getServiceMode() : ServerOperationMode
        {
            _debug.info("getServiceMode()");
            return _config.serverMode;
        }// end function

        private function _trackMetrics(param1:String = "") : void
        {
            var _loc_2:Variables = null;
            var _loc_3:Variables = null;
            var _loc_4:Variables = null;
            var _loc_5:EventInfo = null;
            if (_takeSample())
            {
                _loc_2 = new Variables();
                _loc_2.URIencode = true;
                if (_x10Module && _x10Module.hasData())
                {
                    _loc_5 = new EventInfo(false, _x10Module);
                    _loc_3 = _loc_5.toVariables();
                }
                _loc_4 = _renderMetricsSearchVariables(param1);
                _loc_2.join(_loc_3, _loc_4);
                _gifRequest.send(_account, _loc_2);
            }
            return;
        }// end function

        public function setCampaignTrack(param1:Boolean) : void
        {
            _config.campaignTracking = param1;
            _debug.info("setCampaignTrack( " + _config.campaignTracking + " )");
            return;
        }// end function

        public function addIgnoredRef(param1:String) : void
        {
            _debug.info("addIgnoredRef( " + param1 + " )");
            _config.organic.addIgnoredReferral(param1);
            return;
        }// end function

        public function clearOrganic() : void
        {
            _debug.info("clearOrganic()");
            _config.organic.clearEngines();
            return;
        }// end function

        public function getDetectFlash() : Boolean
        {
            _debug.info("getDetectFlash()");
            return _config.detectFlash;
        }// end function

        public function setCampMediumKey(param1:String) : void
        {
            _config.campaignKey.UCMD = param1;
            var _loc_2:* = "setCampMediumKey( " + _config.campaignKey.UCMD + " )";
            if (_debug.mode == VisualDebugMode.geek)
            {
                _debug.info(_loc_2 + " [UCMD]");
            }
            else
            {
                _debug.info(_loc_2);
            }
            return;
        }// end function

        private function _getUniqueSessionId() : Number
        {
            var _loc_1:* = (Utils.generate32bitRandom() ^ _generateUserDataHash()) * 2147483647;
            _debug.info("Session ID: " + _loc_1, VisualDebugMode.geek);
            return _loc_1;
        }// end function

        private function _getDomainHash() : Number
        {
            if (!_config.domainName || _config.domainName == "" || _config.domain.mode == DomainNameMode.none)
            {
                _config.domainName = "";
                return 1;
            }
            _updateDomainName();
            if (_config.allowDomainHash)
            {
                return Utils.generateHash(_config.domainName);
            }
            return 1;
        }// end function

        public function setSessionTimeout(param1:int) : void
        {
            _config.sessionTimeout = param1;
            _debug.info("setSessionTimeout( " + _config.sessionTimeout + " )");
            return;
        }// end function

        public function getAccount() : String
        {
            _debug.info("getAccount()");
            return _account;
        }// end function

        public function link(param1:String, param2:Boolean = false) : void
        {
            _debug.warning("link( " + [param1, param2].join(", ") + " ) not implemented");
            return;
        }// end function

        public function setRemoteServerMode() : void
        {
            _config.serverMode = ServerOperationMode.remote;
            _debug.info("setRemoteServerMode()");
            return;
        }// end function

    }
}
