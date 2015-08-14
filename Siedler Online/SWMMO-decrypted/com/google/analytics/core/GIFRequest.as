package com.google.analytics.core
{
    import com.google.analytics.debug.*;
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;
    import flash.display.*;
    import flash.events.*;
    import flash.net.*;
    import flash.system.*;

    public class GIFRequest extends Object
    {
        private var _info:Environment;
        private var _count:int;
        private var _utmac:String;
        private var _alertcount:int;
        private var _debug:DebugConfiguration;
        private var _lastRequest:URLRequest;
        private var _buffer:Buffer;
        private var _config:Configuration;
        private var _requests:Array;

        public function GIFRequest(param1:Configuration, param2:DebugConfiguration, param3:Buffer, param4:Environment)
        {
            _config = param1;
            _debug = param2;
            _buffer = param3;
            _info = param4;
            _count = 0;
            _alertcount = 0;
            _requests = [];
            return;
        }// end function

        public function get utmn() : String
        {
            return Utils.generate32bitRandom() as String;
        }// end function

        public function onIOError(event:IOErrorEvent) : void
        {
            var _loc_2:* = _lastRequest.url;
            var _loc_3:* = String((_requests.length - 1));
            var _loc_4:* = "Gif Request #" + _loc_3 + " failed";
            if (_debug.GIFRequests)
            {
                if (!_debug.verbose)
                {
                    if (_loc_2.indexOf("?") > -1)
                    {
                        _loc_2 = _loc_2.split("?")[0];
                    }
                    _loc_2 = _shortenURL(_loc_2);
                }
                if (int(_debug.mode) > int(VisualDebugMode.basic))
                {
                    _loc_4 = _loc_4 + (" \"" + _loc_2 + "\" does not exists or is unreachable");
                }
                _debug.failure(_loc_4);
            }
            else
            {
                _debug.warning(_loc_4);
            }
            _removeListeners(event.target);
            return;
        }// end function

        public function send(param1:String, param2:Variables = null, param3:Boolean = false, param4:Boolean = false) : void
        {
            var _loc_5:String = null;
            var _loc_6:URLRequest = null;
            var _loc_7:URLRequest = null;
            _utmac = param1;
            if (!param2)
            {
                param2 = new Variables();
            }
            param2.URIencode = false;
            param2.pre = ["utmwv", "utmn", "utmhn", "utmt", "utme", "utmcs", "utmsr", "utmsc", "utmul", "utmje", "utmfl", "utmdt", "utmhid", "utmr", "utmp"];
            param2.post = ["utmcc"];
            if (_debug.verbose)
            {
                _debug.info("tracking: " + _buffer.utmb.trackCount + "/" + _config.trackingLimitPerSession, VisualDebugMode.geek);
            }
            if (_buffer.utmb.trackCount < _config.trackingLimitPerSession || param3)
            {
                if (param4)
                {
                    updateToken();
                }
                if (param3 || !param4 || _buffer.utmb.token >= 1)
                {
                    if (!param3 && param4)
                    {
                        (_buffer.utmb.token - 1);
                    }
                    (_buffer.utmb.trackCount + 1);
                    if (_debug.verbose)
                    {
                        _debug.info(_buffer.utmb.toString(), VisualDebugMode.geek);
                    }
                    param2.utmwv = utmwv;
                    param2.utmn = Utils.generate32bitRandom();
                    if (_info.domainName != "")
                    {
                        param2.utmhn = _info.domainName;
                    }
                    if (_config.sampleRate < 1)
                    {
                        param2.utmsp = _config.sampleRate * 100;
                    }
                    if (_config.serverMode == ServerOperationMode.local || _config.serverMode == ServerOperationMode.both)
                    {
                        _loc_5 = _info.locationSWFPath;
                        if (_loc_5.lastIndexOf("/") > 0)
                        {
                            _loc_5 = _loc_5.substring(0, _loc_5.lastIndexOf("/"));
                        }
                        _loc_6 = new URLRequest();
                        if (_config.localGIFpath.indexOf("http") == 0)
                        {
                            _loc_6.url = _config.localGIFpath;
                        }
                        else
                        {
                            _loc_6.url = _loc_5 + _config.localGIFpath;
                        }
                        _loc_6.url = _loc_6.url + ("?" + param2.toString());
                        if (_debug.active && _debug.GIFRequests)
                        {
                            _debugSend(_loc_6);
                        }
                        else
                        {
                            sendRequest(_loc_6);
                        }
                    }
                    if (_config.serverMode == ServerOperationMode.remote || _config.serverMode == ServerOperationMode.both)
                    {
                        _loc_7 = new URLRequest();
                        if (_info.protocol == Protocols.HTTPS)
                        {
                            _loc_7.url = _config.secureRemoteGIFpath;
                        }
                        else if (_info.protocol == Protocols.HTTP)
                        {
                            _loc_7.url = _config.remoteGIFpath;
                        }
                        else
                        {
                            _loc_7.url = _config.remoteGIFpath;
                        }
                        param2.utmac = utmac;
                        param2.utmcc = encodeURIComponent(utmcc);
                        _loc_7.url = _loc_7.url + ("?" + param2.toString());
                        if (_debug.active && _debug.GIFRequests)
                        {
                            _debugSend(_loc_7);
                        }
                        else
                        {
                            sendRequest(_loc_7);
                        }
                    }
                }
            }
            return;
        }// end function

        public function onSecurityError(event:SecurityErrorEvent) : void
        {
            if (_debug.GIFRequests)
            {
                _debug.failure(event.text);
            }
            return;
        }// end function

        public function get utmsp() : String
        {
            return _config.sampleRate * 100 as String;
        }// end function

        public function get utmcc() : String
        {
            var _loc_1:Array = [];
            if (_buffer.hasUTMA())
            {
                _loc_1.push(_buffer.utma.toURLString() + ";");
            }
            if (_buffer.hasUTMZ())
            {
                _loc_1.push(_buffer.utmz.toURLString() + ";");
            }
            if (_buffer.hasUTMV())
            {
                _loc_1.push(_buffer.utmv.toURLString() + ";");
            }
            return _loc_1.join("+");
        }// end function

        public function get utmac() : String
        {
            return _utmac;
        }// end function

        public function get utmwv() : String
        {
            return _config.version;
        }// end function

        public function sendRequest(param1:URLRequest) : void
        {
            var request:* = param1;
            var loader:* = new Loader();
            loader.name = String(_count++);
            var context:* = new LoaderContext(false);
            loader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onIOError);
            loader.contentLoaderInfo.addEventListener(Event.COMPLETE, onComplete);
            _lastRequest = request;
            _requests[loader.name] = new RequestObject(request);
            try
            {
                loader.load(request, context);
            }
            catch (e:Error)
            {
                _debug.failure("\"Loader.load()\" could not instanciate Gif Request");
            }
            return;
        }// end function

        private function _removeListeners(param1:Object) : void
        {
            param1.removeEventListener(IOErrorEvent.IO_ERROR, onIOError);
            param1.removeEventListener(Event.COMPLETE, onComplete);
            return;
        }// end function

        public function updateToken() : void
        {
            var _loc_2:Number = NaN;
            var _loc_1:* = new Date().getTime();
            _loc_2 = (_loc_1 - _buffer.utmb.lastTime) * (_config.tokenRate / 1000);
            if (_debug.verbose)
            {
                _debug.info("tokenDelta: " + _loc_2, VisualDebugMode.geek);
            }
            if (_loc_2 >= 1)
            {
                _buffer.utmb.token = Math.min(Math.floor(_buffer.utmb.token + _loc_2), _config.bucketCapacity);
                _buffer.utmb.lastTime = _loc_1;
                if (_debug.verbose)
                {
                    _debug.info(_buffer.utmb.toString(), VisualDebugMode.geek);
                }
            }
            return;
        }// end function

        public function get utmhn() : String
        {
            return _info.domainName;
        }// end function

        private function _shortenURL(param1:String) : String
        {
            var _loc_2:Array = null;
            if (param1.length > 60)
            {
                _loc_2 = param1.split("/");
                while (param1.length > 60)
                {
                    
                    _loc_2.shift();
                    param1 = "../" + _loc_2.join("/");
                }
            }
            return param1;
        }// end function

        private function _debugSend(param1:URLRequest) : void
        {
            var _loc_3:String = null;
            var _loc_2:String = "";
            switch(_debug.mode)
            {
                case VisualDebugMode.geek:
                {
                    _loc_2 = "Gif Request #" + _alertcount + ":\n" + param1.url;
                    break;
                }
                case VisualDebugMode.advanced:
                {
                    _loc_3 = param1.url;
                    if (_loc_3.indexOf("?") > -1)
                    {
                        _loc_3 = _loc_3.split("?")[0];
                    }
                    _loc_3 = _shortenURL(_loc_3);
                    _loc_2 = "Send Gif Request #" + _alertcount + ":\n" + _loc_3 + " ?";
                    break;
                }
                case VisualDebugMode.basic:
                {
                }
                default:
                {
                    _loc_2 = "Send " + _config.serverMode.toString() + " Gif Request #" + _alertcount + " ?";
                    break;
                }
            }
            _debug.alertGifRequest(_loc_2, param1, this);
            var _loc_5:* = _alertcount + 1;
            _alertcount = _loc_5;
            return;
        }// end function

        public function onComplete(event:Event) : void
        {
            var _loc_2:* = event.target.loader.name;
            _requests[_loc_2].complete();
            var _loc_3:* = "Gif Request #" + _loc_2 + " sent";
            var _loc_4:* = _requests[_loc_2].request.url;
            if (_debug.GIFRequests)
            {
                if (!_debug.verbose)
                {
                    if (_loc_4.indexOf("?") > -1)
                    {
                        _loc_4 = _loc_4.split("?")[0];
                    }
                    _loc_4 = _shortenURL(_loc_4);
                }
                if (int(_debug.mode) > int(VisualDebugMode.basic))
                {
                    _loc_3 = _loc_3 + (" to \"" + _loc_4 + "\"");
                }
                _debug.success(_loc_3);
            }
            else
            {
                _debug.info(_loc_3);
            }
            _removeListeners(event.target);
            return;
        }// end function

    }
}
