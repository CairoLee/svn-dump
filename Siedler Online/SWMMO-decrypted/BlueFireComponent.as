package 
{
    import BlueFireComponent.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.flex3.defaultClient.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import com.bluebyte.bluefire.puremvc.view.xiff.*;
    import flash.display.*;
    import flash.utils.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;
    import org.puremvc.as3.multicore.interfaces.*;

    public class BlueFireComponent extends Canvas
    {
        private var _panel:Object;
        private var _panelClass:Class;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _chatPanelMediatorClass:Class;
        private var _facade:BlueFireFacade;

        public function BlueFireComponent()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas});
            this._facade = BlueFireFacade.getInstance(getTimer() + "" + Math.random());
            mx_internal::_document = this;
            this.addEventListener("creationComplete", this.___BlueFireComponent_Canvas1_creationComplete);
            return;
        }// end function

        public function set chatPanelMediatorClass(param1:Class) : void
        {
            this._chatPanelMediatorClass = param1;
            return;
        }// end function

        public function addChannel(param1:String, param2:Array, param3:Boolean, param4:int) : void
        {
            var _loc_6:String = null;
            var _loc_5:* = new ChannelVO();
            new ChannelVO().name = param1;
            for each (_loc_6 in param2)
            {
                
                _loc_5.addRoom(_loc_6);
            }
            _loc_5.visible = param3;
            _loc_5.sortingIndex = param4;
            this._facade.sendNotification(BlueFireFacade.ADD_CHANNEL, _loc_5);
            return;
        }// end function

        public function ___BlueFireComponent_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.init(event);
            return;
        }// end function

        protected function init(event:FlexEvent) : void
        {
            if (!this._chatPanelMediatorClass)
            {
                this._chatPanelMediatorClass = ChatPanelMediator;
                trace("No ChatPanelMediatorClass set, using default");
            }
            if (!this._panelClass)
            {
                this._panelClass = ChatPanel;
                trace("No ChatPanelClass set, using default");
            }
            this._panel = new this._panelClass();
            this.addChild(this._panel as DisplayObject);
            this._facade.startup(this._panel, this._chatPanelMediatorClass);
            return;
        }// end function

        public function updateGroupSeperator(param1:String) : void
        {
            this._facade.sendNotification(BlueFireFacade.UPDATE_ROOM_GROUP_SEPERATOR, param1);
            return;
        }// end function

        public function set panelClass(param1:Class) : void
        {
            this._panelClass = param1;
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function connect() : void
        {
            this._facade.sendNotification(XIFFConnectionMediator.XIFF_CONNECT);
            return;
        }// end function

        public function updatePlayerData(param1:PlayerVO) : void
        {
            this._facade.sendNotification(BlueFireFacade.UPDATE_PLAYER_DATA, param1);
            return;
        }// end function

        public function updateServerData(param1:ServerVO) : void
        {
            this._facade.sendNotification(BlueFireFacade.UPDATE_SERVER_DATA, param1);
            return;
        }// end function

        public function registerMessageMediator(param1:IMediator) : void
        {
            this._facade.registerMediator(param1);
            return;
        }// end function

    }
}
