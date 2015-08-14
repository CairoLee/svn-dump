package LootTableSystem
{
    import __AS3__.vec.*;
    import nLib.*;

    public class cLootTable extends Object
    {
        private var mPlayerLevelMin:int;
        public const mItemContents_vector:Vector.<cLootTableItemContent>;
        private var mPlayerLevelMax:int;
        private var mMinContribution:int;
        private var mChanceItemsAmount:int;

        public function cLootTable(param1:int, param2:int, param3:int, param4:int)
        {
            this.mItemContents_vector = new Vector.<cLootTableItemContent>;
            this.mMinContribution = param1;
            this.mChanceItemsAmount = param2;
            this.mPlayerLevelMin = param3;
            this.mPlayerLevelMax = param4;
            return;
        }// end function

        public function GetPlayerLevelMin() : int
        {
            return this.mPlayerLevelMin;
        }// end function

        public function GetChanceItemsAmount() : int
        {
            return this.mChanceItemsAmount;
        }// end function

        public function GetMinContribution() : int
        {
            return this.mMinContribution;
        }// end function

        public function toString() : String
        {
            var _loc_2:cLootTableItemContent = null;
            var _loc_1:* = "<cLootTable ChanceItemsAmount=\'" + this.mChanceItemsAmount + "\' >\n";
            for each (_loc_2 in this.mItemContents_vector)
            {
                
                _loc_1 = _loc_1 + (_loc_2.toString() + "\n");
            }
            _loc_1 = _loc_1 + "</cLootTable>\n";
            return _loc_1;
        }// end function

        public function GetPlayerLevelMax() : int
        {
            return this.mPlayerLevelMax;
        }// end function

        public static function CreateLootTableFromXml(param1:cXML) : cLootTable
        {
            var _loc_8:cXML = null;
            var _loc_2:* = param1.GetAttributeInt("MinContribution");
            var _loc_3:* = param1.GetAttributeInt("ChanceItemsAmount");
            var _loc_4:* = param1.GetAttributeInt("PlayerLevelMin");
            var _loc_5:* = param1.GetAttributeInt("PlayerLevelMax");
            if (param1.GetAttributeInt("PlayerLevelMax") == 0)
            {
                _loc_5 = 1000;
            }
            var _loc_6:* = param1.CreateChildrenArray();
            var _loc_7:* = new cLootTable(_loc_2, _loc_3, _loc_4, _loc_5);
            for each (_loc_8 in _loc_6)
            {
                
                _loc_7.mItemContents_vector.push(cLootTableItemContent.CreateLootTableItemContentFromXml(_loc_8));
            }
            return _loc_7;
        }// end function

    }
}
