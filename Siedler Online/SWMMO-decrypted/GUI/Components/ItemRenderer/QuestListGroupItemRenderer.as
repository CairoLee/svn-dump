package GUI.Components.ItemRenderer
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class QuestListGroupItemRenderer extends Canvas implements IBindingClient
    {
        private var _110371416title:String;
        private var _96634189empty:CustomText;
        private var _1419980774emptyText:String;
        private var _3322014list:VBox;
        var _watchers:Array;
        private var _1880183383collapsed:Boolean = false;
        private var _1289167206expand:Sequence;
        private var _632085587collapse:Sequence;
        public var _QuestListGroupItemRenderer_Fade2:Fade;
        public var _QuestListGroupItemRenderer_Fade1:Fade;
        public var _QuestListGroupItemRenderer_Resize1:Resize;
        public var _QuestListGroupItemRenderer_Resize2:Resize;
        private var _itemRendererMap:Object;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _451513404expandToHeight:int;
        private var _2097958236btnTitle:StandardButton;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function QuestListGroupItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:159, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnTitle", events:{click:"__btnTitle_click"}, stylesFactory:function () : void
                {
                    this.paddingLeft = 5;
                    this.paddingRight = 5;
                    this.left = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {labelPlacement:"left", width:159};
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"empty", stylesFactory:function () : void
                {
                    this.left = "5";
                    this.right = "5";
                    this.top = "32";
                    this.fontWeight = "normal";
                    this.textAlign = "center";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {selectable:false};
                }// end function
                }), new UIComponentDescriptor({type:VBox, id:"list", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.top = "32";
                    this.bottom = "0";
                    this.verticalGap = 1;
                    return;
                }// end function
                })]};
            }// end function
            });
            this._itemRendererMap = {};
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 159;
            this.clipContent = false;
            this._QuestListGroupItemRenderer_Sequence2_i();
            this._QuestListGroupItemRenderer_Sequence1_i();
            return;
        }// end function

        override public function initialize() : void
        {
            var target:QuestListGroupItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._QuestListGroupItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_QuestListGroupItemRendererWatcherSetupUtil");
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

        private function _QuestListGroupItemRenderer_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this._QuestListGroupItemRenderer_Fade1 = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 300;
            BindingManager.executeBindings(this, "_QuestListGroupItemRenderer_Fade1", this._QuestListGroupItemRenderer_Fade1);
            return _loc_1;
        }// end function

        public function get list() : VBox
        {
            return this._3322014list;
        }// end function

        private function _QuestListGroupItemRenderer_Resize1_i() : Resize
        {
            var _loc_1:* = new Resize();
            this._QuestListGroupItemRenderer_Resize1 = _loc_1;
            _loc_1.duration = 300;
            BindingManager.executeBindings(this, "_QuestListGroupItemRenderer_Resize1", this._QuestListGroupItemRenderer_Resize1);
            return _loc_1;
        }// end function

        private function _QuestListGroupItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Number
            {
                return expandToHeight;
            }// end function
            , function (param1:Number) : void
            {
                null.heightTo = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Resize1.heightTo");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return this;
            }// end function
            , function (param1:Object) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Resize1.target");
            result[1] = binding;
            binding = new Binding(this, function () : Array
            {
                return [list, empty];
            }// end function
            , function (param1:Array) : void
            {
                _QuestListGroupItemRenderer_Fade1.targets = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Fade1.targets");
            result[2] = binding;
            binding = new Binding(this, function () : Array
            {
                return [list, empty];
            }// end function
            , function (param1:Array) : void
            {
                _QuestListGroupItemRenderer_Fade2.targets = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Fade2.targets");
            result[3] = binding;
            binding = new Binding(this, function () : Number
            {
                return null + btnTitle.height;
            }// end function
            , function (param1:Number) : void
            {
                _QuestListGroupItemRenderer_Resize2.heightTo = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Resize2.heightTo");
            result[4] = binding;
            binding = new Binding(this, function () : Object
            {
                return this;
            }// end function
            , function (param1:Object) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_QuestListGroupItemRenderer_Resize2.target");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnTitle.label = param1;
                return;
            }// end function
            , "btnTitle.label");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(collapsed ? ("ArrowSmallSUp") : ("ArrowSmallNUp"));
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnTitle.icon");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                empty.text = param1;
                return;
            }// end function
            , "empty.text");
            result[8] = binding;
            return result;
        }// end function

        public function set empty(param1:CustomText) : void
        {
            var _loc_2:* = this._96634189empty;
            if (_loc_2 !== param1)
            {
                this._96634189empty = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "empty", _loc_2, param1));
            }
            return;
        }// end function

        public function get collapse() : Sequence
        {
            return this._632085587collapse;
        }// end function

        private function _QuestListGroupItemRenderer_Sequence1_i() : Sequence
        {
            var _loc_1:* = new Sequence();
            this.expand = _loc_1;
            _loc_1.children = [this._QuestListGroupItemRenderer_Resize1_i(), this._QuestListGroupItemRenderer_Fade1_i()];
            return _loc_1;
        }// end function

        public function set title(param1:String) : void
        {
            var _loc_2:* = this._110371416title;
            if (_loc_2 !== param1)
            {
                this._110371416title = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "title", _loc_2, param1));
            }
            return;
        }// end function

        public function set expand(param1:Sequence) : void
        {
            var _loc_2:* = this._1289167206expand;
            if (_loc_2 !== param1)
            {
                this._1289167206expand = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "expand", _loc_2, param1));
            }
            return;
        }// end function

        private function set collapsed(param1:Boolean) : void
        {
            var _loc_2:* = this._1880183383collapsed;
            if (_loc_2 !== param1)
            {
                this._1880183383collapsed = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "collapsed", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnTitle(param1:StandardButton) : void
        {
            var _loc_2:* = this._2097958236btnTitle;
            if (_loc_2 !== param1)
            {
                this._2097958236btnTitle = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnTitle", _loc_2, param1));
            }
            return;
        }// end function

        public function set emptyText(param1:String) : void
        {
            var _loc_2:* = this._1419980774emptyText;
            if (_loc_2 !== param1)
            {
                this._1419980774emptyText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "emptyText", _loc_2, param1));
            }
            return;
        }// end function

        public function set list(param1:VBox) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnTitle_click(event:MouseEvent) : void
        {
            this.expandCollapse();
            return;
        }// end function

        private function display(event:Event = null) : void
        {
            var _loc_3:Object = null;
            var _loc_4:QuestListItemRenderer = null;
            var _loc_5:String = null;
            removeEventListener(FlexEvent.CREATION_COMPLETE, this.display);
            if (!data)
            {
                return;
            }
            this.expandToHeight = 32 + (this.list.numChildren > 0 ? (this.list.height) : (this.empty.height));
            var _loc_2:Object = {};
            for each (_loc_3 in data as Array)
            {
                
                if (_loc_3 is dAdventureClientInfoVO)
                {
                    _loc_5 = _loc_3.adventureName;
                }
                else if (_loc_3 is cAdventureDefinition)
                {
                    _loc_5 = _loc_3.mName_string;
                }
                else if (_loc_3 is dQuestElementVO)
                {
                    _loc_5 = _loc_3.mQuestName_string;
                }
                if (this._itemRendererMap[_loc_5])
                {
                    _loc_4 = this._itemRendererMap[_loc_5];
                }
                else
                {
                    _loc_4 = new QuestListItemRenderer();
                    this._itemRendererMap[_loc_5] = _loc_4;
                    this.list.addChild(_loc_4);
                }
                _loc_4.data = _loc_3;
                _loc_2[_loc_5] = _loc_3;
            }
            for (_loc_5 in this._itemRendererMap)
            {
                
                if (!_loc_2[_loc_5])
                {
                    this.list.removeChild(this._itemRendererMap[_loc_5]);
                    delete this._itemRendererMap[_loc_5];
                }
            }
            this.list.visible = this.list.numChildren > 0;
            this.empty.visible = this.list.numChildren == 0;
            return;
        }// end function

        public function get expandToHeight() : int
        {
            return this._451513404expandToHeight;
        }// end function

        public function get empty() : CustomText
        {
            return this._96634189empty;
        }// end function

        public function get expand() : Sequence
        {
            return this._1289167206expand;
        }// end function

        private function _QuestListGroupItemRenderer_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this._QuestListGroupItemRenderer_Fade2 = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 300;
            BindingManager.executeBindings(this, "_QuestListGroupItemRenderer_Fade2", this._QuestListGroupItemRenderer_Fade2);
            return _loc_1;
        }// end function

        private function get collapsed() : Boolean
        {
            return this._1880183383collapsed;
        }// end function

        public function get title() : String
        {
            return this._110371416title;
        }// end function

        public function get btnTitle() : StandardButton
        {
            return this._2097958236btnTitle;
        }// end function

        private function _QuestListGroupItemRenderer_Resize2_i() : Resize
        {
            var _loc_1:* = new Resize();
            this._QuestListGroupItemRenderer_Resize2 = _loc_1;
            _loc_1.duration = 300;
            BindingManager.executeBindings(this, "_QuestListGroupItemRenderer_Resize2", this._QuestListGroupItemRenderer_Resize2);
            return _loc_1;
        }// end function

        public function get emptyText() : String
        {
            return this._1419980774emptyText;
        }// end function

        public function set collapse(param1:Sequence) : void
        {
            var _loc_2:* = this._632085587collapse;
            if (_loc_2 !== param1)
            {
                this._632085587collapse = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "collapse", _loc_2, param1));
            }
            return;
        }// end function

        private function _QuestListGroupItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.expandToHeight;
            _loc_1 = this;
            _loc_1 = [this.list, this.empty];
            _loc_1 = [this.list, this.empty];
            _loc_1 = this.btnTitle.x + this.btnTitle.height;
            _loc_1 = this;
            _loc_1 = this.title;
            _loc_1 = gAssetManager.GetClass(this.collapsed ? ("ArrowSmallSUp") : ("ArrowSmallNUp"));
            _loc_1 = this.emptyText;
            return;
        }// end function

        private function expandCollapse() : void
        {
            this.collapsed = !this.collapsed;
            if (this.collapsed)
            {
                this.collapse.play();
            }
            else
            {
                this.expand.play();
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (this.list)
            {
                this.display();
            }
            else
            {
                addEventListener(FlexEvent.CREATION_COMPLETE, this.display);
            }
            return;
        }// end function

        private function _QuestListGroupItemRenderer_Sequence2_i() : Sequence
        {
            var _loc_1:* = new Sequence();
            this.collapse = _loc_1;
            _loc_1.children = [this._QuestListGroupItemRenderer_Fade2_i(), this._QuestListGroupItemRenderer_Resize2_i()];
            return _loc_1;
        }// end function

        public function set expandToHeight(param1:int) : void
        {
            var _loc_2:* = this._451513404expandToHeight;
            if (_loc_2 !== param1)
            {
                this._451513404expandToHeight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "expandToHeight", _loc_2, param1));
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
