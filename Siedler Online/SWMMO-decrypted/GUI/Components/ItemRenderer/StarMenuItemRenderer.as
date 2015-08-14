package GUI.Components.ItemRenderer
{
    import BuffSystem.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.GAME.*;
    import GUI.Loca.*;
    import Specialists.*;
    import flash.display.*;
    import flash.events.*;
    import flash.filters.*;
    import flash.geom.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.utils.*;

    public class StarMenuItemRenderer extends Canvas implements IBindingClient
    {
        private var _1521931444bufficon:Image;
        private var _gem:BitmapData;
        private var _384713305resourceIcon:Image;
        var _watchers:Array;
        private var _1229015684amountLabel:Label;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _97692013frame:Frame;
        private var _1098237725removeIcon:RemoveBuffButton;
        private var _377281308dataProxy:ObjectProxy;
        var _bindings:Array;
        private var _1001078227progress:ProgressBar;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function StarMenuItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:56, height:70, childDescriptors:[new UIComponentDescriptor({type:Frame, id:"frame"}), new UIComponentDescriptor({type:Image, id:"bufficon", stylesFactory:function () : void
                {
                    this.horizontalAlign = "center";
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, percentHeight:100, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"resourceIcon", stylesFactory:function () : void
                {
                    null.horizontalAlign = this;
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, percentHeight:100, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:RemoveBuffButton, id:"removeIcon", events:{click:"__removeIcon_click"}, stylesFactory:function () : void
                {
                    this.top = "5";
                    this.right = "5";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:ProgressBar, id:"progress", stylesFactory:function () : void
                {
                    this.left = "8";
                    this.right = "8";
                    this.bottom = "10";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", events:{toolTipCreate:"__amountLabel_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.textAlign = "center";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                })]};
            }// end function
            });
            this._377281308dataProxy = new ObjectProxy();
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 56;
            this.height = 70;
            this.addEventListener("toolTipCreate", this.___StarMenuItemRenderer_Canvas1_toolTipCreate);
            this.addEventListener("click", this.___StarMenuItemRenderer_Canvas1_click);
            return;
        }// end function

        protected function onMouseOutIcon(event:Event) : void
        {
            this.bufficon.filters = [];
            return;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

        private function deleteIconClickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = new ItemClickEvent(cStarMenu.CLICK_DELETE_BUTTON, true);
            _loc_2.item = data;
            this.dispatchEvent(_loc_2);
            return;
        }// end function

        private function addGemIcon(param1:BitmapData) : void
        {
            param1.copyPixels(this._gem, this._gem.rect, new Point(3, 2), null, null, true);
            return;
        }// end function

        public function ___StarMenuItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.useItemClickHandler(event);
            return;
        }// end function

        protected function onMouseOverIcon(event:Event) : void
        {
            this.bufficon.filters = [new GlowFilter(16777130)];
            return;
        }// end function

        override public function initialize() : void
        {
            var target:StarMenuItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._StarMenuItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_StarMenuItemRendererWatcherSetupUtil");
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

        private function Display(event:Event = null) : void
        {
            var _loc_2:cSpecialist = null;
            var _loc_3:Bitmap = null;
            var _loc_4:Boolean = false;
            var _loc_5:cBuff = null;
            var _loc_6:String = null;
            this.removeEventListener(FlexEvent.CREATION_COMPLETE, this.Display);
            if (data != null)
            {
                this.amountLabel.visible = false;
                this.resourceIcon.visible = false;
                this.removeIcon.visible = false;
                if (this.hasEventListener(MouseEvent.MOUSE_OVER))
                {
                    this.removeEventListener(MouseEvent.MOUSE_OVER, this.onMouseOverIcon);
                    this.removeEventListener(MouseEvent.MOUSE_OUT, this.onMouseOutIcon);
                }
                if (data is cSpecialist)
                {
                    this.frame.type = Frame.SPECIALIST;
                    this.bufficon.visible = true;
                    _loc_2 = data as cSpecialist;
                    toolTip = SPECIALIST_TYPE.toString(_loc_2.GetType());
                    _loc_3 = gAssetManager.GetBitmap("Icon" + SPECIALIST_TYPE.toString(_loc_2.GetType()), !_loc_2.IsInUse());
                    _loc_4 = false;
                    switch(_loc_2.GetBaseType())
                    {
                        case SPECIALIST_TYPE.GENERAL:
                        case SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER:
                        {
                            _loc_4 = true;
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    if (_loc_2.IsInUse() && !_loc_4)
                    {
                        this.addGemIcon(_loc_3.bitmapData);
                        this.addEventListener(MouseEvent.MOUSE_OVER, this.onMouseOverIcon);
                        this.addEventListener(MouseEvent.MOUSE_OUT, this.onMouseOutIcon);
                    }
                    this.dataProxy.icon = _loc_3;
                    this.progress.visible = _loc_2.DisplayTaskProgress();
                    if (_loc_2.GetTask())
                    {
                        this.dataProxy.progress = _loc_2.GetTaskProgress();
                    }
                }
                else if (data is cBuff)
                {
                    _loc_5 = data as cBuff;
                    if (_loc_5.GetType_string() == "Adventure")
                    {
                        toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, _loc_5.GetResourceName_string());
                    }
                    else
                    {
                        toolTip = _loc_5.GetType_string();
                    }
                    switch(_loc_5.GetBuffDefinition().GetBuffType())
                    {
                        case BUFF_TYPE.INSTANT:
                        {
                            this.frame.type = Frame.BUFF_INSTANT;
                            break;
                        }
                        case BUFF_TYPE.TIMED:
                        {
                            this.frame.type = Frame.BUFF_TIMED;
                            break;
                        }
                        case BUFF_TYPE.UPGRADE:
                        {
                            this.frame.type = Frame.BUFF_UPGRADE;
                            break;
                        }
                        case BUFF_TYPE.ZONE:
                        {
                            this.frame.type = Frame.BUFF_TIMED;
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    this.progress.visible = false;
                    _loc_6 = _loc_5.GetType_string();
                    if (_loc_6.indexOf("AddResource") > -1 || _loc_6.indexOf("FillDeposit") > -1)
                    {
                        if (_loc_5.GetResourceName_string() != "")
                        {
                            this.resourceIcon.visible = true;
                            this.dataProxy.resourceIcon = gAssetManager.GetResourceIcon(_loc_5.GetResourceName_string(), !_loc_5.GetWaitingForServer());
                        }
                        else
                        {
                            this.resourceIcon.visible = false;
                        }
                        this.amountLabel.visible = true;
                        this.amountLabel.text = _loc_5.GetRemaining().toString();
                        this.bufficon.visible = true;
                        this.dataProxy.icon = gAssetManager.GetBuffIcon(_loc_5.GetType_string(), !_loc_5.GetWaitingForServer());
                    }
                    else if (_loc_6 == "BuildBuilding")
                    {
                        this.resourceIcon.visible = true;
                        this.dataProxy.resourceIcon = gAssetManager.GetBuildingIcon(_loc_5.GetResourceName_string(), !_loc_5.GetWaitingForServer());
                        this.bufficon.visible = false;
                    }
                    else if (_loc_6 == "Adventure")
                    {
                        this.bufficon.visible = true;
                        this.dataProxy.icon = gAssetManager.GetBuffIcon(_loc_5.GetResourceName_string(), !_loc_5.GetWaitingForServer());
                    }
                    else
                    {
                        this.bufficon.visible = true;
                        if (_loc_5.GetCount() > 0)
                        {
                            this.amountLabel.visible = true;
                            this.amountLabel.text = _loc_5.GetCount() - _loc_5.GetWaitingForServerCount() + "";
                        }
                        this.dataProxy.icon = gAssetManager.GetBuffIcon(_loc_5.GetType_string(), !_loc_5.GetWaitingForServer());
                    }
                    if (_loc_5.IsDeletable())
                    {
                        this.removeIcon.visible = true;
                    }
                }
            }
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        public function get removeIcon() : RemoveBuffButton
        {
            return this._1098237725removeIcon;
        }// end function

        public function set bufficon(param1:Image) : void
        {
            var _loc_2:* = this._1521931444bufficon;
            if (_loc_2 !== param1)
            {
                this._1521931444bufficon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bufficon", _loc_2, param1));
            }
            return;
        }// end function

        public function get progress() : ProgressBar
        {
            return this._1001078227progress;
        }// end function

        private function CreateToolTip(event:ToolTipEvent) : void
        {
            if (data is cBuff)
            {
                if ((data as cBuff).GetType_string() == "Adventure")
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
                }
                else
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.BUFF_string, event, data);
                }
            }
            else if (data is cSpecialist)
            {
                if ((data as cSpecialist).GetBaseType() == SPECIALIST_TYPE.GENERAL)
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.SEND_ARMY, event, data);
                }
                else
                {
                    cToolTipUtil.createToolTip(cToolTipUtil.SPECIALIST_string, event, data);
                }
            }
            return;
        }// end function

        public function get resourceIcon() : Image
        {
            return this._384713305resourceIcon;
        }// end function

        public function set removeIcon(param1:RemoveBuffButton) : void
        {
            var _loc_2:* = this._1098237725removeIcon;
            if (_loc_2 !== param1)
            {
                this._1098237725removeIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "removeIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function __removeIcon_click(event:MouseEvent) : void
        {
            this.deleteIconClickHandler(event);
            return;
        }// end function

        public function ___StarMenuItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            this.CreateToolTip(event);
            return;
        }// end function

        private function set dataProxy(param1:ObjectProxy) : void
        {
            var _loc_2:* = this._377281308dataProxy;
            if (_loc_2 !== param1)
            {
                this._377281308dataProxy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "dataProxy", _loc_2, param1));
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

        private function _StarMenuItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.dataProxy.icon;
            _loc_1 = this.dataProxy.resourceIcon;
            _loc_1 = this.dataProxy.progress;
            return;
        }// end function

        public function get bufficon() : Image
        {
            return this._1521931444bufficon;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            this._gem = gAssetManager.GetBitmap("SmallIconHardCurrency").bitmapData;
            if (this.amountLabel && this.resourceIcon && this.frame)
            {
                this.Display();
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.Display);
            }
            return;
        }// end function

        public function set frame(param1:Frame) : void
        {
            var _loc_2:* = this._97692013frame;
            if (_loc_2 !== param1)
            {
                this._97692013frame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "frame", _loc_2, param1));
            }
            return;
        }// end function

        public function __amountLabel_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set progress(param1:ProgressBar) : void
        {
            var _loc_2:* = this._1001078227progress;
            if (_loc_2 !== param1)
            {
                this._1001078227progress = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progress", _loc_2, param1));
            }
            return;
        }// end function

        private function get dataProxy() : ObjectProxy
        {
            return this._377281308dataProxy;
        }// end function

        public function get frame() : Frame
        {
            return this._97692013frame;
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

        private function useItemClickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = new ItemClickEvent(cStarMenu.CLICK_ITEM, true);
            _loc_2.item = data;
            this.dispatchEvent(_loc_2);
            return;
        }// end function

        private function _StarMenuItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return dataProxy.icon;
            }// end function
            , function (param1:Object) : void
            {
                bufficon.source = param1;
                return;
            }// end function
            , "bufficon.source");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return dataProxy.resourceIcon;
            }// end function
            , function (param1:Object) : void
            {
                resourceIcon.source = param1;
                return;
            }// end function
            , "resourceIcon.source");
            result[1] = binding;
            binding = new Binding(this, function () : Number
            {
                return dataProxy.progress;
            }// end function
            , function (param1:Number) : void
            {
                progress.value = param1;
                return;
            }// end function
            , "progress.value");
            result[2] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            StarMenuItemRenderer._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
