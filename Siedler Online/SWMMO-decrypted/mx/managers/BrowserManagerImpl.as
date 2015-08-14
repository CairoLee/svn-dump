package mx.managers
{
    import flash.display.*;
    import flash.events.*;
    import flash.external.*;
    import flash.net.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class BrowserManagerImpl extends EventDispatcher implements IBrowserManager
    {
        private var _title:String;
        private var _isFirefoxMac:Boolean;
        private var browserMode:Boolean = true;
        private var _fragment:String;
        private var _base:String;
        private var _browserUserAgent:String;
        private var _url:String;
        private var _defaultFragment:String = "";
        private var _browserPlatform:String;
        static const VERSION:String = "3.5.0.12683";
        private static var instance:IBrowserManager;

        public function BrowserManagerImpl()
        {
            var sandboxRoot:Object;
            var parent:Object;
            var systemManager:* = SystemManagerGlobals.topLevelSystemManagers;
            if (systemManager)
            {
                systemManager = systemManager[0];
            }
            if (systemManager)
            {
                sandboxRoot = systemManager.getSandboxRoot();
                if (!sandboxRoot.dispatchEvent(new Event("mx.managers::BrowserManager", false, true)))
                {
                    browserMode = false;
                    return;
                }
                try
                {
                    parent = sandboxRoot.parent;
                    while (parent)
                    {
                        
                        if (sandboxRoot.parent is Stage)
                        {
                            break;
                            continue;
                        }
                        parent = parent.parent;
                    }
                }
                catch (e:Error)
                {
                    browserMode = false;
                    return;
                }
                sandboxRoot.addEventListener("mx.managers::BrowserManager", sandboxBrowserManagerHandler, false, 0, true);
            }
            try
            {
                ExternalInterface.addCallback("browserURLChange", browserURLChangeBrowser);
                ExternalInterface.addCallback("debugTrace", debugTrace);
            }
            catch (e:Error)
            {
                browserMode = false;
            }
            return;
        }// end function

        public function initForHistoryManager() : void
        {
            setup("", "");
            return;
        }// end function

        private function setup(param1:String, param2:String) : void
        {
            if (!browserMode)
            {
                return;
            }
            _defaultFragment = param1;
            _url = ExternalInterface.call("BrowserHistory.getURL");
            if (!_url)
            {
                browserMode = false;
                return;
            }
            _browserUserAgent = ExternalInterface.call("BrowserHistory.getUserAgent");
            _browserPlatform = ExternalInterface.call("BrowserHistory.getPlatform");
            _isFirefoxMac = _browserUserAgent && _browserPlatform && _browserUserAgent.indexOf("Firefox") > -1 && _browserPlatform.indexOf("Mac") > -1;
            var _loc_3:* = _url.indexOf("#");
            if (_loc_3 == -1 || _loc_3 == (_url.length - 1))
            {
                _base = _url;
                _fragment = "";
                _title = param2;
                ExternalInterface.call("BrowserHistory.setDefaultURL", param1);
                setTitle(param2);
            }
            else
            {
                _base = _url.substring(0, _loc_3);
                _fragment = _url.substring((_loc_3 + 1));
                _title = ExternalInterface.call("BrowserHistory.getTitle");
                ExternalInterface.call("BrowserHistory.setDefaultURL", _fragment);
                if (_fragment != _defaultFragment)
                {
                    browserURLChange(_fragment, true);
                }
            }
            return;
        }// end function

        private function browserURLChange(param1:String, param2:Boolean = false) : void
        {
            var _loc_3:String = null;
            if (param1 != null && decodeURI(_fragment) != decodeURI(param1) || param2)
            {
                _fragment = param1;
                _loc_3 = url;
                _url = _base + "#" + param1;
                dispatchEvent(new BrowserChangeEvent(BrowserChangeEvent.BROWSER_URL_CHANGE, false, false, url, _loc_3));
                dispatchEvent(new BrowserChangeEvent(BrowserChangeEvent.URL_CHANGE, false, false, url, _loc_3));
            }
            return;
        }// end function

        public function get base() : String
        {
            return _base;
        }// end function

        public function setFragment(param1:String) : void
        {
            var _loc_4:URLRequest = null;
            if (!browserMode)
            {
                return;
            }
            var _loc_2:* = _url;
            var _loc_3:* = _fragment;
            _url = base + "#" + param1;
            _fragment = param1;
            if (dispatchEvent(new BrowserChangeEvent(BrowserChangeEvent.APPLICATION_URL_CHANGE, false, true, _url, _loc_2)))
            {
                if (!_isFirefoxMac)
                {
                    ExternalInterface.call("BrowserHistory.setBrowserURL", param1, ExternalInterface.objectID);
                }
                else
                {
                    _loc_4 = new URLRequest("javascript:BrowserHistory.setBrowserURL(\'" + param1 + "\',\'" + ExternalInterface.objectID + "\');");
                    navigateToURL(_loc_4, "_self");
                }
                dispatchEvent(new BrowserChangeEvent(BrowserChangeEvent.URL_CHANGE, false, false, _url, _loc_2));
            }
            else
            {
                _fragment = _loc_3;
                _url = _loc_2;
            }
            return;
        }// end function

        private function debugTrace(param1:String) : void
        {
            trace(param1);
            return;
        }// end function

        public function get fragment() : String
        {
            if (_fragment && _fragment.length)
            {
                return _fragment;
            }
            return _defaultFragment;
        }// end function

        public function get title() : String
        {
            return _title;
        }// end function

        public function setTitle(param1:String) : void
        {
            if (!browserMode)
            {
                return;
            }
            ExternalInterface.call("BrowserHistory.setTitle", param1);
            _title = ExternalInterface.call("BrowserHistory.getTitle");
            return;
        }// end function

        public function init(param1:String = "", param2:String = "") : void
        {
            ApplicationGlobals.application.historyManagementEnabled = false;
            setup(param1, param2);
            return;
        }// end function

        private function sandboxBrowserManagerHandler(event:Event) : void
        {
            event.preventDefault();
            return;
        }// end function

        private function browserURLChangeBrowser(param1:String) : void
        {
            browserURLChange(param1, false);
            return;
        }// end function

        public function get url() : String
        {
            return _url;
        }// end function

        public static function getInstance() : IBrowserManager
        {
            if (!instance)
            {
                instance = new BrowserManagerImpl;
            }
            return instance;
        }// end function

    }
}
