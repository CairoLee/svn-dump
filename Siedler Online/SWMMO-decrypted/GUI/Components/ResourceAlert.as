package GUI.Components
{
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class ResourceAlert extends Canvas
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868:Class;
        private var _text:String;
        private var _title:String;
        private var _1791483012titleLabel:Label;
        private var _252650492costsList:HBox;
        private var _defaultButtonFlag:uint = 0;
        private var _715594074paymentOrnament:Image;
        private var _1742128193buttonsList:HBox;
        private var _buttonFlags:uint = 0;
        private var _954925063message:Text;
        public static const STYLE_DEFAULT:int = 0;
        private static var _resourcesDisplay:Vector.<dResource>;
        private static var _localize:Boolean;

        public function ResourceAlert()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.top = "0";
                    this.bottom = "0";
                    this.right = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"paymentOrnament", stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.top = "-25";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"titleLabel", stylesFactory:function () : void
                {
                    this.left = "25";
                    this.right = "25";
                    this.top = "8";
                    this.textAlign = "center";
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Text, id:"message", stylesFactory:function () : void
                {
                    this.left = "25";
                    this.top = "40";
                    this.bottom = "60";
                    this.color = 16777215;
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false, width:250};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"costsList", stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"buttonsList", stylesFactory:function () : void
                {
                    this.bottom = "15";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868 = ResourceAlert__embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868;
            mx_internal::_document = this;
            this.clipContent = false;
            this.cacheAsBitmap = true;
            return;
        }// end function

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        public function set costsList(param1:HBox) : void
        {
            var _loc_2:* = this._252650492costsList;
            if (_loc_2 !== param1)
            {
                this._252650492costsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsList", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function set buttonsList(param1:HBox) : void
        {
            var _loc_2:* = this._1742128193buttonsList;
            if (_loc_2 !== param1)
            {
                this._1742128193buttonsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get message() : Text
        {
            return this._954925063message;
        }// end function

        public function set text(param1:String) : void
        {
            if (_localize && param1.length > 0)
            {
                this._text = cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_MESSAGES, param1);
            }
            else
            {
                this._text = param1;
            }
            return;
        }// end function

        public function set message(param1:Text) : void
        {
            var _loc_2:* = this._954925063message;
            if (_loc_2 !== param1)
            {
                this._954925063message = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "message", _loc_2, param1));
            }
            return;
        }// end function

        private function setTexts() : void
        {
            var _loc_1:dResource = null;
            var _loc_2:ResourceItemRenderer = null;
            this.titleLabel.text = this._title;
            this.message.text = this._text;
            this.costsList.removeAllChildren();
            for each (_loc_1 in _resourcesDisplay)
            {
                
                _loc_2 = new ResourceItemRenderer();
                _loc_1.amount = Math.floor(_loc_1.amount);
                _loc_2.data = _loc_1;
                this.costsList.addChild(_loc_2);
            }
            return;
        }// end function

        public function set titleLabel(param1:Label) : void
        {
            var _loc_2:* = this._1791483012titleLabel;
            if (_loc_2 !== param1)
            {
                this._1791483012titleLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "titleLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function addButtons() : void
        {
            var _loc_3:StandardButton = null;
            var _loc_1:* = cLocaManager.GetInstance();
            var _loc_2:* = this._buttonFlags != 0 ? (this._buttonFlags) : (this._defaultButtonFlag);
            if (_loc_2 & Alert.OK || _loc_2 & Alert.CANCEL || _loc_2 & Alert.YES || _loc_2 & Alert.NO)
            {
                if (_loc_2 & Alert.OK)
                {
                    _loc_3 = new StandardButton();
                    _loc_3.name = "OK";
                    _loc_3.label = _loc_1.IsInitialized() ? (_loc_1.GetText(LOCA_GROUP.LABELS, "OK")) : ("OK");
                    _loc_3.width = 70;
                    _loc_3.height = 32;
                    _loc_3.addEventListener(MouseEvent.CLICK, this.removeAlert);
                    this.buttonsList.addChild(_loc_3);
                }
            }
            if (_loc_2 & Alert.CANCEL)
            {
                _loc_3 = new StandardButton();
                _loc_3.name = "CANCEL";
                _loc_3.label = _loc_1.IsInitialized() ? (_loc_1.GetText(LOCA_GROUP.LABELS, "Cancel")) : ("Cancel");
                _loc_3.width = 70;
                _loc_3.height = 32;
                _loc_3.addEventListener(MouseEvent.CLICK, this.removeAlert);
                this.buttonsList.addChild(_loc_3);
            }
            if (_loc_2 & Alert.YES)
            {
                _loc_3 = new StandardButton();
                _loc_3.name = "YES";
                _loc_3.label = _loc_1.IsInitialized() ? (_loc_1.GetText(LOCA_GROUP.LABELS, "Yes")) : ("Yes");
                _loc_3.width = 70;
                _loc_3.height = 32;
                _loc_3.addEventListener(MouseEvent.CLICK, this.removeAlert);
                this.buttonsList.addChild(_loc_3);
            }
            if (_loc_2 & Alert.NO)
            {
                _loc_3 = new StandardButton();
                _loc_3.name = "NO";
                _loc_3.label = _loc_1.IsInitialized() ? (_loc_1.GetText(LOCA_GROUP.LABELS, "No")) : ("No");
                _loc_3.width = 70;
                _loc_3.height = 32;
                _loc_3.addEventListener(MouseEvent.CLICK, this.removeAlert);
                this.buttonsList.addChild(_loc_3);
            }
            return;
        }// end function

        public function get paymentOrnament() : Image
        {
            return this._715594074paymentOrnament;
        }// end function

        public function set buttonFlags(param1:uint) : void
        {
            this._buttonFlags = param1;
            return;
        }// end function

        public function set paymentOrnament(param1:Image) : void
        {
            var _loc_2:* = this._715594074paymentOrnament;
            if (_loc_2 !== param1)
            {
                this._715594074paymentOrnament = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "paymentOrnament", _loc_2, param1));
            }
            return;
        }// end function

        public function set title(param1:String) : void
        {
            if (_localize && param1.length > 0)
            {
                this._title = cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_TITLES, param1);
            }
            else
            {
                this._title = param1;
            }
            return;
        }// end function

        private function removeAlert(event:MouseEvent) : void
        {
            var _loc_2:* = Button(event.currentTarget).name;
            this.visible = false;
            var _loc_3:* = new CloseEvent(CloseEvent.CLOSE);
            if (_loc_2 == "YES")
            {
                _loc_3.detail = Alert.YES;
            }
            else if (_loc_2 == "NO")
            {
                _loc_3.detail = Alert.NO;
            }
            else if (_loc_2 == "OK")
            {
                _loc_3.detail = Alert.OK;
            }
            else if (_loc_2 == "CANCEL")
            {
                _loc_3.detail = Alert.CANCEL;
            }
            this.dispatchEvent(_loc_3);
            PopUpManager.removePopUp(this);
            return;
        }// end function

        public function get titleLabel() : Label
        {
            return this._1791483012titleLabel;
        }// end function

        public function set defaultButtonFlag(param1:uint) : void
        {
            this._defaultButtonFlag = param1;
            return;
        }// end function

        public function get buttonsList() : HBox
        {
            return this._1742128193buttonsList;
        }// end function

        private static function static_creationCompleteHandler(event:FlexEvent) : void
        {
            if (event.target is IFlexDisplayObject && event.eventPhase == EventPhase.AT_TARGET)
            {
                event.target.removeEventListener(FlexEvent.CREATION_COMPLETE, static_creationCompleteHandler);
                event.target.addButtons();
                event.target.setTexts();
                PopUpManager.centerPopUp(IFlexDisplayObject(event.target));
            }
            return;
        }// end function

        public static function show(param1:String = "", param2:String = "", param3 = null, param4:uint = 4, param5:Sprite = null, param6:Function = null, param7:Class = null, param8:uint = 4, param9:Boolean = true, param10:int = 0) : ResourceAlert
        {
            var _loc_13:ISystemManager = null;
            _resourcesDisplay = param3;
            _localize = param9;
            var _loc_11:* = param4 & Alert.NONMODAL ? (false) : (true);
            if (!param5)
            {
                _loc_13 = ISystemManager(Application.application.systemManager);
                if (_loc_13.useSWFBridge())
                {
                    param5 = Sprite(_loc_13.getSandboxRoot());
                }
                else
                {
                    param5 = Sprite(Application.application);
                }
            }
            var _loc_12:* = new ResourceAlert;
            if (param4 & Alert.OK || param4 & Alert.CANCEL || param4 & Alert.YES || param4 & Alert.NO)
            {
                _loc_12.buttonFlags = param4;
            }
            if (param8 == Alert.OK || param8 == Alert.CANCEL || param8 == Alert.YES || param8 == Alert.NO)
            {
                _loc_12.defaultButtonFlag = param8;
            }
            _loc_12.text = param1;
            _loc_12.title = param2;
            if (param6 != null)
            {
                _loc_12.addEventListener(CloseEvent.CLOSE, param6);
            }
            if (param5 is UIComponent)
            {
                _loc_12.moduleFactory = UIComponent(param5).moduleFactory;
            }
            PopUpManager.addPopUp(_loc_12, param5, _loc_11);
            _loc_12.addEventListener(FlexEvent.CREATION_COMPLETE, static_creationCompleteHandler);
            switch(param10)
            {
                case STYLE_DEFAULT:
                {
                    _loc_12.styleName = "customAlert";
                    _loc_12.paymentOrnament.visible = false;
                    _loc_12.titleLabel.visible = true;
                    _loc_12.width = 300;
                    _loc_12.minHeight = 200;
                    _loc_12.message.width = 250;
                    _loc_12.message.setConstraintValue("left", 25);
                    _loc_12.message.setConstraintValue("top", 40);
                    _loc_12.message.setConstraintValue("bottom", 60);
                    _loc_12.buttonsList.setConstraintValue("bottom", 15);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return _loc_12;
        }// end function

    }
}
