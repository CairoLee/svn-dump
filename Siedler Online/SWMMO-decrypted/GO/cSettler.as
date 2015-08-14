package GO
{
    import Enums.*;
    import Interface.*;
    import SettlerKI.*;
    import nLib.*;

    public class cSettler extends cGO
    {
        public var mEnumSettlerKIType:int;
        public var mSettlerKi:cSettlerKI = null;

        public function cSettler(param1:cGeneralInterface)
        {
            this.mEnumSettlerKIType = SETTLER_KI_TYP.UNSET;
            super(param1);
            return;
        }// end function

        override public function PostInit() : void
        {
            var _loc_1:* = mSprite.GetContainer() as cGOSpriteLibContainer;
            SetAnim(_loc_1.mEffectDefaultAnimSpeed, true);
            this.SetKI(_loc_1.mEnumSettlerKiTyp);
            return;
        }// end function

        public function SetSpriteImage(param1:String) : void
        {
            var _loc_2:* = global.settlerGroup.GetNrFromName(param1);
            var _loc_3:* = global.settlerGroup.GetSpriteLibFromNr(global.settlerGroup.mGOList_vector, _loc_2);
            InitWithSpriteLib(_loc_3);
            var _loc_4:* = _loc_3.GetContainer() as cGOSpriteLibContainer;
            SetAnim(_loc_4.mEffectDefaultAnimSpeed, true);
            SetRandomFrame();
            return;
        }// end function

        override public function Render() : void
        {
            if (this.mSettlerKi.mVisible)
            {
                super.Render();
            }
            return;
        }// end function

        override public function Compute() : void
        {
            this.mSettlerKi.Compute();
            return;
        }// end function

        public function SetKI(param1:int) : void
        {
            this.mEnumSettlerKIType = param1;
            if (param1 == SETTLER_KI_TYP.WALK_RANDOM)
            {
                this.mSettlerKi = new cSettlerKIWalkRandom(this);
                return;
            }
            if (param1 == SETTLER_KI_TYP.WALK_FROM_FIELD_TO_FIELD)
            {
                this.mSettlerKi = new cSettlerKIWalkFromFieldtoField(this);
                return;
            }
            if (param1 == SETTLER_KI_TYP.WALK_ON_STREETS)
            {
                this.mSettlerKi = new cSettlerKIWalkOnStreets(this);
                return;
            }
            if (param1 == SETTLER_KI_TYP.WALK_TO_DESTINATION)
            {
                this.mSettlerKi = new cSettlerKIWalkToDestination(this);
                return;
            }
            if (param1 == SETTLER_KI_TYP.PERFORM_GENERAL_TASK)
            {
                this.mSettlerKi = new cSettlerAI_WalkToTarget(this);
                return;
            }
            this.mSettlerKi = new cSettlerKIDoNothing(this);
            return;
        }// end function

        public static function CreateFromNr(param1:cGOGroup, param2:int, param3:cGeneralInterface) : cSettler
        {
            var _loc_4:* = new cSettler(param3);
            new cSettler(param3).InitFromNrNoUniqueID(param1, param2);
            return _loc_4;
        }// end function

        public static function CreateFromString(param1:cGOGroup, param2:String, param3:int, param4:cGeneralInterface) : cSettler
        {
            var _loc_5:* = param1.GetNrFromName(param2);
            var _loc_6:* = CreateFromNr(param1, _loc_5, param4);
            CreateFromNr(param1, _loc_5, param4).SetPosition(0, 0);
            var _loc_7:* = _loc_6.GetNofAnimFrames();
            var _loc_8:* = int(gMisc.GetRandomMinMax(0, (_loc_7 - 1)));
            _loc_6.SetAnimFrame(_loc_8);
            _loc_6.SetLevelEnumObjectType(param3);
            return _loc_6;
        }// end function

        public static function GetRandomSettlerName_string() : String
        {
            return "";
        }// end function

    }
}
