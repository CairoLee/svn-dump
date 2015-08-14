package nLib
{
    import flash.utils.*;

    public class gBinaryStream extends Object
    {
        private static var p:ByteArray;
        public static var a:int;
        private static var initP:ByteArray;

        public function gBinaryStream()
        {
            return;
        }// end function

        public static function InitBinaryStream(param1:ByteArray, param2:int = 0) : void
        {
            p = param1;
            a = param2;
            return;
        }// end function

        public static function ReadShort() : int
        {
            var _loc_1:* = p[a] + 256 * p[(a + 1)];
            a = a + 2;
            return _loc_1;
        }// end function

        public static function ReadInt() : int
        {
            var _loc_1:* = ReadShort() + 65536 * ReadShort();
            return _loc_1;
        }// end function

        public static function ReadCStringAtPos_string(param1:int) : String
        {
            var _loc_2:String = "";
            var _loc_3:int = 0;
            while (true)
            {
                
                if (p[param1 + _loc_3] == 0)
                {
                    break;
                }
                _loc_2 = _loc_2 + String.fromCharCode(p[param1 + _loc_3]);
                _loc_3++;
            }
            return _loc_2;
        }// end function

    }
}
