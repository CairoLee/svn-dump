package Communication.VO.UpdateVO
{
    import mx.collections.*;

    public class dExploredSectorDataVO extends Object
    {
        public var resourceCreations:ArrayCollection;
        public var deposits:ArrayCollection;
        public var streets:ArrayCollection;
        public var landscapes:ArrayCollection;
        public var buildings:ArrayCollection;

        public function dExploredSectorDataVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<ExploredSectordataVO\n";
            _loc_1 = _loc_1 + ("   Buldings: " + this.buildings + "\n");
            _loc_1 = _loc_1 + ("   Landscapes: " + this.landscapes + "\n");
            _loc_1 = _loc_1 + ("   Deposits: " + this.deposits + "\n");
            _loc_1 = _loc_1 + ("   Streets: " + this.streets + "\n");
            _loc_1 = _loc_1 + ("   ResourceCreations: " + this.resourceCreations + "\n");
            return _loc_1;
        }// end function

    }
}
