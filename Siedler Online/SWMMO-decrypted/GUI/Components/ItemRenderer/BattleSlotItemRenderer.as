package GUI.Components.ItemRenderer
{
    import Communication.VO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import flash.filters.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.effects.easing.*;
    import mx.events.*;

    public class BattleSlotItemRenderer extends Canvas implements IBindingClient
    {
        private var mDisabled:Boolean = false;
        private var _1619156027inCombatHighlight:Image;
        var _watchers:Array;
        private var _2065357550showDeadUnits:Parallel;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card00_png_157680316:Class;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_selected01_png_1074558104:Class;
        private var _450269557damageHighlightOverlay:Image;
        private var _531122434playerColor:Image;
        private var _3594628unit:Image;
        private var _1332194002background:Image;
        private var _1229015684amountLabel:Label;
        private var mUnitIcon:String;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_attack01_png_804305062:Class;
        private var _61588901emptyBackground:Image;
        private var mCurrentAmount:int;
        private var _1221262756health:BattleHealthBar;
        var _bindingsByDestination:Object;
        private var mSquad:dSquadVO;
        var _bindingsBeginWithWord:Object;
        private var _1191572123selected:Image;
        private var mPlayerColor:String;
        private var _1588295317deadUnits:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BattleSlotItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:99, height:108, childDescriptors:[new UIComponentDescriptor({type:Image, id:"inCombatHighlight", propertiesFactory:function () : Object
                {
                    return {null:99, height:108, visible:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"selected", propertiesFactory:function () : Object
                {
                    return {null:false, source:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_selected01_png_1074558104};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"emptyBackground", propertiesFactory:function () : Object
                {
                    return {x:3, y:1, source:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card00_png_157680316};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"background", propertiesFactory:function () : Object
                {
                    return {null:3, y:1};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"playerColor", propertiesFactory:function () : Object
                {
                    return {null:null, y:10};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"damageHighlightOverlay", propertiesFactory:function () : Object
                {
                    return {null:null, x:3, y:1, source:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_attack01_png_804305062};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.color = 16777215;
                    this.fontWeight = "normal";
                    this.top = "58";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:BattleHealthBar, id:"health", propertiesFactory:function () : Object
                {
                    return {null:null, y:75};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"unit", propertiesFactory:function () : Object
                {
                    return {null:21, y:1, width:54, height:64};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"deadUnits", stylesFactory:function () : void
                {
                    null.fontWeight = this;
                    this.color = 12784146;
                    this.fontSize = 16;
                    this.horizontalCenter = "20";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {selectable:false, visible:false, y:35, filters:[_BattleSlotItemRenderer_GlowFilter1_c(), _BattleSlotItemRenderer_GlowFilter2_c()]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card00_png_157680316 = BattleSlotItemRenderer__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card00_png_157680316;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_attack01_png_804305062 = BattleSlotItemRenderer__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_attack01_png_804305062;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_selected01_png_1074558104 = BattleSlotItemRenderer__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_selected01_png_1074558104;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 99;
            this.height = 108;
            this._BattleSlotItemRenderer_Parallel1_i();
            this.addEventListener("toolTipCreate", this.___BattleSlotItemRenderer_Canvas1_toolTipCreate);
            this.addEventListener("creationComplete", this.___BattleSlotItemRenderer_Canvas1_creationComplete);
            return;
        }// end function

        public function get playerColor() : Image
        {
            return this._531122434playerColor;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

        public function set playerColor(param1:Image) : void
        {
            var _loc_2:* = this._531122434playerColor;
            if (_loc_2 !== param1)
            {
                this._531122434playerColor = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerColor", _loc_2, param1));
            }
            return;
        }// end function

        public function get damageHighlight() : Boolean
        {
            return this.damageHighlightOverlay.visible;
        }// end function

        public function get showDeadUnits() : Parallel
        {
            return this._2065357550showDeadUnits;
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

        public function get damageHighlightOverlay() : Image
        {
            return this._450269557damageHighlightOverlay;
        }// end function

        public function set unit(param1:Image) : void
        {
            var _loc_2:* = this._3594628unit;
            if (_loc_2 !== param1)
            {
                this._3594628unit = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "unit", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BattleSlotItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BattleSlotItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_BattleSlotItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[null];
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

        public function set damageHighlight(param1:Boolean) : void
        {
            this.damageHighlightOverlay.visible = param1;
            if (!param1 && this.deadUnits.visible)
            {
                this.deadUnits.visible = false;
                this.deadUnits.y = 35;
            }
            return;
        }// end function

        public function get unit() : Image
        {
            return this._3594628unit;
        }// end function

        public function set highlightAttacker(param1:Boolean) : void
        {
            if (param1)
            {
                this.inCombatHighlight.source = gAssetManager.GetBitmap("BattleSlotHighlightAttacker");
            }
            this.inCombatHighlight.visible = param1;
            return;
        }// end function

        public function get selected() : Image
        {
            return this._1191572123selected;
        }// end function

        private function _BattleSlotItemRenderer_GlowFilter1_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 16777215;
            _loc_1.blurX = 3;
            _loc_1.blurY = 3;
            _loc_1.quality = 1;
            _loc_1.alpha = 1;
            _loc_1.strength = 5;
            return _loc_1;
        }// end function

        public function MakeDamage(param1:int) : void
        {
            this.health.value1 = this.health.value1 - param1;
            return;
        }// end function

        private function _BattleSlotItemRenderer_Fade1_c() : Fade
        {
            var _loc_1:* = new Fade();
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 200;
            return _loc_1;
        }// end function

        public function SetSquad(param1:dSquadVO, param2:int = 0) : void
        {
            this.mSquad = param1;
            toolTip = this.mSquad.GetType_string();
            this.mUnitIcon = this.mSquad.GetType_string();
            this.unit.source = gAssetManager.GetMilitaryIcon(this.mUnitIcon);
            var _loc_3:* = this.mSquad.GetUnitDescription().GetHitPoints();
            this.health.maxValue = _loc_3 * this.mSquad.GetAmount();
            this.mCurrentAmount = this.mSquad.GetAmount();
            this.amountLabel.text = this.mCurrentAmount + " / " + this.mSquad.GetAmount();
            this.background.visible = true;
            this.emptyBackground.visible = false;
            this.amountLabel.visible = true;
            this.health.visible = true;
            this.unit.visible = true;
            this.playerColor.visible = true;
            this.mPlayerColor = param2 < 10 ? ("BattlePlayerColor0" + param2) : ("BattlePlayerColor" + param2);
            this.playerColor.source = gAssetManager.GetBitmap(this.mPlayerColor);
            return;
        }// end function

        public function Clear() : void
        {
            this.mSquad = null;
            this.inCombatHighlight.visible = false;
            this.selected.visible = false;
            this.background.visible = false;
            this.emptyBackground.visible = true;
            this.amountLabel.visible = false;
            this.health.visible = false;
            this.damageHighlightOverlay.visible = false;
            this.unit.visible = false;
            this.playerColor.visible = false;
            this.deadUnits.visible = false;
            this.background.source = gAssetManager.GetBitmap("BattleSlotBackground");
            return;
        }// end function

        private function _BattleSlotItemRenderer_Move1_c() : Move
        {
            var _loc_1:* = new Move();
            _loc_1.yBy = -20;
            _loc_1.easingFunction = Cubic.easeOut;
            _loc_1.duration = 500;
            return _loc_1;
        }// end function

        public function DisplayCasualties(param1:int, param2:int) : void
        {
            this.health.value2 = param2;
            this.mCurrentAmount = this.mCurrentAmount - param1;
            this.amountLabel.text = this.mCurrentAmount + " / " + this.mSquad.GetAmount();
            if (param1 < 1)
            {
                return;
            }
            this.deadUnits.text = "-" + param1;
            this.deadUnits.visible = true;
            if (this.mCurrentAmount < 1)
            {
                this.mUnitIcon = "Skull";
                this.unit.source = gAssetManager.GetMilitaryIcon(this.mUnitIcon);
            }
            return;
        }// end function

        public function set emptyBackground(param1:Image) : void
        {
            var _loc_2:* = this._61588901emptyBackground;
            if (_loc_2 !== param1)
            {
                this._61588901emptyBackground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "emptyBackground", _loc_2, param1));
            }
            return;
        }// end function

        public function set damageHighlightOverlay(param1:Image) : void
        {
            var _loc_2:* = this._450269557damageHighlightOverlay;
            if (_loc_2 !== param1)
            {
                this._450269557damageHighlightOverlay = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "damageHighlightOverlay", _loc_2, param1));
            }
            return;
        }// end function

        public function get background() : Image
        {
            return this._1332194002background;
        }// end function

        public function get highlightDefender() : Boolean
        {
            return this.inCombatHighlight.visible;
        }// end function

        public function set health(param1:BattleHealthBar) : void
        {
            var _loc_2:* = this._1221262756health;
            if (_loc_2 !== param1)
            {
                this._1221262756health = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "health", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleSlotItemRenderer_Parallel1_i() : Parallel
        {
            var _loc_1:* = new Parallel();
            this.showDeadUnits = _loc_1;
            _loc_1.children = [this._BattleSlotItemRenderer_Fade1_c(), this._BattleSlotItemRenderer_Move1_c()];
            return _loc_1;
        }// end function

        public function get inCombatHighlight() : Image
        {
            return this._1619156027inCombatHighlight;
        }// end function

        public function get highlightAttacker() : Boolean
        {
            return this.inCombatHighlight.visible;
        }// end function

        public function ___BattleSlotItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.MILITARY_UNIT_EXTENDED_string, event);
            return;
        }// end function

        public function set selected(param1:Image) : void
        {
            var _loc_2:* = this._1191572123selected;
            if (_loc_2 !== param1)
            {
                this._1191572123selected = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selected", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleSlotItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.showDeadUnits;
            return;
        }// end function

        public function set deadUnits(param1:Label) : void
        {
            var _loc_2:* = this._1588295317deadUnits;
            if (_loc_2 !== param1)
            {
                this._1588295317deadUnits = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "deadUnits", _loc_2, param1));
            }
            return;
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

        public function get emptyBackground() : Image
        {
            return this._61588901emptyBackground;
        }// end function

        private function _BattleSlotItemRenderer_GlowFilter2_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 12784146;
            _loc_1.blurX = 5;
            _loc_1.blurY = 5;
            _loc_1.quality = 1;
            _loc_1.alpha = 0.7;
            _loc_1.strength = 2;
            return _loc_1;
        }// end function

        public function get deadUnits() : Label
        {
            return this._1588295317deadUnits;
        }// end function

        public function ___BattleSlotItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.Clear();
            return;
        }// end function

        public function get health() : BattleHealthBar
        {
            return this._1221262756health;
        }// end function

        public function set highlightDefender(param1:Boolean) : void
        {
            if (param1)
            {
                this.inCombatHighlight.source = gAssetManager.GetBitmap("BattleSlotHighlightDefender");
            }
            this.inCombatHighlight.visible = param1;
            return;
        }// end function

        public function set disabled(param1:Boolean) : void
        {
            return;
        }// end function

        private function _BattleSlotItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return showDeadUnits;
            }// end function
            , function (param1) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "deadUnits.showEffect");
            result[0] = binding;
            return result;
        }// end function

        public function get disabled() : Boolean
        {
            return this.mDisabled;
        }// end function

        public function set inCombatHighlight(param1:Image) : void
        {
            var _loc_2:* = this._1619156027inCombatHighlight;
            if (_loc_2 !== param1)
            {
                this._1619156027inCombatHighlight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "inCombatHighlight", _loc_2, param1));
            }
            return;
        }// end function

        public function set showDeadUnits(param1:Parallel) : void
        {
            var _loc_2:* = this._2065357550showDeadUnits;
            if (_loc_2 !== param1)
            {
                this._2065357550showDeadUnits = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showDeadUnits", _loc_2, param1));
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
