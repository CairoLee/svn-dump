package mx.controls.listClasses
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.controls.scrollClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class TileBase extends ListBase
    {
        private var _direction:String = "horizontal";
        private var lastRowCount:int = 0;
        private var _maxRows:int = 0;
        private var bSelectItem:Boolean = false;
        private var bCtrlKey:Boolean = false;
        private var lastColumnCount:int = 0;
        private var lastKey:uint = 0;
        private var _maxColumns:int = 0;
        protected var measuringObjects:Dictionary;
        private var bShiftKey:Boolean = false;
        static const VERSION:String = "3.5.0.12683";

        public function TileBase()
        {
            itemRenderer = new ClassFactory(TileListItemRenderer);
            setRowHeight(50);
            setColumnWidth(50);
            return;
        }// end function

        override public function measureWidthOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Number = NaN;
            var _loc_5:ListData = null;
            var _loc_7:Object = null;
            var _loc_8:Object = null;
            var _loc_9:IFactory = null;
            var _loc_6:Boolean = false;
            if (collection && collection.length)
            {
                _loc_7 = iterator.current;
                _loc_8 = _loc_7 is ItemWrapper ? (_loc_7.data) : (_loc_7);
                if (!measuringObjects)
                {
                    measuringObjects = new Dictionary(true);
                }
                _loc_9 = getItemRendererFactory(_loc_8);
                _loc_3 = measuringObjects[_loc_9];
                if (!_loc_3)
                {
                    _loc_3 = getMeasuringRenderer(_loc_8);
                    _loc_6 = true;
                }
                _loc_5 = ListData(makeListData(_loc_8, uid, 0, 0));
                if (_loc_3 is IDropInListItemRenderer)
                {
                    IDropInListItemRenderer(_loc_3).listData = _loc_8 ? (_loc_5) : (null);
                }
                _loc_3.data = _loc_8;
                UIComponentGlobals.layoutManager.validateClient(_loc_3, true);
                _loc_4 = _loc_3.getExplicitOrMeasuredWidth();
                if (_loc_6)
                {
                    _loc_3.setActualSize(_loc_4, _loc_3.getExplicitOrMeasuredHeight());
                    _loc_6 = false;
                }
            }
            if (isNaN(_loc_4) || _loc_4 == 0)
            {
                _loc_4 = 50;
            }
            return _loc_4 * param2;
        }// end function

        override public function indexToItemRenderer(param1:int) : IListItemRenderer
        {
            var _loc_2:* = indexToRow(param1);
            if (_loc_2 < verticalScrollPosition || _loc_2 >= verticalScrollPosition + rowCount)
            {
                return null;
            }
            var _loc_3:* = indexToColumn(param1);
            if (_loc_3 < horizontalScrollPosition || _loc_3 >= horizontalScrollPosition + columnCount)
            {
                return null;
            }
            return listItems[_loc_2 - verticalScrollPosition][_loc_3 - horizontalScrollPosition];
        }// end function

        public function set direction(param1:String) : void
        {
            _direction = param1;
            itemsSizeChanged = true;
            offscreenExtraRowsOrColumnsChanged = true;
            if (listContent)
            {
                if (direction == TileBaseDirection.HORIZONTAL)
                {
                    var _loc_2:int = 0;
                    listContent.rightOffset = 0;
                    listContent.leftOffset = _loc_2;
                    var _loc_2:int = 0;
                    offscreenExtraColumnsRight = 0;
                    offscreenExtraColumnsLeft = _loc_2;
                }
                else
                {
                    var _loc_2:int = 0;
                    listContent.bottomOffset = 0;
                    listContent.topOffset = _loc_2;
                    var _loc_2:int = 0;
                    offscreenExtraRowsBottom = 0;
                    offscreenExtraRowsTop = _loc_2;
                }
            }
            invalidateProperties();
            invalidateSize();
            invalidateDisplayList();
            dispatchEvent(new Event("directionChanged"));
            return;
        }// end function

        public function get direction() : String
        {
            return _direction;
        }// end function

        override function reconstructDataFromListItems() : Array
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:IListItemRenderer = null;
            var _loc_5:Object = null;
            if (direction == TileBaseDirection.HORIZONTAL || !listItems)
            {
                return super.reconstructDataFromListItems();
            }
            var _loc_1:Array = [];
            if (listItems.length > 0)
            {
                _loc_2 = 0;
                while (_loc_2 < listItems[0].length)
                {
                    
                    _loc_3 = 0;
                    while (_loc_3 < listItems.length)
                    {
                        
                        if (listItems[_loc_3] && listItems[_loc_3].length > _loc_2)
                        {
                            _loc_4 = listItems[_loc_3][_loc_2] as IListItemRenderer;
                            if (_loc_4)
                            {
                                _loc_5 = _loc_4.data;
                                _loc_1.push(_loc_5);
                            }
                        }
                        _loc_3++;
                    }
                    _loc_2++;
                }
            }
            return _loc_1;
        }// end function

        override protected function moveSelectionHorizontally(param1:uint, param2:Boolean, param3:Boolean) : void
        {
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:IListItemRenderer = null;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:Boolean = false;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_16:ScrollEvent = null;
            var _loc_12:* = listItems[0].length - offscreenExtraColumnsLeft - offscreenExtraColumnsRight;
            var _loc_13:* = maxColumns > 0 && direction != TileBaseDirection.VERTICAL ? (maxColumns) : (_loc_12);
            var _loc_14:* = displayingPartialRow() ? (1) : (0);
            var _loc_15:* = displayingPartialColumn() ? (1) : (0);
            if (!collection)
            {
                return;
            }
            showCaret = true;
            switch(param1)
            {
                case Keyboard.LEFT:
                {
                    if (caretIndex > 0)
                    {
                        if (direction == TileBaseDirection.HORIZONTAL)
                        {
                            var _loc_18:* = caretIndex - 1;
                            caretIndex = _loc_18;
                        }
                        else
                        {
                            _loc_10 = indexToRow(caretIndex);
                            _loc_11 = indexToColumn(caretIndex);
                            if (_loc_11 == 0)
                            {
                                _loc_10 = _loc_10 - 1;
                                _loc_11 = lastColumnInRow(_loc_10);
                            }
                            else
                            {
                                _loc_11 = _loc_11 - 1;
                            }
                            caretIndex = Math.min(indicesToIndex(_loc_10, _loc_11), (collection.length - 1));
                        }
                        _loc_10 = indexToRow(caretIndex);
                        _loc_11 = indexToColumn(caretIndex);
                        if (direction == TileBaseDirection.HORIZONTAL)
                        {
                            if (_loc_10 < verticalScrollPosition)
                            {
                                _loc_4 = verticalScrollPosition - 1;
                            }
                            else if (_loc_10 > verticalScrollPosition + rowCount - _loc_14)
                            {
                                _loc_4 = maxVerticalScrollPosition;
                            }
                        }
                        else if (_loc_11 < horizontalScrollPosition)
                        {
                            _loc_5 = horizontalScrollPosition - 1;
                        }
                        else if (_loc_11 > horizontalScrollPosition + _loc_12 - 1 - _loc_15)
                        {
                            _loc_5 = maxHorizontalScrollPosition;
                        }
                    }
                    break;
                }
                case Keyboard.RIGHT:
                {
                    if (caretIndex < (collection.length - 1))
                    {
                        if (direction == TileBaseDirection.HORIZONTAL || caretIndex == -1)
                        {
                            var _loc_18:* = caretIndex + 1;
                            caretIndex = _loc_18;
                        }
                        else
                        {
                            _loc_10 = indexToRow(caretIndex);
                            _loc_11 = indexToColumn(caretIndex);
                            if (_loc_11 == lastColumnInRow(_loc_10))
                            {
                                _loc_11 = 0;
                                _loc_10++;
                            }
                            else
                            {
                                _loc_11++;
                            }
                            caretIndex = Math.min(indicesToIndex(_loc_10, _loc_11), (collection.length - 1));
                        }
                        _loc_10 = indexToRow(caretIndex);
                        _loc_11 = indexToColumn(caretIndex);
                        if (direction == TileBaseDirection.HORIZONTAL)
                        {
                            if (_loc_10 >= verticalScrollPosition + rowCount - _loc_14 && verticalScrollPosition < maxVerticalScrollPosition)
                            {
                                _loc_4 = verticalScrollPosition + 1;
                            }
                            if (_loc_10 < verticalScrollPosition)
                            {
                                _loc_4 = _loc_10;
                            }
                        }
                        else
                        {
                            if (_loc_11 >= horizontalScrollPosition + _loc_12 - _loc_15 && horizontalScrollPosition < maxHorizontalScrollPosition)
                            {
                                _loc_5 = horizontalScrollPosition + 1;
                            }
                            if (_loc_11 < horizontalScrollPosition)
                            {
                                _loc_5 = _loc_11;
                            }
                        }
                    }
                    break;
                }
                case Keyboard.PAGE_UP:
                {
                    if (caretIndex < 0)
                    {
                        caretIndex = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
                    }
                    _loc_10 = indexToRow(caretIndex);
                    _loc_11 = indexToColumn(caretIndex);
                    if (_loc_11 > 0)
                    {
                        var _loc_17:* = Math.max(horizontalScrollPosition - (_loc_12 - _loc_15), 0);
                        _loc_11 = Math.max(horizontalScrollPosition - (_loc_12 - _loc_15), 0);
                        _loc_5 = _loc_17;
                        caretIndex = indicesToIndex(_loc_10, _loc_11);
                    }
                    break;
                }
                case Keyboard.PAGE_DOWN:
                {
                    if (caretIndex < 0)
                    {
                        caretIndex = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
                    }
                    _loc_10 = indexToRow(caretIndex);
                    _loc_11 = indexToColumn(caretIndex);
                    if (_loc_11 < maxHorizontalScrollPosition)
                    {
                        _loc_11 = Math.min(horizontalScrollPosition + _loc_12 - _loc_15, indexToColumn((collection.length - 1)));
                        if (_loc_11 > horizontalScrollPosition)
                        {
                            _loc_5 = Math.min(_loc_11, maxHorizontalScrollPosition);
                        }
                        caretIndex = indicesToIndex(_loc_10, _loc_11);
                    }
                    break;
                }
                case Keyboard.HOME:
                {
                    if (collection.length)
                    {
                        caretIndex = 0;
                        _loc_5 = 0;
                        _loc_4 = 0;
                    }
                    break;
                }
                case Keyboard.END:
                {
                    if (caretIndex < collection.length)
                    {
                        caretIndex = collection.length - 1;
                        _loc_5 = maxHorizontalScrollPosition;
                        _loc_4 = maxVerticalScrollPosition;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (!isNaN(_loc_4))
            {
                if (_loc_4 != verticalScrollPosition)
                {
                    _loc_16 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_16.detail = ScrollEventDetail.THUMB_POSITION;
                    _loc_16.direction = ScrollEventDirection.VERTICAL;
                    _loc_16.delta = _loc_4 - verticalScrollPosition;
                    _loc_16.position = _loc_4;
                    verticalScrollPosition = _loc_4;
                    dispatchEvent(_loc_16);
                }
            }
            if (iteratorValid)
            {
                if (!isNaN(_loc_5))
                {
                    if (_loc_5 != horizontalScrollPosition)
                    {
                        _loc_16 = new ScrollEvent(ScrollEvent.SCROLL);
                        _loc_16.detail = ScrollEventDetail.THUMB_POSITION;
                        _loc_16.direction = ScrollEventDirection.HORIZONTAL;
                        _loc_16.delta = _loc_5 - horizontalScrollPosition;
                        _loc_16.position = _loc_5;
                        horizontalScrollPosition = _loc_5;
                        dispatchEvent(_loc_16);
                    }
                }
            }
            if (!iteratorValid)
            {
                keySelectionPending = true;
                return;
            }
            bShiftKey = param2;
            bCtrlKey = param3;
            lastKey = param1;
            finishKeySelection();
            return;
        }// end function

        override function removeClipMask() : void
        {
            return;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (itemsNeedMeasurement)
            {
                itemsNeedMeasurement = false;
                if (isNaN(explicitRowHeight))
                {
                    setRowHeight(measureHeightOfItems(0, 1));
                }
                if (isNaN(explicitColumnWidth))
                {
                    setColumnWidth(measureWidthOfItems(0, 1));
                }
            }
            return;
        }// end function

        override public function scrollToIndex(param1:int) : Boolean
        {
            var newVPos:int;
            var newHPos:int;
            var index:* = param1;
            var firstIndex:* = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
            var numItemsVisible:* = (listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom) * (listItems[0].length - offscreenExtraColumnsLeft - offscreenExtraColumnsRight);
            if (index >= firstIndex + numItemsVisible || index < firstIndex)
            {
                newVPos = Math.min(indexToRow(index), maxVerticalScrollPosition);
                newHPos = Math.min(indexToColumn(index), maxHorizontalScrollPosition);
                try
                {
                    iterator.seek(CursorBookmark.FIRST, scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition));
                    super.horizontalScrollPosition = newHPos;
                    super.verticalScrollPosition = newVPos;
                }
                catch (e:ItemPendingError)
                {
                }
                return true;
            }
            return false;
        }// end function

        override public function createItemRenderer(param1:Object) : IListItemRenderer
        {
            var _loc_2:IFactory = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Dictionary = null;
            var _loc_5:* = undefined;
            _loc_2 = getItemRendererFactory(param1);
            if (!_loc_2)
            {
                if (!param1)
                {
                    _loc_2 = nullItemRenderer;
                }
                if (!_loc_2)
                {
                    _loc_2 = itemRenderer;
                }
            }
            if (_loc_2 == itemRenderer)
            {
                if (freeItemRenderers && freeItemRenderers.length && freeItemRenderersByFactory[_loc_2])
                {
                    _loc_3 = freeItemRenderers.pop();
                    delete freeItemRenderersByFactory[_loc_2][_loc_3];
                }
            }
            else if (freeItemRenderersByFactory)
            {
                _loc_4 = freeItemRenderersByFactory[_loc_2];
                if (_loc_4)
                {
                    for (_loc_5 in _loc_4)
                    {
                        
                        _loc_3 = IListItemRenderer(_loc_5);
                        delete _loc_4[_loc_5];
                        break;
                    }
                }
            }
            if (!_loc_3)
            {
                _loc_3 = _loc_2.newInstance();
                _loc_3.styleName = this;
                factoryMap[_loc_3] = _loc_2;
            }
            _loc_3.owner = this;
            return _loc_3;
        }// end function

        protected function drawTileBackgrounds() : void
        {
            var _loc_2:Array = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:IListItemRenderer = null;
            var _loc_10:int = 0;
            var _loc_11:DisplayObject = null;
            var _loc_1:* = Sprite(listContent.getChildByName("tileBGs"));
            if (!_loc_1)
            {
                _loc_1 = new FlexSprite();
                _loc_1.mouseEnabled = false;
                _loc_1.name = "tileBGs";
                listContent.addChildAt(_loc_1, 0);
            }
            _loc_2 = getStyle("alternatingItemColors");
            if (!_loc_2 || _loc_2.length == 0)
            {
                while (_loc_1.numChildren > _loc_5)
                {
                    
                    _loc_1.removeChildAt((_loc_1.numChildren - 1));
                }
                return;
            }
            StyleManager.getColorNames(_loc_2);
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            while (_loc_4 < rowCount)
            {
                
                _loc_6 = 0;
                while (_loc_6 < columnCount)
                {
                    
                    _loc_7 = _loc_4 < (rowCount - 1) ? (rowHeight) : (Math.min(rowHeight, listContent.height - (rowCount - 1) * rowHeight));
                    _loc_8 = _loc_6 < (columnCount - 1) ? (columnWidth) : (Math.min(columnWidth, listContent.width - (columnCount - 1) * columnWidth));
                    _loc_9 = listItems[_loc_4] ? (listItems[_loc_4][_loc_6]) : (null);
                    _loc_10 = (verticalScrollPosition + _loc_4) * columnCount + (horizontalScrollPosition + _loc_6);
                    _loc_11 = drawTileBackground(_loc_1, _loc_4, _loc_6, _loc_8, _loc_7, _loc_2[_loc_10 % _loc_2.length], _loc_9);
                    _loc_11.y = _loc_4 * rowHeight;
                    _loc_11.x = _loc_6 * columnWidth;
                    _loc_6++;
                }
                _loc_4++;
            }
            _loc_5 = rowCount * columnCount;
            while (_loc_1.numChildren > _loc_5)
            {
                
                _loc_1.removeChildAt((_loc_1.numChildren - 1));
            }
            return;
        }// end function

        private function displayingPartialRow() : Boolean
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_1:* = listItems[(listItems.length - 1) - offscreenExtraRowsBottom];
            if (_loc_1 && _loc_1.length > 0)
            {
                _loc_2 = _loc_1[0];
                if (!_loc_2 || _loc_2.y + _loc_2.height > listContent.heightExcludingOffsets - listContent.topOffset)
                {
                    return true;
                }
            }
            return false;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            listContent.mask = maskShape;
            return;
        }// end function

        override function addClipMask(param1:Boolean) : void
        {
            return;
        }// end function

        override protected function finishKeySelection() : void
        {
            var _loc_1:String = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:IListItemRenderer = null;
            var _loc_6:ListEvent = null;
            var _loc_2:Boolean = false;
            if (caretIndex < 0)
            {
                return;
            }
            _loc_3 = indexToRow(caretIndex);
            _loc_4 = indexToColumn(caretIndex);
            _loc_5 = listItems[_loc_3 - verticalScrollPosition + offscreenExtraRowsTop][_loc_4 - horizontalScrollPosition + offscreenExtraColumnsLeft];
            if (!bCtrlKey)
            {
                selectItem(_loc_5, bShiftKey, bCtrlKey);
                _loc_2 = true;
            }
            if (bCtrlKey)
            {
                _loc_1 = itemToUID(_loc_5.data);
                drawItem(visibleData[_loc_1], selectedData[_loc_1] != null, false, true);
            }
            if (_loc_2)
            {
                _loc_6 = new ListEvent(ListEvent.CHANGE);
                _loc_6.itemRenderer = _loc_5;
                _loc_6.rowIndex = _loc_3;
                _loc_6.columnIndex = _loc_4;
                dispatchEvent(_loc_6);
            }
            return;
        }// end function

        override protected function scrollPositionToIndex(param1:int, param2:int) : int
        {
            var _loc_3:int = 0;
            if (iterator)
            {
                if (direction == TileBaseDirection.HORIZONTAL)
                {
                    _loc_3 = param2 * columnCount + param1;
                }
                else
                {
                    _loc_3 = param1 * rowCount + param2;
                }
                return _loc_3;
            }
            return -1;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            if (!iteratorValid)
            {
                return;
            }
            if (!collection)
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
                    if (direction == TileBaseDirection.VERTICAL)
                    {
                        moveSelectionHorizontally(event.keyCode, event.shiftKey, event.ctrlKey);
                    }
                    else
                    {
                        moveSelectionVertically(event.keyCode, event.shiftKey, event.ctrlKey);
                    }
                    event.stopPropagation();
                    break;
                }
                case Keyboard.SPACE:
                {
                    if (caretIndex < 0)
                    {
                        break;
                    }
                    _loc_3 = indexToRow(caretIndex);
                    _loc_4 = indexToColumn(caretIndex);
                    _loc_2 = listItems[_loc_3 - verticalScrollPosition][_loc_4 - horizontalScrollPosition];
                    selectItem(_loc_2, event.shiftKey, event.ctrlKey);
                    break;
                }
                default:
                {
                    if (findKey(event.keyCode))
                    {
                        event.stopPropagation();
                    }
                    break;
                }
            }
            return;
        }// end function

        override protected function indexToColumn(param1:int) : int
        {
            var _loc_3:int = 0;
            if (direction == TileBaseDirection.VERTICAL)
            {
                _loc_3 = maxRows > 0 ? (maxRows) : (rowCount);
                return Math.floor(param1 / _loc_3);
            }
            var _loc_2:* = maxColumns > 0 ? (maxColumns) : (columnCount);
            return param1 % _loc_2;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            if (explicitColumnCount > 0 && isNaN(explicitColumnWidth))
            {
                setColumnWidth(Math.floor((width - viewMetrics.left - viewMetrics.right) / explicitColumnCount));
            }
            if (explicitRowCount > 0 && isNaN(explicitRowHeight))
            {
                setRowHeight(Math.floor((height - viewMetrics.top - viewMetrics.bottom) / explicitRowCount));
            }
            super.updateDisplayList(param1, param2);
            drawTileBackgrounds();
            return;
        }// end function

        override protected function scrollHorizontally(param1:int, param2:int, param3:Boolean) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Number = NaN;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:Number = NaN;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:IListItemRenderer = null;
            var _loc_23:int = 0;
            var _loc_24:int = 0;
            var _loc_25:Point = null;
            var _loc_26:int = 0;
            var _loc_27:IListItemRenderer = null;
            var _loc_28:int = 0;
            var _loc_29:int = 0;
            if (param2 == 0)
            {
                return;
            }
            removeClipMask();
            var _loc_10:* = offscreenExtraColumnsRight;
            var _loc_11:* = offscreenExtraColumnsLeft;
            var _loc_12:* = offscreenExtraColumns / 2;
            var _loc_13:* = offscreenExtraColumns / 2;
            if (param3)
            {
                offscreenExtraColumnsLeft = Math.min(_loc_12, offscreenExtraColumnsLeft + param2);
                _loc_14 = param2 - (offscreenExtraColumnsLeft - _loc_11);
                _loc_15 = _loc_14;
            }
            else
            {
                _loc_20 = offscreenExtraColumnsRight == 0 && listItems[0] && listItems[0].length > 0 && listItems[0][(listItems[0].length - 1)] && listItems[0][(listItems[0].length - 1)].x + columnWidth < listContent.widthExcludingOffsets - listContent.leftOffset ? (1) : (0);
                offscreenExtraColumnsLeft = Math.min(_loc_12, param1);
                offscreenExtraColumnsRight = Math.min(offscreenExtraColumnsRight + param2 - _loc_20, _loc_13);
                _loc_14 = param2 - (_loc_11 - offscreenExtraColumnsLeft);
                _loc_16 = offscreenExtraColumnsLeft - _loc_11 + _loc_20 + (offscreenExtraColumnsRight - _loc_10);
                _loc_15 = param2 - (offscreenExtraColumnsRight - _loc_10) - _loc_20;
            }
            var _loc_17:* = listItems[0].length;
            var _loc_18:int = 0;
            while (_loc_18 < _loc_15)
            {
                
                _loc_21 = 0;
                while (_loc_21 < rowCount)
                {
                    
                    _loc_22 = param3 ? (listItems[_loc_21][_loc_18]) : (listItems[_loc_21][_loc_17 - _loc_18 - 1]);
                    if (_loc_22)
                    {
                        delete visibleData[rowMap[_loc_22.name].uid];
                        removeIndicators(rowMap[_loc_22.name].uid);
                        addToFreeItemRenderers(_loc_22);
                        delete rowMap[_loc_22.name];
                        if (param3)
                        {
                            listItems[_loc_21][_loc_18] = null;
                        }
                        else
                        {
                            listItems[_loc_21][_loc_17 - _loc_18 - 1] = null;
                        }
                    }
                    _loc_21++;
                }
                _loc_18++;
            }
            if (param3)
            {
                _loc_9 = _loc_14 * columnWidth;
                _loc_6 = 0;
                _loc_18 = _loc_14;
                while (_loc_18 < _loc_17)
                {
                    
                    _loc_21 = 0;
                    while (_loc_21 < rowCount)
                    {
                        
                        _loc_27 = listItems[_loc_21][_loc_18];
                        if (_loc_27)
                        {
                            _loc_22 = _loc_27;
                            _loc_27.x = _loc_22.x - _loc_9;
                            _loc_7 = rowMap[_loc_22.name].uid;
                            listItems[_loc_21][_loc_18 - _loc_14] = _loc_22;
                            rowMap[_loc_22.name].columnIndex = rowMap[_loc_22.name].columnIndex - _loc_14;
                            moveIndicatorsHorizontally(_loc_7, -_loc_9);
                        }
                        else
                        {
                            listItems[_loc_21][_loc_18 - _loc_14] = null;
                        }
                        _loc_21++;
                    }
                    _loc_6 = _loc_6 + columnWidth;
                    _loc_18++;
                }
                _loc_18 = 0;
                while (_loc_18 < _loc_14)
                {
                    
                    _loc_21 = 0;
                    while (_loc_21 < rowCount)
                    {
                        
                        listItems[_loc_21][_loc_17 - _loc_18 - 1] = null;
                        _loc_21++;
                    }
                    _loc_18++;
                }
                _loc_8 = indicesToIndex(verticalScrollPosition, horizontalScrollPosition + _loc_17 - offscreenExtraColumnsLeft - _loc_14);
                seekPositionSafely(_loc_8);
                _loc_23 = param2 + (_loc_13 - _loc_10);
                _loc_24 = listItems.length ? (listItems[0].length - _loc_14) : (0);
                allowRendererStealingDuringLayout = false;
                _loc_25 = makeRowsAndColumns(_loc_6, 0, listContent.width, listContent.height, _loc_17 - _loc_14, 0, true, _loc_23);
                allowRendererStealingDuringLayout = true;
                _loc_26 = listItems[0].length - (_loc_24 + _loc_25.x);
                if (_loc_26)
                {
                    _loc_18 = 0;
                    while (_loc_18 < listItems.length)
                    {
                        
                        _loc_21 = 0;
                        while (_loc_21 < _loc_26)
                        {
                            
                            listItems[_loc_18].pop();
                            _loc_21++;
                        }
                        _loc_18++;
                    }
                }
                _loc_8 = indicesToIndex(verticalScrollPosition, horizontalScrollPosition - offscreenExtraColumnsLeft);
                seekPositionSafely(_loc_8);
                offscreenExtraColumnsRight = Math.max(0, _loc_13 - (_loc_25.x < param2 ? (_loc_23 - _loc_25.x) : (0)));
            }
            else
            {
                if (_loc_16 < 0)
                {
                    _loc_29 = listItems[0].length + _loc_16;
                    _loc_21 = 0;
                    while (_loc_21 < rowCount)
                    {
                        
                        while (listItems[_loc_21].length > _loc_29)
                        {
                            
                            listItems[_loc_21].pop();
                        }
                        _loc_21++;
                    }
                }
                _loc_9 = _loc_14 * columnWidth;
                if (_loc_14)
                {
                    _loc_6 = _loc_9;
                }
                _loc_28 = _loc_17 + _loc_16;
                _loc_18 = _loc_28 - _loc_14 - 1;
                while (_loc_18 >= 0)
                {
                    
                    _loc_21 = 0;
                    while (_loc_21 < rowCount)
                    {
                        
                        _loc_22 = listItems[_loc_21][_loc_18];
                        if (_loc_22)
                        {
                            _loc_22.x = _loc_22.x + _loc_9;
                            _loc_7 = rowMap[_loc_22.name].uid;
                            listItems[_loc_21][_loc_18 + _loc_14] = _loc_22;
                            rowMap[_loc_22.name].columnIndex = rowMap[_loc_22.name].columnIndex + _loc_14;
                            moveIndicatorsHorizontally(_loc_7, _loc_9);
                        }
                        else
                        {
                            listItems[_loc_21][_loc_18 + _loc_14] = null;
                        }
                        _loc_21++;
                    }
                    _loc_18 = _loc_18 - 1;
                }
                _loc_18 = 0;
                while (_loc_18 < _loc_14)
                {
                    
                    _loc_21 = 0;
                    while (_loc_21 < rowCount)
                    {
                        
                        listItems[_loc_21][_loc_18] = null;
                        _loc_21++;
                    }
                    _loc_18++;
                }
                _loc_8 = indicesToIndex(verticalScrollPosition, horizontalScrollPosition - offscreenExtraColumnsLeft);
                seekPositionSafely(_loc_8);
                allowRendererStealingDuringLayout = false;
                makeRowsAndColumns(0, 0, _loc_6, listContent.height, 0, 0, true, _loc_14);
                allowRendererStealingDuringLayout = true;
                seekPositionSafely(_loc_8);
            }
            var _loc_19:* = listContent.widthExcludingOffsets;
            listContent.leftOffset = (-columnWidth) * offscreenExtraColumnsLeft;
            listContent.rightOffset = offscreenExtraColumnsRight ? (listItems[0][(listItems[0].length - 1)].x + listItems[0][(listItems[0].length - 1)].width + listContent.leftOffset - _loc_19) : (0);
            adjustListContent();
            addClipMask(false);
            return;
        }// end function

        override function adjustOffscreenRowsAndColumns() : void
        {
            if (direction == TileBaseDirection.VERTICAL)
            {
                offscreenExtraRows = 0;
                offscreenExtraColumns = offscreenExtraRowsOrColumns;
            }
            else
            {
                offscreenExtraColumns = 0;
                offscreenExtraRows = offscreenExtraRowsOrColumns;
            }
            return;
        }// end function

        override protected function moveSelectionVertically(param1:uint, param2:Boolean, param3:Boolean) : void
        {
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:IListItemRenderer = null;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:Boolean = false;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_17:ScrollEvent = null;
            var _loc_10:Boolean = false;
            var _loc_13:* = listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom;
            var _loc_14:* = maxRows > 0 && direction != TileBaseDirection.HORIZONTAL ? (maxRows) : (_loc_13);
            var _loc_15:* = displayingPartialRow() ? (1) : (0);
            var _loc_16:* = displayingPartialColumn() ? (1) : (0);
            if (!collection)
            {
                return;
            }
            showCaret = true;
            switch(param1)
            {
                case Keyboard.UP:
                {
                    if (caretIndex > 0)
                    {
                        if (direction == TileBaseDirection.VERTICAL)
                        {
                            var _loc_19:* = caretIndex - 1;
                            caretIndex = _loc_19;
                        }
                        else
                        {
                            _loc_11 = indexToRow(caretIndex);
                            _loc_12 = indexToColumn(caretIndex);
                            if (_loc_11 == 0)
                            {
                                _loc_12 = _loc_12 - 1;
                                _loc_11 = lastRowInColumn(_loc_12);
                            }
                            else
                            {
                                _loc_11 = _loc_11 - 1;
                            }
                            caretIndex = Math.min(indicesToIndex(_loc_11, _loc_12), (collection.length - 1));
                        }
                        _loc_11 = indexToRow(caretIndex);
                        _loc_12 = indexToColumn(caretIndex);
                        if (_loc_11 < verticalScrollPosition)
                        {
                            _loc_4 = verticalScrollPosition - 1;
                        }
                        if (_loc_11 > verticalScrollPosition + _loc_13 - _loc_15)
                        {
                            _loc_4 = maxVerticalScrollPosition;
                        }
                        if (_loc_12 < horizontalScrollPosition)
                        {
                            _loc_5 = horizontalScrollPosition - 1;
                        }
                    }
                    break;
                }
                case Keyboard.DOWN:
                {
                    if (caretIndex < (collection.length - 1))
                    {
                        if (direction == TileBaseDirection.VERTICAL || caretIndex == -1)
                        {
                            var _loc_19:* = caretIndex + 1;
                            caretIndex = _loc_19;
                        }
                        else
                        {
                            _loc_11 = indexToRow(caretIndex);
                            _loc_12 = indexToColumn(caretIndex);
                            if (_loc_11 == lastRowInColumn(_loc_12))
                            {
                                _loc_11 = 0;
                                _loc_12++;
                            }
                            else
                            {
                                _loc_11++;
                            }
                            caretIndex = Math.min(indicesToIndex(_loc_11, _loc_12), (collection.length - 1));
                        }
                        _loc_11 = indexToRow(caretIndex);
                        _loc_12 = indexToColumn(caretIndex);
                        if (_loc_11 >= verticalScrollPosition + _loc_13 - _loc_15 && verticalScrollPosition < maxVerticalScrollPosition)
                        {
                            _loc_4 = verticalScrollPosition + 1;
                        }
                        if (_loc_11 < verticalScrollPosition)
                        {
                            _loc_4 = _loc_11;
                        }
                        if (_loc_12 > horizontalScrollPosition + columnCount - 1)
                        {
                            _loc_5 = horizontalScrollPosition + 1;
                        }
                    }
                    break;
                }
                case Keyboard.PAGE_UP:
                {
                    if (caretIndex < 0)
                    {
                        caretIndex = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
                    }
                    _loc_11 = indexToRow(caretIndex);
                    _loc_12 = indexToColumn(caretIndex);
                    if (verticalScrollPosition > 0)
                    {
                        if (_loc_11 == verticalScrollPosition)
                        {
                            var _loc_18:* = Math.max(verticalScrollPosition - (_loc_13 - _loc_15), 0);
                            _loc_11 = Math.max(verticalScrollPosition - (_loc_13 - _loc_15), 0);
                            _loc_4 = _loc_18;
                        }
                        else
                        {
                            _loc_11 = verticalScrollPosition;
                        }
                        caretIndex = indicesToIndex(_loc_11, _loc_12);
                        break;
                    }
                }
                case Keyboard.HOME:
                {
                    if (collection.length)
                    {
                        caretIndex = 0;
                        _loc_4 = 0;
                        _loc_5 = 0;
                    }
                    break;
                }
                case Keyboard.PAGE_DOWN:
                {
                    if (caretIndex < 0)
                    {
                        caretIndex = scrollPositionToIndex(horizontalScrollPosition, verticalScrollPosition);
                    }
                    _loc_11 = indexToRow(caretIndex);
                    _loc_12 = indexToColumn(caretIndex);
                    if (_loc_11 < maxVerticalScrollPosition)
                    {
                        if (_loc_11 == verticalScrollPosition + (_loc_13 - _loc_15))
                        {
                            _loc_4 = Math.min(verticalScrollPosition + _loc_13 - _loc_15, maxVerticalScrollPosition);
                            _loc_11 = verticalScrollPosition + _loc_13;
                        }
                        else
                        {
                            _loc_11 = Math.min(verticalScrollPosition + _loc_13 - _loc_15, indexToRow((collection.length - 1)));
                            if (_loc_11 == verticalScrollPosition + _loc_13 - _loc_15)
                            {
                                _loc_4 = Math.min(verticalScrollPosition + _loc_13 - _loc_15, maxVerticalScrollPosition);
                            }
                        }
                        caretIndex = Math.min(indicesToIndex(_loc_11, _loc_12), (collection.length - 1));
                        break;
                    }
                }
                case Keyboard.END:
                {
                    if (caretIndex < collection.length)
                    {
                        caretIndex = collection.length - 1;
                        _loc_4 = maxVerticalScrollPosition;
                        _loc_5 = maxHorizontalScrollPosition;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (!isNaN(_loc_4))
            {
                if (_loc_4 != verticalScrollPosition)
                {
                    _loc_17 = new ScrollEvent(ScrollEvent.SCROLL);
                    _loc_17.detail = ScrollEventDetail.THUMB_POSITION;
                    _loc_17.direction = ScrollEventDirection.VERTICAL;
                    _loc_17.delta = _loc_4 - verticalScrollPosition;
                    _loc_17.position = _loc_4;
                    verticalScrollPosition = _loc_4;
                    dispatchEvent(_loc_17);
                }
            }
            if (iteratorValid)
            {
                if (!isNaN(_loc_5))
                {
                    if (_loc_5 != horizontalScrollPosition)
                    {
                        _loc_17 = new ScrollEvent(ScrollEvent.SCROLL);
                        _loc_17.detail = ScrollEventDetail.THUMB_POSITION;
                        _loc_17.direction = ScrollEventDirection.HORIZONTAL;
                        _loc_17.delta = _loc_5 - horizontalScrollPosition;
                        _loc_17.position = _loc_5;
                        horizontalScrollPosition = _loc_5;
                        dispatchEvent(_loc_17);
                    }
                }
            }
            if (!iteratorValid)
            {
                keySelectionPending = true;
                return;
            }
            bShiftKey = param2;
            bCtrlKey = param3;
            lastKey = param1;
            finishKeySelection();
            return;
        }// end function

        override protected function scrollVertically(param1:int, param2:int, param3:Boolean) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Number = NaN;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:Number = NaN;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_23:IListItemRenderer = null;
            var _loc_24:int = 0;
            var _loc_25:Point = null;
            var _loc_26:int = 0;
            removeClipMask();
            var _loc_10:* = offscreenExtraRowsBottom;
            var _loc_11:* = offscreenExtraRowsTop;
            var _loc_12:* = offscreenExtraRows / 2;
            var _loc_13:* = offscreenExtraRows / 2;
            if (param3)
            {
                offscreenExtraRowsTop = Math.min(_loc_12, offscreenExtraRowsTop + param2);
                _loc_14 = param2 - (offscreenExtraRowsTop - _loc_11);
                _loc_15 = _loc_14;
            }
            else
            {
                _loc_21 = offscreenExtraRowsBottom == 0 && listItems.length && listItems[(listItems.length - 1)][0] && listItems[(listItems.length - 1)][0].y + rowHeight < listContent.heightExcludingOffsets - listContent.topOffset ? (1) : (0);
                offscreenExtraRowsTop = Math.min(_loc_12, param1);
                offscreenExtraRowsBottom = Math.min(offscreenExtraRowsBottom + param2 - _loc_21, _loc_13);
                _loc_14 = param2 - (_loc_11 - offscreenExtraRowsTop);
                _loc_16 = offscreenExtraRowsTop - _loc_11 + _loc_21 + (offscreenExtraRowsBottom - _loc_10);
                _loc_15 = param2 - (offscreenExtraRowsBottom - _loc_10) - _loc_21;
            }
            var _loc_17:* = listItems.length;
            var _loc_18:int = 0;
            while (_loc_18 < _loc_15)
            {
                
                _loc_5 = param3 ? (listItems[_loc_18].length) : (listItems[_loc_17 - _loc_18 - 1].length);
                _loc_22 = 0;
                while (_loc_22 < columnCount && _loc_22 < _loc_5)
                {
                    
                    _loc_23 = param3 ? (listItems[_loc_18][_loc_22]) : (listItems[_loc_17 - _loc_18 - 1][_loc_22]);
                    if (_loc_23)
                    {
                        delete visibleData[rowMap[_loc_23.name].uid];
                        removeIndicators(rowMap[_loc_23.name].uid);
                        addToFreeItemRenderers(_loc_23);
                        delete rowMap[_loc_23.name];
                        if (param3)
                        {
                            listItems[_loc_18][_loc_22] = null;
                        }
                        else
                        {
                            listItems[_loc_17 - _loc_18 - 1][_loc_22] = null;
                        }
                    }
                    _loc_22++;
                }
                _loc_18++;
            }
            var _loc_19:* = listItems.length;
            if (param3)
            {
                _loc_9 = _loc_14 * rowHeight;
                _loc_6 = 0;
                _loc_18 = _loc_14;
                while (_loc_18 < _loc_19)
                {
                    
                    _loc_5 = listItems[_loc_18].length;
                    _loc_22 = 0;
                    while (_loc_22 < columnCount && _loc_22 < _loc_5)
                    {
                        
                        _loc_23 = listItems[_loc_18][_loc_22];
                        listItems[_loc_18 - _loc_14][_loc_22] = _loc_23;
                        if (_loc_23)
                        {
                            _loc_23.y = _loc_23.y - _loc_9;
                            rowMap[_loc_23.name].rowIndex = rowMap[_loc_23.name].rowIndex - _loc_14;
                            moveIndicatorsVertically(rowMap[_loc_23.name].uid, -_loc_9);
                        }
                        _loc_22++;
                    }
                    if (_loc_5 < columnCount)
                    {
                        _loc_22 = _loc_5;
                        while (_loc_22 < columnCount)
                        {
                            
                            listItems[_loc_18 - _loc_14][_loc_22] = null;
                            _loc_22++;
                        }
                    }
                    rowInfo[_loc_18 - _loc_14] = rowInfo[_loc_18];
                    rowInfo[_loc_18 - _loc_14].y = rowInfo[_loc_18 - _loc_14].y - _loc_9;
                    _loc_6 = rowInfo[_loc_18 - _loc_14].y + rowHeight;
                    _loc_18++;
                }
                listItems.splice(_loc_19 - _loc_14 - 1, _loc_14);
                rowInfo.splice(_loc_19 - _loc_14 - 1, _loc_14);
                _loc_8 = indicesToIndex(verticalScrollPosition - offscreenExtraRowsTop + _loc_19 - _loc_14, horizontalScrollPosition);
                seekPositionSafely(_loc_8);
                _loc_24 = param2 + (_loc_13 - _loc_10);
                _loc_25 = makeRowsAndColumns(0, _loc_6, listContent.width, _loc_6 + param2 * rowHeight, 0, _loc_19 - _loc_14, true, _loc_24);
                _loc_26 = _loc_24 - _loc_25.y;
                while (_loc_26--)
                {
                    
                    listItems.pop();
                    rowInfo.pop();
                }
                _loc_8 = indicesToIndex(verticalScrollPosition - offscreenExtraRowsTop, horizontalScrollPosition);
                seekPositionSafely(_loc_8);
                offscreenExtraRowsBottom = Math.max(0, _loc_13 - (_loc_25.y < param2 ? (_loc_24 - _loc_25.y) : (0)));
            }
            else
            {
                if (_loc_16 < 0)
                {
                    listItems.splice(listItems.length + _loc_16, -_loc_16);
                    rowInfo.splice(rowInfo.length + _loc_16, -_loc_16);
                }
                else if (_loc_16 > 0)
                {
                    _loc_18 = 0;
                    while (_loc_18 < _loc_16)
                    {
                        
                        listItems[_loc_19 + _loc_18] = [];
                        _loc_18++;
                    }
                }
                _loc_9 = _loc_14 * rowHeight;
                _loc_6 = rowInfo[_loc_14].y;
                _loc_18 = (listItems.length - 1) - _loc_14;
                while (_loc_18 >= 0)
                {
                    
                    _loc_5 = listItems[_loc_18].length;
                    _loc_22 = 0;
                    while (_loc_22 < columnCount && _loc_22 < _loc_5)
                    {
                        
                        _loc_23 = listItems[_loc_18][_loc_22];
                        if (_loc_23)
                        {
                            _loc_23.y = _loc_23.y + _loc_9;
                            rowMap[_loc_23.name].rowIndex = rowMap[_loc_23.name].rowIndex + _loc_14;
                            _loc_7 = rowMap[_loc_23.name].uid;
                            listItems[_loc_18 + _loc_14][_loc_22] = _loc_23;
                            moveIndicatorsVertically(_loc_7, _loc_9);
                        }
                        else
                        {
                            listItems[_loc_18 + _loc_14][_loc_22] = null;
                        }
                        _loc_22++;
                    }
                    rowInfo[_loc_18 + _loc_14] = rowInfo[_loc_18];
                    rowInfo[_loc_18 + _loc_14].y = rowInfo[_loc_18 + _loc_14].y + _loc_9;
                    _loc_18 = _loc_18 - 1;
                }
                _loc_18 = 0;
                while (_loc_18 < _loc_14)
                {
                    
                    _loc_22 = 0;
                    while (_loc_22 < columnCount)
                    {
                        
                        listItems[_loc_18][_loc_22] = null;
                        _loc_22++;
                    }
                    _loc_18++;
                }
                _loc_8 = indicesToIndex(verticalScrollPosition - offscreenExtraRowsTop, horizontalScrollPosition);
                seekPositionSafely(_loc_8);
                allowRendererStealingDuringLayout = false;
                _loc_25 = makeRowsAndColumns(0, 0, listContent.width, _loc_6, 0, 0, true, _loc_14);
                allowRendererStealingDuringLayout = true;
                seekPositionSafely(_loc_8);
            }
            var _loc_20:* = listContent.heightExcludingOffsets;
            listContent.topOffset = (-rowHeight) * offscreenExtraRowsTop;
            listContent.bottomOffset = offscreenExtraRowsBottom ? (rowInfo[(rowInfo.length - 1)].y + rowHeight + listContent.topOffset - _loc_20) : (0);
            adjustListContent();
            addClipMask(false);
            return;
        }// end function

        override public function showDropFeedback(event:DragEvent) : void
        {
            var _loc_7:Class = null;
            var _loc_8:EdgeMetrics = null;
            if (!dropIndicator)
            {
                _loc_7 = getStyle("dropIndicatorSkin");
                if (!_loc_7)
                {
                    _loc_7 = ListDropIndicator;
                }
                dropIndicator = IFlexDisplayObject(new _loc_7);
                _loc_8 = viewMetrics;
                drawFocus(true);
                dropIndicator.x = 2;
                if (direction == TileBaseDirection.HORIZONTAL)
                {
                    dropIndicator.setActualSize(rowHeight - 4, 4);
                    DisplayObject(dropIndicator).rotation = 90;
                }
                else
                {
                    dropIndicator.setActualSize(columnWidth - 4, 4);
                }
                dropIndicator.visible = true;
                listContent.addChild(DisplayObject(dropIndicator));
                if (collection)
                {
                    dragScrollingInterval = setInterval(dragScroll, 15);
                }
            }
            var _loc_2:* = calculateDropIndex(event);
            var _loc_3:* = indexToRow(_loc_2);
            var _loc_4:* = indexToColumn(_loc_2);
            _loc_3 = _loc_3 - (verticalScrollPosition - offscreenExtraRowsTop);
            _loc_4 = _loc_4 - (horizontalScrollPosition - offscreenExtraColumnsLeft);
            var _loc_5:* = listItems.length;
            if (_loc_3 >= _loc_5)
            {
                _loc_3 = _loc_5 - 1;
            }
            var _loc_6:* = _loc_5 ? (listItems[0].length) : (0);
            if (_loc_4 > _loc_6)
            {
                _loc_4 = _loc_6;
            }
            dropIndicator.x = _loc_6 && listItems[_loc_3].length && listItems[_loc_3][_loc_4] ? (listItems[_loc_3][_loc_4].x) : (_loc_4 * columnWidth);
            dropIndicator.y = _loc_5 && listItems[_loc_3].length && listItems[_loc_3][0] ? (listItems[_loc_3][0].y) : (_loc_3 * rowHeight);
            return;
        }// end function

        public function set maxColumns(param1:int) : void
        {
            if (_maxColumns != param1)
            {
                _maxColumns = param1;
                invalidateSize();
                invalidateDisplayList();
            }
            return;
        }// end function

        override protected function configureScrollBars() : void
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_1:* = listItems.length;
            if (_loc_1 == 0)
            {
                return;
            }
            var _loc_2:* = listItems[0].length;
            if (_loc_2 == 0)
            {
                return;
            }
            if (_loc_1 > 1 && (_loc_1 - offscreenExtraRowsTop - offscreenExtraRowsBottom) * rowHeight > listContent.heightExcludingOffsets)
            {
                _loc_1 = _loc_1 - 1;
            }
            _loc_1 = _loc_1 - (offscreenExtraRowsTop + offscreenExtraRowsBottom);
            if (_loc_2 > 1 && (_loc_2 - offscreenExtraColumnsLeft - offscreenExtraColumnsRight) * columnWidth > listContent.widthExcludingOffsets)
            {
                _loc_2 = _loc_2 - 1;
            }
            _loc_2 = _loc_2 - (offscreenExtraColumnsLeft + offscreenExtraColumnsRight);
            var _loc_3:* = horizontalScrollBar;
            var _loc_4:* = verticalScrollBar;
            if (direction == TileBaseDirection.VERTICAL)
            {
                if (iteratorValid && horizontalScrollPosition > 0)
                {
                    _loc_8 = 0;
                    while (_loc_2 > 0 && listItems[0][_loc_2 + offscreenExtraColumnsLeft - 1] == null)
                    {
                        
                        _loc_2 = _loc_2 - 1;
                        _loc_8++;
                    }
                    _loc_9 = Math.floor(listContent.widthExcludingOffsets / columnWidth);
                    _loc_10 = Math.max(0, _loc_9 - (_loc_2 + _loc_8));
                    if (_loc_8 || _loc_10)
                    {
                        _loc_11 = 0;
                        while (_loc_11 < listItems.length)
                        {
                            
                            while (listItems[_loc_11].length > _loc_2 + offscreenExtraColumnsLeft)
                            {
                                
                                (listItems[_loc_11] as Array).pop();
                            }
                            _loc_11++;
                        }
                        if (!runningDataEffect)
                        {
                            horizontalScrollPosition = Math.max(0, horizontalScrollPosition - (_loc_8 + _loc_10));
                            _loc_7 = scrollPositionToIndex(Math.max(0, horizontalScrollPosition - offscreenExtraColumnsLeft), verticalScrollPosition);
                            seekPositionSafely(_loc_7);
                            updateList();
                        }
                        return;
                    }
                }
                if (!iteratorValid)
                {
                    _loc_1 = Math.floor(listContent.heightExcludingOffsets / rowHeight);
                }
                _loc_5 = maxRows > 0 ? (maxRows) : (_loc_1);
                _loc_6 = collection ? (Math.ceil(collection.length / _loc_5)) : (_loc_2);
            }
            else
            {
                if (iteratorValid && verticalScrollPosition > 0)
                {
                    _loc_12 = 0;
                    while (_loc_1 > 0 && (listItems[_loc_1 + offscreenExtraRowsTop - 1] == null || listItems[_loc_1 + offscreenExtraRowsTop - 1][0] == null))
                    {
                        
                        _loc_1 = _loc_1 - 1;
                        _loc_12++;
                    }
                    if (_loc_12)
                    {
                        while (listItems.length > _loc_1 + offscreenExtraRowsTop)
                        {
                            
                            listItems.pop();
                            rowInfo.pop();
                        }
                        if (!runningDataEffect)
                        {
                            verticalScrollPosition = Math.max(0, verticalScrollPosition - _loc_12);
                            _loc_7 = scrollPositionToIndex(horizontalScrollPosition, Math.max(0, verticalScrollPosition - offscreenExtraRowsTop));
                            seekPositionSafely(_loc_7);
                            updateList();
                        }
                        return;
                    }
                }
                if (!iteratorValid)
                {
                    _loc_2 = Math.floor(listContent.widthExcludingOffsets / columnWidth);
                }
                _loc_6 = maxColumns > 0 ? (maxColumns) : (_loc_2);
                _loc_5 = collection ? (Math.ceil(collection.length / _loc_6)) : (_loc_1);
            }
            maxHorizontalScrollPosition = Math.max(0, _loc_6 - _loc_2);
            maxVerticalScrollPosition = Math.max(0, _loc_5 - _loc_1);
            setScrollBarProperties(_loc_6, _loc_2, _loc_5, _loc_1);
            return;
        }// end function

        override protected function indexToRow(param1:int) : int
        {
            var _loc_3:int = 0;
            if (direction == TileBaseDirection.VERTICAL)
            {
                _loc_3 = maxRows > 0 ? (maxRows) : (rowCount);
                return param1 % _loc_3;
            }
            var _loc_2:* = maxColumns > 0 ? (maxColumns) : (columnCount);
            return Math.floor(param1 / _loc_2);
        }// end function

        private function displayingPartialColumn() : Boolean
        {
            var _loc_1:IListItemRenderer = null;
            if (listItems[0] && listItems[0].length > 0)
            {
                _loc_1 = listItems[0][(listItems[0].length - 1) - offscreenExtraColumnsRight];
                if (_loc_1 && _loc_1.x + _loc_1.width > listContent.widthExcludingOffsets - listContent.leftOffset)
                {
                    return true;
                }
            }
            return false;
        }// end function

        override protected function scrollHandler(event:Event) : void
        {
            var scrollBar:ScrollBar;
            var pos:Number;
            var delta:int;
            var startIndex:int;
            var o:EdgeMetrics;
            var bookmark:CursorBookmark;
            var event:* = event;
            if (event is ScrollEvent)
            {
                if (!liveScrolling && ScrollEvent(event).detail == ScrollEventDetail.THUMB_TRACK)
                {
                    return;
                }
                scrollBar = ScrollBar(event.target);
                pos = scrollBar.scrollPosition;
                if (scrollBar == verticalScrollBar)
                {
                    delta = pos - verticalScrollPosition;
                    super.scrollHandler(event);
                    if (Math.abs(delta) >= listItems.length || !iteratorValid)
                    {
                        startIndex = indicesToIndex(pos, horizontalScrollPosition);
                        try
                        {
                            iterator.seek(CursorBookmark.FIRST, startIndex);
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, startIndex);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                        }
                        bookmark = iterator.bookmark;
                        clearIndicators();
                        clearVisibleData();
                        makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
                        iterator.seek(bookmark, 0);
                        drawRowBackgrounds();
                    }
                    else if (delta != 0)
                    {
                        scrollVertically(pos, Math.abs(delta), delta > 0);
                    }
                }
                else
                {
                    delta = pos - horizontalScrollPosition;
                    super.scrollHandler(event);
                    if (Math.abs(delta) >= listItems[0].length || !iteratorValid)
                    {
                        startIndex = indicesToIndex(verticalScrollPosition, pos);
                        try
                        {
                            iterator.seek(CursorBookmark.FIRST, startIndex);
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, startIndex);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                        }
                        bookmark = iterator.bookmark;
                        clearIndicators();
                        clearVisibleData();
                        makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
                        iterator.seek(bookmark, 0);
                        drawRowBackgrounds();
                    }
                    else if (delta != 0)
                    {
                        scrollHorizontally(pos, Math.abs(delta), delta > 0);
                    }
                }
            }
            return;
        }// end function

        function purgeMeasuringRenderers() : void
        {
            var _loc_1:IListItemRenderer = null;
            for each (_loc_1 in measuringObjects)
            {
                
                if (_loc_1.parent)
                {
                    _loc_1.parent.removeChild(DisplayObject(_loc_1));
                }
            }
            if (!measuringObjects)
            {
                measuringObjects = new Dictionary(true);
            }
            return;
        }// end function

        override public function itemRendererToIndex(param1:IListItemRenderer) : int
        {
            var _loc_2:String = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (runningDataEffect)
            {
                _loc_2 = itemToUID(dataItemWrappersByRenderer[param1]);
            }
            else
            {
                _loc_2 = itemToUID(param1.data);
            }
            var _loc_3:* = listItems.length;
            var _loc_4:int = 0;
            while (_loc_4 < listItems.length)
            {
                
                _loc_5 = listItems[_loc_4].length;
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    if (listItems[_loc_4][_loc_6] && rowMap[listItems[_loc_4][_loc_6].name].uid == _loc_2)
                    {
                        if (direction == TileBaseDirection.VERTICAL)
                        {
                            return (_loc_6 + horizontalScrollPosition - offscreenExtraColumnsLeft) * Math.max(maxRows, rowCount) + _loc_4;
                        }
                        return (_loc_4 + verticalScrollPosition - offscreenExtraRowsTop) * Math.max(maxColumns, columnCount) + _loc_6;
                    }
                    _loc_6++;
                }
                _loc_4++;
            }
            return -1;
        }// end function

        override public function measureHeightOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var _loc_3:Number = NaN;
            var _loc_7:Object = null;
            var _loc_8:Object = null;
            var _loc_9:IFactory = null;
            var _loc_10:IListItemRenderer = null;
            var _loc_4:Boolean = false;
            if (collection && collection.length)
            {
                _loc_7 = iterator.current;
                _loc_8 = _loc_7 is ItemWrapper ? (_loc_7.data) : (_loc_7);
                _loc_9 = getItemRendererFactory(_loc_8);
                _loc_10 = measuringObjects[_loc_9];
                if (_loc_10 == null)
                {
                    _loc_10 = getMeasuringRenderer(_loc_8);
                    _loc_4 = true;
                }
                setupRendererFromData(_loc_10, _loc_8);
                _loc_3 = _loc_10.getExplicitOrMeasuredHeight();
                if (_loc_4)
                {
                    _loc_10.setActualSize(_loc_10.getExplicitOrMeasuredWidth(), _loc_3);
                    _loc_4 = false;
                }
            }
            if (isNaN(_loc_3) || _loc_3 == 0)
            {
                _loc_3 = 50;
            }
            var _loc_5:* = getStyle("paddingTop");
            var _loc_6:* = getStyle("paddingBottom");
            _loc_3 = _loc_3 + (_loc_5 + _loc_6);
            return _loc_3 * param2;
        }// end function

        function getMeasuringRenderer(param1:Object) : IListItemRenderer
        {
            var _loc_2:IListItemRenderer = null;
            if (!measuringObjects)
            {
                measuringObjects = new Dictionary(true);
            }
            var _loc_3:* = getItemRendererFactory(param1);
            _loc_2 = measuringObjects[_loc_3];
            if (!_loc_2)
            {
                _loc_2 = createItemRenderer(param1);
                _loc_2.owner = this;
                _loc_2.name = "hiddenItem";
                _loc_2.visible = false;
                _loc_2.styleName = listContent;
                listContent.addChild(DisplayObject(_loc_2));
                measuringObjects[_loc_3] = _loc_2;
            }
            return _loc_2;
        }// end function

        private function getPreparedItemRenderer(param1:int, param2:int, param3:Object, param4:Object, param5:String) : IListItemRenderer
        {
            var _loc_7:IListItemRenderer = null;
            var _loc_8:ListData = null;
            var _loc_9:ListData = null;
            var _loc_6:* = listItems[param1][param2];
            if (listItems[param1][param2])
            {
                if (runningDataEffect ? (dataItemWrappersByRenderer[_loc_6] != param3) : (_loc_6.data != param4))
                {
                    addToFreeItemRenderers(_loc_6);
                }
                else
                {
                    _loc_7 = _loc_6;
                }
            }
            if (!_loc_7)
            {
                if (allowRendererStealingDuringLayout)
                {
                    _loc_7 = visibleData[param5];
                    if (!_loc_7 && param3 != param4)
                    {
                        _loc_7 = visibleData[itemToUID(param4)];
                    }
                }
                if (_loc_7)
                {
                    _loc_9 = ListData(rowMap[_loc_7.name]);
                    if (_loc_9)
                    {
                        if (direction == TileBaseDirection.HORIZONTAL && (_loc_9.rowIndex > param1 || _loc_9.rowIndex == param1 && _loc_9.columnIndex > param2) || direction == TileBaseDirection.VERTICAL && (_loc_9.columnIndex > param2 || _loc_9.columnIndex == param2 && _loc_9.rowIndex > param1))
                        {
                            listItems[_loc_9.rowIndex][_loc_9.columnIndex] = null;
                        }
                        else
                        {
                            _loc_7 = null;
                        }
                    }
                }
                if (!_loc_7)
                {
                    _loc_7 = getReservedOrFreeItemRenderer(param3);
                    if (_loc_7 && !isRendererUnconstrained(_loc_7))
                    {
                        _loc_7.x = 0;
                        _loc_7.y = 0;
                    }
                }
                if (!_loc_7)
                {
                    _loc_7 = createItemRenderer(param4);
                }
                _loc_7.owner = this;
                _loc_7.styleName = listContent;
            }
            if (!_loc_7.parent)
            {
                listContent.addChild(DisplayObject(_loc_7));
            }
            _loc_8 = ListData(makeListData(param4, param5, param1, param2));
            rowMap[_loc_7.name] = _loc_8;
            if (_loc_7 is IDropInListItemRenderer)
            {
                IDropInListItemRenderer(_loc_7).listData = param4 ? (_loc_8) : (null);
            }
            _loc_7.data = param4;
            if (param3 != param4)
            {
                dataItemWrappersByRenderer[_loc_7] = param3;
            }
            _loc_7.visible = true;
            if (param5)
            {
                visibleData[param5] = _loc_7;
            }
            listItems[param1][param2] = _loc_7;
            UIComponentGlobals.layoutManager.validateClient(_loc_7, true);
            return _loc_7;
        }// end function

        private function placeAndDrawItemRenderer(param1:IListItemRenderer, param2:Number, param3:Number, param4:String) : void
        {
            var _loc_8:Number = NaN;
            var _loc_5:Boolean = false;
            var _loc_6:Boolean = false;
            var _loc_7:Boolean = false;
            _loc_8 = param1.getExplicitOrMeasuredHeight();
            if (param1.width != columnWidth || _loc_8 != rowHeight - cachedPaddingTop - cachedPaddingBottom)
            {
                param1.setActualSize(columnWidth, rowHeight - cachedPaddingTop - cachedPaddingBottom);
            }
            if (!isRendererUnconstrained(param1))
            {
                param1.move(param2, param3 + cachedPaddingTop);
            }
            _loc_5 = selectedData[param4] != null;
            if (runningDataEffect)
            {
                _loc_5 = _loc_5 || selectedData[itemToUID(param1.data)] != null;
                _loc_5 = _loc_5 && !getRendererSemanticValue(param1, ModifiedCollectionView.REPLACEMENT) && !getRendererSemanticValue(param1, ModifiedCollectionView.ADDED);
            }
            _loc_6 = highlightUID == param4;
            _loc_7 = caretUID == param4;
            if (param4)
            {
                drawItem(param1, _loc_5, _loc_6, _loc_7);
            }
            return;
        }// end function

        override protected function makeRowsAndColumns(param1:Number, param2:Number, param3:Number, param4:Number, param5:int, param6:int, param7:Boolean = false, param8:uint = 0) : Point
        {
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_13:Number = NaN;
            var _loc_14:Number = NaN;
            var _loc_15:Object = null;
            var _loc_16:Object = null;
            var _loc_17:String = null;
            var _loc_18:IListItemRenderer = null;
            var _loc_19:IListItemRenderer = null;
            var _loc_20:Boolean = false;
            var _loc_21:Boolean = false;
            var _loc_22:int = 0;
            var _loc_23:Number = NaN;
            var _loc_24:int = 0;
            var _loc_25:int = 0;
            var _loc_29:Array = null;
            var _loc_26:Boolean = false;
            var _loc_27:Boolean = false;
            var _loc_28:Boolean = false;
            if (columnWidth == 0 || rowHeight == 0)
            {
                return null;
            }
            invalidateSizeFlag = true;
            allowItemSizeChangeNotification = false;
            if (direction == TileBaseDirection.VERTICAL)
            {
                _loc_9 = maxRows > 0 ? (maxRows) : (Math.max(Math.floor(listContent.heightExcludingOffsets / rowHeight), 1));
                _loc_10 = Math.max(Math.ceil(listContent.widthExcludingOffsets / columnWidth), 1);
                setRowCount(_loc_9);
                setColumnCount(_loc_10);
                _loc_11 = param5;
                _loc_13 = param1;
                _loc_25 = _loc_11 - 1;
                _loc_20 = iterator != null && !iterator.afterLast && iteratorValid;
                while (param7 && param8-- || !param7 && _loc_11 < _loc_10 + param5)
                {
                    
                    _loc_12 = param6;
                    _loc_14 = param2;
                    while (_loc_12 < _loc_9)
                    {
                        
                        _loc_21 = _loc_20;
                        _loc_15 = _loc_20 ? (iterator.current) : (null);
                        _loc_16 = _loc_15 is ItemWrapper ? (_loc_15.data) : (_loc_15);
                        _loc_20 = moveNextSafely(_loc_20);
                        if (!listItems[_loc_12])
                        {
                            listItems[_loc_12] = [];
                        }
                        if (_loc_21 && _loc_14 < param4)
                        {
                            _loc_17 = itemToUID(_loc_15);
                            rowInfo[_loc_12] = new ListRowInfo(_loc_14, rowHeight, _loc_17);
                            _loc_19 = getPreparedItemRenderer(_loc_12, _loc_11, _loc_15, _loc_16, _loc_17);
                            placeAndDrawItemRenderer(_loc_19, _loc_13, _loc_14, _loc_17);
                            _loc_25 = Math.max(_loc_11, _loc_25);
                        }
                        else
                        {
                            _loc_18 = listItems[_loc_12][_loc_11];
                            if (_loc_18)
                            {
                                addToFreeItemRenderers(_loc_18);
                                listItems[_loc_12][_loc_11] = null;
                            }
                            rowInfo[_loc_12] = new ListRowInfo(_loc_14, rowHeight, _loc_17);
                        }
                        _loc_14 = _loc_14 + rowHeight;
                        _loc_12++;
                    }
                    _loc_11++;
                    if (param6)
                    {
                        _loc_22 = 0;
                        while (_loc_22 < param6)
                        {
                            
                            _loc_20 = moveNextSafely(_loc_20);
                            _loc_22++;
                        }
                    }
                    _loc_13 = _loc_13 + columnWidth;
                }
            }
            else
            {
                _loc_10 = maxColumns > 0 ? (maxColumns) : (Math.max(Math.floor(listContent.widthExcludingOffsets / columnWidth), 1));
                _loc_9 = Math.max(Math.ceil(listContent.heightExcludingOffsets / rowHeight), 1);
                setColumnCount(_loc_10);
                setRowCount(_loc_9);
                _loc_12 = param6;
                _loc_14 = param2;
                _loc_20 = iterator != null && !iterator.afterLast && iteratorValid;
                _loc_24 = _loc_12 - 1;
                while (param7 && _loc_8-- || !param7 && _loc_12 < _loc_9 + param6)
                {
                    
                    _loc_11 = param5;
                    _loc_13 = param1;
                    rowInfo[_loc_12] = null;
                    while (_loc_11 < _loc_10)
                    {
                        
                        _loc_21 = _loc_20;
                        _loc_15 = _loc_20 ? (iterator.current) : (null);
                        _loc_16 = _loc_15 is ItemWrapper ? (_loc_15.data) : (_loc_15);
                        _loc_20 = moveNextSafely(_loc_20);
                        if (!listItems[_loc_12])
                        {
                            listItems[_loc_12] = [];
                        }
                        if (_loc_21 && _loc_13 < param3)
                        {
                            _loc_17 = itemToUID(_loc_15);
                            if (!rowInfo[_loc_12])
                            {
                                rowInfo[_loc_12] = new ListRowInfo(_loc_14, rowHeight, _loc_17);
                            }
                            _loc_19 = getPreparedItemRenderer(_loc_12, _loc_11, _loc_15, _loc_16, _loc_17);
                            placeAndDrawItemRenderer(_loc_19, _loc_13, _loc_14, _loc_17);
                            _loc_24 = _loc_12;
                        }
                        else
                        {
                            if (!rowInfo[_loc_12])
                            {
                                rowInfo[_loc_12] = new ListRowInfo(_loc_14, rowHeight, _loc_17);
                            }
                            _loc_18 = listItems[_loc_12][_loc_11];
                            if (_loc_18)
                            {
                                addToFreeItemRenderers(_loc_18);
                                listItems[_loc_12][_loc_11] = null;
                            }
                        }
                        _loc_13 = _loc_13 + columnWidth;
                        _loc_11++;
                    }
                    _loc_12++;
                    if (param5)
                    {
                        _loc_22 = 0;
                        while (_loc_22 < param5)
                        {
                            
                            _loc_20 = moveNextSafely(_loc_20);
                            _loc_22++;
                        }
                    }
                    _loc_14 = _loc_14 + rowHeight;
                }
            }
            if (!param7)
            {
                while (listItems.length > _loc_9 + offscreenExtraRowsTop)
                {
                    
                    _loc_29 = listItems.pop();
                    rowInfo.pop();
                    _loc_22 = 0;
                    while (_loc_22 < _loc_29.length)
                    {
                        
                        _loc_18 = _loc_29[_loc_22];
                        if (_loc_18)
                        {
                            addToFreeItemRenderers(_loc_18);
                        }
                        _loc_22++;
                    }
                }
                if (listItems.length && listItems[0].length > _loc_10 + offscreenExtraColumnsLeft)
                {
                    _loc_22 = 0;
                    while (_loc_22 < _loc_9 + offscreenExtraRowsTop)
                    {
                        
                        _loc_29 = listItems[_loc_22];
                        while (_loc_29.length > _loc_10 + offscreenExtraColumnsLeft)
                        {
                            
                            _loc_18 = _loc_29.pop();
                            if (_loc_18)
                            {
                                addToFreeItemRenderers(_loc_18);
                            }
                        }
                        _loc_22++;
                    }
                }
            }
            allowItemSizeChangeNotification = true;
            invalidateSizeFlag = false;
            return new Point(_loc_25 - param5 + 1, _loc_24 - param6 + 1);
        }// end function

        private function lastColumnInRow(param1:int) : int
        {
            var _loc_2:* = maxRows > 0 ? (maxRows) : (rowCount);
            var _loc_3:* = Math.floor((collection.length - 1) / _loc_2);
            if (indicesToIndex(param1, _loc_3) >= collection.length)
            {
                _loc_3 = _loc_3 - 1;
            }
            return _loc_3;
        }// end function

        override protected function get dragImageOffsets() : Point
        {
            var _loc_4:String = null;
            var _loc_1:* = new Point(8192, 8192);
            var _loc_2:Boolean = false;
            var _loc_3:* = listItems.length;
            for (_loc_4 in visibleData)
            {
                
                if (selectedData[_loc_4])
                {
                    _loc_1.x = Math.min(_loc_1.x, visibleData[_loc_4].x);
                    _loc_1.y = Math.min(_loc_1.y, visibleData[_loc_4].y);
                    _loc_2 = true;
                }
            }
            if (_loc_2)
            {
                return _loc_1;
            }
            return new Point(0, 0);
        }// end function

        public function get maxColumns() : int
        {
            return _maxColumns;
        }// end function

        public function set maxRows(param1:int) : void
        {
            if (_maxRows != param1)
            {
                _maxRows = param1;
                invalidateSize();
                invalidateDisplayList();
            }
            return;
        }// end function

        public function get maxRows() : int
        {
            return _maxRows;
        }// end function

        private function moveNextSafely(param1:Boolean) : Boolean
        {
            var more:* = param1;
            if (iterator && more)
            {
                try
                {
                    more = iterator.moveNext();
                }
                catch (e1:ItemPendingError)
                {
                    lastSeekPending = new ListBaseSeekPending(CursorBookmark.CURRENT, 0);
                    e1.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                    more;
                    iteratorValid = false;
                }
            }
            return more;
        }// end function

        private function lastRowInColumn(param1:int) : int
        {
            var _loc_2:* = maxColumns > 0 ? (maxColumns) : (columnCount);
            var _loc_3:* = Math.floor((collection.length - 1) / _loc_2);
            if (param1 * _loc_3 > collection.length)
            {
                _loc_3 = _loc_3 - 1;
            }
            return _loc_3;
        }// end function

        protected function drawTileBackground(param1:Sprite, param2:int, param3:int, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : DisplayObject
        {
            var _loc_9:Shape = null;
            var _loc_8:* = param2 * columnCount + param3;
            if (param2 * columnCount + param3 < param1.numChildren)
            {
                _loc_9 = Shape(param1.getChildAt(_loc_8));
            }
            else
            {
                _loc_9 = new FlexShape();
                _loc_9.name = "tileBackground";
                param1.addChild(_loc_9);
            }
            var _loc_10:* = _loc_9.graphics;
            _loc_9.graphics.clear();
            _loc_10.beginFill(param6, getStyle("backgroundAlpha"));
            _loc_10.drawRect(0, 0, param4, param5);
            _loc_10.endFill();
            return _loc_9;
        }// end function

        override public function calculateDropIndex(event:DragEvent = null) : int
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Point = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            if (event)
            {
                _loc_3 = new Point(event.localX, event.localY);
                _loc_3 = DisplayObject(event.target).localToGlobal(_loc_3);
                _loc_3 = listContent.globalToLocal(_loc_3);
                _loc_4 = listItems.length;
                _loc_5 = 0;
                while (_loc_5 < _loc_4)
                {
                    
                    if (rowInfo[_loc_5].y <= _loc_3.y && _loc_3.y < rowInfo[_loc_5].y + rowInfo[_loc_5].height)
                    {
                        _loc_6 = listItems[_loc_5].length;
                        _loc_7 = 0;
                        while (_loc_7 < _loc_6)
                        {
                            
                            if (listItems[_loc_5][_loc_7] && listItems[_loc_5][_loc_7].x <= _loc_3.x && _loc_3.x < listItems[_loc_5][_loc_7].x + listItems[_loc_5][_loc_7].width)
                            {
                                _loc_2 = listItems[_loc_5][_loc_7];
                                if (!DisplayObject(_loc_2).visible)
                                {
                                    _loc_2 = null;
                                }
                                break;
                            }
                            _loc_7++;
                        }
                        break;
                    }
                    _loc_5++;
                }
                if (_loc_2)
                {
                    lastDropIndex = itemRendererToIndex(_loc_2);
                }
                else
                {
                    lastDropIndex = collection ? (collection.length) : (0);
                }
            }
            return lastDropIndex;
        }// end function

        override public function set itemRenderer(param1:IFactory) : void
        {
            super.itemRenderer = param1;
            purgeMeasuringRenderers();
            return;
        }// end function

        function setupRendererFromData(param1:IListItemRenderer, param2:Object) : void
        {
            var _loc_3:* = ListData(makeListData(param2, itemToUID(param2), 0, 0));
            if (param1 is IDropInListItemRenderer)
            {
                IDropInListItemRenderer(param1).listData = param2 ? (_loc_3) : (null);
            }
            param1.data = param2;
            UIComponentGlobals.layoutManager.validateClient(param1, true);
            return;
        }// end function

        protected function makeListData(param1:Object, param2:String, param3:int, param4:int) : BaseListData
        {
            return new ListData(itemToLabel(param1), itemToIcon(param1), labelField, param2, this, param3, param4);
        }// end function

        override public function indicesToIndex(param1:int, param2:int) : int
        {
            var _loc_4:int = 0;
            if (direction == TileBaseDirection.VERTICAL)
            {
                _loc_4 = maxRows > 0 ? (maxRows) : (rowCount);
                return param2 * _loc_4 + param1;
            }
            var _loc_3:* = maxColumns > 0 ? (maxColumns) : (columnCount);
            return param1 * _loc_3 + param2;
        }// end function

        override protected function adjustListContent(param1:Number = -1, param2:Number = -1) : void
        {
            var _loc_3:Boolean = false;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            super.adjustListContent(param1, param2);
            if (!collection)
            {
                return;
            }
            var _loc_7:* = collection.length;
            if (direction == TileBaseDirection.VERTICAL)
            {
                _loc_5 = maxRows > 0 ? (maxRows) : (Math.max(Math.floor(listContent.heightExcludingOffsets / rowHeight), 1));
                _loc_6 = Math.max(Math.ceil(listContent.widthExcludingOffsets / columnWidth), 1);
                if (_loc_5 != lastRowCount)
                {
                    _loc_3 = listContent.widthExcludingOffsets / columnWidth != Math.ceil(listContent.widthExcludingOffsets / columnWidth);
                    _loc_8 = Math.max(Math.ceil(_loc_7 / _loc_5) - _loc_6, 0);
                    if (_loc_3)
                    {
                        _loc_8++;
                    }
                    if (horizontalScrollPosition > _loc_8)
                    {
                        $horizontalScrollPosition = _loc_8;
                    }
                    setRowCount(_loc_5);
                    setColumnCount(_loc_6);
                    _loc_4 = scrollPositionToIndex(Math.max(0, horizontalScrollPosition - offscreenExtraColumnsLeft), verticalScrollPosition);
                    seekPositionSafely(_loc_4);
                }
                lastRowCount = _loc_5;
            }
            else
            {
                _loc_6 = maxColumns > 0 ? (maxColumns) : (Math.max(Math.floor(listContent.widthExcludingOffsets / columnWidth), 1));
                _loc_5 = Math.max(Math.ceil(listContent.heightExcludingOffsets / rowHeight), 1);
                if (_loc_6 != lastColumnCount)
                {
                    _loc_3 = listContent.heightExcludingOffsets / rowHeight != Math.ceil(listContent.heightExcludingOffsets / rowHeight);
                    _loc_9 = Math.max(Math.ceil(_loc_7 / _loc_6) - _loc_5, 0);
                    if (_loc_3)
                    {
                        _loc_9++;
                    }
                    if (verticalScrollPosition > _loc_9)
                    {
                        $verticalScrollPosition = _loc_9;
                    }
                    setRowCount(_loc_5);
                    setColumnCount(_loc_6);
                    _loc_4 = scrollPositionToIndex(horizontalScrollPosition, Math.max(0, verticalScrollPosition - offscreenExtraRowsTop));
                    seekPositionSafely(_loc_4);
                }
                lastColumnCount = _loc_6;
            }
            return;
        }// end function

        override protected function collectionChangeHandler(event:Event) : void
        {
            var _loc_2:CollectionEvent = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (event is CollectionEvent)
            {
                _loc_2 = CollectionEvent(event);
                if (_loc_2.location == 0 || _loc_2.kind == CollectionEventKind.REFRESH)
                {
                    itemsNeedMeasurement = true;
                    invalidateProperties();
                }
                if (_loc_2.kind == CollectionEventKind.REMOVE)
                {
                    _loc_3 = indicesToIndex(verticalScrollPosition, horizontalScrollPosition);
                    if (_loc_2.location < _loc_3)
                    {
                        _loc_3 = _loc_3 - _loc_2.items.length;
                        super.collectionChangeHandler(event);
                        _loc_4 = 0;
                        _loc_5 = 0;
                        if (direction == TileBaseDirection.HORIZONTAL)
                        {
                            super.verticalScrollPosition = indexToRow(_loc_3);
                            _loc_4 = Math.min(offscreenExtraRows / 2, verticalScrollPosition);
                        }
                        else
                        {
                            super.horizontalScrollPosition = indexToColumn(_loc_3);
                            _loc_5 = Math.min(offscreenExtraColumns / 2, horizontalScrollPosition);
                        }
                        _loc_6 = scrollPositionToIndex(horizontalScrollPosition - _loc_5, verticalScrollPosition - _loc_4);
                        seekPositionSafely(_loc_6);
                        return;
                    }
                }
            }
            super.collectionChangeHandler(event);
            return;
        }// end function

    }
}
