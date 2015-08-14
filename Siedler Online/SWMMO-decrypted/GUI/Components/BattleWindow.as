package GUI.Components
{
    import GUI.Components.ItemRenderer.*;
    import flash.filters.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.effects.easing.*;
    import mx.events.*;

    public class BattleWindow extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        private var _676475423defenderPanel:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_bg_png_340687270:Class;
        private var _600186953defenderSlot08:BattleSlotItemRenderer;
        private var _515215828attackerSlot01:BattleSlotItemRenderer;
        private var _1091436750fadeOut:Fade;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_top01_png_1904853944:Class;
        private var _515215831attackerSlot04:BattleSlotItemRenderer;
        private var _879632868attackAnimation:SpriteLibAnimation;
        private var _93681948defenderAvatar:AvatarListItemRenderer;
        private var _600186954defenderSlot09:BattleSlotItemRenderer;
        var _bindingsByDestination:Object;
        private var _515215829attackerSlot02:BattleSlotItemRenderer;
        private var _515215832attackerSlot05:BattleSlotItemRenderer;
        private var _711999985indicator:Image;
        private var _107868map:Image;
        private var _600186945defenderSlot00:BattleSlotItemRenderer;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_needle_png_1375800998:Class;
        private var _515215833attackerSlot06:BattleSlotItemRenderer;
        private var _1765364320showOverlayText:Parallel;
        private var _387912121curtainLeft:Image;
        private var _202962689attackerHolder:Canvas;
        private var _951530617content:Canvas;
        private var _844182092attackerNameLabel:Label;
        private var _600186946defenderSlot01:BattleSlotItemRenderer;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_right01_png_165926790:Class;
        private var _515215834attackerSlot07:BattleSlotItemRenderer;
        private var _1260446223attackerPanel:Canvas;
        private var _329041351phaseLabel:Label;
        private var _90636406ornamentalTop:Image;
        private var _287933807defenderHolder:Canvas;
        private var _600186947defenderSlot02:BattleSlotItemRenderer;
        private var _853965142curtainRight:Image;
        private var _515215835attackerSlot08:BattleSlotItemRenderer;
        private var _600186950defenderSlot05:BattleSlotItemRenderer;
        private var _658565795rotationContainer:Canvas;
        private var _600186948defenderSlot03:BattleSlotItemRenderer;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_bottom01_png_913026074:Class;
        private var _515215836attackerSlot09:BattleSlotItemRenderer;
        private var _239971253rotateToAttacker:Rotate;
        private var _600186951defenderSlot06:BattleSlotItemRenderer;
        private var _1534418181hideOverlayText:Fade;
        private var _794656902defenderNameLabel:Label;
        private var _1900348566ornamentalBottom:Image;
        var _watchers:Array;
        private var _600186949defenderSlot04:BattleSlotItemRenderer;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_bg_map_png_260211384:Class;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_left01_png_222845990:Class;
        private var _600186952defenderSlot07:BattleSlotItemRenderer;
        private var _130953927rotateToDefender:Rotate;
        var _bindingsBeginWithWord:Object;
        private var _515215827attackerSlot00:BattleSlotItemRenderer;
        private var _2082343164btnClose:CloseButton;
        private var _164059642roundLabel:Label;
        private var _8710830attackerAvatar:AvatarListItemRenderer;
        private var _447955490overlayTextPhase:Text;
        var _bindings:Array;
        private var _515215830attackerSlot03:BattleSlotItemRenderer;
        private var _445880847overlayTextRound:Text;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BattleWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:741, height:610, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "18";
                    this.top = "110";
                    this.bottom = "17";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {horizontalScrollPolicy:"off", verticalScrollPolicy:"off", styleName:"basicPanel", childDescriptors:[new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                    {
                        this.top = "5";
                        this.right = "15";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"map", stylesFactory:function () : void
                    {
                        this.horizontalCenter = "3";
                        this.verticalCenter = "15";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_bg_map_png_260211384};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "18";
                        this.top = "32";
                        this.bottom = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:320, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"attackerNameLabel", stylesFactory:function () : void
                            {
                                this.top = "1";
                                this.horizontalCenter = "0";
                                this.color = 16777215;
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, id:"attackerPanel", stylesFactory:function () : void
                        {
                            this.backgroundColor = 5326645;
                            this.backgroundAlpha = 0.6;
                            this.left = "1";
                            this.right = "1";
                            this.top = "18";
                            this.bottom = "11";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.right = "16";
                        this.top = "32";
                        this.bottom = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {width:320, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"defenderNameLabel", stylesFactory:function () : void
                            {
                                null.top = this;
                                this.horizontalCenter = "0";
                                this.color = 16777215;
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, id:"defenderPanel", stylesFactory:function () : void
                        {
                            null.backgroundColor = this;
                            this.backgroundAlpha = 0.6;
                            this.left = "1";
                            this.right = "1";
                            this.top = "18";
                            this.bottom = "11";
                            return;
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"curtainLeft", stylesFactory:function () : void
                {
                    this.top = "140";
                    this.left = "30";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_left01_png_222845990};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"curtainRight", stylesFactory:function () : void
                {
                    this.top = "140";
                    this.right = "24";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {source:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_right01_png_165926790};
                }// end function
                }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                {
                    null.top = this;
                    this.horizontalCenter = "-1";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"rotationContainer", stylesFactory:function () : void
                {
                    this.top = "374";
                    this.horizontalCenter = "21";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {clipContent:false, childDescriptors:[new UIComponentDescriptor({type:Image, id:"indicator", propertiesFactory:function () : Object
                    {
                        return {null:null, height:88, x:-44, y:-44, source:_embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_needle_png_1375800998};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"attackerHolder", stylesFactory:function () : void
                {
                    this.left = "37";
                    this.top = "160";
                    this.bottom = "28";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:318, childDescriptors:[new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot01", stylesFactory:function () : void
                    {
                        this.top = "5";
                        this.right = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot02", stylesFactory:function () : void
                    {
                        this.top = "100";
                        this.right = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot03", stylesFactory:function () : void
                    {
                        this.top = "195";
                        this.right = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot04", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.right = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot05", stylesFactory:function () : void
                    {
                        this.top = "50";
                        this.right = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot06", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.right = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot07", stylesFactory:function () : void
                    {
                        this.top = "240";
                        this.right = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot00", stylesFactory:function () : void
                    {
                        this.top = "80";
                        this.right = "215";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot08", stylesFactory:function () : void
                    {
                        this.top = "190";
                        this.right = "200";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"attackerSlot09", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.right = "200";
                        return;
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"defenderHolder", stylesFactory:function () : void
                {
                    null.right = this;
                    this.top = "160";
                    this.bottom = "28";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {width:318, childDescriptors:[new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot01", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.left = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot02", stylesFactory:function () : void
                    {
                        this.top = "100";
                        this.left = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot03", stylesFactory:function () : void
                    {
                        this.top = "195";
                        this.left = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot04", stylesFactory:function () : void
                    {
                        this.top = "290";
                        this.left = "0";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot05", stylesFactory:function () : void
                    {
                        this.top = "50";
                        this.left = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot06", stylesFactory:function () : void
                    {
                        this.top = "145";
                        this.left = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot07", stylesFactory:function () : void
                    {
                        this.top = "240";
                        this.left = "100";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot00", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.left = "215";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot08", stylesFactory:function () : void
                    {
                        this.top = "190";
                        this.left = "200";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:BattleSlotItemRenderer, id:"defenderSlot09", stylesFactory:function () : void
                    {
                        this.top = "285";
                        this.left = "200";
                        return;
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:SpriteLibAnimation, id:"attackAnimation", propertiesFactory:function () : Object
                {
                    return {animationName:"guianim_attack", visible:false, width:140, height:174};
                }// end function
                }), new UIComponentDescriptor({type:AvatarListItemRenderer, id:"attackerAvatar", stylesFactory:function () : void
                {
                    this.top = "138";
                    this.left = "32";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:AvatarListItemRenderer, id:"defenderAvatar", stylesFactory:function () : void
                {
                    this.top = "138";
                    this.right = "30";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"ornamentalTop", stylesFactory:function () : void
                {
                    this.top = "0";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_top01_png_1904853944};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"ornamentalBottom", stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"roundLabel", stylesFactory:function () : void
                {
                    null.fontWeight = this;
                    this.color = 0;
                    this.horizontalCenter = "0";
                    this.top = "120";
                    this.fontSize = 16;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"phaseLabel", stylesFactory:function () : void
                {
                    this.fontWeight = "bold";
                    this.color = 0;
                    this.horizontalCenter = "0";
                    this.bottom = "16";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Text, id:"overlayTextPhase", stylesFactory:function () : void
                {
                    this.fontWeight = "bold";
                    this.color = 13736761;
                    this.fontSize = 38;
                    this.horizontalCenter = "0";
                    this.verticalCenter = "40";
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, visible:false, width:600, filters:[_BattleWindow_GlowFilter1_c(), _BattleWindow_GlowFilter2_c()]};
                }// end function
                }), new UIComponentDescriptor({type:Text, id:"overlayTextRound", stylesFactory:function () : void
                {
                    this.fontWeight = "bold";
                    this.color = 13736761;
                    this.fontSize = 50;
                    this.horizontalCenter = "0";
                    this.verticalCenter = "40";
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {selectable:false, visible:false, width:600, filters:[_BattleWindow_GlowFilter3_c(), _BattleWindow_GlowFilter4_c()]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_bg_map_png_260211384 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_bg_map_png_260211384;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_bottom01_png_913026074 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_bottom01_png_913026074;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_left01_png_222845990 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_left01_png_222845990;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_right01_png_165926790 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_right01_png_165926790;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_top01_png_1904853944 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_ornamental_top01_png_1904853944;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_bg_png_340687270 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_bg_png_340687270;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_needle_png_1375800998 = BattleWindow__embed_mxml_____data_src_gfx_embedded_battlewindow_compass01_needle_png_1375800998;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 741;
            this.height = 610;
            this._BattleWindow_Fade1_i();
            this._BattleWindow_Fade2_i();
            this._BattleWindow_Fade4_i();
            this._BattleWindow_Rotate2_i();
            this._BattleWindow_Rotate1_i();
            this._BattleWindow_Parallel1_i();
            return;
        }// end function

        public function set attackerHolder(param1:Canvas) : void
        {
            var _loc_2:* = this._202962689attackerHolder;
            if (_loc_2 !== param1)
            {
                this._202962689attackerHolder = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerHolder", _loc_2, param1));
            }
            return;
        }// end function

        public function set roundLabel(param1:Label) : void
        {
            var _loc_2:* = this._164059642roundLabel;
            if (_loc_2 !== param1)
            {
                this._164059642roundLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "roundLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get roundLabel() : Label
        {
            return this._164059642roundLabel;
        }// end function

        private function _BattleWindow_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.rotationContainer;
            _loc_1 = this.rotationContainer;
            _loc_1 = this.showOverlayText;
            _loc_1 = this.hideOverlayText;
            _loc_1 = this.showOverlayText;
            _loc_1 = this.hideOverlayText;
            return;
        }// end function

        public function get attackAnimation() : SpriteLibAnimation
        {
            return this._879632868attackAnimation;
        }// end function

        private function _BattleWindow_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function set attackerPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._1260446223attackerPanel;
            if (_loc_2 !== param1)
            {
                this._1260446223attackerPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerPanel", _loc_2, param1));
            }
            return;
        }// end function

        public function set indicator(param1:Image) : void
        {
            var _loc_2:* = this._711999985indicator;
            if (_loc_2 !== param1)
            {
                this._711999985indicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "indicator", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackAnimation(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._879632868attackAnimation;
            if (_loc_2 !== param1)
            {
                this._879632868attackAnimation = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackAnimation", _loc_2, param1));
            }
            return;
        }// end function

        public function get phaseLabel() : Label
        {
            return this._329041351phaseLabel;
        }// end function

        private function _BattleWindow_GlowFilter3_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 3353634;
            _loc_1.blurX = 3;
            _loc_1.blurY = 3;
            _loc_1.quality = 1;
            _loc_1.alpha = 1;
            _loc_1.strength = 5;
            return _loc_1;
        }// end function

        public function set defenderAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._93681948defenderAvatar;
            if (_loc_2 !== param1)
            {
                this._93681948defenderAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderAvatar", _loc_2, param1));
            }
            return;
        }// end function

        public function get defenderSlot00() : BattleSlotItemRenderer
        {
            return this._600186945defenderSlot00;
        }// end function

        public function get defenderSlot03() : BattleSlotItemRenderer
        {
            return this._600186948defenderSlot03;
        }// end function

        public function get defenderSlot04() : BattleSlotItemRenderer
        {
            return this._600186949defenderSlot04;
        }// end function

        public function get defenderSlot05() : BattleSlotItemRenderer
        {
            return this._600186950defenderSlot05;
        }// end function

        private function _BattleWindow_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function get defenderSlot07() : BattleSlotItemRenderer
        {
            return this._600186952defenderSlot07;
        }// end function

        public function get defenderSlot08() : BattleSlotItemRenderer
        {
            return this._600186953defenderSlot08;
        }// end function

        public function get rotateToAttacker() : Rotate
        {
            return this._239971253rotateToAttacker;
        }// end function

        public function get defenderSlot02() : BattleSlotItemRenderer
        {
            return this._600186947defenderSlot02;
        }// end function

        public function get defenderSlot06() : BattleSlotItemRenderer
        {
            return this._600186951defenderSlot06;
        }// end function

        public function get defenderSlot09() : BattleSlotItemRenderer
        {
            return this._600186954defenderSlot09;
        }// end function

        public function get defenderSlot01() : BattleSlotItemRenderer
        {
            return this._600186946defenderSlot01;
        }// end function

        public function get showOverlayText() : Parallel
        {
            return this._1765364320showOverlayText;
        }// end function

        public function get attackerPanel() : Canvas
        {
            return this._1260446223attackerPanel;
        }// end function

        public function set fadeOut(param1:Fade) : void
        {
            var _loc_2:* = this._1091436750fadeOut;
            if (_loc_2 !== param1)
            {
                this._1091436750fadeOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOut", _loc_2, param1));
            }
            return;
        }// end function

        public function get ornamentalTop() : Image
        {
            return this._90636406ornamentalTop;
        }// end function

        private function _BattleWindow_GlowFilter2_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 14273191;
            _loc_1.blurX = 40;
            _loc_1.blurY = 30;
            _loc_1.quality = 1;
            _loc_1.alpha = 0.7;
            _loc_1.strength = 5;
            return _loc_1;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function set phaseLabel(param1:Label) : void
        {
            var _loc_2:* = this._329041351phaseLabel;
            if (_loc_2 !== param1)
            {
                this._329041351phaseLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "phaseLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot00(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186945defenderSlot00;
            if (_loc_2 !== param1)
            {
                this._600186945defenderSlot00 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot00", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot03(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186948defenderSlot03;
            if (_loc_2 !== param1)
            {
                this._600186948defenderSlot03 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot03", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot04(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186949defenderSlot04;
            if (_loc_2 !== param1)
            {
                this._600186949defenderSlot04 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot04", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot01(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186946defenderSlot01;
            if (_loc_2 !== param1)
            {
                this._600186946defenderSlot01 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot01", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot05(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186950defenderSlot05;
            if (_loc_2 !== param1)
            {
                this._600186950defenderSlot05 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot05", _loc_2, param1));
            }
            return;
        }// end function

        public function get defenderNameLabel() : Label
        {
            return this._794656902defenderNameLabel;
        }// end function

        public function set defenderSlot06(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186951defenderSlot06;
            if (_loc_2 !== param1)
            {
                this._600186951defenderSlot06 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot06", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot07(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186952defenderSlot07;
            if (_loc_2 !== param1)
            {
                this._600186952defenderSlot07 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot07", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot08(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186953defenderSlot08;
            if (_loc_2 !== param1)
            {
                this._600186953defenderSlot08 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot08", _loc_2, param1));
            }
            return;
        }// end function

        public function get indicator() : Image
        {
            return this._711999985indicator;
        }// end function

        public function set defenderSlot02(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186947defenderSlot02;
            if (_loc_2 !== param1)
            {
                this._600186947defenderSlot02 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot02", _loc_2, param1));
            }
            return;
        }// end function

        public function set rotateToAttacker(param1:Rotate) : void
        {
            var _loc_2:* = this._239971253rotateToAttacker;
            if (_loc_2 !== param1)
            {
                this._239971253rotateToAttacker = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rotateToAttacker", _loc_2, param1));
            }
            return;
        }// end function

        public function set rotateToDefender(param1:Rotate) : void
        {
            var _loc_2:* = this._130953927rotateToDefender;
            if (_loc_2 !== param1)
            {
                this._130953927rotateToDefender = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rotateToDefender", _loc_2, param1));
            }
            return;
        }// end function

        public function get curtainRight() : Image
        {
            return this._853965142curtainRight;
        }// end function

        public function get attackerAvatar() : AvatarListItemRenderer
        {
            return this._8710830attackerAvatar;
        }// end function

        private function _BattleWindow_GlowFilter1_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 3353634;
            _loc_1.blurX = 3;
            _loc_1.blurY = 3;
            _loc_1.quality = 1;
            _loc_1.alpha = 1;
            _loc_1.strength = 5;
            return _loc_1;
        }// end function

        public function get rotationContainer() : Canvas
        {
            return this._658565795rotationContainer;
        }// end function

        public function set map(param1:Image) : void
        {
            var _loc_2:* = this._107868map;
            if (_loc_2 !== param1)
            {
                this._107868map = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "map", _loc_2, param1));
            }
            return;
        }// end function

        public function set showOverlayText(param1:Parallel) : void
        {
            var _loc_2:* = this._1765364320showOverlayText;
            if (_loc_2 !== param1)
            {
                this._1765364320showOverlayText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showOverlayText", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderSlot09(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._600186954defenderSlot09;
            if (_loc_2 !== param1)
            {
                this._600186954defenderSlot09 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderSlot09", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        private function _BattleWindow_Rotate2_i() : Rotate
        {
            var _loc_1:* = new Rotate();
            this.rotateToAttacker = _loc_1;
            _loc_1.startDelay = 500;
            _loc_1.duration = 1000;
            _loc_1.angleTo = -90;
            _loc_1.easingFunction = Elastic.easeOut;
            BindingManager.executeBindings(this, "rotateToAttacker", this.rotateToAttacker);
            return _loc_1;
        }// end function

        public function set ornamentalBottom(param1:Image) : void
        {
            var _loc_2:* = this._1900348566ornamentalBottom;
            if (_loc_2 !== param1)
            {
                this._1900348566ornamentalBottom = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ornamentalBottom", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleWindow_Parallel1_i() : Parallel
        {
            var _loc_1:* = new Parallel();
            this.showOverlayText = _loc_1;
            _loc_1.children = [this._BattleWindow_Zoom1_c(), this._BattleWindow_Fade3_c()];
            return _loc_1;
        }// end function

        public function set defenderHolder(param1:Canvas) : void
        {
            var _loc_2:* = this._287933807defenderHolder;
            if (_loc_2 !== param1)
            {
                this._287933807defenderHolder = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderHolder", _loc_2, param1));
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function set ornamentalTop(param1:Image) : void
        {
            var _loc_2:* = this._90636406ornamentalTop;
            if (_loc_2 !== param1)
            {
                this._90636406ornamentalTop = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ornamentalTop", _loc_2, param1));
            }
            return;
        }// end function

        public function set content(param1:Canvas) : void
        {
            var _loc_2:* = this._951530617content;
            if (_loc_2 !== param1)
            {
                this._951530617content = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "content", _loc_2, param1));
            }
            return;
        }// end function

        public function get hideOverlayText() : Fade
        {
            return this._1534418181hideOverlayText;
        }// end function

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        public function get attackerHolder() : Canvas
        {
            return this._202962689attackerHolder;
        }// end function

        public function set defenderNameLabel(param1:Label) : void
        {
            var _loc_2:* = this._794656902defenderNameLabel;
            if (_loc_2 !== param1)
            {
                this._794656902defenderNameLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderNameLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleWindow_Rotate1_i() : Rotate
        {
            var _loc_1:* = new Rotate();
            this.rotateToDefender = _loc_1;
            _loc_1.startDelay = 500;
            _loc_1.duration = 1000;
            _loc_1.angleTo = 90;
            _loc_1.easingFunction = Elastic.easeOut;
            BindingManager.executeBindings(this, "rotateToDefender", this.rotateToDefender);
            return _loc_1;
        }// end function

        private function _BattleWindow_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return rotationContainer;
            }// end function
            , function (param1:Object) : void
            {
                rotateToDefender.target = param1;
                return;
            }// end function
            , "rotateToDefender.target");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return rotationContainer;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "rotateToAttacker.target");
            result[1] = binding;
            binding = new Binding(this, function ()
            {
                return showOverlayText;
            }// end function
            , function (param1) : void
            {
                overlayTextPhase.setStyle("showEffect", param1);
                return;
            }// end function
            , "overlayTextPhase.showEffect");
            result[2] = binding;
            binding = new Binding(this, function ()
            {
                return hideOverlayText;
            }// end function
            , function (param1) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "overlayTextPhase.hideEffect");
            result[3] = binding;
            binding = new Binding(this, function ()
            {
                return showOverlayText;
            }// end function
            , function (param1) : void
            {
                overlayTextRound.setStyle("showEffect", param1);
                return;
            }// end function
            , "overlayTextRound.showEffect");
            result[4] = binding;
            binding = new Binding(this, function ()
            {
                return hideOverlayText;
            }// end function
            , function (param1) : void
            {
                overlayTextRound.setStyle("hideEffect", param1);
                return;
            }// end function
            , "overlayTextRound.hideEffect");
            result[5] = binding;
            return result;
        }// end function

        public function get defenderAvatar() : AvatarListItemRenderer
        {
            return this._93681948defenderAvatar;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function get rotateToDefender() : Rotate
        {
            return this._130953927rotateToDefender;
        }// end function

        public function set rotationContainer(param1:Canvas) : void
        {
            var _loc_2:* = this._658565795rotationContainer;
            if (_loc_2 !== param1)
            {
                this._658565795rotationContainer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rotationContainer", _loc_2, param1));
            }
            return;
        }// end function

        public function set curtainRight(param1:Image) : void
        {
            var _loc_2:* = this._853965142curtainRight;
            if (_loc_2 !== param1)
            {
                this._853965142curtainRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "curtainRight", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._8710830attackerAvatar;
            if (_loc_2 !== param1)
            {
                this._8710830attackerAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerAvatar", _loc_2, param1));
            }
            return;
        }// end function

        public function get map() : Image
        {
            return this._107868map;
        }// end function

        public function set attackerNameLabel(param1:Label) : void
        {
            var _loc_2:* = this._844182092attackerNameLabel;
            if (_loc_2 !== param1)
            {
                this._844182092attackerNameLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerNameLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get defenderHolder() : Canvas
        {
            return this._287933807defenderHolder;
        }// end function

        public function set curtainLeft(param1:Image) : void
        {
            var _loc_2:* = this._387912121curtainLeft;
            if (_loc_2 !== param1)
            {
                this._387912121curtainLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "curtainLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function get ornamentalBottom() : Image
        {
            return this._1900348566ornamentalBottom;
        }// end function

        public function set fadeIn(param1:Fade) : void
        {
            var _loc_2:* = this._1282133823fadeIn;
            if (_loc_2 !== param1)
            {
                this._1282133823fadeIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeIn", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleWindow_Fade4_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.hideOverlayText = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:BattleWindow;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BattleWindow_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BattleWindowWatcherSetupUtil");
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

        private function _BattleWindow_Zoom1_c() : Zoom
        {
            var _loc_1:* = new Zoom();
            _loc_1.duration = 300;
            _loc_1.zoomHeightFrom = 0.01;
            _loc_1.zoomWidthFrom = 0.01;
            _loc_1.zoomHeightTo = 1;
            _loc_1.zoomWidthTo = 1;
            _loc_1.easingFunction = Back.easeOut;
            return _loc_1;
        }// end function

        public function set attackerSlot00(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215827attackerSlot00;
            if (_loc_2 !== param1)
            {
                this._515215827attackerSlot00 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot00", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot02(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215829attackerSlot02;
            if (_loc_2 !== param1)
            {
                this._515215829attackerSlot02 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot02", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot04(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215831attackerSlot04;
            if (_loc_2 !== param1)
            {
                this._515215831attackerSlot04 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot04", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot01(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215828attackerSlot01;
            if (_loc_2 !== param1)
            {
                this._515215828attackerSlot01 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot01", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot03(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215830attackerSlot03;
            if (_loc_2 !== param1)
            {
                this._515215830attackerSlot03 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot03", _loc_2, param1));
            }
            return;
        }// end function

        public function get attackerNameLabel() : Label
        {
            return this._844182092attackerNameLabel;
        }// end function

        public function set attackerSlot08(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215835attackerSlot08;
            if (_loc_2 !== param1)
            {
                this._515215835attackerSlot08 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot08", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot05(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215832attackerSlot05;
            if (_loc_2 !== param1)
            {
                this._515215832attackerSlot05 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot05", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot09(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215836attackerSlot09;
            if (_loc_2 !== param1)
            {
                this._515215836attackerSlot09 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot09", _loc_2, param1));
            }
            return;
        }// end function

        public function get curtainLeft() : Image
        {
            return this._387912121curtainLeft;
        }// end function

        public function set attackerSlot07(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215834attackerSlot07;
            if (_loc_2 !== param1)
            {
                this._515215834attackerSlot07 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot07", _loc_2, param1));
            }
            return;
        }// end function

        public function set overlayTextPhase(param1:Text) : void
        {
            var _loc_2:* = this._447955490overlayTextPhase;
            if (_loc_2 !== param1)
            {
                this._447955490overlayTextPhase = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "overlayTextPhase", _loc_2, param1));
            }
            return;
        }// end function

        public function set attackerSlot06(param1:BattleSlotItemRenderer) : void
        {
            var _loc_2:* = this._515215833attackerSlot06;
            if (_loc_2 !== param1)
            {
                this._515215833attackerSlot06 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attackerSlot06", _loc_2, param1));
            }
            return;
        }// end function

        public function set defenderPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._676475423defenderPanel;
            if (_loc_2 !== param1)
            {
                this._676475423defenderPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "defenderPanel", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleWindow_Fade3_c() : Fade
        {
            var _loc_1:* = new Fade();
            _loc_1.duration = 300;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            return _loc_1;
        }// end function

        public function get attackerSlot02() : BattleSlotItemRenderer
        {
            return this._515215829attackerSlot02;
        }// end function

        public function get attackerSlot03() : BattleSlotItemRenderer
        {
            return this._515215830attackerSlot03;
        }// end function

        public function get attackerSlot05() : BattleSlotItemRenderer
        {
            return this._515215832attackerSlot05;
        }// end function

        public function get attackerSlot06() : BattleSlotItemRenderer
        {
            return this._515215833attackerSlot06;
        }// end function

        public function get attackerSlot01() : BattleSlotItemRenderer
        {
            return this._515215828attackerSlot01;
        }// end function

        public function get attackerSlot09() : BattleSlotItemRenderer
        {
            return this._515215836attackerSlot09;
        }// end function

        public function get defenderPanel() : Canvas
        {
            return this._676475423defenderPanel;
        }// end function

        public function get attackerSlot00() : BattleSlotItemRenderer
        {
            return this._515215827attackerSlot00;
        }// end function

        public function get overlayTextPhase() : Text
        {
            return this._447955490overlayTextPhase;
        }// end function

        public function get attackerSlot07() : BattleSlotItemRenderer
        {
            return this._515215834attackerSlot07;
        }// end function

        public function get attackerSlot08() : BattleSlotItemRenderer
        {
            return this._515215835attackerSlot08;
        }// end function

        public function get overlayTextRound() : Text
        {
            return this._445880847overlayTextRound;
        }// end function

        public function set btnClose(param1:CloseButton) : void
        {
            var _loc_2:* = this._2082343164btnClose;
            if (_loc_2 !== param1)
            {
                this._2082343164btnClose = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClose", _loc_2, param1));
            }
            return;
        }// end function

        public function get attackerSlot04() : BattleSlotItemRenderer
        {
            return this._515215831attackerSlot04;
        }// end function

        public function set overlayTextRound(param1:Text) : void
        {
            var _loc_2:* = this._445880847overlayTextRound;
            if (_loc_2 !== param1)
            {
                this._445880847overlayTextRound = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "overlayTextRound", _loc_2, param1));
            }
            return;
        }// end function

        private function _BattleWindow_GlowFilter4_c() : GlowFilter
        {
            var _loc_1:* = new GlowFilter();
            _loc_1.color = 14273191;
            _loc_1.blurX = 40;
            _loc_1.blurY = 30;
            _loc_1.quality = 1;
            _loc_1.alpha = 0.7;
            _loc_1.strength = 5;
            return _loc_1;
        }// end function

        public function set hideOverlayText(param1:Fade) : void
        {
            var _loc_2:* = this._1534418181hideOverlayText;
            if (_loc_2 !== param1)
            {
                this._1534418181hideOverlayText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "hideOverlayText", _loc_2, param1));
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
