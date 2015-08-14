package GO
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import nLib.*;

    public class cLandscape extends cGO
    {
        public var mDirtyIndicator:int;
        private var mSpriteWorkAnim:cSpriteLib = null;
        private var mLandscapeName_string:String = null;
        private var mGrid:int;

        public function cLandscape(param1:cGeneralInterface)
        {
            super(param1);
            return;
        }// end function

        public function GetLandscapeName_string() : String
        {
            return this.mLandscapeName_string;
        }// end function

        public function SetName_string(param1:String) : void
        {
            this.mLandscapeName_string = param1;
            return;
        }// end function

        public function toString() : String
        {
            return "<Landscape name=\'" + this.mLandscapeName_string + "\' grid=\'" + this.mGrid + "\' />";
        }// end function

        public function SetGrid(param1:int) : void
        {
            this.mGrid = param1;
            return;
        }// end function

        public function SetWorkAnimation() : void
        {
            var _loc_1:cSpriteLibContainer = null;
            if (this.mSpriteWorkAnim != null)
            {
                _loc_1 = this.mSpriteWorkAnim.GetContainer() as cSpriteLibContainer;
                this.mSpriteWorkAnim.SetAnim(_loc_1.mAnimationSpeed, true);
            }
            return;
        }// end function

        public function CreateLandscapeVOFromLandscape() : dLandscapeVO
        {
            var _loc_1:* = new dLandscapeVO();
            _loc_1.playerID = GetPlayerID();
            _loc_1.name_string = this.GetLandscapeName_string();
            _loc_1.grid = this.GetGrid();
            return _loc_1;
        }// end function

        public function GetGrid() : int
        {
            return this.mGrid;
        }// end function

        public static function CreateFromString(param1:cGOGroup, param2:String, param3:int, param4:cGeneralInterface) : cLandscape
        {
            var _loc_5:* = param1.GetNrFromName(param2);
            var _loc_6:* = new cLandscape(param4);
            new cLandscape(param4).InitFromNr(param1, _loc_5);
            _loc_6.mSpriteWorkAnim = param1.GetSpriteLibFromNr(param1.mGOWorkAnimList_vector, _loc_5);
            if (_loc_6.mSpriteWorkAnim != null)
            {
                _loc_6.SetWorkAnimation();
            }
            _loc_6.SetLevelEnumObjectType(OBJECTTYPE.LANDSCAPE);
            return _loc_6;
        }// end function

    }
}
