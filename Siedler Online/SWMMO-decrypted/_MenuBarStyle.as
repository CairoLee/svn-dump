package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _MenuBarStyle extends Object
    {

        public function _MenuBarStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("MenuBar");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("MenuBar", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.itemSkin = ActivatorSkin;
                this.backgroundSkin = MenuBarBackgroundSkin;
                this.translucent = false;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
