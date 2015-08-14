package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ResourceItemRenderer extends HBox
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1229015684amountLabel:Label;
        private var _384713305resourceIcon:Image;

        public function ResourceItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
            {
                return {height:26, childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon", propertiesFactory:function () : Object
                {
                    return {null:26, height:25};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", stylesFactory:function () : void
                {
                    this.fontWeight = "bold";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.paddingLeft = 0;
                this.paddingTop = 0;
                this.paddingBottom = 0;
                this.horizontalGap = 0;
                this.verticalAlign = "middle";
                return;
            }// end function
            ;
            this.horizontalScrollPolicy = "off";
            this.height = 26;
            this.addEventListener("creationComplete", this.___ResourceItemRenderer_HBox1_creationComplete);
            this.addEventListener("toolTipCreate", this.___ResourceItemRenderer_HBox1_toolTipCreate);
            return;
        }// end function

        public function ___ResourceItemRenderer_HBox1_creationComplete(event:FlexEvent) : void
        {
            this.DisplayData();
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

        public function setLabelColor() : void
        {
            if (!this.amountLabel || !data)
            {
                return;
            }
            if (global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer).HasPlayerResource(data.name_string, data.amount))
            {
                this.amountLabel.setStyle("color", 16777215);
            }
            else
            {
                this.amountLabel.setStyle("color", 16711680);
            }
            return;
        }// end function

        public function ___ResourceItemRenderer_HBox1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function DisplayData(event:Event = null) : void
        {
            if (!data)
            {
                return;
            }
            this.resourceIcon.source = gAssetManager.GetResourceIcon(data.name_string);
            this.amountLabel.text = data.amount;
            toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, data.name_string);
            this.setLabelColor();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (this.resourceIcon && this.amountLabel)
            {
                this.DisplayData();
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

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

    }
}
