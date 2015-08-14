package mx.messaging.events
{
    import flash.events.*;
    import mx.messaging.*;

    public class ChannelEvent extends Event
    {
        public var channel:Channel;
        public var connected:Boolean;
        public var reconnecting:Boolean;
        public var rejected:Boolean;
        public static const CONNECT:String = "channelConnect";
        public static const DISCONNECT:String = "channelDisconnect";

        public function ChannelEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Channel = null, param5:Boolean = false, param6:Boolean = false, param7:Boolean = false)
        {
            super(param1, param2, param3);
            this.channel = param4;
            this.reconnecting = param5;
            this.rejected = param6;
            this.connected = param7;
            return;
        }// end function

        override public function toString() : String
        {
            return formatToString("ChannelEvent", "channelId", "reconnecting", "rejected", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override public function clone() : Event
        {
            return new ChannelEvent(type, bubbles, cancelable, channel, reconnecting, rejected, connected);
        }// end function

        public function get channelId() : String
        {
            if (channel != null)
            {
                return channel.id;
            }
            return null;
        }// end function

        public static function createEvent(param1:String, param2:Channel = null, param3:Boolean = false, param4:Boolean = false, param5:Boolean = false) : ChannelEvent
        {
            return new ChannelEvent(param1, false, false, param2, param3, param4, param5);
        }// end function

    }
}
