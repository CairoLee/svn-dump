package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class LoginEvent extends Event
    {
        public static const LOGIN:String = "login";

        public function LoginEvent()
        {
            super(LOGIN, false, false);
            return;
        }// end function

        override public function toString() : String
        {
            return "[LoginEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            return new LoginEvent();
        }// end function

    }
}
