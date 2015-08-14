package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class OrderCostsItemRenderer extends Canvas
    {
        private var _384713305resourceIcon:Image;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1229015684amountLabel:Label;
        private var resourceName:String;
        private var _1031442328totalAmountLabel:Label;

        public function OrderCostsItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:50, height:60, childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:25};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", stylesFactory:function () : void
                {
                    this.top = "24";
                    this.color = 16777215;
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "normal";
                    this.textAlign = "center";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"totalAmountLabel", stylesFactory:function () : void
                {
                    this.top = "41";
                    this.color = 16777215;
                    this.left = "5";
                    this.right = "5";
                    this.horizontalCenter = "0";
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 50;
            this.height = 60;
            this.addEventListener("toolTipCreate", this.___OrderCostsItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function ___OrderCostsItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set totalAmountLabel(param1:Label) : void
        {
            var _loc_2:* = this._1031442328totalAmountLabel;
            if (_loc_2 !== param1)
            {
                this._1031442328totalAmountLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "totalAmountLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceIcon() : Image
        {
            return this._384713305resourceIcon;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            this.resourceIcon.source = gAssetManager.GetResourceIcon(data.resource.name_string);
            this.amountLabel.text = data.resource.amount;
            this.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, data.resource.name_string);
            this.totalAmountLabel.text = String(data.resource.amount * data.amount);
            if (data.canAfford)
            {
                this.totalAmountLabel.setStyle("color", 16777215);
            }
            else
            {
                this.totalAmountLabel.setStyle("color", 16711680);
            }
            return;
        }// end function

        public function set resourceIcon(param1:Image) : void
        {
            var _loc_2:* = this._384713305resourceIcon;
            if (_loc_2 !== param1)
            {
                this._384713305resourceIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon", _loc_2, param1));
            }
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

        public function get totalAmountLabel() : Label
        {
            return this._1031442328totalAmountLabel;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

    }
}
