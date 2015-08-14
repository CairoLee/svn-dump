package mx.effects.easing
{

    public class Linear extends Object
    {
        static const VERSION:String = "3.5.0.12683";

        public function Linear()
        {
            return;
        }// end function

        public static function easeOut(param1:Number, param2:Number, param3:Number, param4:Number) : Number
        {
            return param3 * param1 / param4 + param2;
        }// end function

        public static function easeIn(param1:Number, param2:Number, param3:Number, param4:Number) : Number
        {
            return param3 * param1 / param4 + param2;
        }// end function

        public static function easeNone(param1:Number, param2:Number, param3:Number, param4:Number) : Number
        {
            return param3 * param1 / param4 + param2;
        }// end function

        public static function easeInOut(param1:Number, param2:Number, param3:Number, param4:Number) : Number
        {
            return param3 * param1 / param4 + param2;
        }// end function

    }
}
