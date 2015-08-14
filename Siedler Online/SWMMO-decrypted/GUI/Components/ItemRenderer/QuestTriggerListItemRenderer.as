package GUI.Components.ItemRenderer
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import NewQuestSystem.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class QuestTriggerListItemRenderer extends Canvas implements IBindingClient
    {
        private var _110371416title:Text;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _157439105passedIndicator:Image;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_icon_bg_png_849874530:Class;
        private var _100313435image:Image;
        private var _156058660resourceBackground:Image;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function QuestTriggerListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:54, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.backgroundColor = 8220759;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"resourceBackground", stylesFactory:function () : void
                {
                    this.left = "11";
                    this.verticalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:36, height:36, source:_embed_mxml_____data_src_gfx_embedded_quest_quest_icon_bg_png_849874530};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"image", stylesFactory:function () : void
                {
                    null.left = this;
                    this.verticalCenter = "-1";
                    this.horizontalAlign = "center";
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:59, height:51, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"passedIndicator", stylesFactory:function () : void
                {
                    this.right = "0";
                    this.verticalCenter = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Text, id:"title", events:{toolTipCreate:"__title_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "45";
                    this.verticalCenter = "0";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {selectable:false};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_icon_bg_png_849874530 = QuestTriggerListItemRenderer__embed_mxml_____data_src_gfx_embedded_quest_quest_icon_bg_png_849874530;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.height = 54;
            this.verticalScrollPolicy = "off";
            this.horizontalScrollPolicy = "off";
            this.addEventListener("toolTipCreate", this.___QuestTriggerListItemRenderer_Canvas1_toolTipCreate);
            return;
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

        public function set resourceBackground(param1:Image) : void
        {
            var _loc_2:* = this._156058660resourceBackground;
            if (_loc_2 !== param1)
            {
                this._156058660resourceBackground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceBackground", _loc_2, param1));
            }
            return;
        }// end function

        public function get title() : Text
        {
            return this._110371416title;
        }// end function

        override public function initialize() : void
        {
            var target:QuestTriggerListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._QuestTriggerListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_QuestTriggerListItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return target[param1];
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

        private function _QuestTriggerListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "passedIndicator.source");
            result[0] = binding;
            return result;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (param1 == null)
            {
                return;
            }
            var _loc_2:* = param1.trigger as dQuestTriggerVO;
            var _loc_3:* = param1.definition as dQuestDefinitionTriggerVO;
            this.image.source = gAssetManager.GetQuestTriggerIcon(_loc_3);
            var _loc_4:* = param1.total - Math.max(0, param1.remaining);
            if (_loc_3.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
            {
                this.passedIndicator.visible = _loc_4 == param1.total;
            }
            else
            {
                this.passedIndicator.visible = _loc_2 && _loc_2.status > 0;
            }
            this.title.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.QUEST_TRIGGERS, _loc_3.toString(), [_loc_4.toString(), param1.total.toString()]);
            this.resourceBackground.visible = _loc_3.type == QuestManagerStatic.TYPE_RESOURCE || _loc_3.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH;
            this.title.invalidateSize();
            this.title.validateNow();
            return;
        }// end function

        public function get resourceBackground() : Image
        {
            return this._156058660resourceBackground;
        }// end function

        private function _QuestTriggerListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("DailyLoginPassed");
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function ___QuestTriggerListItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set title(param1:Text) : void
        {
            var _loc_2:* = this._110371416title;
            if (_loc_2 !== param1)
            {
                this._110371416title = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "title", _loc_2, param1));
            }
            return;
        }// end function

        public function __title_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set passedIndicator(param1:Image) : void
        {
            var _loc_2:* = this._157439105passedIndicator;
            if (_loc_2 !== param1)
            {
                this._157439105passedIndicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "passedIndicator", _loc_2, param1));
            }
            return;
        }// end function

        public function get passedIndicator() : Image
        {
            return this._157439105passedIndicator;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
