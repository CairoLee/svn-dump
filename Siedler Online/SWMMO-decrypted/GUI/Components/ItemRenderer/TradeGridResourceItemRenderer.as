package GUI.Components.ItemRenderer
{
    import mx.containers.*;
    import mx.controls.dataGridClasses.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;

    public class TradeGridResourceItemRenderer extends Canvas implements IDropInListItemRenderer
    {
        private var _listData:BaseListData;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _494845757renderer:TradeResourceItemRenderer;

        public function TradeGridResourceItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:26, childDescriptors:[new UIComponentDescriptor({type:TradeResourceItemRenderer, id:"renderer", propertiesFactory:function () : Object
                {
                    return {null:10};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.height = 26;
            this.clipContent = false;
            return;
        }// end function

        public function get renderer() : TradeResourceItemRenderer
        {
            return this._494845757renderer;
        }// end function

        public function get listData() : BaseListData
        {
            return this._listData;
        }// end function

        public function set renderer(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._494845757renderer;
            if (_loc_2 !== param1)
            {
                this._494845757renderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "renderer", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            this.renderer.data = param1[DataGridListData(this.listData).dataField];
            return;
        }// end function

        public function set listData(param1:BaseListData) : void
        {
            this._listData = param1;
            return;
        }// end function

    }
}
