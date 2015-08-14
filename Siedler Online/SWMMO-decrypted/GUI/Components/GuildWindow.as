package GUI.Components
{
    import Communication.VO.Guild.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.DataGrid.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.events.*;

    public class GuildWindow extends BasicPanel implements IBindingClient
    {
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_n_sel_png_616187438:Class;
        private var _1166766325btnDiscardRankChanges:StandardButton;
        private var _11548545buttonBar:CustomToggleButtonBar;
        private var _1102566131btnFoundGuild:StandardButton;
        private var _912210348btnBannerRight:Button;
        private var _3387378note:TextEditor;
        private var _1191282484leaderName:Label;
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_s_non_png_1151518270:Class;
        private var _1527062846btnSaveRankChanges:StandardButton;
        private var _297427883btnMyGuild:StandardButton;
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_n_non_png_634470444:Class;
        private var _1366077706memberLevel:Label;
        public var _GuildWindow_FormItem1:FormItem;
        public var _GuildWindow_FormItem2:FormItem;
        public var _GuildWindow_FormItem3:FormItem;
        public var _GuildWindow_FormItem4:FormItem;
        private var _2100227641subcontent:ViewStack;
        private var _2035397994btnRankDown:Button;
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_s_std_png_632473566:Class;
        private var _625449086btnSaveBannerChanges:StandardButton;
        private var _657959364rankName3:TextInput;
        public var _GuildWindow_Label10:Label;
        public var _GuildWindow_Label2:Label;
        public var _GuildWindow_Label12:Label;
        public var _GuildWindow_Label13:Label;
        public var _GuildWindow_Label14:Label;
        public var _GuildWindow_Label15:Label;
        public var _GuildWindow_Label1:Label;
        public var _GuildWindow_Label11:Label;
        public var _GuildWindow_Label4:Label;
        public var _GuildWindow_Label5:Label;
        public var _GuildWindow_Label6:Label;
        private var _877658884btnBackToList:StandardButton;
        private var _2022123915btnDiscardBannerChanges:StandardButton;
        private var _2008041410leaderAvatar:AvatarListItemRenderer;
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_s_sel_png_706929712:Class;
        private var _206006835btnMail:StandardButton;
        private var _1875133630btnIncrease:StandardButton;
        private var _339347977guildDescription:TextEditor;
        private var _657959366rankName1:TextInput;
        private var _1356381607selectedBanner:Image;
        private var _1255702622administration:Canvas;
        var _bindingsByDestination:Object;
        public var _GuildWindow_DataGridColumn1:DataGridColumn;
        public var _GuildWindow_DataGridColumn2:DataGridColumn;
        public var _GuildWindow_DataGridColumn3:DataGridColumn;
        public var _GuildWindow_DataGridColumn5:DataGridColumn;
        public var _GuildWindow_DataGridColumn6:DataGridColumn;
        public var _GuildWindow_DataGridColumn4:DataGridColumn;
        private var _1306556847guildLog:List;
        private var _971126009guildDetailsStack:ViewStack;
        private var _3357586motd:TextEditor;
        private var _1848561871guildList:CustomDataGrid;
        private var _1341231642memberRank:Label;
        private var _547369315btnRankUp:Button;
        private var _1848646847guildInfo:Text;
        private var _301950085btnInvite:StandardButton;
        private var _1160105400officerNote:TextEditor;
        private var _657959363rankName4:TextInput;
        private var _embed_mxml_____data_src_gfx_embedded_guild_arrow_n_std_png_47867872:Class;
        private var _205954754btnKick:StandardButton;
        private var _1396342996banner:Image;
        private var _2090432955btnLeave:StandardButton;
        private var _1401338199membersList:CustomDataGrid;
        private var _901096301memberAvatar:AvatarListItemRenderer;
        var _watchers:Array;
        private var _1090881890btnNextPage:StandardButton;
        private var _657959365rankName2:TextInput;
        public var rankMappings:Object;
        private var _1341350843memberName:Label;
        var _bindings:Array;
        private var _29608753btnBannerLeft:Button;
        private var _505277918btnPrevPage:StandardButton;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindingsBeginWithWord:Object;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function GuildWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {width:600, height:537};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_non_png_634470444 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_n_non_png_634470444;
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_sel_png_616187438 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_n_sel_png_616187438;
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_std_png_47867872 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_n_std_png_47867872;
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_non_png_1151518270 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_s_non_png_1151518270;
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_sel_png_706929712 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_s_sel_png_706929712;
            this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_std_png_632473566 = GuildWindow__embed_mxml_____data_src_gfx_embedded_guild_arrow_s_std_png_632473566;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 600;
            this.height = 537;
            this.subComponents = [this._GuildWindow_ViewStack1_i()];
            return;
        }// end function

        private function _GuildWindow_Label3_i() : Label
        {
            var _loc_1:* = new Label();
            this.leaderName = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "35");
            _loc_1.id = "leaderName";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "25");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __memberRank_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get guildDescription() : TextEditor
        {
            return this._339347977guildDescription;
        }// end function

        private function _GuildWindow_Label12_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label12 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label12";
            BindingManager.executeBindings(this, "_GuildWindow_Label12", this._GuildWindow_Label12);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnDiscardRankChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._1166766325btnDiscardRankChanges;
            if (_loc_2 !== param1)
            {
                this._1166766325btnDiscardRankChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnDiscardRankChanges", _loc_2, param1));
            }
            return;
        }// end function

        public function set note(param1:TextEditor) : void
        {
            var _loc_2:* = this._3387378note;
            if (_loc_2 !== param1)
            {
                this._3387378note = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "note", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.guildInfo = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.selectable = false;
            _loc_1.setStyle("paddingRight", 10);
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "guildInfo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = [];
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Guild");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildTag");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildPlayerCount");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMy");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildFound");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInvite");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMail");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLeave");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildIncreaseSize");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildList");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInfo");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLeader");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDescription");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLog");
            _loc_1 = [];
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMember");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLevel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMemberDetails");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildCurrentAdventures");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildOfficerNote");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildNote");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildKick");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEditRanks");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 1";
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 2";
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 3";
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 4";
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Save");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Discard");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEdit");
            _loc_1 = gAssetManager.GetClass("ArrowLeft");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftDisabled");
            _loc_1 = gAssetManager.GetClass("ArrowRight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightDisabled");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Save");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Discard");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEditDetails");
            return;
        }// end function

        public function set guildDescription(param1:TextEditor) : void
        {
            var _loc_2:* = this._339347977guildDescription;
            if (_loc_2 !== param1)
            {
                this._339347977guildDescription = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildDescription", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas25_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 200;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas26_c());
            _loc_1.addChild(this._GuildWindow_Canvas27_c());
            _loc_1.addChild(this._GuildWindow_Canvas28_c());
            _loc_1.addChild(this._GuildWindow_Canvas29_c());
            _loc_1.addChild(this._GuildWindow_Canvas30_c());
            _loc_1.addChild(this._GuildWindow_TextEditor3_i());
            _loc_1.addChild(this._GuildWindow_Canvas31_c());
            _loc_1.addChild(this._GuildWindow_TextEditor4_i());
            _loc_1.addChild(this._GuildWindow_Canvas32_c());
            return _loc_1;
        }// end function

        public function set memberLevel(param1:Label) : void
        {
            var _loc_2:* = this._1366077706memberLevel;
            if (_loc_2 !== param1)
            {
                this._1366077706memberLevel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "memberLevel", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_DataGridColumn4_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn4 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 170;
            _loc_1.dataField = "username";
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory5_c();
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn4", this._GuildWindow_DataGridColumn4);
            return _loc_1;
        }// end function

        public function formatRanks(param1:Object, param2:DataGridColumn) : String
        {
            var _loc_3:* = param1[param2.dataField];
            return (this.rankMappings[_loc_3] as dGuildRankListItemVO).name;
        }// end function

        public function set memberRank(param1:Label) : void
        {
            var _loc_2:* = this._1341231642memberRank;
            if (_loc_2 !== param1)
            {
                this._1341231642memberRank = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "memberRank", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFoundGuild(param1:StandardButton) : void
        {
            var _loc_2:* = this._1102566131btnFoundGuild;
            if (_loc_2 !== param1)
            {
                this._1102566131btnFoundGuild = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFoundGuild", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas40_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "238");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas41_c());
            _loc_1.addChild(this._GuildWindow_Button3_i());
            _loc_1.addChild(this._GuildWindow_Button4_i());
            _loc_1.addChild(this._GuildWindow_Canvas42_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_FormItem3_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._GuildWindow_FormItem3 = _loc_1;
            _loc_1.setStyle("labelStyleName", "labelLeft");
            _loc_1.id = "_GuildWindow_FormItem3";
            BindingManager.executeBindings(this, "_GuildWindow_FormItem3", this._GuildWindow_FormItem3);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_TextInput3_i());
            return _loc_1;
        }// end function

        public function set guildDetailsStack(param1:ViewStack) : void
        {
            var _loc_2:* = this._971126009guildDetailsStack;
            if (_loc_2 !== param1)
            {
                this._971126009guildDetailsStack = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildDetailsStack", _loc_2, param1));
            }
            return;
        }// end function

        public function __memberName_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _GuildWindow_Button3_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnBannerLeft = _loc_1;
            _loc_1.width = 25;
            _loc_1.height = 23;
            _loc_1.setStyle("left", "20");
            _loc_1.setStyle("top", "60");
            _loc_1.id = "btnBannerLeft";
            BindingManager.executeBindings(this, "btnBannerLeft", this.btnBannerLeft);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_StandardButton6_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnMail = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("top", "307");
            _loc_1.id = "btnMail";
            BindingManager.executeBindings(this, "btnMail", this.btnMail);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get note() : TextEditor
        {
            return this._3387378note;
        }// end function

        private function _GuildWindow_Canvas13_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 100;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "106");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas14_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas36_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label13_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_TextInput3_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.rankName3 = _loc_1;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.maxChars = 32;
            _loc_1.restrict = "^\\\\";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.setStyle("paddingTop", 3);
            _loc_1.setStyle("paddingLeft", 3);
            _loc_1.setStyle("paddingRight", 3);
            _loc_1.id = "rankName3";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get rankName3() : TextInput
        {
            return this._657959364rankName3;
        }// end function

        private function _GuildWindow_ClassFactory7_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function get subcontent() : ViewStack
        {
            return this._2100227641subcontent;
        }// end function

        public function get rankName1() : TextInput
        {
            return this._657959366rankName1;
        }// end function

        public function get btnMail() : StandardButton
        {
            return this._206006835btnMail;
        }// end function

        private function _GuildWindow_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label2 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label2";
            BindingManager.executeBindings(this, "_GuildWindow_Label2", this._GuildWindow_Label2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 25;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get memberName() : Label
        {
            return this._1341350843memberName;
        }// end function

        public function get memberRank() : Label
        {
            return this._1341231642memberRank;
        }// end function

        public function get rankName4() : TextInput
        {
            return this._657959363rankName4;
        }// end function

        public function __guildList_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _GuildWindow_Label11_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label11 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label11";
            BindingManager.executeBindings(this, "_GuildWindow_Label11", this._GuildWindow_Label11);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get rankName2() : TextInput
        {
            return this._657959365rankName2;
        }// end function

        public function get officerNote() : TextEditor
        {
            return this._1160105400officerNote;
        }// end function

        public function set banner(param1:Image) : void
        {
            var _loc_2:* = this._1396342996banner;
            if (_loc_2 !== param1)
            {
                this._1396342996banner = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "banner", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas24_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "25");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get administration() : Canvas
        {
            return this._1255702622administration;
        }// end function

        private function _GuildWindow_DataGridColumn3_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn3 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 100;
            _loc_1.dataField = "size";
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory3_c();
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn3", this._GuildWindow_DataGridColumn3);
            return _loc_1;
        }// end function

        public function set btnMail(param1:StandardButton) : void
        {
            var _loc_2:* = this._206006835btnMail;
            if (_loc_2 !== param1)
            {
                this._206006835btnMail = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnMail", _loc_2, param1));
            }
            return;
        }// end function

        public function set leaderName(param1:Label) : void
        {
            var _loc_2:* = this._1191282484leaderName;
            if (_loc_2 !== param1)
            {
                this._1191282484leaderName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "leaderName", _loc_2, param1));
            }
            return;
        }// end function

        public function set guildList(param1:CustomDataGrid) : void
        {
            var _loc_2:* = this._1848561871guildList;
            if (_loc_2 !== param1)
            {
                this._1848561871guildList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildList", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_FormItem2_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._GuildWindow_FormItem2 = _loc_1;
            _loc_1.setStyle("labelStyleName", "labelLeft");
            _loc_1.id = "_GuildWindow_FormItem2";
            BindingManager.executeBindings(this, "_GuildWindow_FormItem2", this._GuildWindow_FormItem2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_TextInput2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_ClassFactory6_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        private function _GuildWindow_Button2_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnRankDown = _loc_1;
            _loc_1.visible = false;
            _loc_1.width = 12;
            _loc_1.height = 12;
            _loc_1.setStyle("upSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_std_png_632473566);
            _loc_1.setStyle("downSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_sel_png_706929712);
            _loc_1.setStyle("overSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_sel_png_706929712);
            _loc_1.setStyle("disabledSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_s_non_png_1151518270);
            _loc_1.setStyle("bottom", "8");
            _loc_1.setStyle("right", "5");
            _loc_1.id = "btnRankDown";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set subcontent(param1:ViewStack) : void
        {
            var _loc_2:* = this._2100227641subcontent;
            if (_loc_2 !== param1)
            {
                this._2100227641subcontent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subcontent", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_ViewStack2_i() : ViewStack
        {
            var _loc_1:* = new ViewStack();
            this.guildDetailsStack = _loc_1;
            _loc_1.setStyle("left", "135");
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "40");
            _loc_1.id = "guildDetailsStack";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas11_c());
            _loc_1.addChild(this._GuildWindow_Canvas21_c());
            _loc_1.addChild(this._GuildWindow_Canvas34_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_StandardButton5_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnInvite = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("top", "272");
            _loc_1.id = "btnInvite";
            BindingManager.executeBindings(this, "btnInvite", this.btnInvite);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnBannerRight() : Button
        {
            return this._912210348btnBannerRight;
        }// end function

        private function _GuildWindow_StandardButton14_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnDiscardBannerChanges = _loc_1;
            _loc_1.width = 120;
            _loc_1.enabled = false;
            _loc_1.id = "btnDiscardBannerChanges";
            BindingManager.executeBindings(this, "btnDiscardBannerChanges", this.btnDiscardBannerChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas12_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "105");
            _loc_1.setStyle("top", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label1_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas35_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 258;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas36_c());
            _loc_1.addChild(this._GuildWindow_Canvas37_c());
            _loc_1.addChild(this._GuildWindow_Canvas39_c());
            _loc_1.addChild(this._GuildWindow_Canvas40_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_TextInput2_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.rankName2 = _loc_1;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.maxChars = 32;
            _loc_1.restrict = "^\\\\";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.setStyle("paddingTop", 3);
            _loc_1.setStyle("paddingLeft", 3);
            _loc_1.setStyle("paddingRight", 3);
            _loc_1.id = "rankName2";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set rankName1(param1:TextInput) : void
        {
            var _loc_2:* = this._657959366rankName1;
            if (_loc_2 !== param1)
            {
                this._657959366rankName1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rankName1", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Image2_i() : Image
        {
            var _loc_1:* = new Image();
            this.selectedBanner = _loc_1;
            _loc_1.width = 133;
            _loc_1.height = 233;
            _loc_1.scaleContent = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-45");
            _loc_1.id = "selectedBanner";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set rankName2(param1:TextInput) : void
        {
            var _loc_2:* = this._657959365rankName2;
            if (_loc_2 !== param1)
            {
                this._657959365rankName2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rankName2", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnSaveBannerChanges() : StandardButton
        {
            return this._625449086btnSaveBannerChanges;
        }// end function

        public function set rankName3(param1:TextInput) : void
        {
            var _loc_2:* = this._657959364rankName3;
            if (_loc_2 !== param1)
            {
                this._657959364rankName3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rankName3", _loc_2, param1));
            }
            return;
        }// end function

        public function set rankName4(param1:TextInput) : void
        {
            var _loc_2:* = this._657959363rankName4;
            if (_loc_2 !== param1)
            {
                this._657959363rankName4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rankName4", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label1";
            BindingManager.executeBindings(this, "_GuildWindow_Label1", this._GuildWindow_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.height = 400;
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas3_c());
            _loc_1.addChild(this._GuildWindow_Canvas4_c());
            _loc_1.addChild(this._GuildWindow_CustomDataGrid1_i());
            return _loc_1;
        }// end function

        public function get btnDiscardBannerChanges() : StandardButton
        {
            return this._2022123915btnDiscardBannerChanges;
        }// end function

        public function get btnInvite() : StandardButton
        {
            return this._301950085btnInvite;
        }// end function

        private function _GuildWindow_Label10_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label10 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label10";
            BindingManager.executeBindings(this, "_GuildWindow_Label10", this._GuildWindow_Label10);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Label9_i() : Label
        {
            var _loc_1:* = new Label();
            this.memberRank = _loc_1;
            _loc_1.width = 100;
            _loc_1.setStyle("left", "75");
            _loc_1.setStyle("top", "42");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.addEventListener("toolTipCreate", this.__memberRank_toolTipCreate);
            _loc_1.id = "memberRank";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set guildInfo(param1:Text) : void
        {
            var _loc_2:* = this._1848646847guildInfo;
            if (_loc_2 !== param1)
            {
                this._1848646847guildInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildInfo", _loc_2, param1));
            }
            return;
        }// end function

        public function get memberAvatar() : AvatarListItemRenderer
        {
            return this._901096301memberAvatar;
        }// end function

        public function get guildLog() : List
        {
            return this._1306556847guildLog;
        }// end function

        private function _GuildWindow_FormItem1_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._GuildWindow_FormItem1 = _loc_1;
            _loc_1.setStyle("labelStyleName", "labelLeft");
            _loc_1.id = "_GuildWindow_FormItem1";
            BindingManager.executeBindings(this, "_GuildWindow_FormItem1", this._GuildWindow_FormItem1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_TextInput1_i());
            return _loc_1;
        }// end function

        public function get btnNextPage() : StandardButton
        {
            return this._1090881890btnNextPage;
        }// end function

        private function _GuildWindow_Canvas23_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 25;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_TextEditor4_i() : TextEditor
        {
            var _loc_1:* = new TextEditor();
            this.note = _loc_1;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.maxChars = 255;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "283");
            _loc_1.setStyle("bottom", "40");
            _loc_1.id = "note";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_DataGridColumn2_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn2 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 100;
            _loc_1.dataField = "tag";
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory2_c();
            _loc_1.setStyle("textAlign", "center");
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn2", this._GuildWindow_DataGridColumn2);
            return _loc_1;
        }// end function

        private function _GuildWindow_Button1_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnRankUp = _loc_1;
            _loc_1.visible = false;
            _loc_1.width = 12;
            _loc_1.height = 12;
            _loc_1.setStyle("upSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_std_png_47867872);
            _loc_1.setStyle("downSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_sel_png_616187438);
            _loc_1.setStyle("overSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_sel_png_616187438);
            _loc_1.setStyle("disabledSkin", this._embed_mxml_____data_src_gfx_embedded_guild_arrow_n_non_png_634470444);
            _loc_1.setStyle("bottom", "8");
            _loc_1.setStyle("right", "17");
            _loc_1.id = "btnRankUp";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __buttonBar_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _GuildWindow_Canvas46_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "hr";
            _loc_1.height = 3;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "27");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set officerNote(param1:TextEditor) : void
        {
            var _loc_2:* = this._1160105400officerNote;
            if (_loc_2 !== param1)
            {
                this._1160105400officerNote = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "officerNote", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_ViewStack1_i() : ViewStack
        {
            var _loc_1:* = new ViewStack();
            this.subcontent = _loc_1;
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "0");
            _loc_1.id = "subcontent";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas1_c());
            _loc_1.addChild(this._GuildWindow_Canvas9_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas11_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas12_c());
            _loc_1.addChild(this._GuildWindow_Canvas13_c());
            _loc_1.addChild(this._GuildWindow_Canvas15_c());
            _loc_1.addChild(this._GuildWindow_Canvas16_c());
            _loc_1.addChild(this._GuildWindow_Canvas17_c());
            _loc_1.addChild(this._GuildWindow_TextEditor2_i());
            _loc_1.addChild(this._GuildWindow_Canvas18_c());
            _loc_1.addChild(this._GuildWindow_Canvas19_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_TextInput1_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.rankName1 = _loc_1;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.maxChars = 32;
            _loc_1.restrict = "^\\\\";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.setStyle("paddingTop", 3);
            _loc_1.setStyle("paddingLeft", 3);
            _loc_1.setStyle("paddingRight", 3);
            _loc_1.id = "rankName1";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set guildLog(param1:List) : void
        {
            var _loc_2:* = this._1306556847guildLog;
            if (_loc_2 !== param1)
            {
                this._1306556847guildLog = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildLog", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_StandardButton4_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFoundGuild = _loc_1;
            _loc_1.width = 150;
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "btnFoundGuild";
            BindingManager.executeBindings(this, "btnFoundGuild", this.btnFoundGuild);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set administration(param1:Canvas) : void
        {
            var _loc_2:* = this._1255702622administration;
            if (_loc_2 !== param1)
            {
                this._1255702622administration = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "administration", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_StandardButton13_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnSaveBannerChanges = _loc_1;
            _loc_1.width = 120;
            _loc_1.enabled = false;
            _loc_1.id = "btnSaveBannerChanges";
            BindingManager.executeBindings(this, "btnSaveBannerChanges", this.btnSaveBannerChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set memberName(param1:Label) : void
        {
            var _loc_2:* = this._1341350843memberName;
            if (_loc_2 !== param1)
            {
                this._1341350843memberName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "memberName", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas34_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.administration = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.id = "administration";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas35_c());
            _loc_1.addChild(this._GuildWindow_Canvas43_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_HBox3_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_StandardButton13_i());
            _loc_1.addChild(this._GuildWindow_StandardButton14_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas2_c());
            _loc_1.addChild(this._GuildWindow_Canvas5_c());
            _loc_1.addChild(this._GuildWindow_Canvas7_c());
            _loc_1.addChild(this._GuildWindow_Canvas8_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas10_c());
            _loc_1.addChild(this._GuildWindow_Image1_i());
            _loc_1.addChild(this._GuildWindow_StandardButton5_i());
            _loc_1.addChild(this._GuildWindow_StandardButton6_i());
            _loc_1.addChild(this._GuildWindow_StandardButton7_i());
            _loc_1.addChild(this._GuildWindow_StandardButton8_i());
            _loc_1.addChild(this._GuildWindow_StandardButton9_i());
            _loc_1.addChild(this._GuildWindow_ViewStack2_i());
            _loc_1.addChild(this._GuildWindow_Canvas46_c());
            _loc_1.addChild(this._GuildWindow_CustomToggleButtonBar1_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas19_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "258");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas20_c());
            return _loc_1;
        }// end function

        public function get btnBannerLeft() : Button
        {
            return this._29608753btnBannerLeft;
        }// end function

        private function _GuildWindow_Label8_i() : Label
        {
            var _loc_1:* = new Label();
            this.memberLevel = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "75");
            _loc_1.setStyle("top", "23");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "memberLevel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnKick() : StandardButton
        {
            return this._205954754btnKick;
        }// end function

        private function _GuildWindow_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.banner = _loc_1;
            _loc_1.width = 133;
            _loc_1.height = 233;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("top", "35");
            _loc_1.id = "banner";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnRankDown(param1:Button) : void
        {
            var _loc_2:* = this._2035397994btnRankDown;
            if (_loc_2 !== param1)
            {
                this._2035397994btnRankDown = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRankDown", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnIncrease() : StandardButton
        {
            return this._1875133630btnIncrease;
        }// end function

        private function _GuildWindow_Canvas22_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "202");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas23_c());
            _loc_1.addChild(this._GuildWindow_Canvas24_c());
            _loc_1.addChild(this._GuildWindow_CustomDataGrid2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas45_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_ClassFactory5_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function set btnRankUp(param1:Button) : void
        {
            var _loc_2:* = this._547369315btnRankUp;
            if (_loc_2 !== param1)
            {
                this._547369315btnRankUp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRankUp", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnSaveRankChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._1527062846btnSaveRankChanges;
            if (_loc_2 !== param1)
            {
                this._1527062846btnSaveRankChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSaveRankChanges", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_DataGridColumn1_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn1 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 300;
            _loc_1.dataField = "name";
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory1_c();
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn1", this._GuildWindow_DataGridColumn1);
            return _loc_1;
        }// end function

        public function set membersList(param1:CustomDataGrid) : void
        {
            var _loc_2:* = this._1401338199membersList;
            if (_loc_2 !== param1)
            {
                this._1401338199membersList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "membersList", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_TextEditor3_i() : TextEditor
        {
            var _loc_1:* = new TextEditor();
            this.officerNote = _loc_1;
            _loc_1.height = 80;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.maxChars = 255;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "183");
            _loc_1.id = "officerNote";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnDiscardBannerChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._2022123915btnDiscardBannerChanges;
            if (_loc_2 !== param1)
            {
                this._2022123915btnDiscardBannerChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnDiscardBannerChanges", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_ClassFactory4_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = GuildLogItemRenderer;
            return _loc_1;
        }// end function

        public function set btnBannerRight(param1:Button) : void
        {
            var _loc_2:* = this._912210348btnBannerRight;
            if (_loc_2 !== param1)
            {
                this._912210348btnBannerRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBannerRight", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnMyGuild = _loc_1;
            _loc_1.width = 150;
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "btnMyGuild";
            BindingManager.executeBindings(this, "btnMyGuild", this.btnMyGuild);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas10_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 60;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "1");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_TextEditor1_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas33_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsSubContentBox";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_StandardButton10_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_HBox2_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_StandardButton11_i());
            _loc_1.addChild(this._GuildWindow_StandardButton12_i());
            return _loc_1;
        }// end function

        public function get guildDetailsStack() : ViewStack
        {
            return this._971126009guildDetailsStack;
        }// end function

        private function _GuildWindow_StandardButton12_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnDiscardRankChanges = _loc_1;
            _loc_1.width = 120;
            _loc_1.enabled = false;
            _loc_1.id = "btnDiscardRankChanges";
            BindingManager.executeBindings(this, "btnDiscardRankChanges", this.btnDiscardRankChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas18_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "240");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label5_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_List1_i() : List
        {
            var _loc_1:* = new List();
            this.guildLog = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory4_c();
            _loc_1.variableRowHeight = true;
            _loc_1.selectable = false;
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("paddingRight", 10);
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "guildLog";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnBackToList() : StandardButton
        {
            return this._877658884btnBackToList;
        }// end function

        public function set btnInvite(param1:StandardButton) : void
        {
            var _loc_2:* = this._301950085btnInvite;
            if (_loc_2 !== param1)
            {
                this._301950085btnInvite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInvite", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnSaveBannerChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._625449086btnSaveBannerChanges;
            if (_loc_2 !== param1)
            {
                this._625449086btnSaveBannerChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSaveBannerChanges", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnDiscardRankChanges() : StandardButton
        {
            return this._1166766325btnDiscardRankChanges;
        }// end function

        private function _GuildWindow_Label7_i() : Label
        {
            var _loc_1:* = new Label();
            this.memberName = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "75");
            _loc_1.setStyle("top", "4");
            _loc_1.addEventListener("toolTipCreate", this.__memberName_toolTipCreate);
            _loc_1.id = "memberName";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set buttonBar(param1:CustomToggleButtonBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas21_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas22_c());
            _loc_1.addChild(this._GuildWindow_Canvas25_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas44_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label15_i());
            return _loc_1;
        }// end function

        public function get memberLevel() : Label
        {
            return this._1366077706memberLevel;
        }// end function

        public function get btnFoundGuild() : StandardButton
        {
            return this._1102566131btnFoundGuild;
        }// end function

        private function _GuildWindow_Form1_c() : Form
        {
            var _loc_1:* = new Form();
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_FormItem1_i());
            _loc_1.addChild(this._GuildWindow_FormItem2_i());
            _loc_1.addChild(this._GuildWindow_FormItem3_i());
            _loc_1.addChild(this._GuildWindow_FormItem4_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 40;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "458");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_StandardButton3_i());
            _loc_1.addChild(this._GuildWindow_StandardButton4_i());
            return _loc_1;
        }// end function

        public function set motd(param1:TextEditor) : void
        {
            var _loc_2:* = this._3357586motd;
            if (_loc_2 !== param1)
            {
                this._3357586motd = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "motd", _loc_2, param1));
            }
            return;
        }// end function

        public function set memberAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._901096301memberAvatar;
            if (_loc_2 !== param1)
            {
                this._901096301memberAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "memberAvatar", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_TextEditor2_i() : TextEditor
        {
            var _loc_1:* = new TextEditor();
            this.guildDescription = _loc_1;
            _loc_1.height = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.maxChars = 65535;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "138");
            _loc_1.id = "guildDescription";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas29_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 60;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "103");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get banner() : Image
        {
            return this._1396342996banner;
        }// end function

        private function _GuildWindow_StandardButton11_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnSaveRankChanges = _loc_1;
            _loc_1.width = 120;
            _loc_1.enabled = false;
            _loc_1.id = "btnSaveRankChanges";
            BindingManager.executeBindings(this, "btnSaveRankChanges", this.btnSaveRankChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnNextPage(param1:StandardButton) : void
        {
            var _loc_2:* = this._1090881890btnNextPage;
            if (_loc_2 !== param1)
            {
                this._1090881890btnNextPage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnNextPage", _loc_2, param1));
            }
            return;
        }// end function

        public function get guildList() : CustomDataGrid
        {
            return this._1848561871guildList;
        }// end function

        private function _GuildWindow_ClassFactory3_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function get leaderName() : Label
        {
            return this._1191282484leaderName;
        }// end function

        private function _GuildWindow_Canvas17_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "120");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label4_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_StandardButton1_i());
            _loc_1.addChild(this._GuildWindow_StandardButton2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Label6_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label6 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label6";
            BindingManager.executeBindings(this, "_GuildWindow_Label6", this._GuildWindow_Label6);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas7_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "4");
            _loc_1.setStyle("top", "440");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnNextPage = _loc_1;
            _loc_1.label = "»";
            _loc_1.width = 40;
            _loc_1.height = 26;
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "btnNextPage";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnSaveRankChanges() : StandardButton
        {
            return this._1527062846btnSaveRankChanges;
        }// end function

        private function _GuildWindow_Canvas32_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 40;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas33_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas20_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("bottom", "4");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_List1_i());
            return _loc_1;
        }// end function

        public function get membersList() : CustomDataGrid
        {
            return this._1401338199membersList;
        }// end function

        public function get guildInfo() : Text
        {
            return this._1848646847guildInfo;
        }// end function

        private function _GuildWindow_Canvas28_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "85");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label10_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Label15_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label15 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label15";
            BindingManager.executeBindings(this, "_GuildWindow_Label15", this._GuildWindow_Label15);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnRankUp() : Button
        {
            return this._547369315btnRankUp;
        }// end function

        private function _GuildWindow_Canvas43_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 180;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas44_c());
            _loc_1.addChild(this._GuildWindow_Canvas45_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_TextEditor1_i() : TextEditor
        {
            var _loc_1:* = new TextEditor();
            this.motd = _loc_1;
            _loc_1.maxChars = 255;
            _loc_1.setStyle("left", "140");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "6");
            _loc_1.setStyle("bottom", "2");
            _loc_1.id = "motd";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnRankDown() : Button
        {
            return this._2035397994btnRankDown;
        }// end function

        public function set btnMyGuild(param1:StandardButton) : void
        {
            var _loc_2:* = this._297427883btnMyGuild;
            if (_loc_2 !== param1)
            {
                this._297427883btnMyGuild = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnMyGuild", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_StandardButton10_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnKick = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "btnKick";
            BindingManager.executeBindings(this, "btnKick", this.btnKick);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Array
            {
                return [];
            }// end function
            , function (param1:Array) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "guildList.alternatingItemColors");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Guild");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn1.headerText");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildTag");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = param1;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn2.headerText");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildPlayerCount");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn3.headerText");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildMy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnMyGuild.label");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildFound");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnFoundGuild.label = param1;
                return;
            }// end function
            , "btnFoundGuild.label");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildInvite");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnInvite.label = param1;
                return;
            }// end function
            , "btnInvite.label");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMail");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnMail.label");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLeave");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnLeave.label");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildIncreaseSize");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnIncrease.label");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildList");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnBackToList.label");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInfo");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_Label1.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label1.text");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLeader");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label2.text");
            result[12] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDescription");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_Label4.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label4.text");
            result[13] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildLog");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label5.text");
            result[14] = binding;
            binding = new Binding(this, function () : Array
            {
                return [];
            }// end function
            , function (param1:Array) : void
            {
                membersList.setStyle("alternatingItemColors", param1);
                return;
            }// end function
            , "membersList.alternatingItemColors");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMember");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_DataGridColumn4.headerText = param1;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn4.headerText");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildLevel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn5.headerText");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildRank");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_DataGridColumn6.headerText = param1;
                return;
            }// end function
            , "_GuildWindow_DataGridColumn6.headerText");
            result[18] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildMemberDetails");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_Label6.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label6.text");
            result[19] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildCurrentAdventures");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label10.text");
            result[20] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildOfficerNote");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label11.text");
            result[21] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildNote");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_Label12.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label12.text");
            result[22] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildKick");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnKick.label");
            result[23] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEditRanks");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_GuildWindow_Label13.text");
            result[24] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 1";
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_GuildWindow_FormItem1.label");
            result[25] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 2";
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_GuildWindow_FormItem2.label");
            result[26] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildRank") + " 3";
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "_GuildWindow_FormItem3.label");
            result[27] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildRank") + " 4";
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_GuildWindow_FormItem4.label");
            result[28] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Save");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnSaveRankChanges.label");
            result[29] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Discard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnDiscardRankChanges.label");
            result[30] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEdit");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _GuildWindow_Label14.text = param1;
                return;
            }// end function
            , "_GuildWindow_Label14.text");
            result[31] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnBannerLeft.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnBannerLeft.upSkin");
            result[32] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeftHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnBannerLeft.overSkin");
            result[33] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBannerLeft.downSkin");
            result[34] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnBannerLeft.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnBannerLeft.disabledSkin");
            result[35] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBannerRight.upSkin");
            result[36] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnBannerRight.overSkin");
            result[37] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightHighlight");
            }// end function
            , function (param1:Class) : void
            {
                btnBannerRight.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnBannerRight.downSkin");
            result[38] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightDisabled");
            }// end function
            , function (param1:Class) : void
            {
                btnBannerRight.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnBannerRight.disabledSkin");
            result[39] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Save");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnSaveBannerChanges.label");
            result[40] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Discard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnDiscardBannerChanges.label");
            result[41] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildEditDetails");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_GuildWindow_Label15.text");
            result[42] = binding;
            return result;
        }// end function

        private function _GuildWindow_Canvas31_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "265");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label12_i());
            return _loc_1;
        }// end function

        public function set btnLeave(param1:StandardButton) : void
        {
            var _loc_2:* = this._2090432955btnLeave;
            if (_loc_2 !== param1)
            {
                this._2090432955btnLeave = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnLeave", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_StandardButton9_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnBackToList = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("bottom", "39");
            _loc_1.id = "btnBackToList";
            BindingManager.executeBindings(this, "btnBackToList", this.btnBackToList);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set selectedBanner(param1:Image) : void
        {
            var _loc_2:* = this._1356381607selectedBanner;
            if (_loc_2 !== param1)
            {
                this._1356381607selectedBanner = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedBanner", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Canvas16_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.width = 98;
            _loc_1.height = 100;
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_AvatarListItemRenderer1_i());
            _loc_1.addChild(this._GuildWindow_Label3_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas39_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "220");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label14_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnPrevPage = _loc_1;
            _loc_1.label = "«";
            _loc_1.width = 40;
            _loc_1.height = 26;
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "btnPrevPage";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function set btnIncrease(param1:StandardButton) : void
        {
            var _loc_2:* = this._1875133630btnIncrease;
            if (_loc_2 !== param1)
            {
                this._1875133630btnIncrease = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnIncrease", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnKick(param1:StandardButton) : void
        {
            var _loc_2:* = this._205954754btnKick;
            if (_loc_2 !== param1)
            {
                this._205954754btnKick = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnKick", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label5 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label5";
            BindingManager.executeBindings(this, "_GuildWindow_Label5", this._GuildWindow_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsSubContentBox";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_HBox1_c());
            return _loc_1;
        }// end function

        public function get buttonBar() : CustomToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        public function set leaderAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._2008041410leaderAvatar;
            if (_loc_2 !== param1)
            {
                this._2008041410leaderAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "leaderAvatar", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Label14_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label14 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label14";
            BindingManager.executeBindings(this, "_GuildWindow_Label14", this._GuildWindow_Label14);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:GuildWindow;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._GuildWindow_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_GuildWindowWatcherSetupUtil");
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

        public function get motd() : TextEditor
        {
            return this._3357586motd;
        }// end function

        private function _GuildWindow_AvatarListItemRenderer2_i() : AvatarListItemRenderer
        {
            var _loc_1:* = new AvatarListItemRenderer();
            this.memberAvatar = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("left", "7");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "memberAvatar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_CustomToggleButtonBar1_i() : CustomToggleButtonBar
        {
            var _loc_1:* = new CustomToggleButtonBar();
            this.buttonBar = _loc_1;
            _loc_1.setStyle("buttonStyleName", "tab");
            _loc_1.setStyle("selectedButtonTextStyleName", "tabSelected");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "0");
            _loc_1.addEventListener("toolTipCreate", this.__buttonBar_toolTipCreate);
            _loc_1.id = "buttonBar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnBannerLeft(param1:Button) : void
        {
            var _loc_2:* = this._29608753btnBannerLeft;
            if (_loc_2 !== param1)
            {
                this._29608753btnBannerLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBannerLeft", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_DataGridColumn6_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn6 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 150;
            _loc_1.dataField = "rankID";
            _loc_1.labelFunction = this.formatRanks;
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory7_c();
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn6", this._GuildWindow_DataGridColumn6);
            return _loc_1;
        }// end function

        private function _GuildWindow_CustomDataGrid2_i() : CustomDataGrid
        {
            var _loc_1:* = new CustomDataGrid();
            this.membersList = _loc_1;
            _loc_1.rowHeight = 25;
            _loc_1.headerHeight = 20;
            _loc_1.columns = [this._GuildWindow_DataGridColumn4_i(), this._GuildWindow_DataGridColumn5_i(), this._GuildWindow_DataGridColumn6_i()];
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("iconColor", 13077059);
            _loc_1.setStyle("selectionColor", 8482380);
            _loc_1.setStyle("rollOverColor", 7957587);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "12");
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("horizontalGridLines", false);
            _loc_1.setStyle("verticalGridLineColor", 7693901);
            _loc_1.setStyle("headerColors", [3155998]);
            _loc_1.setStyle("borderColor", 7693901);
            _loc_1.setStyle("headerStyleName", "mailDataGridHeader");
            _loc_1.setStyle("headerBackgroundSkin", CustomDataGridHeaderBackgroundSkin);
            _loc_1.setStyle("headerSeparatorSkin", CustomDataGridHeaderSeparator);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.addEventListener("toolTipCreate", this.__membersList_toolTipCreate);
            _loc_1.id = "membersList";
            BindingManager.executeBindings(this, "membersList", this.membersList);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas27_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 65;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_AvatarListItemRenderer2_i());
            _loc_1.addChild(this._GuildWindow_Label7_i());
            _loc_1.addChild(this._GuildWindow_Label8_i());
            _loc_1.addChild(this._GuildWindow_Label9_i());
            _loc_1.addChild(this._GuildWindow_Button1_i());
            _loc_1.addChild(this._GuildWindow_Button2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas42_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 40;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_HBox3_c());
            return _loc_1;
        }// end function

        public function get selectedBanner() : Image
        {
            return this._1356381607selectedBanner;
        }// end function

        private function _GuildWindow_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function get btnMyGuild() : StandardButton
        {
            return this._297427883btnMyGuild;
        }// end function

        private function _GuildWindow_StandardButton8_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnIncrease = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("top", "377");
            _loc_1.id = "btnIncrease";
            BindingManager.executeBindings(this, "btnIncrease", this.btnIncrease);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas15_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.width = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("right", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas38_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 40;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_HBox2_c());
            return _loc_1;
        }// end function

        public function get btnLeave() : StandardButton
        {
            return this._2090432955btnLeave;
        }// end function

        private function _GuildWindow_Canvas30_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "165");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label11_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Label4_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label4 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label4";
            BindingManager.executeBindings(this, "_GuildWindow_Label4", this._GuildWindow_Label4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 35;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "400");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Canvas6_c());
            return _loc_1;
        }// end function

        public function get leaderAvatar() : AvatarListItemRenderer
        {
            return this._2008041410leaderAvatar;
        }// end function

        public function set btnPrevPage(param1:StandardButton) : void
        {
            var _loc_2:* = this._505277918btnPrevPage;
            if (_loc_2 !== param1)
            {
                this._505277918btnPrevPage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnPrevPage", _loc_2, param1));
            }
            return;
        }// end function

        private function _GuildWindow_Label13_i() : Label
        {
            var _loc_1:* = new Label();
            this._GuildWindow_Label13 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_GuildWindow_Label13";
            BindingManager.executeBindings(this, "_GuildWindow_Label13", this._GuildWindow_Label13);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function formatLevel(param1:Object, param2:DataGridColumn) : String
        {
            var _loc_3:* = param1[param2.dataField];
            return _loc_3 == 0 ? ("1") : (_loc_3.toString());
        }// end function

        private function _GuildWindow_AvatarListItemRenderer1_i() : AvatarListItemRenderer
        {
            var _loc_1:* = new AvatarListItemRenderer();
            this.leaderAvatar = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-5");
            _loc_1.id = "leaderAvatar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas41_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.clipContent = true;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "45");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Image2_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas26_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Label6_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_DataGridColumn5_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._GuildWindow_DataGridColumn5 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 90;
            _loc_1.dataField = "playerLevel";
            _loc_1.labelFunction = this.formatLevel;
            _loc_1.itemRenderer = this._GuildWindow_ClassFactory6_c();
            _loc_1.setStyle("textAlign", "center");
            BindingManager.executeBindings(this, "_GuildWindow_DataGridColumn5", this._GuildWindow_DataGridColumn5);
            return _loc_1;
        }// end function

        private function _GuildWindow_CustomDataGrid1_i() : CustomDataGrid
        {
            var _loc_1:* = new CustomDataGrid();
            this.guildList = _loc_1;
            _loc_1.sortableColumns = false;
            _loc_1.rowHeight = 25;
            _loc_1.headerHeight = 20;
            _loc_1.columns = [this._GuildWindow_DataGridColumn1_i(), this._GuildWindow_DataGridColumn2_i(), this._GuildWindow_DataGridColumn3_i()];
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("iconColor", 13077059);
            _loc_1.setStyle("selectionColor", 8482380);
            _loc_1.setStyle("rollOverColor", 7957587);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "12");
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("horizontalGridLines", false);
            _loc_1.setStyle("verticalGridLineColor", 7693901);
            _loc_1.setStyle("headerColors", [3155998]);
            _loc_1.setStyle("borderColor", 7693901);
            _loc_1.setStyle("headerStyleName", "mailDataGridHeader");
            _loc_1.setStyle("headerBackgroundSkin", CustomDataGridHeaderBackgroundSkin);
            _loc_1.setStyle("headerSeparatorSkin", CustomDataGridHeaderSeparator);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.addEventListener("toolTipCreate", this.__guildList_toolTipCreate);
            _loc_1.id = "guildList";
            BindingManager.executeBindings(this, "guildList", this.guildList);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnPrevPage() : StandardButton
        {
            return this._505277918btnPrevPage;
        }// end function

        private function _GuildWindow_FormItem4_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._GuildWindow_FormItem4 = _loc_1;
            _loc_1.setStyle("labelStyleName", "labelLeft");
            _loc_1.id = "_GuildWindow_FormItem4";
            BindingManager.executeBindings(this, "_GuildWindow_FormItem4", this._GuildWindow_FormItem4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_TextInput4_i());
            return _loc_1;
        }// end function

        public function __membersList_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _GuildWindow_Button4_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnBannerRight = _loc_1;
            _loc_1.width = 25;
            _loc_1.height = 23;
            _loc_1.setStyle("right", "20");
            _loc_1.setStyle("top", "60");
            _loc_1.id = "btnBannerRight";
            BindingManager.executeBindings(this, "btnBannerRight", this.btnBannerRight);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas14_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "auto";
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("bottom", "3");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Text1_i());
            return _loc_1;
        }// end function

        private function _GuildWindow_Canvas37_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 200;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._GuildWindow_Form1_c());
            _loc_1.addChild(this._GuildWindow_Canvas38_c());
            return _loc_1;
        }// end function

        private function _GuildWindow_TextInput4_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.rankName4 = _loc_1;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.maxChars = 32;
            _loc_1.restrict = "^\\\\";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.setStyle("paddingTop", 3);
            _loc_1.setStyle("paddingLeft", 3);
            _loc_1.setStyle("paddingRight", 3);
            _loc_1.id = "rankName4";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _GuildWindow_StandardButton7_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnLeave = _loc_1;
            _loc_1.width = 120;
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("top", "342");
            _loc_1.id = "btnLeave";
            BindingManager.executeBindings(this, "btnLeave", this.btnLeave);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnBackToList(param1:StandardButton) : void
        {
            var _loc_2:* = this._877658884btnBackToList;
            if (_loc_2 !== param1)
            {
                this._877658884btnBackToList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBackToList", _loc_2, param1));
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            GuildWindow._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
