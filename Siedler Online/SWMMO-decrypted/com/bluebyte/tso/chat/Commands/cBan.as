package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cBan extends SlashCommand
    {
        public static const COMMAND_BAN:String = "commandBan";

        public function cBan()
        {
            _regEx = /\/ban\s.+\s[0-9]+\s.+""\/ban\s.+\s[0-9]+\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_BAN;
        }// end function

    }
}
