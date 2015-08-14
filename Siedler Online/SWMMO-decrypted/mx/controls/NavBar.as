package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;

    public class NavBar extends Box
    {
        private var _labelField:String = "label";
        private var _iconField:String = "icon";
        private var _dataProvider:IList;
        private var measurementHasBeenCalled:Boolean = false;
        private var _toolTipField:String = "toolTip";
        var navItemFactory:IFactory;
        private var pendingTargetStack:Object;
        private var lastToolTip:String = null;
        private var _labelFunction:Function;
        var targetStack:ViewStack;
        private var _selectedIndex:int = -1;
        private var dataProviderChanged:Boolean = false;
        static const VERSION:String = "3.5.0.12683";

        public function NavBar()
        {
            navItemFactory = new ClassFactory(Button);
            direction = BoxDirection.HORIZONTAL;
            showInAutomationHierarchy = true;
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
            if (param1 != enabled)
            {
                super.enabled = param1;
                _loc_2 = numChildren;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (targetStack)
                    {
                        Button(getChildAt(_loc_3)).enabled = param1 && Container(targetStack.getChildAt(_loc_3)).enabled;
                    }
                    else
                    {
                        Button(getChildAt(_loc_3)).enabled = param1;
                    }
                    _loc_3++;
                }
            }
            return;
        }// end function

        protected function updateNavItemIcon(param1:int, param2:Class) : void
        {
            var _loc_3:* = Button(getChildAt(param1));
            _loc_3.setStyle("icon", param2);
            return;
        }// end function

        private function childIndexChangeHandler(event:IndexChangedEvent) : void
        {
            if (event.target == this)
            {
                return;
            }
            setChildIndex(getChildAt(event.oldIndex), event.newIndex);
            resetNavItems();
            return;
        }// end function

        protected function hiliteSelectedNavItem(param1:int) : void
        {
            return;
        }// end function

        private function checkPendingTargetStack() : void
        {
            if (pendingTargetStack)
            {
                _setTargetViewStack(pendingTargetStack);
                pendingTargetStack = null;
            }
            return;
        }// end function

        private function setTargetViewStack(param1:Object) : void
        {
            if (!measurementHasBeenCalled && param1)
            {
                pendingTargetStack = param1;
                invalidateProperties();
            }
            else
            {
                _setTargetViewStack(param1);
            }
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
            if (numChildren == 0)
            {
                return super.baselinePosition;
            }
            var _loc_1:* = Button(getChildAt(0));
            validateNow();
            return _loc_1.y + _loc_1.baselinePosition;
        }// end function

        private function enabledChangedHandler(event:Event) : void
        {
            var _loc_2:* = targetStack.getChildIndex(DisplayObject(event.target));
            Button(getChildAt(_loc_2)).enabled = enabled && event.target.enabled;
            return;
        }// end function

        private function labelChangedHandler(event:Event) : void
        {
            var _loc_2:* = targetStack.getChildIndex(DisplayObject(event.target));
            updateNavItemLabel(_loc_2, Container(event.target).label);
            return;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            if (dataProviderChanged)
            {
                createNavChildren();
                dataProviderChanged = false;
            }
            return;
        }// end function

        override public function notifyStyleChangeInChildren(param1:String, param2:Boolean) : void
        {
            super.notifyStyleChangeInChildren(param1, true);
            return;
        }// end function

        protected function clickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = getChildIndex(DisplayObject(event.currentTarget));
            if (targetStack)
            {
                targetStack.selectedIndex = _loc_2;
            }
            _selectedIndex = _loc_2;
            var _loc_3:* = new ItemClickEvent(ItemClickEvent.ITEM_CLICK);
            _loc_3.label = Button(event.currentTarget).label;
            _loc_3.index = _loc_2;
            _loc_3.relatedObject = InteractiveObject(event.currentTarget);
            _loc_3.item = _dataProvider ? (_dataProvider.getItemAt(_loc_2)) : (null);
            dispatchEvent(_loc_3);
            event.stopImmediatePropagation();
            return;
        }// end function

        override public function get horizontalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        public function set iconField(param1:String) : void
        {
            _iconField = param1;
            if (_dataProvider)
            {
                dataProvider = _dataProvider;
            }
            dispatchEvent(new Event("iconFieldChanged"));
            return;
        }// end function

        private function childAddHandler(event:ChildExistenceChangedEvent) : void
        {
            if (event.target == this)
            {
                return;
            }
            if (event.relatedObject.parent != targetStack)
            {
                return;
            }
            var _loc_2:* = Container(event.relatedObject);
            var _loc_3:* = Button(createNavItem(itemToLabel(_loc_2), _loc_2.icon));
            var _loc_4:* = _loc_2.parent.getChildIndex(DisplayObject(_loc_2));
            setChildIndex(_loc_3, _loc_4);
            if (_loc_2.toolTip)
            {
                _loc_3.toolTip = _loc_2.toolTip;
                _loc_2.toolTip = null;
            }
            _loc_2.addEventListener("labelChanged", labelChangedHandler);
            _loc_2.addEventListener("iconChanged", iconChangedHandler);
            _loc_2.addEventListener("enabledChanged", enabledChangedHandler);
            _loc_2.addEventListener("toolTipChanged", toolTipChangedHandler);
            _loc_3.enabled = enabled && _loc_2.enabled;
            callLater(resetNavItems);
            return;
        }// end function

        public function itemToLabel(param1:Object) : String
        {
            var data:* = param1;
            if (data == null)
            {
                return "";
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
            if (data is Number)
            {
                return data.toString();
            }
            return "";
        }// end function

        private function createNavChildren() : void
        {
            var item:Object;
            var navItem:Button;
            var label:String;
            var iconValue:Object;
            var icon:Class;
            if (!_dataProvider)
            {
                return;
            }
            var n:* = _dataProvider.length;
            var i:int;
            while (i < n)
            {
                
                item = _dataProvider.getItemAt(i);
                if (item is String && labelFunction == null)
                {
                    navItem = Button(createNavItem(String(item)));
                }
                else
                {
                    label = itemToLabel(item);
                    if (iconField)
                    {
                        iconValue;
                        try
                        {
                            iconValue = item[iconField];
                        }
                        catch (e:Error)
                        {
                        }
                        icon = iconValue is String ? (Class(systemManager.getDefinitionByName(String(iconValue)))) : (Class(iconValue));
                        navItem = Button(createNavItem(label, icon));
                    }
                    else
                    {
                        navItem = Button(createNavItem(label, null));
                    }
                    if (toolTipField)
                    {
                        try
                        {
                            navItem.toolTip = item[toolTipField] === undefined ? (null) : (item[toolTipField]);
                        }
                        catch (e:Error)
                        {
                        }
                    }
                }
                navItem.enabled = enabled;
                i = (i + 1);
            }
            resetNavItems();
            return;
        }// end function

        public function set toolTipField(param1:String) : void
        {
            _toolTipField = param1;
            if (_dataProvider)
            {
                dataProvider = _dataProvider;
            }
            dispatchEvent(new Event("toolTipFieldChanged"));
            return;
        }// end function

        private function _setTargetViewStack(param1:Object) : void
        {
            var _loc_2:ViewStack = null;
            var _loc_4:int = 0;
            var _loc_5:Container = null;
            var _loc_6:int = 0;
            var _loc_7:Button = null;
            if (param1 is ViewStack)
            {
                _loc_2 = ViewStack(param1);
            }
            else if (param1)
            {
                _loc_2 = parentDocument[param1];
            }
            else
            {
                _loc_2 = null;
            }
            if (targetStack)
            {
                targetStack.removeEventListener(ChildExistenceChangedEvent.CHILD_ADD, childAddHandler);
                targetStack.removeEventListener(ChildExistenceChangedEvent.CHILD_REMOVE, childRemoveHandler);
                targetStack.removeEventListener(Event.CHANGE, changeHandler);
                targetStack.removeEventListener(IndexChangedEvent.CHILD_INDEX_CHANGE, childIndexChangeHandler);
                _loc_4 = targetStack.numChildren;
                _loc_6 = 0;
                while (_loc_6 < _loc_4)
                {
                    
                    _loc_5 = Container(targetStack.getChildAt(_loc_6));
                    _loc_5.removeEventListener("labelChanged", labelChangedHandler);
                    _loc_5.removeEventListener("iconChanged", iconChangedHandler);
                    _loc_5.removeEventListener("enabledChanged", enabledChangedHandler);
                    _loc_5.removeEventListener("toolTipChanged", toolTipChangedHandler);
                    _loc_6++;
                }
            }
            removeAllChildren();
            _selectedIndex = -1;
            targetStack = _loc_2;
            if (!targetStack)
            {
                return;
            }
            targetStack.addEventListener(ChildExistenceChangedEvent.CHILD_ADD, childAddHandler);
            targetStack.addEventListener(ChildExistenceChangedEvent.CHILD_REMOVE, childRemoveHandler);
            targetStack.addEventListener(Event.CHANGE, changeHandler);
            targetStack.addEventListener(IndexChangedEvent.CHILD_INDEX_CHANGE, childIndexChangeHandler);
            _loc_4 = targetStack.numChildren;
            _loc_6 = 0;
            while (_loc_6 < _loc_4)
            {
                
                _loc_5 = Container(targetStack.getChildAt(_loc_6));
                _loc_7 = Button(createNavItem(itemToLabel(_loc_5), _loc_5.icon));
                if (_loc_5.toolTip)
                {
                    _loc_7.toolTip = _loc_5.toolTip;
                    _loc_5.toolTip = null;
                }
                _loc_5.addEventListener("labelChanged", labelChangedHandler);
                _loc_5.addEventListener("iconChanged", iconChangedHandler);
                _loc_5.addEventListener("enabledChanged", enabledChangedHandler);
                _loc_5.addEventListener("toolTipChanged", toolTipChangedHandler);
                _loc_7.enabled = enabled && _loc_5.enabled;
                _loc_6++;
            }
            var _loc_3:* = targetStack.selectedIndex;
            if (_loc_3 == -1 && targetStack.numChildren > 0)
            {
                _loc_3 = 0;
            }
            if (_loc_3 != -1)
            {
                hiliteSelectedNavItem(_loc_3);
            }
            resetNavItems();
            invalidateDisplayList();
            return;
        }// end function

        private function toolTipChangedHandler(event:Event) : void
        {
            var _loc_2:* = targetStack.getChildIndex(DisplayObject(event.target));
            var _loc_3:* = UIComponent(getChildAt(_loc_2));
            if (UIComponent(event.target).toolTip)
            {
                _loc_3.toolTip = UIComponent(event.target).toolTip;
                lastToolTip = UIComponent(event.target).toolTip;
                UIComponent(event.target).toolTip = null;
            }
            else if (!lastToolTip)
            {
                _loc_3.toolTip = UIComponent(event.target).toolTip;
                lastToolTip = "placeholder";
                UIComponent(event.target).toolTip = null;
            }
            else
            {
                lastToolTip = null;
            }
            return;
        }// end function

        protected function createNavItem(param1:String, param2:Class = null) : IFlexDisplayObject
        {
            return null;
        }// end function

        public function get dataProvider() : Object
        {
            return targetStack ? (targetStack) : (_dataProvider);
        }// end function

        protected function updateNavItemLabel(param1:int, param2:String) : void
        {
            var _loc_3:* = Button(getChildAt(param1));
            _loc_3.label = param2;
            return;
        }// end function

        override public function set horizontalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (!measurementHasBeenCalled)
            {
                checkPendingTargetStack();
                measurementHasBeenCalled = true;
            }
            if (dataProviderChanged)
            {
                dataProviderChanged = false;
                createNavChildren();
            }
            if (blocker)
            {
                blocker.visible = false;
            }
            return;
        }// end function

        public function set labelField(param1:String) : void
        {
            _labelField = param1;
            if (_dataProvider)
            {
                dataProvider = _dataProvider;
            }
            dispatchEvent(new Event("labelFieldChanged"));
            return;
        }// end function

        private function iconChangedHandler(event:Event) : void
        {
            var _loc_2:* = targetStack.getChildIndex(DisplayObject(event.target));
            updateNavItemIcon(_loc_2, Container(event.target).icon);
            return;
        }// end function

        protected function resetNavItems() : void
        {
            return;
        }// end function

        public function get toolTipField() : String
        {
            return _toolTipField;
        }// end function

        public function set labelFunction(param1:Function) : void
        {
            _labelFunction = param1;
            if (_dataProvider)
            {
                dataProvider = _dataProvider;
            }
            dispatchEvent(new Event("labelFunctionChanged"));
            return;
        }// end function

        public function get labelField() : String
        {
            return _labelField;
        }// end function

        override public function set verticalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        private function childRemoveHandler(event:ChildExistenceChangedEvent) : void
        {
            if (event.target == this)
            {
                return;
            }
            event.relatedObject.removeEventListener("labelChanged", labelChangedHandler);
            event.relatedObject.removeEventListener("iconChanged", iconChangedHandler);
            event.relatedObject.removeEventListener("enabledChanged", enabledChangedHandler);
            event.relatedObject.removeEventListener("toolTipChanged", toolTipChangedHandler);
            var _loc_2:* = ViewStack(event.target);
            removeChildAt(_loc_2.getChildIndex(event.relatedObject));
            callLater(resetNavItems);
            return;
        }// end function

        public function get labelFunction() : Function
        {
            return _labelFunction;
        }// end function

        override public function get verticalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        public function set dataProvider(param1:Object) : void
        {
            var _loc_2:String = null;
            var _loc_3:String = null;
            if (param1 && !(param1 is String) && !(param1 is ViewStack) && !(param1 is Array) && !(param1 is IList))
            {
                _loc_2 = resourceManager.getString("controls", "errWrongContainer", [id]);
                throw new Error(_loc_2);
            }
            if (_dataProvider)
            {
                _dataProvider.removeEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler);
            }
            if (param1 is String && (document && document[param1]))
            {
                param1 = document[param1];
            }
            if (param1 is String || param1 is ViewStack)
            {
                setTargetViewStack(param1);
                return;
            }
            if (param1 is IList && IList(param1).length > 0 && IList(param1).getItemAt(0) is DisplayObject || param1 is Array && (param1 as Array).length > 0 && param1[0] is DisplayObject)
            {
                _loc_3 = id ? (className + " \'" + id + "\'") : ("a " + className);
                _loc_2 = resourceManager.getString("controls", "errWrongType", [_loc_3]);
                throw new Error(_loc_2);
            }
            setTargetViewStack(null);
            removeAllChildren();
            if (param1 is IList)
            {
                _dataProvider = IList(param1);
            }
            else if (param1 is Array)
            {
                _dataProvider = new ArrayCollection(param1 as Array);
            }
            else
            {
                _dataProvider = null;
            }
            dataProviderChanged = true;
            invalidateProperties();
            if (_dataProvider)
            {
                _dataProvider.addEventListener(CollectionEvent.COLLECTION_CHANGE, collectionChangeHandler, false, 0, true);
            }
            if (inheritingStyles == UIComponent.STYLE_UNINITIALIZED)
            {
                return;
            }
            dispatchEvent(new Event("collectionChange"));
            return;
        }// end function

        private function changeHandler(event:Event) : void
        {
            if (event.target == dataProvider)
            {
                hiliteSelectedNavItem(Object(event.target).selectedIndex);
            }
            return;
        }// end function

        private function collectionChangeHandler(event:Event) : void
        {
            dataProvider = dataProvider;
            return;
        }// end function

        public function set selectedIndex(param1:int) : void
        {
            _selectedIndex = param1;
            if (targetStack)
            {
                targetStack.selectedIndex = param1;
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        public function get selectedIndex() : int
        {
            return _selectedIndex;
        }// end function

    }
}
