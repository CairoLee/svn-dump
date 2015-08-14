package mx.messaging.errors
{

    public class MessagingError extends Error
    {

        public function MessagingError(param1:String)
        {
            super(param1);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "[MessagingError";
            if (message != null)
            {
                _loc_1 = _loc_1 + (" message=\'" + message + "\']");
            }
            else
            {
                _loc_1 = _loc_1 + "]";
            }
            return _loc_1;
        }// end function

    }
}
