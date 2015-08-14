package Communication.VO.UpdateVO
{
    import Communication.VO.*;

    public class dFindTreasureResponseVO extends Object
    {
        public var lootItemsVO:dLootItemsVO;
        public var specialistPlayerID:int;
        public var specialistUniqueId:dUniqueID;

        public function dFindTreasureResponseVO()
        {
            this.lootItemsVO = new dLootItemsVO();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "";
            _loc_1 = _loc_1 + ("<dFindTreasureResponseVO specialistPlayerID=\'" + this.specialistPlayerID + "\' specialistUniqueId=\'" + this.specialistUniqueId + "\' >\n");
            _loc_1 = _loc_1 + this.lootItemsVO;
            _loc_1 = _loc_1 + "</dFindTreasureResponseVO>";
            return _loc_1;
        }// end function

    }
}
