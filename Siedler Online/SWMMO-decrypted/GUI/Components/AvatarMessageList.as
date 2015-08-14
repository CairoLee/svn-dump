package GUI.Components
{
    import mx.containers.*;
    import mx.core.*;
    import mx.styles.*;

    public class AvatarMessageList extends VBox
    {
        private var _documentDescriptor_:UIComponentDescriptor;

        public function AvatarMessageList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:VBox});
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.verticalGap = this;
                return;
            }// end function
            ;
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
