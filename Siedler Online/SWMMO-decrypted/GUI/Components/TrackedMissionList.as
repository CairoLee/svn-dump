package GUI.Components
{
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class TrackedMissionList extends Canvas
    {
        private var _868071810topBar:Canvas;
        private var _1310946538bottomOrnamental:Image;
        private var _1683500948topOrnamental:Image;
        private var _3322014list:VBox;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental4_png_1838256238:Class;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076:Class;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function TrackedMissionList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:VBox, id:"list", stylesFactory:function () : void
                {
                    this.top = "14";
                    this.bottom = "21";
                    this.verticalGap = 0;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"topBar", stylesFactory:function () : void
                {
                    this.left = "6";
                    this.right = "6";
                    this.top = "7";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"questOrnamental", height:10};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"topOrnamental", stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "6";
                    this.bottom = "13";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:10};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"bottomOrnamental", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental4_png_1838256238};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076 = TrackedMissionList__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076;
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental4_png_1838256238 = TrackedMissionList__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental4_png_1838256238;
            mx_internal::_document = this;
            this.clipContent = false;
            return;
        }// end function

        public function set list(param1:VBox) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get topOrnamental() : Image
        {
            return this._1683500948topOrnamental;
        }// end function

        public function set bottomOrnamental(param1:Image) : void
        {
            var _loc_2:* = this._1310946538bottomOrnamental;
            if (_loc_2 !== param1)
            {
                this._1310946538bottomOrnamental = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bottomOrnamental", _loc_2, param1));
            }
            return;
        }// end function

        public function get list() : VBox
        {
            return this._3322014list;
        }// end function

        public function set topOrnamental(param1:Image) : void
        {
            var _loc_2:* = this._1683500948topOrnamental;
            if (_loc_2 !== param1)
            {
                this._1683500948topOrnamental = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "topOrnamental", _loc_2, param1));
            }
            return;
        }// end function

        public function get bottomOrnamental() : Image
        {
            return this._1310946538bottomOrnamental;
        }// end function

        public function set topBar(param1:Canvas) : void
        {
            var _loc_2:* = this._868071810topBar;
            if (_loc_2 !== param1)
            {
                this._868071810topBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "topBar", _loc_2, param1));
            }
            return;
        }// end function

        public function get topBar() : Canvas
        {
            return this._868071810topBar;
        }// end function

    }
}
