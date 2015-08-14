package LootTableSystem
{
    import Enums.*;
    import ShopSystem.*;
    import nLib.*;

    public class cLootTableItemContent extends cItemContent
    {
        private var mPrio:int;

        public function cLootTableItemContent(param1:int, param2:int, param3:String, param4:String, param5:int, param6:int)
        {
            super(param2, param3, param4, param5, param6);
            this.mPrio = param1;
            return;
        }// end function

        override public function toString() : String
        {
            return "<cLootTableItemContent prio=\'" + this.mPrio + "\' type=\'" + ITEM_CONTENT_TYPE.toString(GetType()) + "\' resourceName_string=\'" + GetResourceName_string() + "\' name=\'" + GetName_string() + "\' count=\'" + GetCount() + "\' />";
        }// end function

        public function GetPrio() : int
        {
            return this.mPrio;
        }// end function

        public static function CreateLootTableItemContentFromXml(param1:cXML) : cLootTableItemContent
        {
            var _loc_2:* = cItemContent.CreateItemContentFromXml(param1);
            var _loc_3:* = param1.GetAttributeInt("Prio");
            var _loc_4:* = new cLootTableItemContent(_loc_3, _loc_2.GetType(), _loc_2.GetName_string(), _loc_2.GetResourceName_string(), _loc_2.GetCount(), _loc_2.GetRecurringChance());
            return new cLootTableItemContent(_loc_3, _loc_2.GetType(), _loc_2.GetName_string(), _loc_2.GetResourceName_string(), _loc_2.GetCount(), _loc_2.GetRecurringChance());
        }// end function

    }
}
