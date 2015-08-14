package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class AddMessageCommand extends SimpleCommand
    {

        public function AddMessageCommand()
        {
            return;
        }// end function

        override public function execute(param1:INotification) : void
        {
            var _loc_2:* = param1.getBody() as MessageVO;
            if (!_loc_2)
            {
                return;
            }
            var _loc_3:* = new MessageVOContainer(_loc_2);
            var _loc_4:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            sendNotification(BlueFireFacade.MESSAGE_CREATED, _loc_3);
            _loc_4.addMessage(_loc_3.message);
            sendNotification(BlueFireFacade.MESSAGE_CREATED_ADDED, _loc_3.message);
            sendNotification(BlueFireFacade.MESSAGE_CREATED_ADDED_AFTER, _loc_3.message);
            return;
        }// end function

    }
}
