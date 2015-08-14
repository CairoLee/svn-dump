package mx.formatters
{
    import flash.events.*;
    import mx.resources.*;

    public class Formatter extends Object
    {
        private var _resourceManager:IResourceManager;
        public var error:String;
        private static var defaultInvalidFormatErrorOverride:String;
        private static var _defaultInvalidValueError:String;
        private static var _static_resourceManager:IResourceManager;
        private static var initialized:Boolean = false;
        private static var defaultInvalidValueErrorOverride:String;
        private static var _defaultInvalidFormatError:String;
        static const VERSION:String = "3.5.0.12683";

        public function Formatter()
        {
            _resourceManager = ResourceManager.getInstance();
            resourceManager.addEventListener(Event.CHANGE, resourceManager_changeHandler, false, 0, true);
            resourcesChanged();
            return;
        }// end function

        protected function resourcesChanged() : void
        {
            return;
        }// end function

        private function resourceManager_changeHandler(event:Event) : void
        {
            resourcesChanged();
            return;
        }// end function

        public function format(param1:Object) : String
        {
            error = "This format function is abstract. " + "Subclasses must override it.";
            return "";
        }// end function

        protected function get resourceManager() : IResourceManager
        {
            return _resourceManager;
        }// end function

        private static function static_resourcesChanged() : void
        {
            defaultInvalidFormatError = defaultInvalidFormatErrorOverride;
            defaultInvalidValueError = defaultInvalidValueErrorOverride;
            return;
        }// end function

        public static function set defaultInvalidValueError(param1:String) : void
        {
            defaultInvalidValueErrorOverride = param1;
            _defaultInvalidValueError = param1 != null ? (param1) : (static_resourceManager.getString("formatters", "defaultInvalidValueError"));
            return;
        }// end function

        private static function static_resourceManager_changeHandler(event:Event) : void
        {
            static_resourcesChanged();
            return;
        }// end function

        public static function get defaultInvalidValueError() : String
        {
            initialize();
            return _defaultInvalidValueError;
        }// end function

        private static function get static_resourceManager() : IResourceManager
        {
            if (!_static_resourceManager)
            {
                _static_resourceManager = ResourceManager.getInstance();
            }
            return _static_resourceManager;
        }// end function

        public static function set defaultInvalidFormatError(param1:String) : void
        {
            defaultInvalidFormatErrorOverride = param1;
            _defaultInvalidFormatError = param1 != null ? (param1) : (static_resourceManager.getString("formatters", "defaultInvalidFormatError"));
            return;
        }// end function

        private static function initialize() : void
        {
            if (!initialized)
            {
                static_resourceManager.addEventListener(Event.CHANGE, static_resourceManager_changeHandler, false, 0, true);
                static_resourcesChanged();
                initialized = true;
            }
            return;
        }// end function

        public static function get defaultInvalidFormatError() : String
        {
            initialize();
            return _defaultInvalidFormatError;
        }// end function

    }
}
