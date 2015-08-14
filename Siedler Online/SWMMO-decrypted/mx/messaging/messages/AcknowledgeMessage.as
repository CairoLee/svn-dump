package mx.messaging.messages
{
    import flash.utils.*;
    import mx.messaging.messages.*;

    public class AcknowledgeMessage extends AsyncMessage implements ISmallMessage
    {
        public static const ERROR_HINT_HEADER:String = "DSErrorHint";

        public function AcknowledgeMessage()
        {
            return;
        }// end function

        override public function readExternal(param1:IDataInput) : void
        {
            var _loc_4:uint = 0;
            var _loc_5:uint = 0;
            var _loc_6:uint = 0;
            super.readExternal(param1);
            var _loc_2:* = readFlags(param1);
            var _loc_3:uint = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                _loc_4 = _loc_2[_loc_3] as uint;
                _loc_5 = 0;
                if (_loc_4 >> _loc_5 != 0)
                {
                    _loc_6 = _loc_5;
                    while (_loc_6 < 6)
                    {
                        
                        if ((_loc_4 >> _loc_6 & 1) != 0)
                        {
                            param1.readObject();
                        }
                        _loc_6 = _loc_6 + 1;
                    }
                }
                _loc_3 = _loc_3 + 1;
            }
            return;
        }// end function

        override public function writeExternal(param1:IDataOutput) : void
        {
            super.writeExternal(param1);
            var _loc_2:uint = 0;
            param1.writeByte(_loc_2);
            return;
        }// end function

        override public function getSmallMessage() : IMessage
        {
            var _loc_1:Object = this;
            if (_loc_1.constructor == AcknowledgeMessage)
            {
                return new AcknowledgeMessageExt(this);
            }
            return null;
        }// end function

    }
}
