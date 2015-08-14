package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _TextAreaStyle extends Object
    {

        public function _TextAreaStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("TextArea");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("TextArea", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.borderStyle = "solid";
                this.verticalScrollBarStyleName = "textAreaVScrollBarStyle";
                this.backgroundColor = 16777215;
                this.horizontalScrollBarStyleName = "textAreaHScrollBarStyle";
                this.backgroundDisabledColor = 14540253;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
