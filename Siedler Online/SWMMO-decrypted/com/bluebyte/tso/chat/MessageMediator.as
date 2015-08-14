package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class MessageMediator extends Mediator
    {
        private var _connectionProxy:ConnectionProxy;
        private var _tsoDataProxy:TSODataProxy;
        public static const NAME:String = "MessageMediator";

        public function MessageMediator()
        {
            super(NAME);
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [BlueFireFacade.MESSAGE_CREATED, BlueFireFacade.SEND_MESSAGE_CREATED, BlueFireFacade.MESSAGE_CREATED_ADDED_AFTER];
        }// end function

        override public function onRegister() : void
        {
            this._connectionProxy = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            this._tsoDataProxy = facade.retrieveProxy(TSODataProxy.NAME) as TSODataProxy;
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            var _loc_2:MessageVOContainer = null;
            var _loc_3:CustomMessageVO = null;
            var _loc_4:CustomOccupantVO = null;
            var _loc_5:MessageVO = null;
            var _loc_6:SWMMOChatMessage = null;
            var _loc_7:ChannelVO = null;
            if (!this._connectionProxy)
            {
                this._connectionProxy = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            }
            if (!this._tsoDataProxy)
            {
                this._tsoDataProxy = facade.retrieveProxy(TSODataProxy.NAME) as TSODataProxy;
            }
            switch(param1.getName())
            {
                case BlueFireFacade.MESSAGE_CREATED:
                {
                    _loc_2 = param1.getBody() as MessageVOContainer;
                    _loc_2.message = new CustomMessageVO(_loc_2.message);
                    _loc_3 = _loc_2.message as CustomMessageVO;
                    _loc_4 = new CustomOccupantVO(_loc_3.sender);
                    if (_loc_3.getExtension("bbmsg"))
                    {
                        _loc_4.id = (_loc_3.getExtension("bbmsg") as SWMMOChatMessage).mPlayerID;
                        _loc_4.name = (_loc_3.getExtension("bbmsg") as SWMMOChatMessage).mPlayerName;
                        _loc_4.tag = (_loc_3.getExtension("bbmsg") as SWMMOChatMessage).mPlayerTag;
                        if (_loc_4.tag == "null" || _loc_3.room.indexOf("gc_") == 0 || _loc_3.room.indexOf("gco_") == 0)
                        {
                            _loc_4.tag = "";
                        }
                        _loc_3.clickable = true;
                    }
                    _loc_3.sender = _loc_4;
                    if (!_loc_3.groupMessage && _loc_3.room.toLowerCase() == _loc_3.sender.name.toLowerCase())
                    {
                        _loc_3.room = _loc_3.sender.name;
                    }
                    if (_loc_3.groupMessage)
                    {
                        if (_loc_3.text && this._connectionProxy && this._connectionProxy.player && this._connectionProxy.player.name && _loc_3.text.toLowerCase().indexOf(this._connectionProxy.player.name.toLowerCase()) != -1)
                        {
                            _loc_3.ownname = true;
                            this._connectionProxy.getChannel(_loc_3.room.split("@")[0]).newMessages = false;
                            this._connectionProxy.getChannel(_loc_3.room.split("@")[0]).important = true;
                            this._connectionProxy.getChannel(_loc_3.room.split("@")[0]).newMessages = true;
                        }
                    }
                    if (_loc_3.sender.name.toLowerCase().indexOf("bb_") == 0 || _loc_3.sender.name.toLowerCase().indexOf("ubi_") == 0)
                    {
                        _loc_3.bluebyte = true;
                    }
                    else if (_loc_3.sender.name.toLowerCase().indexOf("mod_") == 0)
                    {
                        _loc_3.moderator = true;
                    }
                    break;
                }
                case BlueFireFacade.MESSAGE_CREATED_ADDED_AFTER:
                {
                    _loc_3 = new CustomMessageVO(param1.getBody() as MessageVO);
                    _loc_5 = param1.getBody() as MessageVO;
                    if (_loc_5.text.indexOf(TextController.instance.getText("ClientWelcomeRoom", [_loc_5.sender.name])) != -1 || _loc_5.room == "trade")
                    {
                        for each (_loc_7 in this._connectionProxy.channels)
                        {
                            
                            if (_loc_7.hasRoom((param1.getBody() as MessageVO).room))
                            {
                                _loc_7.newMessages = false;
                            }
                        }
                    }
                    break;
                }
                case BlueFireFacade.SEND_MESSAGE_CREATED:
                {
                    _loc_2 = param1.getBody() as MessageVOContainer;
                    _loc_2.message = new CustomMessageVO(_loc_2.message);
                    _loc_3 = _loc_2.message as CustomMessageVO;
                    _loc_6 = new SWMMOChatMessage();
                    _loc_6.mPlayerID = this._connectionProxy.player.id;
                    _loc_6.mPlayerName = this._connectionProxy.player.name;
                    _loc_6.mPlayerTag = this._tsoDataProxy.playerTag;
                    _loc_3.addExtension(_loc_6);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

    }
}
