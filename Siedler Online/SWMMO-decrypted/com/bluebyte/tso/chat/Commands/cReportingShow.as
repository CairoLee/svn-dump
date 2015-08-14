package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cReportingShow extends SlashCommand
    {
        public static const COMMAND_REPORTING_SHOW:String = "commandReportingShow";

        public function cReportingShow()
        {
            _regEx = /\/showreporting""\/showreporting/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            return COMMAND_REPORTING_SHOW;
        }// end function

    }
}
