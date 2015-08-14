package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.controls.listClasses.*;
    import mx.controls.scrollClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.styles.*;

    public class List extends ListBase implements IIMESupport
    {
        public var editorXOffset:Number = 0;
        public var itemEditorInstance:IListItemRenderer;
        public var rendererIsEditor:Boolean = false;
        private var dontEdit:Boolean = false;
        public var editorYOffset:Number = 0;
        public var editorWidthOffset:Number = 0;
        private var lastEditedItemPosition:Object;
        public var itemEditor:IFactory;
        public var editable:Boolean = false;
        private var losingFocus:Boolean = false;
        public var editorUsesEnterKey:Boolean = false;
        public var editorDataField:String = "text";
        private var bEditedItemPositionChanged:Boolean = false;
        var _lockedRowCount:int = 0;
        private var inEndEdit:Boolean = false;
        public var editorHeightOffset:Number = 0;
        private var _editedItemPosition:Object;
        private var _imeMode:String;
        private var actualRowIndex:int;
        private var _proposedEditedItemPosition:Object;
        private var actualColIndex:int = 0;
        protected var measuringObjects:Dictionary;
        static const VERSION:String = "3.5.0.12683";
        static var createAccessibilityImplementation:Function;

        public function List()
        {
            itemEditor = new ClassFactory(TextInput);
            listType = "vertical";
            bColumnScrolling = false;
            itemRenderer = new ClassFactory(ListItemRenderer);
            _horizontalScrollPolicy = ScrollPolicy.OFF;
            _verticalScrollPolicy = ScrollPolicy.AUTO;
            defaultColumnCount = 1;
            defaultRowCount = 7;
            addEventListener(ListEvent.ITEM_EDIT_BEGINNING, itemEditorItemEditBeginningHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(ListEvent.ITEM_EDIT_BEGIN, itemEditorItemEditBeginHandler, false, EventPriority.DEFAULT_HANDLER);
            addEventListener(ListEvent.ITEM_EDIT_END, itemEditorItemEditEndHandler, false, EventPriority.DEFAULT_HANDLER);
            return;
        }// end function

        override public function measureWidthOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var item:IListItemRenderer;
            var rw:Number;
            var data:Object;
            var factory:IFactory;
            var index:* = param1;
            var count:* = param2;
            if (count == 0)
            {
                count = collection ? (collection.length) : (0);
            }
            if (collection && collection.length == 0)
            {
                count;
            }
            var w:Number;
            var bookmark:* = iterator ? (iterator.bookmark) : (null);
            if (index != -1 && iterator)
            {
                try
                {
                    iterator.seek(CursorBookmark.FIRST, index);
                }
                catch (e:ItemPendingError)
                {
                    return 0;
                }
            }
            var more:* = iterator != null;
            var i:int;
            while (i < count)
            {
                
                if (more)
                {
                    data = iterator.current;
                    factory = getItemRendererFactory(data);
                    item = measuringObjects[factory];
                    if (!item)
                    {
                        item = getMeasuringRenderer(data);
                    }
                    item.explicitWidth = NaN;
                    setupRendererFromData(item, data);
                    rw = item.measuredWidth;
                    w = Math.max(w, rw);
                }
                if (more)
                {
                    try
                    {
                        more = iterator.moveNext();
                    }
                    catch (e:ItemPendingError)
                    {
                        more;
                    }
                }
                i = (i + 1);
            }
            if (iterator)
            {
                iterator.seek(bookmark, 0);
            }
            if (w == 0)
            {
                if (explicitWidth)
                {
                    return explicitWidth;
                }
                return DEFAULT_MEASURED_WIDTH;
            }
            var paddingLeft:* = getStyle("paddingLeft");
            var paddingRight:* = getStyle("paddingRight");
            w = w + (paddingLeft + paddingRight);
            return w;
        }// end function

        private function findNextEnterItemRenderer(event:KeyboardEvent) : void
        {
            if (_proposedEditedItemPosition !== undefined)
            {
                return;
            }
            _editedItemPosition = lastEditedItemPosition;
            var _loc_2:* = _editedItemPosition.rowIndex;
            var _loc_3:* = _editedItemPosition.columnIndex;
            var _loc_4:* = _editedItemPosition.rowIndex + (event.shiftKey ? (-1) : (1));
            if (_editedItemPosition.rowIndex + (event.shiftKey ? (-1) : (1)) < collection.length && _loc_4 >= 0)
            {
                _loc_2 = _loc_4;
            }
            var _loc_5:* = new ListEvent(ListEvent.ITEM_EDIT_BEGINNING, false, true);
            new ListEvent(ListEvent.ITEM_EDIT_BEGINNING, false, true).rowIndex = _loc_2;
            _loc_5.columnIndex = 0;
            dispatchEvent(_loc_5);
            return;
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

        public function set imeMode(param1:String) : void
        {
            _imeMode = param1;
            return;
        }// end function

        override protected function mouseUpHandler(event:MouseEvent) : void
        {
            var _loc_2:ListEvent = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Sprite = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:Point = null;
            _loc_3 = mouseEventToItemRenderer(event);
            super.mouseUpHandler(event);
            if (_loc_3 && _loc_3.mx.core:IDataRenderer::data && _loc_3 != itemEditorInstance)
            {
                _loc_7 = itemRendererToIndices(_loc_3);
                if (editable && !dontEdit)
                {
                    _loc_2 = new ListEvent(ListEvent.ITEM_EDIT_BEGINNING, false, true);
                    _loc_2.rowIndex = _loc_7.y;
                    _loc_2.columnIndex = 0;
                    _loc_2.itemRenderer = _loc_3;
                    dispatchEvent(_loc_2);
                }
            }
            return;
        }// end function

        private function itemEditorItemEditEndHandler(event:ListEvent) : void
        {
            var bChanged:Boolean;
            var bFieldChanged:Boolean;
            var newData:Object;
            var data:Object;
            var editCollection:IList;
            var listData:BaseListData;
            var fm:IFocusManager;
            var event:* = event;
            if (!event.isDefaultPrevented())
            {
                bChanged;
                bFieldChanged;
                newData = itemEditorInstance[editorDataField];
                data = event.itemRenderer.mx.core:IDataRenderer::data;
                if (data is String)
                {
                    if (!(newData is String))
                    {
                        newData = newData.toString();
                    }
                }
                else if (data is uint)
                {
                    if (!(newData is uint))
                    {
                        newData = uint(newData);
                    }
                }
                else if (data is int)
                {
                    if (!(newData is int))
                    {
                        newData = int(newData);
                    }
                }
                else if (data is Number)
                {
                    if (!(newData is int))
                    {
                        newData = Number(newData);
                    }
                }
                else
                {
                    bFieldChanged;
                    try
                    {
                        data[labelField] = newData;
                        if (!(data is IPropertyChangeNotifier))
                        {
                            if (actualCollection)
                            {
                                actualCollection.itemUpdated(data, labelField);
                            }
                            else
                            {
                                collection.itemUpdated(data, labelField);
                            }
                        }
                    }
                    catch (e:Error)
                    {
                        trace("attempt to write to", labelField, "failed.  You may need a custom ITEM_EDIT_END handler");
                    }
                }
                if (!bFieldChanged)
                {
                    if (data !== newData)
                    {
                        bChanged;
                        data = newData;
                    }
                    if (bChanged)
                    {
                        editCollection = actualCollection ? (actualCollection as IList) : (collection as IList);
                        if (editCollection)
                        {
                            IList(editCollection).setItemAt(data, event.rowIndex);
                        }
                        else
                        {
                            trace("attempt to update collection failed.  You may need a custom ITEM_EDIT_END handler");
                        }
                    }
                }
                if (event.itemRenderer is IDropInListItemRenderer)
                {
                    listData = BaseListData(IDropInListItemRenderer(event.itemRenderer).mx.controls.listClasses:IDropInListItemRenderer::listData);
                    listData.label = itemToLabel(data);
                    IDropInListItemRenderer(event.itemRenderer).mx.controls.listClasses:IDropInListItemRenderer::listData = listData;
                }
                delete visibleData[itemToUID(event.itemRenderer.mx.core:IDataRenderer::data)];
                event.itemRenderer.mx.core:IDataRenderer::data = data;
                visibleData[itemToUID(data)] = event.itemRenderer;
            }
            else if (event.reason != ListEventReason.OTHER)
            {
                if (itemEditorInstance && _editedItemPosition)
                {
                    if (selectedIndex != _editedItemPosition.rowIndex)
                    {
                        selectedIndex = _editedItemPosition.rowIndex;
                    }
                    fm = focusManager;
                    if (itemEditorInstance is IFocusManagerComponent)
                    {
                        fm.setFocus(IFocusManagerComponent(itemEditorInstance));
                    }
                }
            }
            if (event.reason == ListEventReason.OTHER || !event.isDefaultPrevented())
            {
                destroyItemEditor();
            }
            return;
        }// end function

        private function itemEditorItemEditBeginningHandler(event:ListEvent) : void
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

        override public function createItemRenderer(param1:Object) : IListItemRenderer
        {
            var _loc_2:IFactory = null;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Dictionary = null;
            var _loc_5:* = undefined;
            _loc_2 = getItemRendererFactory(param1);
            if (!_loc_2)
            {
                if (param1 == null)
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
                if (freeItemRenderers && freeItemRenderers.length)
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

        override protected function focusOutHandler(event:FocusEvent) : void
        {
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
                endEdit(ListEventReason.OTHER);
                removeEventListener(FocusEvent.KEY_FOCUS_CHANGE, keyFocusChangeHandler);
                removeEventListener(MouseEvent.MOUSE_DOWN, mouseFocusChangeHandler);
            }
            return;
        }// end function

        override protected function scrollHorizontally(param1:int, param2:int, param3:Boolean) : void
        {
            var _loc_4:* = listItems.length;
            var _loc_5:* = getStyle("paddingLeft");
            var _loc_6:int = 0;
            while (_loc_6 < _loc_4)
            {
                
                if (listItems[_loc_6].length)
                {
                    listItems[_loc_6][0].x = -param1 + _loc_5;
                }
                _loc_6++;
            }
            return;
        }// end function

        override protected function drawHighlightIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            super.drawHighlightIndicator(param1, 0, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
            return;
        }// end function

        public function get editedItemPosition() : Object
        {
            if (_editedItemPosition)
            {
                return {rowIndex:_editedItemPosition.rowIndex, columnIndex:0};
            }
            return _editedItemPosition;
        }// end function

        private function setEditedItemPosition(param1:Object) : void
        {
            bEditedItemPositionChanged = true;
            _proposedEditedItemPosition = param1;
            invalidateDisplayList();
            return;
        }// end function

        override protected function drawRowBackgrounds() : void
        {
            var _loc_2:Array = null;
            var _loc_6:int = 0;
            var _loc_1:* = Sprite(listContent.getChildByName("rowBGs"));
            if (!_loc_1)
            {
                _loc_1 = new FlexSprite();
                _loc_1.mouseEnabled = false;
                _loc_1.name = "rowBGs";
                listContent.addChildAt(_loc_1, 0);
            }
            _loc_2 = getStyle("alternatingItemColors");
            if (!_loc_2 || _loc_2.length == 0)
            {
                while (_loc_1.numChildren > _loc_6)
                {
                    
                    _loc_1.removeChildAt((_loc_1.numChildren - 1));
                }
                return;
            }
            StyleManager.getColorNames(_loc_2);
            var _loc_3:int = 0;
            var _loc_4:* = verticalScrollPosition;
            var _loc_5:int = 0;
            _loc_6 = listItems.length;
            while (_loc_3 < _loc_6)
            {
                
                drawRowBackground(_loc_1, _loc_5++, rowInfo[_loc_3].y, rowInfo[_loc_3].height, _loc_2[_loc_4 % _loc_2.length], _loc_4);
                _loc_3++;
                _loc_4++;
            }
            while (_loc_1.numChildren > _loc_6)
            {
                
                _loc_1.removeChildAt((_loc_1.numChildren - 1));
            }
            return;
        }// end function

        override protected function drawCaretIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            super.drawCaretIndicator(param1, 0, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
            return;
        }// end function

        private function deactivateHandler(event:Event) : void
        {
            if (itemEditorInstance)
            {
                endEdit(ListEventReason.OTHER);
                losingFocus = true;
                setFocus();
            }
            return;
        }// end function

        protected function layoutEditor(param1:int, param2:int, param3:int, param4:int) : void
        {
            itemEditorInstance.move(param1, param2);
            itemEditorInstance.setActualSize(param3, param4);
            return;
        }// end function

        private function editorKeyDownHandler(event:KeyboardEvent) : void
        {
            if (event.keyCode == Keyboard.ESCAPE)
            {
                endEdit(ListEventReason.CANCELLED);
            }
            else if (event.ctrlKey && event.charCode == 46)
            {
                endEdit(ListEventReason.CANCELLED);
            }
            else if (event.charCode == Keyboard.ENTER && event.keyCode != 229)
            {
                if (editorUsesEnterKey)
                {
                    return;
                }
                if (endEdit(ListEventReason.NEW_ROW))
                {
                    if (!dontEdit)
                    {
                        findNextEnterItemRenderer(event);
                    }
                }
            }
            return;
        }// end function

        private function itemEditorItemEditBeginHandler(event:ListEvent) : void
        {
            var _loc_2:IFocusManager = null;
            if (root)
            {
                systemManager.addEventListener(Event.DEACTIVATE, deactivateHandler, false, 0, true);
            }
            if (!event.isDefaultPrevented() && listItems[actualRowIndex][actualColIndex].data != null)
            {
                createItemEditor(event.columnIndex, event.rowIndex);
                if (editedItemRenderer is IDropInListItemRenderer && itemEditorInstance is IDropInListItemRenderer)
                {
                    IDropInListItemRenderer(itemEditorInstance).mx.controls.listClasses:IDropInListItemRenderer::listData = IDropInListItemRenderer(editedItemRenderer).mx.controls.listClasses:IDropInListItemRenderer::listData;
                }
                if (!rendererIsEditor)
                {
                    itemEditorInstance.mx.core:IDataRenderer::data = editedItemRenderer.mx.core:IDataRenderer::data;
                }
                if (itemEditorInstance is IInvalidating)
                {
                    IInvalidating(itemEditorInstance).validateNow();
                }
                if (itemEditorInstance is IIMESupport)
                {
                    IIMESupport(itemEditorInstance).imeMode = imeMode;
                }
                _loc_2 = focusManager;
                if (itemEditorInstance is IFocusManagerComponent)
                {
                    _loc_2.setFocus(IFocusManagerComponent(itemEditorInstance));
                }
                _loc_2.defaultButtonEnabled = false;
                event = new ListEvent(ListEvent.ITEM_FOCUS_IN);
                event.rowIndex = _editedItemPosition.rowIndex;
                event.itemRenderer = itemEditorInstance;
                dispatchEvent(event);
            }
            return;
        }// end function

        private function editingTemporarilyPrevented(param1:Object) : Boolean
        {
            var _loc_2:int = 0;
            var _loc_3:IListItemRenderer = null;
            if (runningDataEffect && param1)
            {
                _loc_2 = param1.rowIndex - verticalScrollPosition + offscreenExtraRowsTop;
                if (_loc_2 < 0 || _loc_2 >= listItems.length)
                {
                    return false;
                }
                _loc_3 = listItems[_loc_2][0];
                if (_loc_3 && (getRendererSemanticValue(_loc_3, "replaced") || getRendererSemanticValue(_loc_3, "removed")))
                {
                    return true;
                }
            }
            return false;
        }// end function

        override public function measureHeightOfItems(param1:int = -1, param2:int = 0) : Number
        {
            var data:Object;
            var item:IListItemRenderer;
            var index:* = param1;
            var count:* = param2;
            if (count == 0)
            {
                count = collection ? (collection.length) : (0);
            }
            var paddingTop:* = getStyle("paddingTop");
            var paddingBottom:* = getStyle("paddingBottom");
            var ww:Number;
            if (listContent.width)
            {
                ww = listContent.width;
            }
            var h:Number;
            var bookmark:* = iterator ? (iterator.bookmark) : (null);
            if (index != -1 && iterator)
            {
                iterator.seek(CursorBookmark.FIRST, index);
            }
            var rh:* = rowHeight;
            var more:* = iterator != null;
            var i:int;
            while (i < count)
            {
                
                if (more)
                {
                    rh = rowHeight;
                    data = iterator.current;
                    item = getMeasuringRenderer(data);
                    item.explicitWidth = ww;
                    setupRendererFromData(item, data);
                    if (variableRowHeight)
                    {
                        rh = item.getExplicitOrMeasuredHeight() + paddingTop + paddingBottom;
                    }
                }
                h = h + rh;
                if (more)
                {
                    try
                    {
                        more = iterator.moveNext();
                    }
                    catch (e:ItemPendingError)
                    {
                        more;
                    }
                }
                i = (i + 1);
            }
            if (iterator)
            {
                iterator.seek(bookmark, 0);
            }
            return h;
        }// end function

        function callSetupRendererFromData(param1:IListItemRenderer, param2:Object) : void
        {
            setupRendererFromData(param1, param2);
            return;
        }// end function

        override protected function drawSelectionIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            super.drawSelectionIndicator(param1, 0, param3, unscaledWidth - viewMetrics.left - viewMetrics.right, param5, param6, param7);
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

        public function set editedItemPosition(param1:Object) : void
        {
            var _loc_2:Object = {rowIndex:param1.rowIndex, columnIndex:0};
            setEditedItemPosition(_loc_2);
            return;
        }// end function

        override protected function makeRowsAndColumns(param1:Number, param2:Number, param3:Number, param4:Number, param5:int, param6:int, param7:Boolean = false, param8:uint = 0) : Point
        {
            var yy:Number;
            var hh:Number;
            var i:int;
            var j:int;
            var item:IListItemRenderer;
            var oldItem:IListItemRenderer;
            var rowData:BaseListData;
            var data:Object;
            var wrappedData:Object;
            var uid:String;
            var rh:Number;
            var ld:BaseListData;
            var rr:Array;
            var rowInfo:ListRowInfo;
            var dx:Number;
            var dy:Number;
            var dw:Number;
            var dh:Number;
            var left:* = param1;
            var top:* = param2;
            var right:* = param3;
            var bottom:* = param4;
            var firstCol:* = param5;
            var firstRow:* = param6;
            var byCount:* = param7;
            var rowsNeeded:* = param8;
            listContent.allowItemSizeChangeNotification = false;
            var paddingLeft:* = getStyle("paddingLeft");
            var paddingRight:* = getStyle("paddingRight");
            var xx:* = left + paddingLeft - horizontalScrollPosition;
            var ww:* = right - paddingLeft - paddingRight;
            var bSelected:Boolean;
            var bHighlight:Boolean;
            var bCaret:Boolean;
            var colNum:int;
            var rowNum:* = lockedRowCount;
            var rowsMade:int;
            var more:Boolean;
            var valid:Boolean;
            yy = top;
            rowNum = firstRow;
            more = iterator != null && !iterator.afterLast && iteratorValid;
            do
            {
                
                if (byCount)
                {
                    rowsNeeded = (rowsNeeded - 1);
                }
                valid = more;
                wrappedData = more ? (iterator.current) : (null);
                data = wrappedData is ItemWrapper ? (wrappedData.data) : (wrappedData);
                uid;
                if (!listItems[rowNum])
                {
                    listItems[rowNum] = [];
                }
                if (valid)
                {
                    item = listItems[rowNum][colNum];
                    uid = itemToUID(wrappedData);
                    if (!item || (runningDataEffect && dataItemWrappersByRenderer[item] ? (dataItemWrappersByRenderer[item] != wrappedData) : (item.mx.core:IDataRenderer::data != data)))
                    {
                        if (allowRendererStealingDuringLayout)
                        {
                            item = visibleData[uid];
                            if (!item && wrappedData != data)
                            {
                                item = visibleData[itemToUID(data)];
                            }
                        }
                        if (item)
                        {
                            ld = BaseListData(rowMap[item.name]);
                            if (ld && ld.rowIndex > rowNum)
                            {
                                listItems[ld.rowIndex] = [];
                            }
                            else
                            {
                                item;
                            }
                        }
                        if (!item)
                        {
                            item = getReservedOrFreeItemRenderer(wrappedData);
                        }
                        if (!item)
                        {
                            item = createItemRenderer(data);
                            item.owner = this;
                            item.styleName = listContent;
                            listContent.addChild(DisplayObject(item));
                        }
                        oldItem = listItems[rowNum][colNum];
                        if (oldItem)
                        {
                            addToFreeItemRenderers(oldItem);
                        }
                        listItems[rowNum][colNum] = item;
                    }
                    rowData = makeListData(data, uid, rowNum);
                    rowMap[item.name] = rowData;
                    if (item is IDropInListItemRenderer)
                    {
                        if (data != null)
                        {
                            IDropInListItemRenderer(item).mx.controls.listClasses:IDropInListItemRenderer::listData = rowData;
                        }
                        else
                        {
                            IDropInListItemRenderer(item).mx.controls.listClasses:IDropInListItemRenderer::listData = null;
                        }
                    }
                    item.mx.core:IDataRenderer::data = data;
                    item.enabled = enabled;
                    item.visible = true;
                    if (uid != null)
                    {
                        visibleData[uid] = item;
                    }
                    if (wrappedData != data)
                    {
                        dataItemWrappersByRenderer[item] = wrappedData;
                    }
                    item.explicitWidth = ww;
                    if (item is IInvalidating && (wordWrapChanged || variableRowHeight))
                    {
                        IInvalidating(item).invalidateSize();
                    }
                    UIComponentGlobals.layoutManager.validateClient(item, true);
                    hh = Math.ceil(variableRowHeight ? (item.getExplicitOrMeasuredHeight() + cachedPaddingTop + cachedPaddingBottom) : (rowHeight));
                    rh = item.getExplicitOrMeasuredHeight();
                    item.setActualSize(ww, variableRowHeight ? (rh) : (rowHeight - cachedPaddingTop - cachedPaddingBottom));
                    item.move(xx, yy + cachedPaddingTop);
                }
                else
                {
                    hh = rowNum > 0 ? (rowInfo[(rowNum - 1)].height) : (rowHeight);
                    if (hh == 0)
                    {
                        hh = rowHeight;
                    }
                    oldItem = listItems[rowNum][colNum];
                    if (oldItem)
                    {
                        addToFreeItemRenderers(oldItem);
                        listItems[rowNum].splice(colNum, 1);
                    }
                }
                bSelected = selectedData[uid] != null;
                if (wrappedData != data)
                {
                    bSelected = bSelected || selectedData[itemToUID(data)];
                    bSelected = bSelected && !getRendererSemanticValue(item, ModifiedCollectionView.REPLACEMENT) && !getRendererSemanticValue(item, ModifiedCollectionView.ADDED);
                }
                bHighlight = highlightUID == uid;
                bCaret = caretUID == uid;
                rowInfo[rowNum] = new ListRowInfo(yy, hh, uid, data);
                if (valid)
                {
                    drawItem(item, bSelected, bHighlight, bCaret);
                }
                yy = yy + hh;
                rowNum = (rowNum + 1);
                rowsMade = (rowsMade + 1);
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
            }while (!byCount && yy < bottom || byCount && rowsNeeded > 0)
            if (!byCount)
            {
                while (rowNum < listItems.length)
                {
                    
                    rr = listItems.pop();
                    rowInfo.pop();
                    while (rr.length)
                    {
                        
                        item = rr.pop();
                        addToFreeItemRenderers(item);
                    }
                }
            }
            if (itemEditorInstance)
            {
                listContent.setChildIndex(DisplayObject(itemEditorInstance), (listContent.numChildren - 1));
                item = listItems[actualRowIndex][actualColIndex];
                rowInfo = rowInfo[actualRowIndex];
                if (item && !rendererIsEditor)
                {
                    dx = editorXOffset;
                    dy = editorYOffset;
                    dw = editorWidthOffset;
                    dh = editorHeightOffset;
                    layoutEditor(item.x + dx, rowInfo.y + dy, Math.min(item.width + dw, listContent.width - listContent.x - itemEditorInstance.x), Math.min(rowInfo.height + dh, listContent.height - listContent.y - itemEditorInstance.y));
                }
            }
            listContent.allowItemSizeChangeNotification = variableRowHeight;
            return new Point(colNum, rowsMade);
        }// end function

        override protected function measure() : void
        {
            super.measure();
            var _loc_1:* = viewMetrics;
            measuredMinWidth = DEFAULT_MEASURED_MIN_WIDTH;
            if (initialized && variableRowHeight && explicitRowCount < 1 && isNaN(explicitRowHeight))
            {
                measuredHeight = height;
            }
            return;
        }// end function

        private function findNextItemRenderer(param1:Boolean) : Boolean
        {
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
            var _loc_4:* = _editedItemPosition.rowIndex + (param1 ? (-1) : (1));
            if (_editedItemPosition.rowIndex + (param1 ? (-1) : (1)) < collection.length && _loc_4 >= 0)
            {
                _loc_2 = _loc_4;
            }
            else
            {
                setEditedItemPosition(null);
                losingFocus = true;
                setFocus();
                return false;
            }
            var _loc_5:* = new ListEvent(ListEvent.ITEM_EDIT_BEGINNING, false, true);
            new ListEvent(ListEvent.ITEM_EDIT_BEGINNING, false, true).rowIndex = _loc_2;
            _loc_5.columnIndex = _loc_3;
            dispatchEvent(_loc_5);
            return true;
        }// end function

        override protected function mouseDownHandler(event:MouseEvent) : void
        {
            var _loc_2:IListItemRenderer = null;
            var _loc_3:Sprite = null;
            var _loc_5:Point = null;
            var _loc_6:Boolean = false;
            _loc_2 = mouseEventToItemRenderer(event);
            var _loc_4:* = itemRendererContains(itemEditorInstance, DisplayObject(event.target));
            if (!itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                if (_loc_2 && _loc_2.mx.core:IDataRenderer::data)
                {
                    _loc_5 = itemRendererToIndices(_loc_2);
                    _loc_6 = true;
                    if (itemEditorInstance)
                    {
                        _loc_6 = endEdit(ListEventReason.NEW_ROW);
                    }
                    if (!_loc_6)
                    {
                        return;
                    }
                }
                else if (itemEditorInstance)
                {
                    endEdit(ListEventReason.OTHER);
                }
                super.mouseDownHandler(event);
            }
            return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            if (itemEditorInstance)
            {
                return;
            }
            super.keyDownHandler(event);
            return;
        }// end function

        override protected function focusInHandler(event:FocusEvent) : void
        {
            var _loc_2:Boolean = false;
            if (event.target != this)
            {
                return;
            }
            if (losingFocus)
            {
                losingFocus = false;
                return;
            }
            super.focusInHandler(event);
            if (editable && !isPressed)
            {
                _editedItemPosition = lastEditedItemPosition;
                _loc_2 = editedItemPosition != null;
                if (!_editedItemPosition)
                {
                    _editedItemPosition = {rowIndex:0, columnIndex:0};
                    _loc_2 = listItems.length && listItems[0].length > 0;
                }
                if (_loc_2)
                {
                    setEditedItemPosition(_editedItemPosition);
                }
            }
            if (editable)
            {
                addEventListener(FocusEvent.KEY_FOCUS_CHANGE, keyFocusChangeHandler);
                addEventListener(MouseEvent.MOUSE_DOWN, mouseFocusChangeHandler);
            }
            return;
        }// end function

        override protected function mouseEventToItemRenderer(event:MouseEvent) : IListItemRenderer
        {
            var _loc_2:* = super.mouseEventToItemRenderer(event);
            return _loc_2 == itemEditorInstance ? (null) : (_loc_2);
        }// end function

        protected function makeListData(param1:Object, param2:String, param3:int) : BaseListData
        {
            return new ListData(itemToLabel(param1), itemToIcon(param1), labelField, param2, this, param3);
        }// end function

        public function createItemEditor(param1:int, param2:int) : void
        {
            var _loc_5:Number = NaN;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            param1 = 0;
            if (param2 > lockedRowCount)
            {
                param2 = param2 - verticalScrollPosition;
            }
            var _loc_3:* = listItems[param2][param1];
            var _loc_4:* = rowInfo[param2];
            if (!rendererIsEditor)
            {
                _loc_5 = 0;
                _loc_6 = -2;
                _loc_7 = 0;
                _loc_8 = 4;
                if (!itemEditorInstance)
                {
                    _loc_5 = editorXOffset;
                    _loc_6 = editorYOffset;
                    _loc_7 = editorWidthOffset;
                    _loc_8 = editorHeightOffset;
                    itemEditorInstance = itemEditor.newInstance();
                    itemEditorInstance.owner = this;
                    itemEditorInstance.styleName = this;
                    listContent.addChild(DisplayObject(itemEditorInstance));
                }
                listContent.setChildIndex(DisplayObject(itemEditorInstance), (listContent.numChildren - 1));
                itemEditorInstance.visible = true;
                layoutEditor(_loc_3.x + _loc_5, _loc_4.y + _loc_6, Math.min(_loc_3.width + _loc_7, listContent.width - listContent.x - itemEditorInstance.x), Math.min(_loc_4.height + _loc_8, listContent.height - listContent.y - itemEditorInstance.y));
                DisplayObject(itemEditorInstance).addEventListener("focusOut", itemEditorFocusOutHandler);
            }
            else
            {
                itemEditorInstance = _loc_3;
            }
            DisplayObject(itemEditorInstance).addEventListener(KeyboardEvent.KEY_DOWN, editorKeyDownHandler);
            systemManager.getSandboxRoot().addEventListener(MouseEvent.MOUSE_DOWN, editorMouseDownHandler, true, 0, true);
            systemManager.getSandboxRoot().addEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, editorMouseDownHandler, false, 0, true);
            return;
        }// end function

        public function get lockedRowCount() : int
        {
            return _lockedRowCount;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            super.enabled = param1;
            if (itemEditorInstance)
            {
                endEdit(ListEventReason.OTHER);
            }
            invalidateDisplayList();
            return;
        }// end function

        protected function endEdit(param1:String) : Boolean
        {
            if (!editedItemRenderer)
            {
                return true;
            }
            inEndEdit = true;
            var _loc_2:* = new ListEvent(ListEvent.ITEM_EDIT_END, false, true);
            _loc_2.rowIndex = editedItemPosition.rowIndex;
            _loc_2.itemRenderer = editedItemRenderer;
            _loc_2.reason = param1;
            dispatchEvent(_loc_2);
            dontEdit = itemEditorInstance != null;
            if (!dontEdit && param1 == ListEventReason.CANCELLED)
            {
                losingFocus = true;
                setFocus();
            }
            inEndEdit = false;
            return !_loc_2.isDefaultPrevented();
        }// end function

        override protected function collectionChangeHandler(event:Event) : void
        {
            var _loc_2:CollectionEvent = null;
            if (event is CollectionEvent)
            {
                _loc_2 = CollectionEvent(event);
                if (_loc_2.kind == CollectionEventKind.REMOVE)
                {
                    if (editedItemPosition)
                    {
                        if (collection.length == 0)
                        {
                            if (itemEditorInstance)
                            {
                                endEdit(ListEventReason.CANCELLED);
                            }
                            setEditedItemPosition(null);
                        }
                        else if (_loc_2.location <= editedItemPosition.rowIndex)
                        {
                            if (inEndEdit)
                            {
                                _editedItemPosition = {columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex - _loc_2.items.length)};
                            }
                            else
                            {
                                setEditedItemPosition({columnIndex:editedItemPosition.columnIndex, rowIndex:Math.max(0, editedItemPosition.rowIndex - _loc_2.items.length)});
                            }
                        }
                    }
                }
            }
            super.collectionChangeHandler(event);
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                if (listItems.length && listItems[0].length)
                {
                    return borderMetrics.top + cachedPaddingTop + listItems[0][0].baselinePosition;
                }
                return NaN;
            }
            return super.baselinePosition;
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
                endEdit(ListEventReason.OTHER);
            }
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            if (itemEditorInstance)
            {
                endEdit(ListEventReason.OTHER);
            }
            super.dataProvider = param1;
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

        override protected function configureScrollBars() : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:int = 0;
            var _loc_1:* = listItems.length;
            if (_loc_1 == 0)
            {
                return;
            }
            var _loc_4:* = listItems.length;
            while (_loc_1 > 1 && rowInfo[(_loc_4 - 1)].y + rowInfo[(_loc_4 - 1)].height > listContent.height - listContent.bottomOffset)
            {
                
                _loc_1 = _loc_1 - 1;
                _loc_4 = _loc_4 - 1;
            }
            var _loc_5:* = verticalScrollPosition - lockedRowCount - 1;
            var _loc_6:int = 0;
            while (_loc_1 && listItems[(_loc_1 - 1)].length == 0)
            {
                
                if (collection && _loc_1 + _loc_5 >= collection.length)
                {
                    _loc_1 = _loc_1 - 1;
                    _loc_6++;
                    continue;
                }
                break;
            }
            if (verticalScrollPosition > 0 && _loc_6 > 0 && !runningDataEffect)
            {
                if (adjustVerticalScrollPositionDownward(Math.max(_loc_1, 1)))
                {
                    return;
                }
            }
            if (listContent.topOffset)
            {
                _loc_2 = Math.abs(listContent.topOffset);
                _loc_3 = 0;
                while (rowInfo[_loc_3].y + rowInfo[_loc_3].height <= _loc_2)
                {
                    
                    _loc_1 = _loc_1 - 1;
                    _loc_3++;
                    if (_loc_3 == _loc_1)
                    {
                        break;
                    }
                }
            }
            var _loc_7:* = listItems[0].length;
            var _loc_8:* = horizontalScrollBar;
            var _loc_9:* = verticalScrollBar;
            var _loc_10:* = Math.round(unscaledWidth);
            var _loc_11:* = collection ? (collection.length - lockedRowCount) : (0);
            var _loc_12:* = _loc_1 - lockedRowCount;
            setScrollBarProperties(isNaN(_maxHorizontalScrollPosition) ? (Math.round(listContent.width)) : (Math.round(_maxHorizontalScrollPosition + _loc_10)), _loc_10, _loc_11, _loc_12);
            maxVerticalScrollPosition = Math.max(_loc_11 - _loc_12, 0);
            return;
        }// end function

        override protected function mouseWheelHandler(event:MouseEvent) : void
        {
            if (itemEditorInstance)
            {
                endEdit(ListEventReason.OTHER);
            }
            super.mouseWheelHandler(event);
            return;
        }// end function

        override public function set maxHorizontalScrollPosition(param1:Number) : void
        {
            super.maxHorizontalScrollPosition = param1;
            scrollAreaChanged = true;
            invalidateDisplayList();
            return;
        }// end function

        override protected function scrollHandler(event:Event) : void
        {
            var scrollBar:ScrollBar;
            var pos:Number;
            var delta:int;
            var o:EdgeMetrics;
            var bookmark:CursorBookmark;
            var event:* = event;
            if (event is ScrollEvent)
            {
                if (itemEditorInstance)
                {
                    endEdit(ListEventReason.OTHER);
                }
                if (!liveScrolling && ScrollEvent(event).detail == ScrollEventDetail.THUMB_TRACK)
                {
                    return;
                }
                scrollBar = ScrollBar(event.target);
                pos = scrollBar.scrollPosition;
                removeClipMask();
                if (scrollBar == verticalScrollBar)
                {
                    delta = pos - verticalScrollPosition;
                    super.scrollHandler(event);
                    if (Math.abs(delta) >= listItems.length - lockedRowCount || !iteratorValid)
                    {
                        try
                        {
                            if (!iteratorValid)
                            {
                                iterator.seek(CursorBookmark.FIRST, pos);
                            }
                            else
                            {
                                iterator.seek(CursorBookmark.CURRENT, delta);
                            }
                            if (!iteratorValid)
                            {
                                iteratorValid = true;
                                lastSeekPending = null;
                            }
                        }
                        catch (e:ItemPendingError)
                        {
                            lastSeekPending = new ListBaseSeekPending(CursorBookmark.FIRST, pos);
                            e.addResponder(new ItemResponder(seekPendingResultHandler, seekPendingFailureHandler, lastSeekPending));
                            iteratorValid = false;
                        }
                        bookmark = iterator.bookmark;
                        clearIndicators();
                        clearVisibleData();
                        makeRowsAndColumns(0, 0, listContent.width, listContent.height, 0, 0);
                        iterator.seek(bookmark, 0);
                    }
                    else if (delta != 0)
                    {
                        scrollVertically(pos, Math.abs(delta), Boolean(delta > 0));
                    }
                    if (variableRowHeight)
                    {
                        configureScrollBars();
                    }
                    drawRowBackgrounds();
                }
                else
                {
                    delta = pos - _horizontalScrollPosition;
                    super.scrollHandler(event);
                    scrollHorizontally(pos, Math.abs(delta), Boolean(delta > 0));
                }
                addClipMask(false);
            }
            return;
        }// end function

        public function get editedItemRenderer() : IListItemRenderer
        {
            if (!itemEditorInstance)
            {
                return null;
            }
            return listItems[actualRowIndex][actualColIndex];
        }// end function

        private function commitEditedItemPosition(param1:Object) : void
        {
            var _loc_10:String = null;
            if (!enabled || !editable)
            {
                return;
            }
            if (itemEditorInstance && param1 && itemEditorInstance is IFocusManagerComponent && _editedItemPosition.rowIndex == param1.rowIndex)
            {
                IFocusManagerComponent(itemEditorInstance).mx.managers:IFocusManagerComponent::setFocus();
                return;
            }
            if (itemEditorInstance)
            {
                if (!param1)
                {
                    _loc_10 = ListEventReason.OTHER;
                }
                else
                {
                    _loc_10 = ListEventReason.NEW_ROW;
                }
                if (!endEdit(_loc_10) && _loc_10 != ListEventReason.OTHER)
                {
                    return;
                }
            }
            _editedItemPosition = param1;
            if (!param1 || dontEdit)
            {
                return;
            }
            var _loc_2:* = param1.rowIndex;
            var _loc_3:* = param1.columnIndex;
            if (selectedIndex != param1.rowIndex)
            {
                commitSelectedIndex(param1.rowIndex);
            }
            var _loc_4:* = lockedRowCount;
            var _loc_5:* = verticalScrollPosition + listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom - 1;
            var _loc_6:* = rowInfo[listItems.length - offscreenExtraRowsBottom - 1].y + rowInfo[listItems.length - offscreenExtraRowsBottom - 1].height > listContent.height ? (1) : (0);
            if (_loc_2 > _loc_4)
            {
                if (_loc_2 < verticalScrollPosition + _loc_4)
                {
                    verticalScrollPosition = _loc_2 - _loc_4;
                }
                else
                {
                    while (_loc_2 > _loc_5 || _loc_2 == _loc_5 && _loc_2 > verticalScrollPosition + _loc_4 && _loc_6)
                    {
                        
                        if (verticalScrollPosition == maxVerticalScrollPosition)
                        {
                            break;
                        }
                        verticalScrollPosition = Math.min(verticalScrollPosition + (_loc_2 > _loc_5 ? (_loc_2 - _loc_5) : (_loc_6)), maxVerticalScrollPosition);
                        _loc_5 = verticalScrollPosition + listItems.length - offscreenExtraRowsTop - offscreenExtraRowsBottom - 1;
                        _loc_6 = rowInfo[listItems.length - offscreenExtraRowsBottom - 1].y + rowInfo[listItems.length - offscreenExtraRowsBottom - 1].height > listContent.height ? (1) : (0);
                    }
                }
                actualRowIndex = _loc_2 - verticalScrollPosition;
            }
            else
            {
                if (_loc_2 == _loc_4)
                {
                    verticalScrollPosition = 0;
                }
                actualRowIndex = _loc_2;
            }
            var _loc_7:* = borderMetrics;
            actualColIndex = _loc_3;
            var _loc_8:* = listItems[actualRowIndex][actualColIndex];
            if (!listItems[actualRowIndex][actualColIndex])
            {
                commitEditedItemPosition(null);
                return;
            }
            if (!isItemEditable(_loc_8.mx.core:IDataRenderer::data))
            {
                commitEditedItemPosition(null);
                return;
            }
            var _loc_9:* = new ListEvent(ListEvent.ITEM_EDIT_BEGIN, false, true);
            new ListEvent(ListEvent.ITEM_EDIT_BEGIN, false, true).rowIndex = _editedItemPosition.rowIndex;
            _loc_9.itemRenderer = _loc_8;
            dispatchEvent(_loc_9);
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

        protected function drawRowBackground(param1:Sprite, param2:int, param3:Number, param4:Number, param5:uint, param6:int) : void
        {
            var _loc_7:Shape = null;
            if (param2 < param1.numChildren)
            {
                _loc_7 = Shape(param1.getChildAt(param2));
            }
            else
            {
                _loc_7 = new FlexShape();
                _loc_7.name = "rowBackground";
                param1.addChild(_loc_7);
            }
            param4 = Math.min(rowInfo[param2].height, listContent.height - rowInfo[param2].y);
            _loc_7.y = rowInfo[param2].y;
            var _loc_8:* = _loc_7.graphics;
            _loc_7.graphics.clear();
            _loc_8.beginFill(param5, getStyle("backgroundAlpha"));
            _loc_8.drawRect(0, 0, listContent.width, param4);
            _loc_8.endFill();
            return;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:Number = NaN;
            var _loc_3:IListItemRenderer = null;
            var _loc_4:Number = NaN;
            var _loc_5:int = 0;
            super.commitProperties();
            if (itemsNeedMeasurement)
            {
                itemsNeedMeasurement = false;
                if (isNaN(explicitRowHeight))
                {
                    if (iterator)
                    {
                        _loc_1 = getStyle("paddingTop");
                        _loc_2 = getStyle("paddingBottom");
                        _loc_3 = getMeasuringRenderer(iterator.current);
                        _loc_4 = 200;
                        if (listContent.width)
                        {
                            _loc_4 = listContent.width;
                        }
                        _loc_3.explicitWidth = _loc_4;
                        setupRendererFromData(_loc_3, iterator.current);
                        _loc_5 = _loc_3.getExplicitOrMeasuredHeight() + _loc_1 + _loc_2;
                        setRowHeight(Math.max(_loc_5, 20));
                    }
                    else
                    {
                        setRowHeight(20);
                    }
                }
                if (isNaN(explicitColumnWidth))
                {
                    setColumnWidth(measureWidthOfItems(0, explicitRowCount < 1 ? (defaultRowCount) : (explicitRowCount)));
                }
            }
            return;
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

        private function adjustVerticalScrollPositionDownward(param1:int) : Boolean
        {
            var n:int;
            var j:int;
            var more:Boolean;
            var data:Object;
            var rowCount:* = param1;
            var bookmark:* = iterator.bookmark;
            var h:Number;
            var ch:Number;
            var paddingTop:* = getStyle("paddingTop");
            var paddingBottom:* = getStyle("paddingBottom");
            var paddingLeft:* = getStyle("paddingLeft");
            var paddingRight:* = getStyle("paddingRight");
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
                    more = iterator.movePrevious();
                }
            }
            catch (e:ItemPendingError)
            {
                more;
            }
            if (!more)
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
            var item:* = getMeasuringRenderer(iterator.current);
            item.explicitWidth = listContent.width - paddingLeft - paddingRight;
            do
            {
                
                if (more)
                {
                    data = iterator.current;
                    setupRendererFromData(item, data);
                    ch = variableRowHeight ? (item.getExplicitOrMeasuredHeight() + paddingBottom + paddingTop) : (rowHeight);
                }
                h = h - ch;
                try
                {
                    more = iterator.movePrevious();
                    numRows = (numRows + 1);
                }
                catch (e:ItemPendingError)
                {
                    more;
                }
            }while (h > 0 && more)
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

        public function isItemEditable(param1:Object) : Boolean
        {
            if (!editable)
            {
                return false;
            }
            if (param1 == null)
            {
                return false;
            }
            return true;
        }// end function

        override protected function adjustListContent(param1:Number = -1, param2:Number = -1) : void
        {
            var _loc_3:* = viewMetrics.left + Math.max(listContent.leftOffset, 0);
            var _loc_4:* = viewMetrics.top + listContent.topOffset;
            listContent.move(_loc_3, _loc_4);
            var _loc_5:* = Math.max(0, listContent.rightOffset) - _loc_3 - viewMetrics.right;
            var _loc_6:* = Math.max(0, listContent.bottomOffset) - _loc_4 - viewMetrics.bottom;
            var _loc_7:* = param1 + _loc_5;
            if (horizontalScrollPolicy == ScrollPolicy.ON || horizontalScrollPolicy == ScrollPolicy.AUTO && !isNaN(_maxHorizontalScrollPosition))
            {
                if (isNaN(_maxHorizontalScrollPosition))
                {
                    _loc_7 = _loc_7 * 2;
                }
                else
                {
                    _loc_7 = _loc_7 + _maxHorizontalScrollPosition;
                }
            }
            listContent.setActualSize(_loc_7, param2 + _loc_6);
            return;
        }// end function

        private function editorMouseDownHandler(event:Event) : void
        {
            if (event is MouseEvent && itemRendererContains(itemEditorInstance, DisplayObject(event.target)))
            {
                return;
            }
            endEdit(ListEventReason.OTHER);
            return;
        }// end function

        override public function set itemRenderer(param1:IFactory) : void
        {
            super.itemRenderer = param1;
            purgeMeasuringRenderers();
            return;
        }// end function

        function setupRendererFromData(param1:IListItemRenderer, param2:Object) : void
        {
            var _loc_3:* = param2 is ItemWrapper ? (param2.data) : (param2);
            if (param1 is IDropInListItemRenderer)
            {
                if (_loc_3 != null)
                {
                    IDropInListItemRenderer(param1).mx.controls.listClasses:IDropInListItemRenderer::listData = makeListData(_loc_3, itemToUID(param2), 0);
                }
                else
                {
                    IDropInListItemRenderer(param1).mx.controls.listClasses:IDropInListItemRenderer::listData = null;
                }
            }
            param1.mx.core:IDataRenderer::data = _loc_3;
            if (param1 is IInvalidating)
            {
                IInvalidating(param1).invalidateSize();
            }
            UIComponentGlobals.layoutManager.validateClient(param1, true);
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            setRowCount(listItems.length);
            if (bEditedItemPositionChanged && !editingTemporarilyPrevented(_proposedEditedItemPosition))
            {
                bEditedItemPositionChanged = false;
                commitEditedItemPosition(_proposedEditedItemPosition);
                _proposedEditedItemPosition = undefined;
            }
            drawRowBackgrounds();
            return;
        }// end function

        public function destroyItemEditor() : void
        {
            var _loc_1:ListEvent = null;
            if (itemEditorInstance)
            {
                DisplayObject(itemEditorInstance).removeEventListener(KeyboardEvent.KEY_DOWN, editorKeyDownHandler);
                systemManager.getSandboxRoot().removeEventListener(MouseEvent.MOUSE_DOWN, editorMouseDownHandler, true);
                systemManager.getSandboxRoot().removeEventListener(SandboxMouseEvent.MOUSE_DOWN_SOMEWHERE, editorMouseDownHandler);
                _loc_1 = new ListEvent(ListEvent.ITEM_FOCUS_OUT);
                _loc_1.rowIndex = _editedItemPosition.rowIndex;
                _loc_1.itemRenderer = editedItemRenderer;
                dispatchEvent(_loc_1);
                if (!rendererIsEditor)
                {
                    if (itemEditorInstance && itemEditorInstance is UIComponent)
                    {
                        UIComponent(itemEditorInstance).drawFocus(false);
                    }
                    listContent.removeChild(DisplayObject(itemEditorInstance));
                }
                itemEditorInstance = null;
                _editedItemPosition = null;
            }
            return;
        }// end function

        function callMakeListData(param1:Object, param2:String, param3:int) : BaseListData
        {
            return makeListData(param1, param2, param3);
        }// end function

        public function set lockedRowCount(param1:int) : void
        {
            _lockedRowCount = param1;
            invalidateDisplayList();
            return;
        }// end function

    }
}
