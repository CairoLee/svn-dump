package GUI.GAME
{
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import flash.events.*;
    import mx.core.*;

    public class cGameActionBar extends cGuiBaseElement
    {
        protected var mActionBar:ActionBar;
        private var mFriendsListVisible:Boolean = true;
        private var mGI:cGameInterface;

        public function cGameActionBar()
        {
            return;
        }// end function

        public function Init(param1:ActionBar) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mActionBar = param1;
            this.mActionBar.actionBarLeft.btnActionBar01.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleBaseBuildingsMenu);
            this.mActionBar.actionBarLeft.btnActionBar02.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleCL01BuildingsMenu);
            this.mActionBar.actionBarLeft.btnActionBar03.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleCL2BuildingsMenu);
            this.mActionBar.actionBarLeft.btnActionBar04.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleCL3BuildingsMenu);
            this.mActionBar.actionBarCenter.btnActionBar05.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleStarMenu);
            this.mActionBar.actionBarCenter.toggleFrindsList.addEventListener(MouseEvent.CLICK, this.ToggleFriendsList);
            this.mActionBar.actionBarRight.btnActionBar07.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleGuildWindow);
            this.mActionBar.actionBarRight.btnActionBar08.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleMailWindow);
            this.mActionBar.actionBarRight.btnActionBar09.addEventListener(MouseEvent.CLICK, globalFlash.gui.ToggleShop);
            return;
        }// end function

        public function HideStarAnim() : void
        {
            this.mActionBar.actionBarCenter.animStar.visible = false;
            return;
        }// end function

        private function ToggleFriendsList(event:MouseEvent) : void
        {
            if (this.mFriendsListVisible)
            {
                Application.application.GAMESTATE_ID_ACTIONBAR.setConstraintValue("bottom", 0);
                Application.application.blueFireComponent.setConstraintValue("bottom", 0);
                Application.application.GAMESTATE_ID_STAR_MENU.setConstraintValue("bottom", 100);
                Application.application.GAMESTATE_ID_CONSTRUCTION_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_DECORATION_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_MINIMAL_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_BUILDING_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_RESIDENCE_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_WATCHTOWER_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_WAREHOUSE_INFO_PANEL.setConstraintValue("bottom", 89);
                Application.application.GAMESTATE_ID_TAVERN_INFO_PANEL.setConstraintValue("bottom", 89);
            }
            else
            {
                Application.application.GAMESTATE_ID_ACTIONBAR.setConstraintValue("bottom", 91);
                Application.application.blueFireComponent.setConstraintValue("bottom", 91);
                Application.application.GAMESTATE_ID_STAR_MENU.setConstraintValue("bottom", 191);
                Application.application.GAMESTATE_ID_CONSTRUCTION_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_DECORATION_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_MINIMAL_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_BUILDING_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_RESIDENCE_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_WATCHTOWER_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_WAREHOUSE_INFO_PANEL.setConstraintValue("bottom", 180);
                Application.application.GAMESTATE_ID_TAVERN_INFO_PANEL.setConstraintValue("bottom", 180);
            }
            this.mFriendsListVisible = !this.mFriendsListVisible;
            return;
        }// end function

        public function ShowStarAnim() : void
        {
            this.mActionBar.actionBarCenter.animStar.visible = true;
            return;
        }// end function

    }
}
