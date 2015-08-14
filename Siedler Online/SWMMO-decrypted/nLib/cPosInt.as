package nLib
{

    public class cPosInt extends Object
    {
        public var x:int;
        public var y:int;

        public function cPosInt(param1:int = 0, param2:int = 0)
        {
            this.x = param1;
            this.y = param2;
            return;
        }// end function

        public function Set(param1:cPosInt) : void
        {
            this.x = param1.x;
            this.y = param1.y;
            return;
        }// end function

        public function toString() : String
        {
            return this.x + "/" + this.y;
        }// end function

    }
}
