package GUI.GAME
{
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import Sound.*;
    import flash.display.*;
    import flash.events.*;
    import flash.net.*;
    import mx.core.*;

    public class cOptionsPanel extends cGuiBaseElement
    {
        private var mGI:cGameInterface;
        private var mCollapsed:Boolean;
        protected var mPanel:OptionsPanel;

        public function cOptionsPanel()
        {
            return;
        }// end function

        private function ZoomOut(event:Event) : void
        {
            this.mGI.mZoom.AddScaleFactor(-global.zoomSpeed);
            return;
        }// end function

        private function OpenSupport(event:Event) : void
        {
            navigateToURL(new URLRequest(defines.SUPPORT_URL), "_blank");
            return;
        }// end function

        private function OpenForum(event:Event) : void
        {
            navigateToURL(new URLRequest(defines.FORUM_URL), "_blank");
            return;
        }// end function

        private function Logout(event:Event) : void
        {
            navigateToURL(new URLRequest(defines.BIG_BROTHER_URL), "_self");
            return;
        }// end function

        private function ToggleCameraPanel(event:MouseEvent) : void
        {
            if (globalFlash.gui.mCameraControlPanel.IsVisible())
            {
                globalFlash.gui.mCameraControlPanel.Hide();
            }
            else
            {
                globalFlash.gui.mCameraControlPanel.Show();
            }
            return;
        }// end function

        private function ToggleEffects(event:Event) : void
        {
            cSoundManager.GetInstance().ToggleEffects();
            return;
        }// end function

        public function Init(param1:OptionsPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mCollapsed = true;
            this.mPanel.btnToggleEffects.addEventListener(MouseEvent.CLICK, this.ToggleEffects);
            this.mPanel.btnToggleLoops.addEventListener(MouseEvent.CLICK, this.ToggleLoops);
            this.mPanel.btnCamera.addEventListener(MouseEvent.CLICK, this.ToggleCameraPanel);
            this.mPanel.btnSupport.addEventListener(MouseEvent.CLICK, this.OpenSupport);
            this.mPanel.btnForum.addEventListener(MouseEvent.CLICK, this.OpenForum);
            this.mPanel.btnLogout.addEventListener(MouseEvent.CLICK, this.Logout);
            this.mPanel.btnToggleEffects.selected = cLocalSettingsManager.effectsMuted;
            this.mPanel.btnToggleLoops.selected = cLocalSettingsManager.loopsMuted;
            this.mPanel.btnExpandCollapse.addEventListener(MouseEvent.CLICK, this.ToggleSize);
            return;
        }// end function

        private function ToggleFullscreen(event:MouseEvent) : void
        {
            if (Application.application.stage.displayState == StageDisplayState.FULL_SCREEN)
            {
                Application.application.stage.displayState = StageDisplayState.NORMAL;
            }
            else
            {
                Application.application.stage.displayState = StageDisplayState.FULL_SCREEN;
            }
            return;
        }// end function

        private function ZoomIn(event:Event) : void
        {
            this.mGI.mZoom.AddScaleFactor(global.zoomSpeed);
            return;
        }// end function

        private function ToggleLoops(event:Event) : void
        {
            cSoundManager.GetInstance().ToggleLoops();
            return;
        }// end function

        private function ToggleSize(event:MouseEvent) : void
        {
            if (this.mCollapsed)
            {
                this.mPanel.expand.play();
            }
            else
            {
                this.mPanel.collapse.play();
            }
            this.mCollapsed = !this.mCollapsed;
            return;
        }// end function

    }
}
