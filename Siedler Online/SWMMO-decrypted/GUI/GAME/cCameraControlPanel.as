package GUI.GAME
{
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;

    public class cCameraControlPanel extends cGuiBaseElement
    {
        private var clickOffsetY:int;
        private var mGI:cGameInterface;
        protected var mPanel:CameraControlPanel;
        private var clickOffsetX:int;

        public function cCameraControlPanel()
        {
            return;
        }// end function

        private function StopScrolling(event:MouseEvent) : void
        {
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.StopScrolling);
            this.mGI.ResetScrolling();
            return;
        }// end function

        private function MouseDownHandler(event:MouseEvent) : void
        {
            if (event.target is this.mPanel.inheritingStyles.backgroundImage && event.localY < 18)
            {
                this.clickOffsetX = event.localX;
                this.clickOffsetY = event.localY;
                Application.application.addEventListener(MouseEvent.MOUSE_UP, this.MouseUpHandler);
                Application.application.stage.addEventListener(Event.MOUSE_LEAVE, this.MouseUpHandler);
                Application.application.addEventListener(MouseEvent.MOUSE_MOVE, this.MouseMoveHandler);
            }
            return;
        }// end function

        private function MouseUpHandler(event:Event) : void
        {
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.MouseUpHandler);
            Application.application.stage.removeEventListener(Event.MOUSE_LEAVE, this.MouseUpHandler);
            Application.application.removeEventListener(MouseEvent.MOUSE_MOVE, this.MouseMoveHandler);
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        public function Init(param1:CameraControlPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnUp.addEventListener(MouseEvent.MOUSE_DOWN, this.StartScrolling);
            this.mPanel.btnLeft.addEventListener(MouseEvent.MOUSE_DOWN, this.StartScrolling);
            this.mPanel.btnRight.addEventListener(MouseEvent.MOUSE_DOWN, this.StartScrolling);
            this.mPanel.btnDown.addEventListener(MouseEvent.MOUSE_DOWN, this.StartScrolling);
            this.mPanel.btnZoomIn.addEventListener(MouseEvent.CLICK, this.ZoomIn);
            this.mPanel.btnZoomOut.addEventListener(MouseEvent.CLICK, this.ZoomOut);
            this.mPanel.addEventListener(MouseEvent.MOUSE_DOWN, this.MouseDownHandler);
            Application.application.addEventListener(ResizeEvent.RESIZE, this.ResizeHandler);
            return;
        }// end function

        private function StartScrolling(event:MouseEvent) : void
        {
            var _loc_2:int = 0;
            switch(event.currentTarget)
            {
                case this.mPanel.btnUp:
                {
                    _loc_2 = defines.SCROLL_UP;
                    break;
                }
                case this.mPanel.btnLeft:
                {
                    _loc_2 = defines.SCROLL_LEFT;
                    break;
                }
                case this.mPanel.btnRight:
                {
                    _loc_2 = defines.SCROLL_RIGHT;
                    break;
                }
                case this.mPanel.btnDown:
                {
                    _loc_2 = defines.SCROLL_DOWN;
                    break;
                }
                default:
                {
                    break;
                }
            }
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.StopScrolling);
            this.mGI.StartScrolling(_loc_2);
            return;
        }// end function

        private function MouseMoveHandler(event:MouseEvent) : void
        {
            this.mPanel.x = event.stageX - this.clickOffsetX;
            this.mPanel.y = event.stageY - this.clickOffsetY;
            if (this.mPanel.x < 0)
            {
                this.mPanel.x = 0;
            }
            if (this.mPanel.y < 0)
            {
                this.mPanel.y = 0;
            }
            if (this.mPanel.x > Application.application.stage.stageWidth - this.mPanel.width)
            {
                this.mPanel.x = Application.application.stage.stageWidth - this.mPanel.width;
            }
            if (this.mPanel.y > Application.application.stage.stageHeight - this.mPanel.height + 18)
            {
                this.mPanel.y = Application.application.stage.stageHeight - this.mPanel.height + 18;
            }
            return;
        }// end function

        private function ResizeHandler(event:ResizeEvent) : void
        {
            if (this.mPanel.x < 0)
            {
                this.mPanel.x = 0;
            }
            if (this.mPanel.y < 0)
            {
                this.mPanel.y = 0;
            }
            if (this.mPanel.x > Application.application.stage.stageWidth - this.mPanel.width)
            {
                this.mPanel.x = Application.application.stage.stageWidth - this.mPanel.width;
            }
            if (this.mPanel.y > Application.application.stage.stageHeight - this.mPanel.height + 18)
            {
                this.mPanel.y = Application.application.stage.stageHeight - this.mPanel.height + 18;
            }
            return;
        }// end function

        private function ZoomIn(event:MouseEvent) : void
        {
            this.mGI.mZoom.AddScaleFactor(global.zoomSpeed);
            return;
        }// end function

        private function ZoomOut(event:MouseEvent) : void
        {
            this.mGI.mZoom.AddScaleFactor(-global.zoomSpeed);
            return;
        }// end function

    }
}
