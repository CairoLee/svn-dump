package Communication.VO
{
    import GUI.GAME.Chat.*;
    import flash.utils.*;

    public class dLocalUserSettingsVO extends Object implements IExternalizable
    {
        public var tradeCooldownStartTime:Date;
        public var effectsMuted:Boolean;
        public var currentGlobalChatInstance:int;
        public var currentTradeOffer:cTradeData;
        public var loopsMuted:Boolean;

        public function dLocalUserSettingsVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.effectsMuted = param1.readBoolean();
            this.loopsMuted = param1.readBoolean();
            this.currentTradeOffer = param1.readObject() as cTradeData;
            this.tradeCooldownStartTime = param1.readObject() as Date;
            this.currentGlobalChatInstance = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeBoolean(this.effectsMuted);
            param1.writeBoolean(this.loopsMuted);
            param1.writeObject(this.currentTradeOffer);
            param1.writeObject(this.tradeCooldownStartTime);
            param1.writeInt(this.currentGlobalChatInstance);
            return;
        }// end function

    }
}
