package Enums
{

    public class LOG_LEVEL extends Object
    {
        public static const ALL:int = 7;
        public static const FATAL:int = 6;
        public static const TRACE:int = 1;
        public static const ERROR:int = 5;
        public static const WARN:int = 4;
        public static const INFO:int = 3;
        public static const OFF:int = 0;
        public static const DEBUG:int = 2;
        public static const INVALID:int = -1;

        public function LOG_LEVEL()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case INVALID:
                {
                    return "LOG_LEVEL.INVALID";
                }
                case OFF:
                {
                    return "LOG_LEVEL.OFF";
                }
                case TRACE:
                {
                    return "LOG_LEVEL.TRACE";
                }
                case DEBUG:
                {
                    return "LOG_LEVEL.DEBUG";
                }
                case INFO:
                {
                    return "LOG_LEVEL.INFO";
                }
                case WARN:
                {
                    return "LOG_LEVEL.WARN";
                }
                case ERROR:
                {
                    return "LOG_LEVEL.ERROR";
                }
                case FATAL:
                {
                    return "LOG_LEVEL.FATAL";
                }
                case ALL:
                {
                    return "LOG_LEVEL.ALL";
                }
                default:
                {
                    break;
                }
            }
            return "LOG_LEVEL.UNDEFINED(" + param1 + ")";
        }// end function

    }
}
