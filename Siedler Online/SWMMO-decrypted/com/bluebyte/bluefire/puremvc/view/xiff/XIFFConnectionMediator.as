package com.bluebyte.bluefire.puremvc.view.xiff
{
    import __AS3__.vec.*;
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.enum.*;
    import com.bluebyte.bluefire.api.extensions.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.core.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.events.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class XIFFConnectionMediator extends Mediator implements IMediator
    {
        private var _messageQueueEvent:Vector.<MessageEvent>;
        private var _joiningChatInProgress:Boolean;
        private var _messageReceiveInterceptors:ArrayCollection;
        private var _messageQueueLastTime:Number = 0;
        private var _keepAlive:Timer;
        private var _messageQueueTime:Vector.<Number>;
        private var _connectionProxy:ConnectionProxy;
        private var _messageSendInterceptors:ArrayCollection;
        public static const XIFF_CONNECTION_CREATED:String = "xiffConnectionCreated";
        public static const XIFF_CREATE_NEW_CONNECTION:String = "createNewConnection";
        public static const NAME:String = "XIFFConnectionMediator";
        public static const XIFF_CONNECT:String = "login";
        public static const XIFF_SEND_MESSAGE:String = "xiffSendMessage";

        public function XIFFConnectionMediator()
        {
            this._messageQueueTime = new Vector.<Number>;
            this._messageQueueEvent = new Vector.<MessageEvent>;
            this._messageReceiveInterceptors = new ArrayCollection();
            this._messageSendInterceptors = new ArrayCollection();
            super(NAME, new XMPPBOSHConnection());
            this.connection.addEventListener(ConnectionSuccessEvent.CONNECT_SUCCESS, this.connection_ConnectSuccessHandler);
            this.connection.addEventListener(XIFFErrorEvent.XIFF_ERROR, this.connection_XiffErrorHandler);
            this.connection.addEventListener(LoginEvent.LOGIN, this.connection_LoginHandler);
            this.connection.addEventListener(MessageEvent.MESSAGE, this.connection_MessageHandler);
            this._keepAlive = new Timer(2 * 60 * 1000);
            this._keepAlive.addEventListener(TimerEvent.TIMER, this.keepAlive_TimerHandler);
            Application.application.addEventListener(Event.ENTER_FRAME, this.application_EnterFrameHandler);
            return;
        }// end function

        private function application_EnterFrameHandler(event:Event) : void
        {
            var _loc_3:MessageEvent = null;
            if (this._messageQueueTime.length == 0)
            {
                return;
            }
            var _loc_2:* = getTimer();
            while (this._messageQueueTime.length > 0 && this._messageQueueTime[0] < _loc_2)
            {
                
                this._messageQueueTime.shift();
                _loc_3 = this._messageQueueEvent.shift();
                sendNotification(BlueFireFacade.ADD_MESSAGE, this.generateMessage(_loc_3));
            }
            return;
        }// end function

        private function connection_LoginHandler(event:LoginEvent) : void
        {
            this._connectionProxy.status = ConnectionStatus.LOGGED_IN;
            sendNotification(BlueFireFacade.LOGGED_IN);
            return;
        }// end function

        private function connection_ConnectSuccessHandler(event:ConnectionSuccessEvent) : void
        {
            this._connectionProxy.status = ConnectionStatus.LOGGING_IN;
            sendNotification(BlueFireFacade.CONNECTED, this.connection);
            this._keepAlive.start();
            return;
        }// end function

        private function createNewConnection() : void
        {
            this.connection.removeEventListener(ConnectionSuccessEvent.CONNECT_SUCCESS, this.connection_ConnectSuccessHandler);
            this.connection.removeEventListener(XIFFErrorEvent.XIFF_ERROR, this.connection_XiffErrorHandler);
            this.connection.removeEventListener(LoginEvent.LOGIN, this.connection_LoginHandler);
            this.connection.removeEventListener(MessageEvent.MESSAGE, this.connection_MessageHandler);
            this.connection = new XMPPBOSHConnection();
            this.connection.addEventListener(ConnectionSuccessEvent.CONNECT_SUCCESS, this.connection_ConnectSuccessHandler);
            this.connection.addEventListener(XIFFErrorEvent.XIFF_ERROR, this.connection_XiffErrorHandler);
            this.connection.addEventListener(LoginEvent.LOGIN, this.connection_LoginHandler);
            this.connection.addEventListener(MessageEvent.MESSAGE, this.connection_MessageHandler);
            return;
        }// end function

        private function connection_XiffErrorHandler(event:XIFFErrorEvent) : void
        {
            if (event.errorCondition == "Authentication Error")
            {
                this._connectionProxy.status = ConnectionStatus.LOGIN_FAILED;
            }
            else if (event.errorCondition == "not-authorized")
            {
                this._connectionProxy.status = ConnectionStatus.SERVER_NOT_AVAILABLE;
            }
            else if (event.errorCondition == "service-unavailable")
            {
                this._connectionProxy.status = ConnectionStatus.SERVER_NOT_AVAILABLE;
            }
            sendNotification(BlueFireFacade.CONNECTION_ERROR, this._connectionProxy.status);
            return;
        }// end function

        private function get connection() : XMPPBOSHConnection
        {
            return viewComponent as XMPPBOSHConnection;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [XIFFConnectionMediator.XIFF_CONNECT, XIFFConnectionMediator.XIFF_SEND_MESSAGE, XIFFConnectionMediator.XIFF_CREATE_NEW_CONNECTION];
        }// end function

        private function generateMessage(event:MessageEvent) : MessageVO
        {
            var _loc_4:* = undefined;
            var _loc_5:String = null;
            var _loc_6:Array = null;
            var _loc_7:Array = null;
            var _loc_2:* = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            var _loc_3:* = new MessageVO();
            _loc_3.sender = new OccupantVO();
            _loc_3.time = new Date();
            for each (_loc_4 in event.data.getAllExtensions())
            {
                
                if (_loc_4 is IMessageExtension)
                {
                    _loc_3.addExtension(_loc_4);
                }
            }
            if (event.data.errorCondition == "item-not-found")
            {
                _loc_3.sender.name = "SERVER";
                _loc_3.important = true;
                _loc_3.room = event.data.from.node;
                _loc_3.text = TextController.instance.getText("UserOffline");
                return _loc_3;
            }
            switch(event.data.type)
            {
                case "error":
                {
                    _loc_5 = event.data.body.split("|")[0];
                    _loc_6 = event.data.body.split("|");
                    _loc_6 = _loc_6.slice(1);
                    _loc_3.text = TextController.instance.getText(_loc_5, _loc_6);
                    _loc_3.sender.name = "SERVER";
                    _loc_3.important = true;
                    _loc_3.room = event.data.from.node;
                    if (event.data.from.domain.indexOf("conference") != -1)
                    {
                        _loc_3.groupMessage = true;
                    }
                    break;
                }
                case "groupchat":
                {
                    _loc_3.groupMessage = true;
                    _loc_3.room = event.data.from.node + "@" + event.data.from.domain;
                    if (event.data.body == null && event.data.subject != null)
                    {
                        _loc_7 = event.data.from.node.split("-");
                        if (_loc_7.length > 1)
                        {
                            _loc_3.sender.name = TextController.instance.getText("ChatLabelInstance", ["chat" + _loc_7[0], "ChatDelimiter", _loc_7[1]]);
                        }
                        else
                        {
                            _loc_3.sender.name = TextController.instance.getText("chat" + _loc_7[0]);
                        }
                        if (_loc_3.sender.name == TextController.UNDEFINED)
                        {
                            _loc_3.sender.name = event.data.from.node;
                        }
                        _loc_3.text = TextController.instance.getText("ClientWelcomeRoom", [_loc_3.sender.name]);
                    }
                    else
                    {
                        _loc_3.sender.clickable = true;
                        if (event.data.from.resource == _loc_2.player.name.toLowerCase())
                        {
                            return null;
                        }
                        _loc_3.text = event.data.body;
                        if (_loc_3.text == "This room is locked from entry until configuration is confirmed.")
                        {
                            return null;
                        }
                        if (_loc_3.text == "This room is now unlocked.")
                        {
                            return null;
                        }
                        if (event.data.from.resource == null && event.data.from.node != "reporting")
                        {
                            _loc_3.sender.name = _loc_2.player.name;
                        }
                        else if (event.data.from.node == "reporting")
                        {
                            _loc_3.sender.name = "Reporting";
                        }
                        else
                        {
                            _loc_3.sender.name = event.data.from.resource;
                        }
                    }
                    break;
                }
                default:
                {
                    if (event.data.from.toString() == _loc_2.server.ip)
                    {
                        _loc_3.sender.name = "SERVER";
                        _loc_3.text = event.data.body;
                        _loc_3.room = event.data.from.node;
                        sendNotification(BlueFireFacade.MESSAGE_CUSTOMALERT, _loc_3);
                        return null;
                    }
                    _loc_3.sender.clickable = true;
                    if (event.data.body == null)
                    {
                        return null;
                    }
                    _loc_3.text = event.data.body;
                    _loc_3.room = event.data.from.node;
                    break;
                    break;
                }
            }
            if (_loc_3.room.indexOf("@") != -1)
            {
                _loc_3.room = _loc_3.room.split("@")[0];
            }
            return _loc_3;
        }// end function

        private function connection_MessageHandler(event:MessageEvent) : void
        {
            var _loc_3:Number = NaN;
            var _loc_2:* = 100 + Math.random() * Math.random() * 200;
            if (this._messageQueueLastTime < getTimer())
            {
                _loc_3 = getTimer() + _loc_2;
            }
            else
            {
                _loc_3 = this._messageQueueLastTime + _loc_2;
            }
            this._messageQueueLastTime = _loc_3;
            this._messageQueueTime.push(_loc_3);
            this._messageQueueEvent.push(event);
            return;
        }// end function

        override public function onRegister() : void
        {
            this._connectionProxy = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            switch(param1.getName())
            {
                case XIFFConnectionMediator.XIFF_CONNECT:
                {
                    this.connection.username = this._connectionProxy.player.name;
                    this.connection.password = this._connectionProxy.player.password;
                    this.connection.port = this._connectionProxy.server.port;
                    this.connection.server = this._connectionProxy.server.ip;
                    sendNotification(XIFFConnectionMediator.XIFF_CONNECTION_CREATED, this.connection);
                    XMPPConnection.disableSASLMechanism("ANONYMOUS");
                    XMPPConnection.disableSASLMechanism("DIGEST-MD5");
                    XMPPConnection.disableSASLMechanism("EXTERNAL");
                    this.connection.connect(XMPPConnection.STREAM_TYPE_FLASH);
                    break;
                }
                case XIFFConnectionMediator.XIFF_SEND_MESSAGE:
                {
                    this.connection.send(param1.getBody() as Message);
                    break;
                }
                case XIFFConnectionMediator.XIFF_CREATE_NEW_CONNECTION:
                {
                    this.createNewConnection();
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function keepAlive_TimerHandler(event:TimerEvent) : void
        {
            this.connection.sendKeepAlive();
            return;
        }// end function

        private function set connection(param1:XMPPBOSHConnection) : void
        {
            viewComponent = param1;
            return;
        }// end function

    }
}
