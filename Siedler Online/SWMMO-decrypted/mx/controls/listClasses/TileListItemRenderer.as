package mx.controls.listClasses
{
    import flash.display.*;
    import flash.geom.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class TileListItemRenderer extends UIComponent implements IDataRenderer, IDropInListItemRenderer, IListItemRenderer, IFontContextComponent
    {
        private var iconOnly:Boolean = false;
        private var _listData:ListData;
        private var _data:Object;
        protected var label:IUITextField;
        private var listOwner:TileBase;
        protected var icon:IFlexDisplayObject;
        private var iconClass:Class;
        static const VERSION:String = "3.5.0.12683";

        public function TileListItemRenderer()
        {
            addEventListener(ToolTipEvent.TOOL_TIP_SHOW, toolTipShowHandler);
            return;
        }// end function

        public function set fontContext(param1:IFlexModuleFactory) : void
        {
            this.moduleFactory = param1;
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_6:Number = NaN;
            var _loc_9:Number = NaN;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = iconOnly ? (0) : (getStyle("verticalGap"));
            var _loc_4:* = getStyle("paddingLeft");
            var _loc_5:* = getStyle("paddingRight");
            if (icon)
            {
                icon.width = Math.min(param1 - (_loc_4 + _loc_5), icon.measuredWidth);
                icon.height = Math.min(Math.max(param2 - _loc_3 - label.getExplicitOrMeasuredHeight(), 0), icon.measuredHeight);
                icon.x = _loc_4 + (param1 - _loc_4 - _loc_5 - icon.width) / 2;
            }
            label.width = param1 - (_loc_4 + _loc_5);
            label.height = Math.min(label.getExplicitOrMeasuredHeight(), icon ? (Math.max(param2 - _loc_3 - icon.height, 0)) : (param2));
            label.x = _loc_4;
            if (listOwner && listOwner.showDataTips)
            {
                if (label.textWidth > label.width || listOwner.dataTipField && listOwner.dataTipField != "label" || listOwner.dataTipFunction != null)
                {
                    toolTip = listOwner.itemToDataTip(_data);
                }
                else
                {
                    toolTip = null;
                }
            }
            else
            {
                toolTip = null;
            }
            var _loc_7:* = label.height;
            if (icon)
            {
                _loc_7 = _loc_7 + (icon.height + _loc_3);
            }
            var _loc_8:* = getStyle("verticalAlign");
            if (getStyle("verticalAlign") == "top")
            {
                _loc_6 = 0;
                if (icon)
                {
                    icon.y = _loc_6;
                    _loc_6 = _loc_6 + (_loc_3 + icon.height);
                }
                label.y = _loc_6;
            }
            else if (_loc_8 == "bottom")
            {
                _loc_6 = param2 - label.height;
                label.y = _loc_6;
                if (icon)
                {
                    _loc_6 = _loc_6 - (_loc_3 + icon.height);
                    icon.y = _loc_6;
                }
            }
            else
            {
                _loc_6 = (param2 - _loc_7) / 2;
                if (icon)
                {
                    icon.y = _loc_6;
                    _loc_6 = _loc_6 + (_loc_3 + icon.height);
                }
                label.y = _loc_6;
            }
            if (data && parent)
            {
                if (!enabled)
                {
                    _loc_9 = getStyle("disabledColor");
                }
                else if (listOwner.isItemSelected(listData.uid))
                {
                    _loc_9 = getStyle("textSelectedColor");
                }
                else if (listOwner.isItemHighlighted(listData.uid))
                {
                    _loc_9 = getStyle("textRollOverColor");
                }
                else
                {
                    _loc_9 = getStyle("color");
                }
                label.setColor(_loc_9);
            }
            return;
        }// end function

        protected function toolTipShowHandler(event:ToolTipEvent) : void
        {
            var _loc_5:Rectangle = null;
            var _loc_8:InterManagerRequest = null;
            var _loc_2:* = event.toolTip;
            var _loc_3:* = systemManager.topLevelSystemManager;
            var _loc_4:* = _loc_3.getSandboxRoot();
            var _loc_6:* = new Point(0, 0);
            _loc_6 = label.localToGlobal(_loc_6);
            _loc_6 = _loc_4.globalToLocal(_loc_6);
            _loc_2.move(_loc_6.x, _loc_6.y + (height - _loc_2.height) / 2);
            if (_loc_3 != _loc_4)
            {
                _loc_8 = new InterManagerRequest(InterManagerRequest.SYSTEM_MANAGER_REQUEST, false, false, "getVisibleApplicationRect");
                _loc_4.dispatchEvent(_loc_8);
                _loc_5 = Rectangle(_loc_8.value);
            }
            else
            {
                _loc_5 = _loc_3.getVisibleApplicationRect();
            }
            var _loc_7:* = _loc_5.x + _loc_5.width;
            _loc_6.x = _loc_2.x;
            _loc_6.y = _loc_2.y;
            _loc_6 = _loc_4.localToGlobal(_loc_6);
            if (_loc_6.x + _loc_2.width > _loc_7)
            {
                _loc_2.move(_loc_2.x - (_loc_6.x + _loc_2.width - _loc_7), _loc_2.y);
            }
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

        override protected function commitProperties() : void
        {
            var _loc_1:int = 0;
            var _loc_2:Class = null;
            super.commitProperties();
            if (hasFontContextChanged() && label != null)
            {
                _loc_1 = getChildIndex(DisplayObject(label));
                removeLabel();
                createLabel(_loc_1);
            }
            if (icon && !_data)
            {
                removeChild(DisplayObject(icon));
                icon = null;
                iconClass = null;
            }
            if (_data)
            {
                listOwner = TileBase(_listData.owner);
                if (_listData.icon)
                {
                    _loc_2 = _listData.icon;
                    if (iconClass != _loc_2)
                    {
                        iconClass = _loc_2;
                        if (icon)
                        {
                            removeChild(DisplayObject(icon));
                        }
                        icon = new iconClass();
                        addChild(DisplayObject(icon));
                    }
                }
                label.text = _listData.label;
                label.multiline = listOwner.variableRowHeight;
                label.wordWrap = listOwner.wordWrap;
            }
            else
            {
                label.text = " ";
                toolTip = null;
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

        override protected function measure() : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            super.measure();
            var _loc_1:Number = 0;
            if (icon)
            {
                _loc_1 = _loc_1 + icon.measuredHeight;
            }
            if (label.text == "" || label.text == " " || label.text == null)
            {
                label.explicitHeight = 0;
                iconOnly = true;
            }
            else
            {
                label.explicitHeight = NaN;
                _loc_1 = _loc_1 + getStyle("verticalGap");
                iconOnly = false;
            }
            measuredHeight = label.getExplicitOrMeasuredHeight() + _loc_1;
            _loc_2 = getStyle("paddingLeft");
            _loc_3 = getStyle("paddingRight");
            measuredWidth = label.getExplicitOrMeasuredWidth() + _loc_2 + _loc_3;
            if (icon && icon.measuredWidth + _loc_2 + _loc_3 > measuredWidth)
            {
                measuredWidth = icon.measuredWidth + _loc_2 + _loc_3;
            }
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

        public function get fontContext() : IFlexModuleFactory
        {
            return moduleFactory;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            createLabel(-1);
            return;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

    }
}
