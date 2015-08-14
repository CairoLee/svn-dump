package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cFindBan extends SlashCommand
    {
        public static const COMMAND_FIND_BAN:String = "commandFindBan";

        public function cFindBan()
        {
            _regEx = /\/findban\s.+""\/findban\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_FIND_BAN;
        }// end function

    }
}
