package mx.logging
{
    import flash.events.*;

    public interface ILogger extends IEventDispatcher
    {

        public function ILogger();

        function debug(param1:String, ... args) : void;

        function fatal(param1:String, ... args) : void;

        function get category() : String;

        function warn(param1:String, ... args) : void;

        function error(param1:String, ... args) : void;

        function log(param1:int, param2:String, ... args) : void;

        function info(param1:String, ... args) : void;

    }
}
