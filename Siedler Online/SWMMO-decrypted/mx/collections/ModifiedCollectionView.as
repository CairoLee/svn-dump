package mx.collections
{
    import flash.events.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.collections.errors.*;
    import mx.events.*;
    import mx.resources.*;

    public class ModifiedCollectionView extends Object implements ICollectionView
    {
        private var addedItems:Dictionary;
        private var _showPreserved:Boolean = false;
        private var list:ICollectionView;
        private var deltaLength:int = 0;
        private var resourceManager:IResourceManager;
        private var removedItems:Dictionary;
        private var itemWrappersByIndex:Array;
        private var replacementItems:Dictionary;
        private var deltas:Array;
        private var replacedItems:Dictionary;
        private var itemWrappersByCollectionMod:Dictionary;
        public static const REPLACEMENT:String = "replacement";
        public static const REPLACED:String = "replaced";
        public static const REMOVED:String = "removed";
        static const VERSION:String = "3.5.0.12683";
        public static const ADDED:String = "added";

        public function ModifiedCollectionView(param1:ICollectionView)
        {
            resourceManager = ResourceManager.getInstance();
            deltas = [];
            removedItems = new Dictionary(true);
            addedItems = new Dictionary(true);
            replacedItems = new Dictionary(true);
            replacementItems = new Dictionary(true);
            itemWrappersByIndex = [];
            itemWrappersByCollectionMod = new Dictionary(true);
            this.list = param1;
            return;
        }// end function

        function getBookmarkIndex(param1:CursorBookmark) : int
        {
            var _loc_3:String = null;
            if (!(param1 is ModifiedCollectionViewBookmark) || ModifiedCollectionViewBookmark(param1).view != this)
            {
                _loc_3 = resourceManager.getString("collections", "bookmarkNotFound");
                throw new CollectionViewError(_loc_3);
            }
            var _loc_2:* = ModifiedCollectionViewBookmark(param1);
            return _loc_2.index;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return false;
        }// end function

        private function removeModification(param1:CollectionModification) : Boolean
        {
            var _loc_2:int = 0;
            while (_loc_2 < deltas.length)
            {
                
                if (deltas[_loc_2] == param1)
                {
                    deltas.splice(_loc_2, 1);
                    return true;
                }
                _loc_2++;
            }
            return false;
        }// end function

        function getWrappedItemUsingCursor(param1:ModifiedCollectionViewCursor, param2:int) : Object
        {
            var _loc_6:CollectionModification = null;
            var _loc_9:Object = null;
            var _loc_3:* = param2;
            var _loc_4:Object = null;
            var _loc_5:CollectionModification = null;
            var _loc_7:Boolean = false;
            var _loc_8:int = 0;
            while (_loc_8 < deltas.length)
            {
                
                _loc_6 = deltas[_loc_8];
                if (_loc_3 < _loc_6.index)
                {
                    break;
                }
                if (_loc_6.modificationType == CollectionModification.REPLACE)
                {
                    if (_loc_3 == _loc_6.index && _loc_6.showOldReplace && _showPreserved)
                    {
                        _loc_5 = _loc_6;
                        break;
                    }
                    if (_loc_3 == (_loc_6.index + 1) && _loc_6.showOldReplace && _loc_6.showNewReplace && _showPreserved)
                    {
                        _loc_3 = _loc_3 - 1;
                        _loc_7 = true;
                        break;
                    }
                    if (_loc_3 == _loc_6.index && (!_loc_6.showOldReplace && _loc_6.showNewReplace || !_showPreserved))
                    {
                        _loc_7 = true;
                        break;
                    }
                    _loc_3 = _loc_3 - _loc_6.modCount;
                }
                else if (isActive(_loc_6))
                {
                    if (_loc_3 == _loc_6.index && _loc_6.isRemove)
                    {
                        _loc_5 = _loc_6;
                        break;
                    }
                    else if (_loc_3 >= _loc_6.index)
                    {
                        _loc_3 = _loc_3 - _loc_6.modCount;
                    }
                }
                _loc_8++;
            }
            if (_loc_5)
            {
                _loc_4 = _loc_5.item;
            }
            else
            {
                param1.internalCursor.seek(CursorBookmark.CURRENT, _loc_3 - param1.internalIndex);
                _loc_4 = param1.internalCursor.current;
                param1.internalIndex = _loc_3;
            }
            if (_loc_6 && _loc_3 == _loc_6.index && _loc_6.modificationType == CollectionModification.ADD)
            {
                _loc_9 = getUniqueItemWrapper(_loc_4, _loc_6, _loc_3);
            }
            else
            {
                _loc_9 = getUniqueItemWrapper(_loc_4, _loc_5, _loc_3);
            }
            return _loc_9;
        }// end function

        public function contains(param1:Object) : Boolean
        {
            return false;
        }// end function

        private function integrateReplacedElements(event:CollectionEvent, param2:int, param3:int) : void
        {
            var _loc_9:Object = null;
            var _loc_10:Object = null;
            var _loc_11:CollectionModification = null;
            var _loc_12:CollectionModification = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Boolean = false;
            var _loc_7:* = event.items.length;
            var _loc_8:int = 0;
            while (_loc_4 < deltas.length && _loc_5 < _loc_7)
            {
                
                _loc_9 = PropertyChangeEvent(event.items[_loc_5]).oldValue;
                _loc_10 = PropertyChangeEvent(event.items[_loc_5]).newValue;
                _loc_11 = CollectionModification(deltas[_loc_4]);
                _loc_12 = new CollectionModification(event.location + _loc_5, _loc_9, CollectionModification.REPLACE);
                if (_loc_11.isRemove && _loc_11.index <= _loc_12.index || !_loc_11.isRemove && _loc_11.index < _loc_12.index)
                {
                    _loc_4++;
                    continue;
                }
                if ((_loc_11.modificationType == CollectionModification.ADD || _loc_11.modificationType == CollectionModification.REPLACE) && _loc_11.index == _loc_12.index)
                {
                    _loc_4++;
                    _loc_5++;
                    continue;
                }
                deltas.splice(_loc_4 + _loc_5, 0, _loc_12);
                replacedItems[getUniqueItemWrapper(_loc_9, _loc_12, event.location + _loc_5)] = _loc_12;
                replacementItems[getUniqueItemWrapper(_loc_10, _loc_12, event.location + _loc_5, true)] = _loc_12;
                _loc_5++;
                _loc_4++;
            }
            while (_loc_5 < _loc_7)
            {
                
                _loc_9 = PropertyChangeEvent(event.items[_loc_5]).oldValue;
                _loc_10 = PropertyChangeEvent(event.items[_loc_5]).newValue;
                var _loc_13:* = new CollectionModification(event.location + _loc_5, _loc_9, CollectionModification.REPLACE);
                _loc_12 = new CollectionModification(event.location + _loc_5, _loc_9, CollectionModification.REPLACE);
                deltas.push(_loc_13);
                replacedItems[getUniqueItemWrapper(_loc_9, _loc_12, event.location + _loc_5)] = _loc_12;
                replacementItems[getUniqueItemWrapper(_loc_10, _loc_12, event.location + _loc_5, true)] = _loc_12;
                _loc_5++;
            }
            return;
        }// end function

        function getBookmark(param1:ModifiedCollectionViewCursor) : ModifiedCollectionViewBookmark
        {
            var _loc_4:String = null;
            var _loc_2:* = param1.currentIndex;
            if (_loc_2 < 0 || _loc_2 > length)
            {
                _loc_4 = resourceManager.getString("collections", "invalidIndex", [_loc_2]);
                throw new CollectionViewError(_loc_4);
            }
            var _loc_3:* = param1.current;
            return new ModifiedCollectionViewBookmark(_loc_3, this, 0, _loc_2, param1.internalCursor.bookmark, param1.internalIndex);
        }// end function

        public function get sort() : Sort
        {
            return null;
        }// end function

        public function itemUpdated(param1:Object, param2:Object = null, param3:Object = null, param4:Object = null) : void
        {
            return;
        }// end function

        public function processCollectionEvent(event:CollectionEvent, param2:int, param3:int) : void
        {
            switch(event.kind)
            {
                case CollectionEventKind.ADD:
                {
                    integrateAddedElements(event, param2, param3);
                    break;
                }
                case CollectionEventKind.REMOVE:
                {
                    integrateRemovedElements(event, param2, param3);
                    break;
                }
                case CollectionEventKind.REPLACE:
                {
                    integrateReplacedElements(event, param2, param3);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function get showPreservedState() : Boolean
        {
            return _showPreserved;
        }// end function

        public function getSemantics(param1:ItemWrapper) : String
        {
            if (removedItems[param1])
            {
                return ModifiedCollectionView.REMOVED;
            }
            if (addedItems[param1])
            {
                return ModifiedCollectionView.ADDED;
            }
            if (replacedItems[param1])
            {
                return ModifiedCollectionView.REPLACED;
            }
            if (replacementItems[param1])
            {
                return ModifiedCollectionView.REPLACEMENT;
            }
            return null;
        }// end function

        private function getUniqueItemWrapper(param1:Object, param2:CollectionModification, param3:int, param4:Boolean = false) : Object
        {
            if (param2 && (param2.isRemove || param2.modificationType == CollectionModification.REPLACE && !param4))
            {
                if (!itemWrappersByCollectionMod[param2])
                {
                    itemWrappersByCollectionMod[param2] = new ItemWrapper(param1);
                }
                return itemWrappersByCollectionMod[param2];
            }
            if (param2 && param2.modificationType == CollectionModification.ADD)
            {
                param3 = param2.index;
            }
            if (!itemWrappersByIndex[param3])
            {
                itemWrappersByIndex[param3] = new ItemWrapper(param1);
            }
            return itemWrappersByIndex[param3];
        }// end function

        public function enableAutoUpdate() : void
        {
            return;
        }// end function

        public function set sort(param1:Sort) : void
        {
            return;
        }// end function

        public function removeItem(param1:ItemWrapper) : void
        {
            var _loc_2:* = removedItems[param1] as CollectionModification;
            if (!_loc_2)
            {
                _loc_2 = replacedItems[param1] as CollectionModification;
                if (_loc_2)
                {
                    delete replacedItems[param1];
                    _loc_2.stopShowingReplacedValue();
                    var _loc_4:* = deltaLength - 1;
                    deltaLength = _loc_4;
                    if (_loc_2.modCount == 0)
                    {
                        removeModification(_loc_2);
                    }
                }
            }
            else if (removeModification(_loc_2))
            {
                delete removedItems[param1];
                var _loc_4:* = deltaLength - 1;
                deltaLength = _loc_4;
            }
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            return;
        }// end function

        private function integrateRemovedElements(event:CollectionEvent, param2:int, param3:int) : void
        {
            var _loc_9:CollectionModification = null;
            var _loc_10:CollectionModification = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:* = event.items.length;
            var _loc_8:int = 0;
            while (_loc_4 < deltas.length && _loc_5 < _loc_7)
            {
                
                _loc_9 = CollectionModification(deltas[_loc_4]);
                _loc_10 = new CollectionModification(event.location, event.items[_loc_5], CollectionModification.REMOVE);
                removedItems[getUniqueItemWrapper(event.items[_loc_5], _loc_10, 0)] = _loc_10;
                if (_loc_8 != 0)
                {
                    _loc_9.index = _loc_9.index + _loc_8;
                }
                if (_loc_9.isRemove && _loc_9.index <= _loc_10.index || !_loc_9.isRemove && _loc_9.index < _loc_10.index)
                {
                    _loc_4++;
                    continue;
                }
                else if (!_loc_9.isRemove && _loc_9.index == _loc_10.index)
                {
                    deltas.splice(_loc_4 + _loc_5, 1);
                }
                else
                {
                    deltas.splice(_loc_4 + _loc_5, 0, _loc_10);
                    _loc_4++;
                }
                _loc_8 = _loc_8 - 1;
                _loc_5++;
            }
            while (_loc_4 < deltas.length)
            {
                
                _loc_9 = CollectionModification(deltas[_loc_4++]);
                CollectionModification(deltas[_loc_4++]).index = _loc_9.index + _loc_8;
            }
            while (_loc_5 < _loc_7)
            {
                
                var _loc_11:* = new CollectionModification(event.location, event.items[_loc_5], CollectionModification.REMOVE);
                _loc_10 = new CollectionModification(event.location, event.items[_loc_5], CollectionModification.REMOVE);
                deltas.push(_loc_11);
                removedItems[getUniqueItemWrapper(event.items[_loc_5], _loc_10, 0)] = _loc_10;
                _loc_5++;
            }
            deltaLength = deltaLength + (event.items.length - _loc_6);
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return false;
        }// end function

        private function isActive(param1:CollectionModification) : Boolean
        {
            return _showPreserved;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            return;
        }// end function

        public function refresh() : Boolean
        {
            return false;
        }// end function

        public function addItem(param1:ItemWrapper) : void
        {
            var _loc_2:* = addedItems[param1] as CollectionModification;
            if (!_loc_2)
            {
                _loc_2 = replacementItems[param1] as CollectionModification;
                if (_loc_2)
                {
                    _loc_2.startShowingReplacementValue();
                    var _loc_4:* = deltaLength + 1;
                    deltaLength = _loc_4;
                    if (_loc_2.modCount == 0)
                    {
                        removeModification(_loc_2);
                    }
                }
            }
            else if (removeModification(_loc_2))
            {
                var _loc_4:* = deltaLength + 1;
                deltaLength = _loc_4;
            }
            return;
        }// end function

        public function get length() : int
        {
            return list.length + (_showPreserved ? (deltaLength) : (0));
        }// end function

        public function set filterFunction(param1:Function) : void
        {
            return;
        }// end function

        public function set showPreservedState(param1:Boolean) : void
        {
            _showPreserved = param1;
            return;
        }// end function

        public function createCursor() : IViewCursor
        {
            var _loc_1:* = list.createCursor();
            var _loc_2:* = _loc_1.current;
            return new ModifiedCollectionViewCursor(this, _loc_1, _loc_2);
        }// end function

        private function integrateAddedElements(event:CollectionEvent, param2:int, param3:int) : void
        {
            var _loc_9:CollectionModification = null;
            var _loc_10:CollectionModification = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Boolean = false;
            var _loc_7:* = event.items.length;
            var _loc_8:int = 0;
            while (_loc_4 < deltas.length && _loc_5 < _loc_7)
            {
                
                _loc_9 = CollectionModification(deltas[_loc_4]);
                _loc_10 = new CollectionModification(event.location + _loc_5, null, CollectionModification.ADD);
                addedItems[getUniqueItemWrapper(event.items[_loc_5], _loc_10, 0)] = _loc_10;
                if (_loc_9.isRemove && _loc_9.index <= _loc_10.index || !_loc_9.isRemove && _loc_9.index < _loc_10.index)
                {
                    _loc_4++;
                    continue;
                }
                deltas.splice(_loc_4 + _loc_5, 0, _loc_10);
                _loc_8++;
                _loc_5++;
                _loc_4++;
            }
            while (_loc_4 < deltas.length)
            {
                
                _loc_9 = CollectionModification(deltas[_loc_4++]);
                CollectionModification(deltas[_loc_4++]).index = _loc_9.index + _loc_8;
            }
            while (_loc_5 < _loc_7)
            {
                
                var _loc_11:* = new CollectionModification(event.location + _loc_5, null, CollectionModification.ADD);
                _loc_10 = new CollectionModification(event.location + _loc_5, null, CollectionModification.ADD);
                deltas.push(_loc_11);
                addedItems[getUniqueItemWrapper(event.items[_loc_5], _loc_10, 0)] = _loc_10;
                _loc_5++;
            }
            deltaLength = deltaLength - event.items.length;
            return;
        }// end function

        public function disableAutoUpdate() : void
        {
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return false;
        }// end function

        public function get filterFunction() : Function
        {
            return null;
        }// end function

    }
}

class ModifiedCollectionViewBookmark extends CursorBookmark
{
    var viewRevision:int;
    var index:int;
    var internalBookmark:CursorBookmark;
    var view:ModifiedCollectionView;
    var internalIndex:int;

    function ModifiedCollectionViewBookmark(param1:Object, param2:ModifiedCollectionView, param3:int, param4:int, param5:CursorBookmark, param6:int)
    {
        super(param1);
        this.view = param2;
        this.viewRevision = param3;
        this.index = param4;
        this.internalBookmark = param5;
        this.internalIndex = param6;
        return;
    }// end function

    override public function getViewIndex() : int
    {
        return view.getBookmarkIndex(this);
    }// end function

}


class CollectionModification extends Object
{
    public var showOldReplace:Boolean = true;
    private var _modCount:int = 0;
    public var showNewReplace:Boolean = false;
    public var index:int;
    public var modificationType:String = null;
    public var item:Object = null;
    public static const ADD:String = "add";
    public static const REPLACE:String = "replace";
    public static const REMOVE:String = "remove";

    function CollectionModification(param1:int, param2:Object, param3:String)
    {
        this.index = param1;
        this.modificationType = param3;
        if (param3 != CollectionModification.ADD)
        {
            this.item = param2;
        }
        if (param3 == CollectionModification.REMOVE)
        {
            _modCount = 1;
        }
        else if (param3 == CollectionModification.ADD)
        {
            _modCount = -1;
        }
        return;
    }// end function

    public function startShowingReplacementValue() : void
    {
        showNewReplace = true;
        var _loc_2:* = _modCount + 1;
        _modCount = _loc_2;
        return;
    }// end function

    public function get modCount() : int
    {
        return _modCount;
    }// end function

    public function get isRemove() : Boolean
    {
        return modificationType == CollectionModification.REMOVE;
    }// end function

    public function stopShowingReplacedValue() : void
    {
        showOldReplace = false;
        var _loc_2:* = _modCount - 1;
        _modCount = _loc_2;
        return;
    }// end function

}

