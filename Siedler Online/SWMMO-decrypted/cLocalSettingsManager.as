package 
{
    import Communication.VO.*;
    import GUI.GAME.Chat.*;
    import ServerState.*;
    import cLocalSettingsManager.*;
    import flash.events.*;
    import flash.net.*;

    public class cLocalSettingsManager extends Object
    {
        private static var _settings:dLocalUserSettingsVO;
        public static const COOKIE_NAME:String = "TheSettlersOnline";
        private static var _AssetSO:SharedObject;
        private static var _so:SharedObject;
        public static const ASSET_STORAGE_NAME:String = "TheSettlersOnlineGFX";

        public function cLocalSettingsManager()
        {
            return;
        }// end function

        public static function set tradeCooldownStartTime(param1:Date) : void
        {
            settings.tradeCooldownStartTime = param1;
            saveSettings();
            return;
        }// end function

        private static function saveSettings() : void
        {
            if (!_so)
            {
                try
                {
                    _so = SharedObject.getLocal(COOKIE_NAME);
                }
                catch (e:Error)
                {
                    return;
                }
            }
            if (_settings == null)
            {
                _settings = new dLocalUserSettingsVO();
            }
            _so.data["u" + cClientMessagesII.mAuthUser] = _settings;
            return;
        }// end function

        public static function get effectsMuted() : Boolean
        {
            if (settings != null)
            {
                return settings.effectsMuted;
            }
            return false;
        }// end function

        public static function set effectsMuted(param1:Boolean) : void
        {
            if (settings != null)
            {
                settings.effectsMuted = param1;
            }
            saveSettings();
            return;
        }// end function

        public static function set currentGlobalChatInstance(param1:int) : void
        {
            if (settings != null)
            {
                settings.currentGlobalChatInstance = param1;
            }
            saveSettings();
            return;
        }// end function

        static function netStatusHandler(event:NetStatusEvent) : void
        {
            event.stopImmediatePropagation();
            return;
        }// end function

        public static function get loopsMuted() : Boolean
        {
            if (settings != null)
            {
                return settings.loopsMuted;
            }
            return false;
        }// end function

        public static function get tradeCooldownStartTime() : Date
        {
            if (settings != null)
            {
                return settings.tradeCooldownStartTime;
            }
            return null;
        }// end function

        private static function get settings() : dLocalUserSettingsVO
        {
            if (_settings != null)
            {
                return _settings;
            }
            try
            {
                if (!_so)
                {
                    _so = SharedObject.getLocal(COOKIE_NAME);
                }
            }
            catch (e:Error)
            {
                saveSettings();
            }
            _settings = _so.data["u" + cClientMessagesII.mAuthUser];
            if (_settings == null)
            {
                saveSettings();
            }
            return _settings;
        }// end function

        public static function get currentGlobalChatInstance() : int
        {
            if (settings != null)
            {
                return settings.currentGlobalChatInstance;
            }
            return 0;
        }// end function

        public static function set saveLocal(param1:Boolean) : void
        {
            saveSettings();
            if (param1)
            {
                _AssetSO = SharedObject.getLocal(ASSET_STORAGE_NAME);
                _AssetSO.addEventListener(NetStatusEvent.NET_STATUS, netStatusHandler);
                _AssetSO.flush(100000000);
            }
            return;
        }// end function

        public static function get saveLocal() : Boolean
        {
            return false;
        }// end function

        public static function get currentTradeOffer() : cTradeData
        {
            if (settings != null)
            {
                return settings.currentTradeOffer;
            }
            return null;
        }// end function

        public static function set loopsMuted(param1:Boolean) : void
        {
            if (settings != null)
            {
                settings.loopsMuted = param1;
            }
            saveSettings();
            return;
        }// end function

        public static function set currentTradeOffer(param1:cTradeData) : void
        {
            if (settings != null)
            {
                settings.currentTradeOffer = param1;
            }
            saveSettings();
            return;
        }// end function

    }
}
