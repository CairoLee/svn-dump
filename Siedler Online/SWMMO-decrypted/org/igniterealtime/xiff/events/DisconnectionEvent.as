package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class DisconnectionEvent extends Event
    {
        public static const DISCONNECT:String = "disconnection";

        public function DisconnectionEvent()
        {
            super(DISCONNECT, false, false);
            return;
        }// end function

        override public function toString() : String
        {
            return "[DisconnectionEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            return new DisconnectionEvent();
        }// end function

    }
}
