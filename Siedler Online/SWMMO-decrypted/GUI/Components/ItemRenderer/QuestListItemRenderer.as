package GUI.Components.ItemRenderer
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Events.*;
    import GUI.Loca.*;
    import NewQuestSystem.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class QuestListItemRenderer extends Canvas implements IBindingClient
    {
        private var lm:cLocaManager;
        var _watchers:Array;
        private var _1410965406iconImage:Bitmap;
        private var _730196261trackable:Boolean;
        private var _1067395286tracked:Boolean;
        private var _607740351labelText:String;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _97692013frame:Canvas;
        private var _finished:Boolean = false;
        private var _555276332cbTrack:StandardCheckBox;
        private var _106934lbl:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_button_ornametal_png_1638345846:Class;
        private var _selected:Boolean = false;
        public var _QuestListItemRenderer_Image1:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function QuestListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {height:29, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"frame", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "-11";
                    this.top = "-4";
                    this.backgroundSize = "100%";
                    this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_quest_quest_button_ornametal_png_1638345846;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false, height:36};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_QuestListItemRenderer_Image1", stylesFactory:function () : void
                {
                    this.left = "0";
                    this.verticalCenter = "-1";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"lbl", events:{toolTipCreate:"__lbl_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.left = "24";
                    this.verticalCenter = "-2";
                    this.fontWeight = "bold";
                    this.color = 1643018;
                    this.textAlign = "left";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:102};
                }// end function
                }), new UIComponentDescriptor({type:StandardCheckBox, id:"cbTrack", events:{click:"__cbTrack_click"}, stylesFactory:function () : void
                {
                    null.verticalCenter = this;
                    this.right = "6";
                    return;
                }// end function
                })]};
            }// end function
            });
            this.lm = cLocaManager.GetInstance();
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_button_ornametal_png_1638345846 = QuestListItemRenderer__embed_mxml_____data_src_gfx_embedded_quest_quest_button_ornametal_png_1638345846;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.paddingLeft = 5;
                this.paddingRight = 5;
                this.backgroundAlpha = 1;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.clipContent = false;
            this.percentWidth = 100;
            this.height = 29;
            this.addEventListener("creationComplete", this.___QuestListItemRenderer_Canvas1_creationComplete);
            this.addEventListener("rollOver", this.___QuestListItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___QuestListItemRenderer_Canvas1_rollOut);
            this.addEventListener("click", this.___QuestListItemRenderer_Canvas1_click);
            return;
        }// end function

        public function get frame() : Canvas
        {
            return this._97692013frame;
        }// end function

        private function set labelText(param1:String) : void
        {
            var _loc_2:* = this._607740351labelText;
            if (_loc_2 !== param1)
            {
                this._607740351labelText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelText", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:QuestListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._QuestListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_QuestListItemRendererWatcherSetupUtil");
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

        private function RollOver() : void
        {
            if (!this._selected)
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("QuestItemBackgroundOver"));
            }
            return;
        }// end function

        public function __lbl_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get selected() : Boolean
        {
            return this._selected;
        }// end function

        private function clickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = new ItemClickEvent(ItemClickEvent.ITEM_CLICK, true);
            _loc_2.item = data;
            dispatchEvent(_loc_2);
            return;
        }// end function

        private function get trackable() : Boolean
        {
            return this._730196261trackable;
        }// end function

        public function set selected(param1:Boolean) : void
        {
            this._selected = param1;
            if (param1)
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("QuestItemBackgroundSelected"));
            }
            else
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("QuestItemBackgroundNormal"));
            }
            return;
        }// end function

        private function set tracked(param1:Boolean) : void
        {
            var _loc_2:* = this._1067395286tracked;
            if (_loc_2 !== param1)
            {
                this._1067395286tracked = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tracked", _loc_2, param1));
            }
            return;
        }// end function

        public function ___QuestListItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.clickHandler(event);
            return;
        }// end function

        public function get cbTrack() : StandardCheckBox
        {
            return this._555276332cbTrack;
        }// end function

        public function get lbl() : Label
        {
            return this._106934lbl;
        }// end function

        private function _QuestListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.iconImage;
            _loc_1 = this.labelText;
            _loc_1 = this.tracked;
            _loc_1 = this.trackable;
            return;
        }// end function

        private function get tracked() : Boolean
        {
            return this._1067395286tracked;
        }// end function

        public function ___QuestListItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.RollOut();
            return;
        }// end function

        private function set iconImage(param1:Bitmap) : void
        {
            var _loc_2:* = this._1410965406iconImage;
            if (_loc_2 !== param1)
            {
                this._1410965406iconImage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "iconImage", _loc_2, param1));
            }
            return;
        }// end function

        public function ___QuestListItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("QuestItemBackgroundNormal"));
            return;
        }// end function

        private function get labelText() : String
        {
            return this._607740351labelText;
        }// end function

        private function track(event:MouseEvent) : void
        {
            event.stopImmediatePropagation();
            var _loc_2:* = new TrackMissionEvent(TrackMissionEvent.TRACK_MISSION, true);
            _loc_2.item = data;
            _loc_2.track = this.cbTrack.selected;
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function set cbTrack(param1:StandardCheckBox) : void
        {
            var _loc_2:* = this._555276332cbTrack;
            if (_loc_2 !== param1)
            {
                this._555276332cbTrack = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "cbTrack", _loc_2, param1));
            }
            return;
        }// end function

        private function set trackable(param1:Boolean) : void
        {
            var _loc_2:* = this._730196261trackable;
            if (_loc_2 !== param1)
            {
                this._730196261trackable = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "trackable", _loc_2, param1));
            }
            return;
        }// end function

        public function __cbTrack_click(event:MouseEvent) : void
        {
            this.track(event);
            return;
        }// end function

        public function set frame(param1:Canvas) : void
        {
            var _loc_2:* = this._97692013frame;
            if (_loc_2 !== param1)
            {
                this._97692013frame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "frame", _loc_2, param1));
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_2:int = 0;
            super.data = param1;
            if (param1 is dQuestElementVO)
            {
                this.labelText = this.lm.GetText(LOCA_GROUP.QUEST_LABELS, data.mQuestName_string);
                this.iconImage = gAssetManager.GetBitmap("QuestAdvisorSmall");
                this.tracked = data.mIsTrackedMission;
                this.trackable = data.mQuestMode != QuestManagerStatic.QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST;
                this.finished = QuestManagerStatic.IsQuestReadyForSubmit(data as dQuestElementVO) && data.mQuestMode != QuestManagerStatic.QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST;
            }
            else if (data is dQuestDefinitionVO)
            {
                this.labelText = this.lm.GetText(LOCA_GROUP.QUEST_LABELS, data.questName_string);
                this.iconImage = gAssetManager.GetBitmap("QuestAdvisorSmall");
                this.tracked = false;
                this.trackable = false;
            }
            else if (data is dAdventureClientInfoVO)
            {
                this.labelText = this.lm.GetText(LOCA_GROUP.ADVENTURE_NAME, data.adventureName);
                _loc_2 = cAdventureDefinition.FindAdventureDefinition(data.adventureName).mQuality;
                this.iconImage = gAssetManager.GetBitmap("AdventureQuality" + _loc_2);
                this.tracked = data.isTrackedMission;
                this.trackable = true;
            }
            else
            {
                this.labelText = "";
                this.tracked = false;
                this.trackable = false;
            }
            return;
        }// end function

        public function set finished(param1:Boolean) : void
        {
            this._finished = param1;
            this.frame.visible = this._finished;
            return;
        }// end function

        private function _QuestListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return iconImage;
            }// end function
            , function (param1:Object) : void
            {
                _QuestListItemRenderer_Image1.source = param1;
                return;
            }// end function
            , "_QuestListItemRenderer_Image1.source");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "lbl.text");
            result[1] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return tracked;
            }// end function
            , function (param1:Boolean) : void
            {
                cbTrack.selected = param1;
                return;
            }// end function
            , "cbTrack.selected");
            result[2] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return trackable;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = null;
                return;
            }// end function
            , "cbTrack.visible");
            result[3] = binding;
            return result;
        }// end function

        private function get iconImage() : Bitmap
        {
            return this._1410965406iconImage;
        }// end function

        private function RollOut() : void
        {
            if (!this._selected)
            {
                this.setStyle("backgroundImage", gAssetManager.GetClass("QuestItemBackgroundNormal"));
            }
            return;
        }// end function

        public function get finished() : Boolean
        {
            return this._finished;
        }// end function

        public function set lbl(param1:Label) : void
        {
            var _loc_2:* = this._106934lbl;
            if (_loc_2 !== param1)
            {
                this._106934lbl = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lbl", _loc_2, param1));
            }
            return;
        }// end function

        public function ___QuestListItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.RollOver();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
