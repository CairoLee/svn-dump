package org.igniterealtime.xiff.collections
{
    import flash.events.*;
    import flash.utils.*;
    import org.igniterealtime.xiff.collections.events.*;

    public class ArrayCollection extends Proxy implements IEventDispatcher
    {
        protected var eventDispatcher:EventDispatcher;
        protected var _source:Array;
        protected const OUT_OF_BOUNDS_MESSAGE:String = "The supplied index is out of bounds.";

        public function ArrayCollection(param1:Array = null)
        {
            _source = [];
            eventDispatcher = new EventDispatcher(this);
            if (param1)
            {
                this.source = param1;
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return eventDispatcher.dispatchEvent(event);
        }// end function

        protected function internalDispatchEvent(param1:String, param2 = null, param3:int = -1) : void
        {
            var _loc_4:* = new CollectionEvent(CollectionEvent.COLLECTION_CHANGE);
            new CollectionEvent(CollectionEvent.COLLECTION_CHANGE).kind = param1;
            _loc_4.items.push(param2);
            _loc_4.location = param3;
            dispatchEvent(_loc_4);
            return;
        }// end function

        override function nextValue(param1:int)
        {
            return getItemAt((param1 - 1));
        }// end function

        public function clearSource() : void
        {
            _source.splice(0, length);
            return;
        }// end function

        public function getItemIndex(param1) : int
        {
            var _loc_2:* = _source.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (_source[_loc_3] === param1)
                {
                    return _loc_3;
                }
                _loc_3++;
            }
            return -1;
        }// end function

        public function removeItemAt(param1:int)
        {
            if (param1 < 0 || param1 >= length)
            {
                throw new RangeError(OUT_OF_BOUNDS_MESSAGE);
            }
            var _loc_2:* = _source.splice(param1, 1)[0];
            internalDispatchEvent(CollectionEventKind.REMOVE, _loc_2, param1);
            return _loc_2;
        }// end function

        override function getProperty(param1)
        {
            var n:Number;
            var message:String;
            var name:* = param1;
            if (name is QName)
            {
                name = name.localName;
            }
            var index:int;
            try
            {
                n = parseInt(String(name));
                if (!isNaN(n))
                {
                    index = int(n);
                }
            }
            catch (error:Error)
            {
            }
            if (index == -1)
            {
                message = "Unknown Property: " + name + ".";
                throw new Error(message);
            }
            return getItemAt(index);
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return eventDispatcher.hasEventListener(param1);
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            eventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        override function hasProperty(param1) : Boolean
        {
            var n:Number;
            var name:* = param1;
            if (name is QName)
            {
                name = name.localName;
            }
            var index:int;
            try
            {
                n = parseInt(String(name));
                if (!isNaN(n))
                {
                    index = int(n);
                }
            }
            catch (error:Error)
            {
            }
            if (index == -1)
            {
                return false;
            }
            return index >= 0 && index < length;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            eventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        override function callProperty(param1, ... args)
        {
            return null;
        }// end function

        public function addItem(param1) : void
        {
            addItemAt(param1, length);
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return eventDispatcher.willTrigger(param1);
        }// end function

        override function setProperty(param1, param2) : void
        {
            var n:Number;
            var message:String;
            var name:* = param1;
            var value:* = param2;
            if (name is QName)
            {
                name = name.localName;
            }
            var index:int;
            try
            {
                n = parseInt(String(name));
                if (!isNaN(n))
                {
                    index = int(n);
                }
            }
            catch (error:Error)
            {
            }
            if (index == -1)
            {
                message = "Unknown Property: " + name + ".";
                throw new Error(message);
            }
            setItemAt(value, index);
            return;
        }// end function

        public function get source() : Array
        {
            return _source;
        }// end function

        public function getItemAt(param1:int)
        {
            if (param1 < 0 || param1 >= length)
            {
                throw new RangeError(OUT_OF_BOUNDS_MESSAGE);
            }
            return _source[param1];
        }// end function

        public function toArray() : Array
        {
            return _source.concat();
        }// end function

        public function contains(param1) : Boolean
        {
            return getItemIndex(param1) != -1;
        }// end function

        override function nextNameIndex(param1:int) : int
        {
            return param1 < length ? ((param1 + 1)) : (0);
        }// end function

        override function nextName(param1:int) : String
        {
            return ((param1 - 1)).toString();
        }// end function

        public function get length() : int
        {
            return _source ? (_source.length) : (0);
        }// end function

        public function addItemAt(param1, param2:int) : void
        {
            if (param2 < 0 || param2 > length)
            {
                throw new RangeError(OUT_OF_BOUNDS_MESSAGE);
            }
            _source.splice(param2, 0, param1);
            internalDispatchEvent(CollectionEventKind.ADD, param1, param2);
            return;
        }// end function

        public function toString() : String
        {
            if (_source)
            {
                return _source.toString();
            }
            return "";
        }// end function

        public function setItemAt(param1, param2:int)
        {
            if (param2 < 0 || param2 >= length)
            {
                throw new RangeError(OUT_OF_BOUNDS_MESSAGE);
            }
            var _loc_3:* = _source.splice(param2, 1, param1)[0];
            internalDispatchEvent(CollectionEventKind.REPLACE, param1, param2);
            return _loc_3;
        }// end function

        public function set source(param1:Array) : void
        {
            _source = param1 ? (param1) : ([]);
            internalDispatchEvent(CollectionEventKind.RESET);
            return;
        }// end function

        public function itemUpdated(param1) : void
        {
            internalDispatchEvent(CollectionEventKind.UPDATE, param1);
            return;
        }// end function

        public function removeAll() : void
        {
            if (length > 0)
            {
                clearSource();
                internalDispatchEvent(CollectionEventKind.RESET);
            }
            return;
        }// end function

        public function removeItem(param1) : Boolean
        {
            var _loc_2:* = getItemIndex(param1);
            var _loc_3:* = _loc_2 >= 0;
            if (_loc_3)
            {
                removeItemAt(_loc_2);
            }
            return _loc_3;
        }// end function

    }
}
