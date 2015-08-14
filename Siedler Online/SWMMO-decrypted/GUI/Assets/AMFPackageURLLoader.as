package GUI.Assets
{
    import VO.*;
    import flash.events.*;
    import flash.net.*;

    final public class AMFPackageURLLoader extends URLLoader
    {
        public var urlRequest:URLRequest;
        public var targetDict:String = "";

        public function AMFPackageURLLoader()
        {
            this.dataFormat = URLLoaderDataFormat.BINARY;
            registerClassAlias("vo.BinVO", BinVO);
            this.urlRequest = new URLRequest();
            this.urlRequest.method = URLRequestMethod.GET;
            this.urlRequest.contentType = "application/octet-stream";
            this.urlRequest.requestHeaders.push(new URLRequestHeader("Cache-Control", "min-fresh=1310400"), new URLRequestHeader("Cache-Control", "max-stale"));
            return;
        }// end function

        public function loadAMFPackage(param1:String, param2:Function, param3:String = null) : void
        {
            this.targetDict = param3;
            this.urlRequest.url = param1;
            this.addEventListener(Event.COMPLETE, param2);
            this.load(this.urlRequest);
            return;
        }// end function

    }
}
