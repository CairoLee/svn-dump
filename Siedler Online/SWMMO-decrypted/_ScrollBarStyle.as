package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _ScrollBarStyle extends Object
    {

        public function _ScrollBarStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("ScrollBar");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ScrollBar", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.thumbOffset = 0;
                this.paddingTop = 0;
                this.borderColor = 12040892;
                this.trackColors = [9738651, 15198183];
                this.trackSkin = ScrollTrackSkin;
                this.downArrowSkin = ScrollArrowSkin;
                this.cornerRadius = 4;
                this.upArrowSkin = ScrollArrowSkin;
                this.paddingLeft = 0;
                this.paddingBottom = 0;
                this.thumbSkin = ScrollThumbSkin;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
