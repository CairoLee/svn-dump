package GUI.Components.ItemRenderer
{
    import GUI.Components.ToolTips.*;
    import mx.controls.*;
    import mx.events.*;

    public class TradeGridPlayerItemRenderer extends Label
    {

        public function TradeGridPlayerItemRenderer()
        {
            this.addEventListener("toolTipCreate", this.___TradeGridPlayerItemRenderer_Label1_toolTipCreate);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        public function ___TradeGridPlayerItemRenderer_Label1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            return;
        }// end function

    }
}
