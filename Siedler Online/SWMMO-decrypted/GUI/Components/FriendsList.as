package GUI.Components
{
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class FriendsList extends HBox implements IBindingClient
    {
        private var _799977140optionButtons:FriendsListButtonBar;
        private var _3322014list:HorizontalList;
        var _watchers:Array;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        public var _FriendsList_Button1:Button;
        public var _FriendsList_Button2:Button;
        public var _FriendsList_Button3:Button;
        public var _FriendsList_Button4:Button;
        public var _FriendsList_Button6:Button;
        public var _FriendsList_Button5:Button;
        private var itemsPerPage:int;
        var _bindings:Array;
        private var _989997943filterSelector:FriendsListFilterSelector;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function FriendsList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:91, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                {
                    return {percentHeight:100, percentWidth:100, styleName:"friendsListBackground"};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {percentHeight:100, width:150, styleName:"friendsListControllsLeft", childDescriptors:[new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                    {
                        null.right = this;
                        this.verticalCenter = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {width:31, height:79, styleName:"friendsListArrowFrame", childDescriptors:[new UIComponentDescriptor({type:Button, id:"_FriendsList_Button1", events:{click:"___FriendsList_Button1_click"}, propertiesFactory:function () : Object
                        {
                            return {width:25, height:23};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"_FriendsList_Button2", events:{click:"___FriendsList_Button2_click"}, propertiesFactory:function () : Object
                        {
                            return {null:25, height:23};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"_FriendsList_Button3", events:{click:"___FriendsList_Button3_click"}, propertiesFactory:function () : Object
                        {
                            return {null:null, height:23};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:FriendsListButtonBar, id:"optionButtons", propertiesFactory:function () : Object
                {
                    return {null:null, width:71, styleName:"friendsList"};
                }// end function
                }), new UIComponentDescriptor({type:HorizontalList, id:"list", events:{creationComplete:"__list_creationComplete", focusIn:"__list_focusIn"}, propertiesFactory:function () : Object
                {
                    return {null:null, itemRenderer:_FriendsList_ClassFactory1_c(), nullItemRenderer:_FriendsList_ClassFactory2_c(), styleName:"friendsList", rowHeight:91, selectable:false, width:639, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:FriendsListFilterSelector, id:"filterSelector", propertiesFactory:function () : Object
                {
                    return {percentHeight:100, width:71, styleName:"friendsList"};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {percentHeight:100, width:150, styleName:"friendsListControllsRight", childDescriptors:[new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                    {
                        this.left = "5";
                        this.verticalCenter = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {width:31, height:79, styleName:"friendsListArrowFrame", childDescriptors:[new UIComponentDescriptor({type:Button, id:"_FriendsList_Button4", events:{click:"___FriendsList_Button4_click"}, propertiesFactory:function () : Object
                        {
                            return {width:25, height:23};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"_FriendsList_Button5", events:{click:"___FriendsList_Button5_click"}, propertiesFactory:function () : Object
                        {
                            return {width:25, height:23};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"_FriendsList_Button6", events:{click:"___FriendsList_Button6_click"}, propertiesFactory:function () : Object
                        {
                            return {width:25, height:23};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                {
                    return {null:100, percentWidth:100, styleName:"friendsListBackground"};
                }// end function
                })]};
            }// end function
            });
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
                this.horizontalGap = 0;
                return;
            }// end function
            ;
            this.height = 91;
            this.percentWidth = 100;
            return;
        }// end function

        public function ___FriendsList_Button6_click(event:MouseEvent) : void
        {
            this.EndRight();
            return;
        }// end function

        private function _FriendsList_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Boolean
            {
                return null.horizontalScrollPosition > 0;
            }// end function
            , function (param1:Boolean) : void
            {
                _FriendsList_Button1.enabled = param1;
                return;
            }// end function
            , "_FriendsList_Button1.enabled");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeft");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button1.upSkin");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button1.overSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeftHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button1.downSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button1.disabledSkin");
            result[4] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null > 0;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "_FriendsList_Button2.enabled");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeftScroll");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button2.setStyle("upSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button2.upSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button2.overSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeftScrollHighlight");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button2.setStyle("downSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button2.downSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftScrollDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button2.disabledSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.horizontalScrollPosition > 0;
            }// end function
            , function (param1:Boolean) : void
            {
                _FriendsList_Button3.enabled = param1;
                return;
            }// end function
            , "_FriendsList_Button3.enabled");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftEnd");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button3.upSkin");
            result[11] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftEndHighlight");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button3.setStyle("overSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button3.overSkin");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftEndHighlight");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button3.setStyle("downSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button3.downSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button3.disabledSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return list.maxHorizontalScrollPosition > list.horizontalScrollPosition;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "_FriendsList_Button4.enabled");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowRight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button4.upSkin");
            result[16] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button4.overSkin");
            result[17] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button4.setStyle("downSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button4.downSkin");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightDisabled");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button4.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button4.disabledSkin");
            result[19] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return list.horizontalScrollPosition < null;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "_FriendsList_Button5.enabled");
            result[20] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button5.upSkin");
            result[21] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightScrollHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button5.overSkin");
            result[22] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightScrollHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button5.downSkin");
            result[23] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightScrollDisabled");
            }// end function
            , function (param1:Class) : void
            {
                _FriendsList_Button5.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button5.disabledSkin");
            result[24] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return list.maxHorizontalScrollPosition > list.horizontalScrollPosition;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "_FriendsList_Button6.enabled");
            result[25] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowRightEnd");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button6.upSkin");
            result[26] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowRightEndHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "_FriendsList_Button6.overSkin");
            result[27] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button6.downSkin");
            result[28] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightEndDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "_FriendsList_Button6.disabledSkin");
            result[29] = binding;
            return result;
        }// end function

        private function _FriendsList_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.list.horizontalScrollPosition > 0;
            _loc_1 = gAssetManager.GetClass("ArrowLeft");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftDisabled");
            _loc_1 = this.list.horizontalScrollPosition > 0;
            _loc_1 = gAssetManager.GetClass("ArrowLeftScroll");
            _loc_1 = gAssetManager.GetClass("ArrowLeftScrollHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftScrollHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftScrollDisabled");
            _loc_1 = this.list.horizontalScrollPosition > 0;
            _loc_1 = gAssetManager.GetClass("ArrowLeftEnd");
            _loc_1 = gAssetManager.GetClass("ArrowLeftEndHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftEndHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftEndDisabled");
            _loc_1 = this.list.maxHorizontalScrollPosition > this.list.horizontalScrollPosition;
            _loc_1 = gAssetManager.GetClass("ArrowRight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightDisabled");
            _loc_1 = this.list.maxHorizontalScrollPosition > this.list.horizontalScrollPosition;
            _loc_1 = gAssetManager.GetClass("ArrowRightScroll");
            _loc_1 = gAssetManager.GetClass("ArrowRightScrollHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightScrollHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightScrollDisabled");
            _loc_1 = this.list.maxHorizontalScrollPosition > this.list.horizontalScrollPosition;
            _loc_1 = gAssetManager.GetClass("ArrowRightEnd");
            _loc_1 = gAssetManager.GetClass("ArrowRightEndHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightEndHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightEndDisabled");
            return;
        }// end function

        public function ___FriendsList_Button4_click(event:MouseEvent) : void
        {
            this.StepRight();
            return;
        }// end function

        private function StepRight() : void
        {
            if (this.list.horizontalScrollPosition < this.list.maxHorizontalScrollPosition)
            {
                (this.list.horizontalScrollPosition + 1);
            }
            return;
        }// end function

        private function StepLeft() : void
        {
            if (this.list.horizontalScrollPosition > 0)
            {
                (this.list.horizontalScrollPosition - 1);
            }
            return;
        }// end function

        public function get list() : HorizontalList
        {
            return this._3322014list;
        }// end function

        override public function initialize() : void
        {
            var target:FriendsList;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FriendsList_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_FriendsListWatcherSetupUtil");
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

        private function EndRight() : void
        {
            this.list.horizontalScrollPosition = this.list.maxHorizontalScrollPosition;
            return;
        }// end function

        public function set optionButtons(param1:FriendsListButtonBar) : void
        {
            var _loc_2:* = this._799977140optionButtons;
            if (_loc_2 !== param1)
            {
                this._799977140optionButtons = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "optionButtons", _loc_2, param1));
            }
            return;
        }// end function

        private function PageRight() : void
        {
            if (this.list.horizontalScrollPosition + this.itemsPerPage < this.list.maxHorizontalScrollPosition)
            {
                this.list.horizontalScrollPosition = this.list.horizontalScrollPosition + this.itemsPerPage;
            }
            else
            {
                this.EndRight();
            }
            return;
        }// end function

        private function Init() : void
        {
            this.itemsPerPage = this.list.width / (this.list.itemRenderer.newInstance() as Canvas).width;
            return;
        }// end function

        private function _FriendsList_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = FriendsListItemRenderer;
            return _loc_1;
        }// end function

        public function set list(param1:HorizontalList) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        public function ___FriendsList_Button1_click(event:MouseEvent) : void
        {
            this.StepLeft();
            return;
        }// end function

        public function ___FriendsList_Button3_click(event:MouseEvent) : void
        {
            this.EndLeft();
            return;
        }// end function

        public function ___FriendsList_Button5_click(event:MouseEvent) : void
        {
            this.PageRight();
            return;
        }// end function

        public function get optionButtons() : FriendsListButtonBar
        {
            return this._799977140optionButtons;
        }// end function

        public function __list_focusIn(event:FocusEvent) : void
        {
            this.setFocus();
            return;
        }// end function

        private function PageLeft() : void
        {
            if (this.list.horizontalScrollPosition - this.itemsPerPage > 0)
            {
                this.list.horizontalScrollPosition = this.list.horizontalScrollPosition - this.itemsPerPage;
            }
            else
            {
                this.EndLeft();
            }
            return;
        }// end function

        public function __list_creationComplete(event:FlexEvent) : void
        {
            this.Init();
            return;
        }// end function

        private function EndLeft() : void
        {
            this.list.horizontalScrollPosition = 0;
            return;
        }// end function

        public function set filterSelector(param1:FriendsListFilterSelector) : void
        {
            var _loc_2:* = this._989997943filterSelector;
            if (_loc_2 !== param1)
            {
                this._989997943filterSelector = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "filterSelector", _loc_2, param1));
            }
            return;
        }// end function

        public function get filterSelector() : FriendsListFilterSelector
        {
            return this._989997943filterSelector;
        }// end function

        private function _FriendsList_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = FriendsListNullItemRenderer;
            return _loc_1;
        }// end function

        public function ___FriendsList_Button2_click(event:MouseEvent) : void
        {
            this.PageLeft();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
