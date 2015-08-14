package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.api.extensions.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import com.bluebyte.bluefire.puremvc.view.xiff.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.events.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class SendMessageCommand extends SimpleCommand
    {

        public function SendMessageCommand()
        {
            return;
        }// end function

        private function createMessage(param1:MessageVO) : Message
        {
            var _loc_3:EscapedJID = null;
            var _loc_6:IMessageExtension = null;
            var _loc_2:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            var _loc_4:String = null;
            if (param1.groupMessage)
            {
                _loc_3 = new EscapedJID(param1.receiver.name + "@conference." + _loc_2.server.ip);
                _loc_4 = Message.TYPE_GROUPCHAT;
            }
            else
            {
                _loc_3 = new EscapedJID(param1.receiver.name + "@" + _loc_2.server.ip);
            }
            var _loc_5:* = new Message(_loc_3, null, param1.text, null, _loc_4);
            new Message(_loc_3, null, param1.text, null, _loc_4).from = new EscapedJID(param1.sender.name + "@" + _loc_2.server.ip);
            for each (_loc_6 in param1.getAllExtensions())
            {
                
                _loc_5.addExtension(_loc_6);
            }
            return _loc_5;
        }// end function

        override public function execute(param1:INotification) : void
        {
            var _loc_2:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            var _loc_3:* = param1.getBody() as MessageVO;
            _loc_3.receiver = new OccupantVO();
            _loc_3.receiver.name = _loc_3.room;
            _loc_3.receiver.id = -1;
            _loc_3.sender = new OccupantVO();
            _loc_3.sender.name = _loc_2.player.name;
            _loc_3.sender.id = _loc_2.player.id;
            _loc_3.time = new Date();
            var _loc_4:* = new MessageVOContainer(_loc_3);
            sendNotification(BlueFireFacade.SEND_MESSAGE_CREATED, _loc_4);
            var _loc_5:* = this.createMessage(_loc_4.message);
            sendNotification(XIFFConnectionMediator.XIFF_SEND_MESSAGE, _loc_5);
            var _loc_6:* = new MessageEvent();
            _loc_5.from = _loc_5.to;
            _loc_6.data = _loc_5;
            sendNotification(BlueFireFacade.ADD_MESSAGE, _loc_4.message);
            return;
        }// end function

    }
}
