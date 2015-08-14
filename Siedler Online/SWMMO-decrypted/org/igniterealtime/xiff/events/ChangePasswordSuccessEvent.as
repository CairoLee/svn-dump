package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class ChangePasswordSuccessEvent extends Event
    {
        public static const PASSWORD_SUCCESS:String = "changePasswordSuccess";

        public function ChangePasswordSuccessEvent()
        {
            super(PASSWORD_SUCCESS, false, false);
            return;
        }// end function

        override public function toString() : String
        {
            return "[ChangePasswordSuccessEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            return new ChangePasswordSuccessEvent();
        }// end function

    }
}
