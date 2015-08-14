package Map
{
    import GO.*;
    import GOSets.*;
    import Interface.*;

    public class cGoSetListAnimationManager extends Object
    {
        private var mGeneralInterface:cGeneralInterface;

        public function cGoSetListAnimationManager(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function RenderCompute() : void
        {
            return;
        }// end function

        public function IsAnimationAtGridPos(param1:int) : Boolean
        {
            return this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mGoSetListAnimation != null;
        }// end function

        public function Remove(param1:int) : void
        {
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mGoSetListAnimation = null;
            return;
        }// end function

        public function Render() : void
        {
            return;
        }// end function

        public function RemoveSingleAnimation(param1:int) : void
        {
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mIconGoSetListAnimation = null;
            return;
        }// end function

        public function AddAnimation(param1:int, param2:String, param3:Number, param4:int, param5:Object) : void
        {
            var _loc_6:* = cGOSetManager.CreateGOSetList(param2, null);
            var _loc_7:* = new cGoSetListAnimationItem();
            new cGoSetListAnimationItem().gridPos = param1;
            gCalculations.ConvertStreetGridToPixelPos(param1, _loc_7.pixelPos);
            _loc_7.pixelPos.y = _loc_7.pixelPos.y + param4;
            _loc_7.animGoSetListContainer = _loc_6;
            _loc_7.runningTime = param3;
            _loc_7.object = param5;
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mGoSetListAnimation = _loc_7;
            return;
        }// end function

        public function AddSingleAnimation(param1:int, param2:String, param3:Number, param4:int, param5:int, param6:cGOGroup, param7:Object) : void
        {
            var _loc_8:* = cGOSetManager.CreateSingleGfxGOSetList(param2, param4, param5, param6);
            var _loc_9:* = new cGoSetListAnimationItem();
            new cGoSetListAnimationItem().gridPos = param1;
            gCalculations.ConvertStreetGridToPixelPos(param1, _loc_9.pixelPos);
            _loc_9.animGoSetListContainer = _loc_8;
            _loc_9.runningTime = param3;
            _loc_9.object = param7;
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mIconGoSetListAnimation = _loc_9;
            return;
        }// end function

        public function Reset() : void
        {
            return;
        }// end function

    }
}
