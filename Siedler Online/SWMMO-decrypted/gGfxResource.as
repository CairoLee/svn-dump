package 
{
    import Enums.*;
    import GO.*;
    import GOSets.*;
    import GUI.Assets.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.display.*;
    import flash.events.*;
    import flash.filters.*;
    import flash.utils.*;
    import nLib.*;

    final public class gGfxResource extends Object
    {
        public static var mWaitForCommandIcon:cGO;
        private static var mArminNightFinal_Filter:Class = gGfxResource_mArminNightFinal_Filter;
        public static const FILTER_TYPE_COLORMODZOOM:int = 6;
        private static var mColorMod_Filter:Class = gGfxResource_mColorMod_Filter;
        public static var mColorMod_ShaderFilter:ShaderFilter;
        public static var gLoadingScreenGfx:Class = gGfxResource_gLoadingScreenGfx;
        public static var mHealthBarIcons:cGuiIcon;
        private static var mArminSnow_Filter:Class = gGfxResource_mArminSnow_Filter;
        private static var mCopyWithAlpha_Filter:Class = gGfxResource_mCopyWithAlpha_Filter;
        public static var mArminSnowNoWater_Shader:Shader;
        private static var mArminOven_Filter:Class = gGfxResource_mArminOven_Filter;
        public static var mAntialiasingZoom_Shader:Shader;
        private static var mArminSnowLight_Filter:Class = gGfxResource_mArminSnowLight_Filter;
        public static var mPreBuild:cBuilding;
        public static var mZoom_Shader:Shader;
        public static var mUpgradeLevelIcons:cGuiIcon;
        private static var mDispatcherLoad:cCustomDispatcher = new cCustomDispatcher();
        public static var mCurrent_Shader:Shader;
        public static var mArminSnow_ShaderFilter:ShaderFilter;
        public static var mArminOven_ShaderFilter:ShaderFilter;
        public static var mArminNightFinal_Shader:Shader;
        public static var mWaterTile:cBackground;
        public static var mArminSnowLight_ShaderFilter:ShaderFilter;
        public static var mColorMod_Shader:Shader;
        public static const FILTER_TYPE_OVENZOOM:int = 5;
        public static const FILTER_TYPE_SNOWLIGHTZOOM:int = 3;
        public static var mArminNightFinal_ShaderFilter:ShaderFilter;
        public static var mArminSnow_Shader:Shader;
        private static var mCopyWithAlpha_Shader:Shader;
        public static var gUseFilterType:int = 0;
        private static var mPercentLoadingScreen:int;
        public static var mArminOven_Shader:Shader;
        public static var mArminSnowLight_Shader:Shader;
        public static const FILTER_TYPE_MAX:int = 7;
        public static const FILTER_TYPE_SNOWNOWATERZOOM:int = 4;
        public static const FILTER_TYPE_NIGHTZOOM:int = 1;
        public static const FILTER_TYPE_ZOOM:int = 0;
        public static const FILTER_TYPE_SNOWZOOM:int = 2;
        public static var mCopyWithAlpha_ShaderFilter:ShaderFilter;
        private static var mArminSnowNoWater_Filter:Class = gGfxResource_mArminSnowNoWater_Filter;
        public static var mBuildingQueuedIcon:cGO;
        private static var mCompleteFunction:Function;
        private static var mFilterSource:int;
        public static var mActivateStreaming:Boolean;
        public static var gLoadingScreenGfxGraphics:cEmbeddedGraphicsResource = new cEmbeddedGraphicsResource(new gLoadingScreenGfx());
        public static var mUpgradeLevelNumbers:cGuiIcon;
        public static var mBuildingRepairIcon:cGuiIcon;
        public static var mAntialiasingZoom_ShaderFilter:ShaderFilter;
        public static var mBuildingInfoIcons:cGuiIcon;
        private static var mAntialiasingZoom_Filter:Class = gGfxResource_mAntialiasingZoom_Filter;
        private static var mZoom_Filter:Class = gGfxResource_mZoom_Filter;
        public static var mZoom_ShaderFilter:ShaderFilter;
        public static var mCurrent_ShaderFilter:ShaderFilter;
        private static var mCurrentColorSchema:String = null;
        public static var mArminSnowNoWater_ShaderFilter:ShaderFilter;
        public static var mStreamReplacementSpriteContainer:cGOSpriteLibContainer;

        public function gGfxResource()
        {
            return;
        }// end function

        public static function InitializeGlobalGfx() : void
        {
            mWaitForCommandIcon = cGuiIcon.CreateFromString("WaitForCommand", null);
            mWaitForCommandIcon.mSprite.SetAnim(mWaitForCommandIcon.GetGOContainer().mEffectDefaultAnimSpeed, true);
            mBuildingQueuedIcon = cGuiIcon.CreateFromString("BuildingQueued", null);
            mPreBuild = cBuilding.CreateFromString(null, global.buildingGroup, "prebuild", null);
            mBuildingInfoIcons = cGuiIcon.CreateFromString("BuildingInfoIcons", null);
            mUpgradeLevelIcons = cGuiIcon.CreateFromString("UpgradeLevelIcons", null);
            mUpgradeLevelNumbers = cGuiIcon.CreateFromString("UpgradeLevelNumbers", null);
            mHealthBarIcons = cGuiIcon.CreateFromString("HealthbarIcons", null);
            mHealthBarIcons.SetSubType(0);
            mBuildingRepairIcon = cGuiIcon.CreateFromString("RepairBuilding", null);
            mBuildingRepairIcon.SetSubType(0);
            mWaterTile = cBackground.CreateFromString("P13", null);
            mDispatcherLoad.doAction();
            return;
        }// end function

        public static function ReplacementGfxLoaded(param1:cEventWithData) : void
        {
            mDispatcherLoad.addEventListener(cCustomDispatcher.mAction_string, mCompleteFunction);
            global.guiIconGroup.CreateContainer("guiicon_lib/", InitCompleteHandlerguiIconGroup, null, false, mActivateStreaming);
            return;
        }// end function

        private static function InitCompleteHandlerFinished(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.animalGroup.IsSpriteListLoaded())
            {
                InitializeGlobalGfx();
            }
            return;
        }// end function

        private static function InitCompleteHandlerstreetGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.streetGroup.IsSpriteListLoaded())
            {
                global.buildingGroup.CreateContainer("building_lib/", InitCompleteHandlerbuildingGroup, null, true, mActivateStreaming);
            }
            return;
        }// end function

        private static function InitCompleteHandlersettlerGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.settlerGroup.IsSpriteListLoaded())
            {
                global.effectGroup.CreateContainer("effect_lib/", InitCompleteHandlereffectGroup, null, false, mActivateStreaming);
            }
            return;
        }// end function

        public static function ApplyZoom(param1:Number) : void
        {
            if (!defines.FILTER_ACTIVATED)
            {
                return;
            }
            mCurrent_Shader.data.dimension.value = [param1];
            return;
        }// end function

        private static function InitCompleteHandlericons(event:Event) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (gAssetManager.IsLoaded())
            {
                cLocaManager.GetInstance().Init(InitCompleteHandlerlocalization);
            }
            return;
        }// end function

        private static function InitCompleteHandlerlandscapeGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.landscapeGroup.IsSpriteListLoaded())
            {
                global.settlerGroup.CreateContainer("settler_lib/", InitCompleteHandlersettlerGroup, null, true, mActivateStreaming);
            }
            return;
        }// end function

        private static function InitCompleteHandlerbackgroundGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.backgroundGroup.IsSpriteListLoaded())
            {
                global.streetGroup.CreateContainer("street_lib/", InitCompleteHandlerstreetGroup, null, false, mActivateStreaming);
            }
            return;
        }// end function

        private static function InitCompleteHandlerbuildingGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.buildingGroup.IsSpriteListLoaded())
            {
                global.landscapeGroup.CreateContainer("landscape_lib/", InitCompleteHandlerlandscapeGroup, null, true, mActivateStreaming);
            }
            return;
        }// end function

        private static function InitCompleteHandlereffectGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.effectGroup.IsSpriteListLoaded())
            {
                cGOSetManager.LoadGOSetData();
                gAssetManager.LoadIcons("icons/", InitCompleteHandlericons);
            }
            return;
        }// end function

        public static function GetGfxFolder_string() : String
        {
            return defines.STATIC_FILES_URL_LIST[0] + "/GFX/";
        }// end function

        public static function SetFilter(param1:String, param2:int) : Boolean
        {
            var _loc_4:String = null;
            var _loc_5:Array = null;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:Number = NaN;
            var _loc_10:Number = NaN;
            var _loc_11:Number = NaN;
            if (!defines.FILTER_ACTIVATED)
            {
                return true;
            }
            if (param1 == mCurrentColorSchema)
            {
                return false;
            }
            if (param2 != FILTER_SOURCE.REFRESH_ZONE && mCurrentColorSchema != null && param2 != mFilterSource)
            {
                return false;
            }
            mFilterSource = param2;
            mCurrentColorSchema = param1;
            var _loc_3:* = gGfxResource.FILTER_TYPE_MAX;
            if (param1 == "night")
            {
                _loc_3 = gGfxResource.FILTER_TYPE_NIGHTZOOM;
            }
            else if (param1 == "snow")
            {
                _loc_3 = gGfxResource.FILTER_TYPE_SNOWZOOM;
            }
            else if (param1 == "snowlight")
            {
                _loc_3 = gGfxResource.FILTER_TYPE_SNOWLIGHTZOOM;
            }
            else if (param1 == "snownowater")
            {
                _loc_3 = gGfxResource.FILTER_TYPE_SNOWNOWATERZOOM;
            }
            else if (param1 == "oven")
            {
                _loc_3 = gGfxResource.FILTER_TYPE_OVENZOOM;
            }
            else if (param1 != null && param1.indexOf("colormod") != -1)
            {
                _loc_3 = gGfxResource.FILTER_TYPE_COLORMODZOOM;
            }
            if (_loc_3 != gGfxResource.FILTER_TYPE_MAX)
            {
                gGfxResource.gUseFilterType = _loc_3;
                gGfxResource.ActivateShader();
                if (_loc_3 == gGfxResource.FILTER_TYPE_COLORMODZOOM)
                {
                    _loc_4 = param1.substr(8);
                    _loc_5 = _loc_4.split(",");
                    _loc_6 = gMisc.ParseFloat(_loc_5[1]);
                    _loc_7 = gMisc.ParseFloat(_loc_5[2]);
                    _loc_8 = gMisc.ParseFloat(_loc_5[3]);
                    _loc_9 = gMisc.ParseFloat(_loc_5[4]);
                    _loc_10 = gMisc.ParseFloat(_loc_5[5]);
                    _loc_11 = gMisc.ParseFloat(_loc_5[6]);
                    mCurrent_Shader.data.AddRed.value = [_loc_6];
                    mCurrent_Shader.data.AddGreen.value = [_loc_7];
                    mCurrent_Shader.data.AddBlue.value = [_loc_8];
                    mCurrent_Shader.data.MulRed.value = [_loc_9];
                    mCurrent_Shader.data.MulGreen.value = [_loc_10];
                    mCurrent_Shader.data.MulBlue.value = [_loc_11];
                }
                cSpriteLibContainer.mApplyFilter = true;
            }
            else
            {
                cSpriteLibContainer.mApplyFilter = false;
            }
            return true;
        }// end function

        private static function InitCompleteHandlerguiIconGroup(param1:cEventWithData) : void
        {
            IncreasePercentFromLoadingScreen(2);
            if (global.guiIconGroup.IsSpriteListLoaded())
            {
                global.backgroundGroup.CreateContainer("background_lib/", InitCompleteHandlerbackgroundGroup, null, false, mActivateStreaming);
            }
            return;
        }// end function

        private static function InitCompleteHandlerlocalization(event:Event) : void
        {
            IncreasePercentFromLoadingScreen(2);
            global.animalGroup.CreateContainer("animal_lib/", InitCompleteHandlerFinished, null, true, mActivateStreaming);
            return;
        }// end function

        public static function LoadAll(param1:Function, param2:int) : void
        {
            mPercentLoadingScreen = param2 * 10;
            mCompleteFunction = param1;
            InitPreLoadFilter();
            mActivateStreaming = defines.ACTIVATE_STREAMING;
            if (global.GAME_STATE == "Editor" || global.GAME_STATE == "MainMenu")
            {
                mActivateStreaming = false;
            }
            mStreamReplacementSpriteContainer = new cGOSpriteLibContainer(null, gGfxResource.GetGfxFolder_string() + "guiicon_lib/empty.png", ReplacementGfxLoaded, 1000, false, false, 0);
            return;
        }// end function

        public static function InitPreLoadFilter() : void
        {
            mAntialiasingZoom_Shader = new Shader(new mAntialiasingZoom_Filter() as ByteArray);
            mAntialiasingZoom_ShaderFilter = new ShaderFilter(mAntialiasingZoom_Shader);
            if (!defines.FILTER_ACTIVATED)
            {
                return;
            }
            mCopyWithAlpha_Shader = new Shader(new mCopyWithAlpha_Filter() as ByteArray);
            mCopyWithAlpha_ShaderFilter = new ShaderFilter(mCopyWithAlpha_Shader);
            mArminNightFinal_Shader = new Shader(new mArminNightFinal_Filter() as ByteArray);
            mArminNightFinal_ShaderFilter = new ShaderFilter(mArminNightFinal_Shader);
            mArminSnow_Shader = new Shader(new mArminSnow_Filter() as ByteArray);
            mArminSnow_ShaderFilter = new ShaderFilter(mArminSnow_Shader);
            mArminSnowLight_Shader = new Shader(new mArminSnowLight_Filter() as ByteArray);
            mArminSnowLight_ShaderFilter = new ShaderFilter(mArminSnowLight_Shader);
            mArminSnowNoWater_Shader = new Shader(new mArminSnowNoWater_Filter() as ByteArray);
            mArminSnowNoWater_ShaderFilter = new ShaderFilter(mArminSnowNoWater_Shader);
            mArminOven_Shader = new Shader(new mArminOven_Filter() as ByteArray);
            mArminOven_ShaderFilter = new ShaderFilter(mArminOven_Shader);
            mColorMod_Shader = new Shader(new mColorMod_Filter() as ByteArray);
            mColorMod_ShaderFilter = new ShaderFilter(mColorMod_Shader);
            mZoom_Shader = new Shader(new mZoom_Filter() as ByteArray);
            mZoom_ShaderFilter = new ShaderFilter(mZoom_Shader);
            ActivateShader();
            return;
        }// end function

        public static function ActivateShader() : void
        {
            if (!defines.FILTER_ACTIVATED)
            {
                return;
            }
            switch(gUseFilterType)
            {
                case FILTER_TYPE_ZOOM:
                {
                    mCurrent_Shader = mZoom_Shader;
                    mCurrent_ShaderFilter = mZoom_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_NIGHTZOOM:
                {
                    mCurrent_Shader = mArminNightFinal_Shader;
                    mCurrent_ShaderFilter = mArminNightFinal_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_SNOWZOOM:
                {
                    mCurrent_Shader = mArminSnow_Shader;
                    mCurrent_ShaderFilter = mArminSnow_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_SNOWLIGHTZOOM:
                {
                    mCurrent_Shader = mArminSnowLight_Shader;
                    mCurrent_ShaderFilter = mArminSnowLight_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_SNOWNOWATERZOOM:
                {
                    mCurrent_Shader = mArminSnowNoWater_Shader;
                    mCurrent_ShaderFilter = mArminSnowNoWater_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_OVENZOOM:
                {
                    mCurrent_Shader = mArminOven_Shader;
                    mCurrent_ShaderFilter = mArminOven_ShaderFilter;
                    break;
                }
                case FILTER_TYPE_COLORMODZOOM:
                {
                    mCurrent_Shader = mColorMod_Shader;
                    mCurrent_ShaderFilter = mColorMod_ShaderFilter;
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private static function IncreasePercentFromLoadingScreen(param1:int) : void
        {
            mPercentLoadingScreen = mPercentLoadingScreen + param1;
            gInitStaticForAllZones.ShowLoadingScreen(mPercentLoadingScreen / 10);
            return;
        }// end function

    }
}
