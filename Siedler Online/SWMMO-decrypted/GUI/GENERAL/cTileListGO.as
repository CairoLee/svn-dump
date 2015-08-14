package GUI.GENERAL
{
    import Enums.*;
    import GO.*;
    import GUI.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import nLib.*;

    public class cTileListGO extends cTileList
    {
        public var mLastLevelEnumObjectType:int;
        public var mFilterBuildings_map:Object;
        public var mSortNames:Boolean = true;
        public var mLastLevelObjectString_string:String;

        public function cTileListGO()
        {
            this.mFilterBuildings_map = new Object();
            return;
        }// end function

        protected function FilterSpriteListLandscape(param1:cGOSpriteLibContainer) : Boolean
        {
            return param1.mShowInGui != 0;
        }// end function

        public function SetFilterBuildings(param1:String, param2:Boolean) : void
        {
            this.SetFilterBuildingsInMap(param1, param2);
            switch(param1)
            {
                case "undefined":
                {
                    Application.application.FILTER_BUILDING_undefined.selected = param2;
                    break;
                }
                case "workyard":
                {
                    Application.application.FILTER_BUILDING_workyard.selected = param2;
                    break;
                }
                case "none":
                {
                    Application.application.FILTER_BUILDING_None.selected = param2;
                    break;
                }
                case "enemy":
                {
                    Application.application.FILTER_BUILDING_Enemy.selected = param2;
                    break;
                }
                case "minimal":
                {
                    Application.application.FILTER_BUILDING_Minimal.selected = param2;
                    break;
                }
                case "watchtower":
                {
                    Application.application.FILTER_BUILDING_Watchtower.selected = param2;
                    break;
                }
                case "residence":
                {
                    Application.application.FILTER_BUILDING_Residence.selected = param2;
                    break;
                }
                case "timedproduction":
                {
                    Application.application.FILTER_BUILDING_Timedproduction.selected = param2;
                    break;
                }
                case "decoration":
                {
                    Application.application.FILTER_BUILDING_Decoration.selected = param2;
                    break;
                }
                case "sort names":
                {
                    Application.application.FILTER_BUILDING_SortNames.selected = param2;
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function InitFilterBuildingsAll(param1:Boolean) : void
        {
            this.SetFilterBuildings("undefined", param1);
            this.SetFilterBuildings("workyard", param1);
            this.SetFilterBuildings("none", param1);
            this.SetFilterBuildings("enemy", param1);
            this.SetFilterBuildings("minimal", param1);
            this.SetFilterBuildings("watchtower", param1);
            this.SetFilterBuildings("residence", param1);
            this.SetFilterBuildings("timedproduction", param1);
            this.SetFilterBuildings("decoration", param1);
            this.SetFilterBuildings("sort names", param1);
            return;
        }// end function

        public function SetData() : void
        {
            var _loc_2:cXML = null;
            var _loc_3:Vector.<cXML> = null;
            var _loc_4:cXML = null;
            var _loc_5:Sort = null;
            var _loc_1:* = new Array();
            if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BACKGROUND)
            {
                AddSpriteListToGuiSelector(global.GOListScale, global.backgroundGroup.mGOList_vector, _loc_1, OBJECTTYPE.BACKGROUND, this.FilterSpriteList, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_FREEBACKGROUND)
            {
                AddSpriteListToGuiSelector(global.GOListScale * 0.5, global.landscapeGroup.mGOList_vector, _loc_1, OBJECTTYPE.LANDSCAPE, this.FilterSpriteListLandscape, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_LANDSCAPE)
            {
                AddSpriteListToGuiSelector(global.GOListScale * 0.75, global.landscapeGroup.mGOList_vector, _loc_1, OBJECTTYPE.LANDSCAPE, this.FilterSpriteListLandscape, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BUILDING_IN_EDITOR)
            {
                AddSpriteListToGuiSelector(global.GOListScale * 0.75, global.buildingGroup.mGOList_vector, _loc_1, OBJECTTYPE.BUILDING, this.FilterSpriteListBuilding, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.ADD_DEPOSIT_ANIM)
            {
                AddSpriteListToGuiSelector(global.GOListScale, global.buildingGroup.mGOList_vector, _loc_1, OBJECTTYPE.BUILDING, this.FilterSpriteListDepositAnim, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BUILDING_IN_GAME)
            {
                AddSpriteListToGuiSelector(global.GOListScale, global.buildingGroup.mGOList_vector, _loc_1, OBJECTTYPE.BUILDING, this.FilterSpriteList, null);
            }
            else if (Application.application.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_DEPOSIT)
            {
                AddSpriteListToGuiSelector(global.GOListScale, global.guiIconGroup.mGOList_vector, _loc_1, OBJECTTYPE.DEPOSIT, this.FilterSpriteListDeposit, this.FilterNameDeposit);
                _loc_2 = global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("Deposits");
                _loc_3 = _loc_2.CreateChildrenArray();
                for each (_loc_4 in _loc_3)
                {
                    
                    _loc_1.push({label:_loc_4.GetAttributeString_string("name"), bitmapData:new BitmapData(1, 1), levelObjectType:7, gfxResourceListName:"Deposit" + _loc_4.GetAttributeString_string("type")});
                }
            }
            Application.application.mTileListDataProviderGO = new ArrayCollection(_loc_1);
            if (this.mSortNames)
            {
                _loc_5 = new Sort();
                _loc_5.fields = [new SortField("label", true)];
                Application.application.mTileListDataProviderGO.sort = _loc_5;
                Application.application.mTileListDataProviderGO.refresh();
            }
            else
            {
                Application.application.mTileListDataProviderGO.sort = null;
                Application.application.mTileListDataProviderGO.refresh();
            }
            return;
        }// end function

        protected function FilterSpriteListBuilding(param1:cGOSpriteLibContainer) : Boolean
        {
            if (!this.CheckFilterBuilding(param1))
            {
                return false;
            }
            return param1.mShowInGui != 0;
        }// end function

        public function InvertFilterBuildingsAll() : void
        {
            var _loc_1:String = null;
            for (_loc_1 in this.mFilterBuildings_map)
            {
                
                this.SetFilterBuildings(_loc_1, this.mFilterBuildings_map[_loc_1] == -1);
            }
            return;
        }// end function

        public function FilterSpriteListDepositAnim(param1:cGOSpriteLibContainer) : Boolean
        {
            return param1.mShowInGui != 0 && param1.mDepositAnimName_string != null;
        }// end function

        private function myCompare(param1:Object, param2:Object, param3:Array = null) : int
        {
            var _loc_4:int = 0;
            var _loc_5:* = param1 as String;
            var _loc_6:* = param2 as String;
            if (_loc_5 > _loc_6)
            {
                _loc_4 = 0;
            }
            else if (_loc_5 < _loc_6)
            {
                _loc_4 = 1;
            }
            return _loc_4;
        }// end function

        private function FilterNameDeposit(param1:String) : String
        {
            return param1.substr(7);
        }// end function

        public function SetFilterBuildingsAll(param1:Boolean) : void
        {
            var _loc_2:String = null;
            for (_loc_2 in this.mFilterBuildings_map)
            {
                
                this.SetFilterBuildings(_loc_2, param1);
            }
            return;
        }// end function

        private function FilterSpriteListDeposit(param1:cGOSpriteLibContainer) : Boolean
        {
            var _loc_2:* = gMisc.GetSubString_string(param1.mGfxResourceListName_string, 0, 7);
            if (_loc_2 == "Deposit")
            {
                return true;
            }
            return false;
        }// end function

        override public function Click(event:ListEvent) : void
        {
            if (event.currentTarget.selectedItem == null)
            {
                return;
            }
            this.mLastLevelEnumObjectType = event.currentTarget.selectedItem.levelObjectType;
            this.mLastLevelObjectString_string = event.currentTarget.selectedItem.label;
            Application.application.mGeneralInterface.mCurrentCursor.SetCursor(event.currentTarget.selectedItem.levelObjectType, event.currentTarget.selectedItem.gfxResourceListName);
            return;
        }// end function

        private function CheckFilterBuilding(param1:cGOSpriteLibContainer) : Boolean
        {
            var _loc_2:* = globalFlash.gui.GetInfoPanelString(param1.mGfxResourceListName_string);
            if (this.mFilterBuildings_map["undefined"] == 1)
            {
                if (this.mFilterBuildings_map[_loc_2] == null)
                {
                    return true;
                }
            }
            return this.mFilterBuildings_map[_loc_2] == 1;
        }// end function

        override public function Init(param1:TileList) : void
        {
            super.Init(param1);
            this.mLastLevelEnumObjectType = OBJECTTYPE.BUILDING;
            this.mLastLevelObjectString_string = "Farm";
            return;
        }// end function

        public function SetFilterBuildingsInMap(param1:String, param2:Boolean) : void
        {
            this.mFilterBuildings_map[param1] = param2 ? (1) : (-1);
            return;
        }// end function

        override protected function FilterSpriteList(param1:cGOSpriteLibContainer) : Boolean
        {
            return param1.mShowInGui != 0;
        }// end function

    }
}
