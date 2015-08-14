package mx.messaging.messages
{
    import flash.utils.*;

    public class AsyncMessageExt extends AsyncMessage implements IExternalizable
    {
        private var _message:AsyncMessage;

        public function AsyncMessageExt(param1:AsyncMessage = null)
        {
            _message = param1;
            return;
        }// end function

        override public function get messageId() : String
        {
            if (_message != null)
            {
                return _message.messageId;
            }
            return super.messageId;
        }// end function

        override public function writeExternal(param1:IDataOutput) : void
        {
            if (_message != null)
            {
                _message.writeExternal(param1);
            }
            else
            {
                super.writeExternal(param1);
            }
            return;
        }// end function

    }
}
