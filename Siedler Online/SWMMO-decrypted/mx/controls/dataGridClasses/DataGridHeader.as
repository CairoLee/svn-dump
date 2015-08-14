package mx.controls.dataGridClasses
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class DataGridHeader extends DataGridHeaderBase
    {
        private var headerBGSkinChanged:Boolean = false;
        private var lastItemDown:IListItemRenderer;
        protected var dataGrid:DataGrid;
        private var resizeGraphic:IFlexDisplayObject;
        protected var cachedPaddingBottom:Number = 0;
        private var headerSepSkinChanged:Boolean = false;
        var columnDropIndicator:IFlexDisplayObject;
        private var separators:Array;
        protected var headerItems:Array;
        private var startX:Number;
        var sortArrow:IFlexDisplayObject;
        private var dropColumnIndex:int = -1;
        private var allowItemSizeChangeNotification:Boolean = true;
        public var bottomOffset:Number = 0;
        private var lastPt:Point;
        private var resizeCursorID:int = 0;
        protected var cachedPaddingTop:Number = 0;
        public var topOffset:Number = 0;
        private var minX:Number;
        public var rightOffset:Number = 0;
        protected var cachedHeaderHeight:Number = 0;
        public var needRightSeparatorEvents:Boolean = false;
        public var needRightSeparator:Boolean = false;
        private var separatorAffordance:Number = 3;
        public var leftOffset:Number = 0;

        public function DataGridHeader()
        {
            headerItems = [];
            addEventListener(MouseEvent.MOUSE_OVER, mouseOverHandler);
            addEventListener(MouseEvent.MOUSE_OUT, mouseOutHandler);
            addEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
            addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler);
            return;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            super.enabled = param1;
            if (sortArrow)
            {
                removeChild(DisplayObject(sortArrow));
                sortArrow = null;
                placeSortArrow();
            }
            return;
        }// end function

        protected function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:DataGridEvent = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Sprite = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:Point = null;
            _loc_4 = Sprite(getChildByName("sortArrowHitArea"));
            if (event.target == _loc_4)
            {
                _loc_5 = visibleColumns.length;
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    if (visibleColumns[_loc_6].colNum == dataGrid.sortIndex)
                    {
                        _loc_3 = headerItems[_loc_6];
                        break;
                    }
                    _loc_6++;
                }
            }
            else
            {
                _loc_6 = 0;
                while (_loc_6 < separators.length)
                {
                    
                    if (event.target == separators[_loc_6] && visibleColumns[_loc_6].resizable)
                    {
                        return;
                    }
                    _loc_6++;
                }
                _loc_7 = new Point(event.stageX, event.stageY);
                _loc_7 = globalToLocal(_loc_7);
                _loc_6 = 0;
                while (_loc_6 < headerItems.length)
                {
                    
                    if (headerItems[_loc_6].x + headerItems[_loc_6].width >= _loc_7.x)
                    {
                        _loc_3 = headerItems[_loc_6];
                        break;
                    }
                    _loc_6++;
                }
                if (_loc_6 >= headerItems.length)
                {
                    return;
                }
            }
            if (dataGrid.enabled && (dataGrid.sortableColumns || dataGrid.draggableColumns) && dataGrid.dataProvider && dataGrid.headerVisible)
            {
                if (_loc_3 == lastItemDown)
                {
                    if (dataGrid.sortableColumns && visibleColumns[_loc_6].sortable)
                    {
                        lastItemDown = null;
                        _loc_2 = new DataGridEvent(DataGridEvent.HEADER_RELEASE, false, true);
                        _loc_2.columnIndex = visibleColumns[_loc_6].colNum;
                        _loc_2.dataField = visibleColumns[_loc_6].dataField;
                        _loc_2.itemRenderer = _loc_3;
                        dataGrid.dispatchEvent(_loc_2);
                    }
                }
            }
            return;
        }// end function

        protected function drawSeparators() : void
        {
            var _loc_4:UIComponent = null;
            var _loc_5:IFlexDisplayObject = null;
            var _loc_6:Array = null;
            var _loc_7:Class = null;
            if (!separators)
            {
                separators = [];
            }
            var _loc_1:* = UIComponent(getChildByName("lines"));
            if (!_loc_1)
            {
                _loc_1 = new UIComponent();
                _loc_1.name = "lines";
                addChild(_loc_1);
            }
            else
            {
                setChildIndex(_loc_1, (numChildren - 1));
            }
            _loc_1.scrollRect = new Rectangle(0, 0, unscaledWidth, (unscaledHeight + 1));
            if (headerSepSkinChanged)
            {
                headerSepSkinChanged = false;
                clearSeparators();
            }
            var _loc_2:* = visibleColumns ? (visibleColumns.length) : (0);
            if (!needRightSeparator && _loc_2 > 0)
            {
                _loc_2 = _loc_2 - 1;
            }
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (_loc_3 < _loc_1.numChildren)
                {
                    _loc_4 = UIComponent(_loc_1.getChildAt(_loc_3));
                    _loc_5 = IFlexDisplayObject(_loc_4.getChildAt(0));
                }
                else
                {
                    _loc_7 = getStyle("headerSeparatorSkin");
                    _loc_5 = new _loc_7;
                    if (_loc_5 is ISimpleStyleClient)
                    {
                        ISimpleStyleClient(_loc_5).styleName = this;
                    }
                    _loc_4 = new UIComponent();
                    _loc_4.addChild(DisplayObject(_loc_5));
                    _loc_1.addChild(_loc_4);
                    UIComponentGlobals.layoutManager.validateClient(_loc_4, true);
                    separators.push(_loc_4);
                }
                if (!(_loc_3 == (visibleColumns.length - 1) && !needRightSeparatorEvents))
                {
                    DisplayObject(_loc_4).addEventListener(MouseEvent.MOUSE_OVER, columnResizeMouseOverHandler);
                    DisplayObject(_loc_4).addEventListener(MouseEvent.MOUSE_OUT, columnResizeMouseOutHandler);
                    DisplayObject(_loc_4).addEventListener(MouseEvent.MOUSE_DOWN, columnResizeMouseDownHandler);
                }
                else if (_loc_3 == (visibleColumns.length - 1) && !needRightSeparatorEvents)
                {
                    DisplayObject(_loc_4).removeEventListener(MouseEvent.MOUSE_OVER, columnResizeMouseOverHandler);
                    DisplayObject(_loc_4).removeEventListener(MouseEvent.MOUSE_OUT, columnResizeMouseOutHandler);
                    DisplayObject(_loc_4).removeEventListener(MouseEvent.MOUSE_DOWN, columnResizeMouseDownHandler);
                }
                _loc_6 = visibleColumns;
                if (!(_loc_6 && _loc_6.length > 0 || dataGrid.headerVisible))
                {
                    _loc_4.visible = false;
                }
                else
                {
                    _loc_4.visible = true;
                    _loc_4.x = headerItems[_loc_3].x + visibleColumns[_loc_3].width - Math.round(_loc_5.measuredWidth / 2);
                    if (_loc_3 > 0)
                    {
                        _loc_4.x = Math.max(_loc_4.x, separators[(_loc_3 - 1)].x + Math.round(_loc_5.measuredWidth / 2));
                    }
                    _loc_4.y = 0;
                    _loc_5.setActualSize(_loc_5.measuredWidth, Math.ceil(cachedHeaderHeight));
                    _loc_4.graphics.clear();
                    _loc_4.graphics.beginFill(16777215, 0);
                    _loc_4.graphics.drawRect(-separatorAffordance, 0, _loc_5.measuredWidth + separatorAffordance, cachedHeaderHeight);
                    _loc_4.graphics.endFill();
                    _loc_4.mouseEnabled = true;
                }
                _loc_3++;
            }
            while (_loc_1.numChildren > _loc_2)
            {
                
                _loc_1.removeChildAt((_loc_1.numChildren - 1));
                separators.pop();
            }
            UIComponentGlobals.layoutManager.validateClient(_loc_1, true);
            return;
        }// end function

        private function columnResizeMouseOutHandler(event:MouseEvent) : void
        {
            if (!enabled || !dataGrid.resizableColumns)
            {
                return;
            }
            var _loc_2:* = DisplayObject(event.target);
            var _loc_3:* = _loc_2.parent.getChildIndex(_loc_2);
            if (!visibleColumns[_loc_3].resizable)
            {
                return;
            }
            cursorManager.removeCursor(resizeCursorID);
            return;
        }// end function

        override protected function createChildren() : void
        {
            dataGrid = parent as DataGrid;
            selectionLayer = new UIComponent();
            addChild(selectionLayer);
            return;
        }// end function

        function _clearSeparators() : void
        {
            clearSeparators();
            return;
        }// end function

        protected function drawHeaderIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = param1.graphics;
            param1.graphics.clear();
            _loc_8.beginFill(param6);
            _loc_8.drawRect(0, 0, param4, param5);
            _loc_8.endFill();
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        protected function mouseOutHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:Point = null;
            var _loc_6:Sprite = null;
            if (resizeGraphic || dataGrid.movingColumn)
            {
                return;
            }
            if (dataGrid.enabled && dataGrid.sortableColumns && dataGrid.headerVisible)
            {
                _loc_6 = Sprite(getChildByName("sortArrowHitArea"));
                if (event.target == _loc_6)
                {
                    _loc_4 = visibleColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_4)
                    {
                        
                        if (visibleColumns[_loc_3].colNum == dataGrid.sortIndex)
                        {
                            _loc_2 = headerItems[_loc_3];
                            break;
                        }
                        _loc_3++;
                    }
                    if (_loc_3 >= visibleColumns.length)
                    {
                        return;
                    }
                }
                else
                {
                    _loc_3 = 0;
                    while (_loc_3 < separators.length)
                    {
                        
                        if (event.target == separators[_loc_3] && visibleColumns[_loc_3].resizable)
                        {
                            return;
                        }
                        _loc_3++;
                    }
                    _loc_5 = new Point(event.stageX, event.stageY);
                    _loc_5 = globalToLocal(_loc_5);
                    _loc_3 = 0;
                    while (_loc_3 < headerItems.length)
                    {
                        
                        if (headerItems[_loc_3].x + headerItems[_loc_3].width >= _loc_5.x)
                        {
                            _loc_2 = headerItems[_loc_3];
                            break;
                        }
                        _loc_3++;
                    }
                    if (_loc_3 >= headerItems.length)
                    {
                        _loc_3 = headerItems.length - 1;
                    }
                }
                if (visibleColumns.length > 0 && visibleColumns[_loc_3].sortable)
                {
                    _loc_6 = Sprite(selectionLayer.getChildByName("headerSelection"));
                    if (_loc_6)
                    {
                        selectionLayer.removeChild(_loc_6);
                    }
                }
            }
            if (event.buttonDown)
            {
                lastItemDown = _loc_2;
            }
            else
            {
                lastItemDown = null;
            }
            return;
        }// end function

        private function drawHeaderBackgroundSkin(param1:IFlexDisplayObject) : void
        {
            param1.setActualSize(unscaledWidth, Math.ceil(cachedHeaderHeight));
            return;
        }// end function

        function getSeparators() : Array
        {
            return separators;
        }// end function

        private function get resizingColumn() : DataGridColumn
        {
            return dataGrid.resizingColumn;
        }// end function

        private function columnResizeMouseDownHandler(event:MouseEvent) : void
        {
            if (!enabled || !dataGrid.resizableColumns)
            {
                return;
            }
            var _loc_2:* = DisplayObject(event.target);
            var _loc_3:* = _loc_2.parent.getChildIndex(_loc_2);
            if (!visibleColumns[_loc_3].resizable)
            {
                return;
            }
            startX = DisplayObject(event.target).x + x;
            lastPt = new Point(event.stageX, event.stageY);
            lastPt = dataGrid.globalToLocal(lastPt);
            var _loc_4:* = separators.length;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_4)
            {
                
                if (separators[_loc_6] == event.target)
                {
                    resizingColumn = visibleColumns[_loc_6];
                    _loc_5 = _loc_6;
                }
                else
                {
                    separators[_loc_6].mouseEnabled = false;
                }
                _loc_6++;
            }
            if (!resizingColumn)
            {
                return;
            }
            minX = headerItems[_loc_5].x + x + resizingColumn.minWidth;
            var _loc_7:* = systemManager.getSandboxRoot();
            systemManager.getSandboxRoot().addEventListener(MouseEvent.MOUSE_MOVE, columnResizingHandler, true);
            _loc_7.addEventListener(MouseEvent.MOUSE_UP, columnResizeMouseUpHandler, true);
            _loc_7.addEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, columnResizeMouseUpHandler);
            systemManager.deployMouseShields(true);
            var _loc_8:* = getStyle("columnResizeSkin");
            resizeGraphic = new _loc_8;
            if (resizeGraphic is Sprite)
            {
                Sprite(resizeGraphic).mouseEnabled = false;
            }
            dataGrid.addChild(DisplayObject(resizeGraphic));
            resizeGraphic.move(DisplayObject(event.target).x + x, 0);
            resizeGraphic.setActualSize(resizeGraphic.measuredWidth, dataGrid.height / dataGrid.scaleY);
            return;
        }// end function

        private function columnDraggingMouseUpHandler(event:Event) : void
        {
            if (!dataGrid.movingColumn)
            {
                return;
            }
            var _loc_2:* = dataGrid.movingColumn.colNum;
            var _loc_3:* = dataGrid.getAllVisibleColumns();
            if (dropColumnIndex >= 0)
            {
                if (dropColumnIndex >= _loc_3.length)
                {
                    dropColumnIndex = _loc_3.length - 1;
                }
                else if (_loc_2 < _loc_3[dropColumnIndex].colNum)
                {
                    var _loc_9:* = dropColumnIndex - 1;
                    dropColumnIndex = _loc_9;
                }
                dropColumnIndex = _loc_3[dropColumnIndex].colNum;
            }
            dataGrid.shiftColumns(_loc_2, dropColumnIndex, event as MouseEvent);
            var _loc_4:* = systemManager.getSandboxRoot();
            systemManager.getSandboxRoot().removeEventListener(MouseEvent.MOUSE_MOVE, columnDraggingMouseMoveHandler, true);
            _loc_4.removeEventListener(MouseEvent.MOUSE_UP, columnDraggingMouseUpHandler, true);
            _loc_4.removeEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, columnDraggingMouseUpHandler);
            systemManager.deployMouseShields(false);
            var _loc_5:* = Sprite(dataGrid.getChildByName("columnDragSelectionLayer"));
            if (!Sprite(dataGrid.getChildByName("columnDragSelectionLayer")))
            {
                startX = NaN;
                dataGrid.movingColumn = null;
                dropColumnIndex = -1;
                return;
            }
            var _loc_6:* = IListItemRenderer(getChildByName("headerDragProxy"));
            if (IListItemRenderer(getChildByName("headerDragProxy")))
            {
                _loc_5.removeChild(DisplayObject(_loc_6));
            }
            var _loc_7:* = Sprite(_loc_5.getChildByName("headerSelection"));
            if (Sprite(_loc_5.getChildByName("headerSelection")))
            {
                _loc_5.removeChild(_loc_7);
            }
            if (columnDropIndicator)
            {
                columnDropIndicator.visible = false;
            }
            _loc_7 = Sprite(dataGrid.getChildByName("columnDragOverlay"));
            if (_loc_7)
            {
                dataGrid.removeChild(_loc_7);
            }
            dataGrid.removeChild(_loc_5);
            startX = NaN;
            dataGrid.movingColumn = null;
            dropColumnIndex = -1;
            invalidateDisplayList();
            return;
        }// end function

        function _drawSeparators() : void
        {
            drawSeparators();
            return;
        }// end function

        private function columnDraggingMouseMoveHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_4:Sprite = null;
            var _loc_7:Sprite = null;
            var _loc_12:Number = NaN;
            var _loc_13:EdgeMetrics = null;
            var _loc_14:IListItemRenderer = null;
            var _loc_15:DataGridListData = null;
            var _loc_16:Class = null;
            var _loc_17:Shape = null;
            if (!event.buttonDown)
            {
                columnDraggingMouseUpHandler(event);
                return;
            }
            var _loc_3:* = dataGrid.movingColumn;
            var _loc_5:int = 0;
            var _loc_6:* = headerItems.length;
            if (isNaN(startX))
            {
                startX = event.stageX;
                lastItemDown = null;
                _loc_13 = dataGrid.viewMetrics;
                _loc_7 = new UIComponent();
                _loc_7.name = "columnDragSelectionLayer";
                _loc_7.alpha = 0.6;
                dataGrid.addChild(_loc_7);
                _loc_7.x = _loc_13.left;
                _loc_7.y = _loc_13.top;
                _loc_14 = dataGrid.createColumnItemRenderer(_loc_3, true, _loc_3);
                _loc_14.name = "headerDragProxy";
                _loc_15 = new DataGridListData(_loc_3.headerText != null ? (_loc_3.headerText) : (_loc_3.dataField), _loc_3.dataField, _loc_3.colNum, uid, dataGrid, 0);
                if (_loc_14 is IDropInListItemRenderer)
                {
                    IDropInListItemRenderer(_loc_14).listData = _loc_15;
                }
                _loc_7.addChild(DisplayObject(_loc_14));
                _loc_14.data = _loc_3;
                _loc_14.styleName = getStyle("headerDragProxyStyleName");
                UIComponentGlobals.layoutManager.validateClient(_loc_14, true);
                _loc_14.setActualSize(_loc_3.width, dataGrid._explicitHeaderHeight ? (dataGrid.headerHeight) : (_loc_14.getExplicitOrMeasuredHeight()));
                _loc_5 = 0;
                while (_loc_5 < _loc_6)
                {
                    
                    _loc_2 = headerItems[_loc_5];
                    if (_loc_2.data == dataGrid.movingColumn)
                    {
                        break;
                    }
                    _loc_5++;
                }
                _loc_14.move(_loc_2.x + x, _loc_2.y);
                _loc_4 = new FlexSprite();
                _loc_4.name = "columnDragOverlay";
                _loc_4.alpha = 0.6;
                dataGrid.addChild(_loc_4);
                if (_loc_3.width > 0)
                {
                    drawColumnDragOverlay(_loc_4, _loc_2.x + x, 0, _loc_3.width, dataGrid.height / dataGrid.scaleY - _loc_13.bottom - _loc_4.y, getStyle("disabledColor"), _loc_2);
                }
                _loc_4 = Sprite(selectionLayer.getChildByName("headerSelection"));
                if (_loc_4)
                {
                    _loc_4.width = dataGrid.movingColumn.width;
                    _loc_7.addChild(_loc_4);
                    _loc_4.x = _loc_4.x + x;
                }
                _loc_7.scrollRect = new Rectangle(0, 0, dataGrid.width / dataGrid.scaleX, unscaledHeight);
                return;
            }
            var _loc_8:* = event.stageX - startX;
            _loc_7 = Sprite(dataGrid.getChildByName("columnDragSelectionLayer"));
            _loc_4 = Sprite(_loc_7.getChildByName("headerSelection"));
            if (_loc_4)
            {
                _loc_4.x = _loc_4.x + _loc_8;
            }
            _loc_2 = IListItemRenderer(_loc_7.getChildByName("headerDragProxy"));
            if (_loc_2)
            {
                _loc_2.move(_loc_2.x + _loc_8, _loc_2.y);
            }
            startX = startX + _loc_8;
            var _loc_9:* = dataGrid.getAllVisibleColumns();
            var _loc_10:* = new Point(event.stageX, event.stageY);
            _loc_10 = dataGrid.globalToLocal(_loc_10);
            lastPt = _loc_10;
            _loc_6 = _loc_9.length;
            var _loc_11:* = dataGrid.viewMetrics.left;
            _loc_5 = 0;
            while (_loc_5 < _loc_6)
            {
                
                _loc_12 = _loc_9[_loc_5].width;
                if (_loc_10.x < _loc_11 + _loc_12)
                {
                    if (_loc_10.x > _loc_11 + _loc_12 / 2)
                    {
                        _loc_5++;
                        _loc_11 = _loc_11 + _loc_12;
                    }
                    if (dropColumnIndex != _loc_5)
                    {
                        dropColumnIndex = _loc_5;
                        if (!columnDropIndicator)
                        {
                            _loc_16 = getStyle("columnDropIndicatorSkin");
                            if (!_loc_16)
                            {
                                _loc_16 = DataGridColumnDropIndicator;
                            }
                            columnDropIndicator = IFlexDisplayObject(new _loc_16);
                            if (columnDropIndicator is ISimpleStyleClient)
                            {
                                ISimpleStyleClient(columnDropIndicator).styleName = this;
                            }
                            dataGrid.addChild(DisplayObject(columnDropIndicator));
                            _loc_17 = new Shape();
                            _loc_17.graphics.beginFill(16777215);
                            _loc_17.graphics.drawRect(0, 0, 10, 10);
                            _loc_17.graphics.endFill();
                            dataGrid.addChild(_loc_17);
                            columnDropIndicator.mask = _loc_17;
                        }
                        dataGrid.setChildIndex(DisplayObject(columnDropIndicator), (dataGrid.numChildren - 1));
                        columnDropIndicator.visible = true;
                        _loc_17 = columnDropIndicator.mask as Shape;
                        _loc_17.x = dataGrid.viewMetrics.left;
                        _loc_17.y = dataGrid.viewMetrics.top;
                        _loc_17.width = dataGrid.width / dataGrid.scaleX - _loc_17.x - dataGrid.viewMetrics.right;
                        _loc_17.height = dataGrid.height / dataGrid.scaleY - _loc_17.x - dataGrid.viewMetrics.bottom;
                        columnDropIndicator.x = _loc_11 - columnDropIndicator.width;
                        columnDropIndicator.y = 0;
                        columnDropIndicator.setActualSize(3, dataGrid.height / dataGrid.scaleY);
                    }
                    break;
                }
                _loc_11 = _loc_11 + _loc_12;
                _loc_5++;
            }
            return;
        }// end function

        private function columnResizeMouseOverHandler(event:MouseEvent) : void
        {
            if (!enabled || !dataGrid.resizableColumns)
            {
                return;
            }
            var _loc_2:* = DisplayObject(event.target);
            var _loc_3:* = _loc_2.parent.getChildIndex(_loc_2);
            if (!visibleColumns[_loc_3].resizable)
            {
                return;
            }
            var _loc_4:* = getStyle("stretchCursor");
            resizeCursorID = cursorManager.setCursor(_loc_4, CursorManagerPriority.HIGH, 0, 0);
            return;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            super.styleChanged(param1);
            if (param1 == "headerBackgroundSkin")
            {
                headerBGSkinChanged = true;
            }
            else if (param1 == "headerSeparatorSkin")
            {
                headerSepSkinChanged = true;
            }
            return;
        }// end function

        protected function placeSortArrow() : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_8:Class = null;
            var _loc_9:Graphics = null;
            var _loc_10:int = 0;
            var _loc_1:* = Sprite(getChildByName("sortArrowHitArea"));
            if (dataGrid.sortIndex == -1 && dataGrid.lastSortIndex == -1)
            {
                if (sortArrow)
                {
                    sortArrow.visible = false;
                }
                if (_loc_1)
                {
                    _loc_1.visible = false;
                }
                return;
            }
            if (!dataGrid.headerVisible)
            {
                if (sortArrow)
                {
                    sortArrow.visible = false;
                }
                if (_loc_1)
                {
                    _loc_1.visible = false;
                }
                return;
            }
            if (!sortArrow)
            {
                _loc_8 = getStyle("sortArrowSkin");
                sortArrow = new _loc_8;
                DisplayObject(sortArrow).name = enabled ? ("sortArrow") : ("sortArrowDisabled");
                if (sortArrow is ISimpleStyleClient)
                {
                    ISimpleStyleClient(sortArrow).styleName = this;
                }
                addChild(DisplayObject(sortArrow));
            }
            var _loc_5:Boolean = false;
            if (headerItems && headerItems.length)
            {
                _loc_3 = headerItems.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    if (visibleColumns[_loc_4].colNum == dataGrid.sortIndex)
                    {
                        _loc_2 = headerItems[_loc_4].x + visibleColumns[_loc_4].width;
                        headerItems[_loc_4].setActualSize(visibleColumns[_loc_4].width - sortArrow.measuredWidth - 8, headerItems[_loc_4].height);
                        if (!isNaN(headerItems[_loc_4].explicitWidth))
                        {
                            headerItems[_loc_4].explicitWidth = headerItems[_loc_4].width;
                        }
                        UIComponentGlobals.layoutManager.validateClient(headerItems[_loc_4], true);
                        if (!_loc_1)
                        {
                            _loc_1 = new FlexSprite();
                            _loc_1.name = "sortArrowHitArea";
                            addChild(_loc_1);
                        }
                        else
                        {
                            _loc_1.visible = true;
                        }
                        _loc_1.x = headerItems[_loc_4].x + headerItems[_loc_4].width;
                        _loc_1.y = headerItems[_loc_4].y;
                        _loc_9 = _loc_1.graphics;
                        _loc_9.clear();
                        _loc_9.beginFill(0, 0);
                        _loc_9.drawRect(0, 0, sortArrow.measuredWidth + 8, headerItems[_loc_4].height);
                        _loc_9.endFill();
                        _loc_5 = true;
                        break;
                    }
                    _loc_4++;
                }
            }
            if (isNaN(_loc_2))
            {
                sortArrow.visible = false;
            }
            else
            {
                sortArrow.visible = true;
            }
            if (visibleColumns.length && dataGrid.lastSortIndex >= 0 && dataGrid.lastSortIndex != dataGrid.sortIndex)
            {
                if (visibleColumns[0].colNum <= dataGrid.lastSortIndex && dataGrid.lastSortIndex <= visibleColumns[(visibleColumns.length - 1)].colNum)
                {
                    _loc_3 = headerItems.length;
                    _loc_10 = 0;
                    while (_loc_10 < _loc_3)
                    {
                        
                        if (visibleColumns[_loc_10].colNum == dataGrid.lastSortIndex)
                        {
                            headerItems[_loc_10].setActualSize(visibleColumns[_loc_10].width, headerItems[_loc_10].height);
                            UIComponentGlobals.layoutManager.validateClient(headerItems[_loc_10], true);
                            break;
                        }
                        _loc_10++;
                    }
                }
            }
            var _loc_6:* = dataGrid.sortDirection == "ASC";
            sortArrow.width = sortArrow.measuredWidth;
            sortArrow.height = sortArrow.measuredHeight;
            DisplayObject(sortArrow).scaleY = _loc_6 ? (-1) : (1);
            sortArrow.x = _loc_2 - sortArrow.measuredWidth - 8;
            var _loc_7:* = cachedHeaderHeight;
            sortArrow.y = (_loc_7 - sortArrow.measuredHeight) / 2 + (_loc_6 ? (sortArrow.measuredHeight) : (0));
            if (_loc_5 && sortArrow.x < headerItems[_loc_4].x)
            {
                sortArrow.visible = false;
            }
            if (!sortArrow.visible && _loc_1)
            {
                _loc_1.visible = false;
            }
            return;
        }// end function

        protected function drawSelectionIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = param1.graphics;
            param1.graphics.clear();
            _loc_8.beginFill(param6);
            _loc_8.drawRect(0, 0, param4, param5);
            _loc_8.endFill();
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        private function set resizingColumn(param1:DataGridColumn) : void
        {
            dataGrid.resizingColumn = param1;
            return;
        }// end function

        override function clearSelectionLayer() : void
        {
            while (selectionLayer.numChildren > 0)
            {
                
                selectionLayer.removeChildAt(0);
            }
            return;
        }// end function

        private function columnResizeMouseUpHandler(event:Event) : void
        {
            var _loc_6:Point = null;
            if (!enabled || !dataGrid.resizableColumns)
            {
                return;
            }
            lastItemDown = null;
            var _loc_2:* = systemManager.getSandboxRoot();
            _loc_2.removeEventListener(MouseEvent.MOUSE_MOVE, columnResizingHandler, true);
            _loc_2.removeEventListener(MouseEvent.MOUSE_UP, columnResizeMouseUpHandler, true);
            _loc_2.removeEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, columnResizeMouseUpHandler);
            systemManager.deployMouseShields(false);
            dataGrid.removeChild(DisplayObject(resizeGraphic));
            resizeGraphic = null;
            cursorManager.removeCursor(resizeCursorID);
            var _loc_3:* = resizingColumn;
            resizingColumn = null;
            var _loc_4:* = dataGrid.vScrollBar ? (dataGrid.vScrollBar.width) : (0);
            var _loc_5:* = event as MouseEvent;
            if (event as MouseEvent)
            {
                _loc_6 = new Point(_loc_5.stageX, _loc_5.stageY);
                _loc_6 = dataGrid.globalToLocal(_loc_6);
            }
            else
            {
                _loc_6 = lastPt;
            }
            var _loc_7:* = Math.min(Math.max(minX, _loc_6.x), dataGrid.width / dataGrid.scaleX - separators[0].width - _loc_4) - startX;
            dataGrid.resizeColumn(_loc_3.colNum, Math.floor(_loc_3.width + _loc_7));
            invalidateDisplayList();
            var _loc_8:* = new DataGridEvent(DataGridEvent.COLUMN_STRETCH);
            new DataGridEvent(DataGridEvent.COLUMN_STRETCH).columnIndex = _loc_3.colNum;
            _loc_8.dataField = _loc_3.dataField;
            _loc_8.localX = _loc_6.x;
            dataGrid.dispatchEvent(_loc_8);
            return;
        }// end function

        protected function clearSeparators() : void
        {
            if (!separators)
            {
                return;
            }
            var _loc_1:* = Sprite(getChildByName("lines"));
            while (_loc_1.numChildren)
            {
                
                _loc_1.removeChildAt((_loc_1.numChildren - 1));
                separators.pop();
            }
            return;
        }// end function

        function get rendererArray() : Array
        {
            return headerItems;
        }// end function

        override protected function measure() : void
        {
            super.measure();
            var _loc_1:* = dataGrid.calculateHeaderHeight();
            cachedHeaderHeight = dataGrid._explicitHeaderHeight ? (dataGrid.headerHeight) : (_loc_1);
            cachedPaddingBottom = getStyle("paddingBottom");
            cachedPaddingTop = getStyle("paddingTop");
            measuredHeight = cachedHeaderHeight;
            return;
        }// end function

        protected function drawColumnDragOverlay(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = param1.graphics;
            param1.graphics.clear();
            _loc_8.beginFill(param6);
            _loc_8.drawRect(0, 0, param4, param5);
            _loc_8.endFill();
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        function _placeSortArrow() : void
        {
            placeSortArrow();
            return;
        }// end function

        function _drawHeaderBackground(param1:UIComponent) : void
        {
            drawHeaderBackground(param1);
            return;
        }// end function

        private function columnResizingHandler(event:MouseEvent) : void
        {
            if (!MouseEvent(event).buttonDown)
            {
                columnResizeMouseUpHandler(event);
                return;
            }
            var _loc_2:* = dataGrid.vScrollBar ? (dataGrid.vScrollBar.width) : (0);
            var _loc_3:* = new Point(event.stageX, event.stageY);
            _loc_3 = dataGrid.globalToLocal(_loc_3);
            lastPt = _loc_3;
            resizeGraphic.move(Math.min(Math.max(minX, _loc_3.x), dataGrid.width / dataGrid.scaleX - separators[0].width - _loc_2), 0);
            return;
        }// end function

        override public function invalidateSize() : void
        {
            if (allowItemSizeChangeNotification)
            {
                super.invalidateSize();
            }
            return;
        }// end function

        protected function mouseOverHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:Point = null;
            var _loc_6:Sprite = null;
            if (resizingColumn || dataGrid.movingColumn)
            {
                return;
            }
            if (dataGrid.enabled && dataGrid.sortableColumns && dataGrid.headerVisible)
            {
                _loc_6 = Sprite(getChildByName("sortArrowHitArea"));
                if (event.target == _loc_6)
                {
                    _loc_4 = visibleColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_4)
                    {
                        
                        if (visibleColumns[_loc_3].colNum == dataGrid.sortIndex)
                        {
                            _loc_2 = headerItems[_loc_3];
                            break;
                        }
                        _loc_3++;
                    }
                }
                else
                {
                    _loc_3 = 0;
                    while (_loc_3 < separators.length)
                    {
                        
                        if (event.target == separators[_loc_3] && visibleColumns[_loc_3].resizable)
                        {
                            return;
                        }
                        _loc_3++;
                    }
                    _loc_5 = new Point(event.stageX, event.stageY);
                    _loc_5 = globalToLocal(_loc_5);
                    _loc_3 = 0;
                    while (_loc_3 < headerItems.length)
                    {
                        
                        if (headerItems[_loc_3].x + headerItems[_loc_3].width >= _loc_5.x)
                        {
                            _loc_2 = headerItems[_loc_3];
                            break;
                        }
                        _loc_3++;
                    }
                    if (_loc_3 >= headerItems.length)
                    {
                        return;
                    }
                }
                _loc_6 = Sprite(getChildByName("sortArrowHitArea"));
                if (visibleColumns[_loc_3].sortable)
                {
                    _loc_6 = Sprite(selectionLayer.getChildByName("headerSelection"));
                    if (!_loc_6)
                    {
                        _loc_6 = new FlexSprite();
                        _loc_6.name = "headerSelection";
                        _loc_6.mouseEnabled = false;
                        selectionLayer.addChild(_loc_6);
                    }
                    drawHeaderIndicator(_loc_6, _loc_2.x, 0, visibleColumns[_loc_3].width, cachedHeaderHeight - 0.5, getStyle("rollOverColor"), _loc_2);
                }
            }
            if (event.buttonDown)
            {
                lastItemDown = _loc_2;
            }
            else
            {
                lastItemDown = null;
            }
            return;
        }// end function

        protected function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Sprite = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Point = null;
            var _loc_7:DisplayObject = null;
            _loc_3 = Sprite(getChildByName("sortArrowHitArea"));
            if (event.target == _loc_3)
            {
                _loc_5 = visibleColumns.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_5)
                {
                    
                    if (visibleColumns[_loc_4].colNum == dataGrid.sortIndex)
                    {
                        _loc_2 = headerItems[_loc_4];
                        break;
                    }
                    _loc_4++;
                }
            }
            else
            {
                _loc_4 = 0;
                while (_loc_4 < separators.length)
                {
                    
                    if (event.target == separators[_loc_4] && visibleColumns[_loc_4].resizable)
                    {
                        return;
                    }
                    _loc_4++;
                }
                _loc_6 = new Point(event.stageX, event.stageY);
                _loc_6 = globalToLocal(_loc_6);
                _loc_4 = 0;
                while (_loc_4 < headerItems.length)
                {
                    
                    if (headerItems[_loc_4].x + headerItems[_loc_4].width >= _loc_6.x)
                    {
                        _loc_2 = headerItems[_loc_4];
                        break;
                    }
                    _loc_4++;
                }
                if (_loc_4 >= headerItems.length)
                {
                    return;
                }
            }
            if (dataGrid.enabled && (dataGrid.sortableColumns || dataGrid.draggableColumns) && dataGrid.headerVisible)
            {
                if (dataGrid.sortableColumns && visibleColumns[_loc_4].sortable)
                {
                    lastItemDown = _loc_2;
                    _loc_3 = Sprite(selectionLayer.getChildByName("headerSelection"));
                    if (!_loc_3)
                    {
                        _loc_3 = new FlexSprite();
                        _loc_3.name = "headerSelection";
                        selectionLayer.addChild(_loc_3);
                    }
                    drawSelectionIndicator(_loc_3, _loc_2.x, 0, visibleColumns[_loc_4].width, cachedHeaderHeight - 0.5, getStyle("selectionColor"), _loc_2);
                }
                if (dataGrid.draggableColumns && visibleColumns[_loc_4].draggable)
                {
                    startX = NaN;
                    _loc_7 = systemManager.getSandboxRoot();
                    _loc_7.addEventListener(MouseEvent.MOUSE_MOVE, columnDraggingMouseMoveHandler, true);
                    _loc_7.addEventListener(MouseEvent.MOUSE_UP, columnDraggingMouseUpHandler, true);
                    _loc_7.addEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, columnDraggingMouseUpHandler);
                    systemManager.deployMouseShields(true);
                    dataGrid.movingColumn = visibleColumns[_loc_4];
                }
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_5:Number = NaN;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:Number = NaN;
            var _loc_10:int = 0;
            var _loc_11:DataGridListData = null;
            var _loc_12:IListItemRenderer = null;
            var _loc_13:IListItemRenderer = null;
            var _loc_14:Object = null;
            var _loc_15:String = null;
            var _loc_16:DataGridColumn = null;
            var _loc_17:Number = NaN;
            var _loc_18:Array = null;
            var _loc_19:int = 0;
            var _loc_20:Class = null;
            var _loc_21:IFlexDisplayObject = null;
            allowItemSizeChangeNotification = false;
            var _loc_3:* = visibleColumns;
            if (headerItemsChanged && (_loc_3 && _loc_3.length > 0 || dataGrid.headerVisible))
            {
                headerItemsChanged = false;
                _loc_5 = 0;
                _loc_6 = 0;
                _loc_7 = 0;
                _loc_8 = 0;
                _loc_10 = 0;
                _loc_17 = 0;
                _loc_18 = headerItems.slice();
                while (_loc_3 && _loc_10 < _loc_3.length)
                {
                    
                    _loc_16 = _loc_3[_loc_10];
                    _loc_12 = _loc_16.cachedHeaderRenderer;
                    if (!_loc_12)
                    {
                        _loc_12 = dataGrid.createColumnItemRenderer(_loc_16, true, _loc_16);
                        _loc_12.styleName = _loc_16;
                        _loc_16.cachedHeaderRenderer = _loc_12;
                    }
                    _loc_11 = new DataGridListData(_loc_16.headerText != null ? (_loc_16.headerText) : (_loc_16.dataField), _loc_16.dataField, _loc_10, _loc_15, dataGrid, 0);
                    if (_loc_12 is IDropInListItemRenderer)
                    {
                        IDropInListItemRenderer(_loc_12).listData = _loc_11;
                    }
                    _loc_12.data = _loc_16;
                    _loc_12.visible = true;
                    if (_loc_12.parent != this)
                    {
                        addChild(DisplayObject(_loc_12));
                    }
                    headerItems[_loc_10] = _loc_12;
                    var _loc_22:* = _loc_16.width;
                    _loc_8 = _loc_16.width;
                    _loc_12.explicitWidth = _loc_22;
                    UIComponentGlobals.layoutManager.validateClient(_loc_12, true);
                    _loc_9 = _loc_12.getExplicitOrMeasuredHeight();
                    _loc_12.setActualSize(_loc_8, dataGrid._explicitHeaderHeight ? (cachedHeaderHeight - cachedPaddingTop - cachedPaddingBottom) : (_loc_9));
                    _loc_12.move(_loc_5, _loc_6 + cachedPaddingTop);
                    _loc_5 = _loc_5 + _loc_8;
                    _loc_10++;
                    _loc_7 = Math.ceil(Math.max(_loc_7, dataGrid._explicitHeaderHeight ? (cachedHeaderHeight) : (_loc_9 + cachedPaddingBottom + cachedPaddingTop)));
                    _loc_17 = Math.max(_loc_17, dataGrid._explicitHeaderHeight ? (cachedHeaderHeight - cachedPaddingTop - cachedPaddingBottom) : (_loc_9));
                }
                _loc_19 = 0;
                while (_loc_19 < headerItems.length)
                {
                    
                    headerItems[_loc_19].setActualSize(headerItems[_loc_19].width, _loc_17);
                    _loc_19++;
                }
                _loc_19 = 0;
                while (_loc_19 < _loc_18.length)
                {
                    
                    _loc_12 = _loc_18[_loc_19];
                    if (_loc_12 && headerItems.indexOf(_loc_12) == -1)
                    {
                        if (_loc_12.parent == this)
                        {
                            removeChild(DisplayObject(_loc_12));
                        }
                    }
                    _loc_19++;
                }
                while (headerItems.length > _loc_10)
                {
                    
                    _loc_13 = headerItems.pop();
                    if (_loc_13.parent == this)
                    {
                        if (headerItems.indexOf(_loc_13) == -1)
                        {
                            removeChild(DisplayObject(_loc_13));
                        }
                    }
                }
            }
            var _loc_4:* = UIComponent(getChildByName("headerBG"));
            if (headerBGSkinChanged)
            {
                headerBGSkinChanged = false;
                if (_loc_4)
                {
                    removeChild(_loc_4);
                }
                _loc_4 = null;
            }
            if (!_loc_4)
            {
                _loc_4 = new UIComponent();
                _loc_4.name = "headerBG";
                addChildAt(DisplayObject(_loc_4), 0);
                if (FlexVersion.compatibilityVersion >= FlexVersion.VERSION_3_0)
                {
                    _loc_20 = getStyle("headerBackgroundSkin");
                    _loc_21 = new _loc_20;
                    if (_loc_21 is ISimpleStyleClient)
                    {
                        ISimpleStyleClient(_loc_21).styleName = this;
                    }
                    _loc_4.addChild(DisplayObject(_loc_21));
                }
            }
            if (dataGrid.headerVisible)
            {
                _loc_4.visible = true;
                if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
                {
                    dataGrid._drawHeaderBackground(_loc_4);
                }
                else
                {
                    drawHeaderBackgroundSkin(IFlexDisplayObject(_loc_4.getChildAt(0)));
                }
                dataGrid._drawSeparators();
            }
            else
            {
                _loc_4.visible = false;
                dataGrid._clearSeparators();
            }
            dataGrid._placeSortArrow();
            allowItemSizeChangeNotification = true;
            return;
        }// end function

        protected function drawHeaderBackground(param1:UIComponent) : void
        {
            var _loc_2:* = width;
            var _loc_3:* = cachedHeaderHeight;
            var _loc_4:* = param1.graphics;
            param1.graphics.clear();
            var _loc_5:* = getStyle("headerColors");
            StyleManager.getColorNames(_loc_5);
            var _loc_6:* = new Matrix();
            new Matrix().createGradientBox(_loc_2, (_loc_3 + 1), Math.PI / 2, 0, 0);
            _loc_5 = [_loc_5[0], _loc_5[0], _loc_5[1]];
            var _loc_7:Array = [0, 60, 255];
            var _loc_8:Array = [1, 1, 1];
            _loc_4.beginGradientFill(GradientType.LINEAR, _loc_5, _loc_8, _loc_7, _loc_6);
            _loc_4.lineStyle(0, 0, 0);
            _loc_4.moveTo(0, 0);
            _loc_4.lineTo(_loc_2, 0);
            _loc_4.lineTo(_loc_2, _loc_3 - 0.5);
            _loc_4.lineStyle(0, getStyle("borderColor"), 100);
            _loc_4.lineTo(0, _loc_3 - 0.5);
            _loc_4.lineStyle(0, 0, 0);
            _loc_4.endFill();
            return;
        }// end function

    }
}
