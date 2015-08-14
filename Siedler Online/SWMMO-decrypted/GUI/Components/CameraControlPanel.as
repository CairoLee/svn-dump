package GUI.Components
{
    import GUI.Assets.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class CameraControlPanel extends Canvas implements IBindingClient
    {
        private var _embed_mxml_____data_src_gfx_embedded_camera_x_mouseover_png_1471468292:Class;
        private var _1282133823fadeIn:Fade;
        private var _94069271btnUp:Button;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_down_inactive_png_1191392378:Class;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_up_standard_png_1322523128:Class;
        private var _embed_mxml_____data_src_gfx_embedded_camera_x_standard_png_415922918:Class;
        var _watchers:Array;
        private var _205980803btnLeft:Button;
        private var _1091436750fadeOut:Fade;
        private var _embed_mxml_____data_src_gfx_embedded_camera_x_push_png_391842408:Class;
        private var _2096098592btnRight:Button;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_up_inactive_png_1188403324:Class;
        var _bindingsByDestination:Object;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_down_standard_png_1090626554:Class;
        var _bindingsBeginWithWord:Object;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_down_mouseover_png_588260904:Class;
        private var _2082343164btnClose:Button;
        private var _embed_mxml_____data_src_gfx_embedded_camera_scale_up_mouseover_png_824826854:Class;
        private var _789363156btnZoomIn:Button;
        private var _1299539841btnZoomOut:Button;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _205752606btnDown:Button;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function CameraControlPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:67, height:128, childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnClose", stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_camera_x_push_png_391842408;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_camera_x_mouseover_png_1471468292;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_camera_x_standard_png_415922918;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {x:50, y:3, width:13, height:13};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnUp", propertiesFactory:function () : Object
                {
                    return {x:23, y:19, width:22, height:22};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnLeft", propertiesFactory:function () : Object
                {
                    return {null:null, y:37, width:22, height:22};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnRight", propertiesFactory:function () : Object
                {
                    return {null:41, y:37, width:22, height:22};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnDown", propertiesFactory:function () : Object
                {
                    return {x:23, y:55, width:22, height:22};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnZoomIn", stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_up_mouseover_png_824826854;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_up_mouseover_png_824826854;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_up_inactive_png_1188403324;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:5, y:77, width:30, height:31};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnZoomOut", stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_down_mouseover_png_588260904;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_down_mouseover_png_588260904;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_camera_scale_down_inactive_png_1191392378;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, y:77, width:30, height:31};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_down_inactive_png_1191392378 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_down_inactive_png_1191392378;
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_down_mouseover_png_588260904 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_down_mouseover_png_588260904;
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_down_standard_png_1090626554 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_down_standard_png_1090626554;
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_up_inactive_png_1188403324 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_up_inactive_png_1188403324;
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_up_mouseover_png_824826854 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_up_mouseover_png_824826854;
            this._embed_mxml_____data_src_gfx_embedded_camera_scale_up_standard_png_1322523128 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_scale_up_standard_png_1322523128;
            this._embed_mxml_____data_src_gfx_embedded_camera_x_mouseover_png_1471468292 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_x_mouseover_png_1471468292;
            this._embed_mxml_____data_src_gfx_embedded_camera_x_push_png_391842408 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_x_push_png_391842408;
            this._embed_mxml_____data_src_gfx_embedded_camera_x_standard_png_415922918 = CameraControlPanel__embed_mxml_____data_src_gfx_embedded_camera_x_standard_png_415922918;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "cameraControlPanel";
            this.cacheAsBitmap = true;
            this.width = 67;
            this.height = 128;
            this._CameraControlPanel_Fade1_i();
            this._CameraControlPanel_Fade2_i();
            return;
        }// end function

        public function set fadeIn(param1:Fade) : void
        {
            var _loc_2:* = this._1282133823fadeIn;
            if (_loc_2 !== param1)
            {
                this._1282133823fadeIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeIn", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnZoomOut(param1:Button) : void
        {
            var _loc_2:* = this._1299539841btnZoomOut;
            if (_loc_2 !== param1)
            {
                this._1299539841btnZoomOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnZoomOut", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnLeft() : Button
        {
            return this._205980803btnLeft;
        }// end function

        public function get btnClose() : Button
        {
            return this._2082343164btnClose;
        }// end function

        override public function initialize() : void
        {
            var target:CameraControlPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._CameraControlPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_CameraControlPanelWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return target[param1];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        public function set btnLeft(param1:Button) : void
        {
            var _loc_2:* = this._205980803btnLeft;
            if (_loc_2 !== param1)
            {
                this._205980803btnLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnDown() : Button
        {
            return this._205752606btnDown;
        }// end function

        public function get btnUp() : Button
        {
            return this._94069271btnUp;
        }// end function

        public function get btnRight() : Button
        {
            return this._2096098592btnRight;
        }// end function

        private function _CameraControlPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function _CameraControlPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = gAssetManager.GetClass("ArrowSmallNUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallNOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallNOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallNUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallWUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallWOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallWOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallWUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallEUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallEOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallEOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallEUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallSUp");
            _loc_1 = gAssetManager.GetClass("ArrowSmallSOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallSOver");
            _loc_1 = gAssetManager.GetClass("ArrowSmallSUp");
            return;
        }// end function

        public function set btnUp(param1:Button) : void
        {
            var _loc_2:* = this._94069271btnUp;
            if (_loc_2 !== param1)
            {
                this._94069271btnUp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnUp", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnZoomIn(param1:Button) : void
        {
            var _loc_2:* = this._789363156btnZoomIn;
            if (_loc_2 !== param1)
            {
                this._789363156btnZoomIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnZoomIn", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnDown(param1:Button) : void
        {
            var _loc_2:* = this._205752606btnDown;
            if (_loc_2 !== param1)
            {
                this._205752606btnDown = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnDown", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnRight(param1:Button) : void
        {
            var _loc_2:* = this._2096098592btnRight;
            if (_loc_2 !== param1)
            {
                this._2096098592btnRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRight", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get btnZoomIn() : Button
        {
            return this._789363156btnZoomIn;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set fadeOut(param1:Fade) : void
        {
            var _loc_2:* = this._1091436750fadeOut;
            if (_loc_2 !== param1)
            {
                this._1091436750fadeOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOut", _loc_2, param1));
            }
            return;
        }// end function

        private function _CameraControlPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set btnClose(param1:Button) : void
        {
            var _loc_2:* = this._2082343164btnClose;
            if (_loc_2 !== param1)
            {
                this._2082343164btnClose = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClose", _loc_2, param1));
            }
            return;
        }// end function

        private function _CameraControlPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallNUp");
            }// end function
            , function (param1:Class) : void
            {
                btnUp.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnUp.upSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallNOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnUp.downSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnUp.overSkin");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowSmallNUp");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnUp.disabledSkin");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallWUp");
            }// end function
            , function (param1:Class) : void
            {
                btnLeft.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnLeft.upSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowSmallWOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnLeft.downSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowSmallWOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnLeft.overSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnLeft.disabledSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnRight.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnRight.upSkin");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallEOver");
            }// end function
            , function (param1:Class) : void
            {
                btnRight.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnRight.downSkin");
            result[11] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRight.overSkin");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallEUp");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRight.disabledSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnDown.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnDown.upSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallSOver");
            }// end function
            , function (param1:Class) : void
            {
                btnDown.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnDown.downSkin");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowSmallSOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnDown.overSkin");
            result[16] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowSmallSUp");
            }// end function
            , function (param1:Class) : void
            {
                btnDown.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnDown.disabledSkin");
            result[17] = binding;
            return result;
        }// end function

        public function get btnZoomOut() : Button
        {
            return this._1299539841btnZoomOut;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            CameraControlPanel._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
