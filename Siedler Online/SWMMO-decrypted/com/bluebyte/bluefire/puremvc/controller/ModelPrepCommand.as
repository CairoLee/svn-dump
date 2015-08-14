package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.puremvc.model.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class ModelPrepCommand extends SimpleCommand
    {

        public function ModelPrepCommand()
        {
            return;
        }// end function

        override public function execute(param1:INotification) : void
        {
            facade.registerProxy(new ConnectionProxy());
            return;
        }// end function

    }
}
