package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _FormStyle extends Object
    {

        public function _FormStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("Form");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Form", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.paddingTop = 16;
                this.verticalGap = 6;
                this.paddingLeft = 16;
                this.paddingBottom = 16;
                this.paddingRight = 16;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
