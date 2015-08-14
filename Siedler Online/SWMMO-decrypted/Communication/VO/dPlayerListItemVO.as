package Communication.VO
{
    import Communication.VO.UpdateVO.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dPlayerListItemVO extends Object implements IEventDispatcher
    {
        public var adventureVO:dAdventureClientInfoVO = null;
        private var _1159866405onlineStatus:Boolean;
        public var avatarId:int;
        public var username:String;
        public var id:int;
        public var playerLevel:int;
        private var _bindingEventDispatcher:EventDispatcher;

        public function dPlayerListItemVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.id = param1.readInt();
            this.avatarId = param1.readInt();
            this.username = param1.readUTF();
            this.playerLevel = param1.readInt();
            this.onlineStatus = param1.readBoolean();
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.id);
            param1.writeInt(this.avatarId);
            param1.writeUTF(this.username);
            param1.writeInt(this.playerLevel);
            param1.writeBoolean(this.onlineStatus);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function set onlineStatus(param1:Boolean) : void
        {
            var _loc_2:* = this._1159866405onlineStatus;
            if (_loc_2 !== param1)
            {
                this._1159866405onlineStatus = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "onlineStatus", _loc_2, param1));
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function get onlineStatus() : Boolean
        {
            return this._1159866405onlineStatus;
        }// end function

    }
}
