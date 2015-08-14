package GUI.GAME.Chat
{
    import ServerState.*;
    import flash.utils.*;

    public class cTradeData extends Object implements IExternalizable
    {
        public var costs:dResource;
        public var senderName:String;
        public var accepted:Boolean = false;
        public var startTime:Date;
        public var senderID:int;
        public var offer:dResource;

        public function cTradeData()
        {
            this.offer = new dResource();
            this.costs = new dResource();
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.senderID = param1.readInt();
            this.senderName = param1.readUTF();
            this.offer = param1.readObject() as dResource;
            this.costs = param1.readObject() as dResource;
            this.startTime = param1.readObject() as Date;
            this.accepted = param1.readBoolean();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.senderID);
            param1.writeUTF(this.senderName);
            param1.writeObject(this.offer);
            param1.writeObject(this.costs);
            param1.writeObject(this.startTime);
            param1.writeBoolean(this.accepted);
            return;
        }// end function

        public function toString() : String
        {
            return this.offer.name_string + "|" + this.offer.amount + "|" + this.costs.name_string + "|" + this.costs.amount;
        }// end function

        public function parseData(param1:String = null, param2:Date = null) : Boolean
        {
            if (!param1)
            {
                return false;
            }
            var _loc_3:* = param1.split("|");
            if (_loc_3.length != 4)
            {
                return false;
            }
            this.offer.name_string = _loc_3[0];
            if (isNaN(parseInt(_loc_3[1])))
            {
                return false;
            }
            this.offer.amount = parseInt(_loc_3[1]);
            if (this.offer.amount < 1)
            {
                return false;
            }
            if (this.offer.amount > defines.MAX_TRADE_LIMIT)
            {
                return false;
            }
            this.costs.name_string = _loc_3[2];
            if (isNaN(parseInt(_loc_3[3])))
            {
                return false;
            }
            this.costs.amount = parseInt(_loc_3[3]);
            if (this.costs.amount < 1)
            {
                return false;
            }
            if (this.costs.amount > defines.MAX_TRADE_LIMIT)
            {
                return false;
            }
            this.startTime = param2;
            return true;
        }// end function

    }
}
