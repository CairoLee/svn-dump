package ShopSystem
{
    import ServerState.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cShopItem extends Object
    {
        private var itemContent_vector:Vector.<cItemContent>;
        private var name_string:String;
        private var frameType:String;
        private var indicator:String;
        private var quality:int;
        private var id:int;
        private var costs_vector:Vector.<dResource>;
        private var playerLevel:int;
        private var perPlayer:int;
        private var mHideInShop:Boolean;
        private var toolTipIdentifier:String;
        private var percentIncCosts:int;
        private var groupId:int;
        private var sortIdx:int;
        private static var map_ShopItemName_ShopItem:Object = new Object();

        public function cShopItem(param1:int, param2:String, param3:int, param4, param5:int, param6, param7:int, param8:int, param9:int, param10:String, param11:int, param12:Boolean, param13:String, param14:String)
        {
            this.costs_vector = new Vector.<dResource>;
            this.itemContent_vector = new Vector.<cItemContent>;
            this.id = param1;
            this.name_string = param2;
            this.groupId = param3;
            this.costs_vector = param4;
            this.itemContent_vector = param6;
            this.sortIdx = param7;
            this.playerLevel = param8;
            this.quality = param9;
            this.indicator = param10;
            this.perPlayer = param11;
            this.mHideInShop = param12;
            this.frameType = param13;
            this.toolTipIdentifier = param14;
            this.percentIncCosts = param5;
            return;
        }// end function

        public function GetIncCosts_vector(param1:int)
        {
            var _loc_4:dResource = null;
            var _loc_5:dResource = null;
            if (param1 == -1 && global.ui == null)
            {
                return this.costs_vector;
            }
            var _loc_2:* = new Vector.<dResource>;
            var _loc_3:* = global.ui != null ? (global.ui.mCurrentPlayer.GetPurchasedShopItemAmount(this.GetId())) : (param1);
            for each (_loc_4 in this.costs_vector)
            {
                
                _loc_5 = new dResource();
                _loc_5.name_string = _loc_4.name_string;
                _loc_5.amount = _loc_4.amount * (1 + this.percentIncCosts * _loc_3 / 100);
                _loc_2.push(_loc_5);
            }
            return _loc_2;
        }// end function

        public function GetPerPlayer() : int
        {
            return this.perPlayer;
        }// end function

        public function GetPlayerLevel() : int
        {
            return this.playerLevel;
        }// end function

        public function hideInShop() : Boolean
        {
            return this.mHideInShop;
        }// end function

        public function GetFrameType_string() : String
        {
            return this.frameType;
        }// end function

        public function GetToolTipIdentifier_string() : String
        {
            return this.toolTipIdentifier;
        }// end function

        public function GetGroupId() : int
        {
            return this.groupId;
        }// end function

        public function GetShopItemContent_vector()
        {
            return this.itemContent_vector;
        }// end function

        public function GetSortIdx() : int
        {
            return this.sortIdx;
        }// end function

        public function GetName_string() : String
        {
            return this.name_string;
        }// end function

        public function GetId() : int
        {
            return this.id;
        }// end function

        public function GetCosts_vector()
        {
            if (this.percentIncCosts > 0)
            {
                return this.GetIncCosts_vector(-1);
            }
            return this.costs_vector;
        }// end function

        public function toString() : String
        {
            var _loc_2:cItemContent = null;
            var _loc_1:* = "<cShopItem id=\'" + this.id + "\' name=\'" + this.name_string + "\' >\n";
            for each (_loc_2 in this.itemContent_vector)
            {
                
                _loc_1 = _loc_1 + ("  " + _loc_2 + "\n");
            }
            _loc_1 = _loc_1 + "</cShopItem>\n";
            return _loc_1;
        }// end function

        public static function CreateShopItemFromXml(param1:cXML, param2:int) : cShopItem
        {
            var _loc_17:cXML = null;
            var _loc_18:cShopItem = null;
            var _loc_19:cItemContent = null;
            var _loc_3:* = param1.GetAttributeInt("id");
            var _loc_4:* = param1.GetAttributeString_string("name");
            var _loc_5:* = param1.GetAttributeInt("sortIndex");
            var _loc_6:* = param1.GetAttributeInt("playerLevel");
            var _loc_7:* = param1.GetAttributeInt("quality");
            var _loc_8:* = param1.GetAttributeString_string("indicator");
            var _loc_9:* = param1.GetAttributeString_string("tooltip");
            var _loc_10:* = param1.GetAttributeInt("perPlayer");
            var _loc_11:* = param1.GetAttributeString_string("frameType");
            var _loc_12:* = param1.GetAttributeBool("hideInShop");
            var _loc_13:* = param1.GetAttributeInt("percentIncCosts");
            var _loc_14:* = gParse.ParseCosts(param1.MoveToSubNode("Costs"));
            var _loc_15:* = new Vector.<cItemContent>;
            var _loc_16:* = param1.MoveToSubNode("Content").CreateChildrenArray();
            for each (_loc_17 in _loc_16)
            {
                
                _loc_19 = cItemContent.CreateItemContentFromXml(_loc_17);
                _loc_15.push(_loc_19);
            }
            _loc_18 = new cShopItem(_loc_3, _loc_4, param2, _loc_14, _loc_13, _loc_15, _loc_5, _loc_6, _loc_7, _loc_8, _loc_10, _loc_12, _loc_11, _loc_9);
            map_ShopItemName_ShopItem[_loc_3] = _loc_18;
            return _loc_18;
        }// end function

        public static function GetShopItem(param1:int) : cShopItem
        {
            return map_ShopItemName_ShopItem[param1] as cShopItem;
        }// end function

    }
}
