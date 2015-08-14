package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cIgnoreShow extends SlashCommand
    {
        public static const COMMAND_IGNORE_SHOW:String = "commandIgnoreShow";

        public function cIgnoreShow()
        {
            _regEx = /\/ignoreshow""\/ignoreshow/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_IGNORE_SHOW;
        }// end function

    }
}
