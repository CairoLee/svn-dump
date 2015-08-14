package GO
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import ServerState.*;

    public class cStreet extends cGO
    {
        private var mGridPos:int = 0;
        private var mVariationNr:int = 0;
        private var mLastVariationNr:int = -1;
        private var mStreetCityLevel:int = 0;
        public var mDirtyIndicator:int;
        private var mLoadingFinished:Boolean = false;
        private var mLastStreetCityLevel:int = -1;
        private var mStreetBits:int = 0;

        public function cStreet(param1:cGeneralInterface)
        {
            super(param1);
            return;
        }// end function

        public function GetStreetCityLevel() : int
        {
            return this.mStreetCityLevel;
        }// end function

        public function SetStreetBits(param1:int) : void
        {
            this.mStreetBits = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetGridPos(param1:int) : void
        {
            this.mGridPos = param1;
            return;
        }// end function

        public function SetVariationNr(param1:int) : void
        {
            this.mVariationNr = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            if (this.mLoadingFinished)
            {
                this.RefreshAnimFrame();
            }
            return;
        }// end function

        public function RenderMilitryPathPreview() : void
        {
            mGeneralInterface.mMilitaryPath.mSprite.RenderPosNoScaling(int(mXScaled), int(mYScaled));
            return;
        }// end function

        public function GetGridPos() : int
        {
            return this.mGridPos;
        }// end function

        override public function IsCursorPlacable(param1:int, param2:int, param3:int) : int
        {
            return CURSOR_PLACABLE.STREET_PLACE;
        }// end function

        public function GetVariationNr() : int
        {
            return this.mVariationNr;
        }// end function

        public function CreateStreetVOFromStreet() : dStreetVO
        {
            var _loc_1:* = new dStreetVO();
            _loc_1.grid = this.GetGridPos();
            _loc_1.streetBits = this.GetStreetBits();
            _loc_1.streetCityLevel = this.GetStreetCityLevel();
            _loc_1.streetVariation = this.GetVariationNr();
            return _loc_1;
        }// end function

        public function RefreshSubType() : void
        {
            var _loc_1:* = this.mStreetCityLevel;
            var _loc_2:* = GetNofSubTypes();
            if (_loc_1 >= _loc_2)
            {
                _loc_1 = _loc_2 - 1;
            }
            SetSubType(_loc_1);
            return;
        }// end function

        public function SetStreetCityLevel(param1:int) : void
        {
            this.mStreetCityLevel = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            if (this.mLoadingFinished)
            {
                this.RefreshSubType();
                this.RefreshAnimFrame();
            }
            return;
        }// end function

        public function Init(param1:int, param2:int, param3:int) : cStreet
        {
            this.mStreetCityLevel = param1;
            this.mVariationNr = param2;
            this.mGridPos = param3;
            return this;
        }// end function

        public function RefreshAnimFrame() : void
        {
            var _loc_1:* = GetNofAnimFrames();
            var _loc_2:* = this.mVariationNr % _loc_1;
            SetAnimFrame(_loc_2);
            return;
        }// end function

        override public function Render() : void
        {
            if (!GetGOContainer().mStream)
            {
                if (!this.mLoadingFinished)
                {
                    this.mLoadingFinished = true;
                    this.RefreshSubType();
                    this.RefreshAnimFrame();
                }
            }
            super.Render();
            return;
        }// end function

        public function GetStreetBits() : int
        {
            return this.mStreetBits;
        }// end function

        public static function CreateStringFromStreetBitField_string(param1:int) : String
        {
            var _loc_2:String = "";
            if ((param1 & 1) == 1)
            {
                _loc_2 = _loc_2 + "0";
            }
            if ((param1 & 2) == 2)
            {
                _loc_2 = _loc_2 + "1";
            }
            if ((param1 & 4) == 4)
            {
                _loc_2 = _loc_2 + "2";
            }
            if ((param1 & 8) == 8)
            {
                _loc_2 = _loc_2 + "3";
            }
            return _loc_2;
        }// end function

        public static function ConvertStreetNameToBitField(param1:String) : int
        {
            var _loc_4:String = null;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            while (_loc_3 < param1.length)
            {
                
                _loc_4 = param1.charAt(_loc_3) + "";
                if (_loc_4 == "0")
                {
                    _loc_2 = _loc_2 | 1;
                }
                else if (_loc_4 == "1")
                {
                    _loc_2 = _loc_2 | 2;
                }
                else if (_loc_4 == "2")
                {
                    _loc_2 = _loc_2 | 4;
                }
                else if (_loc_4 == "3")
                {
                    _loc_2 = _loc_2 | 8;
                }
                _loc_3++;
            }
            return _loc_2;
        }// end function

        public static function CreateFromString(param1:cPlayerData, param2:cGOGroup, param3:String, param4:cGeneralInterface) : cStreet
        {
            var _loc_5:* = param2.GetNrFromName(param3);
            var _loc_6:* = new cStreet(param4);
            new cStreet(param4).InitFromNr(param2, _loc_5);
            _loc_6.mStreetBits = cStreet.ConvertStreetNameToBitField(_loc_6.GetContainerName_string());
            _loc_6.SetLevelEnumObjectType(OBJECTTYPE.STREET);
            if (param4 != null)
            {
                _loc_6.mPlayerID = param1.GetPlayerId();
            }
            else
            {
                _loc_6.mPlayerID = -1;
            }
            return _loc_6;
        }// end function

    }
}
