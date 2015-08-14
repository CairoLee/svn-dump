package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _titleTextStyleStyle extends Object
    {

        public function _titleTextStyleStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".titleTextStyle");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".titleTextStyle", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.color = this;
                this.alpha = 0.6;
                this.fontSize = 9;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
