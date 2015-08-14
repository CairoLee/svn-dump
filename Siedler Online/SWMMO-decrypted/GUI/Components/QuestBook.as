package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class QuestBook extends Canvas implements IBindingClient
    {
        private var _1253431512btnInstantFinish:StandardButton;
        private var _1282133823fadeIn:Fade;
        private var _3322014list:GroupedQuestList;
        private var _1342136183btnShowDetails:StandardButton;
        private var _1091436750fadeOut:Fade;
        private var _1316820334adventureOptions:Canvas;
        private var _1332194002background:Canvas;
        private var _1268262975btnSendArmy:StandardButton;
        private var _301950085btnInvite:StandardButton;
        private var _222722119sparkleAnim:BatchedSpriteLibAnimation;
        private var _1754800716selectedIcon:Image;
        var _bindingsByDestination:Object;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win2_png_643330800:Class;
        private var _1724546052description:Text;
        private var _690815438rewardOrnamentalRight:Image;
        private var _542559094adventureTodo:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win1_png_645673198:Class;
        private var _577581428btnCancelQuest:StandardButton;
        private var _779276954footerButtons:HBox;
        private var _1503093179triggers:List;
        var _watchers:Array;
        private var _1681770426btnCancelAdventure:StandardButton;
        private var _2099804239btnVisit:StandardButton;
        private var _443164297upperContent:Canvas;
        private var _1666485868rewardsTitle:Label;
        private var _1332141161backgroundFooter:Canvas;
        private var _1295741293todoText:Text;
        private var _915835362rewardsList:QuestRewardList;
        private var _1328577994detailsHeadline:CustomText;
        var _bindingsBeginWithWord:Object;
        private var _2082343164btnClose:CloseButton;
        private var _1115058732headline:Label;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_top1_png_136131836:Class;
        private var _1953015789btnFinishQuest:StandardButton;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _94069048btnOK:StandardButton;
        private var _853385749rewardOrnamentalLeft:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function QuestBook()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:600, height:483, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "9";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:"basicPanel"};
                }// end function
                }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.top = "-42";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    null.left = this;
                    this.top = "15";
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    this.right = "46";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                {
                    this.top = "10";
                    this.right = "24";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "14";
                    this.right = "16";
                    this.top = "33";
                    this.bottom = "52";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"detailsHeader", horizontalScrollPolicy:"off", verticalScrollPolicy:"off", childDescriptors:[new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                    {
                        this.left = "13";
                        this.right = "15";
                        this.top = "8";
                        this.bottom = "3";
                        this.horizontalGap = 2;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {width:176, percentHeight:100, horizontalScrollPolicy:"off", verticalScrollPolicy:"on", clipContent:false, childDescriptors:[new UIComponentDescriptor({type:GroupedQuestList, id:"list", stylesFactory:function () : void
                            {
                                this.left = "0";
                                this.right = "0";
                                this.top = "5";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            return {null:"vr", width:3, percentHeight:100};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                return {styleName:"detailsSubHeader", percentWidth:100, height:45, childDescriptors:[new UIComponentDescriptor({type:CustomText, id:"detailsHeadline", stylesFactory:function () : void
                                {
                                    this.color = 16777215;
                                    this.fontWeight = "bold";
                                    this.textAlign = "center";
                                    this.verticalCenter = "0";
                                    this.left = "10";
                                    this.right = "10";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"rewardOrnamentalLeft", stylesFactory:function () : void
                            {
                                this.left = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {visible:false, source:_embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win1_png_645673198};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"rewardOrnamentalRight", stylesFactory:function () : void
                            {
                                this.right = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {visible:false, source:_embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win2_png_643330800};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, id:"upperContent", stylesFactory:function () : void
                            {
                                this.left = "1";
                                this.right = "1";
                                this.top = "45";
                                this.bottom = "103";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {styleName:"detailsContentBox", childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                                {
                                    null.backgroundColor = this;
                                    this.left = "17";
                                    this.right = "17";
                                    this.top = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {height:98};
                                }// end function
                                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                                {
                                    this.left = "20";
                                    this.right = "1";
                                    this.top = "10";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {height:92, horizontalScrollPolicy:"off", childDescriptors:[new UIComponentDescriptor({type:Text, id:"description", stylesFactory:function () : void
                                    {
                                        null.color = this;
                                        this.paddingRight = 19;
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:false, percentWidth:100};
                                    }// end function
                                    })]};
                                }// end function
                                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                                {
                                    this.left = "5";
                                    this.right = "5";
                                    this.top = "110";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, height:10};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.top = "40";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null, percentWidth:100, height:10};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"selectedIcon", stylesFactory:function () : void
                            {
                                null.left = this;
                                this.top = "-4";
                                return;
                            }// end function
                            }), new UIComponentDescriptor({type:List, id:"triggers", stylesFactory:function () : void
                            {
                                this.left = "18";
                                this.top = "166";
                                this.bottom = "105";
                                this.backgroundAlpha = 0;
                                this.borderThickness = 0;
                                this.paddingBottom = 2;
                                this.paddingTop = 2;
                                this.paddingLeft = 0;
                                this.paddingRight = 0;
                                this.useRollOver = false;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null, itemRenderer:_QuestBook_ClassFactory1_c()};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, id:"adventureTodo", stylesFactory:function () : void
                            {
                                this.left = "20";
                                this.right = "2";
                                this.bottom = "112";
                                this.top = "172";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {horizontalScrollPolicy:"off", childDescriptors:[new UIComponentDescriptor({type:Text, id:"todoText", stylesFactory:function () : void
                                {
                                    this.color = 16777215;
                                    this.paddingRight = 19;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:false, percentWidth:100};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.bottom = "83";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"rewardsTitle", stylesFactory:function () : void
                                {
                                    this.top = "1";
                                    this.horizontalCenter = "0";
                                    this.color = 16777215;
                                    this.fontWeight = "bold";
                                    return;
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.left = "1";
                                this.right = "1";
                                this.bottom = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {styleName:"detailsContentBox", height:83, childDescriptors:[new UIComponentDescriptor({type:QuestRewardList, id:"rewardsList", propertiesFactory:function () : Object
                                {
                                    return {null:false, percentWidth:100};
                                }// end function
                                }), new UIComponentDescriptor({type:Canvas, id:"adventureOptions", stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.verticalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {visible:false, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnVisit", stylesFactory:function () : void
                                    {
                                        null.horizontalCenter = this;
                                        this.verticalCenter = "-17";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:null};
                                    }// end function
                                    }), new UIComponentDescriptor({type:StandardButton, id:"btnSendArmy", stylesFactory:function () : void
                                    {
                                        null.horizontalCenter = this;
                                        this.verticalCenter = "17";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:120};
                                    }// end function
                                    }), new UIComponentDescriptor({type:StandardButton, id:"btnShowDetails", stylesFactory:function () : void
                                    {
                                        null.horizontalCenter = this;
                                        this.verticalCenter = "-17";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {width:120};
                                    }// end function
                                    }), new UIComponentDescriptor({type:StandardButton, id:"btnInvite", stylesFactory:function () : void
                                    {
                                        null.horizontalCenter = this;
                                        this.verticalCenter = "17";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:120};
                                    }// end function
                                    })]};
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"backgroundFooter", stylesFactory:function () : void
                {
                    this.left = "10";
                    this.right = "10";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:60};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"footerButtons", stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.horizontalCenter = "90";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnInstantFinish", propertiesFactory:function () : Object
                    {
                        return {toolTip:"InstantFinishQuest", enabled:false, height:32};
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnFinishQuest", propertiesFactory:function () : Object
                    {
                        return {enabled:false, height:32};
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnCancelQuest", propertiesFactory:function () : Object
                    {
                        return {null:false, height:32};
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnOK", propertiesFactory:function () : Object
                    {
                        return {null:false, height:32, width:70};
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnCancelAdventure", propertiesFactory:function () : Object
                    {
                        return {null:false, height:32};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:BatchedSpriteLibAnimation, id:"sparkleAnim", propertiesFactory:function () : Object
                {
                    return {null:null, height:483, mouseChildren:false, mouseEnabled:false, animationName:"guianim_sparkle", numInstances:20, offsetFrames:2, visible:false};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_top1_png_136131836 = QuestBook__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_top1_png_136131836;
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win1_png_645673198 = QuestBook__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win1_png_645673198;
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win2_png_643330800 = QuestBook__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental_win2_png_643330800;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 600;
            this.height = 483;
            this.cacheAsBitmap = true;
            this.clipContent = false;
            this._QuestBook_Fade1_i();
            this._QuestBook_Fade2_i();
            return;
        }// end function

        public function set description(param1:Text) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        private function _QuestBook_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = QuestTriggerListItemRenderer;
            return _loc_1;
        }// end function

        public function set btnInvite(param1:StandardButton) : void
        {
            var _loc_2:* = this._301950085btnInvite;
            if (_loc_2 !== param1)
            {
                this._301950085btnInvite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInvite", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnFinishQuest() : StandardButton
        {
            return this._1953015789btnFinishQuest;
        }// end function

        public function get rewardOrnamentalLeft() : Image
        {
            return this._853385749rewardOrnamentalLeft;
        }// end function

        public function set btnCancelQuest(param1:StandardButton) : void
        {
            var _loc_2:* = this._577581428btnCancelQuest;
            if (_loc_2 !== param1)
            {
                this._577581428btnCancelQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCancelQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnShowDetails(param1:StandardButton) : void
        {
            var _loc_2:* = this._1342136183btnShowDetails;
            if (_loc_2 !== param1)
            {
                this._1342136183btnShowDetails = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnShowDetails", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFinishQuest(param1:StandardButton) : void
        {
            var _loc_2:* = this._1953015789btnFinishQuest;
            if (_loc_2 !== param1)
            {
                this._1953015789btnFinishQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFinishQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function set rewardsTitle(param1:Label) : void
        {
            var _loc_2:* = this._1666485868rewardsTitle;
            if (_loc_2 !== param1)
            {
                this._1666485868rewardsTitle = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardsTitle", _loc_2, param1));
            }
            return;
        }// end function

        public function set rewardOrnamentalLeft(param1:Image) : void
        {
            var _loc_2:* = this._853385749rewardOrnamentalLeft;
            if (_loc_2 !== param1)
            {
                this._853385749rewardOrnamentalLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardOrnamentalLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function set todoText(param1:Text) : void
        {
            var _loc_2:* = this._1295741293todoText;
            if (_loc_2 !== param1)
            {
                this._1295741293todoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "todoText", _loc_2, param1));
            }
            return;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get detailsHeadline() : CustomText
        {
            return this._1328577994detailsHeadline;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set list(param1:GroupedQuestList) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        public function get sparkleAnim() : BatchedSpriteLibAnimation
        {
            return this._222722119sparkleAnim;
        }// end function

        public function get btnVisit() : StandardButton
        {
            return this._2099804239btnVisit;
        }// end function

        public function set background(param1:Canvas) : void
        {
            var _loc_2:* = this._1332194002background;
            if (_loc_2 !== param1)
            {
                this._1332194002background = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "background", _loc_2, param1));
            }
            return;
        }// end function

        public function get footerButtons() : HBox
        {
            return this._779276954footerButtons;
        }// end function

        public function get backgroundFooter() : Canvas
        {
            return this._1332141161backgroundFooter;
        }// end function

        public function get adventureOptions() : Canvas
        {
            return this._1316820334adventureOptions;
        }// end function

        public function set selectedIcon(param1:Image) : void
        {
            var _loc_2:* = this._1754800716selectedIcon;
            if (_loc_2 !== param1)
            {
                this._1754800716selectedIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnCancelAdventure(param1:StandardButton) : void
        {
            var _loc_2:* = this._1681770426btnCancelAdventure;
            if (_loc_2 !== param1)
            {
                this._1681770426btnCancelAdventure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCancelAdventure", _loc_2, param1));
            }
            return;
        }// end function

        public function get adventureTodo() : Canvas
        {
            return this._542559094adventureTodo;
        }// end function

        public function set btnOK(param1:StandardButton) : void
        {
            var _loc_2:* = this._94069048btnOK;
            if (_loc_2 !== param1)
            {
                this._94069048btnOK = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnOK", _loc_2, param1));
            }
            return;
        }// end function

        public function set detailsHeadline(param1:CustomText) : void
        {
            var _loc_2:* = this._1328577994detailsHeadline;
            if (_loc_2 !== param1)
            {
                this._1328577994detailsHeadline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "detailsHeadline", _loc_2, param1));
            }
            return;
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

        public function get upperContent() : Canvas
        {
            return this._443164297upperContent;
        }// end function

        public function set btnSendArmy(param1:StandardButton) : void
        {
            var _loc_2:* = this._1268262975btnSendArmy;
            if (_loc_2 !== param1)
            {
                this._1268262975btnSendArmy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSendArmy", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnCancelQuest() : StandardButton
        {
            return this._577581428btnCancelQuest;
        }// end function

        private function _QuestBook_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:QuestBook;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._QuestBook_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_QuestBookWatcherSetupUtil");
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

        public function get todoText() : Text
        {
            return this._1295741293todoText;
        }// end function

        public function get rewardsTitle() : Label
        {
            return this._1666485868rewardsTitle;
        }// end function

        public function set rewardOrnamentalRight(param1:Image) : void
        {
            var _loc_2:* = this._690815438rewardOrnamentalRight;
            if (_loc_2 !== param1)
            {
                this._690815438rewardOrnamentalRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardOrnamentalRight", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnInvite() : StandardButton
        {
            return this._301950085btnInvite;
        }// end function

        public function get btnShowDetails() : StandardButton
        {
            return this._1342136183btnShowDetails;
        }// end function

        public function set triggers(param1:List) : void
        {
            var _loc_2:* = this._1503093179triggers;
            if (_loc_2 !== param1)
            {
                this._1503093179triggers = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "triggers", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnVisit(param1:StandardButton) : void
        {
            var _loc_2:* = this._2099804239btnVisit;
            if (_loc_2 !== param1)
            {
                this._2099804239btnVisit = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnVisit", _loc_2, param1));
            }
            return;
        }// end function

        public function set sparkleAnim(param1:BatchedSpriteLibAnimation) : void
        {
            var _loc_2:* = this._222722119sparkleAnim;
            if (_loc_2 !== param1)
            {
                this._222722119sparkleAnim = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "sparkleAnim", _loc_2, param1));
            }
            return;
        }// end function

        public function get list() : GroupedQuestList
        {
            return this._3322014list;
        }// end function

        public function set headline(param1:Label) : void
        {
            var _loc_2:* = this._1115058732headline;
            if (_loc_2 !== param1)
            {
                this._1115058732headline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headline", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnInstantFinish(param1:StandardButton) : void
        {
            var _loc_2:* = this._1253431512btnInstantFinish;
            if (_loc_2 !== param1)
            {
                this._1253431512btnInstantFinish = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInstantFinish", _loc_2, param1));
            }
            return;
        }// end function

        private function _QuestBook_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestBook");
            _loc_1 = this.triggers.dataProvider.length > 2 ? (1) : (18);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Rewards");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Visit");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendArmy");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ShowAdventureDetails");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventureInvitePlayer");
            _loc_1 = gAssetManager.GetClass("ButtonIconInstant");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestFinish");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CancelAdventure");
            return;
        }// end function

        public function get btnCancelAdventure() : StandardButton
        {
            return this._1681770426btnCancelAdventure;
        }// end function

        public function get selectedIcon() : Image
        {
            return this._1754800716selectedIcon;
        }// end function

        public function get triggers() : List
        {
            return this._1503093179triggers;
        }// end function

        public function set rewardsList(param1:QuestRewardList) : void
        {
            var _loc_2:* = this._915835362rewardsList;
            if (_loc_2 !== param1)
            {
                this._915835362rewardsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnSendArmy() : StandardButton
        {
            return this._1268262975btnSendArmy;
        }// end function

        private function _QuestBook_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set backgroundFooter(param1:Canvas) : void
        {
            var _loc_2:* = this._1332141161backgroundFooter;
            if (_loc_2 !== param1)
            {
                this._1332141161backgroundFooter = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "backgroundFooter", _loc_2, param1));
            }
            return;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function get rewardOrnamentalRight() : Image
        {
            return this._690815438rewardOrnamentalRight;
        }// end function

        public function get btnInstantFinish() : StandardButton
        {
            return this._1253431512btnInstantFinish;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function set footerButtons(param1:HBox) : void
        {
            var _loc_2:* = this._779276954footerButtons;
            if (_loc_2 !== param1)
            {
                this._779276954footerButtons = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "footerButtons", _loc_2, param1));
            }
            return;
        }// end function

        public function set adventureOptions(param1:Canvas) : void
        {
            var _loc_2:* = this._1316820334adventureOptions;
            if (_loc_2 !== param1)
            {
                this._1316820334adventureOptions = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "adventureOptions", _loc_2, param1));
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function get rewardsList() : QuestRewardList
        {
            return this._915835362rewardsList;
        }// end function

        public function set adventureTodo(param1:Canvas) : void
        {
            var _loc_2:* = this._542559094adventureTodo;
            if (_loc_2 !== param1)
            {
                this._542559094adventureTodo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "adventureTodo", _loc_2, param1));
            }
            return;
        }// end function

        public function set upperContent(param1:Canvas) : void
        {
            var _loc_2:* = this._443164297upperContent;
            if (_loc_2 !== param1)
            {
                this._443164297upperContent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "upperContent", _loc_2, param1));
            }
            return;
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

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        private function _QuestBook_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                this.setStyle("showEffect", param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestBook");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "headline.text");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.dataProvider.length > 2 ? (1) : (18);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "triggers.right");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Rewards");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "rewardsTitle.text");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Visit");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnVisit.label");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendArmy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnSendArmy.label = param1;
                return;
            }// end function
            , "btnSendArmy.label");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ShowAdventureDetails");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnShowDetails.label = param1;
                return;
            }// end function
            , "btnShowDetails.label");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "AdventureInvitePlayer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnInvite.label = param1;
                return;
            }// end function
            , "btnInvite.label");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconInstant");
            }// end function
            , function (param1:Class) : void
            {
                btnInstantFinish.setStyle("icon", param1);
                return;
            }// end function
            , "btnInstantFinish.icon");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestFinish");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnFinishQuest.label");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnCancelQuest.label = param1;
                return;
            }// end function
            , "btnCancelQuest.label");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnOK.label");
            result[12] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "CancelAdventure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnCancelAdventure.label");
            result[13] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
