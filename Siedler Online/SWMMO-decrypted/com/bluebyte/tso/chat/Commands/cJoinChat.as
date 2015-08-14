package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cJoinChat extends SlashCommand
    {
        public static const COMMAND_JOIN_CHAT:String = "commandJoinChat";

        public function cJoinChat()
        {
            _regEx = /\/joinchat global-[\d]+""\/joinchat global-[\d]+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_JOIN_CHAT;
        }// end function

    }
}
