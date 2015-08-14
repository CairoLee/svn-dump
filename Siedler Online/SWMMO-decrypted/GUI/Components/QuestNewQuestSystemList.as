package GUI.Components
{
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.events.*;

    public class QuestNewQuestSystemList extends Canvas
    {
        private var _1014137377QUEST_LIST_ID:DataGrid;
        private var _729616878QUEST_DROP_ID:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _871187232QUEST_SHOW_ID:Button;

        public function QuestNewQuestSystemList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:406, height:148, childDescriptors:[new UIComponentDescriptor({type:DataGrid, id:"QUEST_LIST_ID", stylesFactory:function () : void
                {
                    null.right = this;
                    this.left = "10";
                    this.bottom = "10";
                    this.top = "10";
                    this.borderStyle = "none";
                    this.color = 468010;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {columns:[_QuestNewQuestSystemList_DataGridColumn1_c(), _QuestNewQuestSystemList_DataGridColumn2_c()]};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"QUEST_SHOW_ID", stylesFactory:function () : void
                {
                    this.right = "10";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, label:"Show", width:82, height:24};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"QUEST_DROP_ID", stylesFactory:function () : void
                {
                    null.right = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, label:"Drop", width:82, height:24};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.cacheAsBitmap = true;
            this.width = 406;
            this.height = 148;
            this.styleName = "basicPanel";
            this.visible = false;
            return;
        }// end function

        private function _QuestNewQuestSystemList_DataGridColumn2_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Triggers";
            _loc_1.dataField = "triggers";
            _loc_1.width = 20;
            return _loc_1;
        }// end function

        private function _QuestNewQuestSystemList_DataGridColumn1_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Name";
            _loc_1.dataField = "name";
            _loc_1.width = 50;
            return _loc_1;
        }// end function

        public function set QUEST_SHOW_ID(param1:Button) : void
        {
            var _loc_2:* = this._871187232QUEST_SHOW_ID;
            if (_loc_2 !== param1)
            {
                this._871187232QUEST_SHOW_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_SHOW_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get QUEST_DROP_ID() : Button
        {
            return this._729616878QUEST_DROP_ID;
        }// end function

        public function get QUEST_SHOW_ID() : Button
        {
            return this._871187232QUEST_SHOW_ID;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function set QUEST_DROP_ID(param1:Button) : void
        {
            var _loc_2:* = this._729616878QUEST_DROP_ID;
            if (_loc_2 !== param1)
            {
                this._729616878QUEST_DROP_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_DROP_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set QUEST_LIST_ID(param1:DataGrid) : void
        {
            var _loc_2:* = this._1014137377QUEST_LIST_ID;
            if (_loc_2 !== param1)
            {
                this._1014137377QUEST_LIST_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_LIST_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get QUEST_LIST_ID() : DataGrid
        {
            return this._1014137377QUEST_LIST_ID;
        }// end function

    }
}
