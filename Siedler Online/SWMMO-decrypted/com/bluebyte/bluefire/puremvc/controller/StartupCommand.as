package com.bluebyte.bluefire.puremvc.controller
{
    import org.puremvc.as3.multicore.patterns.command.*;

    public class StartupCommand extends MacroCommand
    {

        public function StartupCommand()
        {
            return;
        }// end function

        override protected function initializeMacroCommand() : void
        {
            addSubCommand(ModelPrepCommand);
            addSubCommand(ViewPrepCommand);
            return;
        }// end function

    }
}
