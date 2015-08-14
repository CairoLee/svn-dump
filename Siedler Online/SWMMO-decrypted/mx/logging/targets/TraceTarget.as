package mx.logging.targets
{

    public class TraceTarget extends LineFormattedTarget
    {
        static const VERSION:String = "3.5.0.12683";

        public function TraceTarget()
        {
            return;
        }// end function

        override function internalLog(param1:String) : void
        {
            trace(param1);
            return;
        }// end function

    }
}
