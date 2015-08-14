package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cLeaveChat extends SlashCommand
    {
        public static const COMMAND_LEAVE_CHAT:String = "commandLeaveChat";

        public function cLeaveChat()
        {
            _regEx = /\/leavechat""\/leavechat/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_LEAVE_CHAT;
        }// end function

    }
}
