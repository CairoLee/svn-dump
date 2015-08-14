package nLib
{
    import flash.events.*;

    public class cCustomDispatcher extends EventDispatcher
    {
        public static var mAction_string:String = "action";

        public function cCustomDispatcher()
        {
            return;
        }// end function

        public function doActionWithData(param1:String, param2:Object) : void
        {
            dispatchEvent(new cEventWithData(cCustomDispatcher.mAction_string, param1, param2, false, false));
            return;
        }// end function

        public function doAction() : void
        {
            dispatchEvent(new Event(cCustomDispatcher.mAction_string));
            return;
        }// end function

    }
}
