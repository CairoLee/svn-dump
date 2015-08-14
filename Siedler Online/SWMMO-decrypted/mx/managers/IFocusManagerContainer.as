package mx.managers
{
    import flash.display.*;
    import flash.events.*;

    public interface IFocusManagerContainer extends IEventDispatcher
    {

        public function IFocusManagerContainer();

        function set focusManager(param1:IFocusManager) : void;

        function get focusManager() : IFocusManager;

        function get systemManager() : ISystemManager;

        function contains(param1:DisplayObject) : Boolean;

    }
}
