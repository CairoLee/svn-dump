package org.puremvc.as3.multicore.patterns.command
{
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.observer.*;

    public class MacroCommand extends Notifier implements ICommand, INotifier
    {
        private var subCommands:Array;

        public function MacroCommand()
        {
            subCommands = new Array();
            initializeMacroCommand();
            return;
        }// end function

        final public function execute(param1:INotification) : void
        {
            var _loc_2:Class = null;
            var _loc_3:ICommand = null;
            while (subCommands.length > 0)
            {
                
                _loc_2 = subCommands.shift();
                _loc_3 = new _loc_2;
                _loc_3.initializeNotifier(multitonKey);
                _loc_3.execute(param1);
            }
            return;
        }// end function

        protected function addSubCommand(param1:Class) : void
        {
            subCommands.push(param1);
            return;
        }// end function

        protected function initializeMacroCommand() : void
        {
            return;
        }// end function

    }
}
