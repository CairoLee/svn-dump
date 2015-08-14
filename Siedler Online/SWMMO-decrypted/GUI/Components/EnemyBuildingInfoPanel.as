package GUI.Components
{
    import GUI.Components.ItemRenderer.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class EnemyBuildingInfoPanel extends BasicPanel
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _455005011unitsList:TileList;
        private var _1724546052description:Text;
        private var _100313435image:Image;
        private var _824652908listBackground:Canvas;

        public function EnemyBuildingInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:275, height:248};
            }// end function
            });
            mx_internal::_document = this;
            this.width = 275;
            this.height = 248;
            this.subComponents = [this._EnemyBuildingInfoPanel_Canvas1_c(), this._EnemyBuildingInfoPanel_Canvas2_c()];
            return;
        }// end function

        private function _EnemyBuildingInfoPanel_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.image = _loc_1;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("verticalCenter", "1");
            _loc_1.id = "image";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _EnemyBuildingInfoPanel_TileList1_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.unitsList = _loc_1;
            _loc_1.selectable = false;
            _loc_1.itemRenderer = this._EnemyBuildingInfoPanel_ClassFactory1_c();
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "2");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "5");
            _loc_1.id = "unitsList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        private function _EnemyBuildingInfoPanel_Canvas1_c() : Canvas
        {
            var _loc_1:Canvas = null;
            _loc_1 = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 60;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._EnemyBuildingInfoPanel_Image1_i());
            _loc_1.addChild(this._EnemyBuildingInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        private function _EnemyBuildingInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("right", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._EnemyBuildingInfoPanel_Canvas3_i());
            _loc_1.addChild(this._EnemyBuildingInfoPanel_TileList1_i());
            return _loc_1;
        }// end function

        public function set unitsList(param1:TileList) : void
        {
            var _loc_2:* = this._455005011unitsList;
            if (_loc_2 !== param1)
            {
                this._455005011unitsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "unitsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        private function _EnemyBuildingInfoPanel_Canvas3_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.listBackground = _loc_1;
            _loc_1.styleName = "listBackgroundShadow";
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.id = "listBackground";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set listBackground(param1:Canvas) : void
        {
            var _loc_2:* = this._824652908listBackground;
            if (_loc_2 !== param1)
            {
                this._824652908listBackground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "listBackground", _loc_2, param1));
            }
            return;
        }// end function

        public function get unitsList() : TileList
        {
            return this._455005011unitsList;
        }// end function

        private function _EnemyBuildingInfoPanel_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.description = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "70");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "6");
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "description";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public function set description(param1:Text) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        public function get listBackground() : Canvas
        {
            return this._824652908listBackground;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        private function _EnemyBuildingInfoPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = WarehouseDetailsItemRenderer;
            return _loc_1;
        }// end function

    }
}
