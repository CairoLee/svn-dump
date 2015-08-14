package mx.logging
{
    import flash.events.*;

    public class LogEvent extends Event
    {
        public var level:int;
        public var message:String;
        static const VERSION:String = "3.5.0.12683";
        public static const LOG:String = "log";

        public function LogEvent(param1:String = "", param2:int = 0)
        {
            super(LogEvent.LOG, false, false);
            this.message = param1;
            this.level = param2;
            return;
        }// end function

        override public function clone() : Event
        {
            return new LogEvent(message, level);
        }// end function

        public static function getLevelString(param1:uint) : String
        {
            switch(param1)
            {
                case LogEventLevel.INFO:
                {
                    return "INFO";
                }
                case LogEventLevel.DEBUG:
                {
                    return "DEBUG";
                }
                case LogEventLevel.ERROR:
                {
                    return "ERROR";
                }
                case LogEventLevel.WARN:
                {
                    return "WARN";
                }
                case LogEventLevel.FATAL:
                {
                    return "FATAL";
                }
                case LogEventLevel.ALL:
                {
                    return "ALL";
                }
                default:
                {
                    break;
                }
            }
            return "UNKNOWN";
        }// end function

    }
}
