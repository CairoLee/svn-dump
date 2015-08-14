package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _TileListStyle extends Object
    {

        public function _TileListStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("TileList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("TileList", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.textAlign = "center";
                this.verticalAlign = "middle";
                this.paddingLeft = 2;
                this.paddingRight = 2;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
