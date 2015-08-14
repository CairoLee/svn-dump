package com.google.analytics.external
{
    import com.google.analytics.debug.*;

    public class AdSenseGlobals extends JavascriptProxy
    {
        private var _gaGlobalVerified:Boolean = false;
        public static var gaGlobal_js:XML = <script>
n            <![CDATA[
n                function()
n                {
n                    try
n                    {
n                        gaGlobal
n                    }
n                    catch(e)
n                    {
n                        gaGlobal = {} ;
n                    }
n                }
n            ]]>
n        </script>")("<script>
            <![CDATA[
                function()
                {
                    try
                    {
                        gaGlobal
                    }
                    catch(e)
                    {
                        gaGlobal = {} ;
                    }
                }
            ]]>
        </script>;

        public function AdSenseGlobals(param1:DebugConfiguration)
        {
            super(param1);
            return;
        }// end function

        public function set vid(param1:String) : void
        {
            if (!isAvailable())
            {
                return;
            }
            _verify();
            setProperty("gaGlobal.vid", param1);
            return;
        }// end function

        public function get hid() : String
        {
            if (!isAvailable())
            {
                return null;
            }
            _verify();
            return getProperty("gaGlobal.hid");
        }// end function

        public function set hid(param1:String) : void
        {
            if (!isAvailable())
            {
                return;
            }
            _verify();
            setProperty("gaGlobal.hid", param1);
            return;
        }// end function

        public function get dh() : String
        {
            if (!isAvailable())
            {
                return null;
            }
            _verify();
            return getProperty("gaGlobal.dh");
        }// end function

        public function get sid() : String
        {
            if (!isAvailable())
            {
                return null;
            }
            _verify();
            return getProperty("gaGlobal.sid");
        }// end function

        public function get vid() : String
        {
            if (!isAvailable())
            {
                return null;
            }
            _verify();
            return getProperty("gaGlobal.vid");
        }// end function

        private function _verify() : void
        {
            if (!_gaGlobalVerified)
            {
                executeBlock(gaGlobal_js);
                _gaGlobalVerified = true;
            }
            return;
        }// end function

        public function set sid(param1:String) : void
        {
            if (!isAvailable())
            {
                return;
            }
            _verify();
            setProperty("gaGlobal.sid", param1);
            return;
        }// end function

        public function get gaGlobal() : Object
        {
            if (!isAvailable())
            {
                return null;
            }
            _verify();
            return getProperty("gaGlobal");
        }// end function

    }
}
