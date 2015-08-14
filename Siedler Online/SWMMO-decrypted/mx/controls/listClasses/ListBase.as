package mx.controls.listClasses
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.controls.dataGridClasses.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.skins.halo.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ListBase extends ScrollControlBase implements IDataRenderer, IFocusManagerComponent, IListItemRenderer, IDropInListItemRenderer, IEffectTargetHost
    {
        private var _labelField:String = "label";
        private var trackedRenderers:Array;
        var bSelectionChanged:Boolean = false;
        protected var offscreenExtraColumnsLeft:int = 0;
        protected var selectionTweens:Object;
        protected var caretItemRenderer:IListItemRenderer;
        protected var actualIterator:IViewCursor;
        protected var iteratorValid:Boolean = true;
        private var bSelectItem:Boolean = false;
        private var _allowMultipleSelection:Boolean = false;
        protected var cachedItemsChangeEffect:IEffect = null;
        private var lastSelectionData:ListBaseSelectionData;
        protected var iterator:IViewCursor;
        protected var rendererChanged:Boolean = false;
        protected var unconstrainedRenderers:Dictionary;
        protected var freeItemRenderersByFactory:Dictionary;
        private var columnWidthChanged:Boolean = false;
        protected var explicitColumnCount:int = -1;
        private var _data:Object;
        private var bSelectedItemsChanged:Boolean = false;
        private var selectionDataArray:Array;
        protected var defaultRowCount:int = 4;
        private var _rowCount:int = -1;
        protected var offscreenExtraRowsTop:int = 0;
        private var _dataTipField:String = "label";
        private var cachedPaddingTopInvalid:Boolean = true;
        protected var selectedData:Object;
        private var _labelFunction:Function;
        var listType:String = "grid";
        private var cachedPaddingBottomInvalid:Boolean = true;
        protected var runningDataEffect:Boolean = false;
        protected var runDataEffectNextUpdate:Boolean = false;
        private var bShiftKey:Boolean = false;
        private var columnCountChanged:Boolean = true;
        protected var rowMap:Object;
        var _selectedIndex:int = -1;
        var collectionIterator:IViewCursor;
        protected var lastDropIndex:int;
        private var bCtrlKey:Boolean = false;
        private var oldUnscaledHeight:Number;
        protected var explicitColumnWidth:Number;
        private var _dataTipFunction:Function;
        private var _iconFunction:Function;
        protected var dataItemWrappersByRenderer:Dictionary;
        protected var itemsNeedMeasurement:Boolean = true;
        protected var offscreenExtraRowsBottom:int = 0;
        protected var modifiedCollectionView:ModifiedCollectionView;
        private var _columnCount:int = -1;
        private var rowCountChanged:Boolean = true;
        protected var wordWrapChanged:Boolean = false;
        protected var explicitRowCount:int = -1;
        protected var offscreenExtraRows:int = 0;
        private var _dragEnabled:Boolean = false;
        private var bSortItemPending:Boolean = false;
        protected var caretIndicator:Sprite;
        protected var caretUID:String;
        protected var caretBookmark:CursorBookmark;
        public var allowDragSelection:Boolean = false;
        var allowRendererStealingDuringLayout:Boolean = true;
        private var _selectable:Boolean = true;
        protected var listContent:ListBaseContentHolder;
        private var _showDataTips:Boolean = false;
        private var _variableRowHeight:Boolean = false;
        private var cachedVerticalAlignInvalid:Boolean = true;
        private var _dragMoveEnabled:Boolean = false;
        private var _rowHeight:Number;
        private var _selectedItem:Object;
        public var menuSelectionMode:Boolean = false;
        var cachedPaddingTop:Number;
        private var _selectedIndices:Array;
        private var _columnWidth:Number;
        protected var defaultColumnCount:int = 4;
        private var rendererTrackingSuspended:Boolean = false;
        private var oldUnscaledWidth:Number;
        private var _nullItemRenderer:IFactory;
        var bColumnScrolling:Boolean = true;
        protected var showCaret:Boolean;
        private var firstSelectionData:ListBaseSelectionData;
        private var mouseDownItem:IListItemRenderer;
        protected var collection:ICollectionView;
        protected var offscreenExtraRowsOrColumnsChanged:Boolean = false;
        private var _offscreenExtraRowsOrColumns:int = 0;
        private var _iconField:String = "icon";
        protected var dataEffectCompleted:Boolean = false;
        private var bSelectedItemChanged:Boolean = false;
        private var _listData:BaseListData;
        var bSelectOnRelease:Boolean;
        protected var actualCollection:ICollectionView;
        var lastHighlightItemRenderer:IListItemRenderer;
        private var _itemRenderer:IFactory;
        var itemMaskFreeList:Array;
        protected var keySelectionPending:Boolean = false;
        private var mouseDownPoint:Point;
        protected var selectionIndicators:Object;
        protected var highlightUID:String;
        var dragScrollingInterval:int = 0;
        protected var anchorBookmark:CursorBookmark;
        protected var caretIndex:int = -1;
        protected var offscreenExtraColumnsRight:int = 0;
        private var _selectedItemsCompareFunction:Function;
        private var approximate:Boolean = false;
        protected var anchorIndex:int = -1;
        private var firstSelectedItem:Object;
        protected var selectionLayer:Sprite;
        protected var freeItemRenderers:Array;
        var bSelectedIndexChanged:Boolean = false;
        var cachedVerticalAlign:String;
        private var lastHighlightItemIndices:Point;
        var lastHighlightItemRendererAtIndices:IListItemRenderer;
        protected var lastSeekPending:ListBaseSeekPending;
        private var bSelectedIndicesChanged:Boolean = false;
        private var proposedSelectedItemIndexes:Dictionary;
        private var _dropEnabled:Boolean = false;
        protected var itemsSizeChanged:Boolean = false;
        var isPressed:Boolean = false;
        private var IS_ITEM_STYLE:Object;
        var cachedPaddingBottom:Number;
        protected var highlightIndicator:Sprite;
        private var verticalScrollPositionPending:Number;
        protected var explicitRowHeight:Number;
        protected var highlightItemRenderer:IListItemRenderer;
        private var rowHeightChanged:Boolean = false;
        var lastDragEvent:DragEvent;
        private var _wordWrap:Boolean = false;
        private var horizontalScrollPositionPending:Number;
        var dropIndicator:IFlexDisplayObject;
        private var _selectedItems:Array;
        protected var offscreenExtraColumns:int = 0;
        private var lastKey:uint = 0;
        protected var factoryMap:Dictionary;
        protected var reservedItemRenderers:Object;
        static var createAccessibilityImplementation:Function;
        private static var _listContentStyleFilters:Object = null;
        static const DRAG_THRESHOLD:int = 4;
        static const VERSION:String = "3.5.0.12683";

        public function ListBase()
        {
            IS_ITEM_STYLE = {alternatingItemColors:true, backgroundColor:true, backgroundDisabledColor:true, color:true, rollOverColor:true, selectionColor:true, selectionDisabledColor:true, styleName:true, textColor:true, textRollOverColor:true, textSelectedColor:true};
            rowMap = {};
            freeItemRenderers = [];
            reservedItemRenderers = {};
            unconstrainedRenderers = new Dictionary();
            dataItemWrappersByRenderer = new Dictionary(true);
            selectedData = {};
            selectionIndicators = {};
            selectionTweens = {};
            trackedRenderers = [];
            tabEnabled = true;
            factoryMap = new Dictionary(true);
            addEventListener(MouseEvent.MOUSE_WHEEL, mouseWheelHandler);
            addEventListener(MouseEvent.MOUSE_OVER, mouseOverHandler);
            addEventListener(MouseEvent.MOUSE_OUT, mouseOutHandler);
            addEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
            addEventListener(MouseEvent.MOUSE_MOVE, mouseMoveHandler);
            addEventListener(MouseEvent.CLICK, mouseClickHandler);
            addEventListener(MouseEvent.DOUBLE_CLICK, mouseDoubleClickHandler);
            invalidateProperties();
            return;
        }// end function

        public function get iconField() : String
        {
            return _iconField;
        }// end function

        public function set iconField(param1:String) : void
        {
            _iconField = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("iconFieldChanged"));
            return;
        }// end function

        function getItemUID(param1:Object) : String
        {
            return itemToUID(param1);
        }// end function

        public function measureWidthOfItems(param1:int = -1, param2:int = 0) : Number
        {
            return NaN;
        }// end function

        private function terminateSelectionTracking() : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_1:int = 0;
            while (_loc_1 < trackedRenderers.length)
            {
                
                _loc_2 = trackedRenderers[_loc_1] as IListItemRenderer;
                _loc_2.removeEventListener(MoveEvent.MOVE, rendererMoveHandler);
                _loc_1++;
            }
            trackedRenderers = [];
            return;
        }// end function

        public function get columnWidth() : Number
        {
            return _columnWidth;
        }// end function

        public function createItemRenderer(param1:Object) : IListItemRenderer
        {
            return null;
        }// end function

        protected function clearSelected(param1:Boolean = false) : void
        {
            var _loc_2:String = null;
            var _loc_3:Object = null;
            var _loc_4:IListItemRenderer = null;
            for (_loc_2 in selectedData)
            {
                
                _loc_3 = selectedData[_loc_2].data;
                removeSelectionData(_loc_2);
                _loc_4 = UIDToItemRenderer(itemToUID(_loc_3));
                if (_loc_4)
                {
                    drawItem(_loc_4, false, _loc_2 == highlightUID, false, param1);
                }
            }
            clearSelectionData();
            _selectedIndex = -1;
            _selectedItem = null;
            caretIndex = -1;
            anchorIndex = -1;
            caretBookmark = null;
            anchorBookmark = null;
            return;
        }// end function

        protected function addToRowArrays() : void
        {
            listItems.splice(0, 0, null);
            rowInfo.splice(0, 0, null);
            return;
        }// end function

        public function get nullItemRenderer() : IFactory
        {
            return _nullItemRenderer;
        }// end function

        public function get showDataTips() : Boolean
        {
            return _showDataTips;
        }// end function

        public function set columnWidth(param1:Number) : void
        {
            explicitColumnWidth = param1;
            if (_columnWidth != param1)
            {
                setColumnWidth(param1);
                invalidateSize();
                itemsSizeChanged = true;
                invalidateDisplayList();
                dispatchEvent(new Event("columnWidthChanged"));
            }
            return;
        }// end function

        protected function scrollHorizontally(param1:int, param2:int, param3:Boolean) : void
        {
            return;
        }// end function

        protected function drawHighlightIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = Sprite(param1).graphics;
            Sprite(param1).graphics.clear();
            _loc_8.beginFill(param6);
            _loc_8.drawRect(0, 0, param4, param5);
            _loc_8.endFill();
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        override public function get verticalScrollPosition() : Number
        {
            if (!isNaN(verticalScrollPositionPending))
            {
                return verticalScrollPositionPending;
            }
            return super.verticalScrollPosition;
        }// end function

        protected function drawCaretIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = Sprite(param1).graphics;
            Sprite(param1).graphics.clear();
            _loc_8.lineStyle(1, param6, 1);
            _loc_8.drawRect(0, 0, (param4 - 1), (param5 - 1));
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        private function makeAdditionalRows(param1:int) : void
        {
            var cursorPos:CursorBookmark;
            var rowIndex:* = param1;
            if (iterator)
            {
                cursorPos = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.CURRENT, listItems.length);
                }
                catch (e:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(CursorBookmark.CURRENT, listItems.length);
                    e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    iteratorValid = false;
                }
            }
            var curY:* = rowInfo[rowIndex].y + rowInfo[rowIndex].height;
            makeRowsAndColumns(0, curY, listContent.width, listContent.height, 0, (rowIndex + 1));
            seekPositionIgnoreError(iterator, cursorPos);
            return;
        }// end function

        public function set showDataTips(param1:Boolean) : void
        {
            _showDataTips = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("showDataTipsChanged"));
            return;
        }// end function

        public function set nullItemRenderer(param1:IFactory) : void
        {
            _nullItemRenderer = param1;
            invalidateSize();
            invalidateDisplayList();
            itemsSizeChanged = true;
            rendererChanged = true;
            dispatchEvent(new Event("nullItemRendererChanged"));
            return;
        }// end function

        protected function moveIndicatorsHorizontally(param1:String, param2:Number) : void
        {
            if (param1 != null)
            {
                if (selectionIndicators[param1])
                {
                    selectionIndicators[param1].x = selectionIndicators[param1].x + param2;
                }
                if (highlightUID == param1)
                {
                    highlightIndicator.x = highlightIndicator.x + param2;
                }
                if (caretUID == param1)
                {
                    caretIndicator.x = caretIndicator.x + param2;
                }
            }
            return;
        }// end function

        private function seekPreviousSafely(param1:IViewCursor, param2:int) : Boolean
        {
            var iterator:* = param1;
            var pos:* = param2;
            try
            {
                iterator.movePrevious();
            }
            catch (e:ItemPendingError)
            {
                lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, pos);
                e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                iteratorValid = false;
            }
            return iteratorValid;
        }// end function

        public function measureHeightOfItems(param1:int = -1, param2:int = 0) : Number
        {
            return NaN;
        }// end function

        public function get selectedItem() : Object
        {
            return _selectedItem;
        }// end function

        protected function mouseMoveHandler(event:MouseEvent) : void
        {
            var _loc_2:Point = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:DragEvent = null;
            var _loc_5:BaseListData = null;
            if (!enabled || !selectable)
            {
                return;
            }
            _loc_2 = new Point(event.localX, event.localY);
            _loc_2 = DisplayObject(event.target).localToGlobal(_loc_2);
            _loc_2 = globalToLocal(_loc_2);
            if (isPressed && mouseDownPoint && (Math.abs(mouseDownPoint.x - _loc_2.x) > DRAG_THRESHOLD || Math.abs(mouseDownPoint.y - _loc_2.y) > DRAG_THRESHOLD))
            {
                if (dragEnabled && !DragManager.isDragging && mouseDownPoint)
                {
                    _loc_4 = new DragEvent(DragEvent.DRAG_START);
                    _loc_4.dragInitiator = this;
                    _loc_4.localX = mouseDownPoint.x;
                    _loc_4.localY = mouseDownPoint.y;
                    _loc_4.buttonDown = true;
                    dispatchEvent(_loc_4);
                }
            }
            _loc_3 = mouseEventToItemRenderer(event);
            if (_loc_3 && highlightItemRenderer)
            {
                _loc_5 = rowMap[_loc_3.name];
                if (highlightItemRenderer && highlightUID && _loc_5.uid != highlightUID)
                {
                    if (!isPressed)
                    {
                        if (getStyle("useRollOver") && highlightItemRenderer.data != null)
                        {
                            clearHighlight(highlightItemRenderer);
                        }
                    }
                }
            }
            else if (!_loc_3 && highlightItemRenderer)
            {
                if (!isPressed)
                {
                    if (getStyle("useRollOver") && highlightItemRenderer.data)
                    {
                        clearHighlight(highlightItemRenderer);
                    }
                }
            }
            if (_loc_3 && !highlightItemRenderer)
            {
                mouseOverHandler(event);
            }
            return;
        }// end function

        public function get selectable() : Boolean
        {
            return _selectable;
        }// end function

        protected function seekPendingFailureHandler(param1:Object, param2:ListBaseSeekPending) : void
        {
            return;
        }// end function

        override public function set verticalScrollPosition(param1:Number) : void
        {
            var _loc_5:int = 0;
            var _loc_6:Boolean = false;
            if (listItems.length == 0 || !dataProvider || !isNaN(verticalScrollPositionPending))
            {
                verticalScrollPositionPending = param1;
                if (dataProvider)
                {
                    invalidateDisplayList();
                }
                return;
            }
            verticalScrollPositionPending = NaN;
            var _loc_2:* = super.verticalScrollPosition;
            super.verticalScrollPosition = param1;
            removeClipMask();
            var _loc_3:* = offscreenExtraRowsTop;
            var _loc_4:* = offscreenExtraRowsBottom;
            if (_loc_2 != param1)
            {
                _loc_5 = param1 - _loc_2;
                _loc_6 = _loc_5 > 0;
                _loc_5 = Math.abs(_loc_5);
                if (_loc_5 >= rowInfo.length - offscreenExtraRows || !iteratorValid)
                {
                    clearIndicators();
                    clearVisibleData();
                    makeRowsAndColumnsWithExtraRows(oldUnscaledWidth, oldUnscaledHeight);
                }
                else
                {
                    scrollVertically(param1, _loc_5, _loc_6);
                    adjustListContent(oldUnscaledWidth, oldUnscaledHeight);
                }
                if (variableRowHeight)
                {
                    configureScrollBars();
                }
                drawRowBackgrounds();
            }
            addClipMask(offscreenExtraRowsTop != _loc_3 || offscreenExtraRowsBottom != _loc_4);
            return;
        }// end function

        override public function get horizontalScrollPosition() : Number
        {
            if (!isNaN(horizontalScrollPositionPending))
            {
                return horizontalScrollPositionPending;
            }
            return super.horizontalScrollPosition;
        }// end function

        protected function itemRendererToIndices(param1:IListItemRenderer) : Point
        {
            if (!param1 || !(param1.name in rowMap))
            {
                return null;
            }
            var _loc_2:* = rowMap[param1.name].rowIndex;
            var _loc_3:* = listItems[_loc_2].length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                if (listItems[_loc_2][_loc_4] == param1)
                {
                    break;
                }
                _loc_4++;
            }
            return new Point(_loc_4 + horizontalScrollPosition, _loc_2 + verticalScrollPosition + offscreenExtraRowsTop);
        }// end function

        private function reduceRows(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:String = null;
            while (param1 >= 0)
            {
                
                if (rowInfo[param1].y >= listContent.height)
                {
                    _loc_2 = listItems[param1].length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        addToFreeItemRenderers(listItems[param1][_loc_3]);
                        _loc_3++;
                    }
                    _loc_4 = rowInfo[param1].uid;
                    delete visibleData[_loc_4];
                    removeIndicators(_loc_4);
                    listItems.pop();
                    rowInfo.pop();
                    param1 = param1 - 1;
                    continue;
                }
                break;
            }
            return;
        }// end function

        public function get dragMoveEnabled() : Boolean
        {
            return _dragMoveEnabled;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            var _loc_4:ListEvent = null;
            if (!selectable)
            {
                return;
            }
            if (!iteratorValid)
            {
                return;
            }
            if (!collection || collection.length == 0)
            {
                return;
            }
            switch(event.keyCode)
            {
                case Keyboard.UP:
                case Keyboard.DOWN:
                {
                    moveSelectionVertically(event.keyCode, event.shiftKey, event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.LEFT:
                case Keyboard.RIGHT:
                {
                    moveSelectionHorizontally(event.keyCode, event.shiftKey, event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.END:
                case Keyboard.HOME:
                case Keyboard.PAGE_UP:
                case Keyboard.PAGE_DOWN:
                {
                    moveSelectionVertically(event.keyCode, event.shiftKey, event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.SPACE:
                {
                    if (caretIndex != -1 && caretIndex - verticalScrollPosition >= 0 && caretIndex - verticalScrollPosition < listItems.length)
                    {
                        _loc_2 = listItems[caretIndex - verticalScrollPosition][0];
                        if (selectItem(_loc_2, event.shiftKey, event.ctrlKey))
                        {
                            _loc_3 = itemRendererToIndices(_loc_2);
                            _loc_4 = new ListEvent(ListEvent.CHANGE);
                            if (_loc_3)
                            {
                                _loc_4.columnIndex = _loc_3.x;
                                _loc_4.rowIndex = _loc_3.y;
                            }
                            _loc_4.itemRenderer = _loc_2;
                            dispatchEvent(_loc_4);
                        }
                    }
                    break;
                }
                default:
                {
                    if (findKey(event.charCode))
                    {
                        event.stopPropagation();
                    }
                    break;
                }
            }
            return;
        }// end function

        protected function reKeyVisibleData() : void
        {
            var _loc_2:Object = null;
            var _loc_1:Object = {};
            for each (_loc_2 in visibleData)
            {
                
                if (_loc_2.data)
                {
                    _loc_1[itemToUID(_loc_2.data)] = _loc_2;
                }
            }
            listContent.visibleData = _loc_1;
            return;
        }// end function

        protected function copySelectedItems(param1:Boolean = true) : Array
        {
            var _loc_2:Array = [];
            var _loc_3:* = firstSelectionData;
            while (_loc_3 != null)
            {
                
                if (param1)
                {
                    _loc_2.push(_loc_3.data);
                }
                else
                {
                    _loc_2.push(_loc_3.index);
                }
                _loc_3 = _loc_3.nextSelectionData;
            }
            return _loc_2;
        }// end function

        public function invalidateList() : void
        {
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        protected function moveIndicatorsVertically(param1:String, param2:Number) : void
        {
            if (param1 != null)
            {
                if (selectionIndicators[param1])
                {
                    selectionIndicators[param1].y = selectionIndicators[param1].y + param2;
                }
                if (highlightUID == param1)
                {
                    highlightIndicator.y = highlightIndicator.y + param2;
                }
                if (caretUID == param1)
                {
                    caretIndicator.y = caretIndicator.y + param2;
                }
            }
            return;
        }// end function

        public function indexToItemRenderer(param1:int) : IListItemRenderer
        {
            var _loc_2:* = verticalScrollPosition - offscreenExtraRowsTop;
            if (param1 < _loc_2 || param1 >= _loc_2 + listItems.length)
            {
                return null;
            }
            return listItems[param1 - _loc_2][0];
        }// end function

        protected function get dragImage() : IUIComponent
        {
            var _loc_1:* = new ListItemDragProxy();
            _loc_1.owner = this;
            _loc_1.moduleFactory = moduleFactory;
            return _loc_1;
        }// end function

        protected function copyItemWithUID(param1:Object) : Object
        {
            var _loc_2:Object = null;
            _loc_2 = ObjectUtil.copy(param1);
            if (_loc_2 is IUID)
            {
                IUID(_loc_2).uid = UIDUtil.createUID();
            }
            else if (_loc_2 is Object && "mx_internal_uid" in _loc_2)
            {
                _loc_2.mx_internal_uid = UIDUtil.createUID();
            }
            return _loc_2;
        }// end function

        public function get selectedIndices() : Array
        {
            if (bSelectedIndicesChanged)
            {
                return _selectedIndices;
            }
            return copySelectedItems(false);
        }// end function

        public function get variableRowHeight() : Boolean
        {
            return _variableRowHeight;
        }// end function

        protected function mouseDoubleClickHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            var _loc_4:ListEvent = null;
            _loc_2 = mouseEventToItemRenderer(event);
            if (!_loc_2)
            {
                return;
            }
            _loc_3 = itemRendererToIndices(_loc_2);
            if (_loc_3)
            {
                _loc_4 = new ListEvent(ListEvent.ITEM_DOUBLE_CLICK);
                _loc_4.columnIndex = _loc_3.x;
                _loc_4.rowIndex = _loc_3.y;
                _loc_4.itemRenderer = _loc_2;
                dispatchEvent(_loc_4);
            }
            return;
        }// end function

        function selectionDataPendingResultHandler(param1:Object, param2:ListBaseSelectionDataPending) : void
        {
            if (param2.bookmark)
            {
                collectionIterator.seek(param2.bookmark, param2.offset);
            }
            setSelectionDataLoop(param2.items, param2.index, param2.useFind);
            return;
        }// end function

        public function set selectedItem(param1:Object) : void
        {
            if (!collection || collection.length == 0)
            {
                _selectedItem = param1;
                bSelectedItemChanged = true;
                bSelectionChanged = true;
                invalidateDisplayList();
                return;
            }
            commitSelectedItem(param1);
            return;
        }// end function

        private function adjustScrollPosition() : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:int = 0;
            var _loc_1:Boolean = false;
            if (!isNaN(horizontalScrollPositionPending))
            {
                _loc_1 = true;
                _loc_2 = Math.min(horizontalScrollPositionPending, maxHorizontalScrollPosition);
                horizontalScrollPositionPending = NaN;
                super.horizontalScrollPosition = _loc_2;
            }
            if (!isNaN(verticalScrollPositionPending))
            {
                _loc_1 = true;
                _loc_3 = Math.min(verticalScrollPositionPending, maxVerticalScrollPosition);
                verticalScrollPositionPending = NaN;
                super.verticalScrollPosition = _loc_3;
            }
            if (_loc_1)
            {
                _loc_4 = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition - offscreenExtraRowsTop);
                seekPositionSafely(_loc_4);
            }
            return;
        }// end function

        protected function itemToUID(param1:Object) : String
        {
            if (param1 == null)
            {
                return "null";
            }
            return UIDUtil.getUID(param1);
        }// end function

        protected function dragEnterHandler(event:DragEvent) : void
        {
            if (event.isDefaultPrevented())
            {
                return;
            }
            lastDragEvent = event;
            if (enabled && iteratorValid && event.dragSource.hasFormat("items"))
            {
                DragManager.acceptDragDrop(this);
                DragManager.showFeedback(event.ctrlKey ? (DragManager.COPY) : (DragManager.MOVE));
                showDropFeedback(event);
                return;
            }
            hideDropFeedback(event);
            DragManager.showFeedback(DragManager.NONE);
            return;
        }// end function

        protected function indexToColumn(param1:int) : int
        {
            return 0;
        }// end function

        public function set selectable(param1:Boolean) : void
        {
            _selectable = param1;
            return;
        }// end function

        protected function moveRowVertically(param1:int, param2:int, param3:Number) : void
        {
            var _loc_4:IListItemRenderer = null;
            var _loc_5:int = 0;
            while (_loc_5 < param2)
            {
                
                _loc_4 = listItems[param1][_loc_5];
                listItems[param1][_loc_5].move(_loc_4.x, _loc_4.y + param3);
                _loc_5++;
            }
            rowInfo[param1].y = rowInfo[param1].y + param3;
            return;
        }// end function

        override public function set horizontalScrollPosition(param1:Number) : void
        {
            var _loc_3:int = 0;
            var _loc_4:Boolean = false;
            if (listItems.length == 0 || !dataProvider || !isNaN(horizontalScrollPositionPending))
            {
                horizontalScrollPositionPending = param1;
                if (dataProvider)
                {
                    invalidateDisplayList();
                }
                return;
            }
            horizontalScrollPositionPending = NaN;
            var _loc_2:* = super.horizontalScrollPosition;
            super.horizontalScrollPosition = param1;
            removeClipMask();
            if (_loc_2 != param1)
            {
                if (itemsSizeChanged)
                {
                    return;
                }
                _loc_3 = param1 - _loc_2;
                _loc_4 = _loc_3 > 0;
                _loc_3 = Math.abs(_loc_3);
                if (bColumnScrolling && _loc_3 >= columnCount)
                {
                    clearIndicators();
                    clearVisibleData();
                    makeRowsAndColumnsWithExtraColumns(oldUnscaledWidth, oldUnscaledHeight);
                    drawRowBackgrounds();
                }
                else
                {
                    scrollHorizontally(param1, _loc_3, _loc_4);
                }
            }
            addClipMask(false);
            return;
        }// end function

        public function set dragMoveEnabled(param1:Boolean) : void
        {
            _dragMoveEnabled = param1;
            return;
        }// end function

        public function isItemHighlighted(param1:Object) : Boolean
        {
            if (param1 == null)
            {
                return false;
            }
            var _loc_2:* = highlightIndicator && highlightIndicator.parent.getChildIndex(highlightIndicator) != (highlightIndicator.parent.numChildren - 1);
            if (param1 is String)
            {
                return param1 == highlightUID && !_loc_2;
            }
            return itemToUID(param1) == highlightUID && !_loc_2;
        }// end function

        override protected function mouseWheelHandler(event:MouseEvent) : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:int = 0;
            var _loc_4:ScrollEvent = null;
            if (verticalScrollBar && verticalScrollBar.visible)
            {
                event.stopPropagation();
                _loc_2 = verticalScrollPosition;
                _loc_3 = verticalScrollPosition;
                _loc_3 = _loc_3 - event.delta * verticalScrollBar.lineScrollSize;
                _loc_3 = Math.max(0, Math.min(_loc_3, verticalScrollBar.maxScrollPosition));
                verticalScrollPosition = _loc_3;
                if (_loc_2 != verticalScrollPosition)
                {
                    _loc_4 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_4.direction = ScrollEventDirection.VERTICAL;
                    _loc_4.position = verticalScrollPosition;
                    _loc_4.delta = verticalScrollPosition - _loc_2;
                    dispatchEvent(_loc_4);
                }
            }
            return;
        }// end function

        protected function restoreRowArrays(param1:int) : void
        {
            rowInfo.splice(0, param1);
            listItems.splice(0, param1);
            return;
        }// end function

        public function set labelField(param1:String) : void
        {
            _labelField = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("labelFieldChanged"));
            return;
        }// end function

        private function seekPositionIgnoreError(param1:IViewCursor, param2:CursorBookmark) : void
        {
            var iterator:* = param1;
            var cursorPos:* = param2;
            if (iterator)
            {
                try
                {
                    iterator.seek(cursorPos, 0);
                }
                catch (e:ItemPendingError)
                {
                }
            }
            return;
        }// end function

        protected function finishDataChangeEffect(event:EffectEvent) : void
        {
            collection = actualCollection;
            actualCollection = null;
            modifiedCollectionView = null;
            var _loc_3:* = actualIterator;
            iterator = actualIterator;
            listContent.iterator = _loc_3;
            runningDataEffect = false;
            unconstrainedRenderers = new Dictionary();
            terminateSelectionTracking();
            reKeyVisibleData();
            var _loc_2:* = scrollPositionToIndex(horizontalScrollPosition - offscreenExtraColumnsLeft, verticalScrollPosition - offscreenExtraRowsTop);
            iterator.seek(CursorBookmark.FIRST, _loc_2);
            callLater(cleanupAfterDataChangeEffect);
            return;
        }// end function

        public function set offscreenExtraRowsOrColumns(param1:int) : void
        {
            param1 = Math.max(param1, 0);
            if (param1 % 2)
            {
                param1++;
            }
            if (_offscreenExtraRowsOrColumns == param1)
            {
                return;
            }
            _offscreenExtraRowsOrColumns = param1;
            offscreenExtraRowsOrColumnsChanged = true;
            invalidateProperties();
            return;
        }// end function

        function clearHighlight(param1:IListItemRenderer) : void
        {
            var _loc_4:ListEvent = null;
            var _loc_2:* = itemToUID(param1.data);
            drawItem(UIDToItemRenderer(_loc_2), isItemSelected(param1.data), false, _loc_2 == caretUID);
            var _loc_3:* = itemRendererToIndices(param1);
            if (_loc_3 && lastHighlightItemIndices)
            {
                _loc_4 = new ListEvent(ListEvent.ITEM_ROLL_OUT);
                _loc_4.columnIndex = lastHighlightItemIndices.x;
                _loc_4.rowIndex = lastHighlightItemIndices.y;
                _loc_4.itemRenderer = lastHighlightItemRendererAtIndices;
                dispatchEvent(_loc_4);
                lastHighlightItemIndices = null;
            }
            return;
        }// end function

        public function set wordWrap(param1:Boolean) : void
        {
            if (param1 == _wordWrap)
            {
                return;
            }
            _wordWrap = param1;
            wordWrapChanged = true;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("wordWrapChanged"));
            return;
        }// end function

        private function shiftSelectionLoop(param1:Boolean, param2:int, param3:Object, param4:Boolean, param5:CursorBookmark) : void
        {
            var data:Object;
            var uid:String;
            var incr:* = param1;
            var index:* = param2;
            var stopData:* = param3;
            var transition:* = param4;
            var placeHolder:* = param5;
            try
            {
                do
                {
                    
                    data = iterator.current;
                    uid = itemToUID(data);
                    insertSelectionDataBefore(uid, new ListBaseSelectionData(data, index, approximate), firstSelectionData);
                    if (UIDToItemRenderer(uid))
                    {
                        drawItem(UIDToItemRenderer(uid), true, uid == highlightUID, false, transition);
                    }
                    if (data === stopData)
                    {
                        if (UIDToItemRenderer(uid))
                        {
                            drawItem(UIDToItemRenderer(uid), true, uid == highlightUID, true, transition);
                        }
                        break;
                    }
                    if (incr)
                    {
                        index = (index + 1);
                        continue;
                    }
                    index = (index - 1);
                }while (incr ? (iterator.moveNext()) : (iterator.movePrevious()))
            }
            catch (e:ItemPendingError)
            {
                e.addResponder(new ItemResponder(selectionPendingResultHandler, selectionPendingFailureHandler, new ListBaseSelectionPending(incr, index, stopData, transition, placeHolder, CursorBookmark.CURRENT, 0)));
                iteratorValid = false;
                try
                {
                }
                iterator.seek(placeHolder, 0);
                if (!iteratorValid)
                {
                    iteratorValid = true;
                    lastSeekPending = null;
                }
            }
            catch (e2:ItemPendingError)
            {
                lastSeekPending = new ListBaseSeekPending(placeHolder, 0);
                e2.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
            }
            return;
        }// end function

        protected function clearHighlightIndicator(param1:Sprite, param2:IListItemRenderer) : void
        {
            if (highlightIndicator)
            {
                Sprite(highlightIndicator).graphics.clear();
            }
            return;
        }// end function

        protected function truncateRowArrays(param1:int) : void
        {
            listItems.splice(param1);
            rowInfo.splice(param1);
            return;
        }// end function

        public function get itemRenderer() : IFactory
        {
            return _itemRenderer;
        }// end function

        protected function seekPositionSafely(param1:int) : Boolean
        {
            var index:* = param1;
            try
            {
                iterator.seek(CursorBookmark.FIRST, index);
                if (!iteratorValid)
                {
                    iteratorValid = true;
                    lastSeekPending = null;
                }
            }
            catch (e:ItemPendingError)
            {
                lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, index);
                e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                iteratorValid = false;
            }
            return iteratorValid;
        }// end function

        function set $horizontalScrollPosition(param1:Number) : void
        {
            var _loc_2:* = super.horizontalScrollPosition;
            if (_loc_2 != param1)
            {
                super.horizontalScrollPosition = param1;
            }
            return;
        }// end function

        protected function applySelectionEffect(param1:Sprite, param2:String, param3:IListItemRenderer) : void
        {
            var _loc_5:Function = null;
            var _loc_4:* = getStyle("selectionDuration");
            if (getStyle("selectionDuration") != 0)
            {
                param1.alpha = 0;
                selectionTweens[param2] = new Tween(param1, 0, 1, _loc_4, 5);
                selectionTweens[param2].addEventListener(TweenEvent.TWEEN_UPDATE, selectionTween_updateHandler);
                selectionTweens[param2].addEventListener(TweenEvent.TWEEN_END, selectionTween_endHandler);
                selectionTweens[param2].setTweenHandlers(onSelectionTweenUpdate, onSelectionTweenUpdate);
                _loc_5 = getStyle("selectionEasingFunction") as Function;
                if (_loc_5 != null)
                {
                    selectionTweens[param2].easingFunction = _loc_5;
                }
            }
            return;
        }// end function

        override public function set showInAutomationHierarchy(param1:Boolean) : void
        {
            return;
        }// end function

        protected function removeFromRowArrays(param1:int) : void
        {
            listItems.splice(param1, 1);
            rowInfo.splice(param1, 1);
            return;
        }// end function

        protected function updateList() : void
        {
            removeClipMask();
            var _loc_1:* = iterator ? (iterator.bookmark) : (null);
            clearIndicators();
            clearVisibleData();
            if (iterator)
            {
                if (offscreenExtraColumns || offscreenExtraColumnsLeft || offscreenExtraColumnsRight)
                {
                    makeRowsAndColumnsWithExtraColumns(unscaledWidth, unscaledHeight);
                }
                else
                {
                    makeRowsAndColumnsWithExtraRows(unscaledWidth, unscaledHeight);
                }
                iterator.seek(_loc_1, 0);
            }
            else
            {
                makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
            }
            drawRowBackgrounds();
            configureScrollBars();
            addClipMask(true);
            return;
        }// end function

        public function set variableRowHeight(param1:Boolean) : void
        {
            _variableRowHeight = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("variableRowHeightChanged"));
            return;
        }// end function

        protected function isRendererUnconstrained(param1:Object) : Boolean
        {
            return unconstrainedRenderers[param1] != null;
        }// end function

        public function set selectedIndices(param1:Array) : void
        {
            if (!collection || collection.length == 0)
            {
                _selectedIndices = param1;
                bSelectedIndicesChanged = true;
                bSelectionChanged = true;
                invalidateDisplayList();
                return;
            }
            commitSelectedIndices(param1);
            return;
        }// end function

        protected function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            var _loc_4:ListEvent = null;
            mouseDownPoint = null;
            _loc_2 = mouseEventToItemRenderer(event);
            _loc_3 = itemRendererToIndices(_loc_2);
            mouseIsUp();
            if (!enabled || !selectable)
            {
                return;
            }
            if (mouseDownItem)
            {
                _loc_4 = new ListEvent(ListEvent.CHANGE);
                _loc_4.itemRenderer = mouseDownItem;
                _loc_3 = itemRendererToIndices(mouseDownItem);
                if (_loc_3)
                {
                    _loc_4.columnIndex = _loc_3.x;
                    _loc_4.rowIndex = _loc_3.y;
                }
                dispatchEvent(_loc_4);
                mouseDownItem = null;
            }
            if (!_loc_2 || !hitTestPoint(event.stageX, event.stageY))
            {
                isPressed = false;
                return;
            }
            if (bSelectOnRelease)
            {
                bSelectOnRelease = false;
                if (selectItem(_loc_2, event.shiftKey, event.ctrlKey))
                {
                    _loc_4 = new ListEvent(ListEvent.CHANGE);
                    _loc_4.itemRenderer = _loc_2;
                    if (_loc_3)
                    {
                        _loc_4.columnIndex = _loc_3.x;
                        _loc_4.rowIndex = _loc_3.y;
                    }
                    dispatchEvent(_loc_4);
                }
            }
            isPressed = false;
            return;
        }// end function

        public function get allowMultipleSelection() : Boolean
        {
            return _allowMultipleSelection;
        }// end function

        public function itemToItemRenderer(param1:Object) : IListItemRenderer
        {
            return UIDToItemRenderer(itemToUID(param1));
        }// end function

        public function isItemSelected(param1:Object) : Boolean
        {
            if (param1 == null)
            {
                return false;
            }
            if (param1 is String)
            {
                return selectedData[param1] != undefined;
            }
            return selectedData[itemToUID(param1)] != undefined;
        }// end function

        protected function dragScroll() : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:ScrollEvent = null;
            var _loc_1:Number = 0;
            if (dragScrollingInterval == 0)
            {
                return;
            }
            var _loc_6:Number = 30;
            _loc_3 = verticalScrollPosition;
            if (DragManager.isDragging)
            {
                _loc_1 = viewMetrics.top + (variableRowHeight ? (getStyle("fontSize") / 4) : (rowHeight));
            }
            clearInterval(dragScrollingInterval);
            if (mouseY < _loc_1)
            {
                verticalScrollPosition = Math.max(0, (_loc_3 - 1));
                if (DragManager.isDragging)
                {
                    _loc_2 = 100;
                }
                else
                {
                    _loc_4 = Math.min(-mouseY - 30, 0);
                    _loc_2 = 0.593 * _loc_4 * _loc_4 + 1 + _loc_6;
                }
                dragScrollingInterval = setInterval(dragScroll, _loc_2);
                if (_loc_3 != verticalScrollPosition)
                {
                    _loc_5 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_5.detail = ScrollEventDetail.THUMB_POSITION;
                    _loc_5.direction = ScrollEventDirection.VERTICAL;
                    _loc_5.position = verticalScrollPosition;
                    _loc_5.delta = verticalScrollPosition - _loc_3;
                    dispatchEvent(_loc_5);
                }
            }
            else if (mouseY > unscaledHeight - _loc_1)
            {
                verticalScrollPosition = Math.min(maxVerticalScrollPosition, (verticalScrollPosition + 1));
                if (DragManager.isDragging)
                {
                    _loc_2 = 100;
                }
                else
                {
                    _loc_4 = Math.min(mouseY - unscaledHeight - 30, 0);
                    _loc_2 = 0.593 * _loc_4 * _loc_4 + 1 + _loc_6;
                }
                dragScrollingInterval = setInterval(dragScroll, _loc_2);
                if (_loc_3 != verticalScrollPosition)
                {
                    _loc_5 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_5.detail = ScrollEventDetail.THUMB_POSITION;
                    _loc_5.direction = ScrollEventDirection.VERTICAL;
                    _loc_5.position = verticalScrollPosition;
                    _loc_5.delta = verticalScrollPosition - _loc_3;
                    dispatchEvent(_loc_5);
                }
            }
            else
            {
                dragScrollingInterval = setInterval(dragScroll, 15);
            }
            if (DragManager.isDragging && lastDragEvent && _loc_3 != verticalScrollPosition)
            {
                dragOverHandler(lastDragEvent);
            }
            return;
        }// end function

        protected function moveSelectionHorizontally(param1:uint, param2:Boolean, param3:Boolean) : void
        {
            return;
        }// end function

        private function findStringLoop(param1:String, param2:CursorBookmark, param3:int, param4:int) : Boolean
        {
            var itmStr:String;
            var item:IListItemRenderer;
            var pt:Point;
            var evt:ListEvent;
            var more:Boolean;
            var str:* = param1;
            var cursorPos:* = param2;
            var i:* = param3;
            var stopIndex:* = param4;
            while (i != stopIndex)
            {
                
                itmStr = itemToLabel(iterator.current);
                itmStr = itmStr.substring(0, str.length);
                if (str == itmStr || str.toUpperCase() == itmStr.toUpperCase())
                {
                    iterator.seek(cursorPos, 0);
                    scrollToIndex(i);
                    commitSelectedIndex(i);
                    item = indexToItemRenderer(i);
                    pt = itemRendererToIndices(item);
                    evt = new ListEvent(ListEvent.CHANGE);
                    evt.itemRenderer = item;
                    if (pt)
                    {
                        evt.columnIndex = pt.x;
                        evt.rowIndex = pt.y;
                    }
                    dispatchEvent(evt);
                    return true;
                }
                try
                {
                    more = iterator.moveNext();
                }
                catch (e1:ItemPendingError)
                {
                    e1.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, CursorBookmark.CURRENT, 1, (i + 1), stopIndex)));
                    iteratorValid = false;
                    return false;
                }
                if (!more && stopIndex != collection.length)
                {
                    i;
                    try
                    {
                        iterator.seek(CursorBookmark.FIRST, 0);
                    }
                    catch (e2:ItemPendingError)
                    {
                        e2.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, CursorBookmark.FIRST, 0, 0, stopIndex)));
                        iteratorValid = false;
                        return false;
                    }
                }
                i = (i + 1);
            }
            iterator.seek(cursorPos, 0);
            iteratorValid = true;
            return false;
        }// end function

        protected function drawRowBackgrounds() : void
        {
            return;
        }// end function

        private function selectionIndicesPendingResultHandler(param1:Object, param2:ListBaseSelectionDataPending) : void
        {
            if (param2.bookmark)
            {
                iterator.seek(param2.bookmark, param2.offset);
            }
            setSelectionIndicesLoop(param2.index, param2.items, param2.useFind);
            return;
        }// end function

        public function itemRendererContains(param1:IListItemRenderer, param2:DisplayObject) : Boolean
        {
            if (!param2)
            {
                return false;
            }
            if (!param1)
            {
                return false;
            }
            return param1.owns(param2);
        }// end function

        public function removeDataEffectItem(param1:Object) : void
        {
            if (modifiedCollectionView)
            {
                modifiedCollectionView.removeItem(dataItemWrappersByRenderer[param1]);
                iterator.seek(CursorBookmark.CURRENT);
                if (invalidateDisplayListFlag)
                {
                    callLater(invalidateList);
                }
                else
                {
                    invalidateList();
                }
            }
            return;
        }// end function

        public function itemRendererToIndex(param1:IListItemRenderer) : int
        {
            var _loc_2:int = 0;
            if (param1.name in rowMap)
            {
                _loc_2 = rowMap[param1.name].rowIndex;
                return _loc_2 + verticalScrollPosition - offscreenExtraRowsTop;
            }
            return int.MIN_VALUE;
        }// end function

        override public function set horizontalScrollPolicy(param1:String) : void
        {
            super.horizontalScrollPolicy = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        public function get dropEnabled() : Boolean
        {
            return _dropEnabled;
        }// end function

        private function setSelectionIndicesLoop(param1:int, param2:Array, param3:Boolean = false) : void
        {
            var data:Object;
            var uid:String;
            var index:* = param1;
            var indices:* = param2;
            var firstTime:* = param3;
            while (indices.length)
            {
                
                if (index != indices[0])
                {
                    try
                    {
                        collectionIterator.seek(CursorBookmark.CURRENT, indices[0] - index);
                    }
                    catch (e:ItemPendingError)
                    {
                        e.addResponder(new ItemResponder(selectionIndicesPendingResultHandler, selectionIndicesPendingFailureHandler, new ListBaseSelectionDataPending(firstTime, index, indices, CursorBookmark.CURRENT, indices[0] - index)));
                        return;
                    }
                }
                index = indices[0];
                indices.shift();
                data = collectionIterator.current;
                if (firstTime)
                {
                    _selectedIndex = index;
                    _selectedItem = data;
                    caretIndex = index;
                    caretBookmark = collectionIterator.bookmark;
                    anchorIndex = index;
                    anchorBookmark = collectionIterator.bookmark;
                    firstTime;
                }
                uid = itemToUID(data);
                insertSelectionDataAfter(uid, new ListBaseSelectionData(data, index, false), lastSelectionData);
                if (UIDToItemRenderer(uid))
                {
                    drawItem(UIDToItemRenderer(uid), true, uid == highlightUID, caretIndex == index);
                }
            }
            if (initialized)
            {
                updateList();
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        override protected function measure() : void
        {
            super.measure();
            var _loc_1:* = viewMetrics;
            var _loc_2:* = explicitColumnCount < 1 ? (defaultColumnCount) : (explicitColumnCount);
            var _loc_3:* = explicitRowCount < 1 ? (defaultRowCount) : (explicitRowCount);
            if (!isNaN(explicitRowHeight))
            {
                measuredHeight = explicitRowHeight * _loc_3 + _loc_1.top + _loc_1.bottom;
                measuredMinHeight = explicitRowHeight * Math.min(_loc_3, 2) + _loc_1.top + _loc_1.bottom;
            }
            else
            {
                measuredHeight = rowHeight * _loc_3 + _loc_1.top + _loc_1.bottom;
                measuredMinHeight = rowHeight * Math.min(_loc_3, 2) + _loc_1.top + _loc_1.bottom;
            }
            if (!isNaN(explicitColumnWidth))
            {
                measuredWidth = explicitColumnWidth * _loc_2 + _loc_1.left + _loc_1.right;
                measuredMinWidth = explicitColumnWidth * Math.min(_loc_2, 1) + _loc_1.left + _loc_1.right;
            }
            else
            {
                measuredWidth = columnWidth * _loc_2 + _loc_1.left + _loc_1.right;
                measuredMinWidth = columnWidth * Math.min(_loc_2, 1) + _loc_1.left + _loc_1.right;
            }
            if (verticalScrollPolicy == ScrollPolicy.AUTO && verticalScrollBar && verticalScrollBar.visible)
            {
                measuredWidth = measuredWidth - verticalScrollBar.minWidth;
                measuredMinWidth = measuredMinWidth - verticalScrollBar.minWidth;
            }
            if (horizontalScrollPolicy == ScrollPolicy.AUTO && horizontalScrollBar && horizontalScrollBar.visible)
            {
                measuredHeight = measuredHeight - horizontalScrollBar.minHeight;
                measuredMinHeight = measuredMinHeight - horizontalScrollBar.minHeight;
            }
            return;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        private function removeSelectionData(param1:String) : void
        {
            var _loc_2:* = selectedData[param1];
            if (firstSelectionData == _loc_2)
            {
                firstSelectionData = _loc_2.nextSelectionData;
            }
            if (lastSelectionData == _loc_2)
            {
                lastSelectionData = _loc_2.prevSelectionData;
            }
            if (_loc_2.prevSelectionData != null)
            {
                _loc_2.prevSelectionData.nextSelectionData = _loc_2.nextSelectionData;
            }
            if (_loc_2.nextSelectionData != null)
            {
                _loc_2.nextSelectionData.prevSelectionData = _loc_2.prevSelectionData;
            }
            delete selectedData[param1];
            return;
        }// end function

        protected function setRowHeight(param1:Number) : void
        {
            _rowHeight = param1;
            return;
        }// end function

        public function indicesToIndex(param1:int, param2:int) : int
        {
            return param1 * columnCount + param2;
        }// end function

        public function get value() : Object
        {
            var _loc_1:* = selectedItem;
            if (!_loc_1)
            {
                return null;
            }
            if (typeof(_loc_1) != "object")
            {
                return _loc_1;
            }
            return _loc_1.data != null ? (_loc_1.data) : (_loc_1.label);
        }// end function

        function getRowInfo() : Array
        {
            return rowInfo;
        }// end function

        private function rendererMoveHandler(event:MoveEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            if (!rendererTrackingSuspended)
            {
                _loc_2 = event.currentTarget as IListItemRenderer;
                drawItem(_loc_2, true);
            }
            return;
        }// end function

        protected function calculateDropIndicatorY(param1:Number, param2:int) : Number
        {
            var _loc_3:int = 0;
            var _loc_4:Number = 0;
            if (param1 && param2 < param1 && listItems[param2].length && listItems[param2][0])
            {
                return (listItems[param2][0].y - 1);
            }
            _loc_3 = 0;
            while (_loc_3 < param1)
            {
                
                if (listItems[_loc_3].length)
                {
                    _loc_4 = _loc_4 + rowInfo[_loc_3].height;
                }
                else
                {
                    break;
                }
                _loc_3++;
            }
            return _loc_4;
        }// end function

        protected function clearCaretIndicator(param1:Sprite, param2:IListItemRenderer) : void
        {
            if (caretIndicator)
            {
                Sprite(caretIndicator).graphics.clear();
            }
            return;
        }// end function

        override public function validateDisplayList() : void
        {
            var _loc_1:ISystemManager = null;
            if (invalidateDisplayListFlag)
            {
                _loc_1 = parent as ISystemManager;
                if (_loc_1)
                {
                    if (_loc_1 == systemManager.topLevelSystemManager && _loc_1.document != this)
                    {
                        setActualSize(getExplicitOrMeasuredWidth(), getExplicitOrMeasuredHeight());
                    }
                }
                if (runDataEffectNextUpdate)
                {
                    runDataEffectNextUpdate = false;
                    runningDataEffect = true;
                    initiateDataChangeEffect(scaleX == 0 ? (0) : (width / scaleX), scaleY == 0 ? (0) : (height / scaleY));
                }
                else
                {
                    updateDisplayList(scaleX == 0 ? (0) : (width / scaleX), scaleY == 0 ? (0) : (height / scaleY));
                }
                invalidateDisplayListFlag = false;
            }
            return;
        }// end function

        function getListVisibleData() : Object
        {
            return visibleData;
        }// end function

        public function getRendererSemanticValue(param1:Object, param2:String) : Object
        {
            return modifiedCollectionView.getSemantics(dataItemWrappersByRenderer[param1]) == param2;
        }// end function

        function setColumnCount(param1:int) : void
        {
            _columnCount = param1;
            return;
        }// end function

        function hasOnlyTextRenderers() : Boolean
        {
            if (listItems.length == 0)
            {
                return true;
            }
            var _loc_1:* = listItems[(listItems.length - 1)];
            var _loc_2:* = _loc_1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (!(_loc_1[_loc_3] is IUITextField))
                {
                    return false;
                }
                _loc_3++;
            }
            return true;
        }// end function

        protected function sumRowHeights(param1:int, param2:int) : Number
        {
            var _loc_3:Number = 0;
            var _loc_4:* = param1;
            while (_loc_4 <= param2)
            {
                
                _loc_3 = _loc_3 + rowInfo[_loc_4].height;
                _loc_4++;
            }
            return _loc_3;
        }// end function

        protected function get rowInfo() : Array
        {
            return listContent.rowInfo;
        }// end function

        private function selectionPendingFailureHandler(param1:Object, param2:ListBaseSelectionPending) : void
        {
            return;
        }// end function

        function convertIndexToColumn(param1:int) : int
        {
            return indexToColumn(param1);
        }// end function

        function createItemMask(param1:Number, param2:Number, param3:Number, param4:Number, param5:DisplayObjectContainer = null) : DisplayObject
        {
            var _loc_6:Shape = null;
            var _loc_7:Graphics = null;
            if (!itemMaskFreeList)
            {
                itemMaskFreeList = [];
            }
            if (itemMaskFreeList.length > 0)
            {
                _loc_6 = itemMaskFreeList.pop();
                if (_loc_6.width != param3)
                {
                    _loc_6.width = param3;
                }
                if (_loc_6.height != param4)
                {
                    _loc_6.height = param4;
                }
            }
            else
            {
                _loc_6 = new FlexShape();
                _loc_6.name = "mask";
                _loc_7 = _loc_6.graphics;
                _loc_7.beginFill(16777215);
                _loc_7.drawRect(0, 0, param3, param4);
                _loc_7.endFill();
                _loc_6.visible = false;
                if (param5)
                {
                    param5.addChild(_loc_6);
                }
                else
                {
                    listContent.addChild(_loc_6);
                }
            }
            if (_loc_6.x != param1)
            {
                _loc_6.x = param1;
            }
            if (_loc_6.y != param2)
            {
                _loc_6.y = param2;
            }
            return _loc_6;
        }// end function

        function convertIndexToRow(param1:int) : int
        {
            return indexToRow(param1);
        }// end function

        protected function get listItems() : Array
        {
            return listContent ? (listContent.listItems) : ([]);
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            super.commitProperties();
            if (listContent && listContent.iterator != iterator)
            {
                listContent.iterator = iterator;
            }
            if (cachedPaddingTopInvalid)
            {
                cachedPaddingTopInvalid = false;
                cachedPaddingTop = getStyle("paddingTop");
                itemsSizeChanged = true;
                invalidateDisplayList();
            }
            if (cachedPaddingBottomInvalid)
            {
                cachedPaddingBottomInvalid = false;
                cachedPaddingBottom = getStyle("paddingBottom");
                itemsSizeChanged = true;
                invalidateDisplayList();
            }
            if (cachedVerticalAlignInvalid)
            {
                cachedVerticalAlignInvalid = false;
                cachedVerticalAlign = getStyle("verticalAlign");
                itemsSizeChanged = true;
                invalidateDisplayList();
            }
            if (columnCountChanged)
            {
                if (_columnCount < 1)
                {
                    _columnCount = defaultColumnCount;
                }
                if (!isNaN(explicitWidth) && isNaN(explicitColumnWidth) && explicitColumnCount > 0)
                {
                    setColumnWidth((explicitWidth - viewMetrics.left - viewMetrics.right) / columnCount);
                }
                columnCountChanged = false;
            }
            if (rowCountChanged)
            {
                if (_rowCount < 1)
                {
                    _rowCount = defaultRowCount;
                }
                if (!isNaN(explicitHeight) && isNaN(explicitRowHeight) && explicitRowCount > 0)
                {
                    setRowHeight((explicitHeight - viewMetrics.top - viewMetrics.bottom) / rowCount);
                }
                rowCountChanged = false;
            }
            if (offscreenExtraRowsOrColumnsChanged)
            {
                adjustOffscreenRowsAndColumns();
                if (iterator)
                {
                    _loc_1 = Math.min(offscreenExtraColumns / 2, horizontalScrollPosition);
                    _loc_2 = Math.min(offscreenExtraRows / 2, verticalScrollPosition);
                    _loc_3 = scrollPositionToIndex(horizontalScrollPosition - _loc_1, verticalScrollPosition - _loc_2);
                    seekPositionSafely(_loc_3);
                    invalidateList();
                }
                offscreenExtraRowsOrColumnsChanged = false;
            }
            return;
        }// end function

        protected function setRowCount(param1:int) : void
        {
            _rowCount = param1;
            return;
        }// end function

        public function set labelFunction(param1:Function) : void
        {
            _labelFunction = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("labelFunctionChanged"));
            return;
        }// end function

        protected function adjustAfterAdd(param1:Array, param2:int) : Boolean
        {
            var length:int;
            var requiresValueCommit:Boolean;
            var data:ListBaseSelectionData;
            var placeHolder:CursorBookmark;
            var p:String;
            var items:* = param1;
            var location:* = param2;
            length = items.length;
            requiresValueCommit;
            var _loc_4:int = 0;
            var _loc_5:* = selectedData;
            while (_loc_5 in _loc_4)
            {
                
                p = _loc_5[_loc_4];
                data = selectedData[p];
                if (data.index >= location)
                {
                    data.index = data.index + length;
                }
            }
            if (_selectedIndex >= location)
            {
                _selectedIndex = _selectedIndex + length;
                requiresValueCommit;
            }
            if (anchorIndex >= location)
            {
                anchorIndex = anchorIndex + length;
                placeHolder = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.FIRST, anchorIndex);
                    anchorBookmark = iterator.bookmark;
                }
                catch (e:ItemPendingError)
                {
                    e.addResponder(new ItemResponder(setBookmarkPendingResultHandler, setBookmarkPendingFailureHandler, {property:"anchorBookmark", value:anchorIndex}));
                }
                iterator.seek(placeHolder);
            }
            if (caretIndex >= location)
            {
                caretIndex = caretIndex + length;
                placeHolder = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.FIRST, caretIndex);
                    caretBookmark = iterator.bookmark;
                }
                catch (e:ItemPendingError)
                {
                    e.addResponder(new ItemResponder(setBookmarkPendingResultHandler, setBookmarkPendingFailureHandler, {property:"caretBookmark", value:caretIndex}));
                }
                iterator.seek(placeHolder);
            }
            return requiresValueCommit;
        }// end function

        private function mouseLeaveHandler(event:Event) : void
        {
            var _loc_2:ListEvent = null;
            var _loc_3:Point = null;
            mouseDownPoint = null;
            mouseIsUp();
            if (!enabled || !selectable)
            {
                return;
            }
            if (mouseDownItem)
            {
                _loc_2 = new ListEvent(ListEvent.CHANGE);
                _loc_2.itemRenderer = mouseDownItem;
                _loc_3 = itemRendererToIndices(mouseDownItem);
                if (_loc_3)
                {
                    _loc_2.columnIndex = _loc_3.x;
                    _loc_2.rowIndex = _loc_3.y;
                }
                dispatchEvent(_loc_2);
                mouseDownItem = null;
            }
            isPressed = false;
            return;
        }// end function

        public function unconstrainRenderer(param1:Object) : void
        {
            unconstrainedRenderers[param1] = true;
            return;
        }// end function

        function getIterator() : IViewCursor
        {
            return iterator;
        }// end function

        public function get selectedItems() : Array
        {
            return bSelectedItemsChanged ? (_selectedItems) : (copySelectedItems());
        }// end function

        protected function findKey(param1:int) : Boolean
        {
            var _loc_2:* = param1;
            return _loc_2 >= 33 && _loc_2 <= 126 && findString(String.fromCharCode(_loc_2));
        }// end function

        override public function set verticalScrollPolicy(param1:String) : void
        {
            super.verticalScrollPolicy = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        public function set selectedIndex(param1:int) : void
        {
            if (!collection || collection.length == 0)
            {
                _selectedIndex = param1;
                bSelectionChanged = true;
                bSelectedIndexChanged = true;
                invalidateDisplayList();
                return;
            }
            commitSelectedIndex(param1);
            return;
        }// end function

        public function set itemRenderer(param1:IFactory) : void
        {
            _itemRenderer = param1;
            invalidateSize();
            invalidateDisplayList();
            itemsSizeChanged = true;
            rendererChanged = true;
            dispatchEvent(new Event("itemRendererChanged"));
            return;
        }// end function

        public function hideDropFeedback(event:DragEvent) : void
        {
            if (dropIndicator)
            {
                DisplayObject(dropIndicator).parent.removeChild(DisplayObject(dropIndicator));
                dropIndicator = null;
                drawFocus(false);
            }
            return;
        }// end function

        private function commitSelectedItems(param1:Array) : void
        {
            var useFind:Boolean;
            var uid:String;
            var items:* = param1;
            clearSelected();
            items = items.slice();
            useFind = collection.sort != null;
            try
            {
                collectionIterator.seek(CursorBookmark.FIRST, 0);
            }
            catch (e:ItemPendingError)
            {
                e.addResponder(new ItemResponder(selectionDataPendingResultHandler, selectionDataPendingFailureHandler, new ListBaseSelectionDataPending(useFind, 0, items, null, 0)));
                return;
            }
            var n:* = items.length;
            selectionDataArray = new Array(n);
            firstSelectedItem = n ? (items[0]) : (null);
            proposedSelectedItemIndexes = new Dictionary();
            var i:int;
            while (i < n)
            {
                
                uid = itemToUID(items[i]);
                proposedSelectedItemIndexes[uid] = i;
                i = (i + 1);
            }
            setSelectionDataLoop(items, 0, useFind);
            return;
        }// end function

        public function set dataTipField(param1:String) : void
        {
            _dataTipField = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("dataTipFieldChanged"));
            return;
        }// end function

        private function makeRowsAndColumnsWithExtraColumns(param1:Number, param2:Number) : void
        {
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_3:* = offscreenExtraColumns / 2;
            var _loc_4:* = offscreenExtraColumns / 2;
            if (horizontalScrollPosition > collection.length - columnCount)
            {
                super.horizontalScrollPosition = Math.max(0, collection.length - columnCount);
            }
            offscreenExtraColumnsLeft = Math.min(_loc_3, horizontalScrollPosition);
            var _loc_5:* = scrollPositionToIndex(horizontalScrollPosition - offscreenExtraColumnsLeft, verticalScrollPosition);
            seekPositionSafely(_loc_5);
            var _loc_6:* = iterator.bookmark;
            if (offscreenExtraColumnsLeft > 0)
            {
                makeRowsAndColumns(0, 0, 0, listContent.height, 0, 0, true, offscreenExtraColumnsLeft);
            }
            var _loc_7:* = offscreenExtraColumnsLeft ? (listItems[0][(offscreenExtraColumnsLeft - 1)].x + columnWidth) : (0);
            var _loc_8:* = makeRowsAndColumns(_loc_7, 0, _loc_7 + listContent.widthExcludingOffsets, listContent.height, offscreenExtraColumnsLeft, 0);
            if (_loc_4 > 0 && !iterator.afterLast)
            {
                if (offscreenExtraColumnsLeft + _loc_8.x - 1 < 0)
                {
                    _loc_7 = 0;
                }
                else
                {
                    _loc_7 = listItems[0][offscreenExtraColumnsLeft + _loc_8.x - 1].x + columnWidth;
                }
                _loc_10 = listItems[0].length;
                _loc_8 = makeRowsAndColumns(_loc_7, 0, _loc_7, listContent.height, offscreenExtraColumnsLeft + _loc_8.x, 0, true, _loc_4);
                if (_loc_8.x < _loc_4)
                {
                    _loc_11 = listItems[0].length - (_loc_10 + _loc_8.x);
                    if (_loc_11)
                    {
                        _loc_12 = 0;
                        while (_loc_12 < listItems.length)
                        {
                            
                            _loc_13 = 0;
                            while (_loc_13 < _loc_11)
                            {
                                
                                listItems[_loc_12].pop();
                                _loc_13++;
                            }
                            _loc_12++;
                        }
                    }
                }
                offscreenExtraColumnsRight = _loc_8.x;
            }
            else
            {
                offscreenExtraColumnsRight = 0;
            }
            var _loc_9:* = listContent.widthExcludingOffsets;
            listContent.leftOffset = (-offscreenExtraColumnsLeft) * columnWidth;
            listContent.rightOffset = offscreenExtraColumnsRight > 0 ? (listItems[0][(listItems[0].length - 1)].x + columnWidth - _loc_9 + listContent.leftOffset) : (0);
            iterator.seek(_loc_6, 0);
            adjustListContent(param1, param2);
            return;
        }// end function

        protected function dragOverHandler(event:DragEvent) : void
        {
            if (event.isDefaultPrevented())
            {
                return;
            }
            lastDragEvent = event;
            if (enabled && iteratorValid && event.dragSource.hasFormat("items"))
            {
                DragManager.showFeedback(event.ctrlKey ? (DragManager.COPY) : (DragManager.MOVE));
                showDropFeedback(event);
                return;
            }
            hideDropFeedback(event);
            DragManager.showFeedback(DragManager.NONE);
            return;
        }// end function

        private function adjustSelectionSettings(param1:Boolean) : void
        {
            if (bSelectionChanged)
            {
                bSelectionChanged = false;
                if (bSelectedIndicesChanged && (param1 || _selectedIndices == null))
                {
                    bSelectedIndicesChanged = false;
                    bSelectedIndexChanged = false;
                    commitSelectedIndices(_selectedIndices);
                }
                if (bSelectedItemChanged && (param1 || _selectedItem == null))
                {
                    bSelectedItemChanged = false;
                    bSelectedIndexChanged = false;
                    commitSelectedItem(_selectedItem);
                }
                if (bSelectedItemsChanged && (param1 || _selectedItems == null))
                {
                    bSelectedItemsChanged = false;
                    bSelectedIndexChanged = false;
                    commitSelectedItems(_selectedItems);
                }
                if (bSelectedIndexChanged && (param1 || _selectedIndex == -1))
                {
                    commitSelectedIndex(_selectedIndex);
                    bSelectedIndexChanged = false;
                }
            }
            return;
        }// end function

        private function clearSelectionData() : void
        {
            selectedData = {};
            firstSelectionData = null;
            lastSelectionData = null;
            return;
        }// end function

        protected function shiftRow(param1:int, param2:int, param3:int, param4:Boolean) : void
        {
            var _loc_5:IListItemRenderer = null;
            var _loc_6:int = 0;
            while (_loc_6 < param3)
            {
                
                _loc_5 = listItems[param1][_loc_6];
                if (param4)
                {
                    listItems[param2][_loc_6] = _loc_5;
                    rowMap[_loc_5.name].rowIndex = param2;
                }
                else
                {
                    rowMap[_loc_5.name].rowIndex = param1;
                }
                _loc_6++;
            }
            if (param4)
            {
                rowInfo[param2] = rowInfo[param1];
            }
            return;
        }// end function

        function selectionTween_endHandler(event:TweenEvent) : void
        {
            selectionTween_updateHandler(event);
            return;
        }// end function

        function resetDragScrolling() : void
        {
            if (dragScrollingInterval != 0)
            {
                clearInterval(dragScrollingInterval);
                dragScrollingInterval = 0;
            }
            return;
        }// end function

        protected function mouseOverHandler(event:MouseEvent) : void
        {
            var _loc_2:ListEvent = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Point = null;
            var _loc_5:String = null;
            var _loc_6:String = null;
            var _loc_7:BaseListData = null;
            if (!enabled || !selectable)
            {
                return;
            }
            if (dragScrollingInterval != 0 && !event.buttonDown)
            {
                mouseIsUp();
            }
            isPressed = event.buttonDown;
            _loc_3 = mouseEventToItemRenderer(event);
            _loc_4 = itemRendererToIndices(_loc_3);
            if (!_loc_3)
            {
                return;
            }
            _loc_5 = itemToUID(_loc_3.data);
            if (!isPressed || allowDragSelection)
            {
                if (event.relatedObject)
                {
                    if (lastHighlightItemRenderer && highlightUID)
                    {
                        _loc_7 = rowMap[_loc_3.name];
                        _loc_6 = _loc_7.uid;
                    }
                    if (itemRendererContains(_loc_3, event.relatedObject) || _loc_5 == _loc_6 || event.relatedObject == highlightIndicator)
                    {
                        return;
                    }
                }
                if (getStyle("useRollOver") && _loc_3.data != null)
                {
                    if (allowDragSelection)
                    {
                        bSelectOnRelease = true;
                    }
                    drawItem(UIDToItemRenderer(_loc_5), isItemSelected(_loc_3.data), true, _loc_5 == caretUID);
                    if (_loc_4)
                    {
                        _loc_2 = new ListEvent(ListEvent.ITEM_ROLL_OVER);
                        _loc_2.columnIndex = _loc_4.x;
                        _loc_2.rowIndex = _loc_4.y;
                        _loc_2.itemRenderer = _loc_3;
                        dispatchEvent(_loc_2);
                        lastHighlightItemIndices = _loc_4;
                        lastHighlightItemRendererAtIndices = _loc_3;
                    }
                }
            }
            else
            {
                if (DragManager.isDragging)
                {
                    return;
                }
                if (dragScrollingInterval != 0 && allowDragSelection || menuSelectionMode)
                {
                    if (selectItem(_loc_3, event.shiftKey, event.ctrlKey))
                    {
                        _loc_2 = new ListEvent(ListEvent.CHANGE);
                        _loc_2.itemRenderer = _loc_3;
                        if (_loc_4)
                        {
                            _loc_2.columnIndex = _loc_4.x;
                            _loc_2.rowIndex = _loc_4.y;
                        }
                        dispatchEvent(_loc_2);
                    }
                }
            }
            return;
        }// end function

        protected function mouseClickHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            var _loc_4:ListEvent = null;
            _loc_2 = mouseEventToItemRenderer(event);
            if (!_loc_2)
            {
                return;
            }
            _loc_3 = itemRendererToIndices(_loc_2);
            if (_loc_3)
            {
                _loc_4 = new ListEvent(ListEvent.ITEM_CLICK);
                _loc_4.columnIndex = _loc_3.x;
                _loc_4.rowIndex = _loc_3.y;
                _loc_4.itemRenderer = _loc_2;
                dispatchEvent(_loc_4);
            }
            return;
        }// end function

        private function selectionIndicesPendingFailureHandler(param1:Object, param2:ListBaseSelectionDataPending) : void
        {
            return;
        }// end function

        protected function finishKeySelection() : void
        {
            var _loc_1:String = null;
            var _loc_5:IListItemRenderer = null;
            var _loc_7:Point = null;
            var _loc_8:ListEvent = null;
            var _loc_2:* = listItems.length;
            var _loc_3:* = listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom;
            var _loc_4:* = rowInfo[_loc_2 - offscreenExtraRowsBottom - 1].y + rowInfo[_loc_2 - offscreenExtraRowsBottom - 1].height > listContent.heightExcludingOffsets - listContent.topOffset ? (1) : (0);
            if (lastKey == Keyboard.PAGE_DOWN)
            {
                if (_loc_3 - _loc_4 == 0)
                {
                    caretIndex = Math.min(verticalScrollPosition + _loc_3 - _loc_4, (collection.length - 1));
                }
                else
                {
                    caretIndex = Math.min(verticalScrollPosition + _loc_3 - _loc_4 - 1, (collection.length - 1));
                }
            }
            var _loc_6:Boolean = false;
            if (bSelectItem && caretIndex - verticalScrollPosition >= 0)
            {
                if (caretIndex - verticalScrollPosition > Math.max(_loc_3 - _loc_4 - 1, 0))
                {
                    if (lastKey == Keyboard.END && maxVerticalScrollPosition > verticalScrollPosition)
                    {
                        (caretIndex - 1);
                        moveSelectionVertically(lastKey, bShiftKey, bCtrlKey);
                        return;
                    }
                    caretIndex = _loc_3 - _loc_4 - 1 + verticalScrollPosition;
                }
                _loc_5 = listItems[caretIndex - verticalScrollPosition + offscreenExtraRowsTop][0];
                if (_loc_5)
                {
                    _loc_1 = itemToUID(_loc_5.data);
                    _loc_5 = UIDToItemRenderer(_loc_1);
                    if (!bCtrlKey || lastKey == Keyboard.SPACE)
                    {
                        selectItem(_loc_5, bShiftKey, bCtrlKey);
                        _loc_6 = true;
                    }
                    if (bCtrlKey)
                    {
                        drawItem(_loc_5, selectedData[_loc_1] != null, _loc_1 == highlightUID, true);
                    }
                }
            }
            if (_loc_6)
            {
                _loc_7 = itemRendererToIndices(_loc_5);
                _loc_8 = new ListEvent(ListEvent.CHANGE);
                if (_loc_7)
                {
                    _loc_8.columnIndex = _loc_7.x;
                    _loc_8.rowIndex = _loc_7.y;
                }
                _loc_8.itemRenderer = _loc_5;
                dispatchEvent(_loc_8);
            }
            return;
        }// end function

        private function selectionDataPendingFailureHandler(param1:Object, param2:ListBaseSelectionDataPending) : void
        {
            return;
        }// end function

        function addClipMask(param1:Boolean) : void
        {
            var _loc_10:DisplayObject = null;
            var _loc_11:Number = NaN;
            if (param1)
            {
                if (horizontalScrollBar && horizontalScrollBar.visible || hasOnlyTextRenderers() || runningDataEffect || listContent.bottomOffset != 0 || listContent.topOffset != 0 || listContent.leftOffset != 0 || listContent.rightOffset != 0)
                {
                    listContent.mask = maskShape;
                    selectionLayer.mask = null;
                }
                else
                {
                    listContent.mask = null;
                    selectionLayer.mask = maskShape;
                }
            }
            if (listContent.mask)
            {
                return;
            }
            var _loc_2:* = listItems.length - 1;
            var _loc_3:* = rowInfo[_loc_2];
            var _loc_4:* = listItems[_loc_2];
            if (_loc_3.y + _loc_3.height <= listContent.height)
            {
                return;
            }
            var _loc_5:* = _loc_4.length;
            var _loc_6:* = _loc_3.y;
            var _loc_7:* = listContent.width;
            var _loc_8:* = listContent.height - _loc_3.y;
            var _loc_9:int = 0;
            while (_loc_9 < _loc_5)
            {
                
                _loc_10 = _loc_4[_loc_9];
                _loc_11 = _loc_10.y - _loc_6;
                if (_loc_10 is IUITextField)
                {
                    _loc_10.height = _loc_8 - _loc_11;
                }
                else
                {
                    _loc_10.mask = createItemMask(0, _loc_6 + _loc_11, _loc_7, _loc_8 - _loc_11);
                }
                _loc_9++;
            }
            return;
        }// end function

        public function set allowMultipleSelection(param1:Boolean) : void
        {
            _allowMultipleSelection = param1;
            return;
        }// end function

        protected function scrollVertically(param1:int, param2:int, param3:Boolean) : void
        {
            var i:int;
            var j:int;
            var numRows:int;
            var numCols:int;
            var uid:String;
            var curY:Number;
            var cursorPos:CursorBookmark;
            var discardRows:int;
            var desiredoffscreenExtraRowsTop:int;
            var newoffscreenExtraRowsTop:int;
            var offscreenExtraRowsBottomToMake:int;
            var newTopOffset:Number;
            var fillHeight:Number;
            var pt:Point;
            var rowIdx:int;
            var modDeltaPos:int;
            var desiredPrefixItems:int;
            var actual:Point;
            var row:Array;
            var rowData:Object;
            var desiredSuffixItems:int;
            var newOffscreenRows:int;
            var visibleAreaBottomY:int;
            var pos:* = param1;
            var deltaPos:* = param2;
            var scrollUp:* = param3;
            var rowCount:* = rowInfo.length;
            var columnCount:* = listItems[0].length;
            var moveBlockDistance:Number;
            var listContentVisibleHeight:* = listContent.heightExcludingOffsets;
            if (scrollUp)
            {
                discardRows = deltaPos;
                desiredoffscreenExtraRowsTop = offscreenExtraRows / 2;
                newoffscreenExtraRowsTop = Math.min(desiredoffscreenExtraRowsTop, offscreenExtraRowsTop + deltaPos);
                if (offscreenExtraRowsTop < desiredoffscreenExtraRowsTop)
                {
                    discardRows = Math.max(0, deltaPos - (desiredoffscreenExtraRowsTop - offscreenExtraRowsTop));
                }
                moveBlockDistance = sumRowHeights(0, (discardRows - 1));
                i;
                while (i < discardRows)
                {
                    
                    if (!seekNextSafely(iterator, pos))
                    {
                        return;
                    }
                    i = (i + 1);
                }
                i;
                while (i < rowCount)
                {
                    
                    numCols = listItems[i].length;
                    if (i < discardRows)
                    {
                        destroyRow(i, numCols);
                    }
                    else if (discardRows > 0)
                    {
                        moveRowVertically(i, numCols, -moveBlockDistance);
                        moveIndicatorsVertically(rowInfo[i].uid, -moveBlockDistance);
                        shiftRow(i, i - discardRows, numCols, true);
                        if (listItems[i].length == 0)
                        {
                            listItems[i - discardRows].splice(0);
                        }
                    }
                    i = (i + 1);
                }
                if (discardRows)
                {
                    truncateRowArrays(rowCount - discardRows);
                }
                curY = rowInfo[rowCount - discardRows - 1].y + rowInfo[rowCount - discardRows - 1].height;
                cursorPos = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.CURRENT, rowCount - discardRows);
                    if (!iteratorValid)
                    {
                        iteratorValid = true;
                        lastSeekPending = null;
                    }
                }
                catch (e1:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(cursorPos, 0);
                    e1.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    iteratorValid = false;
                }
                offscreenExtraRowsBottomToMake = offscreenExtraRows / 2;
                newTopOffset;
                i;
                while (i < newoffscreenExtraRowsTop)
                {
                    
                    newTopOffset = newTopOffset - rowInfo[i].height;
                    i = (i + 1);
                }
                fillHeight = listContentVisibleHeight - (curY + newTopOffset);
                if (fillHeight > 0)
                {
                    pt = makeRowsAndColumns(0, curY, listContent.width, curY + fillHeight, 0, rowCount - discardRows);
                    rowCount = rowCount + pt.y;
                }
                else
                {
                    rowIdx = rowCount - discardRows - 1;
                    rowIdx = (rowIdx - 1);
                    fillHeight = fillHeight + rowInfo[rowIdx].height;
                    while (fillHeight < 0)
                    {
                        
                        offscreenExtraRowsBottomToMake = (offscreenExtraRowsBottomToMake - 1);
                        rowIdx = (rowIdx - 1);
                        fillHeight = fillHeight + rowInfo[rowIdx].height;
                    }
                }
                if (offscreenExtraRowsBottomToMake > 0)
                {
                    if (pt)
                    {
                        curY = rowInfo[rowCount - discardRows - 1].y + rowInfo[rowCount - discardRows - 1].height;
                    }
                    pt = makeRowsAndColumns(0, curY, listContent.width, listContent.height, 0, rowCount - discardRows, true, offscreenExtraRowsBottomToMake);
                }
                else
                {
                    pt = new Point(0, 0);
                }
                try
                {
                    iterator.seek(cursorPos, 0);
                }
                catch (e2:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(cursorPos, 0);
                    e2.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    iteratorValid = false;
                }
                offscreenExtraRowsTop = newoffscreenExtraRowsTop;
                offscreenExtraRowsBottom = offscreenExtraRows / 2 - offscreenExtraRowsBottomToMake + pt.y;
            }
            else
            {
                curY;
                modDeltaPos = deltaPos;
                desiredPrefixItems = offscreenExtraRows / 2;
                if (pos < desiredPrefixItems)
                {
                    modDeltaPos = modDeltaPos - (desiredPrefixItems - pos);
                }
                i;
                while (i < modDeltaPos)
                {
                    
                    addToRowArrays();
                    i = (i + 1);
                }
                actual = new Point(0, 0);
                if (modDeltaPos > 0)
                {
                    try
                    {
                        iterator.seek(CursorBookmark.CURRENT, -modDeltaPos);
                        if (!iteratorValid)
                        {
                            iteratorValid = true;
                            lastSeekPending = null;
                        }
                    }
                    catch (e3:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(CursorBookmark.CURRENT, -modDeltaPos);
                        e3.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                    }
                    cursorPos = iterator.bookmark;
                    allowRendererStealingDuringLayout = false;
                    actual = makeRowsAndColumns(0, curY, listContent.width, listContent.height, 0, 0, true, modDeltaPos);
                    allowRendererStealingDuringLayout = true;
                    try
                    {
                        iterator.seek(cursorPos, 0);
                    }
                    catch (e4:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(cursorPos, 0);
                        e4.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                    }
                }
                if (actual.y == 0 && modDeltaPos > 0)
                {
                    verticalScrollPosition = 0;
                    restoreRowArrays(modDeltaPos);
                }
                moveBlockDistance = sumRowHeights(0, (actual.y - 1));
                desiredSuffixItems = offscreenExtraRows / 2;
                newOffscreenRows;
                visibleAreaBottomY = listContentVisibleHeight + sumRowHeights(0, (Math.min(desiredPrefixItems, pos) - 1));
                i = actual.y;
                while (i < listItems.length)
                {
                    
                    row = listItems[i];
                    rowData = rowInfo[i];
                    moveRowVertically(i, listItems[i].length, moveBlockDistance);
                    if (rowData.y >= visibleAreaBottomY)
                    {
                        newOffscreenRows = (newOffscreenRows + 1);
                        if (newOffscreenRows > desiredSuffixItems)
                        {
                            destroyRow(i, listItems[i].length);
                            removeFromRowArrays(i);
                            i = (i - 1);
                        }
                        else
                        {
                            shiftRow(i, i + deltaPos, listItems[i].length, false);
                            moveIndicatorsVertically(rowInfo[i].uid, moveBlockDistance);
                        }
                    }
                    else
                    {
                        shiftRow(i, i + deltaPos, listItems[i].length, false);
                        moveIndicatorsVertically(rowInfo[i].uid, moveBlockDistance);
                    }
                    i = (i + 1);
                }
                rowCount = listItems.length;
                offscreenExtraRowsTop = Math.min(desiredPrefixItems, pos);
                offscreenExtraRowsBottom = Math.min(newOffscreenRows, desiredSuffixItems);
            }
            listContent.topOffset = -sumRowHeights(0, (offscreenExtraRowsTop - 1));
            listContent.bottomOffset = rowInfo[(rowInfo.length - 1)].y + rowInfo[(rowInfo.length - 1)].height + listContent.topOffset - listContentVisibleHeight;
            adjustListContent(oldUnscaledWidth, oldUnscaledHeight);
            addClipMask(true);
            return;
        }// end function

        protected function selectItem(param1:IListItemRenderer, param2:Boolean, param3:Boolean, param4:Boolean = true) : Boolean
        {
            var placeHolder:CursorBookmark;
            var index:int;
            var numSelected:int;
            var curSelectionData:ListBaseSelectionData;
            var oldAnchorBookmark:CursorBookmark;
            var oldAnchorIndex:int;
            var incr:Boolean;
            var item:* = param1;
            var shiftKey:* = param2;
            var ctrlKey:* = param3;
            var transition:* = param4;
            if (!item || !isItemSelectable(item.data))
            {
                return false;
            }
            var selectionChange:Boolean;
            placeHolder = iterator.bookmark;
            index = itemRendererToIndex(item);
            var uid:* = itemToUID(item.data);
            if (!allowMultipleSelection || !shiftKey && !ctrlKey)
            {
                numSelected;
                if (allowMultipleSelection)
                {
                    curSelectionData = firstSelectionData;
                    if (curSelectionData != null)
                    {
                        numSelected = (numSelected + 1);
                        if (curSelectionData.nextSelectionData)
                        {
                            numSelected = (numSelected + 1);
                        }
                    }
                }
                if (ctrlKey && selectedData[uid])
                {
                    selectionChange;
                    clearSelected(transition);
                }
                else if (_selectedIndex != index || bSelectedIndexChanged || allowMultipleSelection && numSelected != 1)
                {
                    selectionChange;
                    clearSelected(transition);
                    insertSelectionDataBefore(uid, new ListBaseSelectionData(item.data, index, approximate), firstSelectionData);
                    drawItem(UIDToItemRenderer(uid), true, uid == highlightUID, true, transition);
                    _selectedIndex = index;
                    _selectedItem = item.data;
                    iterator.seek(CursorBookmark.CURRENT, _selectedIndex - indicesToIndex(verticalScrollPosition - offscreenExtraRowsTop, horizontalScrollPosition - offscreenExtraColumnsLeft));
                    caretIndex = _selectedIndex;
                    caretBookmark = iterator.bookmark;
                    anchorIndex = _selectedIndex;
                    anchorBookmark = iterator.bookmark;
                    iterator.seek(placeHolder, 0);
                }
            }
            else if (shiftKey && allowMultipleSelection)
            {
                if (anchorBookmark)
                {
                    oldAnchorBookmark = anchorBookmark;
                    oldAnchorIndex = anchorIndex;
                    incr = anchorIndex < index;
                    clearSelected(false);
                    caretIndex = index;
                    caretBookmark = iterator.bookmark;
                    anchorIndex = oldAnchorIndex;
                    anchorBookmark = oldAnchorBookmark;
                    _selectedIndex = index;
                    _selectedItem = item.data;
                    try
                    {
                        iterator.seek(anchorBookmark, 0);
                    }
                    catch (e:ItemPendingError)
                    {
                        e.addResponder(new ItemResponder(selectionPendingResultHandler, selectionPendingFailureHandler, new ListBaseSelectionPending(incr, index, item.data, transition, placeHolder, CursorBookmark.CURRENT, 0)));
                        iteratorValid = false;
                    }
                    shiftSelectionLoop(incr, anchorIndex, item.data, transition, placeHolder);
                }
                selectionChange;
            }
            else if (ctrlKey && allowMultipleSelection)
            {
                if (selectedData[uid])
                {
                    removeSelectionData(uid);
                    drawItem(UIDToItemRenderer(uid), false, uid == highlightUID, true, transition);
                    if (item.data == selectedItem)
                    {
                        calculateSelectedIndexAndItem();
                    }
                }
                else
                {
                    insertSelectionDataBefore(uid, new ListBaseSelectionData(item.data, index, approximate), firstSelectionData);
                    drawItem(UIDToItemRenderer(uid), true, uid == highlightUID, true, transition);
                    _selectedIndex = index;
                    _selectedItem = item.data;
                }
                iterator.seek(CursorBookmark.CURRENT, index - indicesToIndex(verticalScrollPosition, horizontalScrollPosition));
                caretIndex = index;
                caretBookmark = iterator.bookmark;
                anchorIndex = index;
                anchorBookmark = iterator.bookmark;
                iterator.seek(placeHolder, 0);
                selectionChange;
            }
            return selectionChange;
        }// end function

        function selectionTween_updateHandler(event:TweenEvent) : void
        {
            Sprite(event.target.listener).alpha = Number(event.value);
            return;
        }// end function

        protected function prepareDataEffect(event:CollectionEvent) : void
        {
            var _loc_2:Object = null;
            var _loc_3:Class = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (!cachedItemsChangeEffect)
            {
                _loc_2 = getStyle("itemsChangeEffect");
                _loc_3 = _loc_2 as Class;
                if (_loc_3)
                {
                    _loc_2 = new _loc_3;
                }
                cachedItemsChangeEffect = _loc_2 as IEffect;
            }
            if (runningDataEffect)
            {
                collection = actualCollection;
                var _loc_6:* = actualIterator;
                iterator = actualIterator;
                listContent.iterator = _loc_6;
                cachedItemsChangeEffect.end();
                modifiedCollectionView = null;
            }
            if (cachedItemsChangeEffect && iteratorValid)
            {
                _loc_4 = iterator.bookmark.getViewIndex();
                _loc_5 = _loc_4 + rowCount * columnCount - 1;
                if (!modifiedCollectionView && collection is IList)
                {
                    modifiedCollectionView = new ModifiedCollectionView(ICollectionView(collection));
                }
                if (modifiedCollectionView)
                {
                    modifiedCollectionView.processCollectionEvent(event, _loc_4, _loc_5);
                    runDataEffectNextUpdate = true;
                    if (invalidateDisplayListFlag)
                    {
                        callLater(invalidateList);
                    }
                    else
                    {
                        invalidateList();
                    }
                }
            }
            return;
        }// end function

        protected function drawSelectionIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:* = Sprite(param1).graphics;
            Sprite(param1).graphics.clear();
            _loc_8.beginFill(param6);
            _loc_8.drawRect(0, 0, param4, param5);
            _loc_8.endFill();
            param1.x = param2;
            param1.y = param3;
            return;
        }// end function

        function setColumnWidth(param1:Number) : void
        {
            _columnWidth = param1;
            return;
        }// end function

        protected function makeRowsAndColumns(param1:Number, param2:Number, param3:Number, param4:Number, param5:int, param6:int, param7:Boolean = false, param8:uint = 0) : Point
        {
            return new Point(0, 0);
        }// end function

        public function isItemVisible(param1:Object) : Boolean
        {
            return itemToItemRenderer(param1) != null;
        }// end function

        function commitSelectedIndices(param1:Array) : void
        {
            var indices:* = param1;
            clearSelected();
            try
            {
                collectionIterator.seek(CursorBookmark.FIRST, 0);
            }
            catch (e:ItemPendingError)
            {
                e.addResponder(new ItemResponder(selectionIndicesPendingResultHandler, selectionIndicesPendingFailureHandler, new ListBaseSelectionDataPending(true, 0, indices, CursorBookmark.FIRST, 0)));
                return;
            }
            setSelectionIndicesLoop(0, indices, true);
            return;
        }// end function

        public function calculateDropIndex(event:DragEvent = null) : int
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Point = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (event)
            {
                _loc_4 = new Point(event.localX, event.localY);
                _loc_4 = DisplayObject(event.target).localToGlobal(_loc_4);
                _loc_4 = listContent.globalToLocal(_loc_4);
                _loc_5 = listItems.length;
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    if (listItems[_loc_6][0])
                    {
                        _loc_3 = listItems[_loc_6][0];
                    }
                    if (rowInfo[_loc_6].y <= _loc_4.y && _loc_4.y < rowInfo[_loc_6].y + rowInfo[_loc_6].height)
                    {
                        _loc_2 = listItems[_loc_6][0];
                        break;
                    }
                    _loc_6++;
                }
                if (_loc_2)
                {
                    lastDropIndex = itemRendererToIndex(_loc_2);
                }
                else if (_loc_3)
                {
                    lastDropIndex = itemRendererToIndex(_loc_3) + 1;
                }
                else
                {
                    lastDropIndex = collection ? (collection.length) : (0);
                }
            }
            return lastDropIndex;
        }// end function

        protected function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            if (!enabled || !selectable)
            {
                return;
            }
            if (runningDataEffect)
            {
                cachedItemsChangeEffect.end();
                dataEffectCompleted = true;
                itemsSizeChanged = true;
                invalidateList();
                dataItemWrappersByRenderer = new Dictionary();
                validateDisplayList();
            }
            isPressed = true;
            _loc_2 = mouseEventToItemRenderer(event);
            if (!_loc_2)
            {
                return;
            }
            bSelectOnRelease = false;
            _loc_3 = new Point(event.localX, event.localY);
            _loc_3 = DisplayObject(event.target).localToGlobal(_loc_3);
            mouseDownPoint = globalToLocal(_loc_3);
            systemManager.getSandboxRoot().addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true, 0, true);
            systemManager.getSandboxRoot().addEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, mouseLeaveHandler, false, 0, true);
            if (!dragEnabled)
            {
                dragScrollingInterval = setInterval(dragScroll, 15);
            }
            if (dragEnabled && selectedData[rowMap[_loc_2.name].uid])
            {
                bSelectOnRelease = true;
            }
            else if (selectItem(_loc_2, event.shiftKey, event.ctrlKey))
            {
                mouseDownItem = _loc_2;
            }
            return;
        }// end function

        public function get labelField() : String
        {
            return _labelField;
        }// end function

        private function onSelectionTweenUpdate(param1:Number) : void
        {
            return;
        }// end function

        public function set selectedItemsCompareFunction(param1:Function) : void
        {
            _selectedItemsCompareFunction = param1;
            dispatchEvent(new Event("selectedItemsCompareFunctionChanged"));
            return;
        }// end function

        protected function clearIndicators() : void
        {
            var _loc_1:String = null;
            for (_loc_1 in selectionTweens)
            {
                
                removeIndicators(_loc_1);
            }
            while (selectionLayer.numChildren > 0)
            {
                
                selectionLayer.removeChildAt(0);
            }
            selectionTweens = {};
            selectionIndicators = {};
            highlightIndicator = null;
            highlightUID = null;
            caretIndicator = null;
            caretUID = null;
            return;
        }// end function

        public function get offscreenExtraRowsOrColumns() : int
        {
            return _offscreenExtraRowsOrColumns;
        }// end function

        public function get wordWrap() : Boolean
        {
            return _wordWrap;
        }// end function

        protected function drawItem(param1:IListItemRenderer, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:Boolean = false) : void
        {
            var _loc_6:Sprite = null;
            var _loc_7:Graphics = null;
            var _loc_12:Number = NaN;
            if (!param1)
            {
                return;
            }
            var _loc_8:* = DisplayObject(param1).parent as ListBaseContentHolder;
            if (!(DisplayObject(param1).parent as ListBaseContentHolder))
            {
                return;
            }
            var _loc_9:* = _loc_8.rowInfo;
            var _loc_10:* = _loc_8.selectionLayer;
            var _loc_11:* = rowMap[param1.name];
            if (!rowMap[param1.name])
            {
                return;
            }
            if (param3 && (!highlightItemRenderer || highlightUID != _loc_11.uid))
            {
                if (!highlightIndicator)
                {
                    _loc_6 = new SpriteAsset();
                    _loc_10.addChild(DisplayObject(_loc_6));
                    highlightIndicator = _loc_6;
                }
                else if (highlightIndicator.parent != _loc_10)
                {
                    _loc_10.addChild(highlightIndicator);
                }
                else
                {
                    _loc_10.setChildIndex(DisplayObject(highlightIndicator), (_loc_10.numChildren - 1));
                }
                _loc_6 = highlightIndicator;
                drawHighlightIndicator(_loc_6, param1.x, _loc_9[_loc_11.rowIndex].y, param1.width, _loc_9[_loc_11.rowIndex].height, getStyle("rollOverColor"), param1);
                var _loc_13:* = param1;
                highlightItemRenderer = param1;
                lastHighlightItemRenderer = _loc_13;
                highlightUID = _loc_11.uid;
            }
            else if (!param3 && highlightItemRenderer && (_loc_11 && highlightUID == _loc_11.uid))
            {
                clearHighlightIndicator(highlightIndicator, param1);
                highlightItemRenderer = null;
                highlightUID = null;
            }
            if (param2)
            {
                _loc_12 = runningDataEffect ? (param1.y - cachedPaddingTop) : (_loc_9[_loc_11.rowIndex].y);
                if (!selectionIndicators[_loc_11.uid])
                {
                    _loc_6 = new SpriteAsset();
                    _loc_6.mouseEnabled = false;
                    _loc_10.addChild(DisplayObject(_loc_6));
                    selectionIndicators[_loc_11.uid] = _loc_6;
                    drawSelectionIndicator(_loc_6, param1.x, _loc_12, param1.width, _loc_9[_loc_11.rowIndex].height, enabled ? (getStyle("selectionColor")) : (getStyle("selectionDisabledColor")), param1);
                    if (param5)
                    {
                        applySelectionEffect(_loc_6, _loc_11.uid, param1);
                    }
                }
                else
                {
                    _loc_6 = selectionIndicators[_loc_11.uid];
                    drawSelectionIndicator(_loc_6, param1.x, _loc_12, param1.width, _loc_9[_loc_11.rowIndex].height, enabled ? (getStyle("selectionColor")) : (getStyle("selectionDisabledColor")), param1);
                }
            }
            else if (!param2)
            {
                if (_loc_11 && selectionIndicators[_loc_11.uid])
                {
                    if (selectionTweens[_loc_11.uid])
                    {
                        selectionTweens[_loc_11.uid].removeEventListener(TweenEvent.TWEEN_UPDATE, selectionTween_updateHandler);
                        selectionTweens[_loc_11.uid].removeEventListener(TweenEvent.TWEEN_END, selectionTween_endHandler);
                        if (selectionIndicators[_loc_11.uid].alpha < 1)
                        {
                            Tween.removeTween(selectionTweens[_loc_11.uid]);
                        }
                        delete selectionTweens[_loc_11.uid];
                    }
                    _loc_10.removeChild(selectionIndicators[_loc_11.uid]);
                    delete selectionIndicators[_loc_11.uid];
                }
            }
            if (param4)
            {
                if (showCaret)
                {
                    if (!caretIndicator)
                    {
                        _loc_6 = new SpriteAsset();
                        _loc_6.mouseEnabled = false;
                        _loc_10.addChild(DisplayObject(_loc_6));
                        caretIndicator = _loc_6;
                    }
                    else if (caretIndicator.parent != _loc_10)
                    {
                        _loc_10.addChild(caretIndicator);
                    }
                    else
                    {
                        _loc_10.setChildIndex(DisplayObject(caretIndicator), (_loc_10.numChildren - 1));
                    }
                    _loc_6 = caretIndicator;
                    drawCaretIndicator(_loc_6, param1.x, _loc_9[_loc_11.rowIndex].y, param1.width, _loc_9[_loc_11.rowIndex].height, getStyle("selectionColor"), param1);
                    caretItemRenderer = param1;
                    caretUID = _loc_11.uid;
                }
            }
            else if (!param4 && caretItemRenderer && caretUID == _loc_11.uid)
            {
                clearCaretIndicator(caretIndicator, param1);
                caretItemRenderer = null;
                caretUID = "";
            }
            if (param1 is IFlexDisplayObject)
            {
                if (param1 is IInvalidating)
                {
                    IInvalidating(param1).invalidateDisplayList();
                    IInvalidating(param1).validateNow();
                }
            }
            else if (param1 is IUITextField)
            {
                IUITextField(param1).validateNow();
            }
            return;
        }// end function

        private function strictEqualityCompareFunction(param1:Object, param2:Object) : Boolean
        {
            return param1 === param2;
        }// end function

        protected function dragExitHandler(event:DragEvent) : void
        {
            if (event.isDefaultPrevented())
            {
                return;
            }
            lastDragEvent = null;
            hideDropFeedback(event);
            resetDragScrolling();
            DragManager.showFeedback(DragManager.NONE);
            return;
        }// end function

        protected function adjustAfterRemove(param1:Array, param2:int, param3:Boolean) : Boolean
        {
            var data:ListBaseSelectionData;
            var requiresValueCommit:Boolean;
            var i:int;
            var length:int;
            var placeHolder:CursorBookmark;
            var s:String;
            var items:* = param1;
            var location:* = param2;
            var emitEvent:* = param3;
            requiresValueCommit = emitEvent;
            i;
            length = items.length;
            var _loc_5:int = 0;
            var _loc_6:* = selectedData;
            while (_loc_6 in _loc_5)
            {
                
                s = _loc_6[_loc_5];
                i = (i + 1);
                data = selectedData[s];
                if (data.index > location)
                {
                    data.index = data.index - length;
                }
            }
            if (_selectedIndex > location)
            {
                _selectedIndex = _selectedIndex - length;
                requiresValueCommit;
            }
            if (i > 0 && _selectedIndex == -1)
            {
                _selectedIndex = data.index;
                _selectedItem = data.data;
                requiresValueCommit;
            }
            if (i == 0)
            {
                _selectedIndex = -1;
                bSelectionChanged = true;
                bSelectedIndexChanged = true;
                invalidateDisplayList();
            }
            if (anchorIndex > location)
            {
                anchorIndex = anchorIndex - length;
                placeHolder = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.FIRST, anchorIndex);
                    anchorBookmark = iterator.bookmark;
                }
                catch (e:ItemPendingError)
                {
                    e.addResponder(new ItemResponder(setBookmarkPendingResultHandler, setBookmarkPendingFailureHandler, {property:"anchorBookmark", value:anchorIndex}));
                }
                iterator.seek(placeHolder);
            }
            if (caretIndex > location)
            {
                caretIndex = caretIndex - length;
                placeHolder = iterator.bookmark;
                try
                {
                    iterator.seek(CursorBookmark.FIRST, caretIndex);
                    caretBookmark = iterator.bookmark;
                }
                catch (e:ItemPendingError)
                {
                    e.addResponder(new ItemResponder(setBookmarkPendingResultHandler, setBookmarkPendingFailureHandler, {property:"caretBookmark", value:caretIndex}));
                }
                iterator.seek(placeHolder);
            }
            return requiresValueCommit;
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
            if (iconFunction != null)
            {
                return iconFunction(data);
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

        override public function set enabled(param1:Boolean) : void
        {
            super.enabled = param1;
            var _loc_2:* = border as IFlexDisplayObject;
            if (_loc_2)
            {
                if (_loc_2 is IUIComponent)
                {
                    IUIComponent(_loc_2).enabled = param1;
                }
                if (_loc_2 is IInvalidating)
                {
                    IInvalidating(_loc_2).invalidateDisplayList();
                }
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
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
            var _loc_1:* = dataProvider == null;
            var _loc_2:* = dataProvider != null && dataProvider.length == 0;
            var _loc_3:* = dataProvider;
            if (_loc_1 || _loc_2)
            {
                dataProvider = [null];
                validateNow();
            }
            if (!listItems || listItems.length == 0)
            {
                return super.baselinePosition;
            }
            var _loc_4:* = listItems[0][0] as IUIComponent;
            if (!(listItems[0][0] as IUIComponent))
            {
                return super.baselinePosition;
            }
            var _loc_5:* = ListBaseContentHolder(_loc_4.parent);
            var _loc_6:* = ListBaseContentHolder(_loc_4.parent).y + _loc_4.y + _loc_4.baselinePosition;
            if (_loc_1 || _loc_2)
            {
                dataProvider = _loc_3;
                validateNow();
            }
            return _loc_6;
        }// end function

        public function addDataEffectItem(param1:Object) : void
        {
            if (modifiedCollectionView)
            {
                modifiedCollectionView.addItem(dataItemWrappersByRenderer[param1]);
            }
            if (iterator.afterLast)
            {
                iterator.seek(CursorBookmark.FIRST);
            }
            else
            {
                iterator.seek(CursorBookmark.CURRENT);
            }
            if (invalidateDisplayListFlag)
            {
                callLater(invalidateList);
            }
            else
            {
                invalidateList();
            }
            return;
        }// end function

        private function makeRowsAndColumnsWithExtraRows(param1:Number, param2:Number) : void
        {
            var _loc_3:ListRowInfo = null;
            var _loc_4:ListRowInfo = null;
            var _loc_5:ListRowInfo = null;
            var _loc_6:int = 0;
            var _loc_7:Point = null;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_8:* = offscreenExtraRows / 2;
            var _loc_9:* = offscreenExtraRows / 2;
            offscreenExtraRowsTop = Math.min(_loc_8, verticalScrollPosition);
            var _loc_10:* = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition - offscreenExtraRowsTop);
            seekPositionSafely(_loc_10);
            var _loc_11:* = iterator.bookmark;
            if (offscreenExtraRowsTop > 0)
            {
                makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0, true, offscreenExtraRowsTop);
            }
            var _loc_12:* = offscreenExtraRowsTop ? (rowInfo[(offscreenExtraRowsTop - 1)].y + rowHeight) : (0);
            _loc_7 = makeRowsAndColumns(0, _loc_12, listContent.width, _loc_12 + listContent.heightExcludingOffsets, 0, offscreenExtraRowsTop);
            if (_loc_9 > 0 && !iterator.afterLast)
            {
                if (offscreenExtraRowsTop + _loc_7.y - 1 < 0)
                {
                    _loc_12 = 0;
                }
                else
                {
                    _loc_12 = rowInfo[offscreenExtraRowsTop + _loc_7.y - 1].y + rowInfo[offscreenExtraRowsTop + _loc_7.y - 1].height;
                }
                _loc_14 = listItems.length;
                _loc_7 = makeRowsAndColumns(0, _loc_12, listContent.width, _loc_12, 0, offscreenExtraRowsTop + _loc_7.y, true, _loc_9);
                if (_loc_7.y == _loc_9)
                {
                    while (_loc_7.y > 0 && listItems[(listItems.length - 1)] && listItems[(listItems.length - 1)].length == 0)
                    {
                        
                        var _loc_17:* = _loc_7;
                        var _loc_18:* = _loc_7.y - 1;
                        _loc_17.y = _loc_18;
                        listItems.pop();
                        rowInfo.pop();
                    }
                }
                else if (_loc_7.y < _loc_9)
                {
                    _loc_15 = listItems.length - (_loc_14 + _loc_7.y);
                    if (_loc_15)
                    {
                        _loc_16 = 0;
                        while (_loc_16 < _loc_15)
                        {
                            
                            listItems.pop();
                            rowInfo.pop();
                            _loc_16++;
                        }
                    }
                }
                offscreenExtraRowsBottom = _loc_7.y;
            }
            else
            {
                offscreenExtraRowsBottom = 0;
            }
            var _loc_13:* = listContent.heightExcludingOffsets;
            listContent.topOffset = (-offscreenExtraRowsTop) * rowHeight;
            listContent.bottomOffset = offscreenExtraRowsBottom > 0 ? (listItems[(listItems.length - 1)][0].y + rowHeight - _loc_13 + listContent.topOffset) : (0);
            if (iteratorValid)
            {
                iterator.seek(_loc_11, 0);
            }
            adjustListContent(param1, param2);
            return;
        }// end function

        function indicesToItemRenderer(param1:int, param2:int) : IListItemRenderer
        {
            return listItems[param1][param2];
        }// end function

        function getItemRendererForMouseEvent(event:MouseEvent) : IListItemRenderer
        {
            return mouseEventToItemRenderer(event);
        }// end function

        function set $verticalScrollPosition(param1:Number) : void
        {
            var _loc_2:* = super.verticalScrollPosition;
            if (_loc_2 != param1)
            {
                super.verticalScrollPosition = param1;
            }
            return;
        }// end function

        protected function mouseOutHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            if (!enabled || !selectable)
            {
                return;
            }
            isPressed = event.buttonDown;
            _loc_2 = mouseEventToItemRenderer(event);
            if (!_loc_2)
            {
                return;
            }
            if (!isPressed)
            {
                if (itemRendererContains(_loc_2, event.relatedObject) || event.relatedObject == listContent || event.relatedObject == highlightIndicator || !highlightItemRenderer)
                {
                    return;
                }
                if (getStyle("useRollOver") && _loc_2.data != null)
                {
                    clearHighlight(_loc_2);
                }
            }
            return;
        }// end function

        public function set dropEnabled(param1:Boolean) : void
        {
            if (_dropEnabled && !param1)
            {
                removeEventListener(DragEvent.DRAG_ENTER, dragEnterHandler, false);
                removeEventListener(DragEvent.DRAG_EXIT, dragExitHandler, false);
                removeEventListener(DragEvent.DRAG_OVER, dragOverHandler, false);
                removeEventListener(DragEvent.DRAG_DROP, dragDropHandler, false);
            }
            _dropEnabled = param1;
            if (param1)
            {
                addEventListener(DragEvent.DRAG_ENTER, dragEnterHandler, false, EventPriority.DEFAULT_HANDLER);
                addEventListener(DragEvent.DRAG_EXIT, dragExitHandler, false, EventPriority.DEFAULT_HANDLER);
                addEventListener(DragEvent.DRAG_OVER, dragOverHandler, false, EventPriority.DEFAULT_HANDLER);
                addEventListener(DragEvent.DRAG_DROP, dragDropHandler, false, EventPriority.DEFAULT_HANDLER);
            }
            return;
        }// end function

        protected function get listContentStyleFilters() : Object
        {
            return _listContentStyleFilters;
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

        public function set rowCount(param1:int) : void
        {
            explicitRowCount = param1;
            if (_rowCount != param1)
            {
                setRowCount(param1);
                rowCountChanged = true;
                invalidateProperties();
                invalidateSize();
                itemsSizeChanged = true;
                invalidateDisplayList();
                dispatchEvent(new Event("rowCountChanged"));
            }
            return;
        }// end function

        public function set columnCount(param1:int) : void
        {
            explicitColumnCount = param1;
            if (_columnCount != param1)
            {
                setColumnCount(param1);
                columnCountChanged = true;
                invalidateProperties();
                invalidateSize();
                itemsSizeChanged = true;
                invalidateDisplayList();
                dispatchEvent(new Event("columnCountChanged"));
            }
            return;
        }// end function

        private function partialPurgeItemRenderers() : void
        {
            var _loc_1:* = undefined;
            var _loc_2:String = null;
            var _loc_3:DisplayObject = null;
            var _loc_4:Dictionary = null;
            var _loc_5:* = undefined;
            dataEffectCompleted = false;
            while (freeItemRenderers.length)
            {
                
                _loc_3 = DisplayObject(freeItemRenderers.pop());
                if (_loc_3.parent)
                {
                    listContent.removeChild(_loc_3);
                }
            }
            for (_loc_1 in freeItemRenderersByFactory)
            {
                
                _loc_4 = freeItemRenderersByFactory[_loc_1];
                for (_loc_5 in _loc_4)
                {
                    
                    _loc_3 = DisplayObject(_loc_5);
                    delete _loc_4[_loc_5];
                    if (_loc_3.parent)
                    {
                        listContent.removeChild(_loc_3);
                    }
                }
            }
            for (_loc_2 in reservedItemRenderers)
            {
                
                _loc_3 = DisplayObject(reservedItemRenderers[_loc_2]);
                if (_loc_3.parent)
                {
                    listContent.removeChild(_loc_3);
                }
            }
            reservedItemRenderers = {};
            rowMap = {};
            clearVisibleData();
            return;
        }// end function

        protected function seekPendingResultHandler(param1:Object, param2:ListBaseSeekPending) : void
        {
            var data:* = param1;
            var info:* = param2;
            if (info != lastSeekPending)
            {
                return;
            }
            lastSeekPending = null;
            iteratorValid = true;
            try
            {
                iterator.seek(info.bookmark, info.offset);
            }
            catch (e:ItemPendingError)
            {
                lastSeekPending = new ListBaseSeekPending(info.bookmark, info.offset);
                e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                iteratorValid = false;
            }
            if (bSortItemPending)
            {
                bSortItemPending = false;
                adjustAfterSort();
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        function mouseEventToItemRendererOrEditor(event:MouseEvent) : IListItemRenderer
        {
            var _loc_3:Point = null;
            var _loc_4:Number = NaN;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_2:* = DisplayObject(event.target);
            if (_loc_2 == listContent)
            {
                _loc_3 = new Point(event.stageX, event.stageY);
                _loc_3 = listContent.globalToLocal(_loc_3);
                _loc_4 = 0;
                _loc_5 = listItems.length;
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    if (listItems[_loc_6].length)
                    {
                        if (_loc_3.y < _loc_4 + rowInfo[_loc_6].height)
                        {
                            _loc_7 = listItems[_loc_6].length;
                            if (_loc_7 == 1)
                            {
                                return listItems[_loc_6][0];
                            }
                            _loc_8 = Math.floor(_loc_3.x / columnWidth);
                            return listItems[_loc_6][_loc_8];
                        }
                    }
                    _loc_4 = _loc_4 + rowInfo[_loc_6].height;
                    _loc_6++;
                }
            }
            else if (_loc_2 == highlightIndicator)
            {
                return lastHighlightItemRenderer;
            }
            while (_loc_2 && _loc_2 != this)
            {
                
                if (_loc_2 is IListItemRenderer && _loc_2.parent == listContent)
                {
                    if (_loc_2.visible)
                    {
                        return IListItemRenderer(_loc_2);
                    }
                    break;
                }
                if (_loc_2 is IUIComponent)
                {
                    _loc_2 = IUIComponent(_loc_2).owner;
                    continue;
                }
                _loc_2 = _loc_2.parent;
            }
            return null;
        }// end function

        protected function configureScrollBars() : void
        {
            return;
        }// end function

        protected function clearVisibleData() : void
        {
            listContent.visibleData = {};
            return;
        }// end function

        private function insertSelectionDataAfter(param1:String, param2:ListBaseSelectionData, param3:ListBaseSelectionData) : void
        {
            if (param3 == null)
            {
                var _loc_4:* = param2;
                lastSelectionData = param2;
                firstSelectionData = _loc_4;
            }
            else
            {
                if (param3 == lastSelectionData)
                {
                    lastSelectionData = param2;
                }
                param2.prevSelectionData = param3;
                param2.nextSelectionData = param3.nextSelectionData;
                param3.nextSelectionData = param2;
            }
            selectedData[param1] = param2;
            return;
        }// end function

        protected function moveSelectionVertically(param1:uint, param2:Boolean, param3:Boolean) : void
        {
            var _loc_4:Number = NaN;
            var _loc_5:IListItemRenderer = null;
            var _loc_6:String = null;
            var _loc_7:int = 0;
            var _loc_13:ScrollEvent = null;
            var _loc_8:Boolean = false;
            showCaret = true;
            var _loc_9:* = listItems.length;
            var _loc_10:* = listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom;
            var _loc_11:* = rowInfo[_loc_9 - offscreenExtraRowsBottom - 1].y + rowInfo[_loc_9 - offscreenExtraRowsBottom - 1].height > listContent.heightExcludingOffsets - listContent.topOffset ? (1) : (0);
            var _loc_12:Boolean = false;
            bSelectItem = false;
            switch(param1)
            {
                case Keyboard.UP:
                {
                    if (caretIndex > 0)
                    {
                        var _loc_15:* = caretIndex - 1;
                        caretIndex = _loc_15;
                        _loc_12 = true;
                        bSelectItem = true;
                    }
                    break;
                }
                case Keyboard.DOWN:
                {
                    if (caretIndex < (collection.length - 1))
                    {
                        var _loc_15:* = caretIndex + 1;
                        caretIndex = _loc_15;
                        _loc_12 = true;
                        bSelectItem = true;
                    }
                    else if (caretIndex == (collection.length - 1) && _loc_11)
                    {
                        if (verticalScrollPosition < maxVerticalScrollPosition)
                        {
                            _loc_4 = verticalScrollPosition + 1;
                        }
                    }
                    break;
                }
                case Keyboard.PAGE_UP:
                {
                    if (caretIndex > verticalScrollPosition && caretIndex < verticalScrollPosition + _loc_10)
                    {
                        caretIndex = verticalScrollPosition;
                    }
                    else
                    {
                        caretIndex = Math.max(caretIndex - Math.max(_loc_10 - _loc_11, 1), 0);
                        _loc_4 = Math.max(caretIndex, 0);
                    }
                    bSelectItem = true;
                    break;
                }
                case Keyboard.PAGE_DOWN:
                {
                    if (caretIndex >= verticalScrollPosition && caretIndex < verticalScrollPosition + _loc_10 - _loc_11 - 1)
                    {
                    }
                    else
                    {
                        if (caretIndex == verticalScrollPosition && _loc_10 - _loc_11 <= 1)
                        {
                            var _loc_15:* = caretIndex + 1;
                            caretIndex = _loc_15;
                        }
                        _loc_4 = Math.max(Math.min(caretIndex, maxVerticalScrollPosition), 0);
                    }
                    bSelectItem = true;
                    break;
                }
                case Keyboard.HOME:
                {
                    if (caretIndex > 0)
                    {
                        caretIndex = 0;
                        bSelectItem = true;
                        _loc_4 = 0;
                    }
                    break;
                }
                case Keyboard.END:
                {
                    if (caretIndex < (collection.length - 1))
                    {
                        caretIndex = collection.length - 1;
                        bSelectItem = true;
                        _loc_4 = maxVerticalScrollPosition;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (_loc_12)
            {
                if (caretIndex >= verticalScrollPosition + _loc_10 - _loc_11)
                {
                    if (_loc_10 - _loc_11 == 0)
                    {
                        _loc_4 = Math.min(maxVerticalScrollPosition, caretIndex);
                    }
                    else
                    {
                        _loc_4 = Math.min(maxVerticalScrollPosition, caretIndex - _loc_10 + _loc_11 + 1);
                    }
                }
                else if (caretIndex < verticalScrollPosition)
                {
                    _loc_4 = Math.max(caretIndex, 0);
                }
            }
            if (!isNaN(_loc_4))
            {
                if (verticalScrollPosition != _loc_4)
                {
                    _loc_13 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_13.detail = ScrollEventDetail.THUMB_POSITION;
                    _loc_13.direction = ScrollEventDirection.VERTICAL;
                    _loc_13.delta = _loc_4 - verticalScrollPosition;
                    _loc_13.position = _loc_4;
                    verticalScrollPosition = _loc_4;
                    dispatchEvent(_loc_13);
                }
                if (!iteratorValid)
                {
                    keySelectionPending = true;
                    return;
                }
            }
            bShiftKey = param2;
            bCtrlKey = param3;
            lastKey = param1;
            finishKeySelection();
            return;
        }// end function

        protected function getReservedOrFreeItemRenderer(param1:Object) : IListItemRenderer
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:String = null;
            var _loc_4:IFactory = null;
            var _loc_5:Dictionary = null;
            var _loc_6:* = undefined;
            if (runningDataEffect)
            {
                var _loc_7:* = itemToUID(param1);
                _loc_3 = itemToUID(param1);
                _loc_2 = IListItemRenderer(reservedItemRenderers[_loc_7]);
            }
            if (_loc_2)
            {
                delete reservedItemRenderers[_loc_3];
            }
            else
            {
                _loc_4 = getItemRendererFactory(param1);
                if (freeItemRenderersByFactory)
                {
                    if (_loc_4 == itemRenderer)
                    {
                        if (freeItemRenderers.length)
                        {
                            _loc_2 = freeItemRenderers.pop();
                            delete freeItemRenderersByFactory[_loc_4][_loc_2];
                        }
                    }
                    else
                    {
                        _loc_5 = freeItemRenderersByFactory[_loc_4];
                        if (_loc_5)
                        {
                            for (_loc_6 in _loc_5)
                            {
                                
                                _loc_2 = _loc_6;
                                delete freeItemRenderersByFactory[_loc_4][_loc_2];
                                break;
                            }
                        }
                    }
                }
            }
            return _loc_2;
        }// end function

        protected function addDragData(param1:Object) : void
        {
            param1.addHandler(copySelectedItems, "items");
            return;
        }// end function

        private function adjustAfterSort() : void
        {
            var p:String;
            var index:int;
            var newVerticalScrollPosition:int;
            var newHorizontalScrollPosition:int;
            var pos:int;
            var data:ListBaseSelectionData;
            var i:int;
            var _loc_2:int = 0;
            var _loc_3:* = selectedData;
            while (_loc_3 in _loc_2)
            {
                
                p = _loc_3[_loc_2];
                i = (i + 1);
            }
            index = anchorBookmark ? (anchorBookmark.getViewIndex()) : (-1);
            if (index >= 0)
            {
                if (i == 1)
                {
                    var _loc_2:* = index;
                    caretIndex = index;
                    var _loc_2:* = _loc_2;
                    anchorIndex = _loc_2;
                    _selectedIndex = _loc_2;
                    data = selectedData[p];
                    data.index = index;
                }
                newVerticalScrollPosition = indexToRow(index);
                if (newVerticalScrollPosition == -1)
                {
                    return;
                }
                newVerticalScrollPosition = Math.min(maxVerticalScrollPosition, newVerticalScrollPosition);
                newHorizontalScrollPosition = indexToColumn(index);
                if (newHorizontalScrollPosition == -1)
                {
                    return;
                }
                newHorizontalScrollPosition = Math.min(maxHorizontalScrollPosition, newHorizontalScrollPosition);
                pos = scrollPositionToIndex(newHorizontalScrollPosition, newVerticalScrollPosition);
                try
                {
                    iterator.seek(CursorBookmark.CURRENT, pos - index);
                    if (!iteratorValid)
                    {
                        iteratorValid = true;
                        lastSeekPending = null;
                    }
                }
                catch (e:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(CursorBookmark.CURRENT, pos - index);
                    e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    iteratorValid = false;
                    return;
                }
                super.verticalScrollPosition = newVerticalScrollPosition;
                if (listType != "vertical")
                {
                    super.horizontalScrollPosition = newHorizontalScrollPosition;
                }
            }
            else
            {
                try
                {
                    index = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition - offscreenExtraRowsTop);
                    iterator.seek(CursorBookmark.FIRST, index);
                    if (!iteratorValid)
                    {
                        iteratorValid = true;
                        lastSeekPending = null;
                    }
                }
                catch (e:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, index);
                    e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    iteratorValid = false;
                    return;
                }
            }
            if (i > 1)
            {
                commitSelectedItems(selectedItems);
            }
            return;
        }// end function

        public function set listData(param1:BaseListData) : void
        {
            _listData = param1;
            return;
        }// end function

        private function initiateSelectionTracking(param1:Array) : void
        {
            var _loc_3:IListItemRenderer = null;
            var _loc_2:int = 0;
            while (_loc_2 < param1.length)
            {
                
                _loc_3 = param1[_loc_2] as IListItemRenderer;
                if (selectedData[itemToUID(_loc_3.data)])
                {
                    _loc_3.addEventListener(MoveEvent.MOVE, rendererMoveHandler);
                    trackedRenderers.push(_loc_3);
                }
                _loc_2++;
            }
            return;
        }// end function

        private function setSelectionDataLoop(param1:Array, param2:int, param3:Boolean = true) : void
        {
            var uid:String;
            var item:Object;
            var bookmark:CursorBookmark;
            var compareFunction:Function;
            var selectionData:ListBaseSelectionData;
            var lastSelectionData:ListBaseSelectionData;
            var len:int;
            var data:Object;
            var i:int;
            var items:* = param1;
            var index:* = param2;
            var useFind:* = param3;
            if (useFind)
            {
                while (items.length)
                {
                    
                    item = items.pop();
                    uid = itemToUID(item);
                    try
                    {
                        collectionIterator.findAny(item);
                    }
                    catch (e1:ItemPendingError)
                    {
                        items.push(item);
                        e1.addResponder(new ItemResponder(selectionDataPendingResultHandler, selectionDataPendingFailureHandler, new ListBaseSelectionDataPending(useFind, 0, items, null, 0)));
                        return;
                    }
                    bookmark = collectionIterator.bookmark;
                    index = bookmark.getViewIndex();
                    if (index >= 0)
                    {
                        insertSelectionDataBefore(uid, new ListBaseSelectionData(item, index, true), firstSelectionData);
                    }
                    else
                    {
                        try
                        {
                            collectionIterator.seek(CursorBookmark.FIRST, 0);
                        }
                        catch (e2:ItemPendingError)
                        {
                            e2.addResponder(new ItemResponder(selectionDataPendingResultHandler, selectionDataPendingFailureHandler, new ListBaseSelectionDataPending(false, 0, items, CursorBookmark.FIRST, 0)));
                            return;
                        }
                        setSelectionDataLoop(items, 0, false);
                        return;
                    }
                    if (items.length == 0)
                    {
                        _selectedIndex = index;
                        _selectedItem = item;
                        caretIndex = index;
                        caretBookmark = collectionIterator.bookmark;
                        anchorIndex = index;
                        anchorBookmark = collectionIterator.bookmark;
                    }
                }
            }
            else
            {
                compareFunction = selectedItemsCompareFunction;
                if (compareFunction == null)
                {
                    compareFunction = strictEqualityCompareFunction;
                }
                do
                {
                    
                    len = items.length;
                    data = collectionIterator.current;
                    i;
                    while (i < len)
                    {
                        
                        item = items[i];
                        if (this.compareFunction(data, item))
                        {
                            uid = itemToUID(data);
                            selectionDataArray[proposedSelectedItemIndexes[uid]] = new ListBaseSelectionData(data, index, false);
                            items.splice(i, 1);
                            if (item === firstSelectedItem)
                            {
                                _selectedIndex = index;
                                _selectedItem = data;
                                caretIndex = index;
                                caretBookmark = collectionIterator.bookmark;
                                anchorIndex = index;
                                anchorBookmark = collectionIterator.bookmark;
                            }
                            break;
                        }
                        i = (i + 1);
                    }
                    try
                    {
                        collectionIterator.moveNext();
                        index = (index + 1);
                    }
                    catch (e2:ItemPendingError)
                    {
                        e2.addResponder(new ItemResponder(selectionDataPendingResultHandler, selectionDataPendingFailureHandler, new ListBaseSelectionDataPending(false, index, items, CursorBookmark.FIRST, index)));
                        return;
                    }
                }while (items.length && !collectionIterator.afterLast)
                len = selectionDataArray.length;
                lastSelectionData = firstSelectionData;
                if (len)
                {
                    selectionData = selectionDataArray[0];
                    if (selectionData)
                    {
                        uid = itemToUID(selectionData.data);
                        insertSelectionDataBefore(uid, selectionData, firstSelectionData);
                        lastSelectionData = selectionData;
                    }
                }
                i;
                while (i < len)
                {
                    
                    selectionData = selectionDataArray[i];
                    if (selectionData)
                    {
                        uid = itemToUID(selectionData.data);
                        insertSelectionDataAfter(uid, selectionData, lastSelectionData);
                        lastSelectionData = selectionData;
                    }
                    i = (i + 1);
                }
                selectionDataArray = null;
                proposedSelectedItemIndexes = null;
                firstSelectedItem = null;
            }
            if (initialized)
            {
                updateList();
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        public function set dragEnabled(param1:Boolean) : void
        {
            if (_dragEnabled && !param1)
            {
                removeEventListener(DragEvent.DRAG_START, dragStartHandler, false);
                removeEventListener(DragEvent.DRAG_COMPLETE, dragCompleteHandler, false);
            }
            _dragEnabled = param1;
            if (param1)
            {
                addEventListener(DragEvent.DRAG_START, dragStartHandler, false, EventPriority.DEFAULT_HANDLER);
                addEventListener(DragEvent.DRAG_COMPLETE, dragCompleteHandler, false, EventPriority.DEFAULT_HANDLER);
            }
            return;
        }// end function

        function getListContentHolder() : ListBaseContentHolder
        {
            return listContent;
        }// end function

        public function set iconFunction(param1:Function) : void
        {
            _iconFunction = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("iconFunctionChanged"));
            return;
        }// end function

        protected function initiateDataChangeEffect(param1:Number, param2:Number) : void
        {
            var _loc_9:Array = null;
            var _loc_10:int = 0;
            var _loc_11:Object = null;
            actualCollection = collection;
            actualIterator = iterator;
            collection = modifiedCollectionView;
            modifiedCollectionView.showPreservedState = true;
            var _loc_12:* = collection.createCursor();
            iterator = collection.createCursor();
            listContent.iterator = _loc_12;
            var _loc_3:* = scrollPositionToIndex(horizontalScrollPosition - offscreenExtraColumnsLeft, verticalScrollPosition - offscreenExtraRowsTop);
            iterator.seek(CursorBookmark.FIRST, _loc_3);
            updateDisplayList(param1, param2);
            var _loc_4:Array = [];
            var _loc_5:* = new Dictionary(true);
            var _loc_6:int = 0;
            while (_loc_6 < listItems.length)
            {
                
                _loc_9 = listItems[_loc_6];
                if (_loc_9 && _loc_9.length > 0)
                {
                    _loc_10 = 0;
                    while (_loc_10 < _loc_9.length)
                    {
                        
                        _loc_11 = _loc_9[_loc_10];
                        if (_loc_11)
                        {
                            _loc_4.push(_loc_11);
                            _loc_5[_loc_11] = true;
                        }
                        _loc_10++;
                    }
                }
                _loc_6++;
            }
            cachedItemsChangeEffect.targets = _loc_4;
            if (cachedItemsChangeEffect.effectTargetHost != this)
            {
                cachedItemsChangeEffect.effectTargetHost = this;
            }
            cachedItemsChangeEffect.captureStartValues();
            modifiedCollectionView.showPreservedState = false;
            iterator.seek(CursorBookmark.FIRST, _loc_3);
            itemsSizeChanged = true;
            updateDisplayList(param1, param2);
            var _loc_7:Array = [];
            var _loc_8:* = cachedItemsChangeEffect.targets;
            _loc_6 = 0;
            while (_loc_6 < listItems.length)
            {
                
                _loc_9 = listItems[_loc_6];
                if (_loc_9 && _loc_9.length > 0)
                {
                    _loc_10 = 0;
                    while (_loc_10 < _loc_9.length)
                    {
                        
                        _loc_11 = _loc_9[_loc_10];
                        if (_loc_11 && !_loc_5[_loc_11])
                        {
                            _loc_8.push(_loc_11);
                            _loc_7.push(_loc_11);
                        }
                        _loc_10++;
                    }
                }
                _loc_6++;
            }
            if (_loc_7.length > 0)
            {
                cachedItemsChangeEffect.targets = _loc_8;
                cachedItemsChangeEffect.captureMoreStartValues(_loc_7);
            }
            cachedItemsChangeEffect.captureEndValues();
            modifiedCollectionView.showPreservedState = true;
            iterator.seek(CursorBookmark.FIRST, _loc_3);
            itemsSizeChanged = true;
            updateDisplayList(param1, param2);
            initiateSelectionTracking(_loc_8);
            cachedItemsChangeEffect.addEventListener(EffectEvent.EFFECT_END, finishDataChangeEffect);
            cachedItemsChangeEffect.play();
            return;
        }// end function

        public function get labelFunction() : Function
        {
            return _labelFunction;
        }// end function

        public function get dataTipField() : String
        {
            return _dataTipField;
        }// end function

        protected function adjustListContent(param1:Number = -1, param2:Number = -1) : void
        {
            if (param2 < 0)
            {
                param2 = oldUnscaledHeight;
                param1 = oldUnscaledWidth;
            }
            var _loc_3:* = viewMetrics.left + listContent.leftOffset;
            var _loc_4:* = viewMetrics.top + listContent.topOffset;
            listContent.move(_loc_3, _loc_4);
            var _loc_5:* = Math.max(0, listContent.rightOffset) - _loc_3 - viewMetrics.right;
            var _loc_6:* = Math.max(0, listContent.bottomOffset) - _loc_4 - viewMetrics.bottom;
            listContent.setActualSize(param1 + _loc_5, param2 + _loc_6);
            return;
        }// end function

        public function get selectedIndex() : int
        {
            return _selectedIndex;
        }// end function

        function setBookmarkPendingFailureHandler(param1:Object, param2:Object) : void
        {
            return;
        }// end function

        private function insertSelectionDataBefore(param1:String, param2:ListBaseSelectionData, param3:ListBaseSelectionData) : void
        {
            if (param3 == null)
            {
                var _loc_4:* = param2;
                lastSelectionData = param2;
                firstSelectionData = _loc_4;
            }
            else
            {
                if (param3 == firstSelectionData)
                {
                    firstSelectionData = param2;
                }
                param2.nextSelectionData = param3;
                param2.prevSelectionData = param3.prevSelectionData;
                param3.prevSelectionData = param2;
            }
            selectedData[param1] = param2;
            return;
        }// end function

        function getCaretIndex() : int
        {
            return caretIndex;
        }// end function

        function removeClipMask() : void
        {
            var _loc_7:DisplayObject = null;
            if (listContent && listContent.mask)
            {
                return;
            }
            var _loc_1:* = listItems.length - 1;
            if (_loc_1 < 0)
            {
                return;
            }
            var _loc_2:* = rowInfo[_loc_1].height;
            var _loc_3:* = rowInfo[_loc_1];
            var _loc_4:* = listItems[_loc_1];
            var _loc_5:* = listItems[_loc_1].length;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_7 = _loc_4[_loc_6];
                if (_loc_7 is IUITextField)
                {
                    if (_loc_7.height != _loc_2 - (_loc_7.y - _loc_3.y))
                    {
                        _loc_7.height = _loc_2 - (_loc_7.y - _loc_3.y);
                    }
                }
                else if (_loc_7 && _loc_7.mask)
                {
                    itemMaskFreeList.push(_loc_7.mask);
                    _loc_7.mask = null;
                }
                _loc_6++;
            }
            return;
        }// end function

        function reconstructDataFromListItems() : Array
        {
            var _loc_1:Array = null;
            var _loc_2:int = 0;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Object = null;
            var _loc_5:Object = null;
            var _loc_6:int = 0;
            if (!listItems)
            {
                return [];
            }
            _loc_1 = [];
            _loc_2 = 0;
            while (_loc_2 < listItems.length)
            {
                
                if (listItems[_loc_2])
                {
                    _loc_3 = listItems[_loc_2][0] as IListItemRenderer;
                    if (_loc_3)
                    {
                        _loc_4 = _loc_3.data;
                        _loc_1.push(_loc_4);
                        _loc_6 = 0;
                        while (_loc_6 < listItems[_loc_2].length)
                        {
                            
                            _loc_3 = listItems[_loc_2][_loc_6] as IListItemRenderer;
                            if (_loc_3)
                            {
                                _loc_5 = _loc_3.data;
                                if (_loc_5 != _loc_4)
                                {
                                    _loc_1.push(_loc_5);
                                }
                            }
                            _loc_6++;
                        }
                    }
                }
                _loc_2++;
            }
            return _loc_1;
        }// end function

        public function set dataTipFunction(param1:Function) : void
        {
            _dataTipFunction = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("dataTipFunctionChanged"));
            return;
        }// end function

        private function calculateSelectedIndexAndItem() : void
        {
            var _loc_2:String = null;
            var _loc_1:int = 0;
            for (_loc_2 in selectedData)
            {
                
                _loc_1 = 1;
                break;
            }
            if (!_loc_1)
            {
                _selectedIndex = -1;
                _selectedItem = null;
                return;
            }
            _selectedIndex = selectedData[_loc_2].index;
            _selectedItem = selectedData[_loc_2].data;
            return;
        }// end function

        protected function scrollPositionToIndex(param1:int, param2:int) : int
        {
            return iterator ? (param2) : (-1);
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            if (!listContent)
            {
                listContent = new ListBaseContentHolder(this);
                listContent.styleName = new StyleProxy(this, listContentStyleFilters);
                addChild(listContent);
            }
            if (!selectionLayer)
            {
                selectionLayer = listContent.selectionLayer;
            }
            return;
        }// end function

        public function findString(param1:String) : Boolean
        {
            var cursorPos:CursorBookmark;
            var bMovedNext:Boolean;
            var str:* = param1;
            if (!collection || collection.length == 0)
            {
                return false;
            }
            cursorPos = iterator.bookmark;
            var stopIndex:* = selectedIndex;
            var i:* = (stopIndex + 1);
            if (selectedIndex == -1)
            {
                try
                {
                    iterator.seek(CursorBookmark.FIRST, 0);
                }
                catch (e1:ItemPendingError)
                {
                    e1.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, CursorBookmark.FIRST, 0, 0, collection.length)));
                    iteratorValid = false;
                    return false;
                }
                stopIndex = collection.length;
                i;
            }
            else
            {
                try
                {
                    iterator.seek(CursorBookmark.FIRST, stopIndex);
                }
                catch (e2:ItemPendingError)
                {
                    if (anchorIndex == (collection.length - 1))
                    {
                        e2.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, CursorBookmark.FIRST, 0, 0, collection.length)));
                    }
                    else
                    {
                        e2.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, anchorBookmark, 1, (anchorIndex + 1), anchorIndex)));
                    }
                    iteratorValid = false;
                    return false;
                }
                bMovedNext;
                try
                {
                    bMovedNext = iterator.moveNext();
                }
                catch (e3:ItemPendingError)
                {
                    e3.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, anchorBookmark, 1, (anchorIndex + 1), anchorIndex)));
                    iteratorValid = false;
                    return false;
                }
                if (!bMovedNext)
                {
                    try
                    {
                        iterator.seek(CursorBookmark.FIRST, 0);
                    }
                    catch (e4:ItemPendingError)
                    {
                        e4.addResponder(new ItemResponder(findPendingResultHandler, findPendingFailureHandler, new ListBaseFindPending(str, cursorPos, CursorBookmark.FIRST, 0, 0, collection.length)));
                        iteratorValid = false;
                        return false;
                    }
                    stopIndex = collection.length;
                    i;
                }
            }
            return findStringLoop(str, cursorPos, i, stopIndex);
        }// end function

        private function commitSelectedItem(param1:Object, param2:Boolean = true) : void
        {
            if (param2)
            {
                clearSelected();
            }
            if (param1 != null)
            {
                commitSelectedItems([param1]);
            }
            return;
        }// end function

        public function get selectedItemsCompareFunction() : Function
        {
            return _selectedItemsCompareFunction;
        }// end function

        function commitSelectedIndex(param1:int) : void
        {
            var bookmark:CursorBookmark;
            var len:int;
            var data:Object;
            var selectedBookmark:CursorBookmark;
            var uid:String;
            var value:* = param1;
            if (value != -1)
            {
                value = Math.min(value, (collection.length - 1));
                bookmark = iterator.bookmark;
                len = value - scrollPositionToIndex(horizontalScrollPosition - offscreenExtraColumnsLeft, verticalScrollPosition - offscreenExtraRowsTop);
                try
                {
                    iterator.seek(CursorBookmark.CURRENT, len);
                }
                catch (e:ItemPendingError)
                {
                    iterator.seek(bookmark, 0);
                    bSelectedIndexChanged = true;
                    _selectedIndex = value;
                    return;
                }
                data = iterator.current;
                selectedBookmark = iterator.bookmark;
                uid = itemToUID(data);
                iterator.seek(bookmark, 0);
                if (!selectedData[uid])
                {
                    if (listContent && UIDToItemRenderer(uid))
                    {
                        selectItem(UIDToItemRenderer(uid), false, false);
                    }
                    else
                    {
                        clearSelected();
                        insertSelectionDataBefore(uid, new ListBaseSelectionData(data, value, approximate), firstSelectionData);
                        _selectedIndex = value;
                        caretIndex = value;
                        caretBookmark = selectedBookmark;
                        anchorIndex = value;
                        anchorBookmark = selectedBookmark;
                        _selectedItem = data;
                    }
                }
            }
            else
            {
                clearSelected();
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        protected function get visibleData() : Object
        {
            return listContent.visibleData;
        }// end function

        public function set rowHeight(param1:Number) : void
        {
            explicitRowHeight = param1;
            if (_rowHeight != param1)
            {
                setRowHeight(param1);
                invalidateSize();
                itemsSizeChanged = true;
                invalidateDisplayList();
                dispatchEvent(new Event("rowHeightChanged"));
            }
            return;
        }// end function

        private function seekNextSafely(param1:IViewCursor, param2:int) : Boolean
        {
            var iterator:* = param1;
            var pos:* = param2;
            try
            {
                iterator.moveNext();
            }
            catch (e:ItemPendingError)
            {
                lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, pos);
                e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                iteratorValid = false;
            }
            return iteratorValid;
        }// end function

        public function showDropFeedback(event:DragEvent) : void
        {
            var _loc_6:Class = null;
            var _loc_7:EdgeMetrics = null;
            if (!dropIndicator)
            {
                _loc_6 = getStyle("dropIndicatorSkin");
                if (!_loc_6)
                {
                    _loc_6 = ListDropIndicator;
                }
                dropIndicator = IFlexDisplayObject(new _loc_6);
                _loc_7 = viewMetrics;
                drawFocus(true);
                dropIndicator.x = 2;
                dropIndicator.setActualSize(listContent.width - 4, 4);
                dropIndicator.visible = true;
                listContent.addChild(DisplayObject(dropIndicator));
                if (collection)
                {
                    if (dragScrollingInterval == 0)
                    {
                        dragScrollingInterval = setInterval(dragScroll, 15);
                    }
                }
            }
            var _loc_2:* = listItems.length;
            var _loc_3:* = rowInfo[_loc_2 - offscreenExtraRowsBottom - 1].y + rowInfo[_loc_2 - offscreenExtraRowsBottom - 1].height > listContent.heightExcludingOffsets - listContent.topOffset ? (1) : (0);
            var _loc_4:* = calculateDropIndex(event);
            _loc_4 = calculateDropIndex(event) - verticalScrollPosition;
            var _loc_5:* = listItems.length;
            if (_loc_4 >= _loc_5)
            {
                if (_loc_3)
                {
                    _loc_4 = _loc_5 - 1;
                }
                else
                {
                    _loc_4 = _loc_5;
                }
            }
            if (_loc_4 < 0)
            {
                _loc_4 = 0;
            }
            dropIndicator.y = calculateDropIndicatorY(_loc_5, _loc_4 + offscreenExtraRowsTop);
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            if (_listData && _listData is DataGridListData)
            {
                selectedItem = _data[DataGridListData(_listData).dataField];
            }
            else if (_listData is ListData && ListData(_listData).labelField in _data)
            {
                selectedItem = _data[ListData(_listData).labelField];
            }
            else
            {
                selectedItem = _data;
            }
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        public function get rowCount() : int
        {
            return _rowCount;
        }// end function

        function get rendererArray() : Array
        {
            return listItems;
        }// end function

        public function get columnCount() : int
        {
            return _columnCount;
        }// end function

        protected function purgeItemRenderers() : void
        {
            var _loc_1:* = undefined;
            var _loc_2:Array = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:DisplayObject = null;
            var _loc_5:Dictionary = null;
            var _loc_6:* = undefined;
            rendererChanged = false;
            while (listItems.length)
            {
                
                _loc_2 = listItems.pop();
                while (_loc_2.length)
                {
                    
                    _loc_3 = IListItemRenderer(_loc_2.pop());
                    if (_loc_3)
                    {
                        listContent.removeChild(DisplayObject(_loc_3));
                        if (dataItemWrappersByRenderer[_loc_3])
                        {
                            delete visibleData[itemToUID(dataItemWrappersByRenderer[_loc_3])];
                            continue;
                        }
                        delete visibleData[itemToUID(_loc_3.data)];
                    }
                }
            }
            while (freeItemRenderers.length)
            {
                
                _loc_4 = DisplayObject(freeItemRenderers.pop());
                if (_loc_4.parent)
                {
                    listContent.removeChild(_loc_4);
                }
            }
            for (_loc_1 in freeItemRenderersByFactory)
            {
                
                _loc_5 = freeItemRenderersByFactory[_loc_1];
                for (_loc_6 in _loc_5)
                {
                    
                    _loc_4 = DisplayObject(_loc_6);
                    delete _loc_5[_loc_6];
                    if (_loc_4.parent)
                    {
                        listContent.removeChild(_loc_4);
                    }
                }
            }
            rowMap = {};
            listContent.rowInfo = [];
            return;
        }// end function

        protected function mouseEventToItemRenderer(event:MouseEvent) : IListItemRenderer
        {
            return mouseEventToItemRendererOrEditor(event);
        }// end function

        protected function UIDToItemRenderer(param1:String) : IListItemRenderer
        {
            if (!listContent)
            {
                return null;
            }
            return visibleData[param1];
        }// end function

        public function get dragEnabled() : Boolean
        {
            return _dragEnabled;
        }// end function

        private function findPendingResultHandler(param1:Object, param2:ListBaseFindPending) : void
        {
            iterator.seek(param2.bookmark, param2.offset);
            findStringLoop(param2.searchString, param2.startingBookmark, param2.currentIndex, param2.stopIndex);
            return;
        }// end function

        protected function set allowItemSizeChangeNotification(param1:Boolean) : void
        {
            listContent.allowItemSizeChangeNotification = param1;
            return;
        }// end function

        public function get iconFunction() : Function
        {
            return _iconFunction;
        }// end function

        protected function collectionChangeHandler(event:Event) : void
        {
            var len:int;
            var index:int;
            var i:int;
            var data:ListBaseSelectionData;
            var p:String;
            var selectedUID:String;
            var ce:CollectionEvent;
            var emitEvent:Boolean;
            var oldUID:String;
            var sd:ListBaseSelectionData;
            var requiresValueCommit:Boolean;
            var firstUID:String;
            var uid:String;
            var deletedItems:Array;
            var fakeRemove:CollectionEvent;
            var event:* = event;
            if (event is CollectionEvent)
            {
                ce = CollectionEvent(event);
                if (ce.kind == CollectionEventKind.ADD)
                {
                    prepareDataEffect(ce);
                    if (ce.location == 0 && verticalScrollPosition == 0)
                    {
                        try
                        {
                            iterator.seek(CursorBookmark.FIRST);
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, 0);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                        }
                    }
                    else if (listType == "vertical" && verticalScrollPosition >= ce.location)
                    {
                        super.verticalScrollPosition = super.verticalScrollPosition + ce.items.length;
                    }
                    emitEvent = adjustAfterAdd(ce.items, ce.location);
                    if (emitEvent)
                    {
                        dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
                    }
                }
                else if (ce.kind == CollectionEventKind.REPLACE)
                {
                    selectedUID = selectedItem ? (itemToUID(selectedItem)) : (null);
                    len = ce.items.length;
                    i;
                    while (i < len)
                    {
                        
                        oldUID = itemToUID(ce.items[i].oldValue);
                        sd = selectedData[oldUID];
                        if (sd)
                        {
                            sd.data = ce.items[i].newValue;
                            delete selectedData[oldUID];
                            selectedData[itemToUID(sd.data)] = sd;
                            if (selectedUID == oldUID)
                            {
                                _selectedItem = sd.data;
                                dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
                            }
                        }
                        i = (i + 1);
                    }
                    prepareDataEffect(ce);
                }
                else if (ce.kind == CollectionEventKind.REMOVE)
                {
                    prepareDataEffect(ce);
                    requiresValueCommit;
                    if (listItems.length && listItems[0].length)
                    {
                        firstUID = rowMap[listItems[0][0].name].uid;
                        selectedUID = selectedItem ? (itemToUID(selectedItem)) : (null);
                        i;
                        while (i < ce.items.length)
                        {
                            
                            uid = itemToUID(ce.items[i]);
                            if (uid == firstUID && verticalScrollPosition == 0)
                            {
                                try
                                {
                                    iterator.seek(CursorBookmark.FIRST);
                                    if (!iteratorValid)
                                    {
                                        iteratorValid = true;
                                        lastSeekPending = null;
                                    }
                                }
                                catch (e1:ItemPendingError)
                                {
                                    lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, 0);
                                    e1.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                                    iteratorValid = false;
                                }
                            }
                            if (selectedData[uid])
                            {
                                removeSelectionData(uid);
                            }
                            if (selectedUID == uid)
                            {
                                _selectedItem = null;
                                _selectedIndex = -1;
                                requiresValueCommit;
                            }
                            removeIndicators(uid);
                            i = (i + 1);
                        }
                        if (listType == "vertical" && verticalScrollPosition >= ce.location)
                        {
                            if (verticalScrollPosition > ce.location)
                            {
                                super.verticalScrollPosition = verticalScrollPosition - Math.min(ce.items.length, verticalScrollPosition - ce.location);
                            }
                            else if (verticalScrollPosition >= collection.length)
                            {
                                super.verticalScrollPosition = Math.max((collection.length - 1), 0);
                            }
                            try
                            {
                                offscreenExtraRowsTop = Math.min(offscreenExtraRowsTop, verticalScrollPosition);
                                index = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition - offscreenExtraRowsTop);
                                iterator.seek(CursorBookmark.FIRST, index);
                                if (!iteratorValid)
                                {
                                    iteratorValid = true;
                                    lastSeekPending = null;
                                }
                            }
                            catch (e2:ItemPendingError)
                            {
                                lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, index);
                                e2.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                                iteratorValid = false;
                            }
                        }
                        emitEvent = adjustAfterRemove(ce.items, ce.location, requiresValueCommit);
                        if (emitEvent)
                        {
                            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
                        }
                    }
                }
                else if (ce.kind == CollectionEventKind.MOVE)
                {
                    if (ce.oldLocation < ce.location)
                    {
                        var _loc_3:int = 0;
                        var _loc_4:* = selectedData;
                        while (_loc_4 in _loc_3)
                        {
                            
                            p = _loc_4[_loc_3];
                            data = selectedData[p];
                            if (data.index > ce.oldLocation && data.index < ce.location)
                            {
                                var _loc_5:* = data;
                                var _loc_6:* = data.index - 1;
                                _loc_5.index = _loc_6;
                                continue;
                            }
                            if (data.index == ce.oldLocation)
                            {
                                data.index = ce.location;
                            }
                        }
                        if (_selectedIndex > ce.oldLocation && _selectedIndex < ce.location)
                        {
                            var _loc_4:* = _selectedIndex - 1;
                            _selectedIndex = _loc_4;
                        }
                        else if (_selectedIndex == ce.oldLocation)
                        {
                            _selectedIndex = ce.location;
                        }
                    }
                    else if (ce.location < ce.oldLocation)
                    {
                        var _loc_3:int = 0;
                        var _loc_4:* = selectedData;
                        while (_loc_4 in _loc_3)
                        {
                            
                            p = _loc_4[_loc_3];
                            data = selectedData[p];
                            if (data.index > ce.location && data.index < ce.oldLocation)
                            {
                                var _loc_5:* = data;
                                var _loc_6:* = data.index + 1;
                                _loc_5.index = _loc_6;
                                continue;
                            }
                            if (data.index == ce.oldLocation)
                            {
                                data.index = ce.location;
                            }
                        }
                        if (_selectedIndex > ce.location && _selectedIndex < ce.oldLocation)
                        {
                            var _loc_4:* = _selectedIndex + 1;
                            _selectedIndex = _loc_4;
                        }
                        else if (_selectedIndex == ce.oldLocation)
                        {
                            _selectedIndex = ce.location;
                        }
                    }
                    if (ce.oldLocation == verticalScrollPosition)
                    {
                        if (ce.location > maxVerticalScrollPosition)
                        {
                            iterator.seek(CursorBookmark.CURRENT, maxVerticalScrollPosition - ce.location);
                        }
                        super.verticalScrollPosition = Math.min(ce.location, maxVerticalScrollPosition);
                    }
                    else if (ce.location >= verticalScrollPosition && ce.oldLocation < verticalScrollPosition)
                    {
                        seekNextSafely(iterator, verticalScrollPosition);
                    }
                    else if (ce.location <= verticalScrollPosition && ce.oldLocation > verticalScrollPosition)
                    {
                        seekPreviousSafely(iterator, verticalScrollPosition);
                    }
                }
                else if (ce.kind == CollectionEventKind.REFRESH)
                {
                    if (anchorBookmark)
                    {
                        try
                        {
                            iterator.seek(anchorBookmark, 0);
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            bSortItemPending = true;
                            lastSeekPending = new ListBaseSeekPending(anchorBookmark, 0);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                            ;
                        }
                        catch (cursorError:CursorError)
                        {
                            clearSelected();
                        }
                        adjustAfterSort();
                    }
                    else
                    {
                        try
                        {
                            index = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
                            iterator.seek(CursorBookmark.FIRST, index);
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            bSortItemPending = true;
                            lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, index);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                        }
                    }
                }
                else if (ce.kind == CollectionEventKind.RESET)
                {
                    if (collection.length == 0 || runningDataEffect && actualCollection.length == 0)
                    {
                        deletedItems = reconstructDataFromListItems();
                        if (deletedItems.length)
                        {
                            fakeRemove = new CollectionEvent(CollectionEvent.COLLECTION_CHANGE);
                            fakeRemove.kind = CollectionEventKind.REMOVE;
                            fakeRemove.items = deletedItems;
                            fakeRemove.location = 0;
                            prepareDataEffect(fakeRemove);
                        }
                    }
                    try
                    {
                        iterator.seek(CursorBookmark.FIRST);
                        if (!iteratorValid)
                        {
                            iteratorValid = true;
                            lastSeekPending = null;
                        }
                        collectionIterator.seek(CursorBookmark.FIRST);
                    }
                    catch (e:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, 0);
                        e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                    }
                    if (bSelectedIndexChanged || bSelectedItemChanged || bSelectedIndicesChanged || bSelectedItemsChanged)
                    {
                        bSelectionChanged = true;
                    }
                    else
                    {
                        commitSelectedIndex(-1);
                    }
                    if (isNaN(verticalScrollPositionPending))
                    {
                        verticalScrollPositionPending = 0;
                        super.verticalScrollPosition = 0;
                    }
                    if (isNaN(horizontalScrollPositionPending))
                    {
                        horizontalScrollPositionPending = 0;
                        super.horizontalScrollPosition = 0;
                    }
                    invalidateSize();
                }
                else if (ce.kind == CollectionEventKind.UPDATE)
                {
                    selectedUID = selectedItem ? (itemToUID(selectedItem)) : (null);
                    len = ce.items.length;
                    i;
                    while (i < len)
                    {
                        
                        if (ce.items[i].property == "uid")
                        {
                            oldUID = ce.items[i].oldValue;
                            sd = selectedData[oldUID];
                            if (sd)
                            {
                                sd.data = ce.items[i].target;
                                delete selectedData[oldUID];
                                selectedData[ce.items[i].newValue] = sd;
                                if (selectedUID == oldUID)
                                {
                                    _selectedItem = sd.data;
                                    dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
                                }
                            }
                        }
                        i = (i + 1);
                    }
                }
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        public function set dataProvider(param1:Object) : void
        {
            var _loc_3:XMLList = null;
            var _loc_4:Array = null;
            if (collection)
            {
                collection.removeEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler);
            }
            if (param1 is Array)
            {
                collection = new ArrayCollection(param1 as Array);
            }
            else if (param1 is ICollectionView)
            {
                collection = ICollectionView(param1);
            }
            else if (param1 is IList)
            {
                collection = new ListCollectionView(IList(param1));
            }
            else if (param1 is XMLList)
            {
                collection = new XMLListCollection(param1 as XMLList);
            }
            else if (param1 is XML)
            {
                _loc_3 = new XMLList();
                _loc_3 = _loc_3 + param1;
                collection = new XMLListCollection(_loc_3);
            }
            else
            {
                _loc_4 = [];
                if (param1 != null)
                {
                    _loc_4.push(param1);
                }
                collection = new ArrayCollection(_loc_4);
            }
            iterator = collection.createCursor();
            collectionIterator = collection.createCursor();
            collection.addEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false, 0, true);
            clearSelectionData();
            var _loc_2:* = new CollectionEvent(CollectionEvent.COLLECTION_CHANGE);
            _loc_2.kind = CollectionEventKind.RESET;
            collectionChangeHandler(_loc_2);
            dispatchEvent(_loc_2);
            itemsNeedMeasurement = true;
            invalidateProperties();
            invalidateSize();
            invalidateDisplayList();
            return;
        }// end function

        protected function destroyRow(param1:int, param2:int) : void
        {
            var _loc_3:IListItemRenderer = null;
            var _loc_4:* = rowInfo[param1].uid;
            removeIndicators(_loc_4);
            var _loc_5:int = 0;
            while (_loc_5 < param2)
            {
                
                _loc_3 = listItems[param1][_loc_5];
                if (_loc_3.data)
                {
                    delete visibleData[_loc_4];
                }
                addToFreeItemRenderers(_loc_3);
                _loc_5++;
            }
            return;
        }// end function

        protected function dragDropHandler(event:DragEvent) : void
        {
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            var _loc_4:Array = null;
            var _loc_5:int = 0;
            if (event.isDefaultPrevented())
            {
                return;
            }
            hideDropFeedback(event);
            lastDragEvent = null;
            resetDragScrolling();
            if (enabled && event.dragSource.hasFormat("items"))
            {
                if (!dataProvider)
                {
                    dataProvider = [];
                }
                _loc_2 = event.dragSource.dataForFormat("items") as Array;
                _loc_3 = calculateDropIndex(event);
                if (event.action == DragManager.MOVE && dragMoveEnabled)
                {
                    if (event.dragInitiator == this)
                    {
                        _loc_4 = selectedIndices;
                        _loc_4.sort(Array.NUMERIC);
                        _loc_5 = _loc_4.length - 1;
                        while (_loc_5 >= 0)
                        {
                            
                            collectionIterator.seek(CursorBookmark.FIRST, _loc_4[_loc_5]);
                            if (_loc_4[_loc_5] < _loc_3)
                            {
                                _loc_3 = _loc_3 - 1;
                            }
                            collectionIterator.remove();
                            _loc_5 = _loc_5 - 1;
                        }
                        clearSelected(false);
                    }
                }
                collectionIterator.seek(CursorBookmark.FIRST, _loc_3);
                _loc_5 = _loc_2.length - 1;
                while (_loc_5 >= 0)
                {
                    
                    if (event.action == DragManager.COPY)
                    {
                        collectionIterator.insert(copyItemWithUID(_loc_2[_loc_5]));
                    }
                    else if (event.action == DragManager.MOVE)
                    {
                        collectionIterator.insert(_loc_2[_loc_5]);
                    }
                    _loc_5 = _loc_5 - 1;
                }
            }
            lastDragEvent = null;
            return;
        }// end function

        public function get dataTipFunction() : Function
        {
            return _dataTipFunction;
        }// end function

        public function scrollToIndex(param1:int) : Boolean
        {
            var _loc_2:int = 0;
            if (param1 >= verticalScrollPosition + listItems.length - offscreenExtraRowsBottom || param1 < verticalScrollPosition)
            {
                _loc_2 = Math.min(param1, maxVerticalScrollPosition);
                verticalScrollPosition = _loc_2;
                return true;
            }
            return false;
        }// end function

        protected function addToFreeItemRenderers(param1:IListItemRenderer) : void
        {
            DisplayObject(param1).visible = false;
            var _loc_2:* = factoryMap[param1];
            var _loc_3:* = dataItemWrappersByRenderer[param1];
            var _loc_4:* = _loc_3 ? (itemToUID(_loc_3)) : (itemToUID(param1.data));
            if (visibleData[_loc_4] == param1)
            {
                delete visibleData[_loc_4];
            }
            if (_loc_3)
            {
                reservedItemRenderers[itemToUID(_loc_3)] = param1;
            }
            else
            {
                if (!freeItemRenderersByFactory)
                {
                    freeItemRenderersByFactory = new Dictionary(true);
                }
                if (freeItemRenderersByFactory[_loc_2] == undefined)
                {
                    freeItemRenderersByFactory[_loc_2] = new Dictionary(true);
                }
                freeItemRenderersByFactory[_loc_2][param1] = 1;
                if (_loc_2 == itemRenderer)
                {
                    freeItemRenderers.push(param1);
                }
            }
            delete rowMap[param1.name];
            return;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (ListBase.createAccessibilityImplementation != null)
            {
                ListBase.createAccessibilityImplementation(this);
            }
            return;
        }// end function

        public function isItemSelectable(param1:Object) : Boolean
        {
            if (!selectable)
            {
                return false;
            }
            if (param1 == null)
            {
                return false;
            }
            return true;
        }// end function

        private function findPendingFailureHandler(param1:Object, param2:ListBaseFindPending) : void
        {
            return;
        }// end function

        public function get rowHeight() : Number
        {
            return _rowHeight;
        }// end function

        public function get data() : Object
        {
            return _data;
        }// end function

        function adjustOffscreenRowsAndColumns() : void
        {
            offscreenExtraColumns = 0;
            offscreenExtraRows = offscreenExtraRowsOrColumns;
            return;
        }// end function

        protected function indexToRow(param1:int) : int
        {
            return param1;
        }// end function

        protected function get dragImageOffsets() : Point
        {
            var _loc_1:* = new Point();
            var _loc_2:* = listItems.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (selectedData[rowInfo[_loc_3].uid])
                {
                    _loc_1.x = listItems[_loc_3][0].x;
                    _loc_1.y = listItems[_loc_3][0].y;
                }
                _loc_3++;
            }
            return _loc_1;
        }// end function

        public function get dataProvider() : Object
        {
            if (actualCollection)
            {
                return actualCollection;
            }
            return collection;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (IS_ITEM_STYLE[param1])
            {
                itemsSizeChanged = true;
                invalidateDisplayList();
            }
            else if (param1 == "paddingTop")
            {
                cachedPaddingTopInvalid = true;
                invalidateProperties();
            }
            else if (param1 == "paddingBottom")
            {
                cachedPaddingBottomInvalid = true;
                invalidateProperties();
            }
            else if (param1 == "verticalAlign")
            {
                cachedVerticalAlignInvalid = true;
                invalidateProperties();
            }
            else if (param1 == "itemsChangeEffect")
            {
                cachedItemsChangeEffect = null;
            }
            else if (listContent && listItems)
            {
                _loc_2 = listItems.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    _loc_4 = listItems[_loc_3].length;
                    _loc_5 = 0;
                    while (_loc_5 < _loc_4)
                    {
                        
                        if (listItems[_loc_3][_loc_5])
                        {
                            listItems[_loc_3][_loc_5].styleChanged(param1);
                        }
                        _loc_5++;
                    }
                    _loc_3++;
                }
            }
            super.styleChanged(param1);
            if (invalidateSizeFlag)
            {
                itemsNeedMeasurement = true;
                invalidateProperties();
            }
            if (StyleManager.isSizeInvalidatingStyle(param1))
            {
                scrollAreaChanged = true;
            }
            return;
        }// end function

        private function selectionPendingResultHandler(param1:Object, param2:ListBaseSelectionPending) : void
        {
            iterator.seek(param2.bookmark, param2.offset);
            shiftSelectionLoop(param2.incrementing, param2.index, param2.stopData, param2.transition, param2.placeHolder);
            return;
        }// end function

        public function set selectedItems(param1:Array) : void
        {
            if (!collection || collection.length == 0)
            {
                _selectedItems = param1;
                bSelectedItemsChanged = true;
                bSelectionChanged = true;
                invalidateDisplayList();
                return;
            }
            commitSelectedItems(param1);
            return;
        }// end function

        public function itemToDataTip(param1:Object) : String
        {
            var data:* = param1;
            if (data == null)
            {
                return " ";
            }
            if (dataTipFunction != null)
            {
                return dataTipFunction(data);
            }
            if (data is XML)
            {
                try
                {
                    if (data[dataTipField].length() != 0)
                    {
                        data = data[dataTipField];
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
                    if (data[dataTipField] != null)
                    {
                        data = data[dataTipField];
                    }
                    else if (data.label != null)
                    {
                        data = data.label;
                    }
                }
                catch (e:Error)
                {
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

        protected function dragStartHandler(event:DragEvent) : void
        {
            var _loc_2:DragSource = null;
            if (event.isDefaultPrevented())
            {
                return;
            }
            _loc_2 = new DragSource();
            addDragData(_loc_2);
            DragManager.doDrag(this, _loc_2, event, dragImage, 0, 0, 0.5, dragMoveEnabled);
            return;
        }// end function

        private function cleanupAfterDataChangeEffect() : void
        {
            if (runningDataEffect || runDataEffectNextUpdate)
            {
                return;
            }
            var _loc_1:* = scrollPositionToIndex(horizontalScrollPosition - offscreenExtraColumnsLeft, verticalScrollPosition - offscreenExtraRowsTop);
            iterator.seek(CursorBookmark.FIRST, _loc_1);
            dataEffectCompleted = true;
            itemsSizeChanged = true;
            invalidateList();
            dataItemWrappersByRenderer = new Dictionary();
            return;
        }// end function

        function setBookmarkPendingResultHandler(param1:Object, param2:Object) : void
        {
            var placeHolder:CursorBookmark;
            var data:* = param1;
            var info:* = param2;
            placeHolder = iterator.bookmark;
            try
            {
                iterator.seek(CursorBookmark.FIRST, info.value);
                this[info.property] = iterator.bookmark;
            }
            catch (e:ItemPendingError)
            {
                e.addResponder(new ItemResponder(setBookmarkPendingResultHandler, setBookmarkPendingFailureHandler, info));
            }
            iterator.seek(placeHolder);
            return;
        }// end function

        protected function removeIndicators(param1:String) : void
        {
            if (selectionTweens[param1])
            {
                selectionTweens[param1].removeEventListener(TweenEvent.TWEEN_UPDATE, selectionTween_updateHandler);
                selectionTweens[param1].removeEventListener(TweenEvent.TWEEN_END, selectionTween_endHandler);
                if (selectionIndicators[param1].alpha < 1)
                {
                    Tween.removeTween(selectionTweens[param1]);
                }
                delete selectionTweens[param1];
            }
            if (selectionIndicators[param1])
            {
                selectionIndicators[param1].parent.removeChild(selectionIndicators[param1]);
                selectionIndicators[param1] = null;
            }
            if (param1 == highlightUID)
            {
                highlightItemRenderer = null;
                highlightUID = null;
                clearHighlightIndicator(highlightIndicator, UIDToItemRenderer(param1));
            }
            if (param1 == caretUID)
            {
                caretItemRenderer = null;
                caretUID = null;
                clearCaretIndicator(caretIndicator, UIDToItemRenderer(param1));
            }
            return;
        }// end function

        private function mouseIsUp() : void
        {
            systemManager.getSandboxRoot().removeEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, true);
            systemManager.getSandboxRoot().removeEventListener(SandboxMouseEvent.MOUSE_UP_SOMEWHERE, mouseLeaveHandler);
            if (!dragEnabled && dragScrollingInterval != 0)
            {
                clearInterval(dragScrollingInterval);
                dragScrollingInterval = 0;
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:CursorBookmark = null;
            var _loc_6:int = 0;
            super.updateDisplayList(param1, param2);
            if (oldUnscaledWidth == param1 && oldUnscaledHeight == param2 && !itemsSizeChanged && !bSelectionChanged && !scrollAreaChanged)
            {
                return;
            }
            if (oldUnscaledWidth != param1)
            {
                itemsSizeChanged = true;
            }
            removeClipMask();
            var _loc_4:* = selectionLayer.graphics;
            selectionLayer.graphics.clear();
            if (listContent.width > 0 && listContent.height > 0)
            {
                _loc_4.beginFill(8421504, 0);
                _loc_4.drawRect(0, 0, listContent.width, listContent.height);
                _loc_4.endFill();
            }
            if (rendererChanged)
            {
                purgeItemRenderers();
            }
            else if (dataEffectCompleted)
            {
                partialPurgeItemRenderers();
            }
            adjustListContent(param1, param2);
            var _loc_5:* = collection && collection.length > 0;
            if (collection && collection.length > 0)
            {
                adjustScrollPosition();
            }
            if (oldUnscaledWidth == param1 && !scrollAreaChanged && !itemsSizeChanged && listItems.length > 0 && iterator && columnCount == 1)
            {
                _loc_6 = listItems.length - 1;
                if (oldUnscaledHeight > param2)
                {
                    reduceRows(_loc_6);
                }
                else
                {
                    makeAdditionalRows(_loc_6);
                }
            }
            else
            {
                if (iterator)
                {
                    _loc_3 = iterator.bookmark;
                }
                clearIndicators();
                rendererTrackingSuspended = true;
                if (iterator)
                {
                    if (offscreenExtraColumns || offscreenExtraColumnsLeft || offscreenExtraColumnsRight)
                    {
                        makeRowsAndColumnsWithExtraColumns(param1, param2);
                    }
                    else
                    {
                        makeRowsAndColumnsWithExtraRows(param1, param2);
                    }
                }
                else
                {
                    makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
                }
                rendererTrackingSuspended = false;
                seekPositionIgnoreError(iterator, _loc_3);
            }
            oldUnscaledWidth = param1;
            oldUnscaledHeight = param2;
            configureScrollBars();
            addClipMask(true);
            itemsSizeChanged = false;
            wordWrapChanged = false;
            adjustSelectionSettings(_loc_5);
            if (keySelectionPending && iteratorValid)
            {
                keySelectionPending = false;
                finishKeySelection();
            }
            return;
        }// end function

        protected function dragCompleteHandler(event:DragEvent) : void
        {
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            isPressed = false;
            if (event.isDefaultPrevented())
            {
                return;
            }
            if (event.action == DragManager.MOVE && dragMoveEnabled)
            {
                if (event.relatedObject != this)
                {
                    _loc_2 = selectedIndices;
                    _loc_2.sort(Array.NUMERIC);
                    _loc_3 = _loc_2.length;
                    _loc_4 = _loc_3 - 1;
                    while (_loc_4 >= 0)
                    {
                        
                        collectionIterator.seek(CursorBookmark.FIRST, _loc_2[_loc_4]);
                        collectionIterator.remove();
                        _loc_4 = _loc_4 - 1;
                    }
                    clearSelected(false);
                }
            }
            lastDragEvent = null;
            resetDragScrolling();
            return;
        }// end function

        public function getItemRendererFactory(param1:Object) : IFactory
        {
            if (param1 == null)
            {
                return nullItemRenderer;
            }
            return itemRenderer;
        }// end function

    }
}
