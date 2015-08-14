package mx.controls
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
    import mx.controls.scrollClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.skins.halo.*;
    import mx.styles.*;
    import mx.utils.*;

    public class DataGrid extends DataGridBase implements IIMESupport
    {
        private var lastItemDown:IListItemRenderer;
        public var itemEditorInstance:IListItemRenderer;
        private var displayableColumns:Array;
        private var displayWidth:Number;
        var resizingColumn:DataGridColumn;
        private var dontEdit:Boolean = false;
        var movingColumn:DataGridColumn;
        private var generatedColumns:Boolean = true;
        private var lastEditedItemPosition:Object;
        private var _headerWordWrapPresent:Boolean = false;
        public var editable:Boolean = false;
        private var losingFocus:Boolean = false;
        private var lastItemFocused:DisplayObject;
        private var _originalHeaderHeight:Number = 0;
        private var _minColumnWidth:Number;
        var sortDirection:String;
        private var manualSort:Boolean;
        private var bEditedItemPositionChanged:Boolean = false;
        private var sortColumn:DataGridColumn;
        private var actualContentHolder:ListBaseContentHolder;
        private var _columns:Array;
        private var inEndEdit:Boolean = false;
        private var lockedColumnWidth:Number = 0;
        public var resizableColumns:Boolean = true;
        private var _originalExplicitHeaderHeight:Boolean = false;
        private var minColumnWidthInvalid:Boolean = false;
        private var _editedItemPosition:Object;
        private var _imeMode:String = null;
        private var actualRowIndex:int;
        private var _proposedEditedItemPosition:Object;
        private var itemEditorPositionChanged:Boolean = false;
        var sortIndex:int = -1;
        private var skipHeaderUpdate:Boolean = false;
        var lastSortIndex:int = -1;
        private var actualColIndex:int;
        var lockedColumnDropIndicator:IFlexDisplayObject;
        public var sortableColumns:Boolean = true;
        private var collectionUpdatesDisabled:Boolean = false;
        private var _draggableColumns:Boolean = true;
        private var _focusPane:Sprite;
        static const VERSION:String = "3.5.0.12683";
        static var createAccessibilityImplementation:Function;

        public function DataGrid()
        {
            _columns = [];
            setRowHeight(20);
            addEventListener(DataGridEvent.ITEM_EDIT_BEGINNING, itemEditorItemEditBeginningHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(DataGridEvent.ITEM_EDIT_BEGIN, itemEditorItemEditBeginHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(DataGridEvent.ITEM_EDIT_END, itemEditorItemEditEndHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(DataGridEvent.HEADER_RELEASE, headerReleaseHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler);
            return;
        }// end function

        function _drawHeaderBackground(param1:UIComponent) : void
        {
            drawHeaderBackground(param1);
            return;
        }// end function

        override public function measureWidthOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var _loc_3:Number = 0;
            var _loc_4:* = columns ? (columns.length) : (0);
            var _loc_5:int = 0;
            while (_loc_5 < _loc_4)
            {
                
                if (columns[_loc_5].visible)
                {
                    _loc_3 = _loc_3 + columns[_loc_5].width;
                }
                _loc_5++;
            }
            return _loc_3;
        }// end function

        public function get imeMode() : String
        {
            return _imeMode;
        }// end function

        private function mouseFocusChangeHandler(event:MouseEvent) : void
        {
            if (itemEditorInstance && !event.isDefaultPrevented() && itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                event.preventDefault();
            }
            return;
        }// end function

        public function destroyItemEditor() : void
        {
            var _loc_1:DataGridEvent = null;
            if (itemEditorInstance)
            {
                DisplayObject(itemEditorInstance).removeEventListener(KeyboardEvent.KEY_DOWN, editorKeyDownHandler);
                systemManager.getSandboxRoot().removeEventListener(MouseEvent.MOUSE_DOWN, editorMouseDownHandler, true);
                systemManager.getSandboxRoot().removeEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, editorMouseDownHandler);
                systemManager.removeEventListener(Event.RESIZE, editorStageResizeHandler, true);
                _loc_1 = new DataGridEvent(DataGridEvent.ITEM_FOCUS_OUT);
                _loc_1.columnIndex = _editedItemPosition.columnIndex;
                _loc_1.rowIndex = _editedItemPosition.rowIndex;
                _loc_1.itemRenderer = itemEditorInstance;
                dispatchEvent(_loc_1);
                if (!_columns[_editedItemPosition.columnIndex].rendererIsEditor)
                {
                    if (itemEditorInstance && itemEditorInstance is UIComponent)
                    {
                        UIComponent(itemEditorInstance).drawFocus(false);
                    }
                    actualContentHolder.removeChild(DisplayObject(itemEditorInstance));
                    editedItemRenderer.visible = true;
                }
                itemEditorInstance = null;
                _editedItemPosition = null;
            }
            return;
        }// end function

        override protected function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:DataGridEvent = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Sprite = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:Point = null;
            _loc_3 = mouseEventToItemRenderer(event);
            super.mouseUpHandler(event);
            if (_loc_3 && _loc_3 != itemEditorInstance && (lastItemDown == _loc_3 || itemRendererContains(lastItemDown, lastItemFocused)))
            {
                if (lastItemDown != _loc_3)
                {
                    _loc_3 = lastItemDown;
                }
                lastItemFocused = null;
                _loc_7 = itemRendererToIndices(_loc_3);
                if (_loc_7 && _loc_7.y >= 0 && editable && !dontEdit)
                {
                    if (displayableColumns[_loc_7.x].editable)
                    {
                        beginningEdit(displayableColumns[_loc_7.x].colNum, _loc_7.y, _loc_3);
                    }
                    else
                    {
                        lastEditedItemPosition = {columnIndex:displayableColumns[_loc_7.x].colNum, rowIndex:_loc_7.y};
                    }
                }
            }
            else if (lastItemDown && lastItemDown != itemEditorInstance)
            {
                _loc_7 = itemRendererToIndices(lastItemDown);
                if (_loc_7 && _loc_7.y >= 0 && editable && !dontEdit)
                {
                    if (displayableColumns[_loc_7.x].editable)
                    {
                        beginningEdit(displayableColumns[_loc_7.x].colNum, _loc_7.y, lastItemDown);
                    }
                    else
                    {
                        lastEditedItemPosition = {columnIndex:displayableColumns[_loc_7.x].colNum, rowIndex:_loc_7.y};
                    }
                }
            }
            lastItemDown = null;
            return;
        }// end function

        private function itemEditorItemEditEndHandler(event:DataGridEvent) : void
        {
            var _loc_2:Boolean = false;
            var _loc_3:Object = null;
            var _loc_4:String = null;
            var _loc_5:Object = null;
            var _loc_6:String = null;
            var _loc_7:XML = null;
            var _loc_8:DataGridListData = null;
            var _loc_9:IFocusManager = null;
            if (!event.isDefaultPrevented())
            {
                _loc_2 = false;
                if (event.reason == DataGridEventReason.NEW_COLUMN)
                {
                    if (!collectionUpdatesDisabled)
                    {
                        collection.disableAutoUpdate();
                        collectionUpdatesDisabled = true;
                    }
                }
                else if (collectionUpdatesDisabled)
                {
                    collection.enableAutoUpdate();
                    collectionUpdatesDisabled = false;
                }
                if (itemEditorInstance && event.reason != DataGridEventReason.CANCELLED)
                {
                    _loc_3 = itemEditorInstance[_columns[event.columnIndex].editorDataField];
                    _loc_4 = _columns[event.columnIndex].dataField;
                    _loc_5 = event.itemRenderer.data;
                    _loc_6 = "";
                    for each (_loc_7 in describeType(_loc_5).variable)
                    {
                        
                        if (_loc_4 == _loc_7.@name.toString())
                        {
                            _loc_6 = _loc_7.@type.toString();
                            break;
                        }
                    }
                    if (_loc_6 == "String")
                    {
                        if (!(_loc_3 is String))
                        {
                            _loc_3 = _loc_3.toString();
                        }
                    }
                    else if (_loc_6 == "uint")
                    {
                        if (!(_loc_3 is uint))
                        {
                            _loc_3 = uint(_loc_3);
                        }
                    }
                    else if (_loc_6 == "int")
                    {
                        if (!(_loc_3 is int))
                        {
                            _loc_3 = int(_loc_3);
                        }
                    }
                    else if (_loc_6 == "Number")
                    {
                        if (!(_loc_3 is int))
                        {
                            _loc_3 = Number(_loc_3);
                        }
                    }
                    if (_loc_4 != null && getCurrentDataValue(_loc_5, _loc_4) !== _loc_3)
                    {
                        _loc_2 = setNewValue(_loc_5, _loc_4, _loc_3, event.columnIndex);
                    }
                    if (_loc_2 && !(_loc_5 is IPropertyChangeNotifier || _loc_5 is XML))
                    {
                        collection.itemUpdated(_loc_5, _loc_4);
                    }
                    if (event.itemRenderer is IDropInListItemRenderer)
                    {
                        _loc_8 = DataGridListData(IDropInListItemRenderer(event.itemRenderer).listData);
                        _loc_8.label = _columns[event.columnIndex].itemToLabel(_loc_5);
                        IDropInListItemRenderer(event.itemRenderer).listData = _loc_8;
                    }
                    event.itemRenderer.data = _loc_5;
                }
            }
            else if (event.reason != DataGridEventReason.OTHER)
            {
                if (itemEditorInstance && _editedItemPosition)
                {
                    if (selectedIndex != _editedItemPosition.rowIndex)
                    {
                        selectedIndex = _editedItemPosition.rowIndex;
                    }
                    _loc_9 = focusManager;
                    if (itemEditorInstance is IFocusManagerComponent)
                    {
                        _loc_9.setFocus(IFocusManagerComponent(itemEditorInstance));
                    }
                }
            }
            if (event.reason == DataGridEventReason.OTHER || !event.isDefaultPrevented())
            {
                destroyItemEditor();
            }
            return;
        }// end function

        public function set imeMode(param1:String) : void
        {
            _imeMode = param1;
            return;
        }// end function

        function measureHeightOfItemsUptoMaxHeight(param1:int = -1, param2:int = 0, param3:Number = -1) : Number
        {
            var item:IListItemRenderer;
            var c:DataGridColumn;
            var n:int;
            var j:int;
            var data:Object;
            var index:* = param1;
            var count:* = param2;
            var maxHeight:* = param3;
            if (!columns.length)
            {
                return rowHeight * count;
            }
            var h:Number;
            var ch:Number;
            var paddingTop:* = getStyle("paddingTop");
            var paddingBottom:* = getStyle("paddingBottom");
            var lockedCount:* = lockedRowCount;
            if (headerVisible && count > 0 && index == -1)
            {
                h = calculateHeaderHeight();
                if (maxHeight != -1 && h > maxHeight)
                {
                    setRowCount(0);
                    return 0;
                }
                count = (count - 1);
                index;
            }
            var bookmark:* = iterator ? (iterator.bookmark) : (null);
            var bMore:* = iterator != null;
            if (index != -1 && iterator)
            {
                try
                {
                    iterator.seek(CursorBookmark.FIRST, index);
                }
                catch (e:ItemPendingError)
                {
                    bMore;
                }
            }
            if (lockedCount > 0)
            {
                try
                {
                    collectionIterator.seek(CursorBookmark.FIRST, 0);
                }
                catch (e:ItemPendingError)
                {
                    bMore;
                }
            }
            var i:int;
            while (i < count)
            {
                
                if (bMore)
                {
                    data = lockedCount > 0 ? (collectionIterator.current) : (iterator.current);
                    ch;
                    n = columns.length;
                    j;
                    while (j < n)
                    {
                        
                        c = columns[j];
                        if (!c.visible)
                        {
                        }
                        else
                        {
                            item = c.getMeasuringRenderer(false, data);
                            if (DisplayObject(item).parent == null)
                            {
                                listContent.addChild(DisplayObject(item));
                            }
                            setupRendererFromData(c, item, data);
                            ch = Math.max(ch, variableRowHeight ? (item.getExplicitOrMeasuredHeight() + paddingBottom + paddingTop) : (rowHeight));
                        }
                        j = (j + 1);
                    }
                }
                if (maxHeight != -1 && (h + ch > maxHeight || !bMore))
                {
                    try
                    {
                        if (iterator)
                        {
                            iterator.seek(bookmark, 0);
                        }
                    }
                    catch (e:ItemPendingError)
                    {
                    }
                    count = headerVisible ? ((i + 1)) : (i);
                    setRowCount(count);
                    return h;
                }
                h = h + ch;
                if (iterator)
                {
                    try
                    {
                        bMore = iterator.moveNext();
                        if (lockedCount > 0)
                        {
                            collectionIterator.moveNext();
                            lockedCount = (lockedCount - 1);
                        }
                    }
                    catch (e:ItemPendingError)
                    {
                        bMore;
                    }
                }
                i = (i + 1);
            }
            if (iterator)
            {
                try
                {
                    iterator.seek(bookmark, 0);
                }
                catch (e:ItemPendingError)
                {
                }
            }
            return h;
        }// end function

        function get sortArrow() : IFlexDisplayObject
        {
            return DataGridHeader(header).sortArrow;
        }// end function

        override protected function focusOutHandler(event:FocusEvent) : void
        {
            var _loc_2:DisplayObject = null;
            if (event.target == this)
            {
                super.focusOutHandler(event);
            }
            if (event.relatedObject == this && itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                return;
            }
            if (event.relatedObject == null && itemRendererContains(editedItemRenderer, DisplayObject(event.target)))
            {
                return;
            }
            if (event.relatedObject == null && itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                return;
            }
            if (itemEditorInstance && (!event.relatedObject || !itemRendererContains(itemEditorInstance, event.relatedObject)))
            {
                _loc_2 = DisplayObject(event.relatedObject);
                while (_loc_2 && _loc_2 != this)
                {
                    
                    if (_loc_2 is IListItemRenderer && _loc_2.parent.parent == this && _loc_2.parent is ListBaseContentHolder)
                    {
                        if (_loc_2.visible)
                        {
                            return;
                        }
                    }
                    if (_loc_2 is IUIComponent)
                    {
                        _loc_2 = IUIComponent(_loc_2).owner;
                        continue;
                    }
                    _loc_2 = _loc_2.parent;
                }
                endEdit(DataGridEventReason.OTHER);
                removeEventListener(FocusEvent.KEY_FOCUS_CHANGE, keyFocusChangeHandler);
                removeEventListener(MouseEvent.MOUSE_DOWN, mouseFocusChangeHandler);
            }
            return;
        }// end function

        private function itemEditorItemEditBeginningHandler(event:DataGridEvent) : void
        {
            if (!event.isDefaultPrevented())
            {
                setEditedItemPosition({columnIndex:event.columnIndex, rowIndex:event.rowIndex});
            }
            else if (!itemEditorInstance)
            {
                _editedItemPosition = null;
                editable = false;
                setFocus();
                editable = true;
            }
            return;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            if (!header)
            {
                header = new headerClass();
                header.styleName = this;
                addChild(header);
            }
            return;
        }// end function

        function _clearSeparators() : void
        {
            clearSeparators();
            return;
        }// end function

        public function set draggableColumns(param1:Boolean) : void
        {
            _draggableColumns = param1;
            return;
        }// end function

        private function updateSortIndexAndDirection() : void
        {
            if (!sortableColumns)
            {
                lastSortIndex = sortIndex;
                sortIndex = -1;
                if (lastSortIndex != sortIndex)
                {
                    invalidateDisplayList();
                }
                return;
            }
            if (!dataProvider)
            {
                return;
            }
            var _loc_1:* = ICollectionView(dataProvider);
            var _loc_2:* = _loc_1.sort;
            if (!_loc_2)
            {
                var _loc_7:int = -1;
                lastSortIndex = -1;
                sortIndex = _loc_7;
                return;
            }
            var _loc_3:* = _loc_2.fields;
            if (!_loc_3)
            {
                return;
            }
            if (_loc_3.length != 1)
            {
                lastSortIndex = sortIndex;
                sortIndex = -1;
                if (lastSortIndex != sortIndex)
                {
                    invalidateDisplayList();
                }
                return;
            }
            var _loc_4:* = _loc_3[0];
            var _loc_5:* = _columns.length;
            sortIndex = -1;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                if (_columns[_loc_6].dataField == _loc_4.name)
                {
                    sortIndex = _columns[_loc_6].sortable ? (_loc_6) : (-1);
                    sortDirection = _loc_4.descending ? ("DESC") : ("ASC");
                    return;
                }
                _loc_6++;
            }
            return;
        }// end function

        protected function isComplexColumn(param1:String) : Boolean
        {
            return param1.indexOf(".") != -1;
        }// end function

        public function get editedItemPosition() : Object
        {
            if (_editedItemPosition)
            {
                return {rowIndex:_editedItemPosition.rowIndex, columnIndex:_editedItemPosition.columnIndex};
            }
            return _editedItemPosition;
        }// end function

        private function drawVerticalSeparator(param1:Sprite, param2:int, param3:uint, param4:Number, param5:Boolean = false) : void
        {
            var _loc_10:IFlexDisplayObject = null;
            var _loc_11:IFlexDisplayObject = null;
            var _loc_12:IFlexDisplayObject = null;
            var _loc_13:IFlexDisplayObject = null;
            var _loc_14:Class = null;
            var _loc_15:ISimpleStyleClient = null;
            var _loc_16:Number = NaN;
            var _loc_6:* = "vSeparator" + param2;
            var _loc_7:* = "vLockedSeparator" + param2;
            var _loc_8:* = param5 ? (_loc_7) : (_loc_6);
            var _loc_9:* = param5 ? ("verticalLockedSeparatorSkin") : ("verticalSeparatorSkin");
            _loc_10 = IFlexDisplayObject(param1.getChildByName(_loc_6));
            _loc_11 = IFlexDisplayObject(param1.getChildByName(_loc_7));
            _loc_13 = param5 ? (_loc_11) : (_loc_10);
            _loc_12 = param5 ? (_loc_10) : (_loc_11);
            if (_loc_12)
            {
                param1.removeChild(DisplayObject(_loc_12));
            }
            if (!_loc_13)
            {
                _loc_14 = Class(getStyle(_loc_9));
                if (_loc_14)
                {
                    _loc_13 = IFlexDisplayObject(new _loc_14);
                    _loc_13.name = _loc_8;
                    _loc_15 = _loc_13 as ISimpleStyleClient;
                    if (_loc_15)
                    {
                        _loc_15.styleName = this;
                    }
                    param1.addChild(DisplayObject(_loc_13));
                }
            }
            if (_loc_13)
            {
                _loc_16 = !isNaN(_loc_13.measuredWidth) ? (_loc_13.measuredWidth) : (1);
                _loc_13.setActualSize(_loc_16, param1.parent.parent.height);
                _loc_13.move(param4 - Math.round(_loc_16 / 2), 0);
            }
            else
            {
                drawVerticalLine(param1, param2, param3, param4);
            }
            return;
        }// end function

        override public function set headerHeight(param1:Number) : void
        {
            super.headerHeight = param1;
            _originalHeaderHeight = isNaN(param1) ? (22) : (param1);
            _originalExplicitHeaderHeight = !isNaN(param1);
            return;
        }// end function

        private function headerReleaseHandler(event:DataGridEvent) : void
        {
            if (!event.isDefaultPrevented())
            {
                manualSort = true;
                sortByColumn(event.columnIndex);
                manualSort = false;
            }
            return;
        }// end function

        override function resizeColumn(param1:int, param2:Number) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:Number = NaN;
            var _loc_6:DataGridColumn = null;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:Number = NaN;
            if ((!visibleColumns || visibleColumns.length == 0) && (!visibleLockedColumns || visibleLockedColumns.length == 0))
            {
                _columns[param1].setWidth(param2);
                _columns[param1].preferredWidth = param2;
                return;
            }
            if (param2 < _columns[param1].minWidth)
            {
                param2 = _columns[param1].minWidth;
            }
            if (_horizontalScrollPolicy == ScrollPolicy.ON || _horizontalScrollPolicy == ScrollPolicy.AUTO)
            {
                _columns[param1].setWidth(param2);
                _columns[param1].explicitWidth = param2;
                _columns[param1].preferredWidth = param2;
                columnsInvalid = true;
            }
            else
            {
                _loc_3 = _columns.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    if (param1 == _columns[_loc_4].colNum)
                    {
                        break;
                    }
                    _loc_4++;
                }
                if (_loc_4 >= (_columns.length - 1))
                {
                    return;
                }
                param1 = _loc_4;
                _loc_5 = 0;
                _loc_4 = param1 + 1;
                while (_loc_4 < _loc_3)
                {
                    
                    if (_columns[_loc_4].visible)
                    {
                        if (_columns[_loc_4].resizable)
                        {
                            _loc_5 = _loc_5 + _columns[_loc_4].width;
                        }
                    }
                    _loc_4++;
                }
                _loc_8 = _columns[param1].width - param2 + _loc_5;
                if (_loc_5)
                {
                    _columns[param1].setWidth(param2);
                    _columns[param1].explicitWidth = param2;
                }
                _loc_9 = 0;
                _loc_4 = param1 + 1;
                while (_loc_4 < _loc_3)
                {
                    
                    if (_columns[_loc_4].visible)
                    {
                        if (_columns[_loc_4].resizable)
                        {
                            _loc_7 = Math.floor(_columns[_loc_4].width * _loc_8 / _loc_5);
                            if (_loc_7 < _columns[_loc_4].minWidth)
                            {
                                _loc_7 = _columns[_loc_4].minWidth;
                            }
                            _columns[_loc_4].setWidth(_loc_7);
                            _loc_9 = _loc_9 + _columns[_loc_4].width;
                            _loc_6 = _columns[_loc_4];
                        }
                    }
                    _loc_4++;
                }
                if (_loc_9 > _loc_8)
                {
                    _loc_7 = _columns[param1].width - _loc_9 + _loc_8;
                    if (_loc_7 < _columns[param1].minWidth)
                    {
                        _loc_7 = _columns[param1].minWidth;
                    }
                    _columns[param1].setWidth(_loc_7);
                }
                else if (_loc_6)
                {
                    _loc_6.setWidth(_loc_6.width - _loc_9 + _loc_8);
                }
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        private function generateCols() : void
        {
            var col:DataGridColumn;
            var newCols:Array;
            var cols:Array;
            var info:Object;
            var itmObj:Object;
            var p:String;
            var n:int;
            var colName:Object;
            var i:int;
            if (collection.length > 0)
            {
                newCols;
                if (dataProvider)
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
                        e.addResponder(new ItemResponder(generateColumnsPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                        iteratorValid = false;
                        return;
                    }
                    info = ObjectUtil.getClassInfo(iterator.current, ["uid", "mx_internal_uid"]);
                    if (info)
                    {
                        cols = info.properties;
                    }
                }
                if (!cols)
                {
                    itmObj = iterator.current;
                    var _loc_2:int = 0;
                    var _loc_3:* = itmObj;
                    while (_loc_3 in _loc_2)
                    {
                        
                        p = _loc_3[_loc_2];
                        if (p != "uid")
                        {
                            col = new DataGridColumn();
                            col.dataField = p;
                            newCols.push(col);
                        }
                    }
                }
                else
                {
                    n = cols.length;
                    i;
                    while (i < n)
                    {
                        
                        colName = cols[i];
                        if (colName is QName)
                        {
                            colName = QName(colName).localName;
                        }
                        col = new DataGridColumn();
                        col.dataField = String(colName);
                        newCols.push(col);
                        i = (i + 1);
                    }
                }
                columns = newCols;
                generatedColumns = true;
            }
            return;
        }// end function

        override protected function drawRowBackgrounds() : void
        {
            drawRowGraphics(listContent);
            return;
        }// end function

        function get vScrollBar() : ScrollBar
        {
            return verticalScrollBar;
        }// end function

        override public function showDropFeedback(event:DragEvent) : void
        {
            var _loc_2:Class = null;
            super.showDropFeedback(event);
            if (lockedColumnCount > 0)
            {
                if (!lockedColumnDropIndicator)
                {
                    _loc_2 = getStyle("dropIndicatorSkin");
                    if (!_loc_2)
                    {
                        _loc_2 = ListDropIndicator;
                    }
                    lockedColumnDropIndicator = IFlexDisplayObject(new _loc_2);
                    lockedColumnDropIndicator.x = 2;
                    lockedColumnDropIndicator.setActualSize(lockedColumnContent.width - 2, 4);
                    lockedColumnDropIndicator.visible = true;
                }
                if (dropIndicator.parent == listContent)
                {
                    lockedColumnContent.addChild(DisplayObject(lockedColumnDropIndicator));
                }
                else
                {
                    lockedColumnAndRowContent.addChild(DisplayObject(lockedColumnDropIndicator));
                }
                lockedColumnDropIndicator.y = dropIndicator.y;
            }
            return;
        }// end function

        override protected function scrollPositionToIndex(param1:int, param2:int) : int
        {
            return iterator ? (param2 + lockedRowCount) : (-1);
        }// end function

        protected function setNewValue(param1:Object, param2:String, param3:Object, param4:int) : Boolean
        {
            var _loc_5:Array = null;
            var _loc_6:String = null;
            var _loc_7:Object = null;
            if (!isComplexColumn(param2))
            {
                param1[param2] = param3;
            }
            else
            {
                _loc_5 = param2.split(".");
                _loc_6 = _loc_5.pop();
                _loc_7 = deriveComplexFieldReference(param1, _loc_5);
                _loc_7[_loc_6] = param3;
            }
            return true;
        }// end function

        private function drawHorizontalSeparator(param1:Sprite, param2:int, param3:uint, param4:Number, param5:Boolean = false) : void
        {
            var _loc_10:IFlexDisplayObject = null;
            var _loc_11:IFlexDisplayObject = null;
            var _loc_12:IFlexDisplayObject = null;
            var _loc_13:IFlexDisplayObject = null;
            var _loc_14:Class = null;
            var _loc_15:ISimpleStyleClient = null;
            var _loc_16:Number = NaN;
            var _loc_6:* = "hSeparator" + param2;
            var _loc_7:* = "hLockedSeparator" + param2;
            var _loc_8:* = param5 ? (_loc_7) : (_loc_6);
            var _loc_9:* = param5 ? ("horizontalLockedSeparatorSkin") : ("horizontalSeparatorSkin");
            _loc_10 = IFlexDisplayObject(param1.getChildByName(_loc_6));
            _loc_11 = IFlexDisplayObject(param1.getChildByName(_loc_7));
            _loc_13 = param5 ? (_loc_11) : (_loc_10);
            _loc_12 = param5 ? (_loc_10) : (_loc_11);
            if (_loc_12)
            {
                param1.removeChild(DisplayObject(_loc_12));
            }
            if (!_loc_13)
            {
                _loc_14 = Class(getStyle(_loc_9));
                if (_loc_14)
                {
                    _loc_13 = IFlexDisplayObject(new _loc_14);
                    _loc_13.name = _loc_8;
                    _loc_15 = _loc_13 as ISimpleStyleClient;
                    if (_loc_15)
                    {
                        _loc_15.styleName = this;
                    }
                    param1.addChild(DisplayObject(_loc_13));
                }
            }
            if (_loc_13)
            {
                _loc_16 = !isNaN(_loc_13.measuredHeight) ? (_loc_13.measuredHeight) : (1);
                _loc_13.setActualSize(displayWidth - lockedColumnWidth, _loc_16);
                _loc_13.move(0, param4);
            }
            else
            {
                drawHorizontalLine(param1, param2, param3, param4);
            }
            return;
        }// end function

        private function itemEditorItemEditBeginHandler(event:DataGridEvent) : void
        {
            var _loc_2:IFocusManager = null;
            if (root)
            {
                systemManager.addEventListener(Event.DEACTIVATE, deactivateHandler, false, 0, true);
            }
            if (!event.isDefaultPrevented() && actualContentHolder.listItems[actualRowIndex][actualColIndex].data != null)
            {
                createItemEditor(event.columnIndex, event.rowIndex);
                if (editedItemRenderer is IDropInListItemRenderer && itemEditorInstance is IDropInListItemRenderer)
                {
                    IDropInListItemRenderer(itemEditorInstance).listData = IDropInListItemRenderer(editedItemRenderer).listData;
                }
                if (!columns[event.columnIndex].rendererIsEditor)
                {
                    itemEditorInstance.data = editedItemRenderer.data;
                }
                if (itemEditorInstance is IInvalidating)
                {
                    IInvalidating(itemEditorInstance).validateNow();
                }
                if (itemEditorInstance is IIMESupport)
                {
                    IIMESupport(itemEditorInstance).imeMode = columns[event.columnIndex].imeMode == null ? (_imeMode) : (columns[event.columnIndex].imeMode);
                }
                _loc_2 = focusManager;
                if (itemEditorInstance is IFocusManagerComponent)
                {
                    _loc_2.setFocus(IFocusManagerComponent(itemEditorInstance));
                }
                _loc_2.defaultButtonEnabled = false;
                event = new DataGridEvent(DataGridEvent.ITEM_FOCUS_IN);
                event.columnIndex = _editedItemPosition.columnIndex;
                event.rowIndex = _editedItemPosition.rowIndex;
                event.itemRenderer = itemEditorInstance;
                dispatchEvent(event);
            }
            return;
        }// end function

        private function setEditedItemPosition(param1:Object) : void
        {
            bEditedItemPositionChanged = true;
            _proposedEditedItemPosition = param1;
            invalidateDisplayList();
            return;
        }// end function

        private function keyFocusChangeHandler(event:FocusEvent) : void
        {
            if (event.keyCode == Keyboard.TAB && !event.isDefaultPrevented() && findNextItemRenderer(event.shiftKey))
            {
                event.preventDefault();
            }
            return;
        }// end function

        override public function set horizontalScrollPolicy(param1:String) : void
        {
            super.horizontalScrollPolicy = param1;
            columnsInvalid = true;
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        public function set editedItemPosition(param1:Object) : void
        {
            if (!param1)
            {
                setEditedItemPosition(null);
                return;
            }
            var _loc_2:Object = {rowIndex:param1.rowIndex, columnIndex:param1.columnIndex};
            setEditedItemPosition(_loc_2);
            return;
        }// end function

        override public function measureHeightOfItems(param1:int = -1, param2:int = 0) : Number
        {
            return measureHeightOfItemsUptoMaxHeight(param1, param2);
        }// end function

        override protected function makeRowsAndColumns(param1:Number, param2:Number, param3:Number, param4:Number, param5:int, param6:int, param7:Boolean = false, param8:uint = 0) : Point
        {
            var _loc_10:DataGridColumn = null;
            var _loc_11:IListItemRenderer = null;
            var _loc_12:ListRowInfo = null;
            var _loc_13:Sprite = null;
            var _loc_14:Number = NaN;
            var _loc_15:Number = NaN;
            var _loc_16:Number = NaN;
            var _loc_17:Number = NaN;
            allowItemSizeChangeNotification = false;
            var _loc_9:* = super.makeRowsAndColumns(param1, param2, param3, param4, param5, param6, param7, param8);
            if (itemEditorInstance)
            {
                actualContentHolder.setChildIndex(DisplayObject(itemEditorInstance), (actualContentHolder.numChildren - 1));
                if (lockedColumnCount && editedItemPosition.columnIndex && visibleLockedColumns[(lockedColumnCount - 1)].colNum)
                {
                    _loc_10 = visibleLockedColumns[actualColIndex];
                }
                else
                {
                    _loc_10 = visibleColumns[actualColIndex];
                }
                _loc_11 = actualContentHolder.listItems[actualRowIndex][actualColIndex];
                _loc_12 = actualContentHolder.rowInfo[actualRowIndex];
                if (_loc_11 && !_loc_10.rendererIsEditor)
                {
                    _loc_14 = _loc_10.editorXOffset;
                    _loc_15 = _loc_10.editorYOffset;
                    _loc_16 = _loc_10.editorWidthOffset;
                    _loc_17 = _loc_10.editorHeightOffset;
                    itemEditorInstance.move(_loc_11.x + _loc_14, _loc_12.y + _loc_15);
                    itemEditorInstance.setActualSize(Math.min(_loc_10.width + _loc_16, actualContentHolder.width - itemEditorInstance.x), Math.min(_loc_12.height + _loc_17, actualContentHolder.height - itemEditorInstance.y));
                    _loc_11.visible = false;
                }
                _loc_13 = Sprite(actualContentHolder.getChildByName("lines"));
                if (_loc_13)
                {
                    actualContentHolder.setChildIndex(_loc_13, (actualContentHolder.numChildren - 1));
                }
            }
            allowItemSizeChangeNotification = variableRowHeight;
            return _loc_9;
        }// end function

        private function scrollToEditedItem(param1:int, param2:int) : void
        {
            var _loc_8:int = 0;
            actualContentHolder = listContent;
            var _loc_3:* = actualContentHolder.listItems;
            var _loc_4:* = verticalScrollPosition + _loc_3.length - 1 + lockedRowCount;
            var _loc_5:* = rowInfo[(_loc_3.length - 1)].y + rowInfo[(_loc_3.length - 1)].height > listContent.height ? (1) : (0);
            if (param1 > lockedRowCount)
            {
                if (param1 < verticalScrollPosition + lockedRowCount)
                {
                    verticalScrollPosition = param1 - lockedRowCount;
                }
                else
                {
                    while (param1 > _loc_4 || param1 == _loc_4 && param1 > verticalScrollPosition + lockedRowCount && _loc_5)
                    {
                        
                        if (verticalScrollPosition == maxVerticalScrollPosition)
                        {
                            break;
                        }
                        verticalScrollPosition = Math.min(verticalScrollPosition + (param1 > _loc_4 ? (param1 - _loc_4) : (_loc_5)), maxVerticalScrollPosition);
                        _loc_4 = verticalScrollPosition + _loc_3.length - 1 + lockedRowCount;
                        _loc_5 = rowInfo[(_loc_3.length - 1)].y + rowInfo[(_loc_3.length - 1)].height > listContent.height ? (1) : (0);
                    }
                }
                actualRowIndex = param1 - verticalScrollPosition - lockedRowCount;
            }
            else if (param1 == lockedRowCount)
            {
                verticalScrollPosition = 0;
                actualRowIndex = param1 - lockedRowCount;
            }
            else
            {
                if (lockedRowCount)
                {
                    actualContentHolder = lockedRowContent;
                }
                actualRowIndex = param1;
            }
            _loc_3 = actualContentHolder.listItems;
            var _loc_6:* = _loc_3 && _loc_3[0] ? (_loc_3[0].length) : (visibleColumns.length);
            var _loc_7:* = horizontalScrollPosition + _loc_6 - 1 + lockedColumnCount;
            if (param2 > lockedColumnCount)
            {
                _loc_8 = _loc_3[0][(_loc_6 - 1)].x + _loc_3[0][(_loc_6 - 1)].width > listContent.width ? (1) : (0);
                if (param2 < horizontalScrollPosition + lockedColumnCount)
                {
                    horizontalScrollPosition = param2 - lockedColumnCount;
                }
                else
                {
                    while (param2 > _loc_7 || param2 == _loc_7 && param2 > horizontalScrollPosition + lockedColumnCount && _loc_8)
                    {
                        
                        if (horizontalScrollPosition == maxHorizontalScrollPosition)
                        {
                            break;
                        }
                        horizontalScrollPosition = Math.min(horizontalScrollPosition + (param2 > _loc_7 ? (param2 - _loc_7) : (_loc_8)), maxHorizontalScrollPosition);
                        _loc_6 = _loc_3 && _loc_3[0] ? (_loc_3[0].length) : (visibleColumns.length);
                        _loc_7 = horizontalScrollPosition + _loc_6 - 1 + lockedColumnCount;
                        _loc_8 = _loc_3[0][(_loc_6 - 1)].x + _loc_3[0][(_loc_6 - 1)].width > listContent.width ? (1) : (0);
                    }
                }
                actualColIndex = param2 - horizontalScrollPosition - lockedColumnCount;
            }
            else if (param2 == lockedColumnCount)
            {
                horizontalScrollPosition = 0;
                actualColIndex = param2 - lockedColumnCount;
            }
            else
            {
                if (lockedColumnCount)
                {
                    if (actualContentHolder == lockedRowContent)
                    {
                        actualContentHolder = lockedColumnAndRowContent;
                    }
                    else
                    {
                        actualContentHolder = lockedColumnContent;
                    }
                }
                actualColIndex = param2;
            }
            return;
        }// end function

        private function sortByColumn(param1:int) : void
        {
            var _loc_4:Sort = null;
            var _loc_5:SortField = null;
            var _loc_6:String = null;
            var _loc_7:Array = null;
            var _loc_8:int = 0;
            var _loc_2:* = columns[param1];
            var _loc_3:* = _loc_2.sortDescending;
            if (_loc_2.sortable)
            {
                _loc_4 = collection.sort;
                if (_loc_4)
                {
                    _loc_4.compareFunction = null;
                    _loc_7 = _loc_4.fields;
                    if (_loc_7)
                    {
                        _loc_8 = 0;
                        while (_loc_8 < _loc_7.length)
                        {
                            
                            if (_loc_7[_loc_8].name == _loc_2.dataField)
                            {
                                _loc_5 = _loc_7[_loc_8];
                                _loc_3 = !_loc_5.descending;
                                break;
                            }
                            _loc_8++;
                        }
                    }
                }
                else
                {
                    _loc_4 = new Sort();
                }
                if (!_loc_5)
                {
                    _loc_5 = new SortField(_loc_2.dataField);
                }
                _loc_2.sortDescending = _loc_3;
                _loc_6 = _loc_3 ? ("DESC") : ("ASC");
                sortDirection = _loc_6;
                lastSortIndex = sortIndex;
                sortIndex = param1;
                sortColumn = _loc_2;
                _loc_5.name = _loc_2.dataField;
                if (_loc_2.sortCompareFunction != null)
                {
                    _loc_5.compareFunction = _loc_2.sortCompareFunction;
                }
                else
                {
                    _loc_5.compareFunction = null;
                }
                _loc_5.descending = _loc_3;
                _loc_4.fields = [_loc_5];
            }
            collection.sort = _loc_4;
            collection.refresh();
            return;
        }// end function

        override function columnRendererChanged(param1:DataGridColumn) : void
        {
            var _loc_2:DisplayObject = null;
            var _loc_4:* = undefined;
            var _loc_5:Array = null;
            var _loc_6:IFactory = null;
            var _loc_7:Dictionary = null;
            var _loc_8:* = undefined;
            var _loc_3:* = param1.measuringObjects;
            if (_loc_3)
            {
                for (_loc_4 in _loc_3)
                {
                    
                    _loc_6 = IFactory(_loc_4);
                    _loc_2 = param1.measuringObjects[_loc_6];
                    if (_loc_2)
                    {
                        _loc_2.parent.removeChild(_loc_2);
                        param1.measuringObjects[_loc_6] = null;
                    }
                    if (param1.freeItemRenderersByFactory && param1.freeItemRenderersByFactory[_loc_6])
                    {
                        _loc_7 = param1.freeItemRenderersByFactory[_loc_6];
                        for (_loc_8 in _loc_7)
                        {
                            
                            _loc_2 = DisplayObject(_loc_8);
                            _loc_2.parent.removeChild(_loc_2);
                        }
                        param1.freeItemRenderersByFactory[_loc_6] = new Dictionary(true);
                    }
                }
                _loc_5 = freeItemRenderersTable[param1] as Array;
                if (_loc_5)
                {
                    while (_loc_5.length)
                    {
                        
                        _loc_2 = _loc_5.pop();
                    }
                }
            }
            _loc_2 = param1.cachedHeaderRenderer as DisplayObject;
            if (_loc_2 && _loc_2.parent)
            {
                _loc_2.parent.removeChild(_loc_2);
            }
            param1.cachedHeaderRenderer = null;
            rendererChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        override public function invalidateDisplayList() : void
        {
            super.invalidateDisplayList();
            if (header)
            {
                header.headerItemsChanged = true;
                header.invalidateSize();
                header.invalidateDisplayList();
            }
            if (lockedColumnHeader)
            {
                lockedColumnHeader.headerItemsChanged = true;
                lockedColumnHeader.invalidateSize();
                lockedColumnHeader.invalidateDisplayList();
            }
            return;
        }// end function

        private function findNextEnterItemRenderer(event:KeyboardEvent) : void
        {
            if (_proposedEditedItemPosition !== undefined)
            {
                return;
            }
            _editedItemPosition = lastEditedItemPosition;
            if (!_editedItemPosition)
            {
                return;
            }
            var _loc_2:* = _editedItemPosition.rowIndex;
            var _loc_3:* = _editedItemPosition.columnIndex;
            var _loc_4:* = _editedItemPosition.rowIndex + (event.shiftKey ? (-1) : (1));
            if (_editedItemPosition.rowIndex + (event.shiftKey ? (-1) : (1)) < collection.length && _loc_4 >= 0)
            {
                _loc_2 = _loc_4;
            }
            beginningEdit(_loc_3, _loc_2);
            return;
        }// end function

        override public function set verticalScrollPosition(param1:Number) : void
        {
            skipHeaderUpdate = true;
            var _loc_2:* = super.verticalScrollPosition;
            super.verticalScrollPosition = param1;
            if (_loc_2 != param1)
            {
                if (lockedColumnContent)
                {
                    drawRowGraphics(lockedColumnContent);
                }
            }
            skipHeaderUpdate = false;
            return;
        }// end function

        override public function get columnCount() : int
        {
            if (_columns)
            {
                return _columns.length;
            }
            return 0;
        }// end function

        protected function deriveComplexFieldReference(param1:Object, param2:Array) : Object
        {
            var _loc_4:int = 0;
            var _loc_3:* = param1;
            if (param2)
            {
                _loc_4 = 0;
                while (_loc_4 < param2.length)
                {
                    
                    _loc_3 = _loc_3[param2[_loc_4]];
                    _loc_4++;
                }
            }
            return _loc_3;
        }// end function

        override public function calculateDropIndex(event:DragEvent = null) : int
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
                if (!_loc_2 && lockedRowContent)
                {
                    _loc_4 = listContent.localToGlobal(_loc_4);
                    _loc_4 = lockedRowContent.globalToLocal(_loc_4);
                    _loc_5 = lockedRowContent.listItems.length;
                    _loc_6 = 0;
                    while (_loc_6 < _loc_5)
                    {
                        
                        if (lockedRowContent.rowInfo[_loc_6].y <= _loc_4.y && _loc_4.y < lockedRowContent.rowInfo[_loc_6].y + lockedRowContent.rowInfo[_loc_6].height)
                        {
                            _loc_2 = lockedRowContent.listItems[_loc_6][0];
                            break;
                        }
                        _loc_6++;
                    }
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

        override protected function measure() : void
        {
            var _loc_1:EdgeMetrics = null;
            super.measure();
            if (explicitRowCount != -1)
            {
                measuredHeight = measuredHeight + headerHeight;
                measuredMinHeight = measuredMinHeight + headerHeight;
            }
            _loc_1 = viewMetrics;
            var _loc_2:* = columns.length;
            if (_loc_2 == 0)
            {
                measuredWidth = DEFAULT_MEASURED_WIDTH;
                measuredMinWidth = DEFAULT_MEASURED_MIN_WIDTH;
                return;
            }
            var _loc_3:Number = 0;
            var _loc_4:Number = 0;
            var _loc_5:int = 0;
            while (_loc_5 < _loc_2)
            {
                
                if (columns[_loc_5].visible)
                {
                    _loc_3 = _loc_3 + columns[_loc_5].preferredWidth;
                    if (isNaN(_minColumnWidth))
                    {
                        _loc_4 = _loc_4 + columns[_loc_5].minWidth;
                    }
                }
                _loc_5++;
            }
            if (!isNaN(_minColumnWidth))
            {
                _loc_4 = _loc_2 * _minColumnWidth;
            }
            measuredWidth = _loc_3 + _loc_1.left + _loc_1.right;
            measuredMinWidth = _loc_4 + _loc_1.left + _loc_1.right;
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

        private function lockedRowSeekPendingResultHandler(param1:Object, param2:ListBaseSeekPending) : void
        {
            var data:* = param1;
            var info:* = param2;
            try
            {
                lockedRowContent.iterator.seek(CursorBookmark.FIRST);
            }
            catch (e:ItemPendingError)
            {
                e.addResponder(new ItemResponder(lockedRowSeekPendingResultHandler, seekPendingFailureHandler, null));
            }
            itemsSizeChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        override protected function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Sprite = null;
            var _loc_5:Point = null;
            var _loc_6:Boolean = false;
            _loc_2 = mouseEventToItemRenderer(event);
            lastItemDown = null;
            var _loc_4:* = itemRendererContains(itemEditorInstance, DisplayObject(event.target));
            if (!itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                if (_loc_2)
                {
                    lastItemDown = _loc_2;
                    _loc_5 = itemRendererToIndices(_loc_2);
                    _loc_6 = true;
                    if (itemEditorInstance)
                    {
                        if (displayableColumns[_loc_5.x].editable == false)
                        {
                            _loc_6 = endEdit(DataGridEventReason.OTHER);
                        }
                        else if (editedItemPosition)
                        {
                            _loc_6 = endEdit(editedItemPosition.rowIndex == _loc_5.y ? (DataGridEventReason.NEW_COLUMN) : (DataGridEventReason.NEW_ROW));
                        }
                        else
                        {
                            _loc_6 = false;
                        }
                    }
                    if (!_loc_6)
                    {
                        return;
                    }
                }
                else if (itemEditorInstance)
                {
                    endEdit(DataGridEventReason.OTHER);
                }
                super.mouseDownHandler(event);
                if (_loc_2)
                {
                    if (displayableColumns[_loc_5.x].rendererIsEditor)
                    {
                        resetDragScrolling();
                    }
                }
            }
            else
            {
                resetDragScrolling();
            }
            return;
        }// end function

        public function get minColumnWidth() : Number
        {
            return _minColumnWidth;
        }// end function

        private function findNextItemRenderer(param1:Boolean) : Boolean
        {
            var _loc_7:String = null;
            if (!lastEditedItemPosition)
            {
                return false;
            }
            if (_proposedEditedItemPosition !== undefined)
            {
                return true;
            }
            _editedItemPosition = lastEditedItemPosition;
            var _loc_2:* = _editedItemPosition.rowIndex;
            var _loc_3:* = _editedItemPosition.columnIndex;
            var _loc_4:Boolean = false;
            var _loc_5:* = param1 ? (-1) : (1);
            var _loc_6:* = collection.length - 1;
            while (!_loc_4)
            {
                
                _loc_3 = _loc_3 + _loc_5;
                if (_loc_3 >= _columns.length || _loc_3 < 0)
                {
                    _loc_3 = _loc_3 < 0 ? ((_columns.length - 1)) : (0);
                    _loc_2 = _loc_2 + _loc_5;
                    if (_loc_2 > _loc_6 || _loc_2 < 0)
                    {
                        if (endEdit(DataGridEventReason.NEW_ROW))
                        {
                            setEditedItemPosition(null);
                            losingFocus = true;
                            setFocus();
                            return false;
                        }
                        return true;
                    }
                }
                if (_columns[_loc_3].editable && _columns[_loc_3].visible)
                {
                    _loc_4 = true;
                    _loc_7 = _loc_2 == _editedItemPosition.rowIndex ? (DataGridEventReason.NEW_COLUMN) : (DataGridEventReason.NEW_ROW);
                    if (!itemEditorInstance || endEdit(_loc_7))
                    {
                        beginningEdit(_loc_3, _loc_2);
                    }
                }
            }
            return _loc_4;
        }// end function

        protected function clearSeparators() : void
        {
            DataGridHeader(header)._clearSeparators();
            if (lockedColumnHeader)
            {
                DataGridHeader(lockedColumnHeader)._clearSeparators();
            }
            return;
        }// end function

        override protected function mouseEventToItemRenderer(event:MouseEvent) : IListItemRenderer
        {
            var _loc_2:IListItemRenderer = null;
            _loc_2 = super.mouseEventToItemRenderer(event);
            return _loc_2 == itemEditorInstance ? (null) : (_loc_2);
        }// end function

        private function deactivateHandler(event:Event) : void
        {
            if (itemEditorInstance)
            {
                endEdit(DataGridEventReason.OTHER);
                losingFocus = true;
                setFocus();
            }
            return;
        }// end function

        override protected function focusInHandler(event:FocusEvent) : void
        {
            var _loc_2:DataGridEvent = null;
            var _loc_3:Boolean = false;
            if (losingFocus)
            {
                losingFocus = false;
                return;
            }
            if (editable)
            {
                addEventListener(FocusEvent.KEY_FOCUS_CHANGE, keyFocusChangeHandler);
                addEventListener(MouseEvent.MOUSE_DOWN, mouseFocusChangeHandler);
            }
            if (event.target != this)
            {
                if (itemEditorInstance && itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
                {
                    return;
                }
                lastItemFocused = DisplayObject(event.target);
                return;
            }
            lastItemFocused = null;
            super.focusInHandler(event);
            if (editable && !isPressed)
            {
                _editedItemPosition = lastEditedItemPosition;
                _loc_3 = false;
                if (!_editedItemPosition)
                {
                    _editedItemPosition = {rowIndex:0, columnIndex:0};
                }
                while (_editedItemPosition.columnIndex != _columns.length)
                {
                    
                    if (_columns[_editedItemPosition.columnIndex].editable && _columns[_editedItemPosition.columnIndex].visible)
                    {
                        _loc_3 = true;
                        break;
                    }
                    var _loc_4:* = _editedItemPosition;
                    var _loc_5:* = _editedItemPosition.columnIndex + 1;
                    _loc_4.columnIndex = _loc_5;
                }
                if (_loc_3)
                {
                    beginningEdit(_editedItemPosition.columnIndex, _editedItemPosition.rowIndex);
                }
            }
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            if (itemEditorInstance)
            {
                endEdit(DataGridEventReason.OTHER);
            }
            lastEditedItemPosition = null;
            super.dataProvider = param1;
            return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            if (itemEditorInstance || event.target != event.currentTarget)
            {
                return;
            }
            if (event.keyCode != Keyboard.SPACE)
            {
                super.keyDownHandler(event);
            }
            else if (caretIndex != -1)
            {
                moveSelectionVertically(event.keyCode, event.shiftKey, event.ctrlKey);
            }
            return;
        }// end function

        protected function drawLinesAndColumnBackgrounds() : void
        {
            drawLinesAndColumnGraphics(listContent, visibleColumns, {});
            return;
        }// end function

        public function createItemEditor(param1:int, param2:int) : void
        {
            var _loc_7:int = 0;
            var _loc_8:Number = NaN;
            var _loc_9:Number = NaN;
            var _loc_10:Number = NaN;
            var _loc_11:Number = NaN;
            var _loc_12:IFactory = null;
            if (displayableColumns.length != _columns.length)
            {
                _loc_7 = 0;
                while (_loc_7 < displayableColumns.length)
                {
                    
                    if (displayableColumns[_loc_7].colNum >= param1)
                    {
                        param1 = _loc_7;
                        break;
                    }
                    _loc_7++;
                }
                if (_loc_7 == displayableColumns.length)
                {
                    param1 = 0;
                }
            }
            var _loc_3:* = displayableColumns[param1];
            if (param2 >= lockedRowCount)
            {
                param2 = param2 - (verticalScrollPosition + lockedRowCount);
            }
            if (param1 >= lockedColumnCount)
            {
                param1 = param1 - (horizontalScrollPosition + lockedColumnCount);
            }
            var _loc_4:* = actualContentHolder.listItems[param2][param1];
            var _loc_5:* = actualContentHolder.rowInfo[param2];
            if (!_loc_3.rendererIsEditor)
            {
                _loc_8 = 0;
                _loc_9 = -2;
                _loc_10 = 0;
                _loc_11 = 4;
                if (!itemEditorInstance)
                {
                    _loc_12 = _loc_3.itemEditor;
                    _loc_8 = _loc_3.editorXOffset;
                    _loc_9 = _loc_3.editorYOffset;
                    _loc_10 = _loc_3.editorWidthOffset;
                    _loc_11 = _loc_3.editorHeightOffset;
                    itemEditorInstance = _loc_12.newInstance();
                    itemEditorInstance.owner = this;
                    itemEditorInstance.styleName = _loc_3;
                    actualContentHolder.addChild(DisplayObject(itemEditorInstance));
                }
                actualContentHolder.setChildIndex(DisplayObject(itemEditorInstance), (actualContentHolder.numChildren - 1));
                itemEditorInstance.visible = true;
                itemEditorInstance.move(_loc_4.x + _loc_8, _loc_5.y + _loc_9);
                itemEditorInstance.setActualSize(Math.min(_loc_3.width + _loc_10, (actualContentHolder.width - 1) - itemEditorInstance.x), Math.min(_loc_5.height + _loc_11, actualContentHolder.height - itemEditorInstance.y));
                DisplayObject(itemEditorInstance).addEventListener(FocusEvent.FOCUS_OUT, itemEditorFocusOutHandler);
                _loc_4.visible = false;
            }
            else
            {
                itemEditorInstance = _loc_4;
            }
            DisplayObject(itemEditorInstance).addEventListener(KeyboardEvent.KEY_DOWN, editorKeyDownHandler);
            systemManager.getSandboxRoot().addEventListener(MouseEvent.MOUSE_DOWN, editorMouseDownHandler, true, 0, true);
            systemManager.getSandboxRoot().addEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, editorMouseDownHandler, false, 0, true);
            systemManager.addEventListener(Event.RESIZE, editorStageResizeHandler, true, 0, true);
            var _loc_6:* = new DataGridEvent(DataGridEvent.ITEM_EDITOR_CREATE, false, true, param1, null, param2);
            dispatchEvent(_loc_6);
            return;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            super.enabled = param1;
            if (header)
            {
                header.enabled = param1;
            }
            if (itemEditorInstance)
            {
                endEdit(DataGridEventReason.OTHER);
            }
            invalidateDisplayList();
            return;
        }// end function

        override protected function collectionChangeHandler(event:Event) : void
        {
            var _loc_2:Object = null;
            var _loc_3:CollectionEvent = null;
            var _loc_4:CollectionEvent = null;
            if (event is CollectionEvent)
            {
                _loc_3 = CollectionEvent(event);
                if (_loc_3.kind == CollectionEventKind.RESET)
                {
                    if (itemEditorInstance)
                    {
                        endEdit(DataGridEventReason.CANCELLED);
                    }
                    setEditedItemPosition(null);
                    if (generatedColumns)
                    {
                        generateCols();
                    }
                    else
                    {
                        columnsInvalid = true;
                    }
                    updateSortIndexAndDirection();
                    if (lockedRowContent)
                    {
                        lockedRowContent.iterator = collection.createCursor();
                    }
                    if (lockedColumnAndRowContent)
                    {
                        lockedColumnAndRowContent.iterator = collection.createCursor();
                    }
                }
                else if (_loc_3.kind == CollectionEventKind.REFRESH && !manualSort)
                {
                    updateSortIndexAndDirection();
                }
                else if (_loc_3.kind == CollectionEventKind.ADD)
                {
                    if (editedItemPosition)
                    {
                        if (_loc_3.location <= editedItemPosition.rowIndex)
                        {
                            _loc_2 = editedItemPosition;
                            if (inEndEdit)
                            {
                                _editedItemPosition = {columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex + _loc_3.items.length)};
                            }
                            else if (itemEditorInstance)
                            {
                                _editedItemPosition = {columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex + _loc_3.items.length)};
                                itemEditorPositionChanged = true;
                                lastEditedItemPosition = _editedItemPosition;
                            }
                            else
                            {
                                setEditedItemPosition({columnIndex:_loc_2.columnIndex, rowIndex:Math.max(0, _loc_2.rowIndex + _loc_3.items.length)});
                            }
                        }
                    }
                }
                else if (_loc_3.kind == CollectionEventKind.REMOVE)
                {
                    if (editedItemPosition)
                    {
                        if (collection.length == 0)
                        {
                            if (itemEditorInstance)
                            {
                                endEdit(DataGridEventReason.CANCELLED);
                            }
                            setEditedItemPosition(null);
                        }
                        else if (_loc_3.location <= editedItemPosition.rowIndex)
                        {
                            _loc_2 = editedItemPosition;
                            if (_loc_3.location == editedItemPosition.rowIndex && itemEditorInstance)
                            {
                                endEdit(DataGridEventReason.CANCELLED);
                            }
                            if (inEndEdit)
                            {
                                _editedItemPosition = {columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex - _loc_3.items.length)};
                            }
                            else if (itemEditorInstance)
                            {
                                _editedItemPosition = {columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex - _loc_3.items.length)};
                                itemEditorPositionChanged = true;
                                lastEditedItemPosition = _editedItemPosition;
                            }
                            else
                            {
                                setEditedItemPosition({columnIndex:_loc_2.columnIndex, rowIndex:Math.max(0, _loc_2.rowIndex - _loc_3.items.length)});
                            }
                        }
                    }
                }
                else if (_loc_3.kind == CollectionEventKind.REPLACE)
                {
                    if (editedItemPosition)
                    {
                        if (_loc_3.location == editedItemPosition.rowIndex && itemEditorInstance)
                        {
                            endEdit(DataGridEventReason.CANCELLED);
                        }
                    }
                }
            }
            super.collectionChangeHandler(event);
            if (event is CollectionEvent)
            {
                _loc_4 = CollectionEvent(event);
                if (_loc_4.kind == CollectionEventKind.ADD)
                {
                    if (collection.length == 1)
                    {
                        if (generatedColumns)
                        {
                            generateCols();
                        }
                    }
                }
                else if (_loc_4.kind == CollectionEventKind.REFRESH)
                {
                    if (lockedRowCount && lockedRowContent)
                    {
                        lockedRowContent.iterator.seek(CursorBookmark.FIRST, 0);
                    }
                }
            }
            return;
        }// end function

        override protected function get dragImage() : IUIComponent
        {
            var _loc_1:* = new DataGridDragProxy();
            _loc_1.owner = this;
            _loc_1.moduleFactory = moduleFactory;
            return _loc_1;
        }// end function

        public function get draggableColumns() : Boolean
        {
            return _draggableColumns;
        }// end function

        protected function drawSeparators() : void
        {
            DataGridHeader(header)._drawSeparators();
            if (lockedColumnHeader)
            {
                DataGridHeader(lockedColumnHeader)._drawSeparators();
            }
            return;
        }// end function

        override protected function scrollVertically(param1:int, param2:int, param3:Boolean) : void
        {
            super.scrollVertically(param1, param2, param3);
            if (getStyle("horizontalGridLines"))
            {
                drawLinesAndColumnGraphics(listContent, visibleColumns, {});
                if (lockedColumnCount)
                {
                    drawLinesAndColumnGraphics(lockedColumnContent, visibleLockedColumns, {right:1});
                }
            }
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            var _loc_2:Number = NaN;
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                _loc_2 = 0;
                if (border && border is IRectangularBorder)
                {
                    _loc_2 = IRectangularBorder(border).borderMetrics.top;
                }
                return _loc_2 + measureText(" ").ascent;
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            if (!showHeaders)
            {
                return super.baselinePosition;
            }
            var _loc_1:* = DataGridHeader(header).rendererArray[0];
            if (!_loc_1)
            {
                return super.baselinePosition;
            }
            return header.y + _loc_1.y + _loc_1.baselinePosition;
        }// end function

        private function displayingPartialRow() : Boolean
        {
            var _loc_1:* = (listItems.length - 1) - offscreenExtraRowsBottom;
            if (rowInfo[_loc_1].y + rowInfo[_loc_1].height > listContent.heightExcludingOffsets - listContent.topOffset)
            {
                return true;
            }
            return false;
        }// end function

        function calculateHeaderHeight() : Number
        {
            var _loc_1:IListItemRenderer = null;
            var _loc_2:DataGridColumn = null;
            var _loc_3:DataGridListData = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (!columns.length)
            {
                return rowHeight;
            }
            if (!listContent)
            {
                return rowHeight;
            }
            var _loc_4:Number = 0;
            var _loc_7:* = getStyle("paddingTop");
            var _loc_8:* = getStyle("paddingBottom");
            if (showHeaders)
            {
                _loc_4 = 0;
                _loc_5 = columns.length;
                if (_headerWordWrapPresent)
                {
                    _headerHeight = _originalHeaderHeight;
                    _explicitHeaderHeight = _originalExplicitHeaderHeight;
                }
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    _loc_2 = columns[_loc_6];
                    if (!_loc_2.visible)
                    {
                    }
                    else
                    {
                        _loc_1 = _loc_2.cachedHeaderRenderer;
                        if (!_loc_1)
                        {
                            _loc_1 = createColumnItemRenderer(_loc_2, true, _loc_2);
                            _loc_1.styleName = _loc_2;
                            _loc_2.cachedHeaderRenderer = _loc_1;
                        }
                        if (DisplayObject(_loc_1).parent == null)
                        {
                            listContent.addChild(DisplayObject(_loc_1));
                            _loc_1.visible = false;
                        }
                        _loc_3 = DataGridListData(makeListData(_loc_2, uid, 0, _loc_2.colNum, _loc_2));
                        rowMap[_loc_1.name] = _loc_3;
                        if (_loc_1 is IDropInListItemRenderer)
                        {
                            IDropInListItemRenderer(_loc_1).listData = _loc_3;
                        }
                        _loc_1.data = _loc_2;
                        _loc_1.explicitWidth = _loc_2.width;
                        UIComponentGlobals.layoutManager.validateClient(_loc_1, true);
                        _loc_4 = Math.max(_loc_4, _explicitHeaderHeight ? (headerHeight) : (_loc_1.getExplicitOrMeasuredHeight() + _loc_8 + _loc_7));
                        if (columnHeaderWordWrap(_loc_2))
                        {
                            _headerWordWrapPresent = true;
                        }
                    }
                    _loc_6++;
                }
                if (_headerWordWrapPresent)
                {
                    _originalHeaderHeight = _headerHeight;
                    _originalExplicitHeaderHeight = _explicitHeaderHeight;
                    _headerHeight = _loc_4;
                    _explicitHeaderHeight = true;
                }
            }
            return _loc_4;
        }// end function

        private function calculateColumnSizes() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_5:DataGridColumn = null;
            var _loc_6:Number = NaN;
            var _loc_7:DataGridColumn = null;
            var _loc_8:Number = NaN;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:Number = NaN;
            var _loc_12:Number = NaN;
            var _loc_13:Number = NaN;
            var _loc_14:Number = NaN;
            var _loc_4:Number = 0;
            if (columns.length == 0)
            {
                visibleColumns = [];
                visibleLockedColumns = [];
                lockedColumnWidth = 0;
                columnsInvalid = false;
                return;
            }
            if (columnsInvalid)
            {
                columnsInvalid = false;
                visibleColumns = [];
                visibleLockedColumns = [];
                lockedColumnWidth = 0;
                if (minColumnWidthInvalid)
                {
                    _loc_2 = columns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        columns[_loc_3].minWidth = minColumnWidth;
                        _loc_3++;
                    }
                    minColumnWidthInvalid = false;
                }
                displayableColumns = null;
                _loc_2 = _columns.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (displayableColumns && _columns[_loc_3].visible)
                    {
                        displayableColumns.push(_columns[_loc_3]);
                    }
                    else if (!displayableColumns && !_columns[_loc_3].visible)
                    {
                        displayableColumns = new Array(_loc_3);
                        _loc_9 = 0;
                        while (_loc_9 < _loc_3)
                        {
                            
                            displayableColumns[_loc_9] = _columns[_loc_9];
                            _loc_9++;
                        }
                    }
                    _loc_3++;
                }
                if (!displayableColumns)
                {
                    displayableColumns = _columns;
                }
                if (horizontalScrollPolicy == ScrollPolicy.OFF)
                {
                    _loc_2 = displayableColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        _loc_5 = displayableColumns[_loc_3];
                        if (_loc_3 < lockedColumnCount)
                        {
                            visibleLockedColumns.push(_loc_5);
                        }
                        else
                        {
                            visibleColumns.push(_loc_5);
                        }
                        _loc_3++;
                    }
                }
                else
                {
                    _loc_2 = displayableColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        if (_loc_3 >= lockedColumnCount && _loc_3 < lockedColumnCount + horizontalScrollPosition)
                        {
                        }
                        else
                        {
                            _loc_5 = displayableColumns[_loc_3];
                            if (_loc_5.preferredWidth < _loc_5.minWidth)
                            {
                                _loc_5.preferredWidth = _loc_5.minWidth;
                            }
                            if (_loc_4 < displayWidth)
                            {
                                if (_loc_3 < lockedColumnCount)
                                {
                                    lockedColumnWidth = lockedColumnWidth + Math.max(isNaN(_loc_5.explicitWidth) ? (_loc_5.preferredWidth) : (_loc_5.explicitWidth), _loc_5.minWidth);
                                    visibleLockedColumns.push(_loc_5);
                                }
                                else
                                {
                                    visibleColumns.push(_loc_5);
                                }
                                _loc_4 = _loc_4 + Math.max(isNaN(_loc_5.explicitWidth) ? (_loc_5.preferredWidth) : (_loc_5.explicitWidth), _loc_5.minWidth);
                                if (_loc_5.width != _loc_5.preferredWidth)
                                {
                                    _loc_5.setWidth(_loc_5.preferredWidth);
                                }
                            }
                            else
                            {
                                if (visibleColumns.length == 0)
                                {
                                    visibleColumns.push(displayableColumns[0]);
                                }
                                break;
                            }
                        }
                        _loc_3++;
                    }
                }
            }
            if (horizontalScrollPolicy == ScrollPolicy.OFF)
            {
                _loc_10 = 0;
                _loc_11 = 0;
                _loc_2 = visibleColumns.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (visibleColumns[_loc_3].resizable && !visibleColumns[_loc_3].newlyVisible)
                    {
                        if (!isNaN(visibleColumns[_loc_3].explicitWidth))
                        {
                            _loc_11 = _loc_11 + visibleColumns[_loc_3].width;
                        }
                        else
                        {
                            _loc_10++;
                            _loc_11 = _loc_11 + visibleColumns[_loc_3].minWidth;
                        }
                    }
                    else
                    {
                        _loc_11 = _loc_11 + visibleColumns[_loc_3].width;
                    }
                    _loc_4 = _loc_4 + visibleColumns[_loc_3].width;
                    _loc_3++;
                }
                _loc_2 = visibleLockedColumns.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (visibleLockedColumns[_loc_3].resizable && !visibleLockedColumns[_loc_3].newlyVisible)
                    {
                        if (!isNaN(visibleLockedColumns[_loc_3].explicitWidth))
                        {
                            _loc_11 = _loc_11 + visibleLockedColumns[_loc_3].width;
                        }
                        else
                        {
                            _loc_10++;
                            _loc_11 = _loc_11 + visibleLockedColumns[_loc_3].minWidth;
                        }
                    }
                    else
                    {
                        _loc_11 = _loc_11 + visibleLockedColumns[_loc_3].width;
                    }
                    _loc_4 = _loc_4 + visibleLockedColumns[_loc_3].width;
                    _loc_3++;
                }
                _loc_13 = displayWidth;
                if (displayWidth > _loc_11 && _loc_10)
                {
                    _loc_2 = visibleLockedColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        if (visibleLockedColumns[_loc_3].resizable && !visibleLockedColumns[_loc_3].newlyVisible && isNaN(visibleLockedColumns[_loc_3].explicitWidth))
                        {
                            _loc_7 = visibleLockedColumns[_loc_3];
                            if (_loc_4 > displayWidth)
                            {
                                _loc_12 = (_loc_7.width - _loc_7.minWidth) / (_loc_4 - _loc_11);
                            }
                            else
                            {
                                _loc_12 = _loc_7.width / _loc_4;
                            }
                            _loc_8 = _loc_7.width - (_loc_4 - displayWidth) * _loc_12;
                            _loc_14 = visibleLockedColumns[_loc_3].minWidth;
                            visibleLockedColumns[_loc_3].setWidth(_loc_8 > _loc_14 ? (_loc_8) : (_loc_14));
                        }
                        _loc_13 = _loc_13 - visibleLockedColumns[_loc_3].width;
                        visibleLockedColumns[_loc_3].newlyVisible = false;
                        _loc_3++;
                    }
                    _loc_2 = visibleColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        if (visibleColumns[_loc_3].resizable && !visibleColumns[_loc_3].newlyVisible && isNaN(visibleColumns[_loc_3].explicitWidth))
                        {
                            _loc_7 = visibleColumns[_loc_3];
                            if (_loc_4 > displayWidth)
                            {
                                _loc_12 = (_loc_7.width - _loc_7.minWidth) / (_loc_4 - _loc_11);
                            }
                            else
                            {
                                _loc_12 = _loc_7.width / _loc_4;
                            }
                            _loc_8 = _loc_7.width - (_loc_4 - displayWidth) * _loc_12;
                            _loc_14 = visibleColumns[_loc_3].minWidth;
                            visibleColumns[_loc_3].setWidth(_loc_8 > _loc_14 ? (_loc_8) : (_loc_14));
                        }
                        _loc_13 = _loc_13 - visibleColumns[_loc_3].width;
                        visibleColumns[_loc_3].newlyVisible = false;
                        _loc_3++;
                    }
                    if (_loc_13 && _loc_7)
                    {
                        _loc_7.setWidth(_loc_7.width + _loc_13);
                    }
                }
                else
                {
                    _loc_2 = visibleLockedColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        _loc_7 = visibleLockedColumns[_loc_3];
                        _loc_12 = _loc_7.width / _loc_4;
                        _loc_8 = displayWidth * _loc_12;
                        _loc_7.setWidth(_loc_8);
                        _loc_7.explicitWidth = NaN;
                        _loc_13 = _loc_13 - _loc_8;
                        _loc_3++;
                    }
                    _loc_2 = visibleColumns.length;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2)
                    {
                        
                        _loc_7 = visibleColumns[_loc_3];
                        _loc_12 = _loc_7.width / _loc_4;
                        _loc_8 = displayWidth * _loc_12;
                        _loc_7.setWidth(_loc_8);
                        _loc_7.explicitWidth = NaN;
                        _loc_13 = _loc_13 - _loc_8;
                        _loc_3++;
                    }
                    if (_loc_13 && _loc_7)
                    {
                        _loc_7.setWidth(_loc_7.width + _loc_13);
                    }
                }
            }
            else
            {
                _loc_4 = 0;
                _loc_2 = visibleColumns.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (_loc_4 > displayWidth - lockedColumnWidth)
                    {
                        visibleColumns.splice(_loc_3);
                        break;
                    }
                    _loc_4 = _loc_4 + (isNaN(visibleColumns[_loc_3].explicitWidth) ? (visibleColumns[_loc_3].preferredWidth) : (visibleColumns[_loc_3].explicitWidth));
                    _loc_3++;
                }
                if (visibleColumns.length == 0)
                {
                    return;
                }
                _loc_3 = visibleColumns[(visibleColumns.length - 1)].colNum + 1;
                if (_loc_4 < displayWidth - lockedColumnWidth && _loc_3 < displayableColumns.length)
                {
                    _loc_2 = displayableColumns.length;
                    while (_loc_3 < _loc_2 && _loc_4 < displayWidth - lockedColumnWidth)
                    {
                        
                        _loc_5 = displayableColumns[_loc_3];
                        visibleColumns.push(_loc_5);
                        _loc_4 = _loc_4 + (isNaN(_loc_5.explicitWidth) ? (_loc_5.preferredWidth) : (_loc_5.explicitWidth));
                        _loc_3++;
                    }
                }
                else if (_loc_4 < displayWidth - lockedColumnWidth && horizontalScrollPosition > 0)
                {
                    while (_loc_4 < displayWidth - lockedColumnWidth && horizontalScrollPosition > 0)
                    {
                        
                        _loc_5 = displayableColumns[lockedColumnCount + horizontalScrollPosition - 1];
                        _loc_6 = isNaN(_loc_5.explicitWidth) ? (_loc_5.preferredWidth) : (_loc_5.explicitWidth);
                        if (_loc_6 < displayWidth - lockedColumnWidth - _loc_4)
                        {
                            visibleColumns.splice(0, 0, _loc_5);
                            var _loc_15:String = this;
                            var _loc_16:* = super.horizontalScrollPosition - 1;
                            _loc_15.horizontalScrollPosition = _loc_16;
                            _loc_4 = _loc_4 + _loc_6;
                            continue;
                        }
                        break;
                    }
                }
                _loc_7 = visibleColumns[(visibleColumns.length - 1)];
                _loc_6 = isNaN(_loc_7.explicitWidth) ? (_loc_7.preferredWidth) : (_loc_7.explicitWidth);
                _loc_8 = _loc_6 + displayWidth - lockedColumnWidth - _loc_4;
                if (_loc_7 == displayableColumns[(displayableColumns.length - 1)] && _loc_7.resizable && _loc_8 >= _loc_7.minWidth && _loc_8 > _loc_6)
                {
                    _loc_7.setWidth(_loc_8);
                    maxHorizontalScrollPosition = displayableColumns.length - visibleColumns.length;
                }
                else if (visibleColumns.length == 1 && _loc_7 == displayableColumns[(displayableColumns.length - 1)])
                {
                    maxHorizontalScrollPosition = displayableColumns.length - visibleColumns.length;
                }
                else
                {
                    maxHorizontalScrollPosition = displayableColumns.length - visibleColumns.length + 1;
                }
            }
            lockedColumnWidth = 0;
            if (visibleLockedColumns.length)
            {
                _loc_2 = visibleLockedColumns.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    _loc_5 = visibleLockedColumns[_loc_3];
                    lockedColumnWidth = lockedColumnWidth + _loc_5.width;
                    _loc_3++;
                }
            }
            return;
        }// end function

        private function beginningEdit(param1:int, param2:int, param3:IListItemRenderer = null) : void
        {
            var _loc_4:* = new DataGridEvent(DataGridEvent.ITEM_EDIT_BEGINNING, false, true);
            new DataGridEvent(DataGridEvent.ITEM_EDIT_BEGINNING, false, true).columnIndex = param1;
            _loc_4.dataField = _columns[param1].dataField;
            _loc_4.rowIndex = param2;
            _loc_4.itemRenderer = param3;
            if (!dispatchEvent(_loc_4))
            {
                lastEditedItemPosition = {columnIndex:param1, rowIndex:param2};
            }
            return;
        }// end function

        protected function drawRowGraphics(param1:ListBaseContentHolder) : void
        {
            var _loc_3:Array = null;
            var _loc_7:int = 0;
            var _loc_2:* = Sprite(param1.getChildByName("rowBGs"));
            if (!_loc_2)
            {
                _loc_2 = new FlexSprite();
                _loc_2.mouseEnabled = false;
                _loc_2.name = "rowBGs";
                param1.addChildAt(_loc_2, 0);
            }
            _loc_3 = getStyle("alternatingItemColors");
            if (!_loc_3 || _loc_3.length == 0)
            {
                while (_loc_2.numChildren > _loc_7)
                {
                    
                    _loc_2.removeChildAt((_loc_2.numChildren - 1));
                }
                return;
            }
            StyleManager.getColorNames(_loc_3);
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:* = verticalScrollPosition;
            _loc_7 = param1.listItems.length;
            while (_loc_4 < _loc_7)
            {
                
                drawRowBackground(_loc_2, _loc_5++, param1.rowInfo[_loc_4].y, param1.rowInfo[_loc_4].height, _loc_3[_loc_6 % _loc_3.length], _loc_6);
                _loc_4++;
                _loc_6++;
            }
            while (_loc_2.numChildren > _loc_5)
            {
                
                _loc_2.removeChildAt((_loc_2.numChildren - 1));
            }
            return;
        }// end function

        protected function drawHorizontalLine(param1:Sprite, param2:int, param3:uint, param4:Number) : void
        {
            var _loc_5:* = param1.parent.parent as ListBaseContentHolder;
            var _loc_6:* = param1.graphics;
            param1.graphics.lineStyle(1, param3);
            _loc_6.moveTo(0, param4);
            _loc_6.lineTo(_loc_5.width, param4);
            return;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (DataGrid.createAccessibilityImplementation != null)
            {
                DataGrid.createAccessibilityImplementation(this);
            }
            return;
        }// end function

        private function endEdit(param1:String) : Boolean
        {
            if (!editedItemRenderer)
            {
                return true;
            }
            inEndEdit = true;
            var _loc_2:* = new DataGridEvent(DataGridEvent.ITEM_EDIT_END, false, true);
            _loc_2.columnIndex = editedItemPosition.columnIndex;
            _loc_2.dataField = _columns[editedItemPosition.columnIndex].dataField;
            _loc_2.rowIndex = editedItemPosition.rowIndex;
            _loc_2.itemRenderer = editedItemRenderer;
            _loc_2.reason = param1;
            dispatchEvent(_loc_2);
            dontEdit = itemEditorInstance != null;
            if (!dontEdit && param1 == DataGridEventReason.CANCELLED)
            {
                losingFocus = true;
                setFocus();
            }
            inEndEdit = false;
            return !_loc_2.isDefaultPrevented();
        }// end function

        private function editorKeyDownHandler(event:KeyboardEvent) : void
        {
            if (event.keyCode == Keyboard.ESCAPE)
            {
                endEdit(DataGridEventReason.CANCELLED);
            }
            else if (event.ctrlKey && event.charCode == 46)
            {
                endEdit(DataGridEventReason.CANCELLED);
            }
            else if (event.charCode == Keyboard.ENTER && event.keyCode != 229)
            {
                if (!_editedItemPosition)
                {
                    return;
                }
                if (columns[_editedItemPosition.columnIndex].editorUsesEnterKey)
                {
                    return;
                }
                if (endEdit(DataGridEventReason.NEW_ROW) && !dontEdit)
                {
                    findNextEnterItemRenderer(event);
                }
            }
            return;
        }// end function

        private function itemEditorFocusOutHandler(event:FocusEvent) : void
        {
            if (event.relatedObject && contains(event.relatedObject))
            {
                return;
            }
            if (!event.relatedObject)
            {
                return;
            }
            if (itemEditorInstance)
            {
                endEdit(DataGridEventReason.OTHER);
            }
            return;
        }// end function

        override public function itemToLabel(param1:Object) : String
        {
            return displayableColumns[sortIndex == -1 ? (0) : (sortIndex)].itemToLabel(param1);
        }// end function

        function _drawSeparators() : void
        {
            drawSeparators();
            return;
        }// end function

        override protected function configureScrollBars() : void
        {
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            if (columnsInvalid)
            {
                return;
            }
            if (!displayableColumns)
            {
                return;
            }
            var _loc_1:* = this.listItems;
            if (visibleColumns && !visibleColumns.length && visibleLockedColumns && visibleLockedColumns.length)
            {
                _loc_1 = lockedColumnContent.listItems;
            }
            var _loc_2:* = horizontalScrollBar;
            var _loc_3:* = verticalScrollBar;
            var _loc_4:* = _loc_1.length;
            if (_loc_1.length == 0)
            {
                if (_loc_2 || _loc_3)
                {
                    if (listContent.height)
                    {
                        setScrollBarProperties(0, 0, 0, 0);
                    }
                }
                return;
            }
            if (_loc_4 > 1 && displayingPartialRow())
            {
                _loc_4 = _loc_4 - 1;
            }
            var _loc_5:* = verticalScrollPosition;
            var _loc_6:int = 0;
            while (_loc_4 && _loc_1[(_loc_4 - 1)].length == 0)
            {
                
                if (collection && _loc_4 + _loc_5 >= collection.length - lockedRowCount)
                {
                    _loc_4 = _loc_4 - 1;
                    _loc_6++;
                    continue;
                }
                break;
            }
            if (verticalScrollPosition > 0 && _loc_6 > 0)
            {
                if (adjustVerticalScrollPositionDownward(Math.max(_loc_4, 1)))
                {
                    return;
                }
            }
            _loc_4 = _loc_4 - (offscreenExtraRowsTop + offscreenExtraRowsBottom);
            var _loc_7:* = collection && collection.length > 0;
            var _loc_8:* = collection && collection.length > 0 && _loc_4 > 0 ? (listItems[0].length) : (visibleColumns.length);
            if (_loc_7 && _loc_4 > 0 && _loc_8 > 1 && listItems[0][(_loc_8 - 1)].x + visibleColumns[(_loc_8 - 1)].width > displayWidth - listContent.x + viewMetrics.left)
            {
                _loc_8 = _loc_8 - 1;
            }
            else if (_loc_8 > 1 && !_loc_7)
            {
                _loc_9 = 0;
                _loc_10 = 0;
                while (_loc_10 < visibleColumns.length)
                {
                    
                    _loc_9 = _loc_9 + visibleColumns[_loc_10].width;
                    _loc_10++;
                }
                if (_loc_9 > displayWidth - listContent.x + viewMetrics.left)
                {
                    _loc_8 = _loc_8 - 1;
                }
            }
            setScrollBarProperties(displayableColumns.length - lockedColumnCount, Math.max(_loc_8, 1), collection ? (collection.length - lockedRowCount) : (0), Math.max(_loc_4, 1));
            if ((!verticalScrollBar || !verticalScrollBar.visible) && collection && collection.length - lockedRowCount > _loc_4)
            {
                maxVerticalScrollPosition = collection.length - lockedRowCount - _loc_4;
            }
            if ((!horizontalScrollBar || !horizontalScrollBar.visible) && displayableColumns.length - lockedColumnCount > _loc_8 - lockedColumnCount)
            {
                maxHorizontalScrollPosition = displayableColumns.length - lockedColumnCount - _loc_8;
            }
            return;
        }// end function

        override public function set horizontalScrollPosition(param1:Number) : void
        {
            var _loc_3:CursorBookmark = null;
            var _loc_4:CursorBookmark = null;
            if (!initialized || listItems.length == 0)
            {
                super.horizontalScrollPosition = param1;
                return;
            }
            var _loc_2:* = super.horizontalScrollPosition;
            super.horizontalScrollPosition = param1;
            scrollAreaChanged = true;
            columnsInvalid = true;
            calculateColumnSizes();
            if (itemsSizeChanged)
            {
                return;
            }
            if (_loc_2 != param1)
            {
                removeClipMask();
                if (iterator)
                {
                    _loc_3 = iterator.bookmark;
                }
                clearIndicators();
                clearVisibleData();
                makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
                if (lockedRowCount)
                {
                    _loc_4 = lockedRowContent.iterator.bookmark;
                    makeRows(lockedRowContent, 0, 0, unscaledWidth, unscaledHeight, 0, 0, true, lockedRowCount);
                    if (iteratorValid)
                    {
                        lockedRowContent.iterator.seek(_loc_4, 0);
                    }
                }
                if (headerVisible && header)
                {
                    header.visibleColumns = visibleColumns;
                    header.headerItemsChanged = true;
                    header.invalidateSize();
                    header.validateNow();
                }
                if (iterator && _loc_3)
                {
                    iterator.seek(_loc_3, 0);
                }
                invalidateDisplayList();
                addClipMask(false);
            }
            return;
        }// end function

        protected function drawColumnBackground(param1:Sprite, param2:int, param3:uint, param4:DataGridColumn) : void
        {
            var _loc_5:Shape = null;
            _loc_5 = Shape(param1.getChildByName(param2.toString()));
            if (!_loc_5)
            {
                _loc_5 = new FlexShape();
                param1.addChild(_loc_5);
                _loc_5.name = param2.toString();
            }
            var _loc_6:* = _loc_5.graphics;
            _loc_5.graphics.clear();
            _loc_6.beginFill(param3);
            var _loc_7:* = rowInfo[(listItems.length - 1)];
            var _loc_8:* = param1.parent == lockedColumnContent ? (DataGridHeader(lockedColumnHeader)) : (DataGridHeader(header));
            var _loc_9:* = (param1.parent == lockedColumnContent ? (DataGridHeader(lockedColumnHeader)) : (DataGridHeader(header))).rendererArray[param2].x;
            var _loc_10:* = rowInfo[0].y;
            var _loc_11:* = Math.min(_loc_7.y + _loc_7.height, listContent.height - _loc_10);
            _loc_6.drawRect(_loc_9, _loc_10, _loc_8.visibleColumns[param2].width, listContent.height - _loc_10);
            _loc_6.endFill();
            return;
        }// end function

        override public function set columns(param1:Array) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:DataGridColumn = null;
            var _loc_5:DisplayObject = null;
            _loc_2 = _columns.length;
            _loc_3 = 0;
            while (_loc_3 < _loc_2)
            {
                
                columnRendererChanged(_columns[_loc_3]);
                _loc_3++;
            }
            freeItemRenderersTable = new Dictionary(false);
            columnMap = {};
            _columns = param1.slice(0);
            columnsInvalid = true;
            generatedColumns = false;
            _loc_2 = param1.length;
            _loc_3 = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = _columns[_loc_3];
                _loc_4.owner = this;
                _loc_4.colNum = _loc_3;
                if (_loc_4.cachedHeaderRenderer)
                {
                    _loc_5 = _loc_4.cachedHeaderRenderer as DisplayObject;
                    if (_loc_5.parent)
                    {
                        _loc_5.parent.removeChild(_loc_5);
                    }
                    _loc_4.cachedHeaderRenderer = null;
                }
                _loc_3++;
            }
            updateSortIndexAndDirection();
            itemsSizeChanged = true;
            invalidateDisplayList();
            dispatchEvent(new Event("columnsChanged"));
            return;
        }// end function

        override protected function mouseWheelHandler(event:MouseEvent) : void
        {
            if (itemEditorInstance)
            {
                endEdit(DataGridEventReason.OTHER);
            }
            super.mouseWheelHandler(event);
            return;
        }// end function

        public function get editedItemRenderer() : IListItemRenderer
        {
            if (!itemEditorInstance)
            {
                return null;
            }
            return actualContentHolder.listItems[actualRowIndex][actualColIndex];
        }// end function

        public function set minColumnWidth(param1:Number) : void
        {
            _minColumnWidth = param1;
            minColumnWidthInvalid = true;
            itemsSizeChanged = true;
            columnsInvalid = true;
            invalidateDisplayList();
            return;
        }// end function

        override public function set focusPane(param1:Sprite) : void
        {
            super.focusPane = param1;
            if (!param1 && _focusPane)
            {
                _focusPane.mask = null;
            }
            _focusPane = param1;
            return;
        }// end function

        override function get rendererArray() : Array
        {
            var _loc_1:* = listItems.slice();
            var _loc_2:* = DataGridHeader(header).rendererArray;
            _loc_1.unshift(_loc_2);
            return _loc_1;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:Number = NaN;
            var _loc_3:Object = null;
            var _loc_4:IListItemRenderer = null;
            var _loc_5:DataGridColumn = null;
            var _loc_6:Number = NaN;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            super.commitProperties();
            if (itemsNeedMeasurement)
            {
                itemsNeedMeasurement = false;
                if (isNaN(explicitRowHeight))
                {
                    if (iterator && columns.length > 0)
                    {
                        visibleColumns = columns;
                        columnsInvalid = true;
                        _loc_1 = getStyle("paddingTop");
                        _loc_2 = getStyle("paddingBottom");
                        _loc_3 = iterator.current;
                        _loc_6 = 0;
                        _loc_7 = columns.length;
                        _loc_8 = 0;
                        while (_loc_8 < _loc_7)
                        {
                            
                            _loc_5 = columns[_loc_8];
                            if (!_loc_5.visible)
                            {
                            }
                            else
                            {
                                _loc_4 = _loc_5.getMeasuringRenderer(false, _loc_3);
                                if (DisplayObject(_loc_4).parent == null)
                                {
                                    listContent.addChild(DisplayObject(_loc_4));
                                }
                                setupRendererFromData(_loc_5, _loc_4, _loc_3);
                                _loc_6 = Math.max(_loc_6, _loc_4.getExplicitOrMeasuredHeight() + _loc_2 + _loc_1);
                            }
                            _loc_8++;
                        }
                        setRowHeight(Math.max(_loc_6, 20));
                    }
                    else
                    {
                        setRowHeight(20);
                    }
                }
            }
            return;
        }// end function

        protected function drawRowBackground(param1:Sprite, param2:int, param3:Number, param4:Number, param5:uint, param6:int) : void
        {
            var _loc_8:Shape = null;
            var _loc_7:* = ListBaseContentHolder(param1.parent);
            if (param2 < param1.numChildren)
            {
                _loc_8 = Shape(param1.getChildAt(param2));
            }
            else
            {
                _loc_8 = new FlexShape();
                _loc_8.name = "background";
                param1.addChild(_loc_8);
            }
            _loc_8.y = param3;
            param4 = Math.min(param4, _loc_7.height - param3);
            var _loc_9:* = _loc_8.graphics;
            _loc_8.graphics.clear();
            _loc_9.beginFill(param5, getStyle("backgroundAlpha"));
            _loc_9.drawRect(0, 0, _loc_7.width, param4);
            _loc_9.endFill();
            return;
        }// end function

        private function adjustVerticalScrollPositionDownward(param1:int) : Boolean
        {
            var item:IListItemRenderer;
            var c:DataGridColumn;
            var n:int;
            var j:int;
            var bMore:Boolean;
            var data:Object;
            var rowCount:* = param1;
            var bookmark:* = iterator.bookmark;
            var h:Number;
            var ch:Number;
            var paddingTop:* = getStyle("paddingTop");
            var paddingBottom:* = getStyle("paddingBottom");
            h = rowInfo[(rowCount - 1)].y + rowInfo[(rowCount - 1)].height;
            h = listContent.heightExcludingOffsets - listContent.topOffset - h;
            var numRows:int;
            try
            {
                if (iterator.afterLast)
                {
                    iterator.seek(CursorBookmark.LAST, 0);
                }
                else
                {
                    bMore = iterator.movePrevious();
                }
            }
            catch (e:ItemPendingError)
            {
                bMore;
            }
            if (!bMore)
            {
                super.verticalScrollPosition = 0;
                try
                {
                    iterator.seek(CursorBookmark.FIRST, 0);
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
                    invalidateList();
                    return true;
                }
                updateList();
                return true;
            }
            do
            {
                
                if (bMore)
                {
                    data = iterator.current;
                    ch;
                    n = columns.length;
                    j;
                    while (j < n)
                    {
                        
                        c = columns[j];
                        if (!c.visible)
                        {
                        }
                        else
                        {
                            if (variableRowHeight)
                            {
                                item = c.getMeasuringRenderer(false, data);
                                if (DisplayObject(item).parent == null)
                                {
                                    listContent.addChild(DisplayObject(item));
                                }
                                setupRendererFromData(c, item, data);
                            }
                            ch = Math.max(ch, variableRowHeight ? (item.getExplicitOrMeasuredHeight() + paddingBottom + paddingTop) : (rowHeight));
                        }
                        j = (j + 1);
                    }
                }
                h = h - ch;
                try
                {
                    bMore = iterator.movePrevious();
                    numRows = (numRows + 1);
                }
                catch (e:ItemPendingError)
                {
                    bMore;
                }
            }while (h > 0 && bMore)
            if (h < 0)
            {
                numRows = (numRows - 1);
            }
            iterator.seek(bookmark, 0);
            verticalScrollPosition = Math.max(0, verticalScrollPosition - numRows);
            if (numRows > 0 && !variableRowHeight)
            {
                configureScrollBars();
            }
            return numRows > 0;
        }// end function

        override protected function calculateRowHeight(param1:Object, param2:Number, param3:Boolean = false) : Number
        {
            var _loc_4:IListItemRenderer = null;
            var _loc_5:DataGridColumn = null;
            var _loc_7:int = 0;
            var _loc_6:* = columns.length;
            var _loc_8:int = 0;
            var _loc_9:* = visibleLockedColumns.length;
            if (param3 && visibleColumns.length == _columns.length)
            {
                return param2;
            }
            var _loc_10:* = getStyle("paddingTop");
            var _loc_11:* = getStyle("paddingBottom");
            _loc_7 = 0;
            while (_loc_7 < _loc_6)
            {
                
                if (param3 && _loc_8 < _loc_9 && visibleLockedColumns[_loc_8].colNum == columns[_loc_7].colNum)
                {
                    _loc_8++;
                }
                else if (param3 && _loc_8 - _loc_9 < visibleColumns.length && visibleColumns[_loc_8 - _loc_9].colNum == columns[_loc_7].colNum)
                {
                    _loc_8++;
                }
                else
                {
                    _loc_5 = columns[_loc_7];
                    if (!_loc_5.visible)
                    {
                    }
                    else
                    {
                        _loc_4 = _loc_5.getMeasuringRenderer(false, param1);
                        if (DisplayObject(_loc_4).parent == null)
                        {
                            listContent.addChild(DisplayObject(_loc_4));
                        }
                        setupRendererFromData(_loc_5, _loc_4, param1);
                        param2 = Math.max(param2, _loc_4.getExplicitOrMeasuredHeight() + _loc_11 + _loc_10);
                    }
                }
                _loc_7++;
            }
            return param2;
        }// end function

        override public function get columns() : Array
        {
            return _columns.slice(0);
        }// end function

        override protected function scrollHandler(event:Event) : void
        {
            var _loc_2:ScrollBar = null;
            var _loc_3:Number = NaN;
            if (event.target == verticalScrollBar || event.target == horizontalScrollBar)
            {
                if (event is ScrollEvent)
                {
                    if (!liveScrolling && ScrollEvent(event).detail == ScrollEventDetail.THUMB_TRACK)
                    {
                        return;
                    }
                    if (itemEditorInstance)
                    {
                        endEdit(DataGridEventReason.OTHER);
                    }
                    _loc_2 = ScrollBar(event.target);
                    _loc_3 = _loc_2.scrollPosition;
                    if (_loc_2 == verticalScrollBar)
                    {
                        verticalScrollPosition = _loc_3;
                    }
                    else if (_loc_2 == horizontalScrollBar)
                    {
                        horizontalScrollPosition = _loc_3;
                    }
                    super.scrollHandler(event);
                }
            }
            return;
        }// end function

        public function isItemEditable(param1:Object) : Boolean
        {
            if (!editable)
            {
                return false;
            }
            if (!param1)
            {
                return false;
            }
            return true;
        }// end function

        function _placeSortArrow() : void
        {
            placeSortArrow();
            return;
        }// end function

        protected function drawLinesAndColumnGraphics(param1:ListBaseContentHolder, param2:Array, param3:Object) : void
        {
            var _loc_8:uint = 0;
            var _loc_9:int = 0;
            var _loc_13:Number = NaN;
            var _loc_14:Sprite = null;
            var _loc_15:int = 0;
            var _loc_16:Number = NaN;
            var _loc_17:DataGridColumn = null;
            var _loc_18:Object = null;
            var _loc_19:Shape = null;
            var _loc_20:Graphics = null;
            var _loc_21:DisplayObject = null;
            var _loc_4:* = Sprite(param1.getChildByName("lines"));
            if (!Sprite(param1.getChildByName("lines")))
            {
                _loc_4 = new UIComponent();
                _loc_4.name = "lines";
                _loc_4.cacheAsBitmap = true;
                _loc_4.mouseEnabled = false;
                param1.addChild(_loc_4);
            }
            param1.setChildIndex(_loc_4, (param1.numChildren - 1));
            var _loc_5:* = param1.rowInfo;
            _loc_4.graphics.clear();
            var _loc_6:* = Sprite(_loc_4.getChildByName("body"));
            if (!Sprite(_loc_4.getChildByName("body")))
            {
                _loc_6 = new UIComponent();
                _loc_6.name = "body";
                _loc_6.mouseEnabled = false;
                _loc_4.addChild(_loc_6);
            }
            _loc_6.graphics.clear();
            while (_loc_6.numChildren)
            {
                
                _loc_6.removeChildAt(0);
            }
            var _loc_7:* = unscaledHeight - 1;
            var _loc_10:* = param2 ? (param2.length) : (0);
            var _loc_11:* = param1.listItems.length;
            _loc_8 = getStyle("horizontalGridLineColor");
            if (getStyle("horizontalGridLines"))
            {
                _loc_9 = 0;
                while (_loc_9 < _loc_11)
                {
                    
                    _loc_13 = _loc_5[_loc_9].y + _loc_5[_loc_9].height;
                    if (_loc_13 < param1.height)
                    {
                        drawHorizontalSeparator(_loc_6, _loc_9, _loc_8, _loc_13);
                    }
                    _loc_9++;
                }
            }
            if (param3.top)
            {
                drawHorizontalSeparator(_loc_6, _loc_9++, 0, _loc_5[0].y, true);
            }
            if (param3.bottom && _loc_11 > 0)
            {
                drawHorizontalSeparator(_loc_6, _loc_9++, 0, _loc_5[(_loc_11 - 1)].y + _loc_5[(_loc_11 - 1)].height, true);
            }
            var _loc_12:* = getStyle("verticalGridLines");
            _loc_8 = getStyle("verticalGridLineColor");
            if (_loc_10)
            {
                _loc_14 = Sprite(param1.getChildByName("colBGs"));
                _loc_15 = -1;
                _loc_16 = 0;
                _loc_9 = 0;
                while (_loc_9 < _loc_10)
                {
                    
                    if (_loc_12 && _loc_9 < (_loc_10 - 1))
                    {
                        drawVerticalSeparator(_loc_6, _loc_9, _loc_8, _loc_16 + param2[_loc_9].width);
                    }
                    _loc_17 = param2[_loc_9];
                    if (enabled)
                    {
                        _loc_18 = _loc_17.getStyle("backgroundColor");
                    }
                    else
                    {
                        _loc_18 = _loc_17.getStyle("backgroundDisabledColor");
                    }
                    if (_loc_18 !== null && !isNaN(Number(_loc_18)))
                    {
                        if (!_loc_14)
                        {
                            _loc_14 = new FlexSprite();
                            _loc_14.mouseEnabled = false;
                            _loc_14.name = "colBGs";
                            param1.addChildAt(_loc_14, (param1.getChildIndex(param1.getChildByName("rowBGs")) + 1));
                        }
                        drawColumnBackground(_loc_14, _loc_9, Number(_loc_18), _loc_17);
                        _loc_15 = _loc_9;
                    }
                    else if (_loc_14)
                    {
                        _loc_19 = Shape(_loc_14.getChildByName(_loc_9.toString()));
                        if (_loc_19)
                        {
                            _loc_20 = _loc_19.graphics;
                            _loc_20.clear();
                            _loc_14.removeChild(_loc_19);
                        }
                    }
                    _loc_16 = _loc_16 + param2[_loc_9].width;
                    _loc_9++;
                }
                if (_loc_14 && _loc_14.numChildren)
                {
                    while (_loc_14.numChildren)
                    {
                        
                        _loc_21 = _loc_14.getChildAt((_loc_14.numChildren - 1));
                        if (parseInt(_loc_21.name) > _loc_15)
                        {
                            _loc_14.removeChild(_loc_21);
                            continue;
                        }
                        break;
                    }
                }
            }
            if (param3.right && param2 && param2.length)
            {
                if (param1.listItems.length && param1.listItems[0].length)
                {
                    drawVerticalSeparator(_loc_6, _loc_9++, 0, param1.listItems[0][(_loc_10 - 1)].x + param2[(_loc_10 - 1)].width, true);
                }
                else
                {
                    _loc_16 = 0;
                    _loc_9 = 0;
                    while (_loc_9 < _loc_10)
                    {
                        
                        _loc_16 = _loc_16 + param2[_loc_9].width;
                        _loc_9++;
                    }
                    drawVerticalSeparator(_loc_6, _loc_9++, 0, _loc_16, true);
                }
            }
            if (param3.left)
            {
                drawVerticalSeparator(_loc_6, _loc_9++, 0, 0, true);
            }
            return;
        }// end function

        protected function placeSortArrow() : void
        {
            DataGridHeader(header)._placeSortArrow();
            if (lockedColumnHeader)
            {
                DataGridHeader(lockedColumnHeader)._placeSortArrow();
            }
            return;
        }// end function

        private function commitEditedItemPosition(param1:Object) : void
        {
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:ListEvent = null;
            if (!enabled || !editable)
            {
                return;
            }
            if (!collection || collection.length == 0)
            {
                return;
            }
            if (itemEditorInstance && param1 && itemEditorInstance is IFocusManagerComponent && _editedItemPosition.rowIndex == param1.rowIndex && _editedItemPosition.columnIndex == param1.columnIndex)
            {
                IFocusManagerComponent(itemEditorInstance).mx.managers:IFocusManagerComponent::setFocus();
                return;
            }
            if (itemEditorInstance)
            {
                if (!param1)
                {
                    _loc_7 = DataGridEventReason.OTHER;
                }
                else
                {
                    _loc_7 = !editedItemPosition || param1.rowIndex == editedItemPosition.rowIndex ? (DataGridEventReason.NEW_COLUMN) : (DataGridEventReason.NEW_ROW);
                }
                if (!endEdit(_loc_7) && _loc_7 != DataGridEventReason.OTHER)
                {
                    return;
                }
            }
            _editedItemPosition = param1;
            if (!param1)
            {
                return;
            }
            if (dontEdit)
            {
                return;
            }
            var _loc_2:* = param1.rowIndex;
            var _loc_3:* = param1.columnIndex;
            if (displayableColumns.length != _columns.length)
            {
                _loc_8 = 0;
                while (_loc_8 < displayableColumns.length)
                {
                    
                    if (displayableColumns[_loc_8].colNum >= _loc_3)
                    {
                        _loc_3 = _loc_8;
                        break;
                    }
                    _loc_8++;
                }
                if (_loc_8 == displayableColumns.length)
                {
                    _loc_3 = 0;
                }
            }
            var _loc_4:Boolean = false;
            if (selectedIndex != param1.rowIndex)
            {
                commitSelectedIndex(param1.rowIndex);
                _loc_4 = true;
            }
            scrollToEditedItem(_loc_2, _loc_3);
            var _loc_5:* = actualContentHolder.listItems[actualRowIndex][actualColIndex];
            if (!actualContentHolder.listItems[actualRowIndex][actualColIndex])
            {
                commitEditedItemPosition(null);
                return;
            }
            if (!isItemEditable(_loc_5.data))
            {
                commitEditedItemPosition(null);
                return;
            }
            if (_loc_4)
            {
                _loc_9 = new ListEvent(ListEvent.CHANGE);
                _loc_9.columnIndex = param1.columnIndex;
                _loc_9.rowIndex = param1.rowIndex;
                _loc_9.itemRenderer = _loc_5;
                dispatchEvent(_loc_9);
            }
            var _loc_6:* = new DataGridEvent(DataGridEvent.ITEM_EDIT_BEGIN, false, true);
            new DataGridEvent(DataGridEvent.ITEM_EDIT_BEGIN, false, true).columnIndex = displayableColumns[_loc_3].colNum;
            _loc_6.rowIndex = _editedItemPosition.rowIndex;
            _loc_6.itemRenderer = _loc_5;
            dispatchEvent(_loc_6);
            lastEditedItemPosition = _editedItemPosition;
            if (bEditedItemPositionChanged)
            {
                bEditedItemPositionChanged = false;
                commitEditedItemPosition(_proposedEditedItemPosition);
                _proposedEditedItemPosition = undefined;
            }
            if (!itemEditorInstance)
            {
                commitEditedItemPosition(null);
            }
            return;
        }// end function

        protected function getCurrentDataValue(param1:Object, param2:String) : String
        {
            if (!isComplexColumn(param2))
            {
                return param1[param2];
            }
            var _loc_3:* = param2.split(".");
            var _loc_4:* = deriveComplexFieldReference(param1, _loc_3);
            return String(_loc_4);
        }// end function

        private function editorStageResizeHandler(event:Event) : void
        {
            if (event.target is DisplayObjectContainer && DisplayObjectContainer(event.target).contains(this))
            {
                endEdit(DataGridEventReason.OTHER);
            }
            return;
        }// end function

        private function generateColumnsPendingResultHandler(param1:Object, param2:ListBaseSeekPending) : void
        {
            if (columns.length == 0)
            {
                generateCols();
            }
            seekPendingResultHandler(param1, param2);
            return;
        }// end function

        protected function drawVerticalLine(param1:Sprite, param2:int, param3:uint, param4:Number) : void
        {
            var _loc_5:* = param1.parent.parent as ListBaseContentHolder;
            var _loc_6:* = param1.graphics;
            param1.graphics.lineStyle(1, param3, 100);
            _loc_6.moveTo(param4, headerVisible ? (0) : (1));
            _loc_6.lineTo(param4, _loc_5.height);
            return;
        }// end function

        private function editorMouseDownHandler(event:Event) : void
        {
            if (event is MouseEvent && owns(DisplayObject(event.target)))
            {
                return;
            }
            endEdit(DataGridEventReason.OTHER);
            losingFocus = true;
            setFocus();
            return;
        }// end function

        override protected function adjustListContent(param1:Number = -1, param2:Number = -1) : void
        {
            var ww:Number;
            var lcx:Number;
            var lcy:Number;
            var hcx:Number;
            var pt:Point;
            var unscaledWidth:* = param1;
            var unscaledHeight:* = param2;
            var hh:Number;
            if (headerVisible)
            {
                if (lockedColumnCount > 0)
                {
                    lockedColumnHeader.visible = true;
                    hcx = viewMetrics.left + Math.min(DataGridHeader(lockedColumnHeader).leftOffset, 0);
                    lockedColumnHeader.move(hcx, viewMetrics.top);
                    hh = lockedColumnHeader.getExplicitOrMeasuredHeight();
                    lockedColumnHeader.setActualSize((lockedColumnWidth + 1), hh);
                    DataGridHeader(lockedColumnHeader).needRightSeparator = true;
                    DataGridHeader(lockedColumnHeader).needRightSeparatorEvents = true;
                }
                header.visible = true;
                hcx = viewMetrics.left + lockedColumnWidth + Math.min(DataGridHeader(header).leftOffset, 0);
                header.move(hcx, viewMetrics.top);
                if (verticalScrollBar != null && verticalScrollBar.visible && (horizontalScrollBar == null || !horizontalScrollBar.visible) && headerVisible && roomForScrollBar(verticalScrollBar, unscaledWidth, unscaledHeight - header.height))
                {
                    ww = Math.max(0, DataGridHeader(header).rightOffset) - hcx - borderMetrics.right;
                }
                else
                {
                    ww = Math.max(0, DataGridHeader(header).rightOffset) - hcx - viewMetrics.right;
                }
                hh = header.getExplicitOrMeasuredHeight();
                header.setActualSize(unscaledWidth + ww, hh);
                if (!skipHeaderUpdate)
                {
                    header.headerItemsChanged = true;
                    header.invalidateDisplayList();
                }
            }
            else
            {
                header.visible = false;
                if (lockedColumnCount > 0)
                {
                    lockedColumnHeader.visible = false;
                }
            }
            if (lockedRowCount > 0 && lockedRowContent && lockedRowContent.iterator)
            {
                try
                {
                    lockedRowContent.iterator.seek(CursorBookmark.FIRST);
                    pt = makeRows(lockedRowContent, 0, 0, unscaledWidth, unscaledHeight, 0, 0, true, lockedRowCount, true);
                    if (lockedColumnCount > 0)
                    {
                        lcx = viewMetrics.left + Math.min(lockedColumnAndRowContent.leftOffset, 0);
                        lcy = viewMetrics.top + Math.min(lockedColumnAndRowContent.topOffset, 0) + Math.ceil(hh);
                        lockedColumnAndRowContent.move(lcx, lcy);
                        lockedColumnAndRowContent.setActualSize(lockedColumnWidth, lockedColumnAndRowContent.getExplicitOrMeasuredHeight());
                    }
                    lcx = viewMetrics.left + lockedColumnWidth + Math.min(lockedRowContent.leftOffset, 0);
                    lcy = viewMetrics.top + Math.min(lockedRowContent.topOffset, 0) + Math.ceil(hh);
                    lockedRowContent.move(lcx, lcy);
                    ww = Math.max(0, lockedRowContent.rightOffset) - lcx - viewMetrics.right;
                    lockedRowContent.setActualSize(unscaledWidth + ww, lockedRowContent.getExplicitOrMeasuredHeight());
                    hh = hh + lockedRowContent.getExplicitOrMeasuredHeight();
                }
                catch (e:ItemPendingError)
                {
                    e.addResponder(new ItemResponder(lockedRowSeekPendingResultHandler, seekPendingFailureHandler, null));
                }
            }
            if (lockedColumnCount > 0)
            {
                lcx = viewMetrics.left + Math.min(lockedColumnContent.leftOffset, 0);
                lcy = viewMetrics.top + Math.min(lockedColumnContent.topOffset, 0) + Math.ceil(hh);
                lockedColumnContent.move(lcx, lcy);
                ww = lockedColumnWidth + lockedColumnContent.rightOffset - lockedColumnContent.leftOffset;
                lockedColumnContent.setActualSize(ww, unscaledHeight + Math.max(0, lockedColumnContent.bottomOffset) - lcy - viewMetrics.bottom);
            }
            lcx = viewMetrics.left + lockedColumnWidth + Math.min(listContent.leftOffset, 0);
            lcy = viewMetrics.top + Math.min(listContent.topOffset, 0) + Math.ceil(hh);
            listContent.move(lcx, lcy);
            ww = Math.max(0, listContent.rightOffset) - lcx - viewMetrics.right;
            hh = Math.max(0, listContent.bottomOffset) - lcy - viewMetrics.bottom;
            listContent.setActualSize(Math.max(0, unscaledWidth + ww), Math.max(0, unscaledHeight + hh));
            return;
        }// end function

        function setupRendererFromData(param1:DataGridColumn, param2:IListItemRenderer, param3:Object) : void
        {
            var _loc_4:* = DataGridListData(makeListData(param3, itemToUID(param3), 0, param1.colNum, param1));
            if (param2 is IDropInListItemRenderer)
            {
                IDropInListItemRenderer(param2).listData = param3 ? (_loc_4) : (null);
            }
            param2.data = param3;
            param2.explicitWidth = getWidthOfItem(param2, param1);
            UIComponentGlobals.layoutManager.validateClient(param2, true);
            return;
        }// end function

        override public function get itemRenderer() : IFactory
        {
            var _loc_1:String = null;
            var _loc_2:String = null;
            var _loc_3:String = null;
            var _loc_4:Boolean = false;
            var _loc_5:Boolean = false;
            var _loc_6:IFlexModuleFactory = null;
            if (super.itemRenderer == null)
            {
                _loc_1 = StringUtil.trimArrayElements(getStyle("fontFamily"), ",");
                _loc_2 = getStyle("fontWeight");
                _loc_3 = getStyle("fontStyle");
                _loc_4 = _loc_2 == "bold";
                _loc_5 = _loc_3 == "italic";
                _loc_6 = getFontContext(_loc_1, _loc_4, _loc_5);
                super.itemRenderer = new ContextualClassFactory(DataGridItemRenderer, _loc_6);
            }
            return super.itemRenderer;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:Number = NaN;
            var _loc_4:EdgeMetrics = null;
            if (displayWidth != param1 - viewMetrics.right - viewMetrics.left)
            {
                displayWidth = param1 - viewMetrics.right - viewMetrics.left;
                columnsInvalid = true;
            }
            calculateColumnSizes();
            if (itemEditorPositionChanged)
            {
                itemEditorPositionChanged = false;
                if (!lastItemDown)
                {
                    scrollToEditedItem(editedItemPosition.rowIndex, editedItemPosition.colIndex);
                }
            }
            super.updateDisplayList(param1, param2);
            if (collection && collection.length)
            {
                setRowCount(listItems.length);
                if (listItems.length)
                {
                    setColumnCount(listItems[0].length);
                }
                else
                {
                    setColumnCount(0);
                }
            }
            if (verticalScrollBar != null && verticalScrollBar.visible && (horizontalScrollBar == null || !horizontalScrollBar.visible) && headerVisible)
            {
                _loc_3 = header.height;
                _loc_4 = borderMetrics;
                if (roomForScrollBar(verticalScrollBar, param1 - _loc_4.left - _loc_4.right, param2 - _loc_3 - _loc_4.top - _loc_4.bottom))
                {
                    verticalScrollBar.move(verticalScrollBar.x, viewMetrics.top + _loc_3);
                    verticalScrollBar.setActualSize(verticalScrollBar.width, param2 - viewMetrics.top - viewMetrics.bottom - _loc_3);
                    verticalScrollBar.visible = true;
                    headerMask.width = headerMask.width + verticalScrollBar.getExplicitOrMeasuredWidth();
                    if (!DataGridHeader(header).needRightSeparator)
                    {
                        header.invalidateDisplayList();
                        DataGridHeader(header).needRightSeparator = true;
                    }
                }
                else if (DataGridHeader(header).needRightSeparator)
                {
                    header.invalidateDisplayList();
                    DataGridHeader(header).needRightSeparator = false;
                }
            }
            else if (DataGridHeader(header).needRightSeparator)
            {
                header.invalidateDisplayList();
                DataGridHeader(header).needRightSeparator = false;
            }
            if (bEditedItemPositionChanged)
            {
                bEditedItemPositionChanged = false;
                if (!lastItemDown)
                {
                    commitEditedItemPosition(_proposedEditedItemPosition);
                }
                _proposedEditedItemPosition = undefined;
                itemsSizeChanged = false;
            }
            drawRowBackgrounds();
            drawLinesAndColumnBackgrounds();
            if (lockedRowCount && lockedRowContent)
            {
                drawRowGraphics(lockedRowContent);
                drawLinesAndColumnGraphics(lockedRowContent, visibleColumns, {bottom:1});
                if (lockedColumnCount)
                {
                    drawRowGraphics(lockedColumnAndRowContent);
                    drawLinesAndColumnGraphics(lockedColumnAndRowContent, visibleLockedColumns, {right:1, bottom:1});
                }
            }
            if (lockedColumnCount)
            {
                drawRowGraphics(lockedColumnContent);
                drawLinesAndColumnGraphics(lockedColumnContent, visibleLockedColumns, {right:1});
            }
            return;
        }// end function

        function shiftColumns(param1:int, param2:int, param3:Event = null) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:IndexChangedEvent = null;
            var _loc_7:int = 0;
            var _loc_8:DataGridColumn = null;
            if (param2 >= 0 && param1 != param2)
            {
                _loc_4 = param1 < param2 ? (1) : (-1);
                _loc_5 = param1;
                while (_loc_5 != param2)
                {
                    
                    _loc_7 = _loc_5 + _loc_4;
                    _loc_8 = _columns[_loc_5];
                    _columns[_loc_5] = _columns[_loc_7];
                    _columns[_loc_7] = _loc_8;
                    _columns[_loc_5].colNum = _loc_5;
                    _columns[_loc_7].colNum = _loc_7;
                    _loc_5 = _loc_5 + _loc_4;
                }
                if (sortIndex == param1)
                {
                    sortIndex = sortIndex + (param2 - param1);
                }
                else if (param1 < sortIndex && sortIndex <= param2 || param2 <= sortIndex && sortIndex < param1)
                {
                    sortIndex = sortIndex - _loc_4;
                }
                if (lastSortIndex == param1)
                {
                    lastSortIndex = lastSortIndex + (param2 - param1);
                }
                else if (param1 < lastSortIndex && lastSortIndex <= param2 || param2 <= lastSortIndex && lastSortIndex < param1)
                {
                    lastSortIndex = lastSortIndex - _loc_4;
                }
                columnsInvalid = true;
                itemsSizeChanged = true;
                invalidateDisplayList();
                if (lockedColumnHeader)
                {
                    lockedColumnHeader.invalidateDisplayList();
                }
                _loc_6 = new IndexChangedEvent(IndexChangedEvent.HEADER_SHIFT);
                _loc_6.oldIndex = param1;
                _loc_6.newIndex = param2;
                _loc_6.triggerEvent = param3;
                dispatchEvent(_loc_6);
            }
            return;
        }// end function

        override public function hideDropFeedback(event:DragEvent) : void
        {
            super.hideDropFeedback(event);
            if (lockedColumnDropIndicator)
            {
                DisplayObject(lockedColumnDropIndicator).parent.removeChild(DisplayObject(lockedColumnDropIndicator));
                lockedColumnDropIndicator = null;
            }
            return;
        }// end function

        override protected function dragStartHandler(event:DragEvent) : void
        {
            if (collectionUpdatesDisabled)
            {
                collection.enableAutoUpdate();
                collectionUpdatesDisabled = false;
            }
            super.dragStartHandler(event);
            return;
        }// end function

        protected function drawHeaderBackground(param1:UIComponent) : void
        {
            DataGridHeader(param1.parent)._drawHeaderBackground(param1);
            return;
        }// end function

    }
}
