package mx.containers
{
    import flash.display.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.managers.*;
    import mx.styles.*;

    public class TabNavigator extends ViewStack implements IFocusManagerComponent
    {
        protected var tabBar:TabBar;
        private static var _tabBarStyleFilters:Object = {firstTabStyleName:"firstTabStyleName", horizontalAlign:"horizontalAlign", horizontalGap:"horizontalGap", lastTabStyleName:"lastTabStyleName", selectedTabTextStyleName:"selectedTabTextStyleName", tabStyleName:"tabStyleName", tabWidth:"tabWidth", verticalAlign:"verticalAlign", verticalGap:"verticalGap"};
        static const VERSION:String = "3.5.0.12683";
        private static const MIN_TAB_WIDTH:Number = 30;

        public function TabNavigator()
        {
            tabEnabled = true;
            historyManagementEnabled = true;
            return;
        }// end function

        override protected function get contentHeight() : Number
        {
            var _loc_1:* = viewMetricsAndPadding;
            var _loc_2:* = _loc_1.top;
            var _loc_3:* = _loc_1.bottom;
            if (isNaN(_loc_2))
            {
                _loc_2 = 0;
            }
            if (isNaN(_loc_3))
            {
                _loc_3 = 0;
            }
            return unscaledHeight - tabBarHeight - _loc_2 - _loc_3;
        }// end function

        function getTabBar() : TabBar
        {
            return tabBar;
        }// end function

        override protected function layoutChrome(param1:Number, param2:Number) : void
        {
            var _loc_3:Number = NaN;
            super.layoutChrome(param1, param2);
            if (border)
            {
                _loc_3 = tabBarHeight;
                border.setActualSize(param1, param2 - _loc_3);
                border.move(0, _loc_3);
            }
            return;
        }// end function

        private function get tabBarHeight() : Number
        {
            var _loc_1:* = getStyle("tabHeight");
            if (isNaN(_loc_1))
            {
                _loc_1 = tabBar.getExplicitOrMeasuredHeight();
            }
            return _loc_1 - borderMetrics.top;
        }// end function

        override protected function get contentY() : Number
        {
            var _loc_1:* = getStyle("paddingTop");
            if (isNaN(_loc_1))
            {
                _loc_1 = 0;
            }
            return tabBarHeight + _loc_1;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (tabBar && tabBar.dataProvider != this && numChildren > 0 && getChildAt(0))
            {
                tabBar.dataProvider = this;
            }
            return;
        }// end function

        override protected function adjustFocusRect(param1:DisplayObject = null) : void
        {
            super.adjustFocusRect(param1);
            var _loc_2:* = IFlexDisplayObject(getFocusObject());
            if (_loc_2)
            {
                _loc_2.setActualSize(_loc_2.width, _loc_2.height - tabBarHeight);
                _loc_2.move(_loc_2.x, _loc_2.y + tabBarHeight);
                if (_loc_2 is IInvalidating)
                {
                    IInvalidating(_loc_2).validateNow();
                }
                else if (_loc_2 is IProgrammaticSkin)
                {
                    IProgrammaticSkin(_loc_2).mx.core:IProgrammaticSkin::validateNow();
                }
            }
            return;
        }// end function

        override protected function focusOutHandler(event:FocusEvent) : void
        {
            super.focusOutHandler(event);
            if (focusManager && event.target == this)
            {
                focusManager.defaultButtonEnabled = true;
            }
            return;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            if (!tabBar)
            {
                tabBar = new TabBar();
                tabBar.name = "tabBar";
                tabBar.focusEnabled = false;
                tabBar.styleName = new StyleProxy(this, tabBarStyleFilters);
                rawChildren.addChild(tabBar);
                if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
                {
                    tabBar.setStyle("paddingTop", 0);
                    tabBar.setStyle("paddingBottom", 0);
                    tabBar.setStyle("borderStyle", "none");
                }
            }
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            var _loc_4:Container = null;
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                return super.baselinePosition;
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            var _loc_1:* = numChildren == 0;
            if (_loc_1)
            {
                _loc_4 = new Container();
                addChild(_loc_4);
                validateNow();
            }
            var _loc_2:* = getTabAt(0);
            var _loc_3:* = tabBar.y + _loc_2.y + _loc_2.baselinePosition;
            if (_loc_1)
            {
                removeChildAt(0);
                validateNow();
            }
            return _loc_3;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            if (vsPreferredWidth && !resizeToContent)
            {
                measuredMinWidth = vsMinWidth;
                measuredMinHeight = vsMinHeight;
                measuredWidth = vsPreferredWidth;
                measuredHeight = vsPreferredHeight;
                return;
            }
            super.measure();
            _loc_1 = tabBarHeight;
            measuredMinHeight = measuredMinHeight + _loc_1;
            measuredHeight = measuredHeight + _loc_1;
            var _loc_2:* = getStyle("tabWidth");
            if (isNaN(_loc_2))
            {
                _loc_2 = 0;
            }
            var _loc_3:* = numChildren * Math.max(_loc_2, MIN_TAB_WIDTH);
            var _loc_4:* = viewMetrics;
            _loc_3 = _loc_3 + (_loc_4.left + _loc_4.right);
            if (numChildren > 1)
            {
                _loc_3 = _loc_3 + getStyle("horizontalGap") * (numChildren - 1);
            }
            if (measuredWidth < _loc_3)
            {
                measuredWidth = _loc_3;
            }
            if (selectedChild && Container(selectedChild).numChildrenCreated == -1)
            {
                return;
            }
            if (numChildren == 0)
            {
                return;
            }
            vsMinWidth = measuredMinWidth;
            vsMinHeight = measuredMinHeight;
            vsPreferredWidth = measuredWidth;
            vsPreferredHeight = measuredHeight;
            return;
        }// end function

        protected function get tabBarStyleFilters() : Object
        {
            return _tabBarStyleFilters;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            if (focusManager.getFocus() == this)
            {
                tabBar.dispatchEvent(event);
            }
            return;
        }// end function

        override protected function focusInHandler(event:FocusEvent) : void
        {
            super.focusInHandler(event);
            if (event.target == this)
            {
                focusManager.defaultButtonEnabled = false;
            }
            return;
        }// end function

        public function getTabAt(param1:int) : Button
        {
            return Button(tabBar.getChildAt(param1));
        }// end function

        override public function drawFocus(param1:Boolean) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            super.drawFocus(param1);
            if (!parent)
            {
                return;
            }
            var _loc_2:* = IUIComponent(parent).focusPane;
            if (param1 && !isEffectStarted)
            {
                if (_loc_2)
                {
                    if (parent is Container)
                    {
                        _loc_3 = Container(parent).rawChildren.numChildren;
                        _loc_4 = Container(parent).firstChildIndex;
                        Container(parent).rawChildren.setChildIndex(_loc_2, Math.max(0, _loc_4 == _loc_3 ? ((_loc_3 - 1)) : (_loc_4)));
                    }
                    else
                    {
                        parent.setChildIndex(_loc_2, 0);
                    }
                }
            }
            else if (_loc_2)
            {
                if (parent is Container)
                {
                    Container(parent).rawChildren.setChildIndex(_loc_2, (Container(parent).rawChildren.numChildren - 1));
                }
                else
                {
                    parent.setChildIndex(_loc_2, (parent.numChildren - 1));
                }
            }
            tabBar.drawFocus(param1);
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = borderMetrics;
            var _loc_4:* = viewMetrics;
            var _loc_5:* = param1 - _loc_4.left - _loc_4.right;
            var _loc_6:* = tabBarHeight + _loc_3.top;
            var _loc_7:* = tabBar.getExplicitOrMeasuredWidth();
            tabBar.setActualSize(Math.min(_loc_5, _loc_7), _loc_6);
            var _loc_8:* = getStyle("tabOffset");
            switch(getStyle("horizontalAlign"))
            {
                case "left":
                {
                    tabBar.move(0 + _loc_8, tabBar.y);
                    break;
                }
                case "right":
                {
                    tabBar.move(param1 - tabBar.width + _loc_8, tabBar.y);
                    break;
                }
                case "center":
                {
                    tabBar.move((param1 - tabBar.width) / 2 + _loc_8, tabBar.y);
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

    }
}
