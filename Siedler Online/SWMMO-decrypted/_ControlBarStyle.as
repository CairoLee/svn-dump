package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _ControlBarStyle extends Object
    {

        public function _ControlBarStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("ControlBar");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ControlBar", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.disabledOverlayAlpha = 0;
                this.borderStyle = "controlBar";
                this.paddingTop = 10;
                this.verticalAlign = "middle";
                this.paddingLeft = 10;
                this.paddingBottom = 10;
                this.paddingRight = 10;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
