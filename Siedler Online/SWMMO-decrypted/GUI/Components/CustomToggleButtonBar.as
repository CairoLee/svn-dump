package GUI.Components
{
    import GUI.Components.ToolTips.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class CustomToggleButtonBar extends ToggleButtonBar
    {

        public function CustomToggleButtonBar()
        {
            this.addEventListener(ListEvent.ITEM_CLICK, this.changeTextAlignment);
            this.addEventListener(FlexEvent.UPDATE_COMPLETE, this.changeTextAlignment);
            this.addEventListener(FlexEvent.UPDATE_COMPLETE, this.assignToolTips);
            this.addEventListener(FlexEvent.CREATION_COMPLETE, this.assignToolTips);
            return;
        }// end function

        private function createToolTip(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function changeTextAlignment(event:Event) : void
        {
            var _loc_4:Button = null;
            if (this.dataProvider == null)
            {
                return;
            }
            this.setStyle("buttonWidth", this.width / this.dataProvider.length);
            var _loc_2:* = this.dataProvider.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = this.getChildAt(_loc_3) as Button;
                _loc_4.setStyle("paddingTop", -5);
                _loc_3++;
            }
            if (this.selectedIndex > -1)
            {
                (this.getChildAt(this.selectedIndex) as Button).setStyle("paddingTop", 0);
            }
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            super.dataProvider = param1;
            if (param1 == null)
            {
                return;
            }
            this.setStyle("buttonWidth", this.width / this.dataProvider.length);
            this.selectedIndex = 0;
            return;
        }// end function

        private function assignToolTips(event:FlexEvent) : void
        {
            var _loc_2:Button = null;
            if (this.getChildren() == null)
            {
                return;
            }
            for each (_loc_2 in this.getChildren())
            {
                
                _loc_2.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.createToolTip);
            }
            return;
        }// end function

    }
}
