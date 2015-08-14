package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cAll extends SlashCommand
    {
        public static const COMMAND_ALL:String = "commandAll";

        public function cAll()
        {
            _regEx = /\/all\s.+""\/all\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_ALL;
        }// end function

    }
}
