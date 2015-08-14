package mx.controls.dataGridClasses
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.skins.halo.*;

    public class DataGridBase extends ListBase implements IFontContextComponent
    {
        private var _showHeaders:Boolean = true;
        var visibleColumns:Array;
        private var lockedColumnMask:Shape;
        protected var headerMask:Shape;
        protected var freeItemRenderersTable:Dictionary;
        var visibleLockedColumns:Array;
        protected var columnMap:Object;
        private var indicatorDictionary:Dictionary;
        private var lockedColumnAndRowMask:Shape;
        private var bSelectItem:Boolean = false;
        private var bCtrlKey:Boolean = false;
        private var inSelectItem:Boolean = false;
        private var lockedRowCountChanged:Boolean = false;
        private var lockedColumnHeaderMask:Shape;
        var _explicitHeaderHeight:Boolean;
        protected var lockedColumnAndRowContent:DataGridLockedRowContentHolder;
        protected var lockedColumnContent:ListBaseContentHolder;
        var columnsInvalid:Boolean = true;
        private var lockedRowMask:Shape;
        protected var header:DataGridHeaderBase;
        var _lockedColumnCount:int = 0;
        var _lockedRowCount:int = 0;
        protected var lockedColumnHeader:DataGridHeaderBase;
        protected var columnHighlightIndicator:Sprite;
        protected var columnCaretIndicator:Sprite;
        private var lockedColumnCountChanged:Boolean = false;
        protected var lockedRowContent:DataGridLockedRowContentHolder;
        var headerClass:Class;
        private var lastKey:uint = 0;
        var _headerHeight:Number = 22;
        private var bShiftKey:Boolean = false;
        static const VERSION:String = "3.5.0.12683";

        public function DataGridBase()
        {
            headerClass = DataGridHeader;
            indicatorDictionary = new Dictionary(true);
            listType = "vertical";
            defaultRowCount = 7;
            columnMap = {};
            freeItemRenderersTable = new Dictionary(false);
            return;
        }// end function

        function get dataGridLockedColumnAndRows() : ListBaseContentHolder
        {
            return lockedColumnAndRowContent;
        }// end function

        override protected function removeFromRowArrays(param1:int) : void
        {
            super.removeFromRowArrays(param1);
            if (lockedColumnCount)
            {
                lockedColumnContent.listItems.splice(param1, 1);
                lockedColumnContent.rowInfo.splice(param1, 1);
            }
            return;
        }// end function

        override function removeClipMask() : void
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:DisplayObject = null;
            super.removeClipMask();
            if (!lockedColumnContent)
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
            var _loc_4:* = lockedColumnContent.listItems[_loc_1];
            if (lockedColumnContent.listItems[_loc_1])
            {
                _loc_5 = _loc_4.length;
                _loc_6 = 0;
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
            }
            return;
        }// end function

        private function selectionRemovedListener(event:Event) : void
        {
            if (!lockedColumnCount)
            {
                return;
            }
            var _loc_2:* = indicatorDictionary[event.target] as Sprite;
            if (_loc_2)
            {
                _loc_2.parent.removeChild(_loc_2);
            }
            return;
        }// end function

        override protected function shiftRow(param1:int, param2:int, param3:int, param4:Boolean) : void
        {
            var _loc_5:Array = null;
            var _loc_6:IListItemRenderer = null;
            var _loc_7:int = 0;
            super.shiftRow(param1, param2, param3, param4);
            if (lockedColumnCount)
            {
                _loc_5 = lockedColumnContent.listItems;
                param3 = _loc_5[param1].length;
                _loc_7 = 0;
                while (_loc_7 < param3)
                {
                    
                    _loc_6 = _loc_5[param1][_loc_7];
                    if (param4)
                    {
                        _loc_5[param2][_loc_7] = _loc_6;
                        rowMap[_loc_6.name].rowIndex = param2;
                    }
                    else
                    {
                        rowMap[_loc_6.name].rowIndex = param1;
                    }
                    _loc_7++;
                }
                if (param4)
                {
                    lockedColumnContent.rowInfo[param2] = lockedColumnContent.rowInfo[param1];
                }
            }
            return;
        }// end function

        protected function makeRow(param1:ListBaseContentHolder, param2:int, param3:Number, param4:Number, param5:Number, param6:Object, param7:String) : Number
        {
            var _loc_9:ListBaseContentHolder = null;
            var _loc_10:IListItemRenderer = null;
            var _loc_11:IListItemRenderer = null;
            var _loc_12:DataGridColumn = null;
            var _loc_13:Point = null;
            var _loc_8:* = param1.listItems;
            if (lockedColumnCount > 0)
            {
                if (param1 == lockedRowContent)
                {
                    _loc_9 = lockedColumnAndRowContent;
                }
                else
                {
                    _loc_9 = lockedColumnContent;
                }
            }
            else
            {
                _loc_9 = null;
            }
            var _loc_14:int = 0;
            var _loc_15:* = param3;
            var _loc_16:Number = 0;
            while (_loc_14 < visibleLockedColumns.length)
            {
                
                _loc_12 = visibleLockedColumns[_loc_14];
                _loc_10 = setupColumnItemRenderer(_loc_12, _loc_9, param2, _loc_14, param6, param7);
                _loc_13 = layoutColumnItemRenderer(_loc_12, _loc_10, _loc_15, param5);
                _loc_15 = _loc_15 + _loc_13.x;
                _loc_14++;
                _loc_16 = Math.ceil(Math.max(_loc_16, variableRowHeight ? (_loc_13.y + cachedPaddingTop + cachedPaddingBottom) : (rowHeight)));
            }
            if (visibleLockedColumns.length)
            {
                while (_loc_9.listItems[param2].length > _loc_14)
                {
                    
                    _loc_11 = _loc_9.listItems[param2].pop();
                    addToFreeItemRenderers(_loc_11);
                }
            }
            _loc_14 = 0;
            _loc_15 = param3;
            while (_loc_15 < param4 && _loc_14 < visibleColumns.length)
            {
                
                _loc_12 = visibleColumns[_loc_14];
                _loc_10 = setupColumnItemRenderer(_loc_12, param1, param2, _loc_14, param6, param7);
                _loc_13 = layoutColumnItemRenderer(_loc_12, _loc_10, _loc_15, param5);
                _loc_15 = _loc_15 + _loc_13.x;
                _loc_14++;
                _loc_16 = Math.ceil(Math.max(_loc_16, variableRowHeight ? (_loc_13.y + cachedPaddingTop + cachedPaddingBottom) : (rowHeight)));
            }
            while (_loc_8[param2].length > _loc_14)
            {
                
                _loc_11 = _loc_8[param2].pop();
                addToFreeItemRenderers(_loc_11);
            }
            return _loc_16;
        }// end function

        public function get headerHeight() : Number
        {
            return _headerHeight;
        }// end function

        function columnHeaderWordWrap(param1:DataGridColumn) : Boolean
        {
            if (param1.headerWordWrap == true)
            {
                return true;
            }
            if (param1.headerWordWrap == false)
            {
                return false;
            }
            return wordWrap;
        }// end function

        override protected function drawHighlightIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:ListBaseContentHolder = null;
            var _loc_9:Sprite = null;
            super.drawHighlightIndicator(param1, param2, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
            if (lockedColumnCount)
            {
                if (param7.parent == listContent)
                {
                    _loc_8 = lockedColumnContent;
                }
                else
                {
                    _loc_8 = lockedColumnAndRowContent;
                }
                _loc_9 = _loc_8.selectionLayer;
                if (!columnHighlightIndicator)
                {
                    columnHighlightIndicator = new SpriteAsset();
                    _loc_8.selectionLayer.addChild(DisplayObject(columnHighlightIndicator));
                }
                else if (columnHighlightIndicator.parent != _loc_9)
                {
                    _loc_9.addChild(columnHighlightIndicator);
                }
                else
                {
                    _loc_9.setChildIndex(DisplayObject(columnHighlightIndicator), (_loc_9.numChildren - 1));
                }
                super.drawHighlightIndicator(columnHighlightIndicator, param2, param3, _loc_8.width, param5, param6, param7);
            }
            return;
        }// end function

        override protected function finishKeySelection() : void
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
                    caretIndex = Math.min(verticalScrollPosition + lockedRowCount + _loc_3 - _loc_4, (collection.length - 1));
                }
                else
                {
                    caretIndex = Math.min(verticalScrollPosition + lockedRowCount + _loc_3 - _loc_4 - 1, (collection.length - 1));
                }
            }
            var _loc_6:Boolean = false;
            if (bSelectItem && (caretIndex - verticalScrollPosition >= 0 || caretIndex < lockedRowCount))
            {
                if (caretIndex - lockedRowCount - verticalScrollPosition > Math.max(_loc_3 - _loc_4 - 1, 0))
                {
                    if (lastKey == Keyboard.END && maxVerticalScrollPosition > verticalScrollPosition)
                    {
                        (caretIndex - 1);
                        moveSelectionVertically(lastKey, bShiftKey, bCtrlKey);
                        return;
                    }
                    caretIndex = lockedRowCount + _loc_3 - _loc_4 - 1 + verticalScrollPosition;
                }
                if (caretIndex < lockedRowCount)
                {
                    _loc_5 = lockedRowContent.listItems[caretIndex][0];
                }
                else
                {
                    _loc_5 = listItems[caretIndex - lockedRowCount - verticalScrollPosition + offscreenExtraRowsTop][0];
                }
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

        override function addClipMask(param1:Boolean) : void
        {
            var _loc_2:Graphics = null;
            var _loc_11:DisplayObject = null;
            var _loc_12:Number = NaN;
            if (param1)
            {
                if (horizontalScrollBar && horizontalScrollBar.visible || hasOnlyTextRenderers() || listContent.bottomOffset != 0 || listContent.topOffset != 0 || listContent.leftOffset != 0 || listContent.rightOffset != 0)
                {
                    listContent.mask = maskShape;
                    selectionLayer.mask = null;
                    if (!headerMask)
                    {
                        headerMask = new Shape();
                        addChild(headerMask);
                        _loc_2 = headerMask.graphics;
                        _loc_2.beginFill(16777215);
                        _loc_2.drawRect(0, 0, 10, 10);
                        _loc_2.endFill();
                        headerMask.visible = false;
                    }
                    header.mask = headerMask;
                    header.selectionLayer.mask = null;
                    headerMask.width = maskShape.width;
                    headerMask.height = maskShape.height;
                    headerMask.x = maskShape.x;
                    headerMask.y = maskShape.y;
                    if (verticalScrollBar != null && verticalScrollBar.visible && (horizontalScrollBar == null || !horizontalScrollBar.visible) && headerVisible)
                    {
                        headerMask.width = headerMask.width + verticalScrollBar.getExplicitOrMeasuredWidth();
                    }
                    if (lockedRowContent)
                    {
                        if (!lockedRowMask)
                        {
                            lockedRowMask = new Shape();
                            addChild(lockedRowMask);
                            _loc_2 = lockedRowMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedRowMask.visible = false;
                        }
                        lockedRowContent.mask = lockedRowMask;
                        lockedRowContent.selectionLayer.mask = null;
                        lockedRowMask.width = maskShape.width;
                        lockedRowMask.height = maskShape.height;
                        lockedRowMask.x = maskShape.x;
                        lockedRowMask.y = maskShape.y;
                    }
                    if (lockedColumnContent)
                    {
                        if (!lockedColumnMask)
                        {
                            lockedColumnMask = new Shape();
                            addChild(lockedColumnMask);
                            _loc_2 = lockedColumnMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnMask.visible = false;
                        }
                        lockedColumnContent.mask = lockedColumnMask;
                        lockedColumnContent.selectionLayer.mask = null;
                        lockedColumnMask.width = maskShape.width;
                        lockedColumnMask.height = maskShape.height;
                        lockedColumnMask.x = maskShape.x;
                        lockedColumnMask.y = maskShape.y;
                    }
                    if (lockedColumnAndRowContent)
                    {
                        if (!lockedColumnAndRowMask)
                        {
                            lockedColumnAndRowMask = new Shape();
                            addChild(lockedColumnAndRowMask);
                            _loc_2 = lockedColumnAndRowMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnAndRowMask.visible = false;
                        }
                        lockedColumnAndRowContent.mask = lockedColumnAndRowMask;
                        lockedColumnAndRowContent.selectionLayer.mask = null;
                        lockedColumnAndRowMask.width = maskShape.width;
                        lockedColumnAndRowMask.height = maskShape.height;
                        lockedColumnAndRowMask.x = maskShape.x;
                        lockedColumnAndRowMask.y = maskShape.y;
                    }
                    if (lockedColumnHeader)
                    {
                        if (!lockedColumnHeaderMask)
                        {
                            lockedColumnHeaderMask = new Shape();
                            addChild(lockedColumnHeaderMask);
                            _loc_2 = lockedColumnHeaderMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnHeaderMask.visible = false;
                        }
                        lockedColumnHeader.mask = lockedColumnHeaderMask;
                        lockedColumnHeader.selectionLayer.mask = null;
                        lockedColumnHeaderMask.width = maskShape.width;
                        lockedColumnHeaderMask.height = maskShape.height;
                        lockedColumnHeaderMask.x = maskShape.x;
                        lockedColumnHeaderMask.y = maskShape.y;
                    }
                }
                else
                {
                    listContent.mask = null;
                    selectionLayer.mask = maskShape;
                    if (!headerMask)
                    {
                        headerMask = new Shape();
                        addChild(headerMask);
                        _loc_2 = headerMask.graphics;
                        _loc_2.beginFill(16777215);
                        _loc_2.drawRect(0, 0, 10, 10);
                        _loc_2.endFill();
                        headerMask.visible = false;
                    }
                    header.mask = null;
                    header.selectionLayer.mask = headerMask;
                    headerMask.width = maskShape.width;
                    headerMask.height = maskShape.height;
                    headerMask.x = maskShape.x;
                    headerMask.y = maskShape.y;
                    if (verticalScrollBar != null && verticalScrollBar.visible && (horizontalScrollBar == null || !horizontalScrollBar.visible) && headerVisible)
                    {
                        headerMask.width = headerMask.width + verticalScrollBar.getExplicitOrMeasuredWidth();
                    }
                    if (lockedRowContent)
                    {
                        if (!lockedRowMask)
                        {
                            lockedRowMask = new Shape();
                            addChild(lockedRowMask);
                            _loc_2 = lockedRowMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedRowMask.visible = false;
                        }
                        lockedRowContent.mask = null;
                        lockedRowContent.selectionLayer.mask = lockedRowMask;
                        lockedRowMask.width = maskShape.width;
                        lockedRowMask.height = maskShape.height;
                        lockedRowMask.x = maskShape.x;
                        lockedRowMask.y = maskShape.y;
                    }
                    if (lockedColumnContent)
                    {
                        if (!lockedColumnMask)
                        {
                            lockedColumnMask = new Shape();
                            addChild(lockedColumnMask);
                            _loc_2 = lockedColumnMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnMask.visible = false;
                        }
                        lockedColumnContent.mask = null;
                        lockedColumnContent.selectionLayer.mask = lockedColumnMask;
                        lockedColumnMask.width = maskShape.width;
                        lockedColumnMask.height = maskShape.height;
                        lockedColumnMask.x = maskShape.x;
                        lockedColumnMask.y = maskShape.y;
                    }
                    if (lockedColumnAndRowContent)
                    {
                        if (!lockedColumnAndRowMask)
                        {
                            lockedColumnAndRowMask = new Shape();
                            addChild(lockedColumnAndRowMask);
                            _loc_2 = lockedColumnAndRowMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnAndRowMask.visible = false;
                        }
                        lockedColumnAndRowContent.mask = null;
                        lockedColumnAndRowContent.selectionLayer.mask = lockedColumnAndRowMask;
                        lockedColumnAndRowMask.width = maskShape.width;
                        lockedColumnAndRowMask.height = maskShape.height;
                        lockedColumnAndRowMask.x = maskShape.x;
                        lockedColumnAndRowMask.y = maskShape.y;
                    }
                    if (lockedColumnHeader)
                    {
                        if (!lockedColumnHeaderMask)
                        {
                            lockedColumnHeaderMask = new Shape();
                            addChild(lockedColumnHeaderMask);
                            _loc_2 = lockedColumnHeaderMask.graphics;
                            _loc_2.beginFill(16777215);
                            _loc_2.drawRect(0, 0, 10, 10);
                            _loc_2.endFill();
                            lockedColumnHeaderMask.visible = false;
                        }
                        lockedColumnHeader.mask = null;
                        lockedColumnHeader.selectionLayer.mask = lockedColumnHeaderMask;
                        lockedColumnHeaderMask.width = maskShape.width;
                        lockedColumnHeaderMask.height = maskShape.height;
                        lockedColumnHeaderMask.x = maskShape.x;
                        lockedColumnHeaderMask.y = maskShape.y;
                    }
                }
            }
            if (listContent.mask)
            {
                return;
            }
            var _loc_3:* = listItems.length - 1;
            var _loc_4:* = rowInfo[_loc_3];
            var _loc_5:* = listItems[_loc_3];
            if (_loc_4.y + _loc_4.height <= listContent.height)
            {
                return;
            }
            var _loc_6:* = _loc_5.length;
            var _loc_7:* = _loc_4.y;
            var _loc_8:* = listContent.width;
            var _loc_9:* = listContent.height - _loc_4.y;
            var _loc_10:int = 0;
            while (_loc_10 < _loc_6)
            {
                
                _loc_11 = _loc_5[_loc_10];
                _loc_12 = _loc_11.y - _loc_7;
                if (_loc_11 is IUITextField)
                {
                    _loc_11.height = Math.max(_loc_9 - _loc_12, 0);
                }
                else
                {
                    _loc_11.mask = createItemMask(0, _loc_7 + _loc_12, _loc_8, Math.max(_loc_9 - _loc_12, 0));
                }
                _loc_10++;
            }
            if (lockedColumnContent)
            {
                _loc_5 = lockedColumnContent.listItems[_loc_3];
                _loc_6 = _loc_5.length;
                _loc_8 = lockedColumnContent.width;
                _loc_10 = 0;
                while (_loc_10 < _loc_6)
                {
                    
                    _loc_11 = _loc_5[_loc_10];
                    _loc_12 = _loc_11.y - _loc_7;
                    if (_loc_11 is IUITextField)
                    {
                        _loc_11.height = Math.max(_loc_9 - _loc_12, 0);
                    }
                    else
                    {
                        _loc_11.mask = createItemMask(0, _loc_7 + _loc_12, _loc_8, Math.max(_loc_9 - _loc_12, 0), lockedColumnContent);
                    }
                    _loc_10++;
                }
            }
            return;
        }// end function

        function get headerVisible() : Boolean
        {
            return showHeaders && headerHeight > 0;
        }// end function

        public function set headerHeight(param1:Number) : void
        {
            _headerHeight = param1;
            _explicitHeaderHeight = true;
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        function resizeColumn(param1:int, param2:Number) : void
        {
            return;
        }// end function

        override protected function drawCaretIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:ListBaseContentHolder = null;
            var _loc_9:Sprite = null;
            super.drawCaretIndicator(param1, param2, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
            if (lockedColumnCount)
            {
                if (param7.parent == listContent)
                {
                    _loc_8 = lockedColumnContent;
                }
                else
                {
                    _loc_8 = lockedColumnAndRowContent;
                }
                _loc_9 = _loc_8.selectionLayer;
                if (!columnCaretIndicator)
                {
                    columnCaretIndicator = new SpriteAsset();
                    _loc_8.selectionLayer.addChild(DisplayObject(columnCaretIndicator));
                }
                else if (columnCaretIndicator.parent != _loc_9)
                {
                    _loc_9.addChild(columnCaretIndicator);
                }
                else
                {
                    _loc_9.setChildIndex(DisplayObject(columnCaretIndicator), (_loc_9.numChildren - 1));
                }
                super.drawCaretIndicator(columnCaretIndicator, param2, param3, _loc_8.width, param5, param6, param7);
            }
            return;
        }// end function

        function get dataGridLockedRows() : ListBaseContentHolder
        {
            return lockedRowContent;
        }// end function

        protected function layoutColumnItemRenderer(param1:DataGridColumn, param2:IListItemRenderer, param3:Number, param4:Number) : Point
        {
            var _loc_5:Number = 0;
            var _loc_6:Number = 0;
            if (param2)
            {
                var _loc_7:* = getWidthOfItem(param2, param1);
                _loc_5 = getWidthOfItem(param2, param1);
                param2.explicitWidth = _loc_7;
                UIComponentGlobals.layoutManager.validateClient(param2, true);
                _loc_6 = param2.getExplicitOrMeasuredHeight();
                param2.setActualSize(_loc_5, variableRowHeight ? (param2.getExplicitOrMeasuredHeight()) : (rowHeight - cachedPaddingTop - cachedPaddingBottom));
                param2.move(param3, param4 + cachedPaddingTop);
            }
            return new Point(_loc_5, _loc_6);
        }// end function

        override public function showDropFeedback(event:DragEvent) : void
        {
            var _loc_3:Class = null;
            var _loc_4:EdgeMetrics = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (!dropIndicator)
            {
                _loc_3 = getStyle("dropIndicatorSkin");
                if (!_loc_3)
                {
                    _loc_3 = ListDropIndicator;
                }
                dropIndicator = IFlexDisplayObject(new _loc_3);
                _loc_4 = viewMetrics;
                drawFocus(true);
                dropIndicator.x = 2;
                dropIndicator.setActualSize(listContent.width - 4, 4);
                dropIndicator.visible = true;
                listContent.addChild(DisplayObject(dropIndicator));
                if (collection)
                {
                    dragScrollingInterval = setInterval(dragScroll, 15);
                }
            }
            var _loc_2:* = calculateDropIndex(event);
            if (lockedRowCount && _loc_2 < lockedRowCount)
            {
                if (dropIndicator.parent != lockedRowContent)
                {
                    lockedRowContent.addChild(DisplayObject(dropIndicator));
                }
                dropIndicator.y = lockedRowContent.listItems[_loc_2][0].y - 1;
            }
            else
            {
                _loc_5 = listItems.length;
                _loc_6 = _loc_5 > 0 && rowInfo[_loc_5 - offscreenExtraRowsBottom - 1].y + rowInfo[_loc_5 - offscreenExtraRowsBottom - 1].height > listContent.heightExcludingOffsets - listContent.topOffset ? (1) : (0);
                _loc_2 = _loc_2 - (verticalScrollPosition + lockedRowCount);
                if (_loc_2 >= _loc_5)
                {
                    if (_loc_6)
                    {
                        _loc_2 = _loc_5 - 1;
                    }
                    else
                    {
                        _loc_2 = _loc_5;
                    }
                }
                if (_loc_2 < 0)
                {
                    _loc_2 = 0;
                }
                if (dropIndicator.parent != listContent)
                {
                    listContent.addChild(DisplayObject(dropIndicator));
                }
                dropIndicator.y = calculateDropIndicatorY(_loc_5, _loc_2 + offscreenExtraRowsTop);
            }
            return;
        }// end function

        function columnRendererChanged(param1:DataGridColumn) : void
        {
            return;
        }// end function

        override protected function selectItem(param1:IListItemRenderer, param2:Boolean, param3:Boolean, param4:Boolean = true) : Boolean
        {
            var _loc_5:* = iterator.bookmark;
            if (lockedRowCount)
            {
                inSelectItem = true;
                iterator.seek(CursorBookmark.FIRST, 0);
            }
            var _loc_6:* = super.selectItem(param1, param2, param3, param4);
            if (lockedRowCount)
            {
                iterator.seek(_loc_5, 0);
                inSelectItem = false;
            }
            return _loc_6;
        }// end function

        function get dataGridLockedColumns() : ListBaseContentHolder
        {
            return lockedColumnContent;
        }// end function

        override protected function addToRowArrays() : void
        {
            super.addToRowArrays();
            if (lockedColumnCount)
            {
                lockedColumnContent.listItems.splice(0, 0, null);
                lockedColumnContent.rowInfo.splice(0, 0, null);
            }
            return;
        }// end function

        override public function itemRendererToIndex(param1:IListItemRenderer) : int
        {
            var _loc_2:int = 0;
            if (param1.name in rowMap)
            {
                _loc_2 = rowMap[param1.name].rowIndex;
                if (param1.parent is DataGridLockedRowContentHolder)
                {
                    return _loc_2;
                }
                return _loc_2 + lockedRowCount + verticalScrollPosition - offscreenExtraRowsTop;
            }
            return int.MIN_VALUE;
        }// end function

        override protected function makeRowsAndColumns(param1:Number, param2:Number, param3:Number, param4:Number, param5:int, param6:int, param7:Boolean = false, param8:uint = 0) : Point
        {
            return makeRows(listContent, param1, param2, param3, param4, param5, param6, param7, param8);
        }// end function

        protected function removeExtraRow(param1:ListBaseContentHolder) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_5:ListBaseContentHolder = null;
            var _loc_3:* = param1.listItems;
            var _loc_4:* = param1.rowInfo;
            if (param1 == lockedRowContent)
            {
                _loc_5 = lockedColumnAndRowContent;
            }
            else
            {
                _loc_5 = lockedColumnContent;
            }
            var _loc_6:* = _loc_3.pop();
            _loc_4.pop();
            while (_loc_6.length)
            {
                
                _loc_2 = _loc_6.pop();
                addToFreeItemRenderers(_loc_2);
            }
            if (_loc_5)
            {
                _loc_5.rowInfo.pop();
                _loc_6 = _loc_5.listItems.pop();
                while (_loc_6 && _loc_6.length)
                {
                    
                    _loc_2 = _loc_6.pop();
                    addToFreeItemRenderers(_loc_2);
                }
            }
            return;
        }// end function

        override function selectionTween_updateHandler(event:TweenEvent) : void
        {
            var _loc_2:Sprite = null;
            super.selectionTween_updateHandler(event);
            if (lockedColumnCount)
            {
                _loc_2 = Sprite(event.target.listener);
                _loc_2 = indicatorDictionary[_loc_2] as Sprite;
                _loc_2.alpha = Number(event.value);
            }
            return;
        }// end function

        override protected function purgeItemRenderers() : void
        {
            var _loc_1:Array = null;
            var _loc_2:Array = null;
            var _loc_3:IListItemRenderer = null;
            if (lockedRowContent)
            {
                _loc_1 = lockedRowContent.listItems;
                while (_loc_1.length)
                {
                    
                    _loc_2 = _loc_1.pop();
                    while (_loc_2.length)
                    {
                        
                        _loc_3 = IListItemRenderer(_loc_2.pop());
                        if (_loc_3)
                        {
                            lockedRowContent.removeChild(DisplayObject(_loc_3));
                            delete lockedRowContent.visibleData[itemToUID(_loc_3.data)];
                        }
                    }
                }
            }
            if (lockedColumnContent)
            {
                _loc_1 = lockedColumnContent.listItems;
                while (_loc_1.length)
                {
                    
                    _loc_2 = _loc_1.pop();
                    while (_loc_2.length)
                    {
                        
                        _loc_3 = IListItemRenderer(_loc_2.pop());
                        if (_loc_3)
                        {
                            lockedColumnContent.removeChild(DisplayObject(_loc_3));
                            delete lockedColumnContent.visibleData[itemToUID(_loc_3.data)];
                        }
                    }
                }
            }
            if (lockedColumnAndRowContent)
            {
                _loc_1 = lockedColumnAndRowContent.listItems;
                while (_loc_1.length)
                {
                    
                    _loc_2 = _loc_1.pop();
                    while (_loc_2.length)
                    {
                        
                        _loc_3 = IListItemRenderer(_loc_2.pop());
                        if (_loc_3)
                        {
                            lockedColumnAndRowContent.removeChild(DisplayObject(_loc_3));
                            delete lockedColumnAndRowContent.visibleData[itemToUID(_loc_3.data)];
                        }
                    }
                }
            }
            super.purgeItemRenderers();
            return;
        }// end function

        protected function clearRow(param1:ListBaseContentHolder, param2:int) : void
        {
            var _loc_4:ListBaseContentHolder = null;
            var _loc_5:IListItemRenderer = null;
            var _loc_3:* = param1.listItems;
            if (lockedColumnCount > 0)
            {
                if (param1 == lockedRowContent)
                {
                    _loc_4 = lockedColumnAndRowContent;
                }
                else
                {
                    _loc_4 = lockedColumnContent;
                }
            }
            else
            {
                _loc_4 = null;
            }
            while (_loc_3[param2].length)
            {
                
                _loc_5 = _loc_3[param2].pop();
                addToFreeItemRenderers(_loc_5);
            }
            if (_loc_4)
            {
                while (_loc_4.listItems[param2].length)
                {
                    
                    _loc_5 = _loc_4.listItems[param2].pop();
                    addToFreeItemRenderers(_loc_5);
                }
            }
            return;
        }// end function

        override protected function moveIndicatorsVertically(param1:String, param2:Number) : void
        {
            super.moveIndicatorsVertically(param1, param2);
            if (lockedColumnCount)
            {
                if (param1)
                {
                    if (selectionIndicators[param1])
                    {
                        Sprite(indicatorDictionary[selectionIndicators[param1]]).y = Sprite(indicatorDictionary[selectionIndicators[param1]]).y + param2;
                    }
                    if (highlightUID == param1)
                    {
                        columnHighlightIndicator.y = columnHighlightIndicator.y + param2;
                    }
                    if (caretUID == param1)
                    {
                        columnCaretIndicator.y = columnCaretIndicator.y + param2;
                    }
                }
            }
            return;
        }// end function

        function getAllVisibleColumns() : Array
        {
            var _loc_1:Array = [];
            if (lockedColumnCount)
            {
                _loc_1 = _loc_1.concat(visibleLockedColumns);
            }
            _loc_1 = _loc_1.concat(visibleColumns);
            return _loc_1;
        }// end function

        override protected function drawSelectionIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            var _loc_8:ListBaseContentHolder = null;
            var _loc_9:Sprite = null;
            var _loc_10:Sprite = null;
            super.drawSelectionIndicator(param1, param2, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
            if (lockedColumnCount)
            {
                if (param7.parent == listContent)
                {
                    _loc_8 = lockedColumnContent;
                }
                else
                {
                    _loc_8 = lockedColumnAndRowContent;
                }
                _loc_9 = _loc_8.selectionLayer;
                _loc_10 = indicatorDictionary[param1] as Sprite;
                if (!_loc_10)
                {
                    _loc_10 = new SpriteAsset();
                    _loc_10.mouseEnabled = false;
                    _loc_9.addChild(DisplayObject(_loc_10));
                    param1.parent.addEventListener(Event.REMOVED, selectionRemovedListener);
                    indicatorDictionary[param1] = _loc_10;
                }
                super.drawSelectionIndicator(_loc_10, param2, param3, _loc_8.width, param5, param6, param7);
            }
            return;
        }// end function

        public function get fontContext() : IFlexModuleFactory
        {
            return moduleFactory;
        }// end function

        override protected function itemRendererToIndices(param1:IListItemRenderer) : Point
        {
            if (!param1 || !(param1.name in rowMap))
            {
                return null;
            }
            var _loc_2:* = param1.parent as ListBaseContentHolder;
            var _loc_3:Boolean = false;
            var _loc_4:* = rowMap[param1.name].rowIndex;
            var _loc_5:* = _loc_2.listItems[_loc_4].length;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                if (_loc_2.listItems[_loc_4][_loc_6] == param1)
                {
                    _loc_3 = true;
                    break;
                }
                _loc_6++;
            }
            if (!_loc_3)
            {
                return null;
            }
            if (lockedRowContent == _loc_2)
            {
                return new Point(_loc_6 + horizontalScrollPosition + lockedColumnCount, _loc_4 + offscreenExtraRowsTop);
            }
            if (lockedColumnAndRowContent == _loc_2)
            {
                return new Point(_loc_6, _loc_4 + offscreenExtraRowsTop);
            }
            if (lockedColumnContent == _loc_2)
            {
                return new Point(_loc_6, _loc_4 + verticalScrollPosition + lockedRowCount + offscreenExtraRowsTop);
            }
            return new Point(_loc_6 + horizontalScrollPosition + lockedColumnCount, _loc_4 + verticalScrollPosition + lockedRowCount + offscreenExtraRowsTop);
        }// end function

        protected function updateRendererDisplayList(param1:IListItemRenderer) : void
        {
            var _loc_2:IInvalidating = null;
            if (param1 is IInvalidating)
            {
                _loc_2 = IInvalidating(param1);
                _loc_2.invalidateDisplayList();
                _loc_2.validateNow();
            }
            return;
        }// end function

        override public function indicesToIndex(param1:int, param2:int) : int
        {
            if (inSelectItem)
            {
                return 0;
            }
            return param1;
        }// end function

        override protected function clearIndicators() : void
        {
            super.clearIndicators();
            if (lockedColumnCount && lockedColumnContent)
            {
                while (lockedColumnContent.selectionLayer.numChildren > 0)
                {
                    
                    lockedColumnContent.selectionLayer.removeChildAt(0);
                }
            }
            if (lockedRowCount && lockedRowContent)
            {
                while (lockedRowContent.selectionLayer.numChildren > 0)
                {
                    
                    lockedRowContent.selectionLayer.removeChildAt(0);
                }
                if (lockedColumnCount && lockedColumnAndRowContent)
                {
                    while (lockedColumnAndRowContent.selectionLayer.numChildren > 0)
                    {
                        
                        lockedColumnAndRowContent.selectionLayer.removeChildAt(0);
                    }
                }
            }
            if (header)
            {
                header.clearSelectionLayer();
            }
            if (lockedColumnHeader)
            {
                lockedColumnHeader.clearSelectionLayer();
            }
            return;
        }// end function

        protected function makeListData(param1:Object, param2:String, param3:int, param4:int, param5:DataGridColumn) : BaseListData
        {
            if (param1 is DataGridColumn)
            {
                return new DataGridListData(param5.headerText != null ? (param5.headerText) : (param5.dataField), param5.dataField, param4, param2, this, param3);
                ;
            }
            return new DataGridListData(param5.itemToLabel(param1), param5.dataField, param4, param2, this, param3);
        }// end function

        override protected function drawItem(param1:IListItemRenderer, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:Boolean = false) : void
        {
            var _loc_7:int = 0;
            var _loc_8:IListItemRenderer = null;
            var _loc_9:ListBaseContentHolder = null;
            if (!param1)
            {
                return;
            }
            super.drawItem(param1, param2, param3, param4, param5);
            var _loc_6:* = rowMap[param1.name].rowIndex;
            _loc_7 = 0;
            while (_loc_7 < visibleColumns.length)
            {
                
                _loc_8 = (param1.parent as ListBaseContentHolder).listItems[_loc_6][_loc_7];
                updateRendererDisplayList(_loc_8);
                _loc_7++;
            }
            if (lockedColumnCount)
            {
                if (param1.parent == listContent || param1.parent == lockedColumnContent)
                {
                    _loc_9 = lockedColumnContent;
                }
                else
                {
                    _loc_9 = lockedColumnAndRowContent;
                }
                _loc_7 = 0;
                while (_loc_7 < visibleLockedColumns.length)
                {
                    
                    _loc_8 = _loc_9.listItems[_loc_6][_loc_7];
                    updateRendererDisplayList(_loc_8);
                    _loc_7++;
                }
            }
            return;
        }// end function

        override protected function adjustAfterRemove(param1:Array, param2:int, param3:Boolean) : Boolean
        {
            var firstUID:String;
            var i:int;
            var uid:String;
            var items:* = param1;
            var location:* = param2;
            var requiresValueCommit:* = param3;
            var adjustIterator:Boolean;
            if (lockedRowCount && listItems.length && listItems[0].length)
            {
                if (location <= lockedRowCount + verticalScrollPosition)
                {
                    adjustIterator;
                }
                else
                {
                    firstUID = rowMap[listItems[0][0].name].uid;
                    i;
                    while (i < items.length)
                    {
                        
                        uid = itemToUID(items[i]);
                        if (uid == firstUID && verticalScrollPosition == 0)
                        {
                            adjustIterator;
                            break;
                        }
                        i = (i + 1);
                    }
                }
            }
            var retval:* = super.adjustAfterRemove(items, location, requiresValueCommit);
            if (lockedRowCount)
            {
                if (verticalScrollPosition > 0 && location > lockedRowCount && verticalScrollPosition <= lockedRowCount && verticalScrollPosition == maxVerticalScrollPosition)
                {
                    super.verticalScrollPosition = verticalScrollPosition - items.length;
                    adjustIterator;
                }
                if (adjustIterator)
                {
                    try
                    {
                        iterator.seek(CursorBookmark.FIRST, lockedRowCount + verticalScrollPosition);
                        if (!iteratorValid)
                        {
                            iteratorValid = true;
                            lastSeekPending = null;
                        }
                    }
                    catch (e:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, lockedRowCount + verticalScrollPosition);
                        e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                    }
                }
            }
            return retval;
        }// end function

        override protected function clearCaretIndicator(param1:Sprite, param2:IListItemRenderer) : void
        {
            super.clearCaretIndicator(param1, param2);
            if (lockedColumnCount)
            {
                if (columnCaretIndicator)
                {
                    Sprite(columnCaretIndicator).graphics.clear();
                }
            }
            return;
        }// end function

        public function get lockedRowCount() : int
        {
            return _lockedRowCount;
        }// end function

        function get gridColumnMap() : Object
        {
            return columnMap;
        }// end function

        override protected function UIDToItemRenderer(param1:String) : IListItemRenderer
        {
            var _loc_2:* = visibleData[param1];
            if (!_loc_2)
            {
                if (lockedRowContent)
                {
                    _loc_2 = lockedRowContent.visibleData[param1];
                }
            }
            if (!_loc_2)
            {
                if (lockedColumnContent)
                {
                    _loc_2 = lockedColumnContent.visibleData[param1];
                }
            }
            if (!_loc_2)
            {
                if (lockedColumnAndRowContent)
                {
                    _loc_2 = lockedColumnAndRowContent.visibleData[param1];
                }
            }
            return _loc_2;
        }// end function

        override protected function destroyRow(param1:int, param2:int) : void
        {
            var _loc_3:Array = null;
            var _loc_4:Array = null;
            var _loc_5:Object = null;
            var _loc_6:IListItemRenderer = null;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            super.destroyRow(param1, param2);
            if (lockedColumnCount)
            {
                _loc_3 = lockedColumnContent.listItems;
                param2 = _loc_3[param1].length;
                _loc_4 = lockedColumnContent.rowInfo;
                _loc_5 = lockedColumnContent.visibleData;
                _loc_7 = _loc_4[param1].uid;
                removeIndicators(_loc_7);
                _loc_8 = 0;
                while (_loc_8 < param2)
                {
                    
                    _loc_6 = _loc_3[param1][_loc_8];
                    if (_loc_6.data)
                    {
                        delete _loc_5[_loc_7];
                    }
                    addToFreeItemRenderers(_loc_6);
                    _loc_8++;
                }
            }
            return;
        }// end function

        public function createColumnItemRenderer(param1:DataGridColumn, param2:Boolean, param3:Object) : IListItemRenderer
        {
            var _loc_4:IFactory = null;
            var _loc_5:IListItemRenderer = null;
            var _loc_6:Dictionary = null;
            var _loc_7:* = undefined;
            _loc_4 = param1.getItemRendererFactory(param2, param3);
            if (!_loc_4)
            {
                if (!param3)
                {
                    _loc_4 = nullItemRenderer;
                }
                if (!_loc_4)
                {
                    _loc_4 = itemRenderer;
                }
            }
            if (_loc_4 == param1.itemRenderer)
            {
                if (freeItemRenderersTable[param1] && freeItemRenderersTable[param1].length)
                {
                    _loc_5 = freeItemRenderersTable[param1].pop();
                    delete param1.freeItemRenderersByFactory[_loc_4][_loc_5];
                }
            }
            else if (param1.freeItemRenderersByFactory)
            {
                _loc_6 = param1.freeItemRenderersByFactory[_loc_4];
                if (_loc_6)
                {
                    for (_loc_7 in _loc_6)
                    {
                        
                        _loc_5 = IListItemRenderer(_loc_7);
                        delete _loc_6[_loc_7];
                        break;
                    }
                }
            }
            if (!_loc_5)
            {
                _loc_5 = _loc_4.newInstance();
                if (_loc_5)
                {
                    _loc_5.styleName = param1;
                    factoryMap[_loc_5] = _loc_4;
                }
            }
            if (_loc_5)
            {
                _loc_5.owner = this;
            }
            return _loc_5;
        }// end function

        public function set showHeaders(param1:Boolean) : void
        {
            if (param1 == _showHeaders)
            {
                return;
            }
            _showHeaders = param1;
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("showHeadersChanged"));
            return;
        }// end function

        override protected function addToFreeItemRenderers(param1:IListItemRenderer) : void
        {
            var _loc_5:DataGridColumn = null;
            DisplayObject(param1).visible = false;
            delete rowMap[param1.name];
            var _loc_2:* = factoryMap[param1];
            var _loc_3:* = itemToUID(param1.data);
            var _loc_4:* = ListBaseContentHolder(param1.parent).visibleData;
            if (ListBaseContentHolder(param1.parent).visibleData[_loc_3] == param1)
            {
                delete _loc_4[_loc_3];
            }
            if (columnMap[param1.name])
            {
                _loc_5 = columnMap[param1.name];
                if (_loc_2 == _loc_5.itemRenderer)
                {
                    if (freeItemRenderersTable[_loc_5] == undefined)
                    {
                        freeItemRenderersTable[_loc_5] = [];
                    }
                    freeItemRenderersTable[_loc_5].push(param1);
                }
                if (!_loc_5.freeItemRenderersByFactory)
                {
                    _loc_5.freeItemRenderersByFactory = new Dictionary(true);
                }
                if (_loc_5.freeItemRenderersByFactory[_loc_2] == undefined)
                {
                    _loc_5.freeItemRenderersByFactory[_loc_2] = new Dictionary(true);
                }
                _loc_5.freeItemRenderersByFactory[_loc_2][param1] = 1;
                delete columnMap[param1.name];
            }
            return;
        }// end function

        override protected function moveSelectionVertically(param1:uint, param2:Boolean, param3:Boolean) : void
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
                        bSelectItem = true;
                        if (caretIndex >= lockedRowCount)
                        {
                            _loc_12 = true;
                        }
                    }
                    break;
                }
                case Keyboard.DOWN:
                {
                    if (caretIndex >= (lockedRowCount - 1))
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
                    }
                    else if (caretIndex < (collection.length - 1))
                    {
                        var _loc_15:* = caretIndex + 1;
                        caretIndex = _loc_15;
                        bSelectItem = true;
                    }
                    break;
                }
                case Keyboard.PAGE_UP:
                {
                    if (caretIndex > lockedRowCount)
                    {
                        if (caretIndex > verticalScrollPosition + lockedRowCount && caretIndex < verticalScrollPosition + lockedRowCount + _loc_10)
                        {
                            caretIndex = verticalScrollPosition + lockedRowCount;
                        }
                        else
                        {
                            caretIndex = Math.max(caretIndex - Math.max(_loc_10 - _loc_11, 1), lockedRowCount);
                            _loc_4 = Math.max(caretIndex, lockedRowCount) - lockedRowCount;
                        }
                        bSelectItem = true;
                    }
                    else
                    {
                        caretIndex = 0;
                        bSelectItem = true;
                    }
                    break;
                }
                case Keyboard.PAGE_DOWN:
                {
                    if (caretIndex >= verticalScrollPosition + lockedRowCount && caretIndex < verticalScrollPosition + lockedRowCount + _loc_10 - _loc_11 - 1)
                    {
                    }
                    else
                    {
                        if (caretIndex - lockedRowCount == verticalScrollPosition && _loc_10 - _loc_11 <= 1)
                        {
                            var _loc_15:* = caretIndex + 1;
                            caretIndex = _loc_15;
                        }
                        _loc_4 = Math.min(Math.max(caretIndex - lockedRowCount, 0), maxVerticalScrollPosition);
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
                    if (lockedRowCount >= collection.length)
                    {
                        caretIndex = collection.length - 1;
                        bSelectItem = true;
                    }
                    else if (caretIndex < (collection.length - 1))
                    {
                        caretIndex = collection.length - 1;
                        bSelectItem = true;
                        _loc_4 = maxVerticalScrollPosition;
                    }
                    break;
                }
                case Keyboard.SPACE:
                {
                    _loc_12 = true;
                    bSelectItem = true;
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (_loc_12)
            {
                if (caretIndex >= verticalScrollPosition + lockedRowCount + _loc_10 - _loc_11)
                {
                    if (_loc_10 - _loc_11 == 0)
                    {
                        _loc_4 = Math.min(maxVerticalScrollPosition, Math.max(caretIndex - lockedRowCount, 0));
                    }
                    else
                    {
                        _loc_4 = Math.min(maxVerticalScrollPosition, caretIndex - lockedRowCount - _loc_10 + _loc_11 + 1);
                    }
                }
                else if (caretIndex < verticalScrollPosition + lockedRowCount)
                {
                    _loc_4 = Math.max(caretIndex - lockedRowCount, 0);
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

        override protected function set allowItemSizeChangeNotification(param1:Boolean) : void
        {
            if (lockedColumnContent)
            {
                lockedColumnContent.allowItemSizeChangeNotification = param1;
            }
            if (lockedRowContent)
            {
                lockedRowContent.allowItemSizeChangeNotification = param1;
            }
            if (lockedColumnAndRowContent)
            {
                lockedColumnAndRowContent.allowItemSizeChangeNotification = param1;
            }
            super.allowItemSizeChangeNotification = param1;
            return;
        }// end function

        override protected function clearVisibleData() : void
        {
            if (lockedColumnContent)
            {
                lockedColumnContent.visibleData = {};
            }
            if (lockedRowContent)
            {
                lockedRowContent.visibleData = {};
            }
            if (lockedColumnAndRowContent)
            {
                lockedColumnAndRowContent.visibleData = {};
            }
            super.clearVisibleData();
            return;
        }// end function

        override protected function moveRowVertically(param1:int, param2:int, param3:Number) : void
        {
            var _loc_4:Array = null;
            var _loc_5:Array = null;
            var _loc_6:IListItemRenderer = null;
            var _loc_7:int = 0;
            super.moveRowVertically(param1, param2, param3);
            if (lockedColumnCount)
            {
                _loc_4 = lockedColumnContent.listItems;
                param2 = _loc_4[param1].length;
                _loc_5 = lockedColumnContent.rowInfo;
                _loc_7 = 0;
                while (_loc_7 < param2)
                {
                    
                    _loc_6 = _loc_4[param1][_loc_7];
                    _loc_4[param1][_loc_7].move(_loc_6.x, _loc_6.y + param3);
                    _loc_7++;
                }
            }
            return;
        }// end function

        override function mouseEventToItemRendererOrEditor(event:MouseEvent) : IListItemRenderer
        {
            var _loc_4:ListBaseContentHolder = null;
            var _loc_6:Array = null;
            var _loc_7:Array = null;
            var _loc_8:Point = null;
            var _loc_9:Number = NaN;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:Number = NaN;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_2:Boolean = false;
            var _loc_3:* = DisplayObject(event.target);
            var _loc_5:* = this.visibleColumns;
            if (event.target == listContent)
            {
                _loc_4 = listContent;
            }
            else if (event.target == lockedColumnContent)
            {
                _loc_4 = lockedColumnContent;
                _loc_5 = visibleLockedColumns;
            }
            else if (event.target == lockedRowContent)
            {
                _loc_4 = lockedRowContent;
            }
            else if (event.target == lockedColumnAndRowContent)
            {
                _loc_4 = lockedColumnAndRowContent;
                _loc_5 = visibleLockedColumns;
            }
            else if (event.target == highlightIndicator)
            {
                _loc_4 = highlightIndicator.parent.parent as ListBaseContentHolder;
                _loc_5 = this.visibleColumns;
                if (_loc_4 == lockedColumnContent || _loc_4 == lockedColumnAndRowContent)
                {
                    _loc_5 = visibleLockedColumns;
                }
                _loc_2 = true;
            }
            else if (event.target == columnHighlightIndicator)
            {
                _loc_4 = columnHighlightIndicator.parent.parent as ListBaseContentHolder;
                _loc_5 = this.visibleColumns;
                if (_loc_4 == lockedColumnContent || _loc_4 == lockedColumnAndRowContent)
                {
                    _loc_5 = visibleLockedColumns;
                }
                _loc_2 = true;
            }
            if (_loc_2 || _loc_3 == _loc_4)
            {
                _loc_6 = _loc_4.listItems;
                _loc_7 = _loc_4.rowInfo;
                _loc_8 = new Point(event.stageX, event.stageY);
                _loc_8 = _loc_4.globalToLocal(_loc_8);
                _loc_9 = 0;
                _loc_10 = _loc_6.length;
                _loc_11 = 0;
                while (_loc_11 < _loc_10)
                {
                    
                    if (_loc_6[_loc_11].length)
                    {
                        if (_loc_8.y < _loc_9 + _loc_7[_loc_11].height)
                        {
                            _loc_12 = 0;
                            _loc_13 = _loc_5.length;
                            _loc_14 = 0;
                            while (_loc_14 < _loc_13)
                            {
                                
                                if (_loc_8.x < _loc_12 + _loc_5[_loc_14].width)
                                {
                                    return _loc_6[_loc_11][_loc_14];
                                }
                                _loc_12 = _loc_12 + _loc_5[_loc_14].width;
                                _loc_14++;
                            }
                        }
                    }
                    _loc_9 = _loc_9 + _loc_7[_loc_11].height;
                    _loc_11++;
                }
            }
            while (_loc_3 && _loc_3 != this)
            {
                
                if (_loc_3 is IListItemRenderer && _loc_3.parent && _loc_3.parent.parent == this && _loc_3.parent is ListBaseContentHolder)
                {
                    if (_loc_3.visible)
                    {
                        return IListItemRenderer(_loc_3);
                    }
                    break;
                }
                if (_loc_3 is IUIComponent)
                {
                    _loc_3 = IUIComponent(_loc_3).owner;
                    continue;
                }
                _loc_3 = _loc_3.parent;
            }
            return null;
        }// end function

        function getWidthOfItem(param1:IListItemRenderer, param2:DataGridColumn) : Number
        {
            return param2.width;
        }// end function

        override protected function indexToRow(param1:int) : int
        {
            if (param1 < lockedRowCount)
            {
                return -1;
            }
            return param1 - lockedRowCount;
        }// end function

        function get dataGridHeader() : DataGridHeaderBase
        {
            return header;
        }// end function

        public function set fontContext(param1:IFlexModuleFactory) : void
        {
            this.moduleFactory = param1;
            return;
        }// end function

        protected function drawVisibleItem(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:Boolean = false) : void
        {
            if (visibleData[param1])
            {
                drawItem(visibleData[param1], param2, param3, param4, param5);
            }
            if (lockedRowCount && lockedRowContent && lockedRowContent.visibleData[param1])
            {
                drawItem(lockedRowContent.visibleData[param1], param2, param3, param4, param5);
            }
            return;
        }// end function

        protected function prepareRowArray(param1:ListBaseContentHolder, param2:int) : void
        {
            var _loc_4:ListBaseContentHolder = null;
            var _loc_3:* = param1.listItems;
            if (lockedColumnCount > 0)
            {
                if (param1 == lockedRowContent)
                {
                    _loc_4 = lockedColumnAndRowContent;
                }
                else
                {
                    _loc_4 = lockedColumnContent;
                }
            }
            else
            {
                _loc_4 = null;
            }
            if (!_loc_3[param2])
            {
                _loc_3[param2] = [];
            }
            if (_loc_4)
            {
                if (!_loc_4.listItems[param2])
                {
                    _loc_4.listItems[param2] = [];
                }
            }
            return;
        }// end function

        public function get showHeaders() : Boolean
        {
            return _showHeaders;
        }// end function

        protected function adjustRow(param1:ListBaseContentHolder, param2:int, param3:Number, param4:Number) : void
        {
            var _loc_6:ListBaseContentHolder = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:IListItemRenderer = null;
            var _loc_5:* = param1.listItems;
            if (lockedColumnCount > 0)
            {
                if (param1 == lockedRowContent)
                {
                    _loc_6 = lockedColumnAndRowContent;
                }
                else
                {
                    _loc_6 = lockedColumnContent;
                }
            }
            else
            {
                _loc_6 = null;
            }
            if (_loc_5[param2])
            {
                if (_loc_6)
                {
                    _loc_9 = _loc_6.listItems[param2].length;
                    _loc_8 = 0;
                    while (_loc_8 < _loc_9)
                    {
                        
                        _loc_6.listItems[param2][_loc_8].setActualSize(_loc_6.listItems[param2][_loc_8].width, param4 - cachedPaddingTop - cachedPaddingBottom);
                        _loc_8++;
                    }
                }
                _loc_9 = _loc_5[param2].length;
                _loc_8 = 0;
                while (_loc_8 < _loc_9)
                {
                    
                    _loc_5[param2][_loc_8].setActualSize(_loc_5[param2][_loc_8].width, param4 - cachedPaddingTop - cachedPaddingBottom);
                    _loc_8++;
                }
            }
            if (cachedVerticalAlign != "top")
            {
                if (cachedVerticalAlign == "bottom")
                {
                    _loc_10 = _loc_5[param2].length;
                    _loc_8 = 0;
                    while (_loc_8 < _loc_10)
                    {
                        
                        _loc_11 = _loc_5[param2][_loc_8];
                        _loc_5[param2][_loc_8].move(_loc_11.x, param3 + param4 - cachedPaddingBottom - _loc_11.getExplicitOrMeasuredHeight());
                        _loc_8++;
                    }
                    if (_loc_6)
                    {
                        _loc_9 = _loc_6.listItems[param2].length;
                        _loc_8 = 0;
                        while (_loc_8 < _loc_9)
                        {
                            
                            _loc_11 = _loc_6.listItems[param2][_loc_8];
                            _loc_6.listItems[param2][_loc_8].move(_loc_11.x, param3 + param4 - cachedPaddingBottom - _loc_11.getExplicitOrMeasuredHeight());
                            _loc_8++;
                        }
                    }
                }
                else
                {
                    _loc_10 = _loc_5[param2].length;
                    _loc_8 = 0;
                    while (_loc_8 < _loc_10)
                    {
                        
                        _loc_11 = _loc_5[param2][_loc_8];
                        _loc_5[param2][_loc_8].move(_loc_11.x, param3 + cachedPaddingTop + (param4 - cachedPaddingBottom - cachedPaddingTop - _loc_11.getExplicitOrMeasuredHeight()) / 2);
                        _loc_8++;
                    }
                    if (_loc_6)
                    {
                        _loc_9 = _loc_6.listItems[param2].length;
                        _loc_8 = 0;
                        while (_loc_8 < _loc_9)
                        {
                            
                            _loc_11 = _loc_6.listItems[param2][_loc_8];
                            _loc_6.listItems[param2][_loc_8].move(_loc_11.x, param3 + cachedPaddingTop + (param4 - cachedPaddingBottom - cachedPaddingTop - _loc_11.getExplicitOrMeasuredHeight()) / 2);
                            _loc_8++;
                        }
                    }
                }
            }
            return;
        }// end function

        override protected function restoreRowArrays(param1:int) : void
        {
            super.restoreRowArrays(param1);
            if (lockedColumnCount)
            {
                lockedColumnContent.listItems.splice(0, param1);
                lockedColumnContent.rowInfo.splice(0, param1);
            }
            return;
        }// end function

        protected function setupColumnItemRenderer(param1:DataGridColumn, param2:ListBaseContentHolder, param3:int, param4:int, param5:Object, param6:String) : IListItemRenderer
        {
            var _loc_8:IListItemRenderer = null;
            var _loc_9:DataGridListData = null;
            var _loc_7:* = param2.listItems;
            _loc_8 = param2.listItems[param3][param4];
            if (!_loc_8 || itemToUID(_loc_8.data) != param6 || columnMap[_loc_8.name] != param1)
            {
                _loc_8 = createColumnItemRenderer(param1, false, param5);
                if (_loc_8 == null)
                {
                    return null;
                }
                if (_loc_8.parent != param2)
                {
                    param2.addChild(DisplayObject(_loc_8));
                }
                columnMap[_loc_8.name] = param1;
                if (_loc_7[param3][param4])
                {
                    addToFreeItemRenderers(_loc_7[param3][param4]);
                }
                _loc_7[param3][param4] = _loc_8;
            }
            _loc_9 = DataGridListData(makeListData(param5, param6, param3, param1.colNum, param1));
            rowMap[_loc_8.name] = _loc_9;
            if (_loc_8 is IDropInListItemRenderer)
            {
                IDropInListItemRenderer(_loc_8).listData = param5 ? (_loc_9) : (null);
            }
            _loc_8.data = param5;
            _loc_8.visible = true;
            if (param6 && param4 == 0)
            {
                param2.visibleData[param6] = _loc_8;
            }
            return _loc_8;
        }// end function

        override protected function adjustAfterAdd(param1:Array, param2:int) : Boolean
        {
            var items:* = param1;
            var location:* = param2;
            var retval:* = super.adjustAfterAdd(items, location);
            if (lockedRowCount)
            {
                if (verticalScrollPosition > 0 && verticalScrollPosition >= location && location <= lockedRowCount)
                {
                    if (verticalScrollPosition + lockedRowCount >= collection.length)
                    {
                        super.verticalScrollPosition = verticalScrollPosition - items.length;
                    }
                }
                if (collection.length - items.length <= lockedRowCount && collection.length >= lockedRowCount || location <= lockedRowCount || location == lockedRowCount + verticalScrollPosition)
                {
                    try
                    {
                        iterator.seek(CursorBookmark.FIRST, lockedRowCount + verticalScrollPosition);
                        if (!iteratorValid)
                        {
                            iteratorValid = true;
                            lastSeekPending = null;
                        }
                    }
                    catch (e:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, lockedRowCount + verticalScrollPosition);
                        e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                    }
                }
            }
            return retval;
        }// end function

        protected function calculateRowHeight(param1:Object, param2:Number, param3:Boolean = false) : Number
        {
            return NaN;
        }// end function

        public function set columns(param1:Array) : void
        {
            return;
        }// end function

        public function get columns() : Array
        {
            return null;
        }// end function

        public function set lockedColumnCount(param1:int) : void
        {
            _lockedColumnCount = param1;
            lockedColumnCountChanged = true;
            itemsSizeChanged = true;
            columnsInvalid = true;
            invalidateDisplayList();
            return;
        }// end function

        function get dataGridLockedColumnHeader() : DataGridHeaderBase
        {
            return lockedColumnHeader;
        }// end function

        protected function makeRows(param1:ListBaseContentHolder, param2:Number, param3:Number, param4:Number, param5:Number, param6:int, param7:int, param8:Boolean = false, param9:uint = 0, param10:Boolean = false) : Point
        {
            var xx:Number;
            var yy:Number;
            var hh:Number;
            var i:int;
            var j:int;
            var n:int;
            var item:IListItemRenderer;
            var data:Object;
            var uid:String;
            var contentHolder:* = param1;
            var left:* = param2;
            var top:* = param3;
            var right:* = param4;
            var bottom:* = param5;
            var firstCol:* = param6;
            var firstRow:* = param7;
            var byCount:* = param8;
            var rowsNeeded:* = param9;
            var alwaysCleanup:* = param10;
            var bSelected:Boolean;
            var bHighlight:Boolean;
            var bCaret:Boolean;
            var colNum:int;
            var rowNum:int;
            var rowsMade:int;
            var listItems:* = contentHolder.listItems;
            var iterator:* = contentHolder.iterator;
            var visibleData:* = contentHolder.visibleData;
            var rowInfo:* = contentHolder.rowInfo;
            if ((!visibleColumns || visibleColumns.length == 0) && lockedColumnCount == 0)
            {
                while (listItems.length)
                {
                    
                    rowNum = (listItems.length - 1);
                    while (listItems[rowNum].length)
                    {
                        
                        item = listItems[rowNum].pop();
                        addToFreeItemRenderers(item);
                    }
                    listItems.pop();
                }
                contentHolder.visibleData = {};
                return new Point(0, 0);
            }
            invalidateSizeFlag = true;
            var more:Boolean;
            var valid:Boolean;
            yy = top;
            rowNum = firstRow;
            more = iterator != null && !iterator.afterLast && iteratorValid;
            while (!byCount && yy < bottom || byCount && rowsNeeded > 0)
            {
                
                if (byCount)
                {
                    rowsNeeded = (rowsNeeded - 1);
                }
                valid = more;
                data = more ? (iterator.current) : (null);
                if (iterator && more)
                {
                    try
                    {
                        more = iterator.moveNext();
                    }
                    catch (e:ItemPendingError)
                    {
                        lastSeekPending = new ListBaseSeekPending(CursorBookmark.CURRENT, 0);
                        e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        more;
                        iteratorValid = false;
                    }
                }
                hh;
                uid;
                prepareRowArray(contentHolder, rowNum);
                if (valid)
                {
                    uid = itemToUID(data);
                    hh = makeRow(contentHolder, rowNum, left, right, yy, data, uid);
                }
                else
                {
                    hh = rowNum > 1 ? (rowInfo[(rowNum - 1)].height) : (rowHeight);
                }
                if (valid && variableRowHeight)
                {
                    hh = Math.ceil(calculateRowHeight(data, hh, true));
                }
                if (valid)
                {
                    adjustRow(contentHolder, rowNum, yy, hh);
                }
                else
                {
                    clearRow(contentHolder, rowNum);
                }
                bSelected = selectedData[uid] != null;
                bHighlight = highlightUID == uid;
                bCaret = caretUID == uid;
                setRowInfo(contentHolder, rowNum, yy, hh, uid);
                if (valid)
                {
                    drawVisibleItem(uid, bSelected, bHighlight, bCaret);
                }
                if (hh == 0)
                {
                    hh = rowHeight;
                }
                yy = yy + hh;
                rowNum = (rowNum + 1);
                rowsMade = (rowsMade + 1);
            }
            if (!byCount || alwaysCleanup)
            {
                while (rowNum < listItems.length)
                {
                    
                    removeExtraRow(contentHolder);
                }
            }
            invalidateSizeFlag = false;
            return new Point(colNum, rowsMade);
        }// end function

        override protected function clearHighlightIndicator(param1:Sprite, param2:IListItemRenderer) : void
        {
            super.clearHighlightIndicator(param1, param2);
            if (lockedColumnCount)
            {
                if (columnHighlightIndicator)
                {
                    Sprite(columnHighlightIndicator).graphics.clear();
                }
            }
            return;
        }// end function

        function columnWordWrap(param1:DataGridColumn) : Boolean
        {
            if (param1.wordWrap == true)
            {
                return true;
            }
            if (param1.wordWrap == false)
            {
                return false;
            }
            return wordWrap;
        }// end function

        protected function setRowInfo(param1:ListBaseContentHolder, param2:int, param3:Number, param4:Number, param5:String) : void
        {
            var _loc_8:ListBaseContentHolder = null;
            var _loc_6:* = param1.listItems;
            var _loc_7:* = param1.rowInfo;
            if (lockedColumnCount > 0)
            {
                if (param1 == lockedRowContent)
                {
                    _loc_8 = lockedColumnAndRowContent;
                }
                else
                {
                    _loc_8 = lockedColumnContent;
                }
            }
            else
            {
                _loc_8 = null;
            }
            _loc_7[param2] = new ListRowInfo(param3, param4, param5);
            if (_loc_8)
            {
                _loc_8.rowInfo[param2] = _loc_7[param2];
            }
            return;
        }// end function

        override protected function truncateRowArrays(param1:int) : void
        {
            super.truncateRowArrays(param1);
            if (lockedColumnCount)
            {
                lockedColumnContent.listItems.splice(param1);
                lockedColumnContent.rowInfo.splice(param1);
            }
            return;
        }// end function

        public function get lockedColumnCount() : int
        {
            return _lockedColumnCount;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            if (headerVisible && header)
            {
                header.visibleColumns = visibleColumns;
                header.headerItemsChanged = true;
                header.invalidateSize();
                header.validateNow();
            }
            if (lockedColumnCountChanged)
            {
                lockedColumnCountChanged = false;
                if (lockedColumnCount > 0)
                {
                    if (!lockedColumnContent)
                    {
                        lockedColumnHeader = new headerClass();
                        lockedColumnHeader.styleName = this;
                        addChild(lockedColumnHeader);
                        lockedColumnAndRowContent = new DataGridLockedRowContentHolder(this);
                        lockedColumnAndRowContent.styleName = this;
                        addChild(lockedColumnAndRowContent);
                        lockedColumnContent = new ListBaseContentHolder(this);
                        lockedColumnContent.styleName = this;
                        addChild(lockedColumnContent);
                    }
                    lockedColumnHeader.visible = true;
                    lockedColumnAndRowContent.visible = lockedRowCount > 0;
                    lockedColumnContent.visible = true;
                }
                else if (lockedColumnContent)
                {
                    lockedColumnHeader.visible = false;
                    lockedColumnAndRowContent.visible = false;
                    lockedColumnContent.visible = false;
                }
            }
            if (lockedRowCountChanged && iterator)
            {
                lockedRowCountChanged = false;
                if (lockedRowCount > 0)
                {
                    if (!lockedRowContent)
                    {
                        lockedRowContent = new DataGridLockedRowContentHolder(this);
                        lockedRowContent.styleName = this;
                        addChild(lockedRowContent);
                    }
                    lockedRowContent.visible = true;
                }
                else if (lockedRowContent)
                {
                    lockedRowContent.visible = false;
                }
                if (lockedColumnAndRowContent)
                {
                    lockedColumnAndRowContent.visible = lockedRowCount > 0 && lockedColumnCount > 0;
                }
                seekPositionSafely(lockedRowCount + verticalScrollPosition);
            }
            if (lockedRowContent && lockedColumnAndRowContent)
            {
                _loc_4 = getChildIndex(lockedColumnAndRowContent);
                _loc_3 = getChildIndex(lockedRowContent);
                if (_loc_4 < _loc_3)
                {
                    setChildIndex(lockedRowContent, _loc_4);
                }
            }
            if (lockedColumnContent && lockedColumnAndRowContent)
            {
                _loc_4 = getChildIndex(lockedColumnAndRowContent);
                _loc_3 = getChildIndex(lockedColumnContent);
                if (_loc_4 < _loc_3)
                {
                    setChildIndex(lockedColumnContent, _loc_4);
                }
            }
            if (headerVisible && lockedColumnHeader)
            {
                lockedColumnHeader.visibleColumns = visibleLockedColumns;
                lockedColumnHeader.headerItemsChanged = true;
                lockedColumnHeader.invalidateSize();
                lockedColumnHeader.validateNow();
            }
            super.updateDisplayList(param1, param2);
            return;
        }// end function

        public function set lockedRowCount(param1:int) : void
        {
            _lockedRowCount = param1;
            lockedRowCountChanged = true;
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

    }
}
