package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cUnban extends SlashCommand
    {
        public static const COMMAND_UNBAN:String = "commandUnban";

        public function cUnban()
        {
            _regEx = /\/unban\s.+""\/unban\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_UNBAN;
        }// end function

    }
}
