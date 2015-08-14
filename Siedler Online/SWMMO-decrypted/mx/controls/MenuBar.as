package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.xml.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.containers.*;
    import mx.controls.menuClasses.*;
    import mx.controls.treeClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.styles.*;

    public class MenuBar extends UIComponent implements IFocusManagerComponent
    {
        private var dataProviderChanged:Boolean = false;
        public var menus:Array;
        private var _labelField:String = "label";
        private var menuBarItemRendererChanged:Boolean = false;
        private var _menuBarItemRenderer:IFactory;
        private var openMenuIndex:int = -1;
        public var menuBarItems:Array;
        private var _iconField:String = "icon";
        private var background:IFlexDisplayObject;
        var showRootChanged:Boolean = false;
        private var inKeyDown:Boolean = false;
        private var isInsideACB:Boolean = false;
        var _hasRoot:Boolean = false;
        var _showRoot:Boolean = true;
        private var supposedToLoseFocus:Boolean = false;
        var _dataDescriptor:IMenuDataDescriptor;
        var _rootModel:ICollectionView;
        public var labelFunction:Function;
        private var iconFieldChanged:Boolean = false;
        private var isDown:Boolean;
        static var createAccessibilityImplementation:Function;
        private static const MARGIN_WIDTH:int = 10;
        static const VERSION:String = "3.5.0.12683";
        private static var _menuBarItemStyleFilters:Object = null;

        public function MenuBar()
        {
            _dataDescriptor = new DefaultDataDescriptor();
            menuBarItems = [];
            menus = [];
            menuBarItemRenderer = new ClassFactory(MenuBarItem);
            tabChildren = false;
            return;
        }// end function

        public function get iconField() : String
        {
            return _iconField;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            super.enabled = param1;
            if (menuBarItems)
            {
                _loc_2 = menuBarItems.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    menuBarItems[_loc_3].enabled = param1;
                    _loc_3++;
                }
            }
            return;
        }// end function

        public function get showRoot() : Boolean
        {
            return _showRoot;
        }// end function

        override public function set showInAutomationHierarchy(param1:Boolean) : void
        {
            return;
        }// end function

        private function removeAll() : void
        {
            var _loc_1:IMenuBarItemRenderer = null;
            if (dataProviderChanged)
            {
                commitProperties();
            }
            while (menuBarItems.length > 0)
            {
                
                _loc_1 = menuBarItems[0];
                removeChild(DisplayObject(_loc_1));
                menuBarItems.splice(0, 1);
            }
            menus = [];
            invalidateSize();
            invalidateDisplayList();
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_9:IMenuBarItemRenderer = null;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = MARGIN_WIDTH;
            var _loc_4:Number = 0;
            var _loc_5:* = menuBarItems.length;
            var _loc_6:Boolean = false;
            var _loc_7:* = param1 == 0 || param2 == 0;
            var _loc_8:int = 0;
            while (_loc_8 < _loc_5)
            {
                
                _loc_9 = menuBarItems[_loc_8];
                menuBarItems[_loc_8].setActualSize(_loc_9.getExplicitOrMeasuredWidth(), param2);
                _loc_9.visible = !_loc_7;
                var _loc_10:* = _loc_3 + _loc_4;
                _loc_9.x = _loc_3 + _loc_4;
                _loc_3 = _loc_10;
                _loc_4 = _loc_9.width;
                if (!_loc_7 && (_loc_9.getExplicitOrMeasuredHeight() > param2 || _loc_3 + _loc_4 > param1))
                {
                    _loc_6 = true;
                }
                _loc_8++;
            }
            if (background)
            {
                background.setActualSize(param1, param2);
                background.visible = !_loc_7;
            }
            scrollRect = _loc_6 ? (new Rectangle(0, 0, param1, param2)) : (null);
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
            if (menuBarItems.length == 0)
            {
                return super.baselinePosition;
            }
            var _loc_1:* = menuBarItems[0] as IUIComponent;
            if (!_loc_1)
            {
                return super.baselinePosition;
            }
            validateNow();
            return _loc_1.y + _loc_1.baselinePosition;
        }// end function

        protected function get menuBarItemStyleFilters() : Object
        {
            return _menuBarItemStyleFilters;
        }// end function

        public function set iconField(param1:String) : void
        {
            if (_iconField != param1)
            {
                iconFieldChanged = true;
                _iconField = param1;
                invalidateProperties();
                dispatchEvent(new Event("iconFieldChanged"));
            }
            return;
        }// end function

        public function set menuBarItemRenderer(param1:IFactory) : void
        {
            if (_menuBarItemRenderer != param1)
            {
                _menuBarItemRenderer = param1;
                menuBarItemRendererChanged = true;
                invalidateProperties();
                dispatchEvent(new Event("menuBarItemRendererChanged"));
            }
            return;
        }// end function

        public function get hasRoot() : Boolean
        {
            return _hasRoot;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (MenuBar.createAccessibilityImplementation != null)
            {
                MenuBar.createAccessibilityImplementation(this);
            }
            return;
        }// end function

        public function itemToIcon(param1:Object) : Class
        {
            var iconClass:Class;
            var icon:*;
            var data:* = param1;
            if (data == null)
            {
                return null;
            }
            if (data is XML)
            {
                try
                {
                    if (data[iconField].length() != 0)
                    {
                        icon = String(data[iconField]);
                        if (icon != null)
                        {
                            iconClass = Class(systemManager.getDefinitionByName(icon));
                            if (iconClass)
                            {
                                return iconClass;
                            }
                            return document[icon];
                        }
                    }
                }
                catch (e:Error)
                {
                }
            }
            else if (data is Object)
            {
                try
                {
                    if (data[iconField] != null)
                    {
                        if (data[iconField] is Class)
                        {
                            return data[iconField];
                        }
                        if (data[iconField] is String)
                        {
                            iconClass = Class(systemManager.getDefinitionByName(data[iconField]));
                            if (iconClass)
                            {
                                return iconClass;
                            }
                            return document[data[iconField]];
                        }
                    }
                }
                catch (e:Error)
                {
                }
            }
            return null;
        }// end function

        private function addMenuAt(param1:int, param2:Object, param3:Object = null) : void
        {
            var _loc_4:Menu = null;
            var _loc_5:Object = null;
            if (!dataProvider)
            {
                dataProvider = {};
            }
            var _loc_6:* = param2;
            insertMenuBarItem(param1, _loc_5);
            return;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            var _loc_1:* = parent;
            while (_loc_1)
            {
                
                if (_loc_1 is ApplicationControlBar)
                {
                    isInsideACB = true;
                    break;
                }
                _loc_1 = _loc_1.parent;
            }
            updateBackground();
            return;
        }// end function

        override protected function focusOutHandler(event:FocusEvent) : void
        {
            super.focusOutHandler(event);
            if (supposedToLoseFocus)
            {
                getMenuAt(openMenuIndex).hide();
            }
            supposedToLoseFocus = false;
            return;
        }// end function

        public function itemToLabel(param1:Object) : String
        {
            var data:* = param1;
            if (data == null)
            {
                return " ";
            }
            if (labelFunction != null)
            {
                return labelFunction(data);
            }
            if (data is XML)
            {
                try
                {
                    if (data[labelField].length() != 0)
                    {
                        data = data[labelField];
                    }
                }
                catch (e:Error)
                {
                }
            }
            else if (data is Object)
            {
                try
                {
                    if (data[labelField] != null)
                    {
                        data = data[labelField];
                    }
                }
                catch (e:Error)
                {
                }
            }
            else if (data is String)
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

        private function mouseOutHandler(event:MouseEvent) : void
        {
            var _loc_5:MenuEvent = null;
            var _loc_2:* = IMenuBarItemRenderer(event.target);
            var _loc_3:* = _loc_2.menuBarItemIndex;
            var _loc_4:* = getMenuAt(_loc_3);
            if (_loc_2.enabled && openMenuIndex != _loc_3)
            {
                menuBarItems[_loc_3].menuBarItemState = "itemUpSkin";
            }
            if (_loc_2.mx.core:IDataRenderer::data && _loc_4.dataDescriptor.getType(_loc_2.mx.core:IDataRenderer::data) != "separator")
            {
                _loc_5 = new MenuEvent(MenuEvent.ITEM_ROLL_OUT);
                _loc_5.index = _loc_3;
                _loc_5.menuBar = this;
                _loc_5.label = itemToLabel(_loc_2.mx.core:IDataRenderer::data);
                _loc_5.item = _loc_2.mx.core:IDataRenderer::data;
                _loc_5.itemRenderer = _loc_2;
                dispatchEvent(_loc_5);
            }
            return;
        }// end function

        private function collectionChangeHandler(event:Event) : void
        {
            var _loc_2:CollectionEvent = null;
            if (event is CollectionEvent)
            {
                _loc_2 = CollectionEvent(event);
                if (_loc_2.kind == CollectionEventKind.ADD)
                {
                    dataProviderChanged = true;
                    invalidateProperties();
                }
                else if (_loc_2.kind == CollectionEventKind.REMOVE)
                {
                    dataProviderChanged = true;
                    invalidateProperties();
                }
                else if (_loc_2.kind == CollectionEventKind.REFRESH)
                {
                    dataProviderChanged = true;
                    dataProvider = dataProvider;
                    invalidateProperties();
                    invalidateSize();
                }
                else if (_loc_2.kind == CollectionEventKind.RESET)
                {
                    dataProviderChanged = true;
                    invalidateProperties();
                    invalidateSize();
                }
                else if (_loc_2.kind == CollectionEventKind.UPDATE)
                {
                    if (openMenuIndex == -1)
                    {
                        dataProviderChanged = true;
                        invalidateProperties();
                    }
                }
            }
            invalidateDisplayList();
            return;
        }// end function

        override public function notifyStyleChangeInChildren(param1:String, param2:Boolean) : void
        {
            super.notifyStyleChangeInChildren(param1, param2);
            var _loc_3:* = menuBarItems.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                getMenuAt(_loc_4).notifyStyleChangeInChildren(param1, param2);
                _loc_4++;
            }
            return;
        }// end function

        private function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:* = IMenuBarItemRenderer(event.target);
            var _loc_3:* = _loc_2.menuBarItemIndex;
            if (_loc_2.enabled && !isDown)
            {
                getMenuAt(_loc_3).hideAllMenus();
                _loc_2.menuBarItemState = "itemOverSkin";
            }
            return;
        }// end function

        private function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_5:ICollectionView = null;
            var _loc_6:MenuEvent = null;
            var _loc_7:MenuEvent = null;
            var _loc_2:* = IMenuBarItemRenderer(event.target);
            var _loc_3:* = _loc_2.menuBarItemIndex;
            var _loc_4:* = getMenuAt(_loc_3);
            if (_loc_2.enabled)
            {
                _loc_2.menuBarItemState = "itemDownSkin";
                if (!isDown)
                {
                    _loc_4.supposedToLoseFocus = true;
                    _loc_5 = ICollectionView(_loc_4.dataProvider);
                    if (_loc_4.dataDescriptor.isBranch(_loc_2.mx.core:IDataRenderer::data, _loc_2.mx.core:IDataRenderer::data) && _loc_4.dataDescriptor.hasChildren(_loc_2.mx.core:IDataRenderer::data, _loc_2.mx.core:IDataRenderer::data))
                    {
                        showMenu(_loc_3);
                    }
                    else if (_loc_4)
                    {
                        selectedIndex = _loc_3;
                        _loc_6 = new MenuEvent(MenuEvent.MENU_SHOW);
                        _loc_6.menuBar = this;
                        _loc_6.menu = _loc_4;
                        dispatchEvent(_loc_6);
                    }
                    isDown = true;
                }
                else
                {
                    isDown = false;
                }
                if (_loc_4.dataDescriptor.getType(_loc_2.mx.core:IDataRenderer::data) != "separator")
                {
                    _loc_7 = new MenuEvent(MenuEvent.CHANGE);
                    _loc_7.index = _loc_3;
                    _loc_7.menuBar = this;
                    _loc_7.label = itemToLabel(_loc_2.mx.core:IDataRenderer::data);
                    _loc_7.item = _loc_2.mx.core:IDataRenderer::data;
                    _loc_7.itemRenderer = _loc_2;
                    dispatchEvent(_loc_7);
                }
            }
            return;
        }// end function

        public function get dataDescriptor() : IMenuDataDescriptor
        {
            return IMenuDataDescriptor(_dataDescriptor);
        }// end function

        public function get dataProvider() : Object
        {
            if (_rootModel)
            {
                return _rootModel;
            }
            return null;
        }// end function

        private function showMenu(param1:Number) : void
        {
            var _loc_6:Rectangle = null;
            var _loc_8:InterManagerRequest = null;
            selectedIndex = param1;
            var _loc_2:* = menuBarItems[param1];
            var _loc_3:* = getMenuAt(param1);
            var _loc_4:* = systemManager.topLevelSystemManager;
            var _loc_5:* = systemManager.topLevelSystemManager.getSandboxRoot();
            if (_loc_4 != _loc_5)
            {
                _loc_8 = new InterManagerRequest(InterManagerRequest.SYSTEM_MANAGER_REQUEST, false, false, "getVisibleApplicationRect");
                _loc_5.dispatchEvent(_loc_8);
                _loc_6 = Rectangle(_loc_8.value);
            }
            else
            {
                _loc_6 = _loc_4.getVisibleApplicationRect();
            }
            if (_loc_3.parentDisplayObject && (!_loc_3.parent || !_loc_3.parent.contains(_loc_3.parentDisplayObject)))
            {
                PopUpManager.addPopUp(_loc_3, this, false);
                _loc_3.addEventListener(MenuEvent.MENU_HIDE, menuHideHandler, false, EventPriority.DEFAULT_HANDLER);
            }
            UIComponentGlobals.layoutManager.validateClient(_loc_3, true);
            var _loc_7:* = new Point(0, 0);
            _loc_7 = DisplayObject(_loc_2).localToGlobal(_loc_7);
            if (_loc_7.y + _loc_2.height + 1 + _loc_3.getExplicitOrMeasuredHeight() > _loc_6.height + _loc_6.y)
            {
                _loc_7.y = _loc_7.y - _loc_3.getExplicitOrMeasuredHeight();
            }
            else
            {
                _loc_7.y = _loc_7.y + (_loc_2.height + 1);
            }
            if (_loc_7.x + _loc_3.getExplicitOrMeasuredWidth() > _loc_6.width + _loc_6.x)
            {
                _loc_7.x = _loc_6.x + _loc_6.width - _loc_3.getExplicitOrMeasuredWidth();
            }
            _loc_7 = _loc_5.globalToLocal(_loc_7);
            if (isInsideACB)
            {
                _loc_7.y = _loc_7.y + 2;
            }
            _loc_3.show(_loc_7.x, _loc_7.y);
            return;
        }// end function

        public function get menuBarItemRenderer() : IFactory
        {
            return _menuBarItemRenderer;
        }// end function

        public function getMenuAt(param1:int) : Menu
        {
            var _loc_5:Object = null;
            var _loc_6:CSSStyleDeclaration = null;
            if (dataProviderChanged)
            {
                commitProperties();
            }
            var _loc_2:* = menuBarItems[param1];
            var _loc_3:* = _loc_2.mx.core:IDataRenderer::data;
            var _loc_4:* = menus[param1];
            if (menus[param1] == null)
            {
                _loc_4 = new Menu();
                _loc_4.showRoot = false;
                if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
                {
                    _loc_4.styleName = this;
                }
                _loc_5 = getStyle("menuStyleName");
                if (_loc_5)
                {
                    if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
                    {
                        _loc_6 = StyleManager.getStyleDeclaration("." + _loc_5);
                        if (_loc_6)
                        {
                            _loc_4.styleDeclaration = _loc_6;
                        }
                    }
                    else
                    {
                        _loc_4.styleName = _loc_5;
                    }
                }
                _loc_4.sourceMenuBar = this;
                _loc_4.owner = this;
                _loc_4.addEventListener("menuHide", eventHandler);
                _loc_4.addEventListener("itemRollOver", eventHandler);
                _loc_4.addEventListener("itemRollOut", eventHandler);
                _loc_4.addEventListener("menuShow", eventHandler);
                _loc_4.addEventListener("itemClick", eventHandler);
                _loc_4.addEventListener("change", eventHandler);
                _loc_4.iconField = _iconField;
                _loc_4.labelField = _labelField;
                _loc_4.labelFunction = labelFunction;
                _loc_4.dataDescriptor = _dataDescriptor;
                _loc_4.invalidateSize();
                menus[param1] = _loc_4;
                _loc_4.sourceMenuBarItem = _loc_2;
                Menu.popUpMenu(_loc_4, this, _loc_3);
            }
            return _loc_4;
        }// end function

        public function set labelField(param1:String) : void
        {
            if (_labelField != param1)
            {
                _labelField = param1;
                dispatchEvent(new Event("labelFieldChanged"));
            }
            return;
        }// end function

        override protected function commitProperties() : void
        {
            var i:int;
            var cursor:IViewCursor;
            var tmpCollection:ICollectionView;
            var rootItem:*;
            if (showRootChanged)
            {
                if (!_hasRoot)
                {
                    showRootChanged = false;
                }
            }
            if (dataProviderChanged || showRootChanged)
            {
                dataProviderChanged = false;
                showRootChanged = false;
                if (_rootModel && !_showRoot && _hasRoot)
                {
                    rootItem = _rootModel.createCursor().current;
                    if (rootItem != null && _dataDescriptor.isBranch(rootItem, _rootModel) && _dataDescriptor.hasChildren(rootItem, _rootModel))
                    {
                        tmpCollection = _dataDescriptor.getChildren(rootItem, _rootModel);
                    }
                }
                removeAll();
                if (_rootModel)
                {
                    if (!tmpCollection)
                    {
                        tmpCollection = _rootModel;
                    }
                    tmpCollection.addEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false, EventPriority.DEFAULT_HANDLER, true);
                    if (tmpCollection.length > 0)
                    {
                        cursor = tmpCollection.createCursor();
                        i;
                        while (!cursor.afterLast)
                        {
                            
                            try
                            {
                                insertMenuBarItem(i, cursor.current);
                            }
                            catch (e:ItemPendingError)
                            {
                            }
                            cursor.moveNext();
                            i = (i + 1);
                        }
                    }
                }
            }
            if (iconFieldChanged || menuBarItemRendererChanged)
            {
                iconFieldChanged = false;
                menuBarItemRendererChanged = false;
                removeAll();
                if (_rootModel)
                {
                    if (!tmpCollection)
                    {
                        tmpCollection = _rootModel;
                    }
                    if (tmpCollection.length > 0)
                    {
                        cursor = tmpCollection.createCursor();
                        i;
                        while (!cursor.afterLast)
                        {
                            
                            try
                            {
                                insertMenuBarItem(i, cursor.current);
                            }
                            catch (e:ItemPendingError)
                            {
                            }
                            cursor.moveNext();
                            i = (i + 1);
                        }
                    }
                }
            }
            super.commitProperties();
            return;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            var _loc_2:int = 0;
            var _loc_4:String = null;
            var _loc_5:Menu = null;
            var _loc_6:CSSStyleDeclaration = null;
            super.styleChanged(param1);
            var _loc_3:* = menuBarItems.length;
            _loc_2 = 0;
            while (_loc_2 < _loc_3)
            {
                
                getMenuAt(_loc_2).styleChanged(param1);
                _loc_2++;
            }
            if (!param1 || param1 == "" || param1 == "backgroundSkin")
            {
                updateBackground();
            }
            if (param1 == null || param1 == "styleName" || param1 == "menuStyleName")
            {
                _loc_4 = getStyle("menuStyleName");
                if (_loc_4)
                {
                    if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
                    {
                        _loc_6 = StyleManager.getStyleDeclaration("." + _loc_4);
                        if (_loc_6)
                        {
                            _loc_2 = 0;
                            while (_loc_2 < menus.length)
                            {
                                
                                _loc_5 = menus[_loc_2];
                                _loc_5.styleDeclaration = _loc_6;
                                _loc_5.regenerateStyleCache(true);
                                _loc_2++;
                            }
                        }
                    }
                    else
                    {
                        _loc_2 = 0;
                        while (_loc_2 < menus.length)
                        {
                            
                            _loc_5 = menus[_loc_2];
                            _loc_5.styleName = _loc_4;
                            _loc_2++;
                        }
                    }
                }
            }
            return;
        }// end function

        private function removeMenuBarItemAt(param1:int) : void
        {
            if (dataProviderChanged)
            {
                commitProperties();
            }
            var _loc_2:* = menuBarItems[param1];
            if (_loc_2)
            {
                removeChild(DisplayObject(_loc_2));
                menuBarItems.splice(param1, 1);
                invalidateSize();
                invalidateDisplayList();
            }
            return;
        }// end function

        protected function updateBackground() : void
        {
            var _loc_1:Class = null;
            if (isInsideACB)
            {
                setStyle("translucent", true);
            }
            else
            {
                if (background)
                {
                    removeChild(DisplayObject(background));
                    background = null;
                }
                _loc_1 = getStyle("backgroundSkin");
                background = new _loc_1;
                if (background is ISimpleStyleClient)
                {
                    ISimpleStyleClient(background).styleName = this;
                }
                addChildAt(DisplayObject(background), 0);
            }
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:int = 0;
            super.measure();
            _loc_1 = menuBarItems.length;
            measuredWidth = 0;
            measuredHeight = DEFAULT_MEASURED_MIN_HEIGHT;
            var _loc_2:int = 0;
            while (_loc_2 < _loc_1)
            {
                
                measuredWidth = measuredWidth + menuBarItems[_loc_2].getExplicitOrMeasuredWidth();
                measuredHeight = Math.max(measuredHeight, menuBarItems[_loc_2].getExplicitOrMeasuredHeight());
                _loc_2++;
            }
            if (_loc_1 > 0)
            {
                measuredWidth = measuredWidth + 2 * MARGIN_WIDTH;
            }
            else
            {
                measuredWidth = DEFAULT_MEASURED_MIN_WIDTH;
            }
            measuredMinWidth = measuredWidth;
            measuredMinHeight = measuredHeight;
            return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_3:int = 0;
            var _loc_4:Boolean = false;
            var _loc_5:int = 0;
            var _loc_6:Menu = null;
            var _loc_7:ICollectionView = null;
            var _loc_8:IMenuBarItemRenderer = null;
            var _loc_2:* = menuBarItems.length;
            if (event.keyCode == Keyboard.RIGHT || event.keyCode == Keyboard.LEFT)
            {
                inKeyDown = true;
                _loc_3 = openMenuIndex;
                _loc_4 = false;
                _loc_5 = 0;
                while (!_loc_4 && _loc_5 < _loc_2)
                {
                    
                    _loc_5++;
                    _loc_3 = event.keyCode == Keyboard.RIGHT ? ((_loc_3 + 1)) : ((_loc_3 - 1));
                    if (_loc_3 >= _loc_2)
                    {
                        _loc_3 = 0;
                    }
                    else if (_loc_3 < 0)
                    {
                        _loc_3 = _loc_2 - 1;
                    }
                    if (menuBarItems[_loc_3].enabled)
                    {
                        _loc_4 = true;
                    }
                }
                if (_loc_5 <= _loc_2 && _loc_4)
                {
                    menuBarItems[_loc_3].dispatchEvent(new MouseEvent(MouseEvent.MOUSE_OVER));
                }
                event.stopPropagation();
            }
            if (event.keyCode == Keyboard.DOWN)
            {
                if (openMenuIndex != -1)
                {
                    _loc_6 = getMenuAt(openMenuIndex);
                    _loc_6.selectedIndex = 0;
                    supposedToLoseFocus = true;
                    _loc_7 = ICollectionView(_loc_6.dataProvider);
                    _loc_8 = _loc_6.sourceMenuBarItem;
                    if (_loc_6.dataDescriptor.isBranch(_loc_8.mx.core:IDataRenderer::data, _loc_8.mx.core:IDataRenderer::data) && _loc_6.dataDescriptor.hasChildren(_loc_8.mx.core:IDataRenderer::data, _loc_8.mx.core:IDataRenderer::data))
                    {
                        _loc_6.setFocus();
                    }
                }
                event.stopPropagation();
            }
            if (event.keyCode == Keyboard.ENTER || event.keyCode == Keyboard.ESCAPE)
            {
                if (openMenuIndex != -1)
                {
                    getMenuAt(openMenuIndex).hide();
                }
                event.stopPropagation();
            }
            return;
        }// end function

        public function get labelField() : String
        {
            return _labelField;
        }// end function

        public function set selectedIndex(param1:int) : void
        {
            openMenuIndex = param1;
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        private function mouseOverHandler(event:MouseEvent) : void
        {
            var _loc_6:MenuEvent = null;
            var _loc_7:Number = NaN;
            var _loc_8:ICollectionView = null;
            var _loc_9:IMenuBarItemRenderer = null;
            var _loc_10:Menu = null;
            var _loc_2:* = IMenuBarItemRenderer(event.target);
            var _loc_3:* = _loc_2.menuBarItemIndex;
            var _loc_4:Boolean = false;
            var _loc_5:* = getMenuAt(_loc_3);
            if (_loc_2.enabled)
            {
                if (openMenuIndex != -1 || inKeyDown)
                {
                    _loc_7 = openMenuIndex;
                    if (_loc_7 != _loc_3)
                    {
                        isDown = false;
                        if (_loc_7 != -1)
                        {
                            _loc_9 = menuBarItems[_loc_7];
                            _loc_9.dispatchEvent(new MouseEvent(MouseEvent.MOUSE_UP));
                            _loc_9.menuBarItemState = "itemUpSkin";
                            _loc_6 = new MenuEvent(MenuEvent.ITEM_ROLL_OUT);
                            _loc_6.menuBar = this;
                            _loc_6.index = _loc_7;
                            _loc_6.label = itemToLabel(_loc_9.mx.core:IDataRenderer::data);
                            _loc_6.item = _loc_9.mx.core:IDataRenderer::data;
                            _loc_6.itemRenderer = _loc_9;
                            dispatchEvent(_loc_6);
                        }
                        _loc_2.menuBarItemState = "itemDownSkin";
                        _loc_8 = ICollectionView(_loc_5.dataProvider);
                        if (_loc_5.dataDescriptor.isBranch(_loc_2.mx.core:IDataRenderer::data, _loc_2.mx.core:IDataRenderer::data) && _loc_5.dataDescriptor.hasChildren(_loc_2.mx.core:IDataRenderer::data, _loc_2.mx.core:IDataRenderer::data))
                        {
                            showMenu(_loc_3);
                        }
                        else if (_loc_5)
                        {
                            selectedIndex = _loc_3;
                            _loc_6 = new MenuEvent(MenuEvent.MENU_SHOW);
                            _loc_6.menuBar = this;
                            _loc_6.menu = _loc_5;
                            dispatchEvent(_loc_6);
                            _loc_2.menuBarItemState = "itemOverSkin";
                        }
                        isDown = true;
                        if (_loc_5.dataDescriptor.getType(_loc_2.mx.core:IDataRenderer::data) != "separator")
                        {
                            _loc_4 = true;
                            _loc_6 = new MenuEvent(MenuEvent.CHANGE);
                            _loc_6.index = _loc_3;
                            _loc_6.menuBar = this;
                            _loc_6.label = itemToLabel(_loc_2.mx.core:IDataRenderer::data);
                            _loc_6.item = _loc_2.mx.core:IDataRenderer::data;
                            _loc_6.itemRenderer = _loc_2;
                            dispatchEvent(_loc_6);
                        }
                    }
                    else
                    {
                        _loc_10 = getMenuAt(_loc_3);
                        _loc_10.deleteDependentSubMenus();
                        _loc_10.setFocus();
                    }
                }
                else
                {
                    _loc_2.menuBarItemState = "itemOverSkin";
                    isDown = false;
                    if (_loc_5.dataDescriptor.getType(_loc_2.mx.core:IDataRenderer::data) != "separator")
                    {
                        _loc_4 = true;
                    }
                }
                inKeyDown = false;
                if (_loc_4)
                {
                    _loc_6 = new MenuEvent(MenuEvent.ITEM_ROLL_OVER);
                    _loc_6.index = _loc_3;
                    _loc_6.menuBar = this;
                    _loc_6.label = itemToLabel(_loc_2.mx.core:IDataRenderer::data);
                    _loc_6.item = _loc_2.mx.core:IDataRenderer::data;
                    _loc_6.itemRenderer = _loc_2;
                    dispatchEvent(_loc_6);
                }
            }
            return;
        }// end function

        public function set dataDescriptor(param1:IMenuDataDescriptor) : void
        {
            _dataDescriptor = param1;
            menus = [];
            return;
        }// end function

        private function insertMenuBarItem(param1:int, param2:Object) : void
        {
            if (dataProviderChanged)
            {
                commitProperties();
                return;
            }
            var _loc_3:* = menuBarItemRenderer.newInstance();
            _loc_3.styleName = new StyleProxy(this, menuBarItemStyleFilters);
            _loc_3.visible = false;
            _loc_3.enabled = enabled && _dataDescriptor.isEnabled(param2) != false;
            _loc_3.mx.core:IDataRenderer::data = param2;
            _loc_3.menuBar = this;
            _loc_3.menuBarItemIndex = param1;
            addChild(DisplayObject(_loc_3));
            menuBarItems.splice(param1, 0, _loc_3);
            invalidateSize();
            invalidateDisplayList();
            _loc_3.addEventListener(MouseEvent.MOUSE_OVER, mouseOverHandler);
            _loc_3.addEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
            _loc_3.addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler);
            _loc_3.addEventListener(MouseEvent.MOUSE_OUT, mouseOutHandler);
            return;
        }// end function

        public function set dataProvider(param1:Object) : void
        {
            var _loc_3:XMLList = null;
            var _loc_4:Array = null;
            if (_rootModel)
            {
                _rootModel.removeEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler);
            }
            if (typeof(param1) == "string")
            {
                param1 = new XML(param1);
            }
            else if (param1 is XMLNode)
            {
                param1 = new XML(XMLNode(param1).toString());
            }
            else if (param1 is XMLList)
            {
                param1 = new XMLListCollection(param1 as XMLList);
            }
            if (param1 is XML)
            {
                _hasRoot = true;
                _loc_3 = new XMLList();
                _loc_3 = _loc_3 + param1;
                _rootModel = new XMLListCollection(_loc_3);
            }
            else if (param1 is ICollectionView)
            {
                _rootModel = ICollectionView(param1);
                if (_rootModel.length == 1)
                {
                    _hasRoot = true;
                }
            }
            else if (param1 is Array)
            {
                _rootModel = new ArrayCollection(param1 as Array);
            }
            else if (param1 is Object)
            {
                _hasRoot = true;
                _loc_4 = [];
                _loc_4.push(param1);
                _rootModel = new ArrayCollection(_loc_4);
            }
            else
            {
                _rootModel = new ArrayCollection();
            }
            _rootModel.addEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false, 0, true);
            dataProviderChanged = true;
            invalidateProperties();
            var _loc_2:* = new CollectionEvent(CollectionEvent.COLLECTION_CHANGE);
            _loc_2.kind = CollectionEventKind.RESET;
            collectionChangeHandler(_loc_2);
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get selectedIndex() : int
        {
            return openMenuIndex;
        }// end function

        override protected function focusInHandler(event:FocusEvent) : void
        {
            super.focusInHandler(event);
            return;
        }// end function

        private function eventHandler(event:Event) : void
        {
            var _loc_2:String = null;
            if (event is MenuEvent)
            {
                _loc_2 = event.type;
                if (event.type == MenuEvent.MENU_HIDE && MenuEvent(event).menu == menus[openMenuIndex])
                {
                    menuBarItems[openMenuIndex].menuBarItemState = "itemUpSkin";
                    openMenuIndex = -1;
                    dispatchEvent(event as MenuEvent);
                }
                else
                {
                    dispatchEvent(event);
                }
            }
            return;
        }// end function

        public function set showRoot(param1:Boolean) : void
        {
            if (_showRoot != param1)
            {
                showRootChanged = true;
                _showRoot = param1;
                invalidateProperties();
            }
            return;
        }// end function

        private static function menuHideHandler(event:MenuEvent) : void
        {
            var _loc_2:* = Menu(event.target);
            if (!event.isDefaultPrevented() && event.menu == _loc_2)
            {
                _loc_2.supposedToLoseFocus = true;
                PopUpManager.removePopUp(_loc_2);
                _loc_2.removeEventListener(MenuEvent.MENU_HIDE, menuHideHandler);
            }
            return;
        }// end function

    }
}
