package mx.logging.errors
{

    public class InvalidCategoryError extends Error
    {
        static const VERSION:String = "3.5.0.12683";

        public function InvalidCategoryError(param1:String)
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
