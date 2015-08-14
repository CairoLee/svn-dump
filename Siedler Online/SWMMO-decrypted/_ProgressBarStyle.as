package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _ProgressBarStyle extends Object
    {

        public function _ProgressBarStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("ProgressBar");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ProgressBar", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.fontWeight = this;
                this.trackColors = [15198183, 16777215];
                this.leading = 0;
                this.barSkin = ProgressBarSkin;
                this.trackSkin = ProgressTrackSkin;
                this.indeterminateMoveInterval = 28;
                this.maskSkin = ProgressMaskSkin;
                this.indeterminateSkin = ProgressIndeterminateSkin;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
