package com.google.analytics.core
{
    import com.google.analytics.debug.*;

    public class Domain extends Object
    {
        private var _mode:DomainNameMode;
        private var _debug:DebugConfiguration;
        private var _name:String;

        public function Domain(param1:DomainNameMode = null, param2:String = "", param3:DebugConfiguration = null)
        {
            _debug = param3;
            if (param1 == null)
            {
                param1 = DomainNameMode.auto;
            }
            _mode = param1;
            if (param1 == DomainNameMode.custom)
            {
                this.name = param2;
            }
            else
            {
                _name = param2;
            }
            return;
        }// end function

        public function get mode() : DomainNameMode
        {
            return _mode;
        }// end function

        public function set mode(param1:DomainNameMode) : void
        {
            _mode = param1;
            if (_mode == DomainNameMode.none)
            {
                _name = "";
            }
            return;
        }// end function

        public function get name() : String
        {
            return _name;
        }// end function

        public function set name(param1:String) : void
        {
            if (param1.charAt(0) != "." && _debug)
            {
                _debug.warning("missing leading period \".\", cookie will only be accessible on " + param1, VisualDebugMode.geek);
            }
            _name = param1;
            return;
        }// end function

    }
}
