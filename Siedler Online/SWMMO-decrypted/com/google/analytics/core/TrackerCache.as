package com.google.analytics.core
{
    import com.google.analytics.v4.*;
    import flash.errors.*;

    public class TrackerCache extends Object implements GoogleAnalyticsAPI
    {
        public var tracker:GoogleAnalyticsAPI;
        private var _ar:Array;
        public static var CACHE_THROW_ERROR:Boolean;

        public function TrackerCache(param1:GoogleAnalyticsAPI = null)
        {
            this.tracker = param1;
            _ar = [];
            return;
        }// end function

        public function size() : uint
        {
            return _ar.length;
        }// end function

        public function flush() : void
        {
            var _loc_1:Object = null;
            var _loc_2:String = null;
            var _loc_3:Array = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (tracker == null)
            {
                return;
            }
            if (size() > 0)
            {
                _loc_4 = _ar.length;
                while (_loc_5 < _loc_4)
                {
                    
                    _loc_1 = _ar.shift();
                    _loc_2 = _loc_1.name as String;
                    _loc_3 = _loc_1.args as Array;
                    if (_loc_2 != null && _loc_2 in tracker)
                    {
                        (tracker[_loc_2] as Function).apply(tracker, _loc_3);
                    }
                    _loc_5++;
                }
            }
            return;
        }// end function

        public function enqueue(param1:String, ... args) : Boolean
        {
            if (param1 == null)
            {
                return false;
            }
            _ar.push({name:param1, args:args});
            return true;
        }// end function

        public function link(param1:String, param2:Boolean = false) : void
        {
            enqueue("link", param1, param2);
            return;
        }// end function

        public function addOrganic(param1:String, param2:String) : void
        {
            enqueue("addOrganic", param1, param2);
            return;
        }// end function

        public function setAllowLinker(param1:Boolean) : void
        {
            enqueue("setAllowLinker", param1);
            return;
        }// end function

        public function trackEvent(param1:String, param2:String, param3:String = null, param4:Number = NaN) : Boolean
        {
            enqueue("trackEvent", param1, param2, param3, param4);
            return true;
        }// end function

        public function getClientInfo() : Boolean
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getClientInfo\' method for the moment.");
            }
            return false;
        }// end function

        public function trackTrans() : void
        {
            enqueue("trackTrans");
            return;
        }// end function

        public function trackPageview(param1:String = "") : void
        {
            enqueue("trackPageview", param1);
            return;
        }// end function

        public function setClientInfo(param1:Boolean) : void
        {
            enqueue("setClientInfo", param1);
            return;
        }// end function

        public function linkByPost(param1:Object, param2:Boolean = false) : void
        {
            enqueue("linkByPost", param1, param2);
            return;
        }// end function

        public function setCookieTimeout(param1:int) : void
        {
            enqueue("setCookieTimeout", param1);
            return;
        }// end function

        public function isEmpty() : Boolean
        {
            return _ar.length == 0;
        }// end function

        public function getDetectTitle() : Boolean
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getDetectTitle\' method for the moment.");
            }
            return false;
        }// end function

        public function resetSession() : void
        {
            enqueue("resetSession");
            return;
        }// end function

        public function setDetectFlash(param1:Boolean) : void
        {
            enqueue("setDetectFlash", param1);
            return;
        }// end function

        public function clear() : void
        {
            _ar = [];
            return;
        }// end function

        public function setCampNameKey(param1:String) : void
        {
            enqueue("setCampNameKey", param1);
            return;
        }// end function

        public function addItem(param1:String, param2:String, param3:String, param4:String, param5:Number, param6:int) : void
        {
            enqueue("addItem", param1, param2, param3, param4, param5, param6);
            return;
        }// end function

        public function createEventTracker(param1:String) : EventTracker
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'createEventTracker\' method for the moment.");
            }
            return null;
        }// end function

        public function setVar(param1:String) : void
        {
            enqueue("setVar", param1);
            return;
        }// end function

        public function clearIgnoredOrganic() : void
        {
            enqueue("clearIgnoredOrganic");
            return;
        }// end function

        public function setDomainName(param1:String) : void
        {
            enqueue("setDomainName", param1);
            return;
        }// end function

        public function setCampSourceKey(param1:String) : void
        {
            enqueue("setCampSourceKey", param1);
            return;
        }// end function

        public function addTrans(param1:String, param2:String, param3:Number, param4:Number, param5:Number, param6:String, param7:String, param8:String) : Object
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'addTrans\' method for the moment.");
            }
            return null;
        }// end function

        public function setCampContentKey(param1:String) : void
        {
            enqueue("setCampContentKey", param1);
            return;
        }// end function

        public function setLocalServerMode() : void
        {
            enqueue("setLocalServerMode");
            return;
        }// end function

        public function getLocalGifPath() : String
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getLocalGifPath\' method for the moment.");
            }
            return "";
        }// end function

        public function setAllowAnchor(param1:Boolean) : void
        {
            enqueue("setAllowAnchor", param1);
            return;
        }// end function

        public function clearIgnoredRef() : void
        {
            enqueue("clearIgnoredRef");
            return;
        }// end function

        public function setLocalGifPath(param1:String) : void
        {
            enqueue("setLocalGifPath", param1);
            return;
        }// end function

        public function getVersion() : String
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getVersion\' method for the moment.");
            }
            return "";
        }// end function

        public function setCookiePath(param1:String) : void
        {
            enqueue("setCookiePath", param1);
            return;
        }// end function

        public function setSampleRate(param1:Number) : void
        {
            enqueue("setSampleRate", param1);
            return;
        }// end function

        public function setDetectTitle(param1:Boolean) : void
        {
            enqueue("setDetectTitle", param1);
            return;
        }// end function

        public function setAllowHash(param1:Boolean) : void
        {
            enqueue("setAllowHash", param1);
            return;
        }// end function

        public function addIgnoredOrganic(param1:String) : void
        {
            enqueue("addIgnoredOrganic", param1);
            return;
        }// end function

        public function setCampNOKey(param1:String) : void
        {
            enqueue("setCampNOKey", param1);
            return;
        }// end function

        public function getServiceMode() : ServerOperationMode
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getServiceMode\' method for the moment.");
            }
            return null;
        }// end function

        public function setLocalRemoteServerMode() : void
        {
            enqueue("setLocalRemoteServerMode");
            return;
        }// end function

        public function cookiePathCopy(param1:String) : void
        {
            enqueue("cookiePathCopy", param1);
            return;
        }// end function

        public function getDetectFlash() : Boolean
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getDetectFlash\' method for the moment.");
            }
            return false;
        }// end function

        public function setCampaignTrack(param1:Boolean) : void
        {
            enqueue("setCampaignTrack", param1);
            return;
        }// end function

        public function clearOrganic() : void
        {
            enqueue("clearOrganic");
            return;
        }// end function

        public function setCampTermKey(param1:String) : void
        {
            enqueue("setCampTermKey", param1);
            return;
        }// end function

        public function addIgnoredRef(param1:String) : void
        {
            enqueue("addIgnoredRef", param1);
            return;
        }// end function

        public function setCampMediumKey(param1:String) : void
        {
            enqueue("setCampMediumKey", param1);
            return;
        }// end function

        public function setSessionTimeout(param1:int) : void
        {
            enqueue("setSessionTimeout", param1);
            return;
        }// end function

        public function setRemoteServerMode() : void
        {
            enqueue("setRemoteServerMode");
            return;
        }// end function

        public function element()
        {
            return _ar[0];
        }// end function

        public function getAccount() : String
        {
            if (CACHE_THROW_ERROR)
            {
                throw new IllegalOperationError("The tracker is not ready and you can use the \'getAccount\' method for the moment.");
            }
            return "";
        }// end function

    }
}
