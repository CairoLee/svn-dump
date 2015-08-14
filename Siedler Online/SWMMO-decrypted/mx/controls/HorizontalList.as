package mx.controls
{
    import mx.controls.listClasses.*;
    import mx.core.*;

    public class HorizontalList extends TileBase
    {
        static const VERSION:String = "3.5.0.12683";

        public function HorizontalList()
        {
            _horizontalScrollPolicy = ScrollPolicy.AUTO;
            _verticalScrollPolicy = ScrollPolicy.OFF;
            direction = TileBaseDirection.VERTICAL;
            maxRows = 1;
            defaultRowCount = 1;
            return;
        }// end function

    }
}
