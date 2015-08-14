package TimedProduction
{
    import Communication.VO.*;
    import Interface.*;
    import ServerState.*;
    import mx.collections.*;

    public interface iProductionOrder
    {

        public function iProductionOrder();

        function GetType_string() : String;

        function GetOnFinishedAvatarMessageType() : String;

        function GetInstantBuildCosts() : int;

        function AddUniqueIds(param1:ArrayCollection) : void;

        function GetCostsToBuy_vector();

        function getProductionType() : int;

        function GetProductionTime() : int;

        function GetAmount() : int;

        function CreateItem(param1:cPlayerData, param2:cGeneralInterface, param3:int) : void;

        function GetUniqueIds_vector();

        function GetNextUniqueId() : dUniqueID;

        function GetTimeBonus(param1:cGeneralInterface) : Number;

    }
}
