package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _DataGridItemRendererStyle extends Object
    {

        public function _DataGridItemRendererStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("DataGridItemRenderer");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("DataGridItemRenderer", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.paddingLeft = this;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
