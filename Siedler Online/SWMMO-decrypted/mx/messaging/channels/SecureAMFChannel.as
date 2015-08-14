package mx.messaging.channels
{

    public class SecureAMFChannel extends AMFChannel
    {

        public function SecureAMFChannel(param1:String = null, param2:String = null)
        {
            super(param1, param2);
            return;
        }// end function

        override public function get protocol() : String
        {
            return "https";
        }// end function

    }
}
