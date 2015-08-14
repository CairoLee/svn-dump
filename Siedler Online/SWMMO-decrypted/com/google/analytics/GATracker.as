package com.google.analytics
{
    import com.google.analytics.*;
    import com.google.analytics.core.*;
    import com.google.analytics.debug.*;
    import com.google.analytics.events.*;
    import com.google.analytics.external.*;
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;
    import flash.display.*;
    import flash.events.*;

    public class GATracker extends Object implements AnalyticsTracker
    {
        private var _adSense:AdSenseGlobals;
        private var _env:Environment;
        private var _visualDebug:Boolean;
        private var _idleTimer:IdleTimer;
        private var _debug:DebugConfiguration;
        private var _buffer:Buffer;
        private var _config:Configuration;
        private var _mode:String;
        private var _display:DisplayObject;
        private var _jsproxy:JavascriptProxy;
        private var _dom:HTMLDOM;
        private var _eventDispatcher:EventDispatcher;
        private var _ready:Boolean = false;
        private var _gifRequest:GIFRequest;
        private var _account:String;
        private var _tracker:GoogleAnalyticsAPI;
        public static var version:Version = API.version;
        public static var autobuild:Boolean = true;

        public function GATracker(param1:DisplayObject, param2:String, param3:String = "AS3", param4:Boolean = false, param5:Configuration = null, param6:DebugConfiguration = null)
        {
            _display = param1;
            _eventDispatcher = new EventDispatcher(this);
            _tracker = new TrackerCache();
            this.account = param2;
            this.mode = param3;
            this.visualDebug = param4;
            if (!param6)
            {
                this.debug = new DebugConfiguration();
            }
            if (!param5)
            {
                this.config = new Configuration(param6);
            }
            if (autobuild)
            {
                _factory();
            }
            return;
        }// end function

        public function link(param1:String, param2:Boolean = false) : void
        {
            _tracker.link(param1, param2);
            return;
        }// end function

        public function addOrganic(param1:String, param2:String) : void
        {
            _tracker.addOrganic(param1, param2);
            return;
        }// end function

        public function setAllowLinker(param1:Boolean) : void
        {
            _tracker.setAllowLinker(param1);
            return;
        }// end function

        public function trackEvent(param1:String, param2:String, param3:String = null, param4:Number = NaN) : Boolean
        {
            return _tracker.trackEvent(param1, param2, param3, param4);
        }// end function

        public function setCookieTimeout(param1:int) : void
        {
            _tracker.setCookieTimeout(param1);
            return;
        }// end function

        public function trackTrans() : void
        {
            _tracker.trackTrans();
            return;
        }// end function

        public function getClientInfo() : Boolean
        {
            return _tracker.getClientInfo();
        }// end function

        public function trackPageview(param1:String = "") : void
        {
            _tracker.trackPageview(param1);
            return;
        }// end function

        public function setClientInfo(param1:Boolean) : void
        {
            _tracker.setClientInfo(param1);
            return;
        }// end function

        public function get account() : String
        {
            return _account;
        }// end function

        public function linkByPost(param1:Object, param2:Boolean = false) : void
        {
            _tracker.linkByPost(param1, param2);
            return;
        }// end function

        public function getDetectTitle() : Boolean
        {
            return _tracker.getDetectTitle();
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return _eventDispatcher.dispatchEvent(event);
        }// end function

        public function get config() : Configuration
        {
            return _config;
        }// end function

        public function set mode(param1:String) : void
        {
            _mode = param1;
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            _eventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function setDetectFlash(param1:Boolean) : void
        {
            _tracker.setDetectFlash(param1);
            return;
        }// end function

        public function resetSession() : void
        {
            _tracker.resetSession();
            return;
        }// end function

        public function setCampNameKey(param1:String) : void
        {
            _tracker.setCampNameKey(param1);
            return;
        }// end function

        public function get debug() : DebugConfiguration
        {
            return _debug;
        }// end function

        public function addItem(param1:String, param2:String, param3:String, param4:String, param5:Number, param6:int) : void
        {
            _tracker.addItem(param1, param2, param3, param4, param5, param6);
            return;
        }// end function

        private function _bridgeFactory() : GoogleAnalyticsAPI
        {
            debug.info("GATracker (Bridge) v" + version + "\naccount: " + account);
            return new Bridge(account, _debug, _jsproxy);
        }// end function

        public function clearIgnoredOrganic() : void
        {
            _tracker.clearIgnoredOrganic();
            return;
        }// end function

        public function set account(param1:String) : void
        {
            _account = param1;
            return;
        }// end function

        public function setVar(param1:String) : void
        {
            _tracker.setVar(param1);
            return;
        }// end function

        public function build() : void
        {
            if (!isReady())
            {
                _factory();
            }
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            _eventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function setDomainName(param1:String) : void
        {
            _tracker.setDomainName(param1);
            return;
        }// end function

        public function createEventTracker(param1:String) : EventTracker
        {
            return _tracker.createEventTracker(param1);
        }// end function

        public function setCampSourceKey(param1:String) : void
        {
            _tracker.setCampSourceKey(param1);
            return;
        }// end function

        public function set config(param1:Configuration) : void
        {
            _config = param1;
            return;
        }// end function

        public function addTrans(param1:String, param2:String, param3:Number, param4:Number, param5:Number, param6:String, param7:String, param8:String) : Object
        {
            return _tracker.addTrans(param1, param2, param3, param4, param5, param6, param7, param8);
        }// end function

        public function setCampContentKey(param1:String) : void
        {
            _tracker.setCampContentKey(param1);
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return _eventDispatcher.willTrigger(param1);
        }// end function

        public function setLocalServerMode() : void
        {
            _tracker.setLocalServerMode();
            return;
        }// end function

        public function getLocalGifPath() : String
        {
            return _tracker.getLocalGifPath();
        }// end function

        public function setAllowAnchor(param1:Boolean) : void
        {
            _tracker.setAllowAnchor(param1);
            return;
        }// end function

        public function clearIgnoredRef() : void
        {
            _tracker.clearIgnoredRef();
            return;
        }// end function

        public function isReady() : Boolean
        {
            return _ready;
        }// end function

        public function get mode() : String
        {
            return _mode;
        }// end function

        public function set debug(param1:DebugConfiguration) : void
        {
            _debug = param1;
            return;
        }// end function

        public function setLocalGifPath(param1:String) : void
        {
            _tracker.setLocalGifPath(param1);
            return;
        }// end function

        public function getVersion() : String
        {
            return _tracker.getVersion();
        }// end function

        public function setSampleRate(param1:Number) : void
        {
            _tracker.setSampleRate(param1);
            return;
        }// end function

        public function setCookiePath(param1:String) : void
        {
            _tracker.setCookiePath(param1);
            return;
        }// end function

        public function setAllowHash(param1:Boolean) : void
        {
            _tracker.setAllowHash(param1);
            return;
        }// end function

        public function addIgnoredOrganic(param1:String) : void
        {
            _tracker.addIgnoredOrganic(param1);
            return;
        }// end function

        public function setLocalRemoteServerMode() : void
        {
            _tracker.setLocalRemoteServerMode();
            return;
        }// end function

        public function cookiePathCopy(param1:String) : void
        {
            _tracker.cookiePathCopy(param1);
            return;
        }// end function

        private function _factory() : void
        {
            var _loc_1:GoogleAnalyticsAPI = null;
            _jsproxy = new JavascriptProxy(debug);
            if (visualDebug)
            {
                debug.layout = new Layout(debug, _display);
                debug.active = visualDebug;
            }
            var _loc_2:* = _tracker as TrackerCache;
            switch(mode)
            {
                case TrackerMode.BRIDGE:
                {
                    _loc_1 = _bridgeFactory();
                    break;
                }
                case TrackerMode.AS3:
                {
                }
                default:
                {
                    _loc_1 = _trackerFactory();
                    break;
                }
            }
            if (!_loc_2.isEmpty())
            {
                _loc_2.tracker = _loc_1;
                _loc_2.flush();
            }
            _tracker = _loc_1;
            _ready = true;
            dispatchEvent(new AnalyticsEvent(AnalyticsEvent.READY, this));
            return;
        }// end function

        public function setCampTermKey(param1:String) : void
        {
            _tracker.setCampTermKey(param1);
            return;
        }// end function

        private function _trackerFactory() : GoogleAnalyticsAPI
        {
            debug.info("GATracker (AS3) v" + version + "\naccount: " + account);
            _adSense = new AdSenseGlobals(debug);
            _dom = new HTMLDOM(debug);
            _dom.cacheProperties();
            _env = new Environment("", "", "", debug, _dom);
            _buffer = new Buffer(config, debug, false);
            _gifRequest = new GIFRequest(config, debug, _buffer, _env);
            _idleTimer = new IdleTimer(config, debug, _display, _buffer);
            _env.url = _display.stage.loaderInfo.url;
            return new Tracker(account, config, debug, _env, _buffer, _gifRequest, _adSense);
        }// end function

        public function setCampNOKey(param1:String) : void
        {
            _tracker.setCampNOKey(param1);
            return;
        }// end function

        public function setDetectTitle(param1:Boolean) : void
        {
            _tracker.setDetectTitle(param1);
            return;
        }// end function

        public function getServiceMode() : ServerOperationMode
        {
            return _tracker.getServiceMode();
        }// end function

        public function clearOrganic() : void
        {
            _tracker.clearOrganic();
            return;
        }// end function

        public function setCampaignTrack(param1:Boolean) : void
        {
            _tracker.setCampaignTrack(param1);
            return;
        }// end function

        public function addIgnoredRef(param1:String) : void
        {
            _tracker.addIgnoredRef(param1);
            return;
        }// end function

        public function set visualDebug(param1:Boolean) : void
        {
            _visualDebug = param1;
            return;
        }// end function

        public function setCampMediumKey(param1:String) : void
        {
            _tracker.setCampMediumKey(param1);
            return;
        }// end function

        public function getDetectFlash() : Boolean
        {
            return _tracker.getDetectFlash();
        }// end function

        public function get visualDebug() : Boolean
        {
            return _visualDebug;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return _eventDispatcher.hasEventListener(param1);
        }// end function

        public function getAccount() : String
        {
            return _tracker.getAccount();
        }// end function

        public function setSessionTimeout(param1:int) : void
        {
            _tracker.setSessionTimeout(param1);
            return;
        }// end function

        public function setRemoteServerMode() : void
        {
            _tracker.setRemoteServerMode();
            return;
        }// end function

    }
}
