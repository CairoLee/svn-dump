package GO
{
    import Enums.*;
    import Interface.*;

    public class cBackground extends cGO
    {

        public function cBackground(param1:cGeneralInterface)
        {
            super(param1);
            return;
        }// end function

        public static function CreateFromString(param1:String, param2:cGeneralInterface) : cBackground
        {
            var _loc_3:* = global.backgroundGroup.GetNrFromName(param1);
            var _loc_4:* = new cBackground(param2);
            new cBackground(param2).InitFromNr(global.backgroundGroup, _loc_3);
            _loc_4.SetLevelEnumObjectType(OBJECTTYPE.BACKGROUND);
            return _loc_4;
        }// end function

    }
}
