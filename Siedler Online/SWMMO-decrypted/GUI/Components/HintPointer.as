package GUI.Components
{
    import Enums.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;

    public class HintPointer extends Canvas implements IBindingClient
    {
        private var _1565044065pointerSW:Image;
        private var _466127290pointerW:Image;
        private var _1897140728stateNE:State;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1897140573stateSE:State;
        private var _1897140710stateNW:State;
        private var _892482083stateN:State;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_w_png_70374010:Class;
        private var _798873528stateCompletedQuest:State;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_nw_png_1541265896:Class;
        var _bindingsByDestination:Object;
        private var _892482078stateS:State;
        private var _892482074stateW:State;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_n_png_53535300:Class;
        private var _892482092stateE:State;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_s_png_53483130:Class;
        private var _1854436653stateNewQuest:State;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_ne_png_1607493092:Class;
        private var _1565044047pointerSE:Image;
        private var _1565043892pointerNE:Image;
        private var _466127272pointerE:Image;
        private var _1897140555stateSW:State;
        var _bindingsBeginWithWord:Object;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_sw_png_1428413978:Class;
        private var _466127281pointerN:Image;
        private var _1565043910pointerNW:Image;
        private var _466127286pointerS:Image;
        private var _1786931073pointerNewQuest:QuestPointer;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_se_png_1463688730:Class;
        private var _embed_mxml_____data_src_gfx_embedded_hint_pointer_e_png_3203642:Class;
        var _bindings:Array;
        private var _1939490036pointerCompletedQuest:QuestPointer;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function HintPointer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas});
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_e_png_3203642 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_e_png_3203642;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_n_png_53535300 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_n_png_53535300;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_ne_png_1607493092 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_ne_png_1607493092;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_nw_png_1541265896 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_nw_png_1541265896;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_s_png_53483130 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_s_png_53483130;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_se_png_1463688730 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_se_png_1463688730;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_sw_png_1428413978 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_sw_png_1428413978;
            this._embed_mxml_____data_src_gfx_embedded_hint_pointer_w_png_70374010 = HintPointer__embed_mxml_____data_src_gfx_embedded_hint_pointer_w_png_70374010;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.minWidth = 113;
            this.minHeight = 113;
            this.states = [this._HintPointer_State1_i(), this._HintPointer_State2_i(), this._HintPointer_State3_i(), this._HintPointer_State4_i(), this._HintPointer_State5_i(), this._HintPointer_State6_i(), this._HintPointer_State7_i(), this._HintPointer_State8_i(), this._HintPointer_State9_i(), this._HintPointer_State10_i()];
            return;
        }// end function

        private function _HintPointer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestNew");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestCompleted");
            return;
        }// end function

        public function get stateNE() : State
        {
            return this._1897140728stateNE;
        }// end function

        public function set stateNE(param1:State) : void
        {
            var _loc_2:* = this._1897140728stateNE;
            if (_loc_2 !== param1)
            {
                this._1897140728stateNE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateNE", _loc_2, param1));
            }
            return;
        }// end function

        public function set pointerNewQuest(param1:QuestPointer) : void
        {
            var _loc_2:* = this._1786931073pointerNewQuest;
            if (_loc_2 !== param1)
            {
                this._1786931073pointerNewQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerNewQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateNW() : State
        {
            return this._1897140710stateNW;
        }// end function

        private function _HintPointer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestNew");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "pointerNewQuest.label");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "QuestCompleted");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                pointerCompletedQuest.label = param1;
                return;
            }// end function
            , "pointerCompletedQuest.label");
            result[1] = binding;
            return result;
        }// end function

        private function _HintPointer_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerN = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_n_png_53535300;
            _loc_1.id = "pointerN";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_Image5_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerS = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_s_png_53483130;
            _loc_1.id = "pointerS";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateN = _loc_1;
            _loc_1.name = "N";
            _loc_1.overrides = [this._HintPointer_AddChild1_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild2_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image2_i);
            return _loc_1;
        }// end function

        private function _HintPointer_State5_i() : State
        {
            var _loc_1:* = new State();
            this.stateS = _loc_1;
            _loc_1.name = "S";
            _loc_1.overrides = [this._HintPointer_AddChild5_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild6_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image6_i);
            return _loc_1;
        }// end function

        private function _HintPointer_QuestPointer2_i() : QuestPointer
        {
            var _loc_1:* = new QuestPointer();
            this.pointerCompletedQuest = _loc_1;
            _loc_1.type = "completed";
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "pointerCompletedQuest";
            BindingManager.executeBindings(this, "pointerCompletedQuest", this.pointerCompletedQuest);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_State9_i() : State
        {
            var _loc_1:* = new State();
            this.stateNewQuest = _loc_1;
            _loc_1.name = "NewQuest";
            _loc_1.overrides = [this._HintPointer_AddChild9_c()];
            return _loc_1;
        }// end function

        public function set stateNW(param1:State) : void
        {
            var _loc_2:* = this._1897140710stateNW;
            if (_loc_2 !== param1)
            {
                this._1897140710stateNW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateNW", _loc_2, param1));
            }
            return;
        }// end function

        private function _HintPointer_AddChild10_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_QuestPointer2_i);
            return _loc_1;
        }// end function

        public function get pointerSE() : Image
        {
            return this._1565044047pointerSE;
        }// end function

        public function set pointerE(param1:Image) : void
        {
            var _loc_2:* = this._466127272pointerE;
            if (_loc_2 !== param1)
            {
                this._466127272pointerE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerE", _loc_2, param1));
            }
            return;
        }// end function

        public function set stateSE(param1:State) : void
        {
            var _loc_2:* = this._1897140573stateSE;
            if (_loc_2 !== param1)
            {
                this._1897140573stateSE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateSE", _loc_2, param1));
            }
            return;
        }// end function

        public function get pointerSW() : Image
        {
            return this._1565044065pointerSW;
        }// end function

        public function set pointerN(param1:Image) : void
        {
            var _loc_2:* = this._466127281pointerN;
            if (_loc_2 !== param1)
            {
                this._466127281pointerN = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerN", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateCompletedQuest() : State
        {
            return this._798873528stateCompletedQuest;
        }// end function

        private function _HintPointer_Image4_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerSE = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_se_png_1463688730;
            _loc_1.id = "pointerSE";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_Image8_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerNW = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_nw_png_1541265896;
            _loc_1.id = "pointerNW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set stateSW(param1:State) : void
        {
            var _loc_2:* = this._1897140555stateSW;
            if (_loc_2 !== param1)
            {
                this._1897140555stateSW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateSW", _loc_2, param1));
            }
            return;
        }// end function

        private function _HintPointer_AddChild1_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image1_i);
            return _loc_1;
        }// end function

        public function set pointerS(param1:Image) : void
        {
            var _loc_2:* = this._466127286pointerS;
            if (_loc_2 !== param1)
            {
                this._466127286pointerS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerS", _loc_2, param1));
            }
            return;
        }// end function

        public function set pointerW(param1:Image) : void
        {
            var _loc_2:* = this._466127290pointerW;
            if (_loc_2 !== param1)
            {
                this._466127290pointerW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerW", _loc_2, param1));
            }
            return;
        }// end function

        private function _HintPointer_State4_i() : State
        {
            var _loc_1:* = new State();
            this.stateSE = _loc_1;
            _loc_1.name = "SE";
            _loc_1.overrides = [this._HintPointer_AddChild4_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild5_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image5_i);
            return _loc_1;
        }// end function

        public function set pointerNE(param1:Image) : void
        {
            var _loc_2:* = this._1565043892pointerNE;
            if (_loc_2 !== param1)
            {
                this._1565043892pointerNE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerNE", _loc_2, param1));
            }
            return;
        }// end function

        private function _HintPointer_QuestPointer1_i() : QuestPointer
        {
            var _loc_1:* = new QuestPointer();
            this.pointerNewQuest = _loc_1;
            _loc_1.type = "normal";
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "pointerNewQuest";
            BindingManager.executeBindings(this, "pointerNewQuest", this.pointerNewQuest);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_State8_i() : State
        {
            var _loc_1:* = new State();
            this.stateNW = _loc_1;
            _loc_1.name = "NW";
            _loc_1.overrides = [this._HintPointer_AddChild8_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild9_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_QuestPointer1_i);
            return _loc_1;
        }// end function

        public function get pointerNewQuest() : QuestPointer
        {
            return this._1786931073pointerNewQuest;
        }// end function

        override public function initialize() : void
        {
            var target:HintPointer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._HintPointer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_HintPointerWatcherSetupUtil");
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

        public function set pointerNW(param1:Image) : void
        {
            var _loc_2:* = this._1565043910pointerNW;
            if (_loc_2 !== param1)
            {
                this._1565043910pointerNW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerNW", _loc_2, param1));
            }
            return;
        }// end function

        public function set pointerSE(param1:Image) : void
        {
            var _loc_2:* = this._1565044047pointerSE;
            if (_loc_2 !== param1)
            {
                this._1565044047pointerSE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerSE", _loc_2, param1));
            }
            return;
        }// end function

        public function set stateCompletedQuest(param1:State) : void
        {
            var _loc_2:* = this._798873528stateCompletedQuest;
            if (_loc_2 !== param1)
            {
                this._798873528stateCompletedQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateCompletedQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateSE() : State
        {
            return this._1897140573stateSE;
        }// end function

        public function get pointerE() : Image
        {
            return this._466127272pointerE;
        }// end function

        public function set stateNewQuest(param1:State) : void
        {
            var _loc_2:* = this._1854436653stateNewQuest;
            if (_loc_2 !== param1)
            {
                this._1854436653stateNewQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateNewQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function set stateE(param1:State) : void
        {
            var _loc_2:* = this._892482092stateE;
            if (_loc_2 !== param1)
            {
                this._892482092stateE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateE", _loc_2, param1));
            }
            return;
        }// end function

        private function _HintPointer_Image3_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerE = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_e_png_3203642;
            _loc_1.id = "pointerE";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _HintPointer_State7_i() : State
        {
            var _loc_1:* = new State();
            this.stateW = _loc_1;
            _loc_1.name = "W";
            _loc_1.overrides = [this._HintPointer_AddChild7_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild8_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image8_i);
            return _loc_1;
        }// end function

        public function get pointerW() : Image
        {
            return this._466127290pointerW;
        }// end function

        private function _HintPointer_State3_i() : State
        {
            var _loc_1:* = new State();
            this.stateE = _loc_1;
            _loc_1.name = "E";
            _loc_1.overrides = [this._HintPointer_AddChild3_c()];
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild4_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image4_i);
            return _loc_1;
        }// end function

        public function get pointerN() : Image
        {
            return this._466127281pointerN;
        }// end function

        public function set stateN(param1:State) : void
        {
            var _loc_2:* = this._892482083stateN;
            if (_loc_2 !== param1)
            {
                this._892482083stateN = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateN", _loc_2, param1));
            }
            return;
        }// end function

        public function set pointerSW(param1:Image) : void
        {
            var _loc_2:* = this._1565044065pointerSW;
            if (_loc_2 !== param1)
            {
                this._1565044065pointerSW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerSW", _loc_2, param1));
            }
            return;
        }// end function

        public function get pointerNE() : Image
        {
            return this._1565043892pointerNE;
        }// end function

        public function set stateS(param1:State) : void
        {
            var _loc_2:* = this._892482078stateS;
            if (_loc_2 !== param1)
            {
                this._892482078stateS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateS", _loc_2, param1));
            }
            return;
        }// end function

        public function get pointerS() : Image
        {
            return this._466127286pointerS;
        }// end function

        private function _HintPointer_Image7_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerW = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_w_png_70374010;
            _loc_1.id = "pointerW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get pointerNW() : Image
        {
            return this._1565043910pointerNW;
        }// end function

        private function _HintPointer_State10_i() : State
        {
            var _loc_1:* = new State();
            this.stateCompletedQuest = _loc_1;
            _loc_1.name = "CompletedQuest";
            _loc_1.overrides = [this._HintPointer_AddChild10_c()];
            return _loc_1;
        }// end function

        public function get stateE() : State
        {
            return this._892482092stateE;
        }// end function

        public function get stateSW() : State
        {
            return this._1897140555stateSW;
        }// end function

        public function get stateN() : State
        {
            return this._892482083stateN;
        }// end function

        public function set stateW(param1:State) : void
        {
            var _loc_2:* = this._892482074stateW;
            if (_loc_2 !== param1)
            {
                this._892482074stateW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateW", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateW() : State
        {
            return this._892482074stateW;
        }// end function

        private function _HintPointer_Image2_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerNE = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_ne_png_1607493092;
            _loc_1.id = "pointerNE";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get stateNewQuest() : State
        {
            return this._1854436653stateNewQuest;
        }// end function

        private function _HintPointer_Image6_i() : Image
        {
            var _loc_1:* = new Image();
            this.pointerSW = _loc_1;
            _loc_1.source = this._embed_mxml_____data_src_gfx_embedded_hint_pointer_sw_png_1428413978;
            _loc_1.id = "pointerSW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set pointerCompletedQuest(param1:QuestPointer) : void
        {
            var _loc_2:* = this._1939490036pointerCompletedQuest;
            if (_loc_2 !== param1)
            {
                this._1939490036pointerCompletedQuest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pointerCompletedQuest", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateS() : State
        {
            return this._892482078stateS;
        }// end function

        private function _HintPointer_AddChild3_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image3_i);
            return _loc_1;
        }// end function

        private function _HintPointer_AddChild7_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._HintPointer_Image7_i);
            return _loc_1;
        }// end function

        private function _HintPointer_State2_i() : State
        {
            var _loc_1:* = new State();
            this.stateNE = _loc_1;
            _loc_1.name = "NE";
            _loc_1.overrides = [this._HintPointer_AddChild2_c()];
            return _loc_1;
        }// end function

        public function get pointerCompletedQuest() : QuestPointer
        {
            return this._1939490036pointerCompletedQuest;
        }// end function

        private function _HintPointer_State6_i() : State
        {
            var _loc_1:* = new State();
            this.stateSW = _loc_1;
            _loc_1.name = "SW";
            _loc_1.overrides = [this._HintPointer_AddChild6_c()];
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
