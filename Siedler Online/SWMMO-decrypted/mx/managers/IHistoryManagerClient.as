package mx.managers
{

    public interface IHistoryManagerClient
    {

        public function IHistoryManagerClient();

        function loadState(param1:Object) : void;

        function saveState() : Object;

        function toString() : String;

    }
}
