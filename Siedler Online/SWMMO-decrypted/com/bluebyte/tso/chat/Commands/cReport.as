package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cReport extends SlashCommand
    {
        public static const COMMAND_REPORT:String = "commandReport";

        public function cReport()
        {
            _regEx = /\/report\s.+\s.+""\/report\s.+\s.+/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_REPORT;
        }// end function

    }
}
