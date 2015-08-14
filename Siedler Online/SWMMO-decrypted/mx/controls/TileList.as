package mx.controls
{
    import mx.controls.listClasses.*;
    import mx.core.*;

    public class TileList extends TileBase
    {
        static const VERSION:String = "3.5.0.12683";

        public function TileList()
        {
            _horizontalScrollPolicy = ScrollPolicy.AUTO;
            itemRenderer = new ClassFactory(TileListItemRenderer);
            return;
        }// end function

    }
}
