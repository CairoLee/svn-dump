package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _HorizontalListStyle extends Object
    {

        public function _HorizontalListStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("HorizontalList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("HorizontalList", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.textAlign = "center";
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
