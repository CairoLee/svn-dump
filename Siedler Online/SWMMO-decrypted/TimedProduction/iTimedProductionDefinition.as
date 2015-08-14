package TimedProduction
{

    public interface iTimedProductionDefinition
    {

        public function iTimedProductionDefinition();

        function GetType_string() : String;

        function GetCosts_vector();

        function IsProduceable() : Boolean;

        function GetProductionTime() : int;

        function GetPlayerLevel() : int;

    }
}
