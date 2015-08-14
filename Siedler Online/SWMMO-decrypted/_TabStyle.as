package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _TabStyle extends Object
    {

        public function _TabStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("Tab");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Tab", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.upSkin = this;
                this.selectedDownSkin = null;
                this.overSkin = null;
                this.downSkin = null;
                this.selectedDisabledSkin = null;
                this.paddingTop = 1;
                this.selectedUpSkin = null;
                this.disabledSkin = null;
                this.skin = TabSkin;
                this.paddingBottom = 1;
                this.selectedOverSkin = null;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
