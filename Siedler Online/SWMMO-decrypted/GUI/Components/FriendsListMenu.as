package GUI.Components
{
    import mx.containers.*;
    import mx.core.*;
    import mx.styles.*;

    public class FriendsListMenu extends VBox
    {
        private var _documentDescriptor_:UIComponentDescriptor;

        public function FriendsListMenu()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:VBox, propertiesFactory:function () : Object
            {
                return {null:null};
            }// end function
            });
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.borderStyle = "solid";
                this.borderThickness = 0;
                this.backgroundColor = 4601379;
                this.paddingLeft = 1;
                this.paddingRight = 1;
                this.paddingTop = 1;
                this.paddingBottom = 1;
                this.verticalGap = 1;
                return;
            }// end function
            ;
            this.width = 140;
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
