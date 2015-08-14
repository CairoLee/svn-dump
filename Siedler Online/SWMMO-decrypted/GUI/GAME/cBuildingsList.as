package GUI.GAME
{
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import Interface.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class cBuildingsList extends cBasicPanel
    {
        public var mLastLevelEnumObjectType:int;
        private var mGI:cGameInterface;
        protected var mBuildingsList:BuildingsList;
        protected var mUIType:int;
        public var mLastLevelObjectString_string:String;

        public function cBuildingsList()
        {
            return;
        }// end function

        override public function Show() : void
        {
            this.SetData();
            super.Show();
            return;
        }// end function

        public function HighlightItem(param1:String) : void
        {
            var _loc_2:Object = null;
            for each (_loc_2 in this.mBuildingsList.dataProvider)
            {
                
                if (_loc_2.label == param1)
                {
                    _loc_2.highlighted = true;
                }
            }
            return;
        }// end function

        protected function AddSpriteListToGuiSelector(param1, param2:Array, param3:int, param4:Function) : void
        {
            var _loc_5:cGOSpriteLibContainer = null;
            var _loc_6:String = null;
            var _loc_7:Vector.<dSubtypeCalculated> = null;
            var _loc_8:Boolean = false;
            var _loc_9:Bitmap = null;
            for each (_loc_5 in param1)
            {
                
                if (this.param4(_loc_5))
                {
                    _loc_6 = _loc_5.mGfxResourceListName_string;
                    _loc_7 = _loc_5.mSubtypeCalculated_vector;
                    _loc_8 = _loc_5.mPlayerLevel > this.mGI.mCurrentPlayer.GetPlayerLevel() || this.mGI.mCurrentPlayer.mBuildQueue.IsFull() || this.mGI.mCurrentPlayer.IsMaximumPlacedBuildingCountReached(_loc_6) || this.mGI.mCurrentPlayer.mBuildQueue.IsBlockedUntilBuildQueueIsProceed();
                    _loc_9 = gAssetManager.GetBuildingIcon(_loc_6, !_loc_8);
                    if (_loc_9)
                    {
                        param2.push({label:_loc_6, bitmapData:_loc_9.bitmapData, levelObjectType:param3, gfxResourceListName:_loc_6, disabled:_loc_8, playerLevel:_loc_5.mPlayerLevel});
                    }
                }
            }
            return;
        }// end function

        protected function FilterSpriteList(param1:cGOSpriteLibContainer) : Boolean
        {
            return param1.mShowInGui != 0 && param1.mUITyp == this.mUIType;
        }// end function

        public function SetData() : void
        {
            var _loc_1:Array = [];
            if (this.mUIType == cGOSpriteLibContainer.UI_TYPE_CL01_BUILDING)
            {
                _loc_1.push({label:"BuildStreet", bitmapData:gAssetManager.GetBitmap("IconBuildStreet").bitmapData, levelObjectType:OBJECTTYPE.BUILDING, gfxResourceListName:"BuildStreet", playerLevel:0});
                _loc_1.push({label:"EraseStreet", bitmapData:gAssetManager.GetBitmap("IconEraseStreet").bitmapData, levelObjectType:OBJECTTYPE.BUILDING, gfxResourceListName:"EraseStreet", playerLevel:0});
            }
            this.AddSpriteListToGuiSelector(global.buildingGroup.mGOList_vector, _loc_1, OBJECTTYPE.BUILDING, this.FilterSpriteList);
            _loc_1.sortOn("playerLevel", Array.NUMERIC);
            this.mBuildingsList.dataProvider = new ArrayCollection(_loc_1);
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.mGI.mCurrentlySelectededBuilding = null;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            this.Hide();
            return;
        }// end function

        public function Init(param1:BuildingsList, param2:int) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mBuildingsList = param1;
            this.mUIType = param2;
            this.mLastLevelEnumObjectType = OBJECTTYPE.BUILDING;
            this.mLastLevelObjectString_string = "Farm";
            this.mBuildingsList.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mBuildingsList.tileList.addEventListener(ListEvent.ITEM_CLICK, this.Select);
            return;
        }// end function

        public function Select(event:ListEvent) : void
        {
            if (!event.currentTarget || !event.currentTarget.selectedItem)
            {
                return;
            }
            if (event.currentTarget.selectedItem.label == "BuildStreet")
            {
                this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.BUILD_WAY);
            }
            else if (event.currentTarget.selectedItem.label == "EraseStreet")
            {
                this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.ERASE_WAY);
            }
            else if (!event.currentTarget.selectedItem.disabled)
            {
                this.mGI.mCurrentCursor.SetCursorEditModeObjectName(COMMAND.SET_BUILDING_IN_GAME, event.currentTarget.selectedItem.gfxResourceListName);
                this.mGI.mCurrentCursor.SetCursor(event.currentTarget.selectedItem.levelObjectType, event.currentTarget.selectedItem.gfxResourceListName);
            }
            this.mLastLevelEnumObjectType = event.currentTarget.selectedItem.levelObjectType;
            this.mLastLevelObjectString_string = event.currentTarget.selectedItem.label;
            if (!event.currentTarget.selectedItem.disabled)
            {
                Hide();
            }
            return;
        }// end function

    }
}
