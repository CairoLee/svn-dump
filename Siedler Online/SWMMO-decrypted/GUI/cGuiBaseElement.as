package GUI
{
    import flash.geom.*;
    import mx.core.*;

    public class cGuiBaseElement extends Object
    {
        protected var mUiElement:UIComponent = null;
        static var mGuiElements:Array = null;

        public function cGuiBaseElement()
        {
            return;
        }// end function

        public function Hide() : void
        {
            this.mUiElement.visible = false;
            return;
        }// end function

        public function IsVisible() : Boolean
        {
            return this.mUiElement.visible;
        }// end function

        protected function AddBaseElement(param1:UIComponent) : void
        {
            this.mUiElement = param1;
            mGuiElements.push(param1);
            return;
        }// end function

        public function Show() : void
        {
            this.mUiElement.visible = true;
            return;
        }// end function

        public function PositionIsOverGuiElement() : Boolean
        {
            if (this.mUiElement == null)
            {
                return false;
            }
            var _loc_1:* = this.mUiElement.getObjectsUnderPoint(new Point(Application.application.mouseX, Application.application.mouseY));
            if (_loc_1.length > 0)
            {
                return true;
            }
            return false;
        }// end function

        public static function SetEnableStateForAllGuiElements(param1:Boolean) : void
        {
            var _loc_2:UIComponent = null;
            for each (_loc_2 in mGuiElements)
            {
                
                _loc_2.enabled = param1;
            }
            return;
        }// end function

        public static function SetVisibleStateForAllGuiElements(param1:Boolean) : void
        {
            var _loc_2:UIComponent = null;
            for each (_loc_2 in mGuiElements)
            {
                
                _loc_2.visible = param1;
            }
            return;
        }// end function

        public static function InitStatic() : void
        {
            mGuiElements = new Array();
            return;
        }// end function

    }
}
