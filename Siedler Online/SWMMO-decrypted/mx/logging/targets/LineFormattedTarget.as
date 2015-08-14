package mx.logging.targets
{
    import mx.logging.*;

    public class LineFormattedTarget extends AbstractTarget
    {
        public var includeCategory:Boolean;
        public var fieldSeparator:String = " ";
        public var includeTime:Boolean;
        public var includeLevel:Boolean;
        public var includeDate:Boolean;
        static const VERSION:String = "3.5.0.12683";

        public function LineFormattedTarget()
        {
            includeTime = false;
            includeDate = false;
            includeCategory = false;
            includeLevel = false;
            return;
        }// end function

        private function padTime(param1:Number, param2:Boolean = false) : String
        {
            if (param2)
            {
            }
            if (param1 < 10)
            {
                return "00" + param1.toString();
            }
            if (param1 < 100)
            {
                return "0" + param1.toString();
            }
            return param1.toString();
        }// end function

        override public function logEvent(event:LogEvent) : void
        {
            var _loc_5:Date = null;
            var _loc_2:String = "";
            if (includeDate || includeTime)
            {
                _loc_5 = new Date();
                if (includeDate)
                {
                    _loc_2 = Number((_loc_5.getMonth() + 1)).toString() + "/" + _loc_5.getDate().toString() + "/" + _loc_5.getFullYear() + fieldSeparator;
                }
                if (includeTime)
                {
                    _loc_2 = _loc_2 + (padTime(_loc_5.getHours()) + ":" + padTime(_loc_5.getMinutes()) + ":" + padTime(_loc_5.getSeconds()) + "." + padTime(_loc_5.getMilliseconds(), true) + fieldSeparator);
                }
            }
            var _loc_3:String = "";
            if (includeLevel)
            {
                _loc_3 = "[" + LogEvent.getLevelString(event.level) + "]" + fieldSeparator;
            }
            var _loc_4:* = includeCategory ? (ILogger(event.target).category + fieldSeparator) : ("");
            internalLog(_loc_2 + _loc_3 + _loc_4 + event.message);
            return;
        }// end function

        function internalLog(param1:String) : void
        {
            return;
        }// end function

    }
}
