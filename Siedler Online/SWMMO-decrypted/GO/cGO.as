package GO
{
    import Enums.*;
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import nLib.*;

    public class cGO extends Object
    {
        protected var mXScaled:Number = 0;
        protected var mYScaled:Number = 0;
        protected var mPlayerID:int = 0;
        protected var mXNotScaled:Number = 0;
        protected var mYNotScaled:Number = 0;
        public var mSprite:cSpriteLib = null;
        protected var mLevelEnumObjectType:int = 8;
        public var mGeneralInterface:cGeneralInterface;

        public function cGO(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function SetAnimFrame(param1:Number) : void
        {
            this.mSprite.SetAnimFrame(param1);
            return;
        }// end function

        public function RenderNoAlpha() : void
        {
            this.mSprite.RenderPosNoScalingNoAlpha(int(this.mXScaled), int(this.mYScaled));
            return;
        }// end function

        public function GetLevelEnumObjectType() : int
        {
            return this.mLevelEnumObjectType;
        }// end function

        public function InitFromNrNoUniqueID(param1:cGOGroup, param2:int) : void
        {
            this.InitWithSpriteLib(param1.GetSpriteLibFromNr(param1.mGOList_vector, param2));
            this.PostInit();
            return;
        }// end function

        public function Exit() : void
        {
            this.mSprite = null;
            return;
        }// end function

        public function RenderCursorTypeXY(param1:int, param2:int, param3:int) : void
        {
            if (param3 == CURSOR_RENDERMODE.PLACABLE)
            {
                this.RenderTransform(param1, param2, BlendMode.NORMAL, 1, 1, 0);
                this.RenderTransform(param1, param2, BlendMode.MULTIPLY, 1, 1, 0);
                this.RenderTransform(param1, param2, BlendMode.ADD, 1, 1, 0);
            }
            else
            {
                this.RenderTransform(param1, param2, BlendMode.MULTIPLY, 1, 1, 0);
                this.RenderTransform(param1, param2, BlendMode.MULTIPLY, 1, 1, 0);
            }
            return;
        }// end function

        public function SetRandomFrame() : void
        {
            var _loc_1:* = gMisc.GetRandomMinMax(0, (this.mSprite.GetNofFrames(-1) - 1));
            var _loc_2:* = int(_loc_1);
            this.SetAnimFrame(_loc_2);
            return;
        }// end function

        public function Animate() : void
        {
            this.mSprite.Animate(this.mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
            return;
        }// end function

        public function GetYInt() : int
        {
            return int(this.mYNotScaled);
        }// end function

        public function RenderTextAboveGo(param1:Graphics, param2:String, param3:int) : void
        {
            var _loc_4:* = new cPosInt();
            new cPosInt().x = int(this.mXNotScaled - 16);
            _loc_4.y = int(this.mYNotScaled + param3);
            this.mGeneralInterface.mZoom.CalculateScrollPos(_loc_4);
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, param2, _loc_4.x, _loc_4.y);
            return;
        }// end function

        public function RenderPos(param1:int, param2:int) : void
        {
            this.mSprite.RenderPos(param1, param2);
            return;
        }// end function

        public function Compute() : void
        {
            return;
        }// end function

        public function IsCursorPlacable(param1:int, param2:int, param3:int) : int
        {
            return CURSOR_PLACABLE.GO_PLACABLE;
        }// end function

        public function GetPlayerID() : int
        {
            return this.mPlayerID;
        }// end function

        public function GetContainerName_string() : String
        {
            var _loc_1:* = this.mSprite.GetContainer() as cGOSpriteLibContainer;
            return _loc_1.mGfxResourceListName_string;
        }// end function

        public function GetGOContainer() : cGOSpriteLibContainer
        {
            return this.mSprite.GetContainer() as cGOSpriteLibContainer;
        }// end function

        public function RenderTransform(param1:int, param2:int, param3:String, param4:Number, param5:Number, param6:Number) : void
        {
            this.mSprite.RenderSubTypeAndFrameTransform(param1, param2, this.mSprite.GetSubType(), 0, param3, param4, param5, param6);
            return;
        }// end function

        public function SetPlayerID(param1:int) : Boolean
        {
            this.mPlayerID = param1;
            return true;
        }// end function

        public function GetY() : Number
        {
            return this.mYNotScaled;
        }// end function

        public function InitFromNr(param1:cGOGroup, param2:int) : void
        {
            this.InitWithSpriteLib(param1.GetSpriteLibFromNr(param1.mGOList_vector, param2));
            this.PostInit();
            return;
        }// end function

        public function GetNofAnimFrames() : int
        {
            return this.mSprite.GetNofFrames(this.mSprite.GetSubType());
        }// end function

        public function GetNofSubTypes() : int
        {
            return this.mSprite.GetNofSubTypes();
        }// end function

        public function GetX() : Number
        {
            return this.mXNotScaled;
        }// end function

        public function InitWithSpriteLib(param1:cSpriteLib) : void
        {
            this.mSprite = param1;
            return;
        }// end function

        public function GetXInt() : int
        {
            return int(this.mXNotScaled);
        }// end function

        public function SetSubTypeAndFrame(param1:int, param2:int) : void
        {
            this.mSprite.SetSubTypeAndFrame(param1, param2);
            return;
        }// end function

        public function PostInit() : void
        {
            return;
        }// end function

        public function Render() : void
        {
            this.mSprite.RenderPosNoScaling(int(this.mXScaled), int(this.mYScaled));
            return;
        }// end function

        public function SetPosition(param1:Number, param2:Number) : void
        {
            this.mXNotScaled = param1;
            this.mYNotScaled = param2;
            this.mXScaled = param1 * this.mGeneralInterface.mZoom.mFactorDivDefaultZoom;
            this.mYScaled = param2 * this.mGeneralInterface.mZoom.mFactorDivDefaultZoom;
            return;
        }// end function

        public function SetAnim(param1:Number, param2:Boolean) : void
        {
            this.mSprite.SetAnim(param1, param2);
            return;
        }// end function

        public function SetLevelEnumObjectType(param1:int) : Boolean
        {
            this.mLevelEnumObjectType = param1;
            return true;
        }// end function

        public function SetSubType(param1:int) : void
        {
            this.mSprite.SetSubType(param1);
            return;
        }// end function

        public static function GetHitPoints(param1:int, param2:String) : int
        {
            var _loc_3:int = 0;
            if (param1 == OBJECTTYPE.BUILDING)
            {
                _loc_3 = global.buildingGroup.GetHitPoints(param2);
            }
            return _loc_3;
        }// end function

        public static function GetBlockingList(param1:int, param2:String)
        {
            var _loc_3:* = new Vector.<cBlockingData>;
            if (param1 == OBJECTTYPE.BUILDING)
            {
                _loc_3 = global.buildingGroup.GetBlockingListFromName(param2);
            }
            else if (param1 == OBJECTTYPE.LANDSCAPE)
            {
                _loc_3 = global.landscapeGroup.GetBlockingListFromName(param2);
            }
            else if (param1 == OBJECTTYPE.BACKGROUND)
            {
                _loc_3 = global.backgroundGroup.GetBlockingListFromName(param2);
            }
            return _loc_3;
        }// end function

        public static function GetWatchAreaId(param1:int, param2:String) : int
        {
            var _loc_3:int = 0;
            if (param1 == OBJECTTYPE.BUILDING)
            {
                _loc_3 = global.buildingGroup.GetWatchAreaId(param2);
            }
            return _loc_3;
        }// end function

        public static function CreateGoFromLevelObject(param1:cPlayerData, param2:int, param3:String, param4:cGeneralInterface) : cGO
        {
            var _loc_5:int = 0;
            var _loc_6:cBuilding = null;
            var _loc_7:cLandscape = null;
            var _loc_9:cBackground = null;
            var _loc_10:cStreet = null;
            var _loc_11:cGuiIcon = null;
            var _loc_12:cDeposit = null;
            var _loc_8:cGO = null;
            if (param2 == OBJECTTYPE.BACKGROUND)
            {
                _loc_9 = cBackground.CreateFromString(param3, param4);
                _loc_8 = _loc_9;
            }
            else if (param2 == OBJECTTYPE.STREET)
            {
                _loc_10 = cStreet.CreateFromString(param1, global.streetGroup, param3, param4);
                _loc_8 = _loc_10;
            }
            else if (param2 == OBJECTTYPE.LANDSCAPE)
            {
                _loc_7 = cLandscape.CreateFromString(global.landscapeGroup, param3, param2, param4);
                _loc_8 = _loc_7;
            }
            else if (param2 == OBJECTTYPE.BUILDING)
            {
                _loc_6 = cBuilding.CreateFromString(param1, global.buildingGroup, param3, param4);
                _loc_8 = _loc_6;
            }
            else if (param2 == OBJECTTYPE.GUIICON)
            {
                _loc_11 = cGuiIcon.CreateFromString(param3, param4);
                _loc_8 = _loc_11;
            }
            else if (param2 == OBJECTTYPE.DEPOSIT)
            {
                _loc_12 = cDeposit.CreateFromString(global.guiIconGroup, param3, param4);
                _loc_8 = _loc_12;
            }
            else
            {
                gMisc.Assert(false, "Error: CreateGoFromLevelObject illegal object type " + param2);
            }
            return _loc_8;
        }// end function

        public static function GetMaxUnits(param1:int, param2:String) : int
        {
            var _loc_3:int = 0;
            if (param1 == OBJECTTYPE.BUILDING)
            {
                _loc_3 = global.buildingGroup.GetMaxUnits(param2);
            }
            return _loc_3;
        }// end function

    }
}
