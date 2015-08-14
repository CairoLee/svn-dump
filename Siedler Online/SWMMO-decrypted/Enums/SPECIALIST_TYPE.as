package Enums
{
    import __AS3__.vec.*;
    import nLib.*;

    public class SPECIALIST_TYPE extends Object
    {
        public static const MAX:int = 10;
        public static const EXPLORER:int = 1;
        private static var mSpecialistType_vector:Vector.<String> = new Vector.<String>;
        private static var mSpecialistTypeDictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const GENERAL:int = 0;
        public static const MASTER_GEOLOGIST:int = 5;
        public static const TMP_ARMY_TRANSPORTER:int = 6;
        public static const MASTER_GENERAL:int = 3;
        public static const EASTER_GENERAL:int = 9;
        public static const HALLOWEEN_GENERAL:int = 7;
        public static const GEOLOGIST:int = 2;
        public static const RETAIL_BOX_GENERAL:int = 8;
        public static const EASTER_EXPLORER:int = 10;
        public static const MASTER_EXPLORER:int = 4;

        public function SPECIALIST_TYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            if (param1 >= 0 && param1 < mSpecialistType_vector.length)
            {
                return mSpecialistType_vector[param1];
            }
            return "<unknown Type " + param1 + ">";
        }// end function

        public static function parse(param1:String) : int
        {
            var _loc_2:* = mSpecialistTypeDictionary.Get(param1);
            gMisc.Assert(_loc_2 != defines.ILLEGAL_INT_POS, "Could not interpret \'" + param1 + "\' for a specialist string!");
            return _loc_2;
        }// end function

        private static function AddToSpecialistTypeDictionary(param1:String) : void
        {
            mSpecialistTypeDictionary.Put(param1, mSpecialistType_vector.length);
            mSpecialistType_vector.push(param1);
            return;
        }// end function

        AddToSpecialistTypeDictionary("General");
        AddToSpecialistTypeDictionary("Explorer");
        AddToSpecialistTypeDictionary("Geologist");
        AddToSpecialistTypeDictionary("MasterGeneral");
        AddToSpecialistTypeDictionary("MasterExplorer");
        AddToSpecialistTypeDictionary("MasterGeologist");
        AddToSpecialistTypeDictionary("TmpArmyTransporter");
        AddToSpecialistTypeDictionary("HalloweenGeneral");
        AddToSpecialistTypeDictionary("RetailBoxGeneral");
        AddToSpecialistTypeDictionary("EasterGeneral");
        AddToSpecialistTypeDictionary("EasterExplorer");
    }
}
