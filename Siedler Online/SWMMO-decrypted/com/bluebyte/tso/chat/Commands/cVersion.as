package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cVersion extends SlashCommand
    {
        public static const COMMAND_VERSION:String = "commandVersion";

        public function cVersion()
        {
            _regEx = /\/version""\/version/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_VERSION;
        }// end function

    }
}
