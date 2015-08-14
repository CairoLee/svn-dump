package GUI.Components
{
    import Enums.*;
    import GUI.Loca.*;
    import flash.display.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class CustomAlert extends Canvas
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868:Class;
        private var _text:String;
        private var _title:String;
        private var _1791483012titleLabel:Label;
        private var _defaultButtonFlag:uint = 0;
        private var _715594074paymentOrnament:Image;
        private var _1742128193buttonsList:HBox;
        private var _buttonFlags:uint = 0;
        private var _954925063message:Text;
        public static const STYLE_DEFAULT:int = 0;
        private static var _localize:Boolean;
        public static const STYLE_PAYMENT:int = 1;

        public function CustomAlert()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "5";
                    this.top = "0";
                    this.bottom = "0";
                    this.right = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"paymentOrnament", stylesFactory:function () : void
                {
                    this.horizontalCenter = "1";
                    this.top = "-25";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868};
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
                }), new UIComponentDescriptor({type:HBox, id:"buttonsList", stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868 = CustomAlert__embed_mxml_____data_src_gfx_embedded_alert_alert_payment_ornament_png_1899063868;
            mx_internal::_document = this;
            this.clipContent = false;
            this.cacheAsBitmap = true;
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

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function set text(param1:String) : void
        {
            if (_localize)
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
            this.titleLabel.text = this._title;
            this.message.text = this._text;
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

        public static function show(param1:String = "", param2:String = "", param3:uint = 4, param4:Sprite = null, param5:Function = null, param6:Class = null, param7:uint = 4, param8:Boolean = true, param9:int = 0) : CustomAlert
        {
            var _loc_12:ISystemManager = null;
            _localize = param8;
            var _loc_10:* = param3 & Alert.NONMODAL ? (false) : (true);
            if (!param4)
            {
                _loc_12 = ISystemManager(Application.application.systemManager);
                if (_loc_12.useSWFBridge())
                {
                    param4 = Sprite(_loc_12.getSandboxRoot());
                }
                else
                {
                    param4 = Sprite(Application.application);
                }
            }
            var _loc_11:* = new CustomAlert;
            if (param3 & Alert.OK || param3 & Alert.CANCEL || param3 & Alert.YES || param3 & Alert.NO)
            {
                _loc_11.buttonFlags = param3;
            }
            if (param7 == Alert.OK || param7 == Alert.CANCEL || param7 == Alert.YES || param7 == Alert.NO)
            {
                _loc_11.defaultButtonFlag = param7;
            }
            _loc_11.text = param1;
            _loc_11.title = param2;
            if (param5 != null)
            {
                _loc_11.addEventListener(CloseEvent.CLOSE, param5);
            }
            if (param4 is UIComponent)
            {
                _loc_11.moduleFactory = UIComponent(param4).moduleFactory;
            }
            PopUpManager.addPopUp(_loc_11, param4, _loc_10);
            _loc_11.addEventListener(FlexEvent.CREATION_COMPLETE, static_creationCompleteHandler);
            switch(param9)
            {
                case CustomAlert.STYLE_DEFAULT:
                {
                    _loc_11.styleName = "customAlert";
                    _loc_11.paymentOrnament.visible = false;
                    _loc_11.titleLabel.visible = true;
                    _loc_11.width = 300;
                    _loc_11.minHeight = 150;
                    _loc_11.message.width = 250;
                    _loc_11.message.setConstraintValue("left", 25);
                    _loc_11.message.setConstraintValue("top", 40);
                    _loc_11.message.setConstraintValue("bottom", 60);
                    _loc_11.buttonsList.setConstraintValue("bottom", 15);
                    break;
                }
                case CustomAlert.STYLE_PAYMENT:
                {
                    _loc_11.styleName = "paymentAlert";
                    _loc_11.paymentOrnament.visible = true;
                    _loc_11.titleLabel.visible = false;
                    _loc_11.width = 230;
                    _loc_11.minHeight = 100;
                    _loc_11.message.width = 210;
                    _loc_11.message.setConstraintValue("left", 10);
                    _loc_11.message.setConstraintValue("top", 27);
                    _loc_11.message.setConstraintValue("bottom", 55);
                    _loc_11.buttonsList.setConstraintValue("bottom", 10);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return _loc_11;
        }// end function

    }
}
