package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class UpdatePlayerDataCommand extends SimpleCommand
    {

        public function UpdatePlayerDataCommand()
        {
            return;
        }// end function

        override public function execute(param1:INotification) : void
        {
            var _loc_2:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            _loc_2.player = param1.getBody() as PlayerVO;
            return;
        }// end function

    }
}
