package mx.controls.menuClasses
{
    import flash.display.*;
    import flash.utils.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;
    import mx.controls.menuClasses.*;
    import mx.core.*;
    import mx.events.*;

    public class MenuItemRenderer extends UIComponent implements IDataRenderer, IListItemRenderer, IMenuItemRenderer, IDropInListItemRenderer, IFontContextComponent
    {
        private var _data:Object;
        protected var branchIcon:IFlexDisplayObject;
        private var _listData:ListData;
        protected var typeIcon:IFlexDisplayObject;
        private var _menu:Menu;
        private var _icon:IFlexDisplayObject;
        protected var label:IUITextField;
        protected var separatorIcon:IFlexDisplayObject;
        static const VERSION:String = "3.5.0.12683";

        public function MenuItemRenderer()
        {
            return;
        }// end function

        public function get measuredTypeIconWidth() : Number
        {
            var _loc_2:Class = null;
            var _loc_3:IMenuDataDescriptor = null;
            var _loc_4:Boolean = false;
            var _loc_5:String = null;
            var _loc_6:Number = NaN;
            var _loc_1:* = getStyle("horizontalGap");
            if (typeIcon)
            {
                return typeIcon.measuredWidth + _loc_1;
            }
            if (_data)
            {
                _loc_3 = Menu(_listData.owner).dataDescriptor;
                _loc_4 = _loc_3.isEnabled(_data);
                _loc_5 = _loc_3.getType(_data);
                if (_loc_5)
                {
                    _loc_5 = _loc_5.toLowerCase();
                    if (_loc_5 == "radio")
                    {
                        _loc_2 = getStyle(_loc_4 ? ("radioIcon") : ("radioDisabledIcon"));
                    }
                    else if (_loc_5 == "check")
                    {
                        _loc_2 = getStyle(_loc_4 ? ("checkIcon") : ("checkDisabledIcon"));
                    }
                    if (_loc_2)
                    {
                        typeIcon = new _loc_2;
                        _loc_6 = typeIcon.measuredWidth;
                        typeIcon = null;
                        return _loc_6 + _loc_1;
                    }
                }
            }
            return 0;
        }// end function

        override public function get baselinePosition() : Number
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            return label.y + label.baselinePosition;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            createLabel(-1);
            return;
        }// end function

        public function get measuredBranchIconWidth() : Number
        {
            var _loc_1:* = getStyle("horizontalGap");
            return branchIcon ? (branchIcon.measuredWidth + _loc_1) : (0);
        }// end function

        public function get measuredIconWidth() : Number
        {
            var _loc_1:* = getStyle("horizontalGap");
            return _icon ? (_icon.measuredWidth + _loc_1) : (0);
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

        public function set menu(param1:Menu) : void
        {
            _menu = param1;
            return;
        }// end function

        public function set fontContext(param1:IFlexModuleFactory) : void
        {
            this.moduleFactory = param1;
            return;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:Class = null;
            var _loc_2:Class = null;
            var _loc_3:Class = null;
            var _loc_4:Class = null;
            var _loc_5:int = 0;
            var _loc_6:IMenuDataDescriptor = null;
            var _loc_7:Boolean = false;
            var _loc_8:String = null;
            var _loc_9:Object = null;
            var _loc_10:String = null;
            super.commitProperties();
            if (hasFontContextChanged() && label != null)
            {
                _loc_5 = getChildIndex(DisplayObject(label));
                removeLabel();
                createLabel(_loc_5);
            }
            if (_icon)
            {
                removeChild(DisplayObject(_icon));
                _icon = null;
            }
            if (typeIcon)
            {
                removeChild(DisplayObject(typeIcon));
                typeIcon = null;
            }
            if (separatorIcon)
            {
                removeChild(DisplayObject(separatorIcon));
                separatorIcon = null;
            }
            if (branchIcon)
            {
                removeChild(DisplayObject(branchIcon));
                branchIcon = null;
            }
            if (_data)
            {
                _loc_6 = Menu(_listData.owner).dataDescriptor;
                _loc_7 = _loc_6.isEnabled(_data);
                _loc_8 = _loc_6.getType(_data);
                if (_loc_8.toLowerCase() == "separator")
                {
                    label.text = "";
                    label.visible = false;
                    _loc_3 = getStyle("separatorSkin");
                    separatorIcon = new _loc_3;
                    addChild(DisplayObject(separatorIcon));
                    return;
                }
                label.visible = true;
                if (_listData.icon)
                {
                    _loc_9 = _listData.icon;
                    if (_loc_9 is Class)
                    {
                        _loc_1 = Class(_loc_9);
                    }
                    else if (_loc_9 is String)
                    {
                        _loc_1 = Class(getDefinitionByName(String(_loc_9)));
                    }
                    _icon = new _loc_1;
                    addChild(DisplayObject(_icon));
                }
                label.text = _listData.label;
                label.enabled = _loc_7;
                if (_loc_6.isToggled(_data))
                {
                    _loc_10 = _loc_6.getType(_data);
                    if (_loc_10)
                    {
                        _loc_10 = _loc_10.toLowerCase();
                        if (_loc_10 == "radio")
                        {
                            _loc_2 = getStyle(_loc_7 ? ("radioIcon") : ("radioDisabledIcon"));
                        }
                        else if (_loc_10 == "check")
                        {
                            _loc_2 = getStyle(_loc_7 ? ("checkIcon") : ("checkDisabledIcon"));
                        }
                        if (_loc_2)
                        {
                            typeIcon = new _loc_2;
                            addChild(DisplayObject(typeIcon));
                        }
                    }
                }
                if (_loc_6.isBranch(_data))
                {
                    _loc_4 = getStyle(_loc_7 ? ("branchIcon") : ("branchDisabledIcon"));
                    if (_loc_4)
                    {
                        branchIcon = new _loc_4;
                        addChild(DisplayObject(branchIcon));
                    }
                }
            }
            else
            {
                label.text = " ";
            }
            invalidateDisplayList();
            return;
        }// end function

        function getLabel() : IUITextField
        {
            return label;
        }// end function

        public function set listData(param1:BaseListData) : void
        {
            _listData = ListData(param1);
            invalidateProperties();
            return;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            super.styleChanged(param1);
            if (!param1 || param1 == "styleName" || param1.toLowerCase().indexOf("icon") != -1)
            {
                invalidateSize();
                invalidateDisplayList();
            }
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            invalidateProperties();
            invalidateSize();
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Boolean = false;
            var _loc_5:Number = NaN;
            var _loc_6:Number = NaN;
            super.measure();
            if (separatorIcon)
            {
                measuredWidth = separatorIcon.measuredWidth;
                measuredHeight = separatorIcon.measuredHeight;
                return;
            }
            if (_listData)
            {
                _loc_1 = MenuListData(_listData).maxMeasuredIconWidth;
                _loc_2 = MenuListData(_listData).maxMeasuredTypeIconWidth;
                _loc_3 = MenuListData(_listData).maxMeasuredBranchIconWidth;
                _loc_4 = MenuListData(_listData).useTwoColumns;
                _loc_5 = Math.max(getStyle("leftIconGap"), _loc_4 ? (_loc_1 + _loc_2) : (Math.max(_loc_1, _loc_2)));
                _loc_6 = Math.max(getStyle("rightIconGap"), _loc_3);
                if (isNaN(explicitWidth))
                {
                    measuredWidth = label.measuredWidth + _loc_5 + _loc_6 + 7;
                }
                else
                {
                    label.width = explicitWidth - _loc_5 - _loc_6;
                }
                measuredHeight = label.measuredHeight;
                if (_icon && _icon.measuredHeight > measuredHeight)
                {
                    measuredHeight = _icon.measuredHeight;
                }
                if (typeIcon && typeIcon.measuredHeight > measuredHeight)
                {
                    measuredHeight = typeIcon.measuredHeight;
                }
                if (branchIcon && branchIcon.measuredHeight > measuredHeight)
                {
                    measuredHeight = branchIcon.measuredHeight;
                }
            }
            return;
        }// end function

        public function get menu() : Menu
        {
            return _menu;
        }// end function

        public function get fontContext() : IFlexModuleFactory
        {
            return moduleFactory;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        function createLabel(param1:int) : void
        {
            if (!label)
            {
                label = IUITextField(createInFontContext(UITextField));
                label.styleName = this;
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

        protected function set icon(param1:IFlexDisplayObject) : void
        {
            _icon = param1;
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:Boolean = false;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:String = null;
            var _loc_10:Number = NaN;
            var _loc_11:Number = NaN;
            super.updateDisplayList(param1, param2);
            if (_listData)
            {
                if (Menu(_listData.owner).dataDescriptor.getType(_data).toLowerCase() == "separator")
                {
                    if (separatorIcon)
                    {
                        separatorIcon.x = 2;
                        separatorIcon.y = (param2 - separatorIcon.measuredHeight) / 2;
                        separatorIcon.setActualSize(param1 - 4, separatorIcon.measuredHeight);
                    }
                    return;
                }
                _loc_3 = MenuListData(_listData).maxMeasuredIconWidth;
                _loc_4 = MenuListData(_listData).maxMeasuredTypeIconWidth;
                _loc_5 = MenuListData(_listData).maxMeasuredBranchIconWidth;
                _loc_6 = MenuListData(_listData).useTwoColumns;
                _loc_7 = Math.max(getStyle("leftIconGap"), _loc_6 ? (_loc_3 + _loc_4) : (Math.max(_loc_3, _loc_4)));
                _loc_8 = Math.max(getStyle("rightIconGap"), _loc_5);
                if (_loc_6)
                {
                    _loc_11 = (_loc_7 - (_loc_3 + _loc_4)) / 2;
                    if (_icon)
                    {
                        _icon.x = _loc_11 + (_loc_3 - _icon.measuredWidth) / 2;
                        _icon.setActualSize(_icon.measuredWidth, _icon.measuredHeight);
                    }
                    if (typeIcon)
                    {
                        typeIcon.x = _loc_11 + _loc_3 + (_loc_4 - typeIcon.measuredWidth) / 2;
                        typeIcon.setActualSize(typeIcon.measuredWidth, typeIcon.measuredHeight);
                    }
                }
                else
                {
                    if (_icon)
                    {
                        _icon.x = (_loc_7 - _icon.measuredWidth) / 2;
                        _icon.setActualSize(_icon.measuredWidth, _icon.measuredHeight);
                    }
                    if (typeIcon)
                    {
                        typeIcon.x = (_loc_7 - typeIcon.measuredWidth) / 2;
                        typeIcon.setActualSize(typeIcon.measuredWidth, typeIcon.measuredHeight);
                    }
                }
                if (branchIcon)
                {
                    branchIcon.x = param1 - _loc_8 + (_loc_8 - branchIcon.measuredWidth) / 2;
                    branchIcon.setActualSize(branchIcon.measuredWidth, branchIcon.measuredHeight);
                }
                label.x = _loc_7;
                label.setActualSize(param1 - _loc_7 - _loc_8, label.getExplicitOrMeasuredHeight());
                if (_listData && !Menu(_listData.owner).showDataTips)
                {
                    label.text = _listData.label;
                    if (label.truncateToFit())
                    {
                        toolTip = _listData.label;
                    }
                    else
                    {
                        toolTip = null;
                    }
                }
                _loc_9 = getStyle("verticalAlign");
                if (_loc_9 == "top")
                {
                    label.y = 0;
                    if (_icon)
                    {
                        _icon.y = 0;
                    }
                    if (typeIcon)
                    {
                        typeIcon.y = 0;
                    }
                    if (branchIcon)
                    {
                        branchIcon.y = 0;
                    }
                }
                else if (_loc_9 == "bottom")
                {
                    label.y = param2 - label.height + 2;
                    if (_icon)
                    {
                        _icon.y = param2 - _icon.height;
                    }
                    if (typeIcon)
                    {
                        typeIcon.y = param2 - typeIcon.height;
                    }
                    if (branchIcon)
                    {
                        branchIcon.y = param2 - branchIcon.height;
                    }
                }
                else
                {
                    label.y = (param2 - label.height) / 2;
                    if (_icon)
                    {
                        _icon.y = (param2 - _icon.height) / 2;
                    }
                    if (typeIcon)
                    {
                        typeIcon.y = (param2 - typeIcon.height) / 2;
                    }
                    if (branchIcon)
                    {
                        branchIcon.y = (param2 - branchIcon.height) / 2;
                    }
                }
                if (data && parent)
                {
                    if (!enabled)
                    {
                        _loc_10 = getStyle("disabledColor");
                    }
                    else if (Menu(listData.owner).isItemHighlighted(listData.uid))
                    {
                        _loc_10 = getStyle("textRollOverColor");
                    }
                    else if (Menu(listData.owner).isItemSelected(listData.uid))
                    {
                        _loc_10 = getStyle("textSelectedColor");
                    }
                    else
                    {
                        _loc_10 = getStyle("color");
                    }
                    label.setColor(_loc_10);
                }
            }
            return;
        }// end function

        protected function get icon() : IFlexDisplayObject
        {
            var _loc_1:IMenuDataDescriptor = null;
            var _loc_2:String = null;
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                if (_data)
                {
                    _loc_1 = Menu(_listData.owner).dataDescriptor;
                    _loc_2 = _loc_1.getType(_data);
                    if (_loc_2.toLowerCase() == "separator")
                    {
                        return separatorIcon;
                    }
                }
                if (typeIcon)
                {
                    return typeIcon;
                }
                return _icon;
            }
            return _icon;
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

    }
}
