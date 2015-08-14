package ServerState
{
    import __AS3__.vec.*;

    public class dResourceCreationDefinition extends Object
    {
        public var typeEnumResourceType:int;
        public var workTime:int;
        public var amountRemoved:int;
        public var ignoreMaxWarehouseLimit:Boolean;
        public var necessaryResources_vector:Vector.<dResource>;
        public var defaultSetting:dResourceDefaultDefinition;
        public var buildingName_string:String;
        public var externalResource_string:String;
        public var id:int;

        public function dResourceCreationDefinition()
        {
            this.necessaryResources_vector = new Vector.<dResource>;
            return;
        }// end function

        public function toString() : String
        {
            return "<ResourceCreationDefinition building=\'" + this.buildingName_string + "\', externalResource=\'" + this.externalResource_string + "\' >";
        }// end function

    }
}
