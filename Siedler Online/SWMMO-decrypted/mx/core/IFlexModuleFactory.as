package mx.core
{
    import flash.utils.*;

    public interface IFlexModuleFactory
    {

        public function IFlexModuleFactory();

        function get preloadedRSLs() : Dictionary;

        function allowInsecureDomain(... args) : void;

        function create(... args) : Object;

        function allowDomain(... args) : void;

        function info() : Object;

    }
}
