package mx.controls.listClasses
{
    import flash.display.*;
    import flash.geom.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class ListItemRenderer extends UIComponent implements IDataRenderer, IDropInListItemRenderer, IListItemRenderer, IFontContextComponent
    {
        private var _listData:ListData;
        private var _data:Object;
        protected var label:IUITextField;
        private var listOwner:ListBase;
        protected var icon:IFlexDisplayObject;
        static const VERSION:String = "3.5.0.12683";

        public function ListItemRenderer()
        {
            addEventListener(ToolTipEvent.TOOL_TIP_SHOW, toolTipShowHandler);
            return;
        }// end function

        public function set fontContext(param1:IFlexModuleFactory) : void
        {
            this.moduleFactory = param1;
            return;
        }// end function

        function getLabel() : IUITextField
        {
            return label;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_2:Class = null;
            super.commitProperties();
            var _loc_1:int = -1;
            if (hasFontContextChanged() && label != null)
            {
                _loc_1 = getChildIndex(DisplayObject(label));
                removeChild(DisplayObject(label));
                label = null;
            }
            if (!label)
            {
                label = IUITextField(createInFontContext(UITextField));
                label.styleName = this;
                if (_loc_1 == -1)
                {
                    addChild(DisplayObject(label));
                }
                else
                {
                    addChildAt(DisplayObject(label), _loc_1);
                }
            }
            if (icon)
            {
                removeChild(DisplayObject(icon));
                icon = null;
            }
            if (_data != null)
            {
                listOwner = ListBase(_listData.owner);
                if (_listData.icon)
                {
                    _loc_2 = _listData.icon;
                    icon = new _loc_2;
                    addChild(DisplayObject(icon));
                }
                label.text = _listData.label ? (_listData.label) : (" ");
                label.multiline = listOwner.variableRowHeight;
                label.wordWrap = listOwner.wordWrap;
                if (listOwner.showDataTips)
                {
                    if (label.textWidth > label.width || listOwner.dataTipFunction != null)
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
            }
            else
            {
                label.text = " ";
                toolTip = null;
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

        public function set listData(param1:BaseListData) : void
        {
            _listData = ListData(param1);
            invalidateProperties();
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            invalidateProperties();
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                if (!label)
                {
                    return 0;
                }
                return label.baselinePosition;
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            return label.y + label.baselinePosition;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            super.measure();
            _loc_1 = 0;
            if (icon)
            {
                _loc_1 = icon.measuredWidth;
            }
            if (label.width < 4 || label.height < 4)
            {
                label.width = 4;
                label.height = 16;
            }
            if (isNaN(explicitWidth))
            {
                _loc_1 = _loc_1 + label.getExplicitOrMeasuredWidth();
                measuredWidth = _loc_1;
                measuredHeight = label.getExplicitOrMeasuredHeight();
            }
            else
            {
                measuredWidth = explicitWidth;
                label.setActualSize(Math.max(explicitWidth - _loc_1, 4), label.height);
                measuredHeight = label.getExplicitOrMeasuredHeight();
                if (icon && icon.measuredHeight > measuredHeight)
                {
                    measuredHeight = icon.measuredHeight;
                }
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
            if (!label)
            {
                label = IUITextField(createInFontContext(UITextField));
                label.styleName = this;
                addChild(DisplayObject(label));
            }
            return;
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_5:Number = NaN;
            super.updateDisplayList(param1, param2);
            var _loc_3:Number = 0;
            if (icon)
            {
                icon.x = _loc_3;
                _loc_3 = icon.x + icon.measuredWidth;
                icon.setActualSize(icon.measuredWidth, icon.measuredHeight);
            }
            label.x = _loc_3;
            label.setActualSize(param1 - _loc_3, measuredHeight);
            var _loc_4:* = getStyle("verticalAlign");
            if (getStyle("verticalAlign") == "top")
            {
                label.y = 0;
                if (icon)
                {
                    icon.y = 0;
                }
            }
            else if (_loc_4 == "bottom")
            {
                label.y = param2 - label.height + 2;
                if (icon)
                {
                    icon.y = param2 - icon.height;
                }
            }
            else
            {
                label.y = (param2 - label.height) / 2;
                if (icon)
                {
                    icon.y = (param2 - icon.height) / 2;
                }
            }
            if (data && parent)
            {
                if (!enabled)
                {
                    _loc_5 = getStyle("disabledColor");
                }
                else if (listOwner.isItemHighlighted(listData.uid))
                {
                    _loc_5 = getStyle("textRollOverColor");
                }
                else if (listOwner.isItemSelected(listData.uid))
                {
                    _loc_5 = getStyle("textSelectedColor");
                }
                else
                {
                    _loc_5 = getStyle("color");
                }
                label.setColor(_loc_5);
            }
            return;
        }// end function

    }
}
