package GO
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import nLib.*;

    public class cFreeLandscape extends cGO
    {
        private var mGoGroup:cGOGroup;
        private var mLandscapeName_string:String = null;
        public var mIsAnimated:Boolean = false;
        public var mAnimationInitialized:Boolean = false;

        public function cFreeLandscape(param1:cGeneralInterface)
        {
            super(param1);
            return;
        }// end function

        public function GetLandscapeName_string() : String
        {
            return this.mLandscapeName_string;
        }// end function

        public function SetAnimation() : void
        {
            var _loc_2:cSpriteLibContainer = null;
            var _loc_1:* = GetNofAnimFrames();
            if (_loc_1 > 1)
            {
                this.mIsAnimated = true;
                _loc_2 = mSprite.GetContainer() as cSpriteLibContainer;
                mSprite.SetAnim(_loc_2.mAnimationSpeed, true);
                mSprite.SetRandomAnimFrame();
            }
            else
            {
                this.mIsAnimated = false;
            }
            this.mAnimationInitialized = true;
            return;
        }// end function

        public function SetName_string(param1:String) : void
        {
            this.mLandscapeName_string = param1;
            return;
        }// end function

        public function SetGoGroup(param1:cGOGroup) : Boolean
        {
            this.mGoGroup = param1;
            return true;
        }// end function

        public function CreateVO() : dFreeLandscapeVO
        {
            var _loc_1:* = new dFreeLandscapeVO();
            _loc_1.name_string = this.GetLandscapeName_string();
            _loc_1.x = GetXInt();
            _loc_1.y = GetYInt();
            return _loc_1;
        }// end function

        public static function CreateFromString(param1:cGOGroup, param2:String, param3:cGeneralInterface) : cFreeLandscape
        {
            var _loc_4:* = param1.GetNrFromName(param2);
            var _loc_5:* = new cFreeLandscape(param3);
            new cFreeLandscape(param3).InitFromNr(param1, _loc_4);
            _loc_5.SetGoGroup(param1);
            _loc_5.SetLevelEnumObjectType(OBJECTTYPE.LANDSCAPE);
            return _loc_5;
        }// end function

    }
}
