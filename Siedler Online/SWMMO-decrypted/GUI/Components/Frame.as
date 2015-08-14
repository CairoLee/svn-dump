package GUI.Components
{
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class Frame extends Canvas
    {
        private var _contentType:String = "normal";
        private var _type:String;
        private var _291050514frameImage:Image;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1229015684amountLabel:Label;
        private var _content:String;
        private var _267185744framedIcon:Image;
        private var _amount:int = -1;
        public static const DAILY_LOGIN:String = "dailyLogin";
        public static const CONTENT_TYPE_SHOPITEM:String = "shopitem";
        public static const BUFF_TIMED:String = "buffTimed";
        public static const EMPTY:String = "empty";
        public static const BUFF_UPGRADE:String = "buffUpgrafe";
        public static const SPECIALIST:String = "specialist";
        public static const DAILY_LOGIN_LAST:String = "dailyLoginLast";
        public static const CONTENT_TYPE_RESOURCE:String = "resource";
        public static const BUFF_INSTANT:String = "buffInstant";
        public static const CONTENT_TYPE_ADVENTURE:String = "adventure";
        public static const CONTENT_TYPE_BUFF:String = "buff";
        public static const CONTENT_TYPE_NORMAL:String = "normal";

        public function Frame()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:56, height:70, childDescriptors:[new UIComponentDescriptor({type:Image, id:"frameImage"}), new UIComponentDescriptor({type:Image, id:"framedIcon", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.verticalCenter = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", events:{toolTipCreate:"__amountLabel_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.textAlign = "center";
                    this.bottom = "10";
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:50};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.width = 56;
            this.height = 70;
            this.addEventListener("creationComplete", this.___Frame_Canvas1_creationComplete);
            return;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

        public function Clear() : void
        {
            this._contentType = Frame.CONTENT_TYPE_NORMAL;
            this._content = "";
            this.type = Frame.EMPTY;
            this.amount = -1;
            this.framedIcon.source = null;
            this.Init();
            return;
        }// end function

        private function DisplayContent() : void
        {
            if (this.framedIcon && this._content)
            {
                switch(this._contentType)
                {
                    case Frame.CONTENT_TYPE_RESOURCE:
                    {
                        this.framedIcon.setStyle("verticalCenter", this._amount > -1 ? (-10) : (0));
                        this.framedIcon.source = gAssetManager.GetResourceIcon(this._content);
                        break;
                    }
                    case Frame.CONTENT_TYPE_SHOPITEM:
                    {
                        this.framedIcon.source = gAssetManager.GetShopIcon(this._content);
                        break;
                    }
                    case Frame.CONTENT_TYPE_ADVENTURE:
                    {
                        this.framedIcon.source = gAssetManager.GetBuffIcon(this._content);
                        break;
                    }
                    case Frame.CONTENT_TYPE_ADVENTURE:
                    case Frame.CONTENT_TYPE_BUFF:
                    {
                        this.framedIcon.source = gAssetManager.GetBuffIcon(this._content);
                        break;
                    }
                    default:
                    {
                        this.framedIcon.source = gAssetManager.GetBitmap(this._content);
                        break;
                    }
                }
            }
            if (this.frameImage)
            {
                switch(this._type)
                {
                    case Frame.SPECIALIST:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameSpecialist");
                        break;
                    }
                    case Frame.BUFF_INSTANT:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameBuffInstant");
                        break;
                    }
                    case Frame.BUFF_TIMED:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameBuffTimed");
                        break;
                    }
                    case Frame.BUFF_UPGRADE:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameBuffUpgrade");
                        break;
                    }
                    case Frame.DAILY_LOGIN:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameDailyLogin");
                        break;
                    }
                    case Frame.DAILY_LOGIN_LAST:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("FrameDailyLoginLast");
                        break;
                    }
                    default:
                    {
                        this.frameImage.source = gAssetManager.GetBitmap("StarmenuFrameEmpty");
                        break;
                    }
                }
            }
            if (!this.amountLabel)
            {
                return;
            }
            if (this._amount > -1)
            {
                this.amountLabel.text = this._amount.toString();
                this.amountLabel.visible = true;
            }
            else
            {
                this.amountLabel.visible = false;
            }
            return;
        }// end function

        public function get framedIcon() : Image
        {
            return this._267185744framedIcon;
        }// end function

        public function get type() : String
        {
            return this._type;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get contentType() : String
        {
            return this._contentType;
        }// end function

        public function get amount() : int
        {
            return this._amount;
        }// end function

        public function __amountLabel_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set framedIcon(param1:Image) : void
        {
            var _loc_2:* = this._267185744framedIcon;
            if (_loc_2 !== param1)
            {
                this._267185744framedIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "framedIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set frameImage(param1:Image) : void
        {
            var _loc_2:* = this._291050514frameImage;
            if (_loc_2 !== param1)
            {
                this._291050514frameImage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "frameImage", _loc_2, param1));
            }
            return;
        }// end function

        public function set contentType(param1:String) : void
        {
            this._contentType = param1;
            this.DisplayContent();
            return;
        }// end function

        public function ___Frame_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.Init();
            return;
        }// end function

        public function set amount(param1:int) : void
        {
            this._amount = param1;
            this.DisplayContent();
            return;
        }// end function

        public function set content(param1:String) : void
        {
            this._content = param1;
            this.DisplayContent();
            return;
        }// end function

        public function set amountLabel(param1:Label) : void
        {
            var _loc_2:* = this._1229015684amountLabel;
            if (_loc_2 !== param1)
            {
                this._1229015684amountLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "amountLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get content() : String
        {
            return this._content;
        }// end function

        public function set type(param1:String) : void
        {
            this._type = param1;
            this.DisplayContent();
            return;
        }// end function

        public function get frameImage() : Image
        {
            return this._291050514frameImage;
        }// end function

        private function Init() : void
        {
            if (!this._type)
            {
                this.type = Frame.EMPTY;
            }
            this.DisplayContent();
            return;
        }// end function

    }
}
