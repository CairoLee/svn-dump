package ShopSystem
{
    import Enums.*;
    import nLib.*;

    public class cItemContent extends Object
    {
        private var name_string:String;
        private var count:int;
        private var recurringChance:int;
        private var resourceName_string:String;
        private var type:int;

        public function cItemContent(param1:int, param2:String, param3:String, param4:int, param5:int)
        {
            this.type = param1;
            this.name_string = param2;
            this.resourceName_string = param3;
            this.count = param4;
            this.recurringChance = param5;
            return;
        }// end function

        public function GetResourceName_string() : String
        {
            return this.resourceName_string;
        }// end function

        public function toString() : String
        {
            return "<cItemContent type=\'" + ITEM_CONTENT_TYPE.toString(this.type) + "\' resourceName_string=\'" + this.resourceName_string + "\' name=\'" + this.name_string + "\' count=\'" + this.count + "\' />";
        }// end function

        public function GetType() : int
        {
            return this.type;
        }// end function

        public function GetName_string() : String
        {
            return this.name_string;
        }// end function

        public function GetCount() : int
        {
            return this.count;
        }// end function

        public function GetRecurringChance() : int
        {
            return this.recurringChance;
        }// end function

        public static function CreateItemContentFromXml(param1:cXML) : cItemContent
        {
            var _loc_2:* = ITEM_CONTENT_TYPE.parse(param1.GetAttributeString_string("type"));
            var _loc_3:* = param1.GetAttributeString_string("name");
            var _loc_4:* = param1.GetAttributeString_string("resource");
            var _loc_5:* = param1.GetAttributeInt("count");
            var _loc_6:* = param1.GetAttributeInt("recurringChance");
            var _loc_7:* = new cItemContent(_loc_2, _loc_3, _loc_4, _loc_5, _loc_6);
            return new cItemContent(_loc_2, _loc_3, _loc_4, _loc_5, _loc_6);
        }// end function

    }
}
