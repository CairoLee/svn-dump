package mx.messaging.config
{

    public class LoaderConfig extends Object
    {
        static var _parameters:Object;
        static var _swfVersion:uint;
        static var _url:String = null;
        static const VERSION:String = "3.5.0.12683";

        public function LoaderConfig()
        {
            return;
        }// end function

        public static function get parameters() : Object
        {
            return _parameters;
        }// end function

        public static function get url() : String
        {
            return _url;
        }// end function

        public static function get swfVersion() : uint
        {
            return _swfVersion;
        }// end function

    }
}
