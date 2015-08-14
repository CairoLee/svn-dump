package Communication.VO
{
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import mx.collections.*;

    public class dResourcesVO extends Object
    {
        public var resources_vector:ArrayCollection;
        public var workers:int;
        public var free:int;
        public var military:int;

        public function dResourcesVO()
        {
            this.resources_vector = new ArrayCollection();
            return;
        }// end function

        public function CreateResourcesFromVO(param1:cGeneralInterface, param2:int, param3:int) : cResources
        {
            var _loc_6:dResourceVO = null;
            var _loc_4:* = new cResources(param1, param2, param3);
            new cResources(param1, param2, param3).CreateResourceEntries();
            var _loc_5:* = new Vector.<dResourceVO>;
            for each (_loc_6 in this.resources_vector)
            {
                
                _loc_5.push(_loc_6);
            }
            _loc_4.Init(this.workers, this.military, this.free, _loc_5);
            return _loc_4;
        }// end function

    }
}
