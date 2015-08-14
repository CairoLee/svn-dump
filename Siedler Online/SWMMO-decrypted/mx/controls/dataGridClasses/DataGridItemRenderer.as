package mx.controls.dataGridClasses
{
    import flash.display.*;
    import flash.geom.*;
    import flash.utils.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.styles.*;

    public class DataGridItemRenderer extends UITextField implements IDataRenderer, IDropInListItemRenderer, ILayoutManagerClient, IListItemRenderer, IStyleClient
    {
        private var invalidateSizeFlag:Boolean = false;
        private var _data:Object;
        private var _listData:DataGridListData;
        private var invalidatePropertiesFlag:Boolean = false;
        private var _styleDeclaration:CSSStyleDeclaration;
        static const VERSION:String = "3.5.0.12683";

        public function DataGridItemRenderer()
        {
            tabEnabled = false;
            mouseWheelEnabled = false;
            ignorePadding = false;
            addEventListener(ToolTipEvent.TOOL_TIP_SHOW, toolTipShowHandler);
            var _loc_1:* = UIComponent.STYLE_UNINITIALIZED;
            nonInheritingStyles = UIComponent.STYLE_UNINITIALIZED;
            inheritingStyles = _loc_1;
            return;
        }// end function

        override public function initialize() : void
        {
            regenerateStyleCache(false);
            return;
        }// end function

        public function validateDisplayList() : void
        {
            validateNow();
            return;
        }// end function

        public function getClassStyleDeclarations() : Array
        {
            var s:CSSStyleDeclaration;
            var className:* = getQualifiedClassName(this);
            className = className.replace("::", ".");
            var decls:Array;
            do
            {
                
                s = StyleManager.getStyleDeclaration(className);
                if (s)
                {
                    decls.unshift(s);
                }
                try
                {
                    className = getQualifiedSuperclassName(getDefinitionByName(className));
                    className = className.replace("::", ".");
                }
                catch (e:ReferenceError)
                {
                    className;
                }
            }while (className != null && className != "mx.core.UIComponent" && className != "mx.core.UITextField")
            return decls;
        }// end function

        public function notifyStyleChangeInChildren(param1:String, param2:Boolean) : void
        {
            return;
        }// end function

        public function regenerateStyleCache(param1:Boolean) : void
        {
            initProtoChain();
            return;
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

        public function get styleDeclaration() : CSSStyleDeclaration
        {
            return _styleDeclaration;
        }// end function

        override public function set nestLevel(param1:int) : void
        {
            super.nestLevel = param1;
            UIComponentGlobals.layoutManager.invalidateProperties(this);
            invalidatePropertiesFlag = true;
            UIComponentGlobals.layoutManager.invalidateSize(this);
            invalidateSizeFlag = true;
            return;
        }// end function

        public function validateSize(param1:Boolean = false) : void
        {
            invalidateSizeFlag = false;
            validateNow();
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
            _loc_6 = localToGlobal(_loc_6);
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

        public function set styleDeclaration(param1:CSSStyleDeclaration) : void
        {
            _styleDeclaration = param1;
            return;
        }// end function

        override public function validateNow() : void
        {
            var _loc_1:Number = NaN;
            if (data && parent)
            {
                if (DataGridBase(_listData.owner).isItemHighlighted(_listData.uid))
                {
                    _loc_1 = getStyle("textRollOverColor");
                }
                else if (DataGridBase(_listData.owner).isItemSelected(_listData.uid))
                {
                    _loc_1 = getStyle("textSelectedColor");
                }
                else
                {
                    _loc_1 = getStyle("color");
                }
                if (_loc_1 != explicitColor)
                {
                    styleChangedFlag = true;
                    explicitColor = _loc_1;
                    invalidateDisplayList();
                }
            }
            super.validateNow();
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        public function clearStyle(param1:String) : void
        {
            setStyle(param1, undefined);
            return;
        }// end function

        public function registerEffects(param1:Array) : void
        {
            return;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        public function validateProperties() : void
        {
            var _loc_1:DataGrid = null;
            var _loc_2:DataGridColumn = null;
            var _loc_3:Boolean = false;
            invalidatePropertiesFlag = false;
            if (_listData)
            {
                _loc_1 = DataGrid(_listData.owner);
                _loc_2 = _loc_1.columns[_listData.columnIndex];
                text = _listData.label;
                if (_data is DataGridColumn)
                {
                    wordWrap = _loc_1.columnHeaderWordWrap(_loc_2);
                }
                else
                {
                    wordWrap = _loc_1.columnWordWrap(_loc_2);
                }
                if (DataGrid(_listData.owner).variableRowHeight)
                {
                    multiline = true;
                }
                _loc_3 = _loc_1.showDataTips;
                if (_loc_2.showDataTips == true)
                {
                    _loc_3 = true;
                }
                if (_loc_2.showDataTips == false)
                {
                    _loc_3 = false;
                }
                if (_loc_3)
                {
                    if (!(_data is DataGridColumn) && (textWidth > width || _loc_2.dataTipFunction || _loc_2.dataTipField || _loc_1.dataTipFunction || _loc_1.dataTipField))
                    {
                        toolTip = _loc_2.itemToDataTip(_data);
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
                text = " ";
                toolTip = null;
            }
            return;
        }// end function

        public function set listData(param1:BaseListData) : void
        {
            _listData = DataGridListData(param1);
            if (nestLevel && !invalidatePropertiesFlag)
            {
                UIComponentGlobals.layoutManager.invalidateProperties(this);
                invalidatePropertiesFlag = true;
                UIComponentGlobals.layoutManager.invalidateSize(this);
                invalidateSizeFlag = true;
            }
            return;
        }// end function

        public function initProtoChain() : void
        {
            var _loc_1:CSSStyleDeclaration = null;
            var _loc_7:Object = null;
            var _loc_8:CSSStyleDeclaration = null;
            styleChangedFlag = true;
            if (styleName)
            {
                if (styleName is CSSStyleDeclaration)
                {
                    _loc_1 = CSSStyleDeclaration(styleName);
                }
                else
                {
                    if (styleName is IFlexDisplayObject)
                    {
                        StyleProtoChain.initProtoChainForUIComponentStyleName(this);
                        return;
                    }
                    if (styleName is String)
                    {
                        _loc_1 = StyleManager.getStyleDeclaration("." + styleName);
                    }
                }
            }
            var _loc_2:* = StyleManager.stylesRoot;
            var _loc_3:* = parent as IStyleClient;
            if (_loc_3)
            {
                _loc_7 = _loc_3.inheritingStyles;
                if (_loc_7 == UIComponent.STYLE_UNINITIALIZED)
                {
                    _loc_7 = _loc_2;
                }
            }
            else
            {
                _loc_7 = StyleManager.stylesRoot;
            }
            var _loc_4:* = getClassStyleDeclarations();
            var _loc_5:* = getClassStyleDeclarations().length;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_8 = _loc_4[_loc_6];
                _loc_7 = _loc_8.addStyleToProtoChain(_loc_7, this);
                _loc_2 = _loc_8.addStyleToProtoChain(_loc_2, this);
                _loc_6++;
            }
            if (_loc_1)
            {
                _loc_7 = _loc_1.addStyleToProtoChain(_loc_7, this);
                _loc_2 = _loc_1.addStyleToProtoChain(_loc_2, this);
            }
            inheritingStyles = styleDeclaration ? (styleDeclaration.addStyleToProtoChain(_loc_7, this)) : (_loc_7);
            nonInheritingStyles = styleDeclaration ? (styleDeclaration.addStyleToProtoChain(_loc_2, this)) : (_loc_2);
            return;
        }// end function

        override public function getStyle(param1:String)
        {
            return StyleManager.inheritingStyles[param1] ? (inheritingStyles[param1]) : (nonInheritingStyles[param1]);
        }// end function

        override public function setStyle(param1:String, param2) : void
        {
            if (param1 == "styleName")
            {
                styleName = param2;
                return;
            }
            var _loc_3:* = StyleManager.isInheritingStyle(param1);
            var _loc_4:* = inheritingStyles != UIComponent.STYLE_UNINITIALIZED;
            if (_loc_3)
            {
                if (getStyle(param1) == param2 && _loc_4)
                {
                    return;
                }
                if (!styleDeclaration)
                {
                    styleDeclaration = new CSSStyleDeclaration();
                    styleDeclaration.setStyle(param1, param2);
                    if (_loc_4)
                    {
                        regenerateStyleCache(true);
                    }
                }
                else
                {
                    styleDeclaration.setStyle(param1, param2);
                }
            }
            else
            {
                if (getStyle(param1) == param2 && _loc_4)
                {
                    return;
                }
                if (!styleDeclaration)
                {
                    styleDeclaration = new CSSStyleDeclaration();
                    styleDeclaration.setStyle(param1, param2);
                    if (_loc_4)
                    {
                        regenerateStyleCache(false);
                    }
                }
                else
                {
                    styleDeclaration.setStyle(param1, param2);
                }
            }
            if (_loc_4)
            {
                styleChanged(param1);
                notifyStyleChangeInChildren(param1, _loc_3);
            }
            return;
        }// end function

    }
}
