package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import mx.controls.tabBarClasses.*;
    import mx.core.*;

    public class TabBar extends ToggleButtonBar
    {
        static const VERSION:String = "3.5.0.12683";
        static var createAccessibilityImplementation:Function;

        public function TabBar()
        {
            buttonHeightProp = "tabHeight";
            buttonStyleNameProp = "tabStyleName";
            firstButtonStyleNameProp = "firstTabStyleName";
            lastButtonStyleNameProp = "lastTabStyleName";
            buttonWidthProp = "tabWidth";
            navItemFactory = new ClassFactory(Tab);
            selectedButtonTextStyleNameProp = "selectedTabTextStyleName";
            return;
        }// end function

        override protected function clickHandler(event:MouseEvent) : void
        {
            if (getChildIndex(DisplayObject(event.currentTarget)) == selectedIndex)
            {
                Button(event.currentTarget).selected = true;
                event.stopImmediatePropagation();
                return;
            }
            super.clickHandler(event);
            return;
        }// end function

        override protected function createNavItem(param1:String, param2:Class = null) : IFlexDisplayObject
        {
            var _loc_3:* = super.createNavItem(param1, param2);
            DisplayObject(_loc_3).addEventListener(MouseEvent.MOUSE_DOWN, tab_mouseDownHandler);
            DisplayObject(_loc_3).addEventListener(MouseEvent.DOUBLE_CLICK, tab_doubleClickHandler);
            return _loc_3;
        }// end function

        private function tab_doubleClickHandler(event:MouseEvent) : void
        {
            Button(event.currentTarget).selected = true;
            return;
        }// end function

        private function tab_mouseDownHandler(event:MouseEvent) : void
        {
            selectButton(event.currentTarget.parent.getChildIndex(event.currentTarget), true, event);
            return;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (TabBar.createAccessibilityImplementation != null)
            {
                TabBar.createAccessibilityImplementation(this);
            }
            return;
        }// end function

    }
}
