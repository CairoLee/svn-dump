package mx.controls.dataGridClasses
{
    import mx.controls.listClasses.*;

    public class DataGridLockedRowContentHolder extends ListBaseContentHolder
    {

        public function DataGridLockedRowContentHolder(param1:ListBase)
        {
            super(param1);
            if (param1.dataProvider)
            {
                iterator = param1.dataProvider.createCursor();
            }
            return;
        }// end function

        override public function get measuredHeight() : Number
        {
            var _loc_1:* = rowInfo.length;
            if (_loc_1 == 0)
            {
                return 0;
            }
            return rowInfo[(_loc_1 - 1)].y + rowInfo[(_loc_1 - 1)].height;
        }// end function

    }
}
