package com.google.analytics.v4
{
    import com.google.analytics.core.*;
    import com.google.analytics.debug.*;
    import com.google.analytics.external.*;
    import com.google.analytics.v4.*;

    public class Bridge extends Object implements GoogleAnalyticsAPI
    {
        private var _debug:DebugConfiguration;
        private var _proxy:JavascriptProxy;
        private var _jsContainer:String = "_GATracker";
        private var _hasGATracker:Boolean = false;
        private var _account:String;
        private static var _linkTrackingObject_js:XML = <script>
n            <![CDATA[
n                function( container , target )
n                {
n                    var targets ;
n                    var name ;
n                    if( target.indexOf(""."") > 0 )
n                    {
n                        targets = target.split(""."");
n                        name    = targets.pop();
n                    }
n                    else
n                    {
n                        targets = [];
n                        name    = target;
n                    }
n                    var ref   = window;
n                    var depth = targets.length;
n                    for( var j = 0 ; j < depth ; j++ )
n                    {
n                        ref = ref[ targets[j] ] ;
n                    }
n                    window[container][target] = ref[name] ;
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function( container , target )
                {
                    var targets ;
                    var name ;
                    if( target.indexOf(".") > 0 )
                    {
                        targets = target.split(".");
                        name    = targets.pop();
                    }
                    else
                    {
                        targets = [];
                        name    = target;
                    }
                    var ref   = window;
                    var depth = targets.length;
                    for( var j = 0 ; j < depth ; j++ )
                    {
                        ref = ref[ targets[j] ] ;
                    }
                    window[container][target] = ref[name] ;
                }
            ]]>
        </script>;
        private static var _createTrackingObject_js:XML = <script>
n            <![CDATA[
n                function( acct )
n                {
n                    _GATracker[acct] = _gat._getTracker(acct);
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function( acct )
                {
                    _GATracker[acct] = _gat._getTracker(acct);
                }
            ]]>
        </script>;
        private static var _injectTrackingObject_js:XML = <script>
n            <![CDATA[
n                function()
n                {
n                    try 
n                    {
n                        _GATracker
n                    }
n                    catch(e) 
n                    {
n                        _GATracker = {};
n                    }
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function()
                {
                    try 
                    {
                        _GATracker
                    }
                    catch(e) 
                    {
                        _GATracker = {};
                    }
                }
            ]]>
        </script>;
        private static var _checkGAJS_js:XML = <script>
n            <![CDATA[
n                function()
n                {
n                    if( _gat && _gat._getTracker )
n                    {
n                        return true;
n                    }
n                    return false;
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function()
                {
                    if( _gat && _gat._getTracker )
                    {
                        return true;
                    }
                    return false;
                }
            ]]>
        </script>;
        private static var _checkValidTrackingObject_js:XML = <script>
n            <![CDATA[
n                function(acct)
n                {
n                    if( _GATracker[acct] && (_GATracker[acct]._getAccount) )
n                    {
n                        return true ;
n                    }
n                    else
n                    {
n                        return false;
n                    }
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function(acct)
                {
                    if( _GATracker[acct] && (_GATracker[acct]._getAccount) )
                    {
                        return true ;
                    }
                    else
                    {
                        return false;
                    }
                }
            ]]>
        </script>;

        public function Bridge(param1:String, param2:DebugConfiguration, param3:JavascriptProxy)
        {
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:String = null;
            _account = param1;
            _debug = param2;
            _proxy = param3;
            if (!_checkGAJS())
            {
                _loc_4 = "";
                _loc_4 = _loc_4 + "ga.js not found, be sure to check if\n";
                _loc_4 = _loc_4 + "<script src=\"http://www.google-analytics.com/ga.js\"></script>\n";
                _loc_4 = _loc_4 + "is included in the HTML.";
                _debug.warning(_loc_4);
                throw new Error(_loc_4);
            }
            if (!_hasGATracker)
            {
                if (_debug.javascript && _debug.verbose)
                {
                    _loc_5 = "";
                    _loc_5 = _loc_5 + "The Google Analytics tracking code was not found on the container page\n";
                    _loc_5 = _loc_5 + "we create it";
                    _debug.info(_loc_5, VisualDebugMode.advanced);
                }
                _injectTrackingObject();
            }
            if (Utils.validateAccount(param1))
            {
                _createTrackingObject(param1);
            }
            else if (_checkTrackingObject(param1))
            {
                _linkTrackingObject(param1);
            }
            else
            {
                _loc_6 = "";
                _loc_6 = _loc_6 + ("JS Object \"" + param1 + "\" doesn\'t exist in DOM\n");
                _loc_6 = _loc_6 + "Bridge object not created.";
                _debug.warning(_loc_6);
                throw new Error(_loc_6);
            }
            return;
        }// end function

        public function link(param1:String, param2:Boolean = false) : void
        {
            _debug.info("link( " + param1 + ", " + param2 + " )");
            _call("_link", param1, param2);
            return;
        }// end function

        public function addOrganic(param1:String, param2:String) : void
        {
            _debug.info("addOrganic( " + [param1, param2].join(", ") + " )");
            _call("_addOrganic", param1);
            return;
        }// end function

        public function setAllowLinker(param1:Boolean) : void
        {
            _debug.info("setAllowLinker( " + param1 + " )");
            _call("_setAllowLinker", param1);
            return;
        }// end function

        private function _linkTrackingObject(param1:String) : void
        {
            _proxy.call(_linkTrackingObject_js, _jsContainer, param1);
            return;
        }// end function

        public function trackEvent(param1:String, param2:String, param3:String = null, param4:Number = NaN) : Boolean
        {
            var _loc_5:int = 2;
            if (param3 && param3 != "")
            {
                _loc_5 = 3;
            }
            if (_loc_5 == 3 && !isNaN(param4))
            {
                _loc_5 = 4;
            }
            switch(_loc_5)
            {
                case 4:
                {
                    _debug.info("trackEvent( " + [param1, param2, param3, param4].join(", ") + " )");
                    return _call("_trackEvent", param1, param2, param3, param4);
                }
                case 3:
                {
                    _debug.info("trackEvent( " + [param1, param2, param3].join(", ") + " )");
                    return _call("_trackEvent", param1, param2, param3);
                }
                case 2:
                {
                }
                default:
                {
                    _debug.info("trackEvent( " + [param1, param2].join(", ") + " )");
                    return _call("_trackEvent", param1, param2);
                    continue;
                }
            }
        }// end function

        public function setClientInfo(param1:Boolean) : void
        {
            _debug.info("setClientInfo( " + param1 + " )");
            _call("_setClientInfo", param1);
            return;
        }// end function

        public function trackTrans() : void
        {
            _debug.info("trackTrans()");
            _call("_trackTrans");
            return;
        }// end function

        public function setCookieTimeout(param1:int) : void
        {
            _debug.info("setCookieTimeout( " + param1 + " )");
            _call("_setCookieTimeout", param1);
            return;
        }// end function

        public function trackPageview(param1:String = "") : void
        {
            _debug.info("trackPageview( " + param1 + " )");
            _call("_trackPageview", param1);
            return;
        }// end function

        public function getClientInfo() : Boolean
        {
            _debug.info("getClientInfo()");
            return _call("_getClientInfo");
        }// end function

        private function _checkValidTrackingObject(param1:String) : Boolean
        {
            return _proxy.call(_checkValidTrackingObject_js, param1);
        }// end function

        private function _checkGAJS() : Boolean
        {
            return _proxy.call(_checkGAJS_js);
        }// end function

        public function linkByPost(param1:Object, param2:Boolean = false) : void
        {
            _debug.warning("linkByPost( " + param1 + ", " + param2 + " ) not implemented");
            return;
        }// end function

        private function _call(param1:String, ... args)
        {
            args.unshift("window." + _jsContainer + "[\"" + _account + "\"]." + param1);
            return _proxy.call.apply(_proxy, args);
        }// end function

        public function hasGAJS() : Boolean
        {
            return _checkGAJS();
        }// end function

        private function _checkTrackingObject(param1:String) : Boolean
        {
            var _loc_2:* = _proxy.hasProperty(param1);
            var _loc_3:* = _proxy.hasProperty(param1 + "._getAccount");
            return _loc_2 && _loc_3;
        }// end function

        public function resetSession() : void
        {
            _debug.warning("resetSession() not implemented");
            return;
        }// end function

        public function getDetectTitle() : Boolean
        {
            _debug.info("getDetectTitle()");
            return _call("_getDetectTitle");
        }// end function

        public function setCampNameKey(param1:String) : void
        {
            _debug.info("setCampNameKey( " + param1 + " )");
            _call("_setCampNameKey", param1);
            return;
        }// end function

        public function setDetectFlash(param1:Boolean) : void
        {
            _debug.info("setDetectFlash( " + param1 + " )");
            _call("_setDetectFlash", param1);
            return;
        }// end function

        public function createEventTracker(param1:String) : EventTracker
        {
            _debug.info("createEventTracker( " + param1 + " )");
            return new EventTracker(param1, this);
        }// end function

        public function addItem(param1:String, param2:String, param3:String, param4:String, param5:Number, param6:int) : void
        {
            _debug.info("addItem( " + [param1, param2, param3, param4, param5, param6].join(", ") + " )");
            _call("_addItem", param1, param2, param3, param4, param5, param6);
            return;
        }// end function

        public function clearIgnoredOrganic() : void
        {
            _debug.info("clearIgnoredOrganic()");
            _call("_clearIgnoreOrganic");
            return;
        }// end function

        public function setVar(param1:String) : void
        {
            _debug.info("setVar( " + param1 + " )");
            _call("_setVar", param1);
            return;
        }// end function

        public function setDomainName(param1:String) : void
        {
            _debug.info("setDomainName( " + param1 + " )");
            _call("_setDomainName", param1);
            return;
        }// end function

        public function hasTrackingAccount(param1:String) : Boolean
        {
            if (Utils.validateAccount(param1))
            {
                return _checkValidTrackingObject(param1);
            }
            return _checkTrackingObject(param1);
        }// end function

        public function setCampSourceKey(param1:String) : void
        {
            _debug.info("setCampSourceKey( " + param1 + " )");
            _call("_setCampSourceKey", param1);
            return;
        }// end function

        public function addTrans(param1:String, param2:String, param3:Number, param4:Number, param5:Number, param6:String, param7:String, param8:String) : Object
        {
            _debug.info("addTrans( " + [param1, param2, param3, param4, param5, param6, param7, param8].join(", ") + " )");
            _call("_addTrans", param1, param2, param3, param4, param5, param6, param7, param8);
            return null;
        }// end function

        public function setCampContentKey(param1:String) : void
        {
            _debug.info("setCampContentKey( " + param1 + " )");
            _call("_setCampContentKey", param1);
            return;
        }// end function

        public function setLocalServerMode() : void
        {
            _debug.info("setLocalServerMode()");
            _call("_setLocalServerMode");
            return;
        }// end function

        public function getLocalGifPath() : String
        {
            _debug.info("getLocalGifPath()");
            return _call("_getLocalGifPath");
        }// end function

        public function clearIgnoredRef() : void
        {
            _debug.info("clearIgnoredRef()");
            _call("_clearIgnoreRef");
            return;
        }// end function

        public function setAllowAnchor(param1:Boolean) : void
        {
            _debug.info("setAllowAnchor( " + param1 + " )");
            _call("_setAllowAnchor", param1);
            return;
        }// end function

        public function setLocalGifPath(param1:String) : void
        {
            _debug.info("setLocalGifPath( " + param1 + " )");
            _call("_setLocalGifPath", param1);
            return;
        }// end function

        public function getVersion() : String
        {
            _debug.info("getVersion()");
            return _call("_getVersion");
        }// end function

        private function _injectTrackingObject() : void
        {
            _proxy.executeBlock(_injectTrackingObject_js);
            _hasGATracker = true;
            return;
        }// end function

        public function setCookiePath(param1:String) : void
        {
            _debug.info("setCookiePath( " + param1 + " )");
            _call("_setCookiePath", param1);
            return;
        }// end function

        public function setSampleRate(param1:Number) : void
        {
            _debug.info("setSampleRate( " + param1 + " )");
            _call("_setSampleRate", param1);
            return;
        }// end function

        public function setAllowHash(param1:Boolean) : void
        {
            _debug.info("setAllowHash( " + param1 + " )");
            _call("_setAllowHash", param1);
            return;
        }// end function

        public function addIgnoredOrganic(param1:String) : void
        {
            _debug.info("addIgnoredOrganic( " + param1 + " )");
            _call("_addIgnoredOrganic", param1);
            return;
        }// end function

        public function setCampNOKey(param1:String) : void
        {
            _debug.info("setCampNOKey( " + param1 + " )");
            _call("_setCampNOKey", param1);
            return;
        }// end function

        public function cookiePathCopy(param1:String) : void
        {
            _debug.info("cookiePathCopy( " + param1 + " )");
            _call("_cookiePathCopy", param1);
            return;
        }// end function

        public function setLocalRemoteServerMode() : void
        {
            _debug.info("setLocalRemoteServerMode()");
            _call("_setLocalRemoteServerMode");
            return;
        }// end function

        public function getServiceMode() : ServerOperationMode
        {
            _debug.info("getServiceMode()");
            return _call("_getServiceMode");
        }// end function

        public function setDetectTitle(param1:Boolean) : void
        {
            _debug.info("setDetectTitle( " + param1 + " )");
            _call("_setDetectTitle", param1);
            return;
        }// end function

        private function _createTrackingObject(param1:String) : void
        {
            _proxy.call(_createTrackingObject_js, param1);
            return;
        }// end function

        public function setCampaignTrack(param1:Boolean) : void
        {
            _debug.info("setCampaignTrack( " + param1 + " )");
            _call("_setCampaignTrack", param1);
            return;
        }// end function

        public function clearOrganic() : void
        {
            _debug.info("clearOrganic()");
            _call("_clearOrganic");
            return;
        }// end function

        public function setCampTermKey(param1:String) : void
        {
            _debug.info("setCampTermKey( " + param1 + " )");
            _call("_setCampTermKey", param1);
            return;
        }// end function

        public function getDetectFlash() : Boolean
        {
            _debug.info("getDetectFlash()");
            return _call("_getDetectFlash");
        }// end function

        public function setCampMediumKey(param1:String) : void
        {
            _debug.info("setCampMediumKey( " + param1 + " )");
            _call("_setCampMediumKey", param1);
            return;
        }// end function

        public function addIgnoredRef(param1:String) : void
        {
            _debug.info("addIgnoredRef( " + param1 + " )");
            _call("_addIgnoredRef", param1);
            return;
        }// end function

        public function setSessionTimeout(param1:int) : void
        {
            _debug.info("setSessionTimeout( " + param1 + " )");
            _call("_setSessionTimeout", param1);
            return;
        }// end function

        public function setRemoteServerMode() : void
        {
            _debug.info("setRemoteServerMode()");
            _call("_setRemoteServerMode");
            return;
        }// end function

        public function getAccount() : String
        {
            _debug.info("getAccount()");
            return _call("_getAccount");
        }// end function

    }
}
