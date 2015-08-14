package Enums
{
    import nLib.*;

    public class BUFF_TARGET_ZONE extends Object
    {
        public static const ADVENTURE:int = 4;
        public static const FRIEND:int = 2;
        public static const HOME:int = 1;

        public function BUFF_TARGET_ZONE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            var _loc_2:String = "";
            if ((param1 & HOME) > 0)
            {
                _loc_2 = _loc_2 + "Home";
            }
            if ((param1 & FRIEND) > 0)
            {
                _loc_2 = _loc_2 + ((_loc_2.length > 0 ? (",") : ("")) + "Friend");
            }
            if ((param1 & ADVENTURE) > 0)
            {
                _loc_2 = _loc_2 + ((_loc_2.length > 0 ? (",") : ("")) + "Adventure");
            }
            return _loc_2;
        }// end function

        public static function parse(param1:String) : int
        {
            var _loc_4:String = null;
            if (param1.length == 0)
            {
                return 0;
            }
            var _loc_2:int = 0;
            var _loc_3:* = param1.split(",");
            for each (_loc_4 in _loc_3)
            {
                
                if (_loc_4 == "Home")
                {
                    _loc_2 = _loc_2 | HOME;
                    continue;
                }
                if (_loc_4 == "Friend")
                {
                    _loc_2 = _loc_2 | FRIEND;
                    continue;
                }
                if (_loc_4 == "Adventure")
                {
                    _loc_2 = _loc_2 | ADVENTURE;
                    continue;
                }
                gMisc.Assert(false, "Could not interpret target zone string \'" + _loc_4 + "\'!");
            }
            return _loc_2;
        }// end function

    }
}
