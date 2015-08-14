package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import org.igniterealtime.xiff.data.*;

    public class MessageEvent extends Event
    {
        private var _data:Message;
        public static const MESSAGE:String = "message";

        public function MessageEvent()
        {
            super(MessageEvent.MESSAGE, false, false);
            return;
        }// end function

        public function set data(param1:Message) : void
        {
            _data = param1;
            return;
        }// end function

        public function get data() : Message
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[MessageEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new MessageEvent();
            _loc_1.data = _data;
            return _loc_1;
        }// end function

    }
}
