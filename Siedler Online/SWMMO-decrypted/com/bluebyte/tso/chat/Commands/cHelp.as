package com.bluebyte.tso.chat.Commands
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;

    public class cHelp extends SlashCommand
    {
        public static const COMMAND_HELP:String = "commandHelp";

        public function cHelp()
        {
            _regEx = /\/help""\/help/;
            return;
        }// end function

        override protected function internalEvaluate(param1:String) : String
        {
            var _loc_2:String = "\n";
            _loc_2 = _loc_2 + "Type /w username \n";
            _loc_2 = _loc_2 + "Type /joinChat global-X (X = number)\n";
            _loc_2 = _loc_2 + "Type /findFriend Friendname\n";
            _loc_2 = _loc_2 + "Type /version\n";
            _loc_2 = _loc_2 + "Type /ignoreshow\n";
            _loc_2 = _loc_2 + "Type /ignoreadd username\n";
            _loc_2 = _loc_2 + "Type /ignoreremove username\n";
            _loc_2 = _loc_2 + "Type /report Username Reason\n";
            return COMMAND_HELP;
        }// end function

    }
}
