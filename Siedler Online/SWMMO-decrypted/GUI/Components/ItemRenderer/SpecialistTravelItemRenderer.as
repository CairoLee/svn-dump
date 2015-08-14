package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Specialists.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class SpecialistTravelItemRenderer extends Canvas implements IBindingClient
    {
        private var _2096649492specialistRenderer:StarMenuItemRenderer;
        var _bindingsBeginWithWord:Object;
        private var _499020811specialistType:Label;
        var _watchers:Array;
        var _bindingsByDestination:Object;
        private var _520425005currentMission:CustomText;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function SpecialistTravelItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:230, height:70, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "10";
                    this.right = "5";
                    this.top = "3";
                    this.bottom = "3";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {styleName:"detailsContentBox", childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsSubContentBox", percentWidth:100, height:22, childDescriptors:[new UIComponentDescriptor({type:Label, id:"specialistType", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "20";
                            this.verticalCenter = "0";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:CustomText, id:"currentMission", stylesFactory:function () : void
                    {
                        null.color = this;
                        this.fontWeight = "normal";
                        this.textAlign = "left";
                        this.left = "50";
                        this.right = "5";
                        this.bottom = "2";
                        this.top = "24";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:StarMenuItemRenderer, id:"specialistRenderer", events:{toolTipCreate:"__specialistRenderer_toolTipCreate"}})]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 230;
            this.height = 70;
            this.addEventListener("toolTipCreate", this.___SpecialistTravelItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            var _loc_2:* = param1 as cSpecialist;
            toolTip = SPECIALIST_TYPE.toString(_loc_2.GetType());
            this.specialistRenderer.data = _loc_2;
            this.specialistType.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, SPECIALIST_TYPE.toString(_loc_2.GetType()));
            this.currentMission.text = this.CreateDescription();
            return;
        }// end function

        public function get specialistType() : Label
        {
            return this._499020811specialistType;
        }// end function

        public function get specialistRenderer() : StarMenuItemRenderer
        {
            return this._2096649492specialistRenderer;
        }// end function

        private function CreateDescription() : String
        {
            var _loc_1:* = data as cSpecialist;
            var _loc_2:String = "";
            _loc_2 = _loc_2 + (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CurrentMission") + " ");
            if (_loc_1.GetTask() && _loc_1.GetTask().GetType() == SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH)
            {
                _loc_2 = _loc_2 + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTask" + _loc_1.GetTask().GetType(), [(_loc_1.GetTask() as cSpecialistTask_FindDeposit).GetDepositToSearch_string()]);
            }
            else if (_loc_1.GetTask())
            {
                _loc_2 = _loc_2 + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTask" + _loc_1.GetTask().GetType());
            }
            else
            {
                _loc_2 = _loc_2 + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTaskNone");
            }
            if (_loc_1.GetTask() && _loc_1.GetTask().GetRemainingTime() > -1)
            {
                _loc_2 = _loc_2 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TimeRemaining") + " " + cLocaManager.GetInstance().FormatDuration(_loc_1.GetTask().GetRemainingTime()));
            }
            return _loc_2;
        }// end function

        public function get currentMission() : CustomText
        {
            return this._520425005currentMission;
        }// end function

        override public function initialize() : void
        {
            var target:SpecialistTravelItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SpecialistTravelItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_SpecialistTravelItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[null];
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

        public function set specialistType(param1:Label) : void
        {
            var _loc_2:* = this._499020811specialistType;
            if (_loc_2 !== param1)
            {
                this._499020811specialistType = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistType", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistTravelItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositCoal");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                currentMission.text = param1;
                return;
            }// end function
            , "currentMission.text");
            result[0] = binding;
            return result;
        }// end function

        public function ___SpecialistTravelItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SEND_ARMY, event, data);
            return;
        }// end function

        public function set currentMission(param1:CustomText) : void
        {
            var _loc_2:* = this._520425005currentMission;
            if (_loc_2 !== param1)
            {
                this._520425005currentMission = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentMission", _loc_2, param1));
            }
            return;
        }// end function

        public function set specialistRenderer(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._2096649492specialistRenderer;
            if (_loc_2 !== param1)
            {
                this._2096649492specialistRenderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistRenderer", _loc_2, param1));
            }
            return;
        }// end function

        public function __specialistRenderer_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SEND_ARMY, event, data);
            return;
        }// end function

        private function _SpecialistTravelItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositCoal");
            return;
        }// end function

        public function set selected(param1:Boolean) : void
        {
            if (param1)
            {
                this.specialistType.setStyle("color", 16772864);
                this.currentMission.setStyle("color", 16772864);
            }
            else
            {
                this.specialistType.setStyle("color", 16777215);
                this.currentMission.setStyle("color", 16777215);
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
