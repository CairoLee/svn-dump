package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cIgnoreRemove extends SlashCommand
    {
        public static const COMMAND_IGNORE_REMOVE:String = "commandIgnoreRemove";

        public function cIgnoreRemove()
        {
            _regEx = /\/ignoreremove\s.+""\/ignoreremove\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_IGNORE_REMOVE;
        }// end function

    }
}
