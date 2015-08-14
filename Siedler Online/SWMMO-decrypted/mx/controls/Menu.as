package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.utils.*;
    import flash.xml.*;
    import mx.collections.*;
    import mx.controls.listClasses.*;
    import mx.controls.menuClasses.*;
    import mx.controls.treeClasses.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.managers.*;

    public class Menu extends List implements IFocusManagerContainer
    {
        var parentDisplayObject:DisplayObject;
        private var isDirectionLeft:Boolean = false;
        var popupTween:Tween;
        var closeTimer:int = 0;
        var openSubMenuTimer:int = 0;
        var showRootChanged:Boolean = false;
        var sourceMenuBarItem:IMenuBarItemRenderer;
        var _hasRoot:Boolean = false;
        var dataProviderChanged:Boolean = false;
        private var maxMeasuredTypeIconWidth:Number = 0;
        var sourceMenuBar:MenuBar;
        private var maxMeasuredBranchIconWidth:Number = 0;
        private var maxMeasuredIconWidth:Number = 0;
        private var subMenu:Menu;
        var _parentMenu:Menu;
        var _dataDescriptor:IMenuDataDescriptor;
        private var hiddenItem:IListItemRenderer;
        var _showRoot:Boolean = true;
        private var useTwoColumns:Boolean = false;
        var supposedToLoseFocus:Boolean = false;
        private var anchorRow:IListItemRenderer;
        var _rootModel:ICollectionView;
        var _listDataProvider:ICollectionView;
        static var createAccessibilityImplementation:Function;
        static const VERSION:String = "3.5.0.12683";

        public function Menu()
        {
            _dataDescriptor = new DefaultDataDescriptor();
            itemRenderer = new ClassFactory(MenuItemRenderer);
            setRowHeight(19);
            iconField = "icon";
            visible = false;
            return;
        }// end function

        private function moveSelBy(param1:Number, param2:Number) : void
        {
            var _loc_6:Object = null;
            var _loc_8:MenuEvent = null;
            var _loc_9:Object = null;
            var _loc_3:* = param1;
            if (isNaN(_loc_3))
            {
                _loc_3 = -1;
            }
            var _loc_4:* = Math.max(0, (Math.min(rowCount, collection.length) - 1));
            var _loc_5:* = _loc_3;
            var _loc_7:int = 0;
            do
            {
                
                _loc_5 = _loc_5 + param2;
                if (_loc_7 > _loc_4)
                {
                    return;
                }
                _loc_7++;
                if (_loc_5 > _loc_4)
                {
                    _loc_5 = 0;
                }
                else if (_loc_5 < 0)
                {
                    _loc_5 = _loc_4;
                }
                _loc_6 = listItems[_loc_5][0];
            }while (_loc_6.data && (_dataDescriptor.getType(_loc_6.data) == "separator" || !_dataDescriptor.isEnabled(_loc_6.data)))
            if (selectedIndex != -1)
            {
                _loc_9 = listItems[selectedIndex][0];
                _loc_8 = new MenuEvent(MenuEvent.ITEM_ROLL_OUT);
                _loc_8.menu = this;
                _loc_8.index = this.selectedIndex;
                _loc_8.menuBar = sourceMenuBar;
                _loc_8.label = itemToLabel(_loc_9.data);
                _loc_8.item = _loc_9.data;
                _loc_8.itemRenderer = IListItemRenderer(_loc_9);
                getRootMenu().dispatchEvent(_loc_8);
            }
            if (_loc_6.data)
            {
                selectItem(listItems[_loc_5 - verticalScrollPosition][0], false, false);
                _loc_8 = new MenuEvent(MenuEvent.ITEM_ROLL_OVER);
                _loc_8.menu = this;
                _loc_8.index = this.selectedIndex;
                _loc_8.menuBar = sourceMenuBar;
                _loc_8.label = itemToLabel(_loc_6.data);
                _loc_8.item = _loc_6.data;
                _loc_8.itemRenderer = IListItemRenderer(_loc_6);
                getRootMenu().dispatchEvent(_loc_8);
            }
            return;
        }// end function

        override public function measureWidthOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var _loc_6:CursorBookmark = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:Boolean = false;
            var _loc_10:Object = null;
            var _loc_11:MenuListData = null;
            var _loc_12:IListItemRenderer = null;
            var _loc_13:IMenuItemRenderer = null;
            var _loc_3:Number = 0;
            var _loc_4:* = getStyle("leftIconGap");
            var _loc_5:* = getStyle("rightIconGap");
            maxMeasuredIconWidth = 0;
            maxMeasuredTypeIconWidth = 0;
            maxMeasuredBranchIconWidth = 0;
            useTwoColumns = false;
            if (collection && collection.length)
            {
                _loc_6 = iterator.bookmark;
                _loc_7 = param2;
                _loc_8 = 0;
                while (_loc_8 < 2)
                {
                    
                    iterator.seek(CursorBookmark.FIRST, param1);
                    param2 = _loc_7;
                    _loc_9 = false;
                    while (param2)
                    {
                        
                        _loc_10 = iterator.current;
                        var _loc_14:* = getMeasuringRenderer(_loc_10);
                        hiddenItem = getMeasuringRenderer(_loc_10);
                        _loc_12 = _loc_14;
                        _loc_12.explicitWidth = NaN;
                        setupRendererFromData(_loc_12, _loc_10);
                        _loc_3 = Math.max(_loc_12.getExplicitOrMeasuredWidth(), _loc_3);
                        if (_loc_12 is IMenuItemRenderer)
                        {
                            _loc_13 = IMenuItemRenderer(_loc_12);
                            if (_loc_13.measuredIconWidth > maxMeasuredIconWidth)
                            {
                                maxMeasuredIconWidth = _loc_13.measuredIconWidth;
                                _loc_9 = true;
                            }
                            if (_loc_13.measuredTypeIconWidth > maxMeasuredTypeIconWidth)
                            {
                                maxMeasuredTypeIconWidth = _loc_13.measuredTypeIconWidth;
                                _loc_9 = true;
                            }
                            if (_loc_13.measuredBranchIconWidth > maxMeasuredBranchIconWidth)
                            {
                                maxMeasuredBranchIconWidth = _loc_13.measuredBranchIconWidth;
                                _loc_9 = true;
                            }
                            if (_loc_13.measuredIconWidth > 0 && _loc_13.measuredTypeIconWidth)
                            {
                                useTwoColumns = true;
                                _loc_9 = true;
                            }
                        }
                        param2 = param2 - 1;
                        if (!iterator.moveNext())
                        {
                            break;
                        }
                    }
                    if (_loc_8 == 0)
                    {
                        if (!(_loc_9 && (maxMeasuredIconWidth + maxMeasuredTypeIconWidth > _loc_4 || maxMeasuredBranchIconWidth > _loc_5)))
                        {
                            break;
                        }
                    }
                    _loc_8++;
                }
                iterator.seek(_loc_6, 0);
            }
            if (!_loc_3)
            {
                _loc_3 = 200;
            }
            _loc_3 = _loc_3 + (getStyle("paddingLeft") + getStyle("paddingRight"));
            return _loc_3;
        }// end function

        override protected function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:MenuEvent = null;
            var _loc_4:Object = null;
            var _loc_5:Boolean = false;
            if (!enabled || !selectable || !visible)
            {
                return;
            }
            super.mouseUpHandler(event);
            var _loc_3:* = mouseEventToItemRenderer(event);
            if (_loc_3 && _loc_3.data)
            {
                _loc_4 = _loc_3.data;
            }
            if (_loc_4 != null && _dataDescriptor.isEnabled(_loc_4) && !_dataDescriptor.isBranch(_loc_4))
            {
                _loc_5 = _dataDescriptor.getType(_loc_4) != "radio" || !_dataDescriptor.isToggled(_loc_4);
                if (_loc_5)
                {
                    setMenuItemToggled(_loc_4, !_dataDescriptor.isToggled(_loc_4));
                }
                _loc_2 = new MenuEvent(MenuEvent.ITEM_CLICK);
                _loc_2.menu = this;
                _loc_2.index = this.selectedIndex;
                _loc_2.menuBar = sourceMenuBar;
                _loc_2.label = itemToLabel(_loc_4);
                _loc_2.item = _loc_4;
                _loc_2.itemRenderer = _loc_3;
                getRootMenu().dispatchEvent(_loc_2);
                if (_loc_5)
                {
                    _loc_2 = new MenuEvent(MenuEvent.CHANGE);
                    _loc_2.menu = this;
                    _loc_2.index = this.selectedIndex;
                    _loc_2.menuBar = sourceMenuBar;
                    _loc_2.label = itemToLabel(_loc_4);
                    _loc_2.item = _loc_4;
                    _loc_2.itemRenderer = _loc_3;
                    getRootMenu().dispatchEvent(_loc_2);
                }
                hideAllMenus();
            }
            return;
        }// end function

        private function isMouseOverMenu(event:MouseEvent) : Boolean
        {
            var _loc_2:* = DisplayObject(event.target);
            while (_loc_2)
            {
                
                if (_loc_2 is Menu)
                {
                    return true;
                }
                _loc_2 = _loc_2.parent;
            }
            return false;
        }// end function

        override protected function focusOutHandler(event:FocusEvent) : void
        {
            super.focusOutHandler(event);
            if (!supposedToLoseFocus)
            {
                hideAllMenus();
            }
            supposedToLoseFocus = false;
            return;
        }// end function

        function openSubMenu(param1:IListItemRenderer) : void
        {
            var _loc_3:Menu = null;
            var _loc_7:Number = NaN;
            var _loc_12:Number = NaN;
            supposedToLoseFocus = true;
            var _loc_2:* = getRootMenu();
            if (!IMenuItemRenderer(param1).menu)
            {
                _loc_3 = new Menu();
                _loc_3.parentMenu = this;
                _loc_3.owner = this;
                _loc_3.showRoot = showRoot;
                _loc_3.dataDescriptor = _loc_2.dataDescriptor;
                _loc_3.styleName = _loc_2;
                _loc_3.labelField = _loc_2.labelField;
                _loc_3.labelFunction = _loc_2.labelFunction;
                _loc_3.iconField = _loc_2.iconField;
                _loc_3.iconFunction = _loc_2.iconFunction;
                _loc_3.itemRenderer = _loc_2.itemRenderer;
                _loc_3.rowHeight = _loc_2.rowHeight;
                _loc_3.scaleY = _loc_2.scaleY;
                _loc_3.scaleX = _loc_2.scaleX;
                if (param1.data && _dataDescriptor.isBranch(param1.data) && _dataDescriptor.hasChildren(param1.data))
                {
                    _loc_3.dataProvider = _dataDescriptor.getChildren(param1.data);
                }
                _loc_3.sourceMenuBar = sourceMenuBar;
                _loc_3.sourceMenuBarItem = sourceMenuBarItem;
                IMenuItemRenderer(param1).menu = _loc_3;
                PopUpManager.addPopUp(_loc_3, _loc_2, false);
            }
            else
            {
                _loc_3 = IMenuItemRenderer(param1).menu;
            }
            var _loc_4:* = DisplayObject(param1);
            var _loc_5:* = new Point(0, 0);
            _loc_5 = _loc_4.localToGlobal(_loc_5);
            if (_loc_4.root)
            {
                _loc_5 = _loc_4.root.globalToLocal(_loc_5);
            }
            var _loc_6:* = _loc_5.y;
            if (!isDirectionLeft)
            {
                _loc_7 = _loc_5.x + param1.width;
            }
            else
            {
                _loc_7 = _loc_5.x - _loc_3.getExplicitOrMeasuredWidth();
            }
            var _loc_8:* = systemManager.getVisibleApplicationRect();
            var _loc_9:* = systemManager.getSandboxRoot();
            var _loc_10:* = systemManager.getSandboxRoot().localToGlobal(new Point(_loc_7, _loc_6));
            var _loc_11:* = systemManager.getSandboxRoot().localToGlobal(new Point(_loc_7, _loc_6)).x + _loc_3.getExplicitOrMeasuredWidth() - _loc_8.right;
            if (systemManager.getSandboxRoot().localToGlobal(new Point(_loc_7, _loc_6)).x + _loc_3.getExplicitOrMeasuredWidth() - _loc_8.right > 0 || _loc_10.x < _loc_8.x)
            {
                _loc_12 = getExplicitOrMeasuredWidth() + _loc_3.getExplicitOrMeasuredWidth();
                if (isDirectionLeft)
                {
                    _loc_12 = _loc_12 * -1;
                }
                _loc_7 = Math.max(_loc_7 - _loc_12, 0);
                _loc_10 = new Point(_loc_7, _loc_6);
                _loc_10 = _loc_9.localToGlobal(_loc_10);
                _loc_11 = Math.max(0, _loc_10.x + width - _loc_8.right);
                _loc_7 = Math.max(_loc_7 - _loc_11, 0);
            }
            _loc_3.isDirectionLeft = this.x > _loc_7;
            _loc_11 = _loc_10.y + height - _loc_8.bottom;
            if (_loc_11 > 0 || _loc_10.y < _loc_8.y)
            {
                _loc_6 = Math.max(_loc_6 - _loc_11, 0);
            }
            _loc_3.show(_loc_7, _loc_6);
            subMenu = _loc_3;
            clearInterval(openSubMenuTimer);
            openSubMenuTimer = 0;
            return;
        }// end function

        public function get parentMenu() : Menu
        {
            return _parentMenu;
        }// end function

        private function parentRowHeightHandler(event:Event) : void
        {
            rowHeight = parentMenu.rowHeight;
            return;
        }// end function

        function hideAllMenus() : void
        {
            getRootMenu().hide();
            getRootMenu().deleteDependentSubMenus();
            return;
        }// end function

        override public function dispatchEvent(event:Event) : Boolean
        {
            var _loc_2:MenuEvent = null;
            if (!(event is MenuEvent) && event is ListEvent && (event.type == ListEvent.ITEM_ROLL_OUT || event.type == ListEvent.ITEM_ROLL_OVER || event.type == ListEvent.CHANGE))
            {
                event.stopImmediatePropagation();
            }
            if (!(event is MenuEvent) && event is ListEvent && event.type == ListEvent.ITEM_CLICK)
            {
                _loc_2 = new MenuEvent(event.type, event.bubbles, event.cancelable);
                _loc_2.item = ListEvent(event).itemRenderer.data;
                _loc_2.label = itemToLabel(ListEvent(event).itemRenderer);
                return super.dispatchEvent(_loc_2);
            }
            return super.dispatchEvent(event);
        }// end function

        function deleteDependentSubMenus() : void
        {
            var _loc_3:Menu = null;
            var _loc_1:* = listItems.length;
            var _loc_2:int = 0;
            while (_loc_2 < _loc_1)
            {
                
                if (listItems[_loc_2][0])
                {
                    _loc_3 = IMenuItemRenderer(listItems[_loc_2][0]).menu;
                    if (_loc_3)
                    {
                        _loc_3.deleteDependentSubMenus();
                        PopUpManager.removePopUp(_loc_3);
                        IMenuItemRenderer(listItems[_loc_2][0]).menu = null;
                    }
                }
                _loc_2++;
            }
            return;
        }// end function

        public function hide() : void
        {
            var _loc_1:DisplayObject = null;
            var _loc_2:MenuEvent = null;
            if (visible)
            {
                if (popupTween)
                {
                    popupTween.endTween();
                }
                clearSelected();
                if (anchorRow)
                {
                    drawItem(anchorRow, false, false);
                    anchorRow = null;
                }
                visible = false;
                _loc_1 = systemManager.getSandboxRoot();
                _loc_1.removeEventListener(MouseEvent.MOUSE_DOWN, mouseDownOutsideHandler);
                removeEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, mouseDownOutsideHandler);
                _loc_2 = new MenuEvent(MenuEvent.MENU_HIDE);
                _loc_2.menu = this;
                _loc_2.menuBar = sourceMenuBar;
                getRootMenu().dispatchEvent(_loc_2);
            }
            return;
        }// end function

        override public function set horizontalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        public function set parentMenu(param1:Menu) : void
        {
            _parentMenu = param1;
            param1.addEventListener(FlexEvent.HIDE, parentHideHandler, false, 0, true);
            param1.addEventListener("rowHeightChanged", parentRowHeightHandler, false, 0, true);
            param1.addEventListener("iconFieldChanged", parentIconFieldHandler, false, 0, true);
            param1.addEventListener("iconFunctionChanged", parentIconFunctionHandler, false, 0, true);
            param1.addEventListener("labelFieldChanged", parentLabelFieldHandler, false, 0, true);
            param1.addEventListener("labelFunctionChanged", parentLabelFunctionHandler, false, 0, true);
            param1.addEventListener("itemRendererChanged", parentItemRendererHandler, false, 0, true);
            return;
        }// end function

        protected function setMenuItemToggled(param1:Object, param2:Boolean) : void
        {
            var _loc_3:String = null;
            var _loc_4:int = 0;
            var _loc_5:IListItemRenderer = null;
            var _loc_6:Object = null;
            itemsSizeChanged = true;
            invalidateDisplayList();
            if (_dataDescriptor.getType(param1) == "radio")
            {
                _loc_3 = _dataDescriptor.getGroupName(param1);
                _loc_4 = 0;
                while (_loc_4 < listItems.length)
                {
                    
                    _loc_5 = listItems[_loc_4][0];
                    _loc_6 = _loc_5.data;
                    if (_dataDescriptor.getType(_loc_6) == "radio" && _dataDescriptor.getGroupName(_loc_6) == _loc_3)
                    {
                        _dataDescriptor.setToggled(_loc_6, _loc_6 == param1);
                    }
                    _loc_4++;
                }
            }
            if (param2 != _dataDescriptor.isToggled(param1))
            {
                _dataDescriptor.setToggled(param1, param2);
            }
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:EdgeMetrics = null;
            var _loc_2:int = 0;
            super.measure();
            if (!dataProvider || dataProvider.length == 0)
            {
                measuredWidth = 0;
                measuredHeight = 0;
            }
            else
            {
                _loc_1 = viewMetrics;
                var _loc_3:* = measureWidthOfItems(0, dataProvider.length);
                measuredWidth = measureWidthOfItems(0, dataProvider.length);
                measuredMinWidth = _loc_3;
                if (variableRowHeight)
                {
                    _loc_2 = measureHeightOfItems(0, dataProvider.length);
                }
                else
                {
                    _loc_2 = dataProvider.length * rowHeight;
                }
                var _loc_3:* = _loc_2 + _loc_1.top + _loc_1.bottom;
                measuredHeight = _loc_2 + _loc_1.top + _loc_1.bottom;
                measuredMinHeight = _loc_3;
            }
            return;
        }// end function

        override protected function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_3:Object = null;
            var _loc_2:* = mouseEventToItemRenderer(event);
            if (_loc_2 && _loc_2.data)
            {
                _loc_3 = _loc_2.data;
            }
            if (_loc_3 && _dataDescriptor.isEnabled(_loc_3) && !_dataDescriptor.isBranch(_loc_3))
            {
                super.mouseDownHandler(event);
            }
            return;
        }// end function

        override protected function mouseEventToItemRenderer(event:MouseEvent) : IListItemRenderer
        {
            var _loc_2:* = super.mouseEventToItemRenderer(event);
            if (_loc_2 && _loc_2.data && _dataDescriptor.getType(_loc_2.data) == "separator")
            {
                return null;
            }
            return _loc_2;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_5:MenuEvent = null;
            var _loc_2:* = selectedIndex == -1 ? (null) : (listItems[selectedIndex - verticalScrollPosition][0]);
            var _loc_3:* = _loc_2 ? (_loc_2.data) : (null);
            var _loc_4:* = _loc_2 ? (IMenuItemRenderer(_loc_2).menu) : (null);
            if (event.keyCode == Keyboard.UP)
            {
                if (_loc_3 && _dataDescriptor.isBranch(_loc_3) && _loc_4 && _loc_4.visible)
                {
                    supposedToLoseFocus = true;
                    _loc_4.setFocus();
                    _loc_4.moveSelBy(_loc_4.dataProvider.length, -1);
                }
                else
                {
                    moveSelBy(selectedIndex, -1);
                }
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.DOWN)
            {
                if (_loc_3 && _dataDescriptor.isBranch(_loc_3) && _loc_4 && _loc_4.visible)
                {
                    supposedToLoseFocus = true;
                    _loc_4.setFocus();
                    _loc_4.moveSelBy(-1, 1);
                }
                else
                {
                    moveSelBy(selectedIndex, 1);
                }
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.RIGHT)
            {
                if (_loc_3 && _dataDescriptor.isBranch(_loc_3))
                {
                    openSubMenu(_loc_2);
                    _loc_4 = IMenuItemRenderer(_loc_2).menu;
                    supposedToLoseFocus = true;
                    _loc_4.setFocus();
                    _loc_4.moveSelBy(-1, 1);
                }
                else if (sourceMenuBar)
                {
                    supposedToLoseFocus = true;
                    sourceMenuBar.setFocus();
                    sourceMenuBar.dispatchEvent(event);
                }
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.LEFT)
            {
                if (_parentMenu)
                {
                    supposedToLoseFocus = true;
                    hide();
                    _parentMenu.setFocus();
                }
                else if (sourceMenuBar)
                {
                    supposedToLoseFocus = true;
                    sourceMenuBar.setFocus();
                    sourceMenuBar.dispatchEvent(event);
                }
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.ENTER || event.keyCode == Keyboard.SPACE)
            {
                if (_loc_3 && _dataDescriptor.isBranch(_loc_3))
                {
                    openSubMenu(_loc_2);
                    _loc_4 = IMenuItemRenderer(_loc_2).menu;
                    supposedToLoseFocus = true;
                    _loc_4.setFocus();
                    _loc_4.moveSelBy(-1, 1);
                }
                else if (_loc_3)
                {
                    setMenuItemToggled(_loc_3, !_dataDescriptor.isToggled(_loc_3));
                    _loc_5 = new MenuEvent(MenuEvent.ITEM_CLICK);
                    _loc_5.menu = this;
                    _loc_5.index = this.selectedIndex;
                    _loc_5.menuBar = sourceMenuBar;
                    _loc_5.label = itemToLabel(_loc_3);
                    _loc_5.item = _loc_3;
                    _loc_5.itemRenderer = _loc_2;
                    getRootMenu().dispatchEvent(_loc_5);
                    _loc_5 = new MenuEvent(MenuEvent.CHANGE);
                    _loc_5.menu = this;
                    _loc_5.index = this.selectedIndex;
                    _loc_5.menuBar = sourceMenuBar;
                    _loc_5.label = itemToLabel(_loc_3);
                    _loc_5.item = _loc_3;
                    _loc_5.itemRenderer = _loc_2;
                    getRootMenu().dispatchEvent(_loc_5);
                    hideAllMenus();
                }
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.TAB)
            {
                _loc_5 = new MenuEvent(MenuEvent.MENU_HIDE);
                _loc_5.menu = getRootMenu();
                _loc_5.menuBar = sourceMenuBar;
                getRootMenu().dispatchEvent(_loc_5);
                hideAllMenus();
                event.stopPropagation();
            }
            else if (event.keyCode == Keyboard.ESCAPE)
            {
                if (_parentMenu)
                {
                    supposedToLoseFocus = true;
                    hide();
                    _parentMenu.setFocus();
                }
                else
                {
                    _loc_5 = new MenuEvent(MenuEvent.MENU_HIDE);
                    _loc_5.menu = getRootMenu();
                    _loc_5.menuBar = sourceMenuBar;
                    getRootMenu().dispatchEvent(_loc_5);
                    hideAllMenus();
                    event.stopPropagation();
                }
            }
            return;
        }// end function

        private function parentItemRendererHandler(event:Event) : void
        {
            itemRenderer = parentMenu.itemRenderer;
            return;
        }// end function

        function onTweenEnd(param1:Object) : void
        {
            UIComponent.resumeBackgroundProcessing();
            scrollRect = null;
            popupTween = null;
            return;
        }// end function

        public function set dataDescriptor(param1:IMenuDataDescriptor) : void
        {
            _dataDescriptor = param1;
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            var _loc_2:XMLList = null;
            var _loc_3:Array = null;
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
                _loc_2 = new XMLList();
                _loc_2 = _loc_2 + param1;
                _rootModel = new XMLListCollection(_loc_2);
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
                _loc_3 = [];
                _loc_3.push(param1);
                _rootModel = new ArrayCollection(_loc_3);
            }
            else
            {
                _rootModel = new ArrayCollection();
            }
            dataProviderChanged = true;
            invalidateProperties();
            return;
        }// end function

        override protected function drawItem(param1:IListItemRenderer, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:Boolean = false) : void
        {
            if (!getStyle("useRollOver"))
            {
                super.drawItem(param1, param2, false, false, param5);
            }
            else
            {
                super.drawItem(param1, param2, param3, param4, param5);
            }
            return;
        }// end function

        private function parentLabelFieldHandler(event:Event) : void
        {
            labelField = parentMenu.labelField;
            return;
        }// end function

        override protected function collectionChangeHandler(event:Event) : void
        {
            var _loc_2:CollectionEvent = null;
            if (event is CollectionEvent)
            {
                _loc_2 = CollectionEvent(event);
                if (_loc_2.kind == CollectionEventKind.ADD)
                {
                    super.collectionChangeHandler(event);
                    dataProviderChanged = true;
                    invalidateProperties();
                    invalidateSize();
                    UIComponentGlobals.layoutManager.validateClient(this);
                    setActualSize(getExplicitOrMeasuredWidth(), getExplicitOrMeasuredHeight());
                }
                else if (_loc_2.kind == CollectionEventKind.REMOVE)
                {
                    super.collectionChangeHandler(event);
                    dataProviderChanged = true;
                    invalidateProperties();
                    invalidateSize();
                    UIComponentGlobals.layoutManager.validateClient(this);
                    setActualSize(getExplicitOrMeasuredWidth(), getExplicitOrMeasuredHeight());
                }
                else if (_loc_2.kind == CollectionEventKind.REFRESH)
                {
                    dataProviderChanged = true;
                    invalidateProperties();
                    invalidateSize();
                }
                else if (_loc_2.kind == CollectionEventKind.RESET)
                {
                    dataProviderChanged = true;
                    invalidateProperties();
                    invalidateSize();
                }
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        override protected function makeListData(param1:Object, param2:String, param3:int) : BaseListData
        {
            var _loc_4:* = new MenuListData(itemToLabel(param1), itemToIcon(param1), labelField, param2, this, param3);
            new MenuListData(itemToLabel(param1), itemToIcon(param1), labelField, param2, this, param3).maxMeasuredIconWidth = maxMeasuredIconWidth;
            _loc_4.maxMeasuredTypeIconWidth = maxMeasuredTypeIconWidth;
            _loc_4.maxMeasuredBranchIconWidth = maxMeasuredBranchIconWidth;
            _loc_4.useTwoColumns = useTwoColumns;
            return _loc_4;
        }// end function

        public function get showRoot() : Boolean
        {
            return _showRoot;
        }// end function

        private function parentLabelFunctionHandler(event:Event) : void
        {
            labelFunction = parentMenu.labelFunction;
            return;
        }// end function

        private function getRowIndex(param1:IListItemRenderer) : int
        {
            var _loc_3:IListItemRenderer = null;
            var _loc_2:int = 0;
            while (_loc_2 < listItems.length)
            {
                
                _loc_3 = listItems[_loc_2][0];
                if (_loc_3 && _loc_3.data && _dataDescriptor.getType(_loc_3.data) != "separator")
                {
                    if (_loc_3 == param1)
                    {
                        return _loc_2;
                    }
                }
                _loc_2++;
            }
            return -1;
        }// end function

        private function parentIconFunctionHandler(event:Event) : void
        {
            iconFunction = parentMenu.iconFunction;
            return;
        }// end function

        function get subMenus() : Array
        {
            var _loc_1:Array = [];
            var _loc_2:int = 0;
            while (_loc_2 < listItems.length)
            {
                
                _loc_1.push(listItems[_loc_2][0].menu);
                _loc_2++;
            }
            return _loc_1;
        }// end function

        override public function setFocus() : void
        {
            super.setFocus();
            return;
        }// end function

        public function get hasRoot() : Boolean
        {
            return _hasRoot;
        }// end function

        private function parentHideHandler(event:FlexEvent) : void
        {
            visible = false;
            return;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (createAccessibilityImplementation != null)
            {
                createAccessibilityImplementation(this);
            }
            return;
        }// end function

        private function closeSubMenu(param1:Menu) : void
        {
            param1.hide();
            clearInterval(param1.closeTimer);
            param1.closeTimer = 0;
            return;
        }// end function

        override protected function mouseOutHandler(event:MouseEvent) : void
        {
            var _loc_3:Object = null;
            if (!enabled || !selectable || !visible)
            {
                return;
            }
            systemManager.removeEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true);
            var _loc_2:* = mouseEventToItemRenderer(event);
            if (!_loc_2)
            {
                return;
            }
            if (_loc_2 && _loc_2.data)
            {
                _loc_3 = _loc_2.data;
            }
            if (openSubMenuTimer)
            {
                clearInterval(openSubMenuTimer);
                openSubMenuTimer = 0;
            }
            if (itemRendererContains(_loc_2, event.relatedObject) || itemRendererContains(_loc_2, DisplayObject(event.target)) || event.relatedObject == highlightIndicator || event.relatedObject == listContent || !highlightItemRenderer)
            {
                return;
            }
            if (getStyle("useRollOver") && _loc_3)
            {
                clearHighlight(_loc_2);
            }
            return;
        }// end function

        override public function get horizontalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        private function mouseDownOutsideHandler(event:Event) : void
        {
            var _loc_2:MouseEvent = null;
            if (event is MouseEvent)
            {
                _loc_2 = MouseEvent(event);
                if (!isMouseOverMenu(_loc_2) && !isMouseOverMenuBarItem(_loc_2))
                {
                    hideAllMenus();
                }
            }
            else if (event is SandboxMouseEvent)
            {
                hideAllMenus();
            }
            return;
        }// end function

        override protected function configureScrollBars() : void
        {
            return;
        }// end function

        public function get dataDescriptor() : IMenuDataDescriptor
        {
            return IMenuDataDescriptor(_dataDescriptor);
        }// end function

        override public function get dataProvider() : Object
        {
            var _loc_1:* = super.dataProvider;
            if (_loc_1 == null)
            {
                if (_rootModel != null)
                {
                    return _rootModel;
                }
            }
            else
            {
                return _loc_1;
            }
            return null;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            super.styleChanged(param1);
            deleteDependentSubMenus();
            return;
        }// end function

        function onTweenUpdate(param1:Object) : void
        {
            scrollRect = new Rectangle(0, 0, param1[0], param1[1]);
            return;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:ICollectionView = null;
            var _loc_2:* = undefined;
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
                    _loc_2 = _rootModel.createCursor().current;
                    if (_loc_2 != null && _dataDescriptor.isBranch(_loc_2, _rootModel) && _dataDescriptor.hasChildren(_loc_2, _rootModel))
                    {
                        _loc_1 = _dataDescriptor.getChildren(_loc_2, _rootModel);
                    }
                }
                if (_listDataProvider)
                {
                    _listDataProvider.removeEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false);
                }
                if (_rootModel)
                {
                    if (!_loc_1)
                    {
                        _loc_1 = _rootModel;
                    }
                    _listDataProvider = _loc_1;
                    super.dataProvider = _loc_1;
                    _listDataProvider.addEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false, EventPriority.DEFAULT_HANDLER, true);
                }
                else
                {
                    _listDataProvider = null;
                    super.dataProvider = null;
                }
            }
            super.commitProperties();
            return;
        }// end function

        private function parentIconFieldHandler(event:Event) : void
        {
            iconField = parentMenu.iconField;
            return;
        }// end function

        function getRootMenu() : Menu
        {
            var _loc_1:Menu = this;
            while (_loc_1.parentMenu)
            {
                
                _loc_1 = _loc_1.parentMenu;
            }
            return _loc_1;
        }// end function

        override protected function mouseClickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        override public function set verticalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        override function clearHighlight(param1:IListItemRenderer) : void
        {
            var _loc_4:MenuEvent = null;
            var _loc_2:* = itemToUID(param1.data);
            drawItem(visibleData[_loc_2], isItemSelected(param1.data), false, _loc_2 == caretUID);
            var _loc_3:* = itemRendererToIndices(param1);
            if (_loc_3)
            {
                _loc_4 = new MenuEvent(MenuEvent.ITEM_ROLL_OUT);
                _loc_4.menu = this;
                _loc_4.index = getRowIndex(param1);
                _loc_4.menuBar = sourceMenuBar;
                _loc_4.label = itemToLabel(param1.data);
                _loc_4.item = param1.data;
                _loc_4.itemRenderer = param1;
                getRootMenu().dispatchEvent(_loc_4);
            }
            return;
        }// end function

        override protected function mouseOverHandler(event:MouseEvent) : void
        {
            var item:Object;
            var menuEvent:MenuEvent;
            var event:* = event;
            if (!enabled || !selectable || !visible)
            {
                return;
            }
            systemManager.addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true, 0, true);
            var row:* = mouseEventToItemRenderer(event);
            if (!row)
            {
                return;
            }
            if (row && row.data)
            {
                item = row.data;
            }
            isPressed = event.buttonDown;
            if (row && row != anchorRow)
            {
                if (anchorRow)
                {
                    drawItem(anchorRow, false, false);
                }
                if (subMenu)
                {
                    subMenu.supposedToLoseFocus = true;
                    subMenu.closeTimer = setTimeout(closeSubMenu, 250, subMenu);
                }
                subMenu = null;
                anchorRow = null;
            }
            else if (subMenu && subMenu.subMenu)
            {
                subMenu.subMenu.hide();
            }
            if (_dataDescriptor.isBranch(item) && _dataDescriptor.isEnabled(item))
            {
                anchorRow = row;
                if (subMenu && subMenu.closeTimer)
                {
                    clearInterval(subMenu.closeTimer);
                    subMenu.closeTimer = 0;
                }
                if (!subMenu || !subMenu.visible)
                {
                    if (openSubMenuTimer)
                    {
                        clearInterval(openSubMenuTimer);
                    }
                    openSubMenuTimer = setTimeout(function (param1:IListItemRenderer) : void
            {
                null.openSubMenu(null);
                return;
            }// end function
            , 250, row);
                }
            }
            if (item && _dataDescriptor.isEnabled(item))
            {
                if (event.relatedObject)
                {
                    if (itemRendererContains(row, event.relatedObject) || row == lastHighlightItemRenderer || event.relatedObject == highlightIndicator)
                    {
                        return;
                    }
                }
            }
            if (row)
            {
                drawItem(row, false, Boolean(item && _dataDescriptor.isEnabled(item)));
                if (isPressed)
                {
                    if (item && _dataDescriptor.isEnabled(item))
                    {
                        if (!_dataDescriptor.isBranch(item))
                        {
                            selectItem(row, event.shiftKey, event.ctrlKey);
                        }
                        else
                        {
                            clearSelected();
                        }
                    }
                }
                if (item && _dataDescriptor.isEnabled(item))
                {
                    menuEvent = new MenuEvent(MenuEvent.ITEM_ROLL_OVER);
                    menuEvent.menu = this;
                    menuEvent.index = getRowIndex(row);
                    menuEvent.menuBar = sourceMenuBar;
                    menuEvent.label = itemToLabel(item);
                    menuEvent.item = item;
                    menuEvent.itemRenderer = row;
                    getRootMenu().dispatchEvent(menuEvent);
                }
            }
            return;
        }// end function

        override public function get verticalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            border.move(0, 0);
            border.visible = dataProvider != null && dataProvider.length > 0;
            if (hiddenItem)
            {
                hiddenItem.setActualSize(param1, hiddenItem.getExplicitOrMeasuredHeight());
            }
            return;
        }// end function

        private function isMouseOverMenuBarItem(event:MouseEvent) : Boolean
        {
            if (!sourceMenuBarItem)
            {
                return false;
            }
            var _loc_2:* = DisplayObject(event.target);
            while (_loc_2)
            {
                
                if (_loc_2 == sourceMenuBarItem)
                {
                    return true;
                }
                _loc_2 = _loc_2.parent;
            }
            return false;
        }// end function

        public function show(param1:Object = null, param2:Object = null) : void
        {
            var _loc_7:Rectangle = null;
            var _loc_8:Point = null;
            var _loc_9:Number = NaN;
            var _loc_10:InterManagerRequest = null;
            if (collection && collection.length == 0)
            {
                return;
            }
            if (parentMenu && !parentMenu.visible)
            {
                return;
            }
            if (visible)
            {
                return;
            }
            if (parentDisplayObject && (!parent || !parent.contains(parentDisplayObject)))
            {
                PopUpManager.addPopUp(this, parentDisplayObject, false);
                addEventListener(MenuEvent.MENU_HIDE, menuHideHandler, false, EventPriority.DEFAULT_HANDLER);
            }
            var _loc_3:* = new MenuEvent(MenuEvent.MENU_SHOW);
            _loc_3.menu = this;
            _loc_3.menuBar = sourceMenuBar;
            getRootMenu().dispatchEvent(_loc_3);
            systemManager.activate(this);
            if (param1 !== null && !isNaN(Number(param1)))
            {
                x = Number(param1);
            }
            if (param2 !== null && !isNaN(Number(param2)))
            {
                y = Number(param2);
            }
            var _loc_4:* = systemManager.topLevelSystemManager;
            var _loc_5:* = systemManager.topLevelSystemManager.getSandboxRoot();
            if (getRootMenu() != this)
            {
                _loc_8 = new Point(x, y);
                _loc_8 = _loc_5.localToGlobal(_loc_8);
                if (_loc_4 != _loc_5)
                {
                    _loc_10 = new InterManagerRequest(InterManagerRequest.SYSTEM_MANAGER_REQUEST, false, false, "getVisibleApplicationRect");
                    _loc_5.dispatchEvent(_loc_10);
                    _loc_7 = Rectangle(_loc_10.value);
                }
                else
                {
                    _loc_7 = _loc_4.getVisibleApplicationRect();
                }
                _loc_9 = _loc_8.x + width - _loc_7.right;
                if (_loc_9 > 0)
                {
                    x = Math.max(x - _loc_9, 0);
                }
                _loc_9 = _loc_8.y + height - _loc_7.bottom;
                if (_loc_9 > 0)
                {
                    y = Math.max(y - _loc_9, 0);
                }
            }
            UIComponentGlobals.layoutManager.validateClient(this, true);
            setActualSize(getExplicitOrMeasuredWidth(), getExplicitOrMeasuredHeight());
            cacheAsBitmap = true;
            var _loc_6:* = getStyle("openDuration");
            if (getStyle("openDuration") != 0)
            {
                scrollRect = new Rectangle(0, 0, unscaledWidth, 0);
                visible = true;
                UIComponentGlobals.layoutManager.validateNow();
                UIComponent.suspendBackgroundProcessing();
                popupTween = new Tween(this, [0, 0], [unscaledWidth, unscaledHeight], _loc_6);
            }
            else
            {
                UIComponentGlobals.layoutManager.validateNow();
                visible = true;
            }
            focusManager.setFocus(this);
            supposedToLoseFocus = true;
            _loc_5.addEventListener(MouseEvent.MOUSE_DOWN, mouseDownOutsideHandler, false, 0, true);
            addEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, mouseDownOutsideHandler, false, 0, true);
            return;
        }// end function

        public function set showRoot(param1:Boolean) : void
        {
            if (_showRoot != param1)
            {
                _showRoot = param1;
                showRootChanged = true;
                invalidateProperties();
            }
            return;
        }// end function

        private static function menuHideHandler(event:MenuEvent) : void
        {
            var _loc_2:* = Menu.Menu(event.target);
            if (!event.isDefaultPrevented() && event.menu == _loc_2)
            {
                _loc_2.supposedToLoseFocus = true;
                PopUpManager.removePopUp(_loc_2);
                _loc_2.removeEventListener(MenuEvent.MENU_HIDE, menuHideHandler);
            }
            return;
        }// end function

        public static function popUpMenu(param1:Menu, param2:DisplayObjectContainer, param3:Object) : void
        {
            param1.parentDisplayObject = param2 ? (param2) : (DisplayObject(Application.application));
            if (!param3)
            {
                param3 = new XML();
            }
            param1.supposedToLoseFocus = true;
            param1.dataProvider = param3;
            return;
        }// end function

        public static function createMenu(param1:DisplayObjectContainer, param2:Object, param3:Boolean = true) : Menu
        {
            var _loc_4:Menu = null;
            _loc_4 = new Menu;
            _loc_4.tabEnabled = false;
            _loc_4.owner = DisplayObjectContainer(Application.application);
            _loc_4.showRoot = param3;
            popUpMenu(_loc_4, param1, param2);
            return _loc_4;
        }// end function

    }
}
