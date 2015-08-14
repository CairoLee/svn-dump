package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class RegistrationSuccessEvent extends Event
    {
        public static const REGISTRATION_SUCCESS:String = "registrationSuccess";

        public function RegistrationSuccessEvent()
        {
            super(REGISTRATION_SUCCESS, false, false);
            return;
        }// end function

        override public function toString() : String
        {
            return "[RegistrationSuccessEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            return new RegistrationSuccessEvent();
        }// end function

    }
}
