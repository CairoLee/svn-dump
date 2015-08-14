package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cFindFriend extends SlashCommand
    {
        public static const COMMAND_FIND_FRIEND:String = "commandFindFriend";

        public function cFindFriend()
        {
            _regEx = /\/findfriend\s.+""\/findfriend\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_FIND_FRIEND;
        }// end function

    }
}
