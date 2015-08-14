package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class WarehouseDetailsItemRenderer extends Canvas
    {
        private var _384713305resourceIcon:Image;
        private var useRollOver:Boolean = false;
        private var _1923613447capacityBar:Canvas;
        private var _67824454capacity:Canvas;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1229015684amountLabel:Label;

        public function WarehouseDetailsItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:80, height:40, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"capacity", stylesFactory:function () : void
                {
                    this.borderStyle = "solid";
                    this.borderThickness = 1;
                    this.borderColor = 9535066;
                    this.backgroundColor = 4470822;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {width:8, height:33, x:2, y:2, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"capacityBar", stylesFactory:function () : void
                    {
                        this.backgroundColor = 8880699;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:6};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"resourceIcon"}), new UIComponentDescriptor({type:Label, id:"amountLabel", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    this.left = "15";
                    this.right = "6";
                    this.verticalCenter = "-1";
                    this.textAlign = "right";
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
                null.paddingLeft = this;
                this.paddingRight = 5;
                this.backgroundAlpha = 1;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.width = 80;
            this.height = 40;
            this.addEventListener("creationComplete", this.___WarehouseDetailsItemRenderer_Canvas1_creationComplete);
            this.addEventListener("rollOver", this.___WarehouseDetailsItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___WarehouseDetailsItemRenderer_Canvas1_rollOut);
            this.addEventListener("toolTipCreate", this.___WarehouseDetailsItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function ___WarehouseDetailsItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.RollOut();
            return;
        }// end function

        public function get capacity() : Canvas
        {
            return this._67824454capacity;
        }// end function

        public function set capacityBar(param1:Canvas) : void
        {
            var _loc_2:* = this._1923613447capacityBar;
            if (_loc_2 !== param1)
            {
                this._1923613447capacityBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "capacityBar", _loc_2, param1));
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

        private function FormatAmount(param1:Number) : String
        {
            if (param1 > 999)
            {
                return Math.floor(param1 / 1000).toString() + "k";
            }
            return param1.toString();
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        private function RollOver() : void
        {
            if (this.useRollOver)
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundHighlight"));
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            this.useRollOver = this.parentDocument is TradingPanel || this.parentDocument is ResidenceInfoPanel || this.parentDocument is WarehouseInfoPanel;
            if (this.parentDocument is EnemyBuildingInfoPanel)
            {
                width = 80;
                height = 68;
                this.resourceIcon.setConstraintValue("left", 0);
                this.resourceIcon.setConstraintValue("top", 0);
                toolTip = data.name_string;
            }
            else
            {
                width = 80;
                height = 40;
                this.resourceIcon.setConstraintValue("left", 12);
                this.resourceIcon.setConstraintValue("top", 6);
                toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, data.name_string);
                if (data.amount > -1)
                {
                    toolTip = toolTip + (": " + Math.floor(data.amount) + (isNaN(data.maxLimit) || data.maxLimit == 0 ? ("") : ("/" + Math.floor(data.maxLimit))));
                }
            }
            var _loc_4:* = !isNaN(data.maxLimit) && data.amount > -1 && data.maxLimit > 0;
            this.capacity.visible = !isNaN(data.maxLimit) && data.amount > -1 && data.maxLimit > 0;
            this.capacityBar.visible = _loc_4;
            var _loc_2:* = Math.floor(data.amount) / data.maxLimit;
            var _loc_3:* = 33 * _loc_2;
            this.capacityBar.height = _loc_3;
            this.capacityBar.y = 33 - _loc_3;
            this.amountLabel.visible = data.amount > -1;
            this.amountLabel.text = this.FormatAmount(Math.floor(data.amount));
            if (this.parentDocument is EnemyBuildingInfoPanel)
            {
                this.resourceIcon.source = gAssetManager.GetMilitaryIcon(data.name_string);
            }
            else
            {
                this.resourceIcon.source = gAssetManager.GetResourceIcon(data.name_string);
            }
            return;
        }// end function

        private function ToolTipCreate(event:ToolTipEvent) : void
        {
            if (this.parentDocument is EnemyBuildingInfoPanel)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MILITARY_UNIT_EXTENDED_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            }
            return;
        }// end function

        public function ___WarehouseDetailsItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.RollOver();
            return;
        }// end function

        public function get resourceIcon() : Image
        {
            return this._384713305resourceIcon;
        }// end function

        public function ___WarehouseDetailsItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundNormal"));
            return;
        }// end function

        private function RollOut() : void
        {
            if (this.useRollOver)
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundNormal"));
            }
            return;
        }// end function

        public function set capacity(param1:Canvas) : void
        {
            var _loc_2:* = this._67824454capacity;
            if (_loc_2 !== param1)
            {
                this._67824454capacity = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "capacity", _loc_2, param1));
            }
            return;
        }// end function

        public function ___WarehouseDetailsItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            this.ToolTipCreate(event);
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

        public function get capacityBar() : Canvas
        {
            return this._1923613447capacityBar;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

    }
}
