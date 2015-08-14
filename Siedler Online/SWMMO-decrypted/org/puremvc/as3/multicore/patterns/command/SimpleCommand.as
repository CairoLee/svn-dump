package org.puremvc.as3.multicore.patterns.command
{
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.observer.*;

    public class SimpleCommand extends Notifier implements ICommand, INotifier
    {

        public function SimpleCommand()
        {
            return;
        }// end function

        public function execute(param1:INotification) : void
        {
            return;
        }// end function

    }
}
