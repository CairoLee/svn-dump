package GUI.Components.ItemRenderer
{
    import mx.controls.*;
    import mx.styles.*;

    public class GuildLogItemRenderer extends Text
    {

        public function GuildLogItemRenderer()
        {
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.paddingLeft = this;
                this.paddingTop = -2;
                this.paddingBottom = -5;
                return;
            }// end function
            ;
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

    }
}
