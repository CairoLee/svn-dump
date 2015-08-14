package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cFindUser extends SlashCommand
    {
        public static const COMMAND_FIND_USER:String = "commandFindUser";

        public function cFindUser()
        {
            _regEx = /\/finduser\s.+""\/finduser\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_FIND_USER;
        }// end function

    }
}
