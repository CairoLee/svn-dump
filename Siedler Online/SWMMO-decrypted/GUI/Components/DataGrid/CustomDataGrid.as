package GUI.Components.DataGrid
{
    import GUI.Components.ItemRenderer.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.core.*;

    public class CustomDataGrid extends DataGrid
    {

        public function CustomDataGrid()
        {
            mx_internal::headerClass = CustomDataGridHeader;
            return;
        }// end function

        override protected function mouseClickHandler(event:MouseEvent) : void
        {
            super.mouseClickHandler(event);
            if (event.target && event.target.parent && event.target.parent is TradeGridPlayerItemRenderer)
            {
                event.stopImmediatePropagation();
            }
            return;
        }// end function

        override protected function drawHeaderBackground(param1:UIComponent) : void
        {
            return;
        }// end function

    }
}
