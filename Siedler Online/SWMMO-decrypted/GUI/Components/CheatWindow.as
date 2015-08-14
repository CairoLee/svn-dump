package GUI.Components
{
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.events.*;

    public class CheatWindow extends TitleWindow
    {
        private var _1379556710SupportTab:Canvas;
        private var _1192393962InsertZoneEventLogID:Button;
        private var _339209245showGrid:CheckBox;
        private var _1132644544showLandingField:CheckBox;
        private var _579519159SetCityLevel:Button;
        private var _1234526375resourceTab:Canvas;
        private var _211895922HOURS_TIL_NEXT_DAY_ID:Label;
        private var _338964802consoleTab:Canvas;
        private var _2098857202CHEATWINDOW_FILTER_TEXTINPUT:TextInput;
        private var _1522746745GAMESPEED_TEXTINPUT_ID:TextInput;
        private var _1252453928BUTTON_RESOURCES_CLEAR_ALL:Button;
        private var _871187232QUEST_SHOW_ID:Button;
        private var _1202389732showMemoryMonitor:CheckBox;
        private var _1088473615showBackgroundGrid:CheckBox;
        private var _862843174refreshHomeZone:Button;
        private var _60599402GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID:TextInput;
        private var _1085103662showCursorDebugInfo:CheckBox;
        private var _852461362CHEATWINDOW_TEXT_CANVAS:Canvas;
        private var _261364945showIsoDebugGrid:CheckBox;
        private var _996886627resourcesList:TileList;
        private var _2067265708showFPS:CheckBox;
        private var _868353437SetGodMode:Button;
        private var _121310094settingsTab:Canvas;
        private var _1618925386disableFog:CheckBox;
        private var _1106925012SetFilterButton:Button;
        private var _1624450414AddOneDayID:Button;
        private var _1358891337SHOW_ALL_QUESTS_ID:CheckBox;
        private var _1570317292BUTTON_RESOURCES_FILL_ALL:Button;
        private var _804167404QUEST_FINISH_WITH_GEMS_ID:Button;
        private var _1803200937applyResources:Button;
        private var _1061598316debugQuestGui:CheckBox;
        private var _2117550485SETCITYLEVEL_TEXTINPUT_ID0:TextInput;
        private var _1790038357TIME_OFFSET_ID:Label;
        private var _992483516QUEST_REFRESH_ID:Button;
        private var _1698020035SetFakeServerDateID:Button;
        private var _2040911440ResetFakeServerDateID:Button;
        private var _951510359console:TextArea;
        private var _91467698showDeposits:CheckBox;
        private var _1503921104showBuildingDebugInfo:CheckBox;
        private var _430664130SPOOLTIME_TEXTINPUTADDMINUTES_ID:TextInput;
        private var _1101246605QuestTab:Canvas;
        private var _130813753QUEST_INFO_TEXT_ID:Text;
        private var _1277049579BUTTON_RESOURCES_FILL_MAXIMUM:Button;
        private var _875590269resizeToMin:Button;
        private var _1197788949SpoolTimeAddMinutesID:Button;
        private var _1095425440LOCALSERVERDATE_TEXTINPUT_ID:TextInput;
        private var _2112342757ORGINAL_SERVER_DATE_ID:Label;
        private var _1576126688SPOOLTIME_TEXTINPUT_ID:TextInput;
        private var _2049964875resizeToFB:Button;
        private var _1499459633RefreshAllID0:Button;
        private var _261440066tabNavigator:TabNavigator;
        private var _1014137377QUEST_LIST_ID:DataGrid;
        private var _2093280599showSectorGrid:CheckBox;
        private var _1466438868showWatchAreas:CheckBox;
        private var _1855855432showBlockingGrid:CheckBox;
        private var _1627967607SpoolTimeID:Button;
        private var _729616878QUEST_DROP_ID:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _2008846161GrabForeignZoneID:Button;

        public function CheatWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:TitleWindow, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:540, height:640, childDescriptors:[new UIComponentDescriptor({type:TabNavigator, id:"tabNavigator", stylesFactory:function () : void
                {
                    null.paddingTop = this;
                    this.left = "0";
                    this.right = "0";
                    this.top = "0";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"settingsTab", propertiesFactory:function () : Object
                    {
                        return {label:"Settings", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Button, id:"refreshHomeZone", propertiesFactory:function () : Object
                        {
                            return {null:10, y:10, label:"Refresh Home Zone"};
                        }// end function
                        }), new UIComponentDescriptor({type:VBox, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {y:40, x:10, height:502, width:203, label:"level up", childDescriptors:[new UIComponentDescriptor({type:Label, stylesFactory:function () : void
                            {
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {text:"Rendering"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showGrid", propertiesFactory:function () : Object
                            {
                                return {label:"show iso grid"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showBuildingDebugInfo", propertiesFactory:function () : Object
                            {
                                return {label:"show Building info"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showBlockingGrid", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showWatchAreas", propertiesFactory:function () : Object
                            {
                                return {null:"show watch areas"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showSectorGrid", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showLandingField", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showDeposits", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showFPS", propertiesFactory:function () : Object
                            {
                                return {null:"show fps counter"};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, stylesFactory:function () : void
                            {
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {text:"Debug Settings"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showIsoDebugGrid", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showBackgroundGrid", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showCursorDebugInfo", propertiesFactory:function () : Object
                            {
                                return {label:"show Cursor Debug Info"};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"showMemoryMonitor", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"disableFog", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:CheckBox, id:"debugQuestGui", propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:Button, id:"SetFilterButton", propertiesFactory:function () : Object
                            {
                                return {width:121.5, label:"Set Filter"};
                            }// end function
                            }), new UIComponentDescriptor({type:TextInput, id:"CHEATWINDOW_FILTER_TEXTINPUT", propertiesFactory:function () : Object
                            {
                                return {enabled:true, text:"none"};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, stylesFactory:function () : void
                        {
                            null.fontWeight = this;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {x:224, y:12, text:"Resize browser window"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"resizeToMin", propertiesFactory:function () : Object
                        {
                            return {null:null, y:36, label:"SWMMO min", width:100};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"resizeToFB", propertiesFactory:function () : Object
                        {
                            return {x:332, y:36, label:"Facebook", width:100};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, stylesFactory:function () : void
                        {
                            null.fontWeight = this;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:229, y:66, text:"Game speed"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"SetCityLevel", propertiesFactory:function () : Object
                        {
                            return {null:229, y:129, label:"Set Player Level", width:121};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"GAMESPEED_TEXTINPUT_ID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:83, text:"37.0"};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"SPOOLTIME_TEXTINPUT_ID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:237, text:"1"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"SpoolTimeID", propertiesFactory:function () : Object
                        {
                            return {x:229, y:207, label:"Spool Time", width:90};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"SpoolTimeAddMinutesID", propertiesFactory:function () : Object
                        {
                            return {x:226.5, y:267, label:"Add Minutes", width:121.5};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"SPOOLTIME_TEXTINPUTADDMINUTES_ID", propertiesFactory:function () : Object
                        {
                            return {null:229, y:297, text:"60"};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"SETCITYLEVEL_TEXTINPUT_ID0", propertiesFactory:function () : Object
                        {
                            return {null:229, y:159, text:"1"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"SetGodMode", propertiesFactory:function () : Object
                        {
                            return {null:null, y:348, label:"Set Max Player Level  and Resources", width:244, height:30};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"resourceTab", propertiesFactory:function () : Object
                    {
                        return {label:"Resources", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:TileList, id:"resourcesList", stylesFactory:function () : void
                        {
                            this.left = "5";
                            this.right = "5";
                            this.top = "5";
                            this.bottom = "35";
                            this.borderThickness = 0;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {itemRenderer:_CheatWindow_ClassFactory1_c()};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"BUTTON_RESOURCES_FILL_MAXIMUM", stylesFactory:function () : void
                        {
                            this.bottom = "10";
                            this.right = "274";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {label:"Fill Maximum"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"applyResources", stylesFactory:function () : void
                        {
                            this.right = "10";
                            this.bottom = "10";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"BUTTON_RESOURCES_CLEAR_ALL", stylesFactory:function () : void
                        {
                            this.bottom = "10";
                            this.right = "78";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"BUTTON_RESOURCES_FILL_ALL", stylesFactory:function () : void
                        {
                            this.bottom = "10";
                            this.right = "159";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {label:"Fill 50 Percent"};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"consoleTab", propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Console", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:TextArea, id:"console", events:{valueCommit:"__console_valueCommit"}, propertiesFactory:function () : Object
                        {
                            return {editable:false, percentWidth:100, percentHeight:100};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"SupportTab", propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Support", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Button, id:"GrabForeignZoneID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:10, label:"Grab Foreign Zone", width:150.5};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID", propertiesFactory:function () : Object
                        {
                            return {null:10, y:40, text:"PlayerName"};
                        }// end function
                        }), new UIComponentDescriptor({type:TextInput, id:"LOCALSERVERDATE_TEXTINPUT_ID", propertiesFactory:function () : Object
                        {
                            return {null:10, y:194, height:25, text:"-"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"SetFakeServerDateID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:139, label:"Set Fake Server Date", width:150.5};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"ORGINAL_SERVER_DATE_ID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:257, text:"-"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"ResetFakeServerDateID", propertiesFactory:function () : Object
                        {
                            return {x:10, y:164, label:"Reset Fake Server Date", width:174};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"HOURS_TIL_NEXT_DAY_ID", propertiesFactory:function () : Object
                        {
                            return {null:null, y:277, text:"-"};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"TIME_OFFSET_ID", propertiesFactory:function () : Object
                        {
                            return {x:10, y:297, text:"-"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"RefreshAllID0", propertiesFactory:function () : Object
                        {
                            return {null:null, y:227, label:"Refresh All", width:112};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"AddOneDayID", propertiesFactory:function () : Object
                        {
                            return {x:189, y:194, label:"Add One Day", width:112, toolTip:"Sets Fake Date and adds one day"};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"InsertZoneEventLogID", propertiesFactory:function () : Object
                        {
                            return {x:10, y:340, label:"Insert log of zoneEvents", width:200, toolTip:"Logs the zone event log into database!"};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"QuestTab", propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, percentHeight:100, label:"Quests", childDescriptors:[new UIComponentDescriptor({type:DataGrid, id:"QUEST_LIST_ID", stylesFactory:function () : void
                        {
                            null.left = this;
                            this.right = "10";
                            this.top = "10";
                            this.borderStyle = "none";
                            this.color = 468010;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:339, toolTip:"abc", variableRowHeight:true, columns:[_CheatWindow_DataGridColumn1_c(), _CheatWindow_DataGridColumn2_c(), _CheatWindow_DataGridColumn3_c(), _CheatWindow_DataGridColumn4_c()]};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"QUEST_SHOW_ID", stylesFactory:function () : void
                        {
                            this.right = "426";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null, label:"Show", width:82, height:24};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"QUEST_DROP_ID", stylesFactory:function () : void
                        {
                            this.right = "336";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null, label:"Drop", width:82, height:24};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"QUEST_REFRESH_ID", stylesFactory:function () : void
                        {
                            this.right = "246";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:543, label:"Refresh", width:82, height:24};
                        }// end function
                        }), new UIComponentDescriptor({type:CheckBox, id:"SHOW_ALL_QUESTS_ID", stylesFactory:function () : void
                        {
                            this.right = "37";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {y:545, width:82, label:"Show all", selected:true};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, id:"CHEATWINDOW_TEXT_CANVAS", propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {x:0, y:367, width:518, height:168, verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:Text, id:"QUEST_INFO_TEXT_ID", propertiesFactory:function () : Object
                            {
                                return {null:null, y:10, width:488, height:1000, text:"-"};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"QUEST_FINISH_WITH_GEMS_ID", stylesFactory:function () : void
                        {
                            null.right = this;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:543, label:"Finish with Gems", visible:false, width:101, height:24};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.title = "Cheat Window";
            this.showCloseButton = true;
            this.layout = "absolute";
            this.width = 540;
            this.height = 640;
            return;
        }// end function

        public function get showBackgroundGrid() : CheckBox
        {
            return this._1088473615showBackgroundGrid;
        }// end function

        public function get BUTTON_RESOURCES_CLEAR_ALL() : Button
        {
            return this._1252453928BUTTON_RESOURCES_CLEAR_ALL;
        }// end function

        public function set SpoolTimeAddMinutesID(param1:Button) : void
        {
            var _loc_2:* = this._1197788949SpoolTimeAddMinutesID;
            if (_loc_2 !== param1)
            {
                this._1197788949SpoolTimeAddMinutesID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SpoolTimeAddMinutesID", _loc_2, param1));
            }
            return;
        }// end function

        public function get showCursorDebugInfo() : CheckBox
        {
            return this._1085103662showCursorDebugInfo;
        }// end function

        public function set ORGINAL_SERVER_DATE_ID(param1:Label) : void
        {
            var _loc_2:* = this._2112342757ORGINAL_SERVER_DATE_ID;
            if (_loc_2 !== param1)
            {
                this._2112342757ORGINAL_SERVER_DATE_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ORGINAL_SERVER_DATE_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set showMemoryMonitor(param1:CheckBox) : void
        {
            var _loc_2:* = this._1202389732showMemoryMonitor;
            if (_loc_2 !== param1)
            {
                this._1202389732showMemoryMonitor = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showMemoryMonitor", _loc_2, param1));
            }
            return;
        }// end function

        public function get SetFilterButton() : Button
        {
            return this._1106925012SetFilterButton;
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

        public function get tabNavigator() : TabNavigator
        {
            return this._261440066tabNavigator;
        }// end function

        public function set SPOOLTIME_TEXTINPUT_ID(param1:TextInput) : void
        {
            var _loc_2:* = this._1576126688SPOOLTIME_TEXTINPUT_ID;
            if (_loc_2 !== param1)
            {
                this._1576126688SPOOLTIME_TEXTINPUT_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SPOOLTIME_TEXTINPUT_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set refreshHomeZone(param1:Button) : void
        {
            var _loc_2:* = this._862843174refreshHomeZone;
            if (_loc_2 !== param1)
            {
                this._862843174refreshHomeZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "refreshHomeZone", _loc_2, param1));
            }
            return;
        }// end function

        public function set BUTTON_RESOURCES_CLEAR_ALL(param1:Button) : void
        {
            var _loc_2:* = this._1252453928BUTTON_RESOURCES_CLEAR_ALL;
            if (_loc_2 !== param1)
            {
                this._1252453928BUTTON_RESOURCES_CLEAR_ALL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "BUTTON_RESOURCES_CLEAR_ALL", _loc_2, param1));
            }
            return;
        }// end function

        public function get applyResources() : Button
        {
            return this._1803200937applyResources;
        }// end function

        public function set SetFilterButton(param1:Button) : void
        {
            var _loc_2:* = this._1106925012SetFilterButton;
            if (_loc_2 !== param1)
            {
                this._1106925012SetFilterButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetFilterButton", _loc_2, param1));
            }
            return;
        }// end function

        public function get LOCALSERVERDATE_TEXTINPUT_ID() : TextInput
        {
            return this._1095425440LOCALSERVERDATE_TEXTINPUT_ID;
        }// end function

        public function get resourcesList() : TileList
        {
            return this._996886627resourcesList;
        }// end function

        public function get GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID() : TextInput
        {
            return this._60599402GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID;
        }// end function

        public function get SETCITYLEVEL_TEXTINPUT_ID0() : TextInput
        {
            return this._2117550485SETCITYLEVEL_TEXTINPUT_ID0;
        }// end function

        public function get debugQuestGui() : CheckBox
        {
            return this._1061598316debugQuestGui;
        }// end function

        public function get SpoolTimeID() : Button
        {
            return this._1627967607SpoolTimeID;
        }// end function

        public function set showCursorDebugInfo(param1:CheckBox) : void
        {
            var _loc_2:* = this._1085103662showCursorDebugInfo;
            if (_loc_2 !== param1)
            {
                this._1085103662showCursorDebugInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showCursorDebugInfo", _loc_2, param1));
            }
            return;
        }// end function

        public function get HOURS_TIL_NEXT_DAY_ID() : Label
        {
            return this._211895922HOURS_TIL_NEXT_DAY_ID;
        }// end function

        public function get GAMESPEED_TEXTINPUT_ID() : TextInput
        {
            return this._1522746745GAMESPEED_TEXTINPUT_ID;
        }// end function

        private function _CheatWindow_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = CheatWindow_inlineComponent1;
            _loc_1.properties = {outerDocument:this};
            return _loc_1;
        }// end function

        public function set QUEST_INFO_TEXT_ID(param1:Text) : void
        {
            var _loc_2:* = this._130813753QUEST_INFO_TEXT_ID;
            if (_loc_2 !== param1)
            {
                this._130813753QUEST_INFO_TEXT_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_INFO_TEXT_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set tabNavigator(param1:TabNavigator) : void
        {
            var _loc_2:* = this._261440066tabNavigator;
            if (_loc_2 !== param1)
            {
                this._261440066tabNavigator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tabNavigator", _loc_2, param1));
            }
            return;
        }// end function

        public function get settingsTab() : Canvas
        {
            return this._121310094settingsTab;
        }// end function

        public function get AddOneDayID() : Button
        {
            return this._1624450414AddOneDayID;
        }// end function

        public function set resizeToFB(param1:Button) : void
        {
            var _loc_2:* = this._2049964875resizeToFB;
            if (_loc_2 !== param1)
            {
                this._2049964875resizeToFB = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resizeToFB", _loc_2, param1));
            }
            return;
        }// end function

        public function set SHOW_ALL_QUESTS_ID(param1:CheckBox) : void
        {
            var _loc_2:* = this._1358891337SHOW_ALL_QUESTS_ID;
            if (_loc_2 !== param1)
            {
                this._1358891337SHOW_ALL_QUESTS_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SHOW_ALL_QUESTS_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceTab() : Canvas
        {
            return this._1234526375resourceTab;
        }// end function

        public function get showSectorGrid() : CheckBox
        {
            return this._2093280599showSectorGrid;
        }// end function

        public function set TIME_OFFSET_ID(param1:Label) : void
        {
            var _loc_2:* = this._1790038357TIME_OFFSET_ID;
            if (_loc_2 !== param1)
            {
                this._1790038357TIME_OFFSET_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "TIME_OFFSET_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get showFPS() : CheckBox
        {
            return this._2067265708showFPS;
        }// end function

        public function set applyResources(param1:Button) : void
        {
            var _loc_2:* = this._1803200937applyResources;
            if (_loc_2 !== param1)
            {
                this._1803200937applyResources = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "applyResources", _loc_2, param1));
            }
            return;
        }// end function

        public function get GrabForeignZoneID() : Button
        {
            return this._2008846161GrabForeignZoneID;
        }// end function

        public function set console(param1:TextArea) : void
        {
            var _loc_2:* = this._951510359console;
            if (_loc_2 !== param1)
            {
                this._951510359console = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "console", _loc_2, param1));
            }
            return;
        }// end function

        public function get disableFog() : CheckBox
        {
            return this._1618925386disableFog;
        }// end function

        public function get SetCityLevel() : Button
        {
            return this._579519159SetCityLevel;
        }// end function

        public function get consoleTab() : Canvas
        {
            return this._338964802consoleTab;
        }// end function

        public function get showBlockingGrid() : CheckBox
        {
            return this._1855855432showBlockingGrid;
        }// end function

        public function get QUEST_REFRESH_ID() : Button
        {
            return this._992483516QUEST_REFRESH_ID;
        }// end function

        public function set resourcesList(param1:TileList) : void
        {
            var _loc_2:* = this._996886627resourcesList;
            if (_loc_2 !== param1)
            {
                this._996886627resourcesList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourcesList", _loc_2, param1));
            }
            return;
        }// end function

        public function get SetFakeServerDateID() : Button
        {
            return this._1698020035SetFakeServerDateID;
        }// end function

        public function set SupportTab(param1:Canvas) : void
        {
            var _loc_2:* = this._1379556710SupportTab;
            if (_loc_2 !== param1)
            {
                this._1379556710SupportTab = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SupportTab", _loc_2, param1));
            }
            return;
        }// end function

        public function get CHEATWINDOW_TEXT_CANVAS() : Canvas
        {
            return this._852461362CHEATWINDOW_TEXT_CANVAS;
        }// end function

        public function set LOCALSERVERDATE_TEXTINPUT_ID(param1:TextInput) : void
        {
            var _loc_2:* = this._1095425440LOCALSERVERDATE_TEXTINPUT_ID;
            if (_loc_2 !== param1)
            {
                this._1095425440LOCALSERVERDATE_TEXTINPUT_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "LOCALSERVERDATE_TEXTINPUT_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get showIsoDebugGrid() : CheckBox
        {
            return this._261364945showIsoDebugGrid;
        }// end function

        public function set GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID(param1:TextInput) : void
        {
            var _loc_2:* = this._60599402GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID;
            if (_loc_2 !== param1)
            {
                this._60599402GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GRABFOREIGNZONE_TEXTINPUTADDMINUTES_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set SETCITYLEVEL_TEXTINPUT_ID0(param1:TextInput) : void
        {
            var _loc_2:* = this._2117550485SETCITYLEVEL_TEXTINPUT_ID0;
            if (_loc_2 !== param1)
            {
                this._2117550485SETCITYLEVEL_TEXTINPUT_ID0 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SETCITYLEVEL_TEXTINPUT_ID0", _loc_2, param1));
            }
            return;
        }// end function

        public function set debugQuestGui(param1:CheckBox) : void
        {
            var _loc_2:* = this._1061598316debugQuestGui;
            if (_loc_2 !== param1)
            {
                this._1061598316debugQuestGui = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "debugQuestGui", _loc_2, param1));
            }
            return;
        }// end function

        public function get showWatchAreas() : CheckBox
        {
            return this._1466438868showWatchAreas;
        }// end function

        public function get showLandingField() : CheckBox
        {
            return this._1132644544showLandingField;
        }// end function

        public function set HOURS_TIL_NEXT_DAY_ID(param1:Label) : void
        {
            var _loc_2:* = this._211895922HOURS_TIL_NEXT_DAY_ID;
            if (_loc_2 !== param1)
            {
                this._211895922HOURS_TIL_NEXT_DAY_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "HOURS_TIL_NEXT_DAY_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set QuestTab(param1:Canvas) : void
        {
            var _loc_2:* = this._1101246605QuestTab;
            if (_loc_2 !== param1)
            {
                this._1101246605QuestTab = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QuestTab", _loc_2, param1));
            }
            return;
        }// end function

        public function get InsertZoneEventLogID() : Button
        {
            return this._1192393962InsertZoneEventLogID;
        }// end function

        public function get QUEST_FINISH_WITH_GEMS_ID() : Button
        {
            return this._804167404QUEST_FINISH_WITH_GEMS_ID;
        }// end function

        public function set SpoolTimeID(param1:Button) : void
        {
            var _loc_2:* = this._1627967607SpoolTimeID;
            if (_loc_2 !== param1)
            {
                this._1627967607SpoolTimeID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SpoolTimeID", _loc_2, param1));
            }
            return;
        }// end function

        public function set settingsTab(param1:Canvas) : void
        {
            var _loc_2:* = this._121310094settingsTab;
            if (_loc_2 !== param1)
            {
                this._121310094settingsTab = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "settingsTab", _loc_2, param1));
            }
            return;
        }// end function

        private function _CheatWindow_DataGridColumn4_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Info";
            _loc_1.dataField = "info";
            _loc_1.width = 20;
            return _loc_1;
        }// end function

        public function get CHEATWINDOW_FILTER_TEXTINPUT() : TextInput
        {
            return this._2098857202CHEATWINDOW_FILTER_TEXTINPUT;
        }// end function

        public function get BUTTON_RESOURCES_FILL_MAXIMUM() : Button
        {
            return this._1277049579BUTTON_RESOURCES_FILL_MAXIMUM;
        }// end function

        public function set GAMESPEED_TEXTINPUT_ID(param1:TextInput) : void
        {
            var _loc_2:* = this._1522746745GAMESPEED_TEXTINPUT_ID;
            if (_loc_2 !== param1)
            {
                this._1522746745GAMESPEED_TEXTINPUT_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESPEED_TEXTINPUT_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function get SpoolTimeAddMinutesID() : Button
        {
            return this._1197788949SpoolTimeAddMinutesID;
        }// end function

        public function get ORGINAL_SERVER_DATE_ID() : Label
        {
            return this._2112342757ORGINAL_SERVER_DATE_ID;
        }// end function

        public function get showMemoryMonitor() : CheckBox
        {
            return this._1202389732showMemoryMonitor;
        }// end function

        public function set resizeToMin(param1:Button) : void
        {
            var _loc_2:* = this._875590269resizeToMin;
            if (_loc_2 !== param1)
            {
                this._875590269resizeToMin = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resizeToMin", _loc_2, param1));
            }
            return;
        }// end function

        public function get QUEST_SHOW_ID() : Button
        {
            return this._871187232QUEST_SHOW_ID;
        }// end function

        public function get SPOOLTIME_TEXTINPUT_ID() : TextInput
        {
            return this._1576126688SPOOLTIME_TEXTINPUT_ID;
        }// end function

        public function set AddOneDayID(param1:Button) : void
        {
            var _loc_2:* = this._1624450414AddOneDayID;
            if (_loc_2 !== param1)
            {
                this._1624450414AddOneDayID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AddOneDayID", _loc_2, param1));
            }
            return;
        }// end function

        public function get refreshHomeZone() : Button
        {
            return this._862843174refreshHomeZone;
        }// end function

        private function _CheatWindow_DataGridColumn3_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Triggers";
            _loc_1.dataField = "triggers";
            _loc_1.width = 30;
            return _loc_1;
        }// end function

        public function get QUEST_INFO_TEXT_ID() : Text
        {
            return this._130813753QUEST_INFO_TEXT_ID;
        }// end function

        public function set SetGodMode(param1:Button) : void
        {
            var _loc_2:* = this._868353437SetGodMode;
            if (_loc_2 !== param1)
            {
                this._868353437SetGodMode = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetGodMode", _loc_2, param1));
            }
            return;
        }// end function

        public function __console_valueCommit(event:FlexEvent) : void
        {
            this.console.verticalScrollPosition = this.console.maxVerticalScrollPosition;
            return;
        }// end function

        public function set resourceTab(param1:Canvas) : void
        {
            var _loc_2:* = this._1234526375resourceTab;
            if (_loc_2 !== param1)
            {
                this._1234526375resourceTab = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceTab", _loc_2, param1));
            }
            return;
        }// end function

        public function get resizeToFB() : Button
        {
            return this._2049964875resizeToFB;
        }// end function

        public function get TIME_OFFSET_ID() : Label
        {
            return this._1790038357TIME_OFFSET_ID;
        }// end function

        public function get console() : TextArea
        {
            return this._951510359console;
        }// end function

        public function set showSectorGrid(param1:CheckBox) : void
        {
            var _loc_2:* = this._2093280599showSectorGrid;
            if (_loc_2 !== param1)
            {
                this._2093280599showSectorGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showSectorGrid", _loc_2, param1));
            }
            return;
        }// end function

        public function get SHOW_ALL_QUESTS_ID() : CheckBox
        {
            return this._1358891337SHOW_ALL_QUESTS_ID;
        }// end function

        public function set showDeposits(param1:CheckBox) : void
        {
            var _loc_2:* = this._91467698showDeposits;
            if (_loc_2 !== param1)
            {
                this._91467698showDeposits = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showDeposits", _loc_2, param1));
            }
            return;
        }// end function

        public function get SupportTab() : Canvas
        {
            return this._1379556710SupportTab;
        }// end function

        public function set disableFog(param1:CheckBox) : void
        {
            var _loc_2:* = this._1618925386disableFog;
            if (_loc_2 !== param1)
            {
                this._1618925386disableFog = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "disableFog", _loc_2, param1));
            }
            return;
        }// end function

        public function set ResetFakeServerDateID(param1:Button) : void
        {
            var _loc_2:* = this._2040911440ResetFakeServerDateID;
            if (_loc_2 !== param1)
            {
                this._2040911440ResetFakeServerDateID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ResetFakeServerDateID", _loc_2, param1));
            }
            return;
        }// end function

        public function set showBlockingGrid(param1:CheckBox) : void
        {
            var _loc_2:* = this._1855855432showBlockingGrid;
            if (_loc_2 !== param1)
            {
                this._1855855432showBlockingGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showBlockingGrid", _loc_2, param1));
            }
            return;
        }// end function

        public function get QuestTab() : Canvas
        {
            return this._1101246605QuestTab;
        }// end function

        private function _CheatWindow_DataGridColumn2_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Questmode";
            _loc_1.dataField = "questmode";
            _loc_1.width = 20;
            return _loc_1;
        }// end function

        public function set GrabForeignZoneID(param1:Button) : void
        {
            var _loc_2:* = this._2008846161GrabForeignZoneID;
            if (_loc_2 !== param1)
            {
                this._2008846161GrabForeignZoneID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GrabForeignZoneID", _loc_2, param1));
            }
            return;
        }// end function

        public function set QUEST_REFRESH_ID(param1:Button) : void
        {
            var _loc_2:* = this._992483516QUEST_REFRESH_ID;
            if (_loc_2 !== param1)
            {
                this._992483516QUEST_REFRESH_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_REFRESH_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set consoleTab(param1:Canvas) : void
        {
            var _loc_2:* = this._338964802consoleTab;
            if (_loc_2 !== param1)
            {
                this._338964802consoleTab = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "consoleTab", _loc_2, param1));
            }
            return;
        }// end function

        public function set SetCityLevel(param1:Button) : void
        {
            var _loc_2:* = this._579519159SetCityLevel;
            if (_loc_2 !== param1)
            {
                this._579519159SetCityLevel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetCityLevel", _loc_2, param1));
            }
            return;
        }// end function

        public function set SPOOLTIME_TEXTINPUTADDMINUTES_ID(param1:TextInput) : void
        {
            var _loc_2:* = this._430664130SPOOLTIME_TEXTINPUTADDMINUTES_ID;
            if (_loc_2 !== param1)
            {
                this._430664130SPOOLTIME_TEXTINPUTADDMINUTES_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SPOOLTIME_TEXTINPUTADDMINUTES_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set showFPS(param1:CheckBox) : void
        {
            var _loc_2:* = this._2067265708showFPS;
            if (_loc_2 !== param1)
            {
                this._2067265708showFPS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showFPS", _loc_2, param1));
            }
            return;
        }// end function

        public function set SetFakeServerDateID(param1:Button) : void
        {
            var _loc_2:* = this._1698020035SetFakeServerDateID;
            if (_loc_2 !== param1)
            {
                this._1698020035SetFakeServerDateID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetFakeServerDateID", _loc_2, param1));
            }
            return;
        }// end function

        public function set showLandingField(param1:CheckBox) : void
        {
            var _loc_2:* = this._1132644544showLandingField;
            if (_loc_2 !== param1)
            {
                this._1132644544showLandingField = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showLandingField", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get resizeToMin() : Button
        {
            return this._875590269resizeToMin;
        }// end function

        public function set CHEATWINDOW_TEXT_CANVAS(param1:Canvas) : void
        {
            var _loc_2:* = this._852461362CHEATWINDOW_TEXT_CANVAS;
            if (_loc_2 !== param1)
            {
                this._852461362CHEATWINDOW_TEXT_CANVAS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "CHEATWINDOW_TEXT_CANVAS", _loc_2, param1));
            }
            return;
        }// end function

        public function get SetGodMode() : Button
        {
            return this._868353437SetGodMode;
        }// end function

        public function set RefreshAllID0(param1:Button) : void
        {
            var _loc_2:* = this._1499459633RefreshAllID0;
            if (_loc_2 !== param1)
            {
                this._1499459633RefreshAllID0 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "RefreshAllID0", _loc_2, param1));
            }
            return;
        }// end function

        public function set showBuildingDebugInfo(param1:CheckBox) : void
        {
            var _loc_2:* = this._1503921104showBuildingDebugInfo;
            if (_loc_2 !== param1)
            {
                this._1503921104showBuildingDebugInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showBuildingDebugInfo", _loc_2, param1));
            }
            return;
        }// end function

        public function set showWatchAreas(param1:CheckBox) : void
        {
            var _loc_2:* = this._1466438868showWatchAreas;
            if (_loc_2 !== param1)
            {
                this._1466438868showWatchAreas = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showWatchAreas", _loc_2, param1));
            }
            return;
        }// end function

        public function set showIsoDebugGrid(param1:CheckBox) : void
        {
            var _loc_2:* = this._261364945showIsoDebugGrid;
            if (_loc_2 !== param1)
            {
                this._261364945showIsoDebugGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showIsoDebugGrid", _loc_2, param1));
            }
            return;
        }// end function

        private function _CheatWindow_DataGridColumn1_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.width = 20;
            _loc_1.dataField = "name";
            _loc_1.dataTipField = "ass";
            _loc_1.headerText = "Name";
            _loc_1.wordWrap = false;
            return _loc_1;
        }// end function

        public function get ResetFakeServerDateID() : Button
        {
            return this._2040911440ResetFakeServerDateID;
        }// end function

        public function get showDeposits() : CheckBox
        {
            return this._91467698showDeposits;
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

        public function get SPOOLTIME_TEXTINPUTADDMINUTES_ID() : TextInput
        {
            return this._430664130SPOOLTIME_TEXTINPUTADDMINUTES_ID;
        }// end function

        public function set showGrid(param1:CheckBox) : void
        {
            var _loc_2:* = this._339209245showGrid;
            if (_loc_2 !== param1)
            {
                this._339209245showGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showGrid", _loc_2, param1));
            }
            return;
        }// end function

        public function get RefreshAllID0() : Button
        {
            return this._1499459633RefreshAllID0;
        }// end function

        public function get showBuildingDebugInfo() : CheckBox
        {
            return this._1503921104showBuildingDebugInfo;
        }// end function

        public function set InsertZoneEventLogID(param1:Button) : void
        {
            var _loc_2:* = this._1192393962InsertZoneEventLogID;
            if (_loc_2 !== param1)
            {
                this._1192393962InsertZoneEventLogID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "InsertZoneEventLogID", _loc_2, param1));
            }
            return;
        }// end function

        public function set BUTTON_RESOURCES_FILL_ALL(param1:Button) : void
        {
            var _loc_2:* = this._1570317292BUTTON_RESOURCES_FILL_ALL;
            if (_loc_2 !== param1)
            {
                this._1570317292BUTTON_RESOURCES_FILL_ALL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "BUTTON_RESOURCES_FILL_ALL", _loc_2, param1));
            }
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

        public function set BUTTON_RESOURCES_FILL_MAXIMUM(param1:Button) : void
        {
            var _loc_2:* = this._1277049579BUTTON_RESOURCES_FILL_MAXIMUM;
            if (_loc_2 !== param1)
            {
                this._1277049579BUTTON_RESOURCES_FILL_MAXIMUM = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "BUTTON_RESOURCES_FILL_MAXIMUM", _loc_2, param1));
            }
            return;
        }// end function

        public function get QUEST_LIST_ID() : DataGrid
        {
            return this._1014137377QUEST_LIST_ID;
        }// end function

        public function get showGrid() : CheckBox
        {
            return this._339209245showGrid;
        }// end function

        public function set CHEATWINDOW_FILTER_TEXTINPUT(param1:TextInput) : void
        {
            var _loc_2:* = this._2098857202CHEATWINDOW_FILTER_TEXTINPUT;
            if (_loc_2 !== param1)
            {
                this._2098857202CHEATWINDOW_FILTER_TEXTINPUT = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "CHEATWINDOW_FILTER_TEXTINPUT", _loc_2, param1));
            }
            return;
        }// end function

        public function set QUEST_FINISH_WITH_GEMS_ID(param1:Button) : void
        {
            var _loc_2:* = this._804167404QUEST_FINISH_WITH_GEMS_ID;
            if (_loc_2 !== param1)
            {
                this._804167404QUEST_FINISH_WITH_GEMS_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "QUEST_FINISH_WITH_GEMS_ID", _loc_2, param1));
            }
            return;
        }// end function

        public function set showBackgroundGrid(param1:CheckBox) : void
        {
            var _loc_2:* = this._1088473615showBackgroundGrid;
            if (_loc_2 !== param1)
            {
                this._1088473615showBackgroundGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showBackgroundGrid", _loc_2, param1));
            }
            return;
        }// end function

        public function get QUEST_DROP_ID() : Button
        {
            return this._729616878QUEST_DROP_ID;
        }// end function

        public function get BUTTON_RESOURCES_FILL_ALL() : Button
        {
            return this._1570317292BUTTON_RESOURCES_FILL_ALL;
        }// end function

    }
}
