package ShopSystem
{
    import __AS3__.vec.*;
    import nLib.*;

    public class cShopItemGroup extends Object
    {
        private var id:int;
        public var name_string:String;
        private var mHideInShop:Boolean;
        public const shopItems_vector:Vector.<cShopItem>;
        private var sortIndex:int;
        private static var map_ShopItemGroupId_ShopItemGroup:Object = new Object();

        public function cShopItemGroup(param1:int, param2:String, param3:int, param4:Boolean)
        {
            this.shopItems_vector = new Vector.<cShopItem>;
            this.id = param1;
            this.name_string = param2;
            this.sortIndex = param3;
            this.mHideInShop = param4;
            return;
        }// end function

        public function GetId() : int
        {
            return this.id;
        }// end function

        public function toString() : String
        {
            var _loc_2:cShopItem = null;
            var _loc_1:* = "<cShopItemGroup id=\'" + this.id + "\' name=\'" + this.name_string + "\' >\n";
            for each (_loc_2 in this.shopItems_vector)
            {
                
                _loc_1 = _loc_1 + (_loc_2 + "\n");
            }
            _loc_1 = _loc_1 + "</cShopItemGroup>";
            return _loc_1;
        }// end function

        public function GetName_string() : String
        {
            return this.name_string;
        }// end function

        public function AddShopItem(param1:cShopItem) : void
        {
            this.shopItems_vector.push(param1);
            return;
        }// end function

        public function GetSortIndex() : int
        {
            return this.sortIndex;
        }// end function

        public static function GetShopItemGroup(param1:int) : cShopItemGroup
        {
            return map_ShopItemGroupId_ShopItemGroup[param1] as ;
        }// end function

        public static function GetAllShopItemGroups() : Array
        {
            var _loc_2:String = null;
            var _loc_3:cShopItemGroup = null;
            var _loc_1:Array = [];
            for (_loc_2 in map_ShopItemGroupId_ShopItemGroup)
            {
                
                _loc_3 = map_ShopItemGroupId_ShopItemGroup[_loc_2];
                if (!_loc_3.mHideInShop)
                {
                    _loc_1.push(_loc_3);
                }
            }
            _loc_1.sort(SortGroups);
            return _loc_1;
        }// end function

        public static function SortGroups(param1:cShopItemGroup, param2:cShopItemGroup) : int
        {
            return param1.GetSortIndex() - param2.GetSortIndex();
        }// end function

        public static function ReadShopItemGroupFromXml(param1:cXML) : cShopItemGroup
        {
            var _loc_2:* = param1.GetAttributeInt("id");
            var _loc_3:* = param1.GetAttributeString_string("name");
            var _loc_4:* = param1.GetAttributeInt("sortIndex");
            var _loc_5:* = param1.GetAttributeBool("hideInShop");
            var _loc_6:* = new cShopItemGroup(_loc_2, _loc_3, _loc_4, _loc_5);
            map_ShopItemGroupId_ShopItemGroup[_loc_2] = _loc_6;
            return _loc_6;
        }// end function

    }
}
