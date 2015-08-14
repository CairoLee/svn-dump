package mx.controls.menuClasses
{
    import flash.display.*;
    import mx.controls.*;
    import mx.controls.menuClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class MenuBarItem extends UIComponent implements IMenuBarItemRenderer, IFontContextComponent
    {
        private var _data:Object;
        private var _menuBarItemIndex:int = -1;
        private var leftMargin:int = 20;
        var currentSkin:IFlexDisplayObject;
        private var _dataProvider:Object;
        var skinName:String = "itemSkin";
        private var checkedDefaultSkin:Boolean = false;
        private var enabledChanged:Boolean = false;
        private var _menuBarItemState:String;
        private var defaultSkinUsesStates:Boolean = false;
        protected var label:IUITextField;
        private var _menuBar:MenuBar;
        protected var icon:IFlexDisplayObject;
        static const VERSION:String = "3.5.0.12683";

        public function MenuBarItem()
        {
            mouseChildren = false;
            return;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            if (super.enabled == param1)
            {
                return;
            }
            super.enabled = param1;
            enabledChanged = true;
            invalidateProperties();
            return;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            var styleDeclaration:* = new CSSStyleDeclaration();
            styleDeclaration.factory = function () : void
            {
                this.borderStyle = "none";
                return;
            }// end function
            ;
            createLabel(-1);
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                return super.baselinePosition;
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            return label.y + label.baselinePosition;
        }// end function

        public function get menuBarItemIndex() : int
        {
            return _menuBarItemIndex;
        }// end function

        public function get menuBar() : MenuBar
        {
            return _menuBar;
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

        function getLabel() : IUITextField
        {
            return label;
        }// end function

        public function set fontContext(param1:IFlexModuleFactory) : void
        {
            this.moduleFactory = param1;
            return;
        }// end function

        public function get dataProvider() : Object
        {
            return _dataProvider;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:Class = null;
            var _loc_2:int = 0;
            var _loc_3:String = null;
            super.commitProperties();
            if (hasFontContextChanged() && label != null)
            {
                _loc_2 = getChildIndex(DisplayObject(label));
                removeLabel();
                createLabel(_loc_2);
            }
            if (enabledChanged)
            {
                enabledChanged = false;
                if (label)
                {
                    label.enabled = enabled;
                }
                if (!enabled)
                {
                    menuBarItemState = "itemUpSkin";
                }
            }
            if (icon)
            {
                removeChild(DisplayObject(icon));
                icon = null;
            }
            if (_data)
            {
                _loc_1 = menuBar.itemToIcon(data);
                if (_loc_1)
                {
                    icon = new _loc_1;
                    addChild(DisplayObject(icon));
                }
                label.visible = true;
                if (menuBar.labelFunction != null)
                {
                    _loc_3 = menuBar.labelFunction(_data);
                }
                if (_loc_3 == null)
                {
                    _loc_3 = menuBar.itemToLabel(_data);
                }
                label.text = _loc_3;
                label.enabled = enabled;
            }
            else
            {
                label.text = " ";
            }
            invalidateDisplayList();
            return;
        }// end function

        private function viewSkin(param1:String) : void
        {
            var _loc_3:IFlexDisplayObject = null;
            var _loc_2:* = Class(getStyle(param1));
            var _loc_4:String = "";
            if (!_loc_2)
            {
                _loc_2 = Class(getStyle(skinName));
                if (param1 == "itemDownSkin")
                {
                    _loc_4 = "down";
                }
                else if (param1 == "itemOverSkin")
                {
                    _loc_4 = "over";
                }
                else if (param1 == "itemUpSkin")
                {
                    _loc_4 = "up";
                }
                if (defaultSkinUsesStates)
                {
                    param1 = skinName;
                }
                if (!checkedDefaultSkin && _loc_2)
                {
                    _loc_3 = IFlexDisplayObject(new _loc_2);
                    if (!(_loc_3 is IProgrammaticSkin) && _loc_3 is IStateClient)
                    {
                        defaultSkinUsesStates = true;
                        param1 = skinName;
                    }
                    if (_loc_3)
                    {
                        checkedDefaultSkin = true;
                    }
                }
            }
            _loc_3 = IFlexDisplayObject(getChildByName(param1));
            if (!_loc_3)
            {
                if (_loc_2)
                {
                    _loc_3 = new _loc_2;
                    DisplayObject(_loc_3).name = param1;
                    if (_loc_3 is ISimpleStyleClient)
                    {
                        ISimpleStyleClient(_loc_3).styleName = this;
                    }
                    addChildAt(DisplayObject(_loc_3), 0);
                }
            }
            _loc_3.setActualSize(unscaledWidth, unscaledHeight);
            if (currentSkin)
            {
                currentSkin.visible = false;
            }
            if (_loc_3)
            {
                _loc_3.visible = true;
            }
            currentSkin = _loc_3;
            if (defaultSkinUsesStates && currentSkin is IStateClient)
            {
                IStateClient(currentSkin).currentState = _loc_4;
            }
            return;
        }// end function

        public function set menuBarItemState(param1:String) : void
        {
            _menuBarItemState = param1;
            viewSkin(_menuBarItemState);
            return;
        }// end function

        public function set menuBarItemIndex(param1:int) : void
        {
            _menuBarItemIndex = param1;
            return;
        }// end function

        function removeLabel() : void
        {
            if (label)
            {
                removeChild(DisplayObject(label));
                label = null;
            }
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            invalidateProperties();
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        override protected function measure() : void
        {
            super.measure();
            if (icon && leftMargin < icon.measuredWidth)
            {
                leftMargin = icon.measuredWidth;
            }
            measuredWidth = label.getExplicitOrMeasuredWidth() + leftMargin;
            measuredHeight = label.getExplicitOrMeasuredHeight();
            if (icon && icon.measuredHeight > measuredHeight)
            {
                measuredHeight = icon.measuredHeight + 2;
            }
            return;
        }// end function

        function createLabel(param1:int) : void
        {
            if (!label)
            {
                label = IUITextField(createInFontContext(UITextField));
                label.styleName = this;
                label.selectable = false;
                if (param1 == -1)
                {
                    addChild(DisplayObject(label));
                }
                else
                {
                    addChildAt(DisplayObject(label), param1);
                }
            }
            return;
        }// end function

        public function get fontContext() : IFlexModuleFactory
        {
            return moduleFactory;
        }// end function

        public function set menuBar(param1:MenuBar) : void
        {
            _menuBar = param1;
            return;
        }// end function

        public function get menuBarItemState() : String
        {
            return _menuBarItemState;
        }// end function

        public function set dataProvider(param1:Object) : void
        {
            _dataProvider = param1;
            invalidateProperties();
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            if (icon)
            {
                icon.x = (leftMargin - icon.measuredWidth) / 2;
                icon.setActualSize(icon.measuredWidth, icon.measuredHeight);
                label.x = leftMargin;
            }
            else
            {
                label.x = leftMargin / 2;
            }
            label.setActualSize(param1 - leftMargin, label.getExplicitOrMeasuredHeight());
            label.y = (param2 - label.height) / 2;
            if (icon)
            {
                icon.y = (param2 - icon.height) / 2;
            }
            menuBarItemState = "itemUpSkin";
            return;
        }// end function

    }
}
