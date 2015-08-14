package ServerState
{
    import __AS3__.vec.*;

    public class dResourceDefaultDefinition extends Object
    {
        public var group_string:String;
        public var expandMaxLimitList_vector:Vector.<dExpandMaxLimit>;
        public var maxLimit:int;
        public var resourceName_string:String;

        public function dResourceDefaultDefinition()
        {
            this.expandMaxLimitList_vector = new Vector.<dExpandMaxLimit>;
            return;
        }// end function

    }
}
