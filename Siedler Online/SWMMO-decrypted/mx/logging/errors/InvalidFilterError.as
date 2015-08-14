package mx.logging.errors
{

    public class InvalidFilterError extends Error
    {
        static const VERSION:String = "3.5.0.12683";

        public function InvalidFilterError(param1:String)
        {
            super(param1);
            return;
        }// end function

        public function toString() : String
        {
            return String(message);
        }// end function

    }
}
