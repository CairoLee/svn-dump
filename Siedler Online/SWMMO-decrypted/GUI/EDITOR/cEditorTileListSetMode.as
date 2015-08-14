package GUI.EDITOR
{
    import Enums.*;
    import GUI.GENERAL.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class cEditorTileListSetMode extends cTileListSetMode
    {
        public var mAutoSwitchModes:Boolean = true;
        public var mLastLevelObjectTypeEObjectType:int;
        public var mLastLevelObjectString_string:String;

        public function cEditorTileListSetMode()
        {
            return;
        }// end function

        override public function Init(param1:TileList) : void
        {
            super.Init(param1);
            mAllowedTypes = new Array("SetBackground", "SetFreeBackground", "SetSector", "SetBlocking", "EraseBlocking", "SetLandscape", "SetBuilding", "EraseBuilding", "SelectBuilding", "SetDeposit", "EraseDeposit", "BuildWay", "EraseWay", "SetDepositAnim");
            return;
        }// end function

        override public function Click(event:ListEvent) : void
        {
            this.mLastLevelObjectTypeEObjectType = event.currentTarget.selectedItem.levelObjectType;
            this.mLastLevelObjectString_string = event.currentTarget.selectedItem.label;
            if (this.mAutoSwitchModes)
            {
                global.ui.showDepositMap = false;
                global.ui.showIsoGrid = false;
                global.ui.showIsoDebugGrid = false;
                global.ui.showBuildingDebugGrid = false;
                global.ui.showBlockingGrid = false;
                global.ui.showSectorGrid = false;
                global.ui.showLandingFields = false;
            }
            Application.application.DepositGroupWindowID.visible = false;
            Application.application.SectorModeWindow.visible = false;
            Application.application.brushSizeRadioID.visible = false;
            Application.application.SelectBuildingWindowID.visible = false;
            Application.application.AssignUnitsWindowID.visible = false;
            Application.application.SetBlockingWindowID.visible = false;
            if (this.mLastLevelObjectString_string == "SetBackground")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BACKGROUND);
            }
            else if (this.mLastLevelObjectString_string == "SetFreeBackground")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_FREEBACKGROUND);
            }
            else if (this.mLastLevelObjectString_string == "SetSector")
            {
                global.ui.mCurrentCursor.SetCursorEditMode(COMMAND.SET_SECTOR);
                if (this.mAutoSwitchModes)
                {
                    global.ui.showSectorGrid = true;
                }
                Application.application.SectorModeWindow.visible = true;
                Application.application.brushSizeRadioID.visible = true;
            }
            else if (this.mLastLevelObjectString_string == "SetBlocking")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BLOCKING);
                if (this.mAutoSwitchModes)
                {
                    global.ui.showBlockingGrid = true;
                    global.ui.showDepositMap = true;
                }
                Application.application.brushSizeRadioID.visible = true;
                Application.application.SetBlockingWindowID.visible = true;
            }
            else if (this.mLastLevelObjectString_string == "EraseBlocking")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.ERASE_BLOCKING);
                if (this.mAutoSwitchModes)
                {
                    global.ui.showDepositMap = true;
                    global.ui.showBlockingGrid = true;
                }
            }
            else if (this.mLastLevelObjectString_string == "SetLandscape")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_LANDSCAPE);
                if (this.mAutoSwitchModes)
                {
                }
            }
            else if (this.mLastLevelObjectString_string == "SetBuilding")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BUILDING_IN_EDITOR);
                if (this.mAutoSwitchModes)
                {
                }
            }
            else if (this.mLastLevelObjectString_string == "EraseBuilding")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.ERASE_BUILDING);
            }
            else if (this.mLastLevelObjectString_string == "SelectBuilding")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            }
            else if (this.mLastLevelObjectString_string == "SetDeposit")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_DEPOSIT);
                if (this.mAutoSwitchModes)
                {
                    global.ui.showDepositMap = true;
                    global.ui.showIsoGrid = true;
                }
                Application.application.DepositGroupWindowID.visible = true;
            }
            else if (this.mLastLevelObjectString_string == "EraseDeposit")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.ERASE_DEPOSIT);
                if (this.mAutoSwitchModes)
                {
                    global.ui.showDepositMap = true;
                    global.ui.showIsoGrid = true;
                }
            }
            else if (this.mLastLevelObjectString_string == "BuildWay")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.BUILD_WAY);
                if (this.mAutoSwitchModes)
                {
                }
            }
            else if (this.mLastLevelObjectString_string == "EraseWay")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.ERASE_WAY);
            }
            else if (this.mLastLevelObjectString_string == "ConnectWay")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.CONNECT_WAY);
            }
            else if (this.mLastLevelObjectString_string == "SetDepositAnim")
            {
                Application.application.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.ADD_DEPOSIT_ANIM);
            }
            return;
        }// end function

    }
}
