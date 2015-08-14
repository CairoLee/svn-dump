package mx.managers
{
    import mx.core.*;

    public class HistoryManager extends Object
    {
        private static var implClassDependency:HistoryManagerImpl;
        static const VERSION:String = "3.5.0.12683";
        private static var _impl:IHistoryManager;

        public function HistoryManager()
        {
            return;
        }// end function

        public static function save() : void
        {
            impl.save();
            return;
        }// end function

        private static function get impl() : IHistoryManager
        {
            if (!_impl)
            {
                _impl = IHistoryManager(Singleton.getInstance("mx.managers::IHistoryManager"));
            }
            return _impl;
        }// end function

        public static function register(param1:IHistoryManagerClient) : void
        {
            impl.register(param1);
            return;
        }// end function

        public static function unregister(param1:IHistoryManagerClient) : void
        {
            impl.unregister(param1);
            return;
        }// end function

        public static function initialize(param1:ISystemManager) : void
        {
            return;
        }// end function

    }
}
