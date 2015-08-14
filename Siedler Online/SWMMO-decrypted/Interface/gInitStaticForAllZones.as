package Interface
{
    import NewQuestSystem.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.core.*;
    import nLib.*;

    public class gInitStaticForAllZones extends Object
    {
        private static var mLoadingScreenSteps:int = 0;
        private static const LOADING_SCREEN_STEPS:int = 10;
        private static var mDispatcherInitStaticForAllZones:cCustomDispatcher = new cCustomDispatcher();

        public function gInitStaticForAllZones()
        {
            return;
        }// end function

        private static function GfxResourcesLoadedCompleteHandler(event:Event) : void
        {
            mDispatcherInitStaticForAllZones.doAction();
            if (global.GAME_STATE == "Editor" || global.GAME_STATE == "MainMenu")
            {
                gGfxResource.mActivateStreaming = true;
            }
            return;
        }// end function

        private static function AllSettingsLoadedHandler(event:Event) : void
        {
            ShowLoadingScreen(20);
            gGfxResource.LoadAll(GfxResourcesLoadedCompleteHandler, 21);
            return;
        }// end function

        private static function GfxSettingsLoadedHandler(event:Event) : void
        {
            ShowLoadingScreen(15);
            gParse.ParseGameSettings(gGfxResource.GetGfxFolder_string() + global.gameSettingsFilename, GameSettingsLoadedHandler);
            return;
        }// end function

        public static function ShowLoadingScreen(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:Rectangle = null;
            var _loc_13:Point = null;
            var _loc_14:Rectangle = null;
            var _loc_15:Point = null;
            var _loc_16:Rectangle = null;
            var _loc_18:* = mLoadingScreenSteps - 1;
            mLoadingScreenSteps = _loc_18;
            if (mLoadingScreenSteps < 0)
            {
                _loc_2 = gGfxResource.gLoadingScreenGfxGraphics.mBitmap.width;
                _loc_3 = gGfxResource.gLoadingScreenGfxGraphics.mBitmap.height;
                _loc_4 = global.screenWidthHalf - _loc_2 / 2;
                _loc_5 = global.screenHeightHalf - _loc_3 / 2;
                _loc_6 = _loc_4 + 101;
                _loc_7 = _loc_5 + 417;
                _loc_8 = 525;
                _loc_9 = 9;
                if (mLoadingScreenSteps < 0)
                {
                    _loc_14 = new Rectangle(0, 0, _loc_2, _loc_3);
                    _loc_15 = new Point(_loc_4, _loc_5);
                    _loc_16 = new Rectangle(_loc_4 + 101, _loc_5 + 417, 525, 9);
                    cBackbuffer.Lock();
                    cBackbuffer.Clear(16708586);
                    cBackbuffer.mBackBuffer.copyPixels(gGfxResource.gLoadingScreenGfxGraphics.mBitmap, _loc_14, _loc_15, null, null, false);
                    cBackbuffer.mBackBuffer.fillRect(_loc_16, 597293);
                    cBackbuffer.Unlock();
                }
                _loc_10 = 260;
                _loc_11 = 525 * (param1 * 100 / _loc_10) / 100;
                _loc_12 = new Rectangle(_loc_6 - _loc_4, _loc_7 - _loc_5, _loc_11, _loc_9);
                _loc_13 = new Point(_loc_6, _loc_7);
                cBackbuffer.Lock();
                cBackbuffer.mBackBuffer.copyPixels(gGfxResource.gLoadingScreenGfxGraphics.mBitmap, _loc_12, _loc_13, null, null, false);
                cBackbuffer.Unlock();
                Application.application.myCanvas.graphics.clear();
                Application.application.myCanvas.graphics.beginBitmapFill(cBackbuffer.mBackBuffer, null, false, false);
                Application.application.myCanvas.graphics.drawRect(0, 0, cBackbuffer.mBackBuffer.width, cBackbuffer.mBackBuffer.height);
                Application.application.myCanvas.graphics.endFill();
                mLoadingScreenSteps = LOADING_SCREEN_STEPS;
            }
            return;
        }// end function

        public static function Init(param1:Function) : void
        {
            if (defines.USE_PHP)
            {
                defines.USE_EXTERNAL_SERVER = Application.application.parameters.e == "true";
                defines.USE_BIG_BROTHER = Application.application.parameters.ubb == "true";
                defines.BIG_BROTHER_URL = Application.application.parameters.bb;
                defines.STATIC_FILES_URL_LIST = Application.application.parameters.s.split("|");
                defines.CHAT_SOCKET_URL = Application.application.parameters.chatS;
                defines.CHAT_BOSH_URL = Application.application.parameters.chatB;
                if (!Application.application.parameters.hasOwnProperty("country"))
                {
                    Application.application.parameters["country"] = "de";
                }
                defines.USER_COUNTRY = Application.application.parameters.country.toLowerCase();
            }
            else
            {
                defines.USE_EXTERNAL_SERVER = true;
                defines.USE_BIG_BROTHER = false;
                defines.BIG_BROTHER_URL = "http://10.26.100.147:8080/GameServer";
                defines.STATIC_FILES_URL_LIST = ["http://10.26.100.147:80/SWMMO"];
                defines.CHAT_SOCKET_URL = "xmlsocket://localhost:90";
                defines.CHAT_BOSH_URL = "http://localhost:90";
                defines.USER_COUNTRY = "de";
            }
            cBackbuffer.Init(global.screenWidth, global.screenHeight, false);
            cBackbuffer.Clear(defines.DEFAULT_BACKGROUND_CLEAR_COLOR);
            ShowLoadingScreen(10);
            gCalculations.Init();
            QuestManagerStatic.Init();
            mDispatcherInitStaticForAllZones.addEventListener(cCustomDispatcher.mAction_string, param1);
            gParse.ParseGfxSettings(gGfxResource.GetGfxFolder_string() + "gfx_settings.xml", GfxSettingsLoadedHandler);
            return;
        }// end function

        public static function ClearScreen() : void
        {
            Application.application.myCanvas.graphics.clear();
            Application.application.myCanvas.graphics.beginFill(-1);
            Application.application.myCanvas.graphics.endFill();
            return;
        }// end function

        private static function GameSettingsLoadedHandler(event:Event) : void
        {
            ShowLoadingScreen(15);
            gParse.ParseShopConfig(gGfxResource.GetGfxFolder_string() + global.shopConfigFilename, AllSettingsLoadedHandler);
            return;
        }// end function

    }
}
