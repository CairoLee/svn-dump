package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class AdventureDifficultyIndicator extends Canvas implements IBindingClient
    {
        private var _1211707988holder:HBox;
        private var mDifficulty:int = 0;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        public var _AdventureDifficultyIndicator_Label1:Label;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        private static const MAX:int = 10;

        public function AdventureDifficultyIndicator()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:HBox, id:"holder", stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.horizontalGap = 0;
                    this.top = "5";
                    this.bottom = "3";
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_AdventureDifficultyIndicator_Label1", stylesFactory:function () : void
                    {
                        this.color = 16777215;
                        this.fontWeight = "bold";
                        return;
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "detailsSubHeader";
            this.addEventListener("creationComplete", this.___AdventureDifficultyIndicator_Canvas1_creationComplete);
            this.addEventListener("toolTipCreate", this.___AdventureDifficultyIndicator_Canvas1_toolTipCreate);
            return;
        }// end function

        public function ___AdventureDifficultyIndicator_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.createImages();
            return;
        }// end function

        public function get difficulty() : int
        {
            return this.mDifficulty;
        }// end function

        public function get holder() : HBox
        {
            return this._1211707988holder;
        }// end function

        public function set difficulty(param1:int) : void
        {
            this.mDifficulty = param1;
            this.update();
            return;
        }// end function

        private function update() : void
        {
            toolTip = this.mDifficulty + "/" + MAX;
            var _loc_1:int = 0;
            while (_loc_1 < MAX)
            {
                
                this.holder.getChildAt((_loc_1 + 1)).alpha = _loc_1 < this.mDifficulty ? (1) : (0.3);
                _loc_1++;
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:AdventureDifficultyIndicator;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._AdventureDifficultyIndicator_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_AdventureDifficultyIndicatorWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
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

        private function createImages() : void
        {
            var _loc_2:Image = null;
            var _loc_1:int = 0;
            while (_loc_1 < MAX)
            {
                
                _loc_2 = new Image();
                _loc_2.source = gAssetManager.GetBitmap("IconSkull");
                this.holder.addChild(_loc_2);
                _loc_1++;
            }
            this.update();
            return;
        }// end function

        public function set holder(param1:HBox) : void
        {
            var _loc_2:* = this._1211707988holder;
            if (_loc_2 !== param1)
            {
                this._1211707988holder = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "holder", _loc_2, param1));
            }
            return;
        }// end function

        private function _AdventureDifficultyIndicator_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Difficulty");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_AdventureDifficultyIndicator_Label1.text");
            result[0] = binding;
            return result;
        }// end function

        private function _AdventureDifficultyIndicator_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Difficulty");
            return;
        }// end function

        public function ___AdventureDifficultyIndicator_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
