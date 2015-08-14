package Communication.VO.UpdateVO
{
    import Communication.VO.*;
    import Enums.*;
    import flash.utils.*;

    public class dBattleResultVO extends Object
    {
        public var buildingHitPoints:int;
        public var specialistPlayerID:int;
        public var casualtiesDefender:int;
        public var lostPopulationDefender:int;
        public var attackingArmyVO:dArmyVO;
        public var unitFightDuration:int;
        public var casualtiesAttacker:int;
        public var lostPopulationAttacker:int;
        public var combatDuration:int;
        public var defendingArmyVO:dArmyVO;
        public var battleScript:String;
        public var battleResult:int;
        public var gainedXp:int;
        public var specialistUniqueID:dUniqueID;

        public function dBattleResultVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.specialistUniqueID = param1.readObject() as dUniqueID;
            this.combatDuration = param1.readInt();
            this.unitFightDuration = param1.readInt();
            this.casualtiesAttacker = param1.readInt();
            this.casualtiesDefender = param1.readInt();
            this.lostPopulationAttacker = param1.readInt();
            this.lostPopulationDefender = param1.readInt();
            this.gainedXp = param1.readInt();
            this.buildingHitPoints = param1.readInt();
            this.attackingArmyVO = param1.readObject() as dArmyVO;
            this.defendingArmyVO = param1.readObject() as dArmyVO;
            this.battleScript = param1.readUTF();
            this.battleResult = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeObject(this.specialistUniqueID);
            param1.writeInt(this.combatDuration);
            param1.writeInt(this.unitFightDuration);
            param1.writeInt(this.casualtiesAttacker);
            param1.writeInt(this.casualtiesDefender);
            param1.writeInt(this.lostPopulationAttacker);
            param1.writeInt(this.lostPopulationDefender);
            param1.writeInt(this.gainedXp);
            param1.writeInt(this.buildingHitPoints);
            param1.writeObject(this.attackingArmyVO);
            param1.writeObject(this.defendingArmyVO);
            param1.writeUTF(this.battleScript);
            param1.writeInt(this.battleResult);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dBattleResultVO" + " specialistPlayerID=\'" + this.specialistPlayerID + "\' specialistUniqueID=\'" + this.specialistUniqueID + "\' combatDuration=\'" + this.combatDuration + "\' unitFightDuration=\'" + this.unitFightDuration + "\' casualtiesAttacker=\'" + this.casualtiesAttacker + "\' casualtiesDefender=\'" + this.casualtiesDefender + "\' lostPopulationAttacker=\'" + this.lostPopulationAttacker + "\' lostPopulationDefender=\'" + this.lostPopulationDefender + "\' gainedXp=\'" + this.gainedXp + "\' buildingHitPoints=\'" + this.buildingHitPoints + "\' battleResult=\'" + BATTLE_RESULT.toString(this.battleResult) + "\' >\n";
            _loc_1 = _loc_1 + (this.attackingArmyVO + "\n");
            _loc_1 = _loc_1 + (this.defendingArmyVO + "\n");
            _loc_1 = _loc_1 + (this.battleScript + "\n");
            _loc_1 = _loc_1 + "</dBattleResultVO>";
            return _loc_1;
        }// end function

    }
}
