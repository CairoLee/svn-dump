package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _FormItemLabelStyle extends Object
    {

        public function _FormItemLabelStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("FormItemLabel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("FormItemLabel", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.textAlign = "right";
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
