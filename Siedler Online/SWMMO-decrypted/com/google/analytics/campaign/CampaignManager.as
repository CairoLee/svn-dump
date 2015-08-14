package com.google.analytics.campaign
{
    import com.google.analytics.core.*;
    import com.google.analytics.debug.*;
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;

    public class CampaignManager extends Object
    {
        private var _config:Configuration;
        private var _domainHash:Number;
        private var _debug:DebugConfiguration;
        private var _timeStamp:Number;
        private var _referrer:String;
        private var _buffer:Buffer;
        public static const trackingDelimiter:String = "|";

        public function CampaignManager(param1:Configuration, param2:DebugConfiguration, param3:Buffer, param4:Number, param5:String, param6:Number)
        {
            _config = param1;
            _debug = param2;
            _buffer = param3;
            _domainHash = param4;
            _referrer = param5;
            _timeStamp = param6;
            return;
        }// end function

        public function getCampaignInformation(param1:String, param2:Boolean) : CampaignInfo
        {
            var _loc_4:CampaignTracker = null;
            var _loc_8:CampaignTracker = null;
            var _loc_9:int = 0;
            var _loc_3:* = new CampaignInfo();
            var _loc_5:Boolean = false;
            var _loc_6:Boolean = false;
            var _loc_7:int = 0;
            if (_config.allowLinker && _buffer.isGenuine())
            {
                if (!_buffer.hasUTMZ())
                {
                    return _loc_3;
                }
            }
            _loc_4 = getTrackerFromSearchString(param1);
            if (isValid(_loc_4))
            {
                _loc_6 = hasNoOverride(param1);
                if (_loc_6 && !_buffer.hasUTMZ())
                {
                    return _loc_3;
                }
            }
            if (!isValid(_loc_4))
            {
                _loc_4 = getOrganicCampaign();
                if (!_buffer.hasUTMZ() && isIgnoredKeyword(_loc_4))
                {
                    return _loc_3;
                }
            }
            if (!isValid(_loc_4) && param2)
            {
                _loc_4 = getReferrerCampaign();
                if (!_buffer.hasUTMZ() && isIgnoredReferral(_loc_4))
                {
                    return _loc_3;
                }
            }
            if (!isValid(_loc_4))
            {
                if (!_buffer.hasUTMZ() && param2)
                {
                    _loc_4 = getDirectCampaign();
                }
            }
            if (!isValid(_loc_4))
            {
                return _loc_3;
            }
            if (_buffer.hasUTMZ() && !_buffer.utmz.isEmpty())
            {
                _loc_8 = new CampaignTracker();
                _loc_8.fromTrackerString(_buffer.utmz.campaignTracking);
                _loc_5 = _loc_8.toTrackerString() == _loc_4.toTrackerString();
                _loc_7 = _buffer.utmz.responseCount;
            }
            if (!_loc_5 || param2)
            {
                _loc_9 = _buffer.utma.sessionCount;
                _loc_7++;
                if (_loc_9 == 0)
                {
                    _loc_9 = 1;
                }
                _buffer.utmz.domainHash = _domainHash;
                _buffer.utmz.campaignCreation = _timeStamp;
                _buffer.utmz.campaignSessions = _loc_9;
                _buffer.utmz.responseCount = _loc_7;
                _buffer.utmz.campaignTracking = _loc_4.toTrackerString();
                _debug.info(_buffer.utmz.toString(), VisualDebugMode.geek);
                _loc_3 = new CampaignInfo(false, true);
            }
            else
            {
                _loc_3 = new CampaignInfo(false, false);
            }
            return _loc_3;
        }// end function

        public function hasNoOverride(param1:String) : Boolean
        {
            var _loc_2:* = _config.campaignKey;
            if (param1 == "")
            {
                return false;
            }
            var _loc_3:* = new Variables(param1);
            var _loc_4:String = "";
            if (_loc_3.hasOwnProperty(_loc_2.UCNO))
            {
            }
            _loc_4 = _loc_3[_loc_2.UCNO];
            ;
            
            return true;
        }// end function

        public function getTrackerFromSearchString(param1:String) : CampaignTracker
        {
            var _loc_2:* = getOrganicCampaign();
            var _loc_3:* = new CampaignTracker();
            var _loc_4:* = _config.campaignKey;
            if (param1 == "")
            {
                return _loc_3;
            }
            var _loc_5:* = new Variables(param1);
            if (new Variables(param1).hasOwnProperty(_loc_4.UCID))
            {
                _loc_3.id = _loc_5[_loc_4.UCID];
            }
            if (_loc_5.hasOwnProperty(_loc_4.UCSR))
            {
                _loc_3.source = _loc_5[_loc_4.UCSR];
            }
            if (_loc_5.hasOwnProperty(_loc_4.UGCLID))
            {
                _loc_3.clickId = _loc_5[_loc_4.UGCLID];
            }
            if (_loc_5.hasOwnProperty(_loc_4.UCCN))
            {
                _loc_3.name = _loc_5[_loc_4.UCCN];
            }
            else
            {
                _loc_3.name = "(not set)";
            }
            if (_loc_5.hasOwnProperty(_loc_4.UCMD))
            {
                _loc_3.medium = _loc_5[_loc_4.UCMD];
            }
            else
            {
                _loc_3.medium = "(not set)";
            }
            if (_loc_5.hasOwnProperty(_loc_4.UCTR))
            {
                _loc_3.term = _loc_5[_loc_4.UCTR];
            }
            else if (_loc_2 && _loc_2.term != "")
            {
                _loc_3.term = _loc_2.term;
            }
            if (_loc_5.hasOwnProperty(_loc_4.UCCT))
            {
                _loc_3.content = _loc_5[_loc_4.UCCT];
            }
            return _loc_3;
        }// end function

        public function getOrganicCampaign() : CampaignTracker
        {
            var _loc_1:CampaignTracker = null;
            var _loc_4:Array = null;
            var _loc_5:OrganicReferrer = null;
            var _loc_6:String = null;
            if (isInvalidReferrer(_referrer) || isFromGoogleCSE(_referrer, _config))
            {
                return _loc_1;
            }
            var _loc_2:* = new URL(_referrer);
            var _loc_3:String = "";
            if (_loc_2.hostName != "")
            {
                if (_loc_2.hostName.indexOf(".") > -1)
                {
                    _loc_4 = _loc_2.hostName.split(".");
                    switch(_loc_4.length)
                    {
                        case 2:
                        {
                            _loc_3 = _loc_4[0];
                            break;
                        }
                        case 3:
                        {
                            _loc_3 = _loc_4[1];
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                }
            }
            if (_config.organic.match(_loc_3))
            {
                _loc_5 = _config.organic.getReferrerByName(_loc_3);
                _loc_6 = _config.organic.getKeywordValue(_loc_5, _loc_2.search);
                _loc_1 = new CampaignTracker();
                _loc_1.source = _loc_5.engine;
                _loc_1.name = "(organic)";
                _loc_1.medium = "organic";
                _loc_1.term = _loc_6;
            }
            return _loc_1;
        }// end function

        public function getDirectCampaign() : CampaignTracker
        {
            var _loc_1:* = new CampaignTracker();
            _loc_1.source = "(direct)";
            _loc_1.name = "(direct)";
            _loc_1.medium = "(none)";
            return _loc_1;
        }// end function

        public function isIgnoredKeyword(param1:CampaignTracker) : Boolean
        {
            if (param1 && param1.medium == "organic")
            {
                return _config.organic.isIgnoredKeyword(param1.term);
            }
            return false;
        }// end function

        public function isIgnoredReferral(param1:CampaignTracker) : Boolean
        {
            if (param1 && param1.medium == "referral")
            {
                return _config.organic.isIgnoredReferral(param1.source);
            }
            return false;
        }// end function

        public function isValid(param1:CampaignTracker) : Boolean
        {
            if (param1 && param1.isValid())
            {
                return true;
            }
            return false;
        }// end function

        public function getReferrerCampaign() : CampaignTracker
        {
            var _loc_1:CampaignTracker = null;
            if (isInvalidReferrer(_referrer) || isFromGoogleCSE(_referrer, _config))
            {
                return _loc_1;
            }
            var _loc_2:* = new URL(_referrer);
            var _loc_3:* = _loc_2.hostName;
            var _loc_4:* = _loc_2.path;
            if (_loc_3.indexOf("www.") == 0)
            {
                _loc_3 = _loc_3.substr(4);
            }
            _loc_1 = new CampaignTracker();
            _loc_1.source = _loc_3;
            _loc_1.name = "(referral)";
            _loc_1.medium = "referral";
            _loc_1.content = _loc_4;
            return _loc_1;
        }// end function

        public static function isInvalidReferrer(param1:String) : Boolean
        {
            var _loc_2:URL = null;
            if (param1 == "" || param1 == "-" || param1 == "0")
            {
                return true;
            }
            if (param1.indexOf("://") > -1)
            {
                _loc_2 = new URL(param1);
                if (_loc_2.protocol == Protocols.file || _loc_2.protocol == Protocols.none)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public static function isFromGoogleCSE(param1:String, param2:Configuration) : Boolean
        {
            var _loc_3:* = new URL(param1);
            if (_loc_3.hostName.indexOf(param2.google) > -1)
            {
                if (_loc_3.search.indexOf(param2.googleSearchParam + "=") > -1)
                {
                    if (_loc_3.path == "/" + param2.googleCsePath)
                    {
                        return true;
                    }
                }
            }
            return false;
        }// end function

    }
}
