package GUI.Components
{
    import mx.containers.*;
    import mx.core.*;
    import mx.styles.*;

    public class DarkenPanel extends Canvas
    {
        private var _documentDescriptor_:UIComponentDescriptor;

        public function DarkenPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas});
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.backgroundColor = 0;
                this.backgroundAlpha = 0.7;
                return;
            }// end function
            ;
            this.percentWidth = 100;
            this.percentHeight = 100;
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

    }
}
