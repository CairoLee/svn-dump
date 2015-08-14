package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cShowModLog extends SlashCommand
    {
        public static const COMMAND_SHOW_MOD_LOG:String = "commandShowModLog";

        public function cShowModLog()
        {
            _regEx = /\/showmodlog\s.+""\/showmodlog\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_SHOW_MOD_LOG;
        }// end function

    }
}
