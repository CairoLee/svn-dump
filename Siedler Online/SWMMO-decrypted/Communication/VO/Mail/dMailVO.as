package Communication.VO.Mail
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dMailVO extends Object implements IEventDispatcher
    {
        private var _1867885268subject:String;
        private var _3575610type:int;
        private var _1247963696senderId:int;
        private var _738997328attachments:Object;
        private var _3355id:int;
        private var _bindingEventDispatcher:EventDispatcher;
        private var _997385824senderName:String;
        private var _3496342read:Boolean;
        private var _3029410body:String;
        private var _1297018337reciepientId:int;
        private var _358705620deletedAt:int;
        private var _55126294timestamp:Number;

        public function dMailVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.id = param1.readInt();
            this.type = param1.readInt();
            this.read = param1.readBoolean();
            this.timestamp = param1.readDouble();
            this.subject = param1.readUTF();
            this.body = param1.readUTF();
            this.attachments = param1.readObject();
            this.senderName = param1.readUTF();
            this.senderId = param1.readInt();
            this.reciepientId = param1.readInt();
            this.deletedAt = param1.readInt();
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get read() : Boolean
        {
            return this._3496342read;
        }// end function

        public function get id() : int
        {
            return this._3355id;
        }// end function

        public function get timestamp() : Number
        {
            return this._55126294timestamp;
        }// end function

        public function get body() : String
        {
            return this._3029410body;
        }// end function

        public function set timestamp(param1:Number) : void
        {
            var _loc_2:* = this._55126294timestamp;
            if (_loc_2 !== param1)
            {
                this._55126294timestamp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "timestamp", _loc_2, param1));
            }
            return;
        }// end function

        public function get attachments() : Object
        {
            return this._738997328attachments;
        }// end function

        public function get subject() : String
        {
            return this._1867885268subject;
        }// end function

        public function set id(param1:int) : void
        {
            var _loc_2:* = this._3355id;
            if (_loc_2 !== param1)
            {
                this._3355id = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "id", _loc_2, param1));
            }
            return;
        }// end function

        public function get senderId() : int
        {
            return this._1247963696senderId;
        }// end function

        public function set senderName(param1:String) : void
        {
            var _loc_2:* = this._997385824senderName;
            if (_loc_2 !== param1)
            {
                this._997385824senderName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "senderName", _loc_2, param1));
            }
            return;
        }// end function

        public function get type() : int
        {
            return this._3575610type;
        }// end function

        public function set body(param1:String) : void
        {
            var _loc_2:* = this._3029410body;
            if (_loc_2 !== param1)
            {
                this._3029410body = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "body", _loc_2, param1));
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function set reciepientId(param1:int) : void
        {
            var _loc_2:* = this._1297018337reciepientId;
            if (_loc_2 !== param1)
            {
                this._1297018337reciepientId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "reciepientId", _loc_2, param1));
            }
            return;
        }// end function

        public function get deletedAt() : int
        {
            return this._358705620deletedAt;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.id);
            param1.writeInt(this.type);
            param1.writeBoolean(this.read);
            param1.writeDouble(this.timestamp);
            param1.writeUTF(this.subject);
            param1.writeUTF(this.body);
            param1.writeObject(this.attachments);
            param1.writeUTF(this.senderName);
            param1.writeInt(this.senderId);
            param1.writeInt(this.reciepientId);
            param1.writeInt(this.deletedAt);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function set subject(param1:String) : void
        {
            var _loc_2:* = this._1867885268subject;
            if (_loc_2 !== param1)
            {
                this._1867885268subject = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subject", _loc_2, param1));
            }
            return;
        }// end function

        public function set read(param1:Boolean) : void
        {
            var _loc_2:* = this._3496342read;
            if (_loc_2 !== param1)
            {
                this._3496342read = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "read", _loc_2, param1));
            }
            return;
        }// end function

        public function set deletedAt(param1:int) : void
        {
            var _loc_2:* = this._358705620deletedAt;
            if (_loc_2 !== param1)
            {
                this._358705620deletedAt = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "deletedAt", _loc_2, param1));
            }
            return;
        }// end function

        public function set senderId(param1:int) : void
        {
            var _loc_2:* = this._1247963696senderId;
            if (_loc_2 !== param1)
            {
                this._1247963696senderId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "senderId", _loc_2, param1));
            }
            return;
        }// end function

        public function get reciepientId() : int
        {
            return this._1297018337reciepientId;
        }// end function

        public function set attachments(param1:Object) : void
        {
            var _loc_2:* = this._738997328attachments;
            if (_loc_2 !== param1)
            {
                this._738997328attachments = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "attachments", _loc_2, param1));
            }
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dMailVO ";
            _loc_1 = _loc_1 + ("id=\'" + this.id + "\' ");
            _loc_1 = _loc_1 + ("type=\'" + this.type + "\' ");
            _loc_1 = _loc_1 + ("read=\'" + this.read + "\' ");
            _loc_1 = _loc_1 + ("timestamp=\'" + this.timestamp + "\' ");
            _loc_1 = _loc_1 + ("subject=\'" + this.subject + "\' ");
            _loc_1 = _loc_1 + ("body=\'" + this.body + "\' ");
            _loc_1 = _loc_1 + ("attachments=\'" + this.attachments + "\' ");
            _loc_1 = _loc_1 + ("senderName=\'" + this.senderName + "\' ");
            _loc_1 = _loc_1 + ("senderId=\'" + this.senderId + "\' ");
            _loc_1 = _loc_1 + ("reciepientId=\'" + this.reciepientId + "\' ");
            _loc_1 = _loc_1 + ("deletedAt=\'" + this.deletedAt + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

        public function get senderName() : String
        {
            return this._997385824senderName;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function set type(param1:int) : void
        {
            var _loc_2:* = this._3575610type;
            if (_loc_2 !== param1)
            {
                this._3575610type = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "type", _loc_2, param1));
            }
            return;
        }// end function

    }
}
