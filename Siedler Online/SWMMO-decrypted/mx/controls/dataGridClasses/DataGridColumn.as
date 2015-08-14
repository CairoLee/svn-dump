package mx.controls.dataGridClasses
{
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.styles.*;
    import mx.utils.*;

    public class DataGridColumn extends CSSStyleDeclaration implements IIMESupport
    {
        private var _headerText:String;
        public var editorXOffset:Number = 0;
        var measuringObjects:Dictionary;
        private var fontPropertiesSet:Boolean = false;
        public var rendererIsEditor:Boolean = false;
        var cachedHeaderRenderer:IListItemRenderer;
        public var sortDescending:Boolean = false;
        private var cachedEmbeddedFont:EmbeddedFont = null;
        public var editorYOffset:Number = 0;
        private var _headerWordWrap:Object;
        private var _dataTipFunction:Function;
        private var _visible:Boolean = true;
        public var editorWidthOffset:Number = 0;
        public var itemEditor:IFactory;
        public var editorUsesEnterKey:Boolean = false;
        public var editable:Boolean = true;
        private var _nullItemRenderer:IFactory;
        var freeItemRenderersByFactory:Dictionary;
        public var editorDataField:String = "text";
        var newlyVisible:Boolean = false;
        public var draggable:Boolean = true;
        protected var hasComplexFieldName:Boolean = false;
        private var _sortCompareFunction:Function;
        public var editorHeightOffset:Number = 0;
        public var resizable:Boolean = true;
        private var _headerRenderer:IFactory;
        var owner:DataGridBase;
        private var _imeMode:String;
        private var _dataTipField:String;
        protected var complexFieldNameComponents:Array;
        private var _width:Number = 100;
        private var oldEmbeddedFontContext:IFlexModuleFactory = null;
        private var _wordWrap:Object;
        var preferredWidth:Number = 100;
        private var _itemRenderer:IFactory;
        var colNum:Number;
        private var _dataField:String;
        private var _minWidth:Number = 20;
        private var _labelFunction:Function;
        private var hasFontContextBeenSaved:Boolean = false;
        public var sortable:Boolean = true;
        var explicitWidth:Number;
        private var _showDataTips:Object;
        private static var _embeddedFontRegistry:IEmbeddedFontRegistry;
        static const VERSION:String = "3.5.0.12683";

        public function DataGridColumn(param1:String = null)
        {
            itemEditor = new ClassFactory(TextInput);
            if (param1)
            {
                dataField = param1;
                headerText = param1;
            }
            return;
        }// end function

        function getMeasuringRenderer(param1:Boolean, param2:Object) : IListItemRenderer
        {
            var _loc_3:* = getItemRendererFactory(param1, param2);
            if (!_loc_3)
            {
                _loc_3 = owner.itemRenderer;
            }
            if (!measuringObjects)
            {
                measuringObjects = new Dictionary(false);
            }
            var _loc_4:* = measuringObjects[_loc_3];
            if (!measuringObjects[_loc_3])
            {
                _loc_4 = _loc_3.newInstance();
                _loc_4.visible = false;
                _loc_4.styleName = this;
                measuringObjects[_loc_3] = _loc_4;
            }
            return _loc_4;
        }// end function

        public function get imeMode() : String
        {
            return _imeMode;
        }// end function

        public function set imeMode(param1:String) : void
        {
            _imeMode = param1;
            return;
        }// end function

        public function getItemRendererFactory(param1:Boolean, param2:Object) : IFactory
        {
            if (param1)
            {
                return replaceItemRendererFactory(headerRenderer);
            }
            if (!param2)
            {
                return replaceItemRendererFactory(nullItemRenderer);
            }
            return replaceItemRendererFactory(itemRenderer);
        }// end function

        public function set dataTipFunction(param1:Function) : void
        {
            _dataTipFunction = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            dispatchEvent(new Event("labelFunctionChanged"));
            return;
        }// end function

        public function get nullItemRenderer() : IFactory
        {
            return _nullItemRenderer;
        }// end function

        public function get showDataTips()
        {
            return _showDataTips;
        }// end function

        public function get headerWordWrap()
        {
            return _headerWordWrap;
        }// end function

        public function set minWidth(param1:Number) : void
        {
            _minWidth = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            if (_width < param1)
            {
                _width = param1;
            }
            dispatchEvent(new Event("minWidthChanged"));
            return;
        }// end function

        public function set nullItemRenderer(param1:IFactory) : void
        {
            _nullItemRenderer = param1;
            if (owner)
            {
                owner.invalidateList();
                owner.columnRendererChanged(this);
            }
            dispatchEvent(new Event("nullItemRendererChanged"));
            return;
        }// end function

        public function set showDataTips(param1) : void
        {
            _showDataTips = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            return;
        }// end function

        public function set headerWordWrap(param1) : void
        {
            _headerWordWrap = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            return;
        }// end function

        override function addStyleToProtoChain(param1:Object, param2:DisplayObject, param3:Object = null) : Object
        {
            var _loc_6:Object = null;
            var _loc_7:Object = null;
            var _loc_8:Object = null;
            var _loc_4:* = owner;
            var _loc_5:* = IListItemRenderer(param2);
            _loc_6 = _loc_6;
            if (_loc_6)
            {
                if (_loc_6 is String)
                {
                    _loc_6 = StyleManager.getStyleDeclaration("." + _loc_6);
                }
                if (_loc_6 is CSSStyleDeclaration)
                {
                    param1 = _loc_6.addStyleToProtoChain(param1, param2);
                }
            }
            param1 = super.addStyleToProtoChain(param1, param2);
            if (_loc_5.data && _loc_5.data is DataGridColumn)
            {
                _loc_8 = _loc_4.getStyle("headerStyleName");
                if (_loc_8)
                {
                    if (_loc_8 is String)
                    {
                        _loc_8 = StyleManager.getStyleDeclaration("." + _loc_8);
                    }
                    if (_loc_8 is CSSStyleDeclaration)
                    {
                        param1 = _loc_8.addStyleToProtoChain(param1, param2);
                    }
                }
                _loc_8 = getStyle("headerStyleName");
                if (_loc_8)
                {
                    if (_loc_8 is String)
                    {
                        _loc_8 = StyleManager.getStyleDeclaration("." + _loc_8);
                    }
                    if (_loc_8 is CSSStyleDeclaration)
                    {
                        param1 = _loc_8.addStyleToProtoChain(param1, param2);
                    }
                }
            }
            if (!fontPropertiesSet)
            {
                fontPropertiesSet = true;
                saveFontContext(owner ? (owner.moduleFactory) : (null));
            }
            return param1;
        }// end function

        public function get headerText() : String
        {
            return _headerText != null ? (_headerText) : (dataField);
        }// end function

        public function get sortCompareFunction() : Function
        {
            return _sortCompareFunction;
        }// end function

        protected function complexColumnSortCompare(param1:Object, param2:Object) : int
        {
            if (!param1 && !param2)
            {
                return 0;
            }
            if (!param1)
            {
                return 1;
            }
            if (!param2)
            {
                return -1;
            }
            var _loc_3:* = deriveComplexColumnData(param1).toString();
            var _loc_4:* = deriveComplexColumnData(param2).toString();
            if (_loc_3 < _loc_4)
            {
                return -1;
            }
            if (_loc_3 > _loc_4)
            {
                return 1;
            }
            return 0;
        }// end function

        function hasFontContextChanged(param1:IFlexModuleFactory) : Boolean
        {
            if (!hasFontContextBeenSaved)
            {
                return false;
            }
            var _loc_2:* = StringUtil.trimArrayElements(getStyle("fontFamily"), ",");
            var _loc_3:* = getStyle("fontWeight");
            var _loc_4:* = getStyle("fontStyle");
            var _loc_5:* = _loc_3 == "bold";
            var _loc_6:* = _loc_4 == "italic";
            var _loc_7:* = getEmbeddedFont(_loc_2, _loc_5, _loc_6);
            var _loc_8:* = embeddedFontRegistry.getAssociatedModuleFactory(_loc_7, param1);
            return embeddedFontRegistry.getAssociatedModuleFactory(_loc_7, param1) != oldEmbeddedFontContext;
        }// end function

        override public function setStyle(param1:String, param2) : void
        {
            fontPropertiesSet = false;
            var _loc_3:* = getStyle(param1);
            var _loc_4:Boolean = false;
            if (factory == null && defaultFactory == null && !overrides && _loc_3 !== param2)
            {
                _loc_4 = true;
            }
            super.setStyle(param1, param2);
            if (param1 == "headerStyleName")
            {
                if (owner)
                {
                    owner.regenerateStyleCache(true);
                    owner.notifyStyleChangeInChildren("headerStyleName", true);
                }
                return;
            }
            if (owner)
            {
                if (_loc_4)
                {
                    owner.regenerateStyleCache(true);
                }
                if (hasFontContextChanged(owner.moduleFactory))
                {
                    owner.columnRendererChanged(this);
                }
                owner.invalidateList();
            }
            return;
        }// end function

        public function get dataField() : String
        {
            return _dataField;
        }// end function

        public function get visible() : Boolean
        {
            return _visible;
        }// end function

        public function get wordWrap()
        {
            return _wordWrap;
        }// end function

        public function get headerRenderer() : IFactory
        {
            return _headerRenderer;
        }// end function

        function setWidth(param1:Number) : void
        {
            var _loc_2:* = _width;
            _width = param1;
            if (_loc_2 != param1)
            {
                dispatchEvent(new Event("widthChanged"));
            }
            return;
        }// end function

        function getEmbeddedFont(param1:String, param2:Boolean, param3:Boolean) : EmbeddedFont
        {
            if (cachedEmbeddedFont)
            {
                if (cachedEmbeddedFont.fontName == param1 && cachedEmbeddedFont.fontStyle == EmbeddedFontRegistry.getFontStyle(param2, param3))
                {
                    return cachedEmbeddedFont;
                }
            }
            cachedEmbeddedFont = new EmbeddedFont(param1, param2, param3);
            return cachedEmbeddedFont;
        }// end function

        public function get dataTipFunction() : Function
        {
            return _dataTipFunction;
        }// end function

        public function set width(param1:Number) : void
        {
            var _loc_2:Boolean = false;
            explicitWidth = param1;
            preferredWidth = param1;
            if (owner != null)
            {
                _loc_2 = resizable;
                resizable = false;
                owner.resizeColumn(colNum, param1);
                resizable = _loc_2;
            }
            else
            {
                _width = param1;
            }
            dispatchEvent(new Event("widthChanged"));
            return;
        }// end function

        public function get minWidth() : Number
        {
            return _minWidth;
        }// end function

        protected function deriveComplexColumnData(param1:Object) : Object
        {
            var _loc_3:int = 0;
            var _loc_2:* = param1;
            if (complexFieldNameComponents)
            {
                _loc_3 = 0;
                while (_loc_3 < complexFieldNameComponents.length)
                {
                    
                    _loc_2 = _loc_2[complexFieldNameComponents[_loc_3]];
                    _loc_3++;
                }
            }
            return _loc_2;
        }// end function

        private function saveFontContext(param1:IFlexModuleFactory) : void
        {
            hasFontContextBeenSaved = true;
            var _loc_2:* = StringUtil.trimArrayElements(getStyle("fontFamily"), ",");
            var _loc_3:* = getStyle("fontWeight");
            var _loc_4:* = getStyle("fontStyle");
            var _loc_5:* = _loc_3 == "bold";
            var _loc_6:* = _loc_4 == "italic";
            var _loc_7:* = getEmbeddedFont(_loc_2, _loc_5, _loc_6);
            oldEmbeddedFontContext = embeddedFontRegistry.getAssociatedModuleFactory(_loc_7, param1);
            return;
        }// end function

        public function itemToLabel(param1:Object) : String
        {
            var data:* = param1;
            if (!data)
            {
                return " ";
            }
            if (labelFunction != null)
            {
                return labelFunction(data, this);
            }
            if (owner.labelFunction != null)
            {
                return owner.labelFunction(data, this);
            }
            if (typeof(data) == "object" || typeof(data) == "xml")
            {
                try
                {
                    if (!hasComplexFieldName)
                    {
                        data = data[dataField];
                    }
                    else
                    {
                        data = deriveComplexColumnData(data);
                    }
                }
                catch (e:Error)
                {
                    data;
                }
            }
            if (data is String)
            {
                return String(data);
            }
            try
            {
                return data.toString();
            }
            catch (e:Error)
            {
            }
            return " ";
        }// end function

        public function set headerText(param1:String) : void
        {
            _headerText = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            dispatchEvent(new Event("headerTextChanged"));
            return;
        }// end function

        public function set sortCompareFunction(param1:Function) : void
        {
            _sortCompareFunction = param1;
            dispatchEvent(new Event("sortCompareFunctionChanged"));
            return;
        }// end function

        public function itemToDataTip(param1:Object) : String
        {
            var field:String;
            var data:* = param1;
            if (dataTipFunction != null)
            {
                return dataTipFunction(data);
            }
            if (owner.dataTipFunction != null)
            {
                return owner.dataTipFunction(data);
            }
            if (typeof(data) == "object" || typeof(data) == "xml")
            {
                field = dataTipField;
                if (!field)
                {
                    field = owner.dataTipField;
                }
                try
                {
                    if (data[field] != null)
                    {
                        data = data[field];
                    }
                    else if (data[dataField] != null)
                    {
                        data = data[dataField];
                    }
                }
                catch (e:Error)
                {
                    data;
                }
            }
            if (data is String)
            {
                return String(data);
            }
            try
            {
                return data.toString();
            }
            catch (e:Error)
            {
            }
            return " ";
        }// end function

        public function get width() : Number
        {
            return _width;
        }// end function

        public function set dataTipField(param1:String) : void
        {
            _dataTipField = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            dispatchEvent(new Event("dataTipChanged"));
            return;
        }// end function

        public function set labelFunction(param1:Function) : void
        {
            _labelFunction = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            dispatchEvent(new Event("labelFunctionChanged"));
            return;
        }// end function

        public function set dataField(param1:String) : void
        {
            _dataField = param1;
            if (param1.indexOf(".") != -1)
            {
                hasComplexFieldName = true;
                complexFieldNameComponents = param1.split(".");
                if (_sortCompareFunction == null)
                {
                    _sortCompareFunction = complexColumnSortCompare;
                }
            }
            if (owner)
            {
                owner.invalidateList();
            }
            return;
        }// end function

        public function set headerRenderer(param1:IFactory) : void
        {
            _headerRenderer = param1;
            if (owner)
            {
                owner.invalidateList();
                owner.columnRendererChanged(this);
            }
            dispatchEvent(new Event("headerRendererChanged"));
            return;
        }// end function

        public function set wordWrap(param1) : void
        {
            _wordWrap = param1;
            if (owner)
            {
                owner.invalidateList();
            }
            return;
        }// end function

        public function get dataTipField() : String
        {
            return _dataTipField;
        }// end function

        public function set visible(param1:Boolean) : void
        {
            if (_visible != param1)
            {
                _visible = param1;
                if (param1)
                {
                    newlyVisible = true;
                }
                if (owner)
                {
                    owner.columnsInvalid = true;
                    owner.invalidateSize();
                    owner.invalidateList();
                }
            }
            return;
        }// end function

        public function set itemRenderer(param1:IFactory) : void
        {
            _itemRenderer = param1;
            if (owner)
            {
                owner.invalidateList();
                owner.columnRendererChanged(this);
            }
            dispatchEvent(new Event("itemRendererChanged"));
            return;
        }// end function

        private function replaceItemRendererFactory(param1:IFactory) : IFactory
        {
            if (oldEmbeddedFontContext == null)
            {
                return param1;
            }
            if (param1 == null && owner != null)
            {
                param1 = owner.itemRenderer;
            }
            if (param1 is ClassFactory)
            {
                return new ContextualClassFactory(ClassFactory(param1).generator, oldEmbeddedFontContext);
            }
            return param1;
        }// end function

        public function get itemRenderer() : IFactory
        {
            return _itemRenderer;
        }// end function

        public function get labelFunction() : Function
        {
            return _labelFunction;
        }// end function

        private static function get embeddedFontRegistry() : IEmbeddedFontRegistry
        {
            if (!_embeddedFontRegistry)
            {
                _embeddedFontRegistry = IEmbeddedFontRegistry(Singleton.getInstance("mx.core::IEmbeddedFontRegistry"));
            }
            return _embeddedFontRegistry;
        }// end function

    }
}
