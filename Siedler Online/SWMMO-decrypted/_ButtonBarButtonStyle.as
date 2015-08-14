package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _ButtonBarButtonStyle extends Object
    {

        public function _ButtonBarButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("ButtonBarButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ButtonBarButton", style, false);
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
                this.selectedUpSkin = null;
                this.disabledSkin = null;
                this.horizontalGap = 1;
                this.skin = ButtonBarButtonSkin;
                this.selectedOverSkin = null;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
