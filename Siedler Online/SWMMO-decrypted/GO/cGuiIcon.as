package GO
{
    import Enums.*;
    import Interface.*;

    public class cGuiIcon extends cGO
    {

        public function cGuiIcon(param1:cGeneralInterface)
        {
            super(param1);
            return;
        }// end function

        public static function CreateFromString(param1:String, param2:cGeneralInterface) : cGuiIcon
        {
            var _loc_3:* = global.guiIconGroup.GetNrFromName(param1);
            var _loc_4:* = new cGuiIcon(param2);
            new cGuiIcon(param2).InitFromNr(global.guiIconGroup, _loc_3);
            _loc_4.SetLevelEnumObjectType(OBJECTTYPE.GUIICON);
            return _loc_4;
        }// end function

    }
}
