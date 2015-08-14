package org.igniterealtime.xiff.data
{

    public class ExtensionClassRegistry extends Object
    {
        private static var _classes:Array = [];

        public function ExtensionClassRegistry()
        {
            return;
        }// end function

        public static function lookup(param1:String) : Class
        {
            return _classes[param1];
        }// end function

        public static function register(param1:Class) : Boolean
        {
            var _loc_2:* = new param1;
            if (_loc_2 is IExtension)
            {
                _classes[_loc_2.getNS()] = param1;
                return true;
            }
            return false;
        }// end function

    }
}
