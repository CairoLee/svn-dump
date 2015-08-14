package NewQuestSystem.Server
{
    import Communication.VO.*;
    import GOSets.*;
    import Interface.*;

    final public class TriggerActions extends Object
    {
        private var mGeneralInterface:cGeneralInterface;

        public function TriggerActions(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function startOnCompleteEffects(param1:dQuestDefinitionTriggerVO) : void
        {
            if (param1.onComplete == "")
            {
                return;
            }
            var _loc_2:* = param1.onComplete.split(",");
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                var _loc_4:String = this;
                _loc_4.this[_loc_2[_loc_3]](param1);
                _loc_3++;
            }
            return;
        }// end function

        public function destroySelectedBuilding(param1:dQuestDefinitionTriggerVO) : void
        {
            var _loc_3:cGOSetList = null;
            if (this.mGeneralInterface.mCurrentlySelectededBuilding == null)
            {
                return;
            }
            var _loc_2:* = this.mGeneralInterface.mCurrentlySelectededBuilding.GetBuildingGrid();
            if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mGoSetListAnimation == null)
            {
                _loc_3 = this.mGeneralInterface.mCurrentlySelectededBuilding.GetDestructionAnimEffectSet();
                this.mGeneralInterface.mGoSetListAnimationManager.AddAnimation(_loc_2, _loc_3.mName_string, 0, global.streetGridYHalf, null);
                this.mGeneralInterface.mCurrentlySelectededBuilding.mIsSelectable = false;
            }
            return;
        }// end function

    }
}
