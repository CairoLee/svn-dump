package com.bluebyte.bluefire.puremvc.view
{
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import flash.events.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.events.*;
    import mx.utils.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class ChatPanelMediator extends Mediator implements IMediator
    {
        protected var _roomSendCoolDown:Timer;
        private var _connectionProxy:ConnectionProxy;
        public static const NAME:String = "ChatPanelMediator";

        public function ChatPanelMediator(param1:IChatPanel)
        {
            this._roomSendCoolDown = new Timer(5000, 1);
            super(NAME, param1);
            this.panel.messageInput.addEventListener(KeyboardEvent.KEY_UP, this.KeyDown);
            this.panel.mucs.addEventListener(ItemClickEvent.ITEM_CLICK, this.HandleTabClick);
            this.panel.whispers.addEventListener(ItemClickEvent.ITEM_CLICK, this.HandleTabClick);
            var _loc_2:* = new SortField();
            _loc_2.name = "sortingIndex";
            _loc_2.caseInsensitive = true;
            _loc_2.numeric = true;
            var _loc_3:* = new Sort();
            _loc_3.fields = [_loc_2];
            (this.panel.mucs.dataProvider as ArrayCollection).sort = _loc_3;
            (this.panel.mucs.dataProvider as ArrayCollection).refresh();
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [BlueFireFacade.ADD_CHANNEL, BlueFireFacade.REMOVE_CHANNEL, BlueFireFacade.ADD_WHISPER, BlueFireFacade.MESSAGE_CREATED_ADDED, BlueFireFacade.REMOVE_WHISPER];
        }// end function

        override public function onRegister() : void
        {
            this._connectionProxy = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            return;
        }// end function

        private function KeyDown(event:KeyboardEvent) : void
        {
            var _loc_3:String = null;
            var _loc_4:MessageVO = null;
            var _loc_5:int = 0;
            var _loc_6:Array = null;
            var _loc_7:String = null;
            var _loc_2:* = this.panel.messageInput.text;
            if (this.panel.messageInput.text.substr(0, 1) == "\\")
            {
                _loc_2 = "/" + _loc_2.slice(1);
            }
            if (event.keyCode == Keyboard.ENTER)
            {
                if (_loc_2 == "")
                {
                    return;
                }
                if (!this._connectionProxy.isJoiningInProgress())
                {
                    if (_loc_2.substr(0, 1) == "/")
                    {
                        if (_loc_2.substr(0, 5) == "/all ")
                        {
                            if (!this._roomSendCoolDown.running)
                            {
                                this._roomSendCoolDown.reset();
                                this._roomSendCoolDown.start();
                            }
                            else
                            {
                                this.PutMessageToChannelWithoutServer(this.panel.selectedChannel.name, new Date(), "SERVER", TextController.instance.getText("ClientRoomSendCooldown", [this._roomSendCoolDown.delay / 1000]), true, false);
                                this.panel.messageInput.setFocus();
                                return;
                            }
                        }
                        sendNotification(BlueFireFacade.EVALUATE_SLASH_COMMAND, _loc_2);
                    }
                    else
                    {
                        _loc_3 = this.panel.selectedChannel.name;
                        if (_loc_3 != "news" && _loc_3 != "whisper")
                        {
                            if (!this._roomSendCoolDown.running || !this.RoomIsAffectedByCooldown(_loc_3))
                            {
                                _loc_4 = new MessageVO();
                                _loc_4.room = _loc_3;
                                _loc_4.text = this.panel.messageInput.text;
                                _loc_5 = this.panel.mucs.dataProvider.getItemIndex(this.panel.selectedChannel);
                                if (_loc_5 != -1)
                                {
                                    _loc_4.groupMessage = true;
                                }
                                sendNotification(BlueFireFacade.SEND_MESSAGE, _loc_4);
                                if (this.RoomIsAffectedByCooldown(_loc_3))
                                {
                                    this._roomSendCoolDown.reset();
                                    this._roomSendCoolDown.start();
                                }
                            }
                            else
                            {
                                this.PutMessageToChannelWithoutServer(this.panel.selectedChannel.name, new Date(), "SERVER", TextController.instance.getText("ClientRoomSendCooldown", [this._roomSendCoolDown.delay / 1000]), true, false);
                                this.panel.messageInput.setFocus();
                                return;
                            }
                        }
                    }
                }
                this.CleanMessageInput();
                this.panel.messageInput.setFocus();
                ;
            }
            if (_loc_2.substr(0, 1) == "/")
            {
            }
            if (_loc_2.search(/\/w\s.+\s""\/w\s.+\s/) != -1)
            {
            }
            _loc_6 = this.panel.messageInput.text.split(" ");
            _loc_7 = StringUtil.trim(_loc_6[1]);
            this.CleanMessageInput();
            if (_loc_6.length > 2)
            {
                this.panel.messageInput.text = _loc_6[2];
            }
            this.ActivatePrivateChat(_loc_7);
            return;
        }// end function

        public function PutMessageToChannelWithoutServer(param1:String, param2:Date, param3:String, param4:String, param5:Boolean, param6:Boolean) : void
        {
            var _loc_7:* = new MessageVO();
            new MessageVO().room = param1;
            _loc_7.time = param2;
            _loc_7.sender = new OccupantVO();
            _loc_7.sender.name = param3;
            _loc_7.text = param4;
            _loc_7.important = param5;
            _loc_7.clickable = param6;
            _loc_7.groupMessage = true;
            sendNotification(BlueFireFacade.ADD_MESSAGE, _loc_7);
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            var _loc_2:String = null;
            var _loc_3:int = 0;
            var _loc_4:ChannelVO = null;
            var _loc_5:ChannelVO = null;
            var _loc_6:ChannelVO = null;
            switch(param1.getName())
            {
                case BlueFireFacade.ADD_CHANNEL:
                {
                    this.panel.mucs.dataProvider.addItem(param1.getBody());
                    this.panel.selectedChannel = this.panel.mucs.dataProvider.getItemAt(0);
                    break;
                }
                case BlueFireFacade.ADD_WHISPER:
                {
                    this.panel.whispers.dataProvider.addItem(param1.getBody());
                    break;
                }
                case BlueFireFacade.REMOVE_WHISPER:
                {
                    this.panel.whispers.dataProvider.removeItemAt(this.panel.whispers.dataProvider.getItemIndex(param1.getBody()));
                    break;
                }
                case BlueFireFacade.REMOVE_CHANNEL:
                {
                    _loc_2 = param1.getBody() as String;
                    _loc_3 = 0;
                    while (_loc_3 < this.panel.mucs.dataProvider.length)
                    {
                        
                        if ((this.panel.mucs.dataProvider[_loc_3] as ChannelVO).name == _loc_2)
                        {
                            if (this.panel.mucs.dataProvider.getItemAt(_loc_3) == this.panel.selectedChannel)
                            {
                                this.panel.selectedChannel = this.panel.mucs.dataProvider.getItemAt(0);
                            }
                            this.panel.mucs.dataProvider.removeItemAt(_loc_3);
                            break;
                        }
                        _loc_3++;
                    }
                    break;
                }
                case BlueFireFacade.MESSAGE_CREATED_ADDED:
                {
                    for each (_loc_4 in this._connectionProxy.channels)
                    {
                        
                        if (_loc_4.hasRoom((param1.getBody() as MessageVO).room))
                        {
                            _loc_4.newMessages = true;
                        }
                    }
                    for each (_loc_5 in this._connectionProxy.whispers)
                    {
                        
                        if (_loc_5.hasRoom((param1.getBody() as MessageVO).room))
                        {
                            _loc_5.newMessages = true;
                            this._connectionProxy.getChannel("whisper").newMessages = true;
                            break;
                        }
                    }
                    if (this.panel.selectedChannel)
                    {
                        this.panel.selectedChannel.newMessages = false;
                    }
                    for each (_loc_6 in this._connectionProxy.whispers)
                    {
                        
                        if (_loc_6 == this.panel.selectedChannel)
                        {
                            this._connectionProxy.getChannel("whisper").newMessages = false;
                            break;
                        }
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function CleanMessageInput() : void
        {
            this.panel.messageInput.text = "";
            return;
        }// end function

        public function ActivatePrivateChat(param1:String) : void
        {
            this.panel.selectedChannel = this._connectionProxy.getWhisper(param1);
            this.panel.mucs.selectedItem = this._connectionProxy.getChannel("whisper");
            this.panel.whispers.selectedItem = this.panel.selectedChannel;
            this.panel.activateWhisper();
            return;
        }// end function

        protected function setRoomSendCooldown(param1:int) : void
        {
            this._roomSendCoolDown = new Timer(param1, 1);
            return;
        }// end function

        protected function get connectionProxy() : ConnectionProxy
        {
            return this._connectionProxy;
        }// end function

        protected function HandleTabClick(event:ListEvent) : void
        {
            var _loc_2:* = event.itemRenderer.data as ChannelVO;
            _loc_2.newMessages = false;
            if (_loc_2.name == "whisper")
            {
                this.panel.activateWhisper();
                this.panel.selectedChannel = this.panel.whispers.selectedItem as ChannelVO;
                if (!this.panel.selectedChannel)
                {
                    this.panel.selectedChannel = _loc_2;
                }
            }
            else
            {
                if (this.panel.mucs.dataProvider.getItemIndex(_loc_2) != -1)
                {
                    this.panel.deactivateWhisper();
                }
                this.panel.selectedChannel = _loc_2;
            }
            return;
        }// end function

        private function get panel() : IChatPanel
        {
            return viewComponent as IChatPanel;
        }// end function

        private function RoomIsAffectedByCooldown(param1:String) : Boolean
        {
            return param1 == "help" || param1.indexOf("global-") == 0 || param1.indexOf("gc_") == 0 || param1.indexOf("gco_") == 0;
        }// end function

    }
}
