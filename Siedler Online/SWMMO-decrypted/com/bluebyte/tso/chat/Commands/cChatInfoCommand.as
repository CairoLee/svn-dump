package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cChatInfoCommand extends SlashCommand
    {
        public static const COMMAND_CHAT_INFO:String = "commandChatInfo";

        public function cChatInfoCommand()
        {
            _regEx = /\/chatinfo""\/chatinfo/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_CHAT_INFO;
        }// end function

    }
}
