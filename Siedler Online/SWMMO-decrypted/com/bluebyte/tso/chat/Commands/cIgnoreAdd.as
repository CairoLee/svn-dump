package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cIgnoreAdd extends SlashCommand
    {
        public static const COMMAND_IGNORE_ADD:String = "commandIgnoreAdd";

        public function cIgnoreAdd()
        {
            _regEx = /\/ignoreadd\s.+""\/ignoreadd\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_IGNORE_ADD;
        }// end function

    }
}
