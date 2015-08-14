package GUI.Components.ItemRenderer
{
    import GUI.Assets.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;

    public class StarMenuNullItemRenderer extends Canvas implements IBindingClient
    {
        public var _StarMenuNullItemRenderer_Image1:Image;
        var _bindingsByDestination:Object;
        var _bindings:Array;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function StarMenuNullItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:56, height:68, childDescriptors:[new UIComponentDescriptor({type:Image, id:"_StarMenuNullItemRenderer_Image1", propertiesFactory:function () : Object
                {
                    return {percentWidth:100, percentHeight:100};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 56;
            this.height = 68;
            return;
        }// end function

        private function _StarMenuNullItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("StarmenuFrameEmpty");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_StarMenuNullItemRenderer_Image1.source");
            result[0] = binding;
            return result;
        }// end function

        private function _StarMenuNullItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("StarmenuFrameEmpty");
            return;
        }// end function

        override public function initialize() : void
        {
            var target:StarMenuNullItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._StarMenuNullItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_StarMenuNullItemRendererWatcherSetupUtil");
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

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
