package mx.managers
{
    import mx.core.*;

    public class BrowserManager extends Object
    {
        private static var implClassDependency:BrowserManagerImpl;
        private static var instance:IBrowserManager;
        static const VERSION:String = "3.5.0.12683";

        public function BrowserManager()
        {
            return;
        }// end function

        public static function getInstance() : IBrowserManager
        {
            if (!instance)
            {
                instance = IBrowserManager(Singleton.getInstance("mx.managers::IBrowserManager"));
            }
            return instance;
        }// end function

    }
}
