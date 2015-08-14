package mx.containers
{
    import flash.display.*;
    import flash.events.*;
    import mx.automation.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.graphics.*;
    import mx.managers.*;

    public class ViewStack extends Container implements IHistoryManagerClient
    {
        private var dispatchChangeEventPending:Boolean = false;
        private var historyManagementEnabledChanged:Boolean = false;
        var vsPreferredHeight:Number;
        private var initialSelectedIndex:int = -1;
        private var firstTime:Boolean = true;
        var _historyManagementEnabled:Boolean = false;
        private var overlayChild:Container;
        private var overlayTargetArea:RoundedRectangle;
        private var proposedSelectedIndex:int = -1;
        private var needToInstantiateSelectedChild:Boolean = false;
        private var bSaveState:Boolean = false;
        var vsMinHeight:Number;
        private var bInLoadState:Boolean = false;
        var vsPreferredWidth:Number;
        private var _resizeToContent:Boolean = false;
        var vsMinWidth:Number;
        private var lastIndex:int = -1;
        private var _selectedIndex:int = -1;
        static const VERSION:String = "3.5.0.12683";

        public function ViewStack()
        {
            addEventListener(ChildExistenceChangedEvent.CHILD_ADD, childAddHandler);
            addEventListener(ChildExistenceChangedEvent.CHILD_REMOVE, childRemoveHandler);
            return;
        }// end function

        protected function get contentHeight() : Number
        {
            var _loc_1:* = viewMetricsAndPadding;
            return unscaledHeight - _loc_1.top - _loc_1.bottom;
        }// end function

        public function set selectedChild(param1:Container) : void
        {
            var _loc_2:* = getChildIndex(DisplayObject(param1));
            if (_loc_2 >= 0 && _loc_2 < numChildren)
            {
                selectedIndex = _loc_2;
            }
            return;
        }// end function

        override function setActualCreationPolicies(param1:String) : void
        {
            var _loc_2:int = 0;
            var _loc_3:Container = null;
            super.setActualCreationPolicies(param1);
            if (param1 == ContainerCreationPolicy.ALL && numChildren > 0)
            {
                _loc_2 = 0;
                while (_loc_2 < numChildren)
                {
                    
                    _loc_3 = getChildAt(_loc_2) as Container;
                    if (_loc_3 && _loc_3.numChildrenCreated == -1)
                    {
                        _loc_3.createComponentsFromDescriptors();
                    }
                    _loc_2++;
                }
            }
            return;
        }// end function

        private function dispatchChangeEvent(param1:int, param2:int) : void
        {
            var _loc_3:* = new IndexChangedEvent(IndexChangedEvent.CHANGE);
            _loc_3.oldIndex = param1;
            _loc_3.newIndex = param2;
            _loc_3.relatedObject = getChildAt(param2);
            dispatchEvent(_loc_3);
            return;
        }// end function

        protected function get contentY() : Number
        {
            return getStyle("paddingTop");
        }// end function

        protected function commitSelectedIndex(param1:int) : void
        {
            var _loc_3:Container = null;
            var _loc_4:Effect = null;
            if (numChildren == 0)
            {
                _selectedIndex = -1;
                return;
            }
            if (param1 < 0)
            {
                param1 = 0;
            }
            else if (param1 > (numChildren - 1))
            {
                param1 = numChildren - 1;
            }
            if (lastIndex != -1 && lastIndex < numChildren)
            {
                Container(getChildAt(lastIndex)).endEffectsStarted();
            }
            if (_selectedIndex != -1)
            {
                selectedChild.endEffectsStarted();
            }
            lastIndex = _selectedIndex;
            if (param1 == lastIndex)
            {
                return;
            }
            _selectedIndex = param1;
            if (initialSelectedIndex == -1)
            {
                initialSelectedIndex = _selectedIndex;
            }
            if (lastIndex != -1 && param1 != -1)
            {
                dispatchChangeEventPending = true;
            }
            var _loc_2:Boolean = false;
            if (lastIndex != -1 && lastIndex < numChildren)
            {
                _loc_3 = Container(getChildAt(lastIndex));
                _loc_3.setVisible(false);
                if (_loc_3.getStyle("hideEffect"))
                {
                    _loc_4 = EffectManager.lastEffectCreated;
                    if (_loc_4)
                    {
                        _loc_4.addEventListener(EffectEvent.EFFECT_END, hideEffectEndHandler);
                        _loc_2 = true;
                    }
                }
            }
            if (!_loc_2)
            {
                hideEffectEndHandler(null);
            }
            return;
        }// end function

        private function instantiateSelectedChild() : void
        {
            if (!selectedChild)
            {
                return;
            }
            if (selectedChild && selectedChild.numChildrenCreated == -1)
            {
                if (initialized)
                {
                    selectedChild.addEventListener(FlexEvent.CREATION_COMPLETE, childCreationCompleteHandler);
                }
                selectedChild.createComponentsFromDescriptors(true);
            }
            if (selectedChild is IInvalidating)
            {
                IInvalidating(selectedChild).invalidateSize();
            }
            invalidateSize();
            invalidateDisplayList();
            return;
        }// end function

        private function initializeHandler(event:FlexEvent) : void
        {
            overlayChild.removeEventListener(FlexEvent.INITIALIZE, initializeHandler);
            UIComponent(overlayChild).addOverlay(overlayColor, overlayTargetArea);
            return;
        }// end function

        public function set historyManagementEnabled(param1:Boolean) : void
        {
            if (param1 != _historyManagementEnabled)
            {
                _historyManagementEnabled = param1;
                historyManagementEnabledChanged = true;
                invalidateProperties();
            }
            return;
        }// end function

        override public function get horizontalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        private function childAddHandler(event:ChildExistenceChangedEvent) : void
        {
            var _loc_4:IUIComponent = null;
            var _loc_2:* = event.relatedObject;
            var _loc_3:* = getChildIndex(_loc_2);
            if (_loc_2 is IUIComponent)
            {
                _loc_4 = IUIComponent(_loc_2);
                _loc_4.visible = false;
            }
            if (numChildren == 1 && proposedSelectedIndex == -1)
            {
                proposedSelectedIndex = 0;
                invalidateProperties();
            }
            else if (_loc_3 <= selectedIndex && numChildren > 1 && proposedSelectedIndex == -1)
            {
                var _loc_6:* = selectedIndex + 1;
                selectedIndex = _loc_6;
            }
            if (_loc_2 is IAutomationObject)
            {
                IAutomationObject(_loc_2).showInAutomationHierarchy = true;
            }
            return;
        }// end function

        private function addedToStageHandler(event:Event) : void
        {
            if (historyManagementEnabled)
            {
                HistoryManager.register(this);
            }
            return;
        }// end function

        public function get resizeToContent() : Boolean
        {
            return _resizeToContent;
        }// end function

        public function saveState() : Object
        {
            var _loc_1:* = _selectedIndex == -1 ? (0) : (_selectedIndex);
            return {selectedIndex:_loc_1};
        }// end function

        override public function get autoLayout() : Boolean
        {
            return true;
        }// end function

        override function removeOverlay() : void
        {
            if (overlayChild)
            {
                UIComponent(overlayChild).removeOverlay();
                overlayChild = null;
            }
            return;
        }// end function

        private function removedFromStageHandler(event:Event) : void
        {
            HistoryManager.unregister(this);
            return;
        }// end function

        public function get selectedChild() : Container
        {
            if (selectedIndex == -1)
            {
                return null;
            }
            return Container(getChildAt(selectedIndex));
        }// end function

        private function hideEffectEndHandler(event:EffectEvent) : void
        {
            if (event)
            {
                event.currentTarget.removeEventListener(EffectEvent.EFFECT_END, hideEffectEndHandler);
            }
            needToInstantiateSelectedChild = true;
            invalidateProperties();
            if (bSaveState)
            {
                HistoryManager.save();
                bSaveState = false;
            }
            return;
        }// end function

        private function childCreationCompleteHandler(event:FlexEvent) : void
        {
            event.target.removeEventListener(FlexEvent.CREATION_COMPLETE, childCreationCompleteHandler);
            event.target.dispatchEvent(new FlexEvent(FlexEvent.SHOW));
            return;
        }// end function

        override public function set horizontalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        public function get historyManagementEnabled() : Boolean
        {
            return _historyManagementEnabled;
        }// end function

        public function loadState(param1:Object) : void
        {
            var _loc_2:* = param1 ? (int(param1.selectedIndex)) : (0);
            if (_loc_2 == -1)
            {
                _loc_2 = initialSelectedIndex;
            }
            if (_loc_2 == -1)
            {
                _loc_2 = 0;
            }
            if (_loc_2 != _selectedIndex)
            {
                bInLoadState = true;
                selectedIndex = _loc_2;
                bInLoadState = false;
            }
            return;
        }// end function

        protected function get contentWidth() : Number
        {
            var _loc_1:* = viewMetricsAndPadding;
            return unscaledWidth - _loc_1.left - _loc_1.right;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (historyManagementEnabledChanged)
            {
                if (historyManagementEnabled)
                {
                    HistoryManager.register(this);
                }
                else
                {
                    HistoryManager.unregister(this);
                }
                historyManagementEnabledChanged = false;
            }
            if (proposedSelectedIndex != -1)
            {
                commitSelectedIndex(proposedSelectedIndex);
                proposedSelectedIndex = -1;
            }
            if (needToInstantiateSelectedChild)
            {
                instantiateSelectedChild();
                needToInstantiateSelectedChild = false;
            }
            if (dispatchChangeEventPending)
            {
                dispatchChangeEvent(lastIndex, selectedIndex);
                dispatchChangeEventPending = false;
            }
            if (firstTime)
            {
                firstTime = false;
                addEventListener(Event.ADDED_TO_STAGE, addedToStageHandler, false, 0, true);
                addEventListener(Event.REMOVED_FROM_STAGE, removedFromStageHandler, false, 0, true);
            }
            return;
        }// end function

        public function set resizeToContent(param1:Boolean) : void
        {
            if (param1 != _resizeToContent)
            {
                _resizeToContent = param1;
                if (param1)
                {
                    invalidateSize();
                }
            }
            return;
        }// end function

        override public function createComponentsFromDescriptors(param1:Boolean = true) : void
        {
            if (actualCreationPolicy == ContainerCreationPolicy.ALL)
            {
                super.createComponentsFromDescriptors();
                return;
            }
            var _loc_2:* = numChildren;
            var _loc_3:* = childDescriptors ? (childDescriptors.length) : (0);
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                createComponentFromDescriptor(childDescriptors[_loc_4], false);
                _loc_4++;
            }
            numChildrenCreated = numChildren - _loc_2;
            processedDescriptors = true;
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_8:Container = null;
            super.measure();
            _loc_1 = 0;
            _loc_2 = 0;
            _loc_3 = 0;
            _loc_4 = 0;
            if (vsPreferredWidth && !_resizeToContent)
            {
                measuredMinWidth = vsMinWidth;
                measuredMinHeight = vsMinHeight;
                measuredWidth = vsPreferredWidth;
                measuredHeight = vsPreferredHeight;
                return;
            }
            if (numChildren > 0 && selectedIndex != -1)
            {
                _loc_8 = Container(getChildAt(selectedIndex));
                _loc_1 = _loc_8.minWidth;
                _loc_3 = _loc_8.getExplicitOrMeasuredWidth();
                _loc_2 = _loc_8.minHeight;
                _loc_4 = _loc_8.getExplicitOrMeasuredHeight();
            }
            var _loc_5:* = viewMetricsAndPadding;
            var _loc_6:* = viewMetricsAndPadding.left + _loc_5.right;
            _loc_1 = _loc_1 + _loc_6;
            _loc_3 = _loc_3 + _loc_6;
            var _loc_7:* = _loc_5.top + _loc_5.bottom;
            _loc_2 = _loc_2 + _loc_7;
            _loc_4 = _loc_4 + _loc_7;
            measuredMinWidth = _loc_1;
            measuredMinHeight = _loc_2;
            measuredWidth = _loc_3;
            measuredHeight = _loc_4;
            if (selectedChild && Container(selectedChild).numChildrenCreated == -1)
            {
                return;
            }
            if (numChildren == 0)
            {
                return;
            }
            vsMinWidth = _loc_1;
            vsMinHeight = _loc_2;
            vsPreferredWidth = _loc_3;
            vsPreferredHeight = _loc_4;
            return;
        }// end function

        override public function set verticalScrollPolicy(param1:String) : void
        {
            return;
        }// end function

        public function set selectedIndex(param1:int) : void
        {
            if (param1 == selectedIndex)
            {
                return;
            }
            proposedSelectedIndex = param1;
            invalidateProperties();
            if (historyManagementEnabled && _selectedIndex != -1 && !bInLoadState)
            {
                bSaveState = true;
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        override function addOverlay(param1:uint, param2:RoundedRectangle = null) : void
        {
            if (overlayChild)
            {
                removeOverlay();
            }
            overlayChild = selectedChild;
            if (!overlayChild)
            {
                return;
            }
            overlayColor = param1;
            overlayTargetArea = param2;
            if (selectedChild && selectedChild.numChildrenCreated == -1)
            {
                selectedChild.addEventListener(FlexEvent.INITIALIZE, initializeHandler);
            }
            else
            {
                initializeHandler(null);
            }
            return;
        }// end function

        override public function set autoLayout(param1:Boolean) : void
        {
            return;
        }// end function

        override public function get verticalScrollPolicy() : String
        {
            return ScrollPolicy.OFF;
        }// end function

        public function get selectedIndex() : int
        {
            return proposedSelectedIndex == -1 ? (_selectedIndex) : (proposedSelectedIndex);
        }// end function

        private function childRemoveHandler(event:ChildExistenceChangedEvent) : void
        {
            var _loc_2:* = event.relatedObject;
            var _loc_3:* = getChildIndex(_loc_2);
            if (_loc_3 > selectedIndex)
            {
                return;
            }
            var _loc_4:* = selectedIndex;
            if (_loc_3 < _loc_4 || _loc_4 == (numChildren - 1))
            {
                if (_loc_4 == 0)
                {
                    selectedIndex = -1;
                    _selectedIndex = -1;
                }
                else
                {
                    var _loc_6:* = selectedIndex - 1;
                    selectedIndex = _loc_6;
                }
            }
            else if (_loc_3 == _loc_4)
            {
                needToInstantiateSelectedChild = true;
                invalidateProperties();
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_8:Container = null;
            var _loc_9:Number = NaN;
            var _loc_10:Number = NaN;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = numChildren;
            var _loc_4:* = contentWidth;
            var _loc_5:* = contentHeight;
            var _loc_6:* = contentX;
            var _loc_7:* = contentY;
            if (selectedIndex != -1)
            {
                _loc_8 = Container(getChildAt(selectedIndex));
                _loc_9 = _loc_4;
                _loc_10 = _loc_5;
                if (!isNaN(_loc_8.percentWidth))
                {
                    if (_loc_9 > _loc_8.maxWidth)
                    {
                        _loc_9 = _loc_8.maxWidth;
                    }
                }
                else if (_loc_9 > _loc_8.explicitWidth)
                {
                    _loc_9 = _loc_8.explicitWidth;
                }
                if (!isNaN(_loc_8.percentHeight))
                {
                    if (_loc_10 > _loc_8.maxHeight)
                    {
                        _loc_10 = _loc_8.maxHeight;
                    }
                }
                else if (_loc_10 > _loc_8.explicitHeight)
                {
                    _loc_10 = _loc_8.explicitHeight;
                }
                if (_loc_8.width != _loc_9 || _loc_8.height != _loc_10)
                {
                    _loc_8.setActualSize(_loc_9, _loc_10);
                }
                if (_loc_8.x != _loc_6 || _loc_8.y != _loc_7)
                {
                    _loc_8.move(_loc_6, _loc_7);
                }
                _loc_8.visible = true;
            }
            return;
        }// end function

        protected function get contentX() : Number
        {
            return getStyle("paddingLeft");
        }// end function

    }
}
