package mx.managers
{
    import flash.display.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class HistoryManagerImpl extends Object implements IHistoryManager
    {
        private var registeredObjects:Array;
        private var pendingQueryString:String;
        private var pendingStates:Object;
        private var registrationMap:Dictionary;
        private static const NAME_VALUE_SEPARATOR:String = "=";
        private static var instance:IHistoryManager;
        private static var appID:String;
        private static const HANDSHAKE_INTERVAL:int = 500;
        private static var historyURL:String;
        private static const ID_NAME_SEPARATOR:String = "-";
        private static const MAX_HANDSHAKE_TRIES:int = 100;
        static const VERSION:String = "3.5.0.12683";
        private static const PROPERTY_SEPARATOR:String = "&";
        private static var systemManager:ISystemManager;

        public function HistoryManagerImpl()
        {
            var _loc_1:LoaderInfo = null;
            var _loc_2:String = null;
            registeredObjects = [];
            pendingStates = {};
            if (instance)
            {
                throw new Error("Instance already exists.");
            }
            if (appID)
            {
                return;
            }
            if (!ApplicationGlobals.application.historyManagementEnabled)
            {
                return;
            }
            if (HistoryManagerGlobals.loaderInfo)
            {
                _loc_1 = HistoryManagerGlobals.loaderInfo;
            }
            else
            {
                _loc_1 = DisplayObject(systemManager).loaderInfo;
            }
            if (HistoryManagerGlobals.loaderInfo)
            {
                _loc_2 = HistoryManagerGlobals.loaderInfo.url;
            }
            else
            {
                _loc_2 = DisplayObject(systemManager).loaderInfo.url;
            }
            appID = calcCRC(_loc_2);
            BrowserManager.getInstance().addEventListener(BrowserChangeEvent.BROWSER_URL_CHANGE, browserURLChangeHandler);
            BrowserManager.getInstance().initForHistoryManager();
            return;
        }// end function

        public function registered() : void
        {
            return;
        }// end function

        public function unregister(param1:IHistoryManagerClient) : void
        {
            if (!ApplicationGlobals.application.historyManagementEnabled)
            {
                return;
            }
            var _loc_2:int = -1;
            var _loc_3:* = registeredObjects.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                if (registeredObjects[_loc_4] == param1)
                {
                    _loc_2 = _loc_4;
                    break;
                }
                _loc_4++;
            }
            if (_loc_2 >= 0)
            {
                registeredObjects.splice(_loc_2, 1);
            }
            if (param1 && registrationMap)
            {
                delete registrationMap[param1];
            }
            return;
        }// end function

        private function updateCRC(param1:uint, param2:uint) : uint
        {
            var _loc_6:Boolean = false;
            var _loc_3:uint = 4129;
            var _loc_4:uint = 128;
            var _loc_5:int = 0;
            while (_loc_5 < 8)
            {
                
                _loc_6 = (param1 & 32768) != 0;
                param1 = param1 << 1;
                param1 = param1 & 65535;
                if ((param2 & _loc_4) != 0)
                {
                    param1 = param1 + 1;
                }
                if (_loc_6)
                {
                    param1 = param1 ^ _loc_3;
                }
                _loc_4 = _loc_4 >> 1;
                _loc_5++;
            }
            return param1;
        }// end function

        private function submitQuery() : void
        {
            if (pendingQueryString)
            {
                BrowserManager.getInstance().setFragment(pendingQueryString);
                pendingQueryString = null;
                ApplicationGlobals.application.resetHistory = true;
            }
            return;
        }// end function

        public function browserURLChangeHandler(event:BrowserChangeEvent) : void
        {
            var _loc_2:String = null;
            var _loc_3:String = null;
            var _loc_9:Array = null;
            var _loc_10:int = 0;
            var _loc_11:String = null;
            var _loc_12:Object = null;
            var _loc_13:IHistoryManagerClient = null;
            if (!ApplicationGlobals.application.historyManagementEnabled)
            {
                return;
            }
            var _loc_4:* = event.url.split(PROPERTY_SEPARATOR);
            var _loc_5:Object = {};
            var _loc_6:* = _loc_4.length;
            var _loc_7:int = 0;
            while (_loc_7 < _loc_6)
            {
                
                _loc_9 = _loc_4[_loc_7].split(NAME_VALUE_SEPARATOR);
                _loc_5[_loc_9[0]] = parseString(_loc_9[1]);
                _loc_7++;
            }
            var _loc_8:Object = {};
            for (_loc_2 in _loc_5)
            {
                
                _loc_10 = _loc_2.indexOf(ID_NAME_SEPARATOR);
                if (_loc_10 > -1)
                {
                    _loc_3 = _loc_2.substr(0, _loc_10);
                    _loc_11 = _loc_2.substr((_loc_10 + 1), _loc_2.length);
                    _loc_12 = _loc_5[_loc_2];
                    if (!_loc_8[_loc_3])
                    {
                        _loc_8[_loc_3] = {};
                    }
                    _loc_8[_loc_3][_loc_11] = _loc_12;
                }
            }
            _loc_6 = registeredObjects.length;
            _loc_7 = 0;
            while (_loc_7 < _loc_6)
            {
                
                _loc_13 = registeredObjects[_loc_7];
                _loc_3 = getRegistrationInfo(_loc_13).crc;
                _loc_13.loadState(_loc_8[_loc_3]);
                delete _loc_8[_loc_3];
                _loc_7++;
            }
            for (_loc_2 in _loc_8)
            {
                
                pendingStates[_loc_2] = _loc_8[_loc_2];
            }
            return;
        }// end function

        public function registerHandshake() : void
        {
            return;
        }// end function

        private function getRegistrationInfo(param1:IHistoryManagerClient) : RegistrationInfo
        {
            return registrationMap ? (registrationMap[param1]) : (null);
        }// end function

        private function getPath(param1:IHistoryManagerClient) : String
        {
            return param1.toString();
        }// end function

        public function load(param1:Object) : void
        {
            return;
        }// end function

        private function depthCompare(param1:Object, param2:Object) : int
        {
            var _loc_3:* = getRegistrationInfo(IHistoryManagerClient(param1));
            var _loc_4:* = getRegistrationInfo(IHistoryManagerClient(param2));
            if (!_loc_3 || !_loc_4)
            {
                return 0;
            }
            if (_loc_3.depth > _loc_4.depth)
            {
                return 1;
            }
            if (_loc_3.depth < _loc_4.depth)
            {
                return -1;
            }
            return 0;
        }// end function

        public function register(param1:IHistoryManagerClient) : void
        {
            if (!ApplicationGlobals.application.historyManagementEnabled)
            {
                return;
            }
            unregister(param1);
            registeredObjects.push(param1);
            var _loc_2:* = getPath(param1);
            var _loc_3:* = calcCRC(_loc_2);
            var _loc_4:* = calcDepth(_loc_2);
            if (!registrationMap)
            {
                registrationMap = new Dictionary(true);
            }
            registrationMap[param1] = new RegistrationInfo(_loc_3, _loc_4);
            registeredObjects.sort(depthCompare);
            if (pendingStates[_loc_3])
            {
                param1.loadState(pendingStates[_loc_3]);
                delete pendingStates[_loc_3];
            }
            return;
        }// end function

        private function parseString(param1:String) : Object
        {
            if (param1 == "true")
            {
                return true;
            }
            if (param1 == "false")
            {
                return false;
            }
            var _loc_2:* = parseInt(param1);
            if (_loc_2.toString() == param1)
            {
                return _loc_2;
            }
            var _loc_3:* = parseFloat(param1);
            if (_loc_3.toString() == param1)
            {
                return _loc_3;
            }
            return param1;
        }// end function

        private function calcDepth(param1:String) : int
        {
            return param1.split(".").length;
        }// end function

        public function loadInitialState() : void
        {
            return;
        }// end function

        public function save() : void
        {
            var _loc_5:IHistoryManagerClient = null;
            var _loc_6:Object = null;
            var _loc_7:String = null;
            var _loc_8:String = null;
            var _loc_9:Object = null;
            if (!ApplicationGlobals.application.historyManagementEnabled)
            {
                return;
            }
            var _loc_1:Boolean = false;
            var _loc_2:* = "app=" + appID;
            var _loc_3:* = registeredObjects.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_5 = registeredObjects[_loc_4];
                _loc_6 = _loc_5.saveState();
                _loc_7 = getRegistrationInfo(_loc_5).crc;
                for (_loc_8 in _loc_6)
                {
                    
                    _loc_9 = _loc_6[_loc_8];
                    if (_loc_2.length > 0)
                    {
                        _loc_2 = _loc_2 + PROPERTY_SEPARATOR;
                    }
                    _loc_2 = _loc_2 + _loc_7;
                    _loc_2 = _loc_2 + ID_NAME_SEPARATOR;
                    _loc_2 = _loc_2 + escape(_loc_8);
                    _loc_2 = _loc_2 + NAME_VALUE_SEPARATOR;
                    _loc_2 = _loc_2 + escape(_loc_9.toString());
                    _loc_1 = true;
                }
                _loc_4++;
            }
            if (_loc_1)
            {
                pendingQueryString = _loc_2;
                ApplicationGlobals.application.callLater(this.submitQuery);
            }
            return;
        }// end function

        private function calcCRC(param1:String) : String
        {
            var _loc_5:uint = 0;
            var _loc_6:uint = 0;
            var _loc_7:uint = 0;
            var _loc_2:uint = 65535;
            var _loc_3:* = param1.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_5 = param1.charCodeAt(_loc_4);
                _loc_6 = _loc_5 & 255;
                _loc_7 = _loc_5 >> 8;
                if (_loc_7 != 0)
                {
                    _loc_2 = updateCRC(_loc_2, _loc_7);
                }
                _loc_2 = updateCRC(_loc_2, _loc_6);
                _loc_4++;
            }
            _loc_2 = updateCRC(_loc_2, 0);
            _loc_2 = updateCRC(_loc_2, 0);
            return _loc_2.toString(16);
        }// end function

        public static function getInstance() : IHistoryManager
        {
            if (!instance)
            {
                systemManager = SystemManagerGlobals.topLevelSystemManagers[0];
                instance = new HistoryManagerImpl;
            }
            return instance;
        }// end function

    }
}

class RegistrationInfo extends Object
{
    public var depth:int;
    public var crc:String;
    static const VERSION:String = "3.5.0.12683";

    function RegistrationInfo(param1:String, param2:int)
    {
        this.crc = param1;
        this.depth = param2;
        return;
    }// end function

}

