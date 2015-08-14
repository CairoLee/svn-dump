package com.google.analytics.external
{
    import com.google.analytics.debug.*;
    import flash.external.*;
    import flash.system.*;

    public class JavascriptProxy extends Object
    {
        private var _notAvailableWarning:Boolean = true;
        private var _debug:DebugConfiguration;
        public static var setProperty_js:XML = <script>
n                <![CDATA[
n                    function( path , value )
n                    {
n                        var paths;
n                        var prop;
n                        if( path.indexOf(""."") > 0 )
n                        {
n                            paths = path.split(""."");
n                            prop  = paths.pop() ;
n                        }
n                        else
n                        {
n                            paths = [];
n                            prop  = path;
n                        }
n                        var target = window ;
n                        var len    = paths.length ;
n                        for( var i = 0 ; i < len ; i++ )
n                        {
n                            target = target[ paths[i] ] ;
n                        }
n                        
n                        target[ prop ] = value ;
n                    }
n                ]]>
n            </script>")("<script>
                <![CDATA[
                    function( path , value )
                    {
                        var paths;
                        var prop;
                        if( path.indexOf(".") > 0 )
                        {
                            paths = path.split(".");
                            prop  = paths.pop() ;
                        }
                        else
                        {
                            paths = [];
                            prop  = path;
                        }
                        var target = window ;
                        var len    = paths.length ;
                        for( var i = 0 ; i < len ; i++ )
                        {
                            target = target[ paths[i] ] ;
                        }
                        
                        target[ prop ] = value ;
                    }
                ]]>
            </script>;
        public static var hasProperty_js:XML = <script>
n                <![CDATA[
n                    function( path )
n                    {
n                        var paths;
n                        if( path.indexOf(""."") > 0 )
n                        {
n                            paths = path.split(""."");
n                        }
n                        else
n                        {
n                            paths = [path];
n                        }
n                        var target = window ;
n                        var len    = paths.length ;
n                        for( var i = 0 ; i < len ; i++ )
n                        {
n                            target = target[ paths[i] ] ;
n                        }
n                        if( target )
n                        {
n                            return true;
n                        }
n                        else
n                        {
n                            return false;
n                        }
n                    }
n                ]]>
n            </script>")("<script>
                <![CDATA[
                    function( path )
                    {
                        var paths;
                        if( path.indexOf(".") > 0 )
                        {
                            paths = path.split(".");
                        }
                        else
                        {
                            paths = [path];
                        }
                        var target = window ;
                        var len    = paths.length ;
                        for( var i = 0 ; i < len ; i++ )
                        {
                            target = target[ paths[i] ] ;
                        }
                        if( target )
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                ]]>
            </script>;
        public static var setPropertyRef_js:XML = <script>
n                <![CDATA[
n                    function( path , target )
n                    {
n                        var paths;
n                        var prop;
n                        if( path.indexOf(""."") > 0 )
n                        {
n                            paths = path.split(""."");
n                            prop  = paths.pop() ;
n                        }
n                        else
n                        {
n                            paths = [];
n                            prop  = path;
n                        }
n                        alert( ""paths:""+paths.length+"", prop:""+prop );
n                        var targets;
n                        var name;
n                        if( target.indexOf(""."") > 0 )
n                        {
n                            targets = target.split(""."");
n                            name    = targets.pop();
n                        }
n                        else
n                        {
n                            targets = [];
n                            name    = target;
n                        }
n                        alert( ""targets:""+targets.length+"", name:""+name );
n                        var root = window;
n                        var len  = paths.length;
n                        for( var i = 0 ; i < len ; i++ )
n                        {
n                            root = root[ paths[i] ] ;
n                        }
n                        var ref   = window;
n                        var depth = targets.length;
n                        for( var j = 0 ; j < depth ; j++ )
n                        {
n                            ref = ref[ targets[j] ] ;
n                        }
n                        root[ prop ] = ref[name] ;
n                    }
n                ]]>
n            </script>")("<script>
                <![CDATA[
                    function( path , target )
                    {
                        var paths;
                        var prop;
                        if( path.indexOf(".") > 0 )
                        {
                            paths = path.split(".");
                            prop  = paths.pop() ;
                        }
                        else
                        {
                            paths = [];
                            prop  = path;
                        }
                        alert( "paths:"+paths.length+", prop:"+prop );
                        var targets;
                        var name;
                        if( target.indexOf(".") > 0 )
                        {
                            targets = target.split(".");
                            name    = targets.pop();
                        }
                        else
                        {
                            targets = [];
                            name    = target;
                        }
                        alert( "targets:"+targets.length+", name:"+name );
                        var root = window;
                        var len  = paths.length;
                        for( var i = 0 ; i < len ; i++ )
                        {
                            root = root[ paths[i] ] ;
                        }
                        var ref   = window;
                        var depth = targets.length;
                        for( var j = 0 ; j < depth ; j++ )
                        {
                            ref = ref[ targets[j] ] ;
                        }
                        root[ prop ] = ref[name] ;
                    }
                ]]>
            </script>;

        public function JavascriptProxy(param1:DebugConfiguration)
        {
            _debug = param1;
            return;
        }// end function

        public function getProperty(param1:String)
        {
            return call(param1 + ".valueOf");
        }// end function

        public function hasProperty(param1:String) : Boolean
        {
            return call(hasProperty_js, param1);
        }// end function

        public function setProperty(param1:String, param2) : void
        {
            call(setProperty_js, param1, param2);
            return;
        }// end function

        public function executeBlock(param1:String) : void
        {
            var data:* = param1;
            if (isAvailable())
            {
                try
                {
                    ExternalInterface.call(data);
                }
                catch (e:SecurityError)
                {
                    if (_debug.javascript)
                    {
                        _debug.warning("ExternalInterface is not allowed.\nEnsure that allowScriptAccess is set to \"always\" in the Flash embed HTML.");
                    }
                    ;
                }
                catch (e:Error)
                {
                    if (_debug.javascript)
                    {
                        _debug.warning("ExternalInterface failed to make the call\nreason: " + e.message);
                    }
                }
            }
            return;
        }// end function

        public function getPropertyString(param1:String) : String
        {
            return call(param1 + ".toString");
        }// end function

        public function setPropertyByReference(param1:String, param2:String) : void
        {
            call(setPropertyRef_js, param1, param2);
            return;
        }// end function

        public function call(param1:String, ... args)
        {
            args = new activation;
            var output:String;
            var functionName:* = param1;
            var args:* = args;
            if (isAvailable())
            {
                try
                {
                    if (_debug.javascript && _debug.verbose)
                    {
                        output;
                        output = "Flash->JS: " + ;
                        output =  + "( ";
                        if (length > 0)
                        {
                            output =  + join(",");
                        }
                        output =  + " )";
                        _debug.info();
                    }
                    unshift();
                    return ExternalInterface.call.apply(ExternalInterface, );
                }
                catch (e:SecurityError)
                {
                    if (_debug.javascript)
                    {
                        _debug.warning("ExternalInterface is not allowed.\nEnsure that allowScriptAccess is set to \"always\" in the Flash embed HTML.");
                    }
                    ;
                }
                catch (e:Error)
                {
                    if (_debug.javascript)
                    {
                        _debug.warning("ExternalInterface failed to make the call\nreason: " + e.message);
                    }
                }
            }
            return null;
        }// end function

        public function isAvailable() : Boolean
        {
            var _loc_1:* = ExternalInterface.available;
            if (_loc_1 && Capabilities.playerType == "External")
            {
                _loc_1 = false;
            }
            if (!_loc_1 && _debug.javascript && _notAvailableWarning)
            {
                _debug.warning("ExternalInterface is not available.");
                _notAvailableWarning = false;
            }
            return _loc_1;
        }// end function

    }
}
