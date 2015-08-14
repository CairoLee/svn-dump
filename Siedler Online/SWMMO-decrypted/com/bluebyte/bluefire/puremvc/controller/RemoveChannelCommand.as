package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.puremvc.model.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class RemoveChannelCommand extends SimpleCommand
    {

        public function RemoveChannelCommand()
        {
            return;
        }// end function

        override public function execute(param1:INotification) : void
        {
            var _loc_2:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            _loc_2.removeChannel(param1.getBody() as String);
            return;
        }// end function

    }
}
