package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import MilitarySystem.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class TimedProductionTypeItemRenderer extends Canvas
    {
        private var _293001187unitIcon:Image;
        private var itemEnabled:Boolean;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function TimedProductionTypeItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:45, height:43, childDescriptors:[new UIComponentDescriptor({type:Image, id:"unitIcon", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.verticalCenter = "0";
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
                this.backgroundAlpha = 1;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.width = 45;
            this.height = 43;
            this.addEventListener("creationComplete", this.___TimedProductionTypeItemRenderer_Canvas1_creationComplete);
            this.addEventListener("rollOver", this.___TimedProductionTypeItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___TimedProductionTypeItemRenderer_Canvas1_rollOut);
            this.addEventListener("toolTipCreate", this.___TimedProductionTypeItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function ___TimedProductionTypeItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            this.CreateTooltip(event);
            return;
        }// end function

        public function ___TimedProductionTypeItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundNormal"));
            return;
        }// end function

        private function CreateTooltip(event:ToolTipEvent) : void
        {
            if (this.itemEnabled)
            {
                if (data is cMilitaryUnitDescription)
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.MILITARY_UNIT_EXTENDED_string, event);
                }
                else
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.BUFF_string, event, data);
                }
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function ___TimedProductionTypeItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundNormal"));
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function ___TimedProductionTypeItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("BackgroundHighlight"));
            return;
        }// end function

        public function set unitIcon(param1:Image) : void
        {
            var _loc_2:* = this._293001187unitIcon;
            if (_loc_2 !== param1)
            {
                this._293001187unitIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "unitIcon", _loc_2, param1));
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            this.itemEnabled = data.GetPlayerLevel() <= global.ui.mCurrentPlayer.GetPlayerLevel();
            this.unitIcon.source = gAssetManager.GetResourceIcon(data.GetType_string(), this.itemEnabled);
            if (this.itemEnabled)
            {
                toolTip = data.GetType_string();
            }
            else
            {
                toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [data.GetPlayerLevel().toString()]);
            }
            return;
        }// end function

        public function get unitIcon() : Image
        {
            return this._293001187unitIcon;
        }// end function

    }
}
