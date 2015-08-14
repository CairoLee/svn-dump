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

    public class ResourceIconRenderer extends Canvas
    {
        private var _buffed:int;
        private var _resourceName:String;
        private var _1984457027foreground:Image;
        private var _missing:Boolean;
        private var _100313435image:Image;
        private var _1332194002background:Image;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _active:Boolean = true;
        public static const BUFFED_NONE:int = 0;
        public static const BUFFED_POSITIVE:int = 1;
        public static const BUFFED_NEGATIVE:int = -1;

        public function ResourceIconRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:37, height:37, childDescriptors:[new UIComponentDescriptor({type:Image, id:"background"}), new UIComponentDescriptor({type:Image, id:"image", propertiesFactory:function () : Object
                {
                    return {null:null, y:6};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"foreground"})]};
            }// end function
            });
            mx_internal::_document = this;
            this.width = 37;
            this.height = 37;
            this.addEventListener("creationComplete", this.___ResourceIconRenderer_Canvas1_creationComplete);
            this.addEventListener("toolTipCreate", this.___ResourceIconRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function get foreground() : Image
        {
            return this._1984457027foreground;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public function set foreground(param1:Image) : void
        {
            var _loc_2:* = this._1984457027foreground;
            if (_loc_2 !== param1)
            {
                this._1984457027foreground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "foreground", _loc_2, param1));
            }
            return;
        }// end function

        public function set active(param1:Boolean) : void
        {
            this._active = param1;
            this.updateIcon();
            return;
        }// end function

        public function clear() : void
        {
            this.image.source = null;
            this.background.source = null;
            this.foreground.source = null;
            return;
        }// end function

        public function set missing(param1:Boolean) : void
        {
            this._missing = param1;
            this.updateIcon();
            return;
        }// end function

        public function ___ResourceIconRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.updateIcon();
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function set background(param1:Image) : void
        {
            var _loc_2:* = this._1332194002background;
            if (_loc_2 !== param1)
            {
                this._1332194002background = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "background", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function ___ResourceIconRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set buffed(param1:int) : void
        {
            this._buffed = param1;
            this.updateIcon();
            return;
        }// end function

        private function updateIcon() : void
        {
            if (this.image && this._resourceName)
            {
                this.image.source = gAssetManager.GetResourceIcon(this._resourceName, this._active);
                if (this._missing)
                {
                    this.background.source = gAssetManager.GetBitmap("InputMissingBackground");
                    this.foreground.source = gAssetManager.GetBitmap("InputMissingForeground");
                    this.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InputResourceMissing", [this._resourceName]);
                }
                else if (this._buffed == BUFFED_POSITIVE)
                {
                    this.background.source = gAssetManager.GetBitmap("OutputBuffedBackground");
                    this.foreground.source = gAssetManager.GetBitmap("OutputBuffedForeground");
                    this.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OutputResourceBuffed", [this._resourceName]);
                }
                else if (this._buffed == BUFFED_NEGATIVE)
                {
                    this.background.source = gAssetManager.GetBitmap("InputMissingBackground");
                    this.foreground.source = gAssetManager.GetBitmap("OutputBuffedForeground");
                    this.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OutputResourceBuffedNegative", [this._resourceName]);
                }
                else
                {
                    this.background.source = null;
                    this.foreground.source = null;
                    this.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this._resourceName);
                }
            }
            return;
        }// end function

        public function get background() : Image
        {
            return this._1332194002background;
        }// end function

        public function set resourceName(param1:String) : void
        {
            this._resourceName = param1;
            this.updateIcon();
            return;
        }// end function

    }
}
