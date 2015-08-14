package GUI.Components.ItemRenderer
{
    import Communication.VO.Mail.*;
    import GUI.Components.ToolTips.*;
    import mx.controls.*;
    import mx.events.*;

    public class MailGridTextItemRenderer extends Label
    {

        public function MailGridTextItemRenderer()
        {
            this.addEventListener("toolTipCreate", this.___MailGridTextItemRenderer_Label1_toolTipCreate);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (param1 is dMailVO)
            {
                if (dMailVO(param1).read)
                {
                    this.setStyle("fontWeight", "normal");
                }
                else
                {
                    this.setStyle("fontWeight", "bold");
                }
            }
            else
            {
                this.setStyle("fontWeight", "normal");
            }
            return;
        }// end function

        public function ___MailGridTextItemRenderer_Label1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

    }
}
