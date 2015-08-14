package com.bluebyte.bluefire.flex3.defaultClient
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class ChatPanel extends Canvas implements IChatPanel, IBindingClient
    {
        private var _3613077vbox:VBox;
        private var _892481550status:Label;
        private var _139203217whispersList:CustomList;
        private var _1784002189messageHistory:ChatHistoryList;
        private var _11548545buttonBar:ChatToggleButtonBar;
        private var _selectedChannel:ChannelVO;
        var _watchers:Array;
        private var _676870449autoScrollBox:CheckBox;
        var _bindingsBeginWithWord:Object;
        public var _ChatPanel_Button1:Button;
        public var _ChatPanel_Button2:Button;
        private var _1599613778chatInput:CustomInput;
        var _bindingsByDestination:Object;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ChatPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.backgroundColor = 13421772;
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {height:20, childDescriptors:[new UIComponentDescriptor({type:Label, id:"status", propertiesFactory:function () : Object
                    {
                        return {null:null};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "5";
                    this.right = "5";
                    this.top = "25";
                    this.bottom = "35";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:VBox, id:"vbox", stylesFactory:function () : void
                    {
                        this.verticalGap = 6;
                        this.horizontalGap = 0;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:ChatHistoryList, id:"messageHistory", stylesFactory:function () : void
                            {
                                null.backgroundAlpha = this;
                                this.borderThickness = 0;
                                this.left = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {editable:false, selectable:false, verticalScrollPolicy:"off", variableRowHeight:true, percentHeight:100, percentWidth:100, itemRenderer:_ChatPanel_ClassFactory1_c()};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                return {width:18, clipContent:true, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Button, id:"_ChatPanel_Button1", events:{mouseDown:"___ChatPanel_Button1_mouseDown"}, stylesFactory:function () : void
                                {
                                    this.top = "0";
                                    this.horizontalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, height:22};
                                }// end function
                                }), new UIComponentDescriptor({type:Button, id:"_ChatPanel_Button2", events:{mouseDown:"___ChatPanel_Button2_mouseDown"}, stylesFactory:function () : void
                                {
                                    null.bottom = this;
                                    this.horizontalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {width:22, height:22};
                                }// end function
                                }), new UIComponentDescriptor({type:CheckBox, id:"autoScrollBox", events:{click:"__autoScrollBox_click"}, stylesFactory:function () : void
                                {
                                    null.bottom = this;
                                    this.horizontalCenter = "-1";
                                    return;
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:CustomList, id:"whispersList", stylesFactory:function () : void
                            {
                                null.top = this;
                                this.right = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:100, visible:false, labelField:"name", itemRenderer:_ChatPanel_ClassFactory2_c()};
                            }// end function
                            }), new UIComponentDescriptor({type:ChatToggleButtonBar, id:"buttonBar", stylesFactory:function () : void
                            {
                                null.top = this;
                                this.right = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:1, focusEnabled:false, percentHeight:100, width:100, itemRenderer:_ChatPanel_ClassFactory3_c()};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:CustomInput, id:"chatInput", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:500, styleName:"chatInput", height:30, restrict:"^\\<"};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.percentWidth = 100;
            this.percentHeight = 100;
            this.styleName = "chatPanel";
            this.cacheAsBitmap = true;
            return;
        }// end function

        public function get messageInput() : IBFTextInput
        {
            return this.chatInput;
        }// end function

        public function get buttonBar() : ChatToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        public function set buttonBar(param1:ChatToggleButtonBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        public function get messageHistory() : ChatHistoryList
        {
            return this._1784002189messageHistory;
        }// end function

        public function activateWhisper() : void
        {
            this.whispersList.visible = true;
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ChatPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ChatPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_com_bluebyte_bluefire_flex3_defaultClient_ChatPanelWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        public function get mucs() : IBFList
        {
            return this.buttonBar;
        }// end function

        protected function HandleScrollDownStop(event:Event) : void
        {
            Application.application.removeEventListener(Event.ENTER_FRAME, this.HandleScrollDown);
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.HandleScrollDownStop);
            return;
        }// end function

        public function ___ChatPanel_Button2_mouseDown(event:MouseEvent) : void
        {
            this.button3_clickHandler(event);
            return;
        }// end function

        public function set messageHistory(param1:ChatHistoryList) : void
        {
            var _loc_2:* = this._1784002189messageHistory;
            if (_loc_2 !== param1)
            {
                this._1784002189messageHistory = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "messageHistory", _loc_2, param1));
            }
            return;
        }// end function

        private function button1_clickHandler(event:MouseEvent) : void
        {
            this.messageHistory.autoscroll = (event.target as CheckBox).selected;
            return;
        }// end function

        public function set chatInput(param1:CustomInput) : void
        {
            var _loc_2:* = this._1599613778chatInput;
            if (_loc_2 !== param1)
            {
                this._1599613778chatInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "chatInput", _loc_2, param1));
            }
            return;
        }// end function

        public function set vbox(param1:VBox) : void
        {
            var _loc_2:* = this._3613077vbox;
            if (_loc_2 !== param1)
            {
                this._3613077vbox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "vbox", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.selectedChannel.messages;
            _loc_1 = this.enabled;
            _loc_1 = this.enabled;
            _loc_1 = this.messageHistory.autoscroll;
            _loc_1 = this.whispersList.visible ? (100) : (0);
            _loc_1 = new ArrayCollection();
            _loc_1 = new ArrayCollection();
            return;
        }// end function

        public function set autoScrollBox(param1:CheckBox) : void
        {
            var _loc_2:* = this._676870449autoScrollBox;
            if (_loc_2 !== param1)
            {
                this._676870449autoScrollBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "autoScrollBox", _loc_2, param1));
            }
            return;
        }// end function

        protected function HandleScrollUp(event:Event) : void
        {
            this.messageHistory.ScrollList(-3);
            return;
        }// end function

        private function set _174067176selectedChannel(param1:ChannelVO) : void
        {
            this._selectedChannel = param1;
            return;
        }// end function

        public function get vbox() : VBox
        {
            return this._3613077vbox;
        }// end function

        private function _ChatPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ChatMessageItemRenderer;
            return _loc_1;
        }// end function

        private function _ChatPanel_ClassFactory3_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ButtonBarItemRenderer;
            return _loc_1;
        }// end function

        private function _ChatPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return this.messages;
            }// end function
            , function (param1:Object) : void
            {
                messageHistory.dataProvider = param1;
                return;
            }// end function
            , "messageHistory.dataProvider");
            result[0] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "_ChatPanel_Button1.enabled");
            result[1] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "_ChatPanel_Button2.enabled");
            result[2] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return messageHistory.autoscroll;
            }// end function
            , function (param1:Boolean) : void
            {
                null.selected = param1;
                return;
            }// end function
            , "autoScrollBox.selected");
            result[3] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.visible ? (100) : (0);
            }// end function
            , function (param1:Number) : void
            {
                null.width = null;
                return;
            }// end function
            , "whispersList.width");
            result[4] = binding;
            binding = new Binding(this, function () : Object
            {
                return new ArrayCollection();
            }// end function
            , function (param1:Object) : void
            {
                whispersList.dataProvider = param1;
                return;
            }// end function
            , "whispersList.dataProvider");
            result[5] = binding;
            binding = new Binding(this, function () : Object
            {
                return new ArrayCollection();
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = param1;
                return;
            }// end function
            , "buttonBar.dataProvider");
            result[6] = binding;
            return result;
        }// end function

        public function __autoScrollBox_click(event:MouseEvent) : void
        {
            this.button1_clickHandler(event);
            return;
        }// end function

        public function handleClick(event:MouseEvent) : void
        {
            this.messageInput.setFocus();
            return;
        }// end function

        protected function button2_clickHandler(event:MouseEvent) : void
        {
            Application.application.addEventListener(Event.ENTER_FRAME, this.HandleScrollUp);
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.HandleScrollUpStop);
            return;
        }// end function

        public function get status() : Label
        {
            return this._892481550status;
        }// end function

        public function set selectedChannel(param1:ChannelVO) : void
        {
            var _loc_2:* = this.selectedChannel;
            if (_loc_2 !== param1)
            {
                this._174067176selectedChannel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedChannel", _loc_2, param1));
            }
            return;
        }// end function

        public function get whispers() : IBFList
        {
            return this.whispersList;
        }// end function

        public function ___ChatPanel_Button1_mouseDown(event:MouseEvent) : void
        {
            this.button2_clickHandler(event);
            return;
        }// end function

        public function get autoScrollBox() : CheckBox
        {
            return this._676870449autoScrollBox;
        }// end function

        protected function HandleScrollUpStop(event:Event) : void
        {
            Application.application.removeEventListener(Event.ENTER_FRAME, this.HandleScrollUp);
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.HandleScrollUpStop);
            return;
        }// end function

        public function set whispersList(param1:CustomList) : void
        {
            var _loc_2:* = this._139203217whispersList;
            if (_loc_2 !== param1)
            {
                this._139203217whispersList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "whispersList", _loc_2, param1));
            }
            return;
        }// end function

        protected function button3_clickHandler(event:MouseEvent) : void
        {
            Application.application.addEventListener(Event.ENTER_FRAME, this.HandleScrollDown);
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.HandleScrollDownStop);
            return;
        }// end function

        public function get chatInput() : CustomInput
        {
            return this._1599613778chatInput;
        }// end function

        private function changeTextAlignment(event:Event) : void
        {
            var _loc_4:Button = null;
            if (event.target.dataProvider == null)
            {
                return;
            }
            event.target.setStyle("buttonWidth", event.target.width / event.target.dataProvider.length);
            var _loc_2:* = event.target.dataProvider.length;
            if (_loc_2 == 0)
            {
                return;
            }
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = event.target.getChildAt(_loc_3) as Button;
                _loc_4.setStyle("paddingTop", -3);
                _loc_3++;
            }
            (event.target.getChildAt(event.target.selectedIndex) as Button).setStyle("paddingTop", 5);
            return;
        }// end function

        public function set status(param1:Label) : void
        {
            var _loc_2:* = this._892481550status;
            if (_loc_2 !== param1)
            {
                this._892481550status = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "status", _loc_2, param1));
            }
            return;
        }// end function

        public function deactivateWhisper() : void
        {
            this.whispersList.visible = false;
            return;
        }// end function

        public function get selectedChannel() : ChannelVO
        {
            return this._selectedChannel;
        }// end function

        protected function HandleScrollDown(event:Event) : void
        {
            this.messageHistory.ScrollList(3);
            return;
        }// end function

        private function _ChatPanel_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ButtonBarItemRenderer;
            return _loc_1;
        }// end function

        public function get whispersList() : CustomList
        {
            return this._139203217whispersList;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            ChatPanel._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
