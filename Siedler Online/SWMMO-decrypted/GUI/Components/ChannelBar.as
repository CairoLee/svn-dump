package GUI.Components
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import flash.display.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;

    public class ChannelBar extends TileList implements IBFList
    {

        public function ChannelBar()
        {
            return;
        }// end function

        private function filterFunction(param1:Object) : Boolean
        {
            return (param1 as ChannelVO).visible;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            super.dataProvider = param1;
            (this.dataProvider as ArrayCollection).filterFunction = this.filterFunction;
            return;
        }// end function

        override protected function drawSelectionIndicator(param1:Sprite, param2:Number, param3:Number, param4:Number, param5:Number, param6:uint, param7:IListItemRenderer) : void
        {
            return;
        }// end function

    }
}
