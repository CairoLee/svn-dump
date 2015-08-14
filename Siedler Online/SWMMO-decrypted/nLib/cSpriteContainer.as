package nLib
{
    import GUI.Assets.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.net.*;
    import flash.system.*;
    import mx.core.*;

    public class cSpriteContainer extends Object
    {
        public var mCurrentScaleFactor:Number = -1;
        private var mDispatcherLoadPNG:cCustomDispatcher;
        public var mOriginalGraphicsImage:DisplayObject = null;
        public var mScaledGraphics:BitmapData = null;
        public var mFilename_string:String = null;
        public var mLoadingFinished:Boolean = false;
        public var mExternalData:Object = null;
        private var mImageLoader:Loader = null;
        private var mRequest:URLRequest;
        public var mOriginalGraphicsImageBitmapData:BitmapData = null;
        public var mOriginalScaleFactor:Number = 1000;
        private var mRequestFailCounter:int = 0;

        public function cSpriteContainer(param1:String = null, param2:Function = null, param3:int = 1000) : void
        {
            this.mDispatcherLoadPNG = new cCustomDispatcher();
            if (param1 == null)
            {
                return;
            }
            if (param2 == null)
            {
                param2 = this.dummyFinished;
            }
            this.mOriginalScaleFactor = param3;
            this.LoadGfx(param1, param2);
            return;
        }// end function

        private function ioSecurityErrorHandler(event:Event) : void
        {
            var _loc_2:LoaderContext = null;
            var _loc_3:String = this;
            var _loc_4:* = this.mRequestFailCounter + 1;
            _loc_3.mRequestFailCounter = _loc_4;
            if (this.mRequestFailCounter < defines.STATIC_FILES_URL_LIST.length)
            {
                this.mRequest.url = this.mRequest.url.replace(defines.STATIC_FILES_URL_LIST[(this.mRequestFailCounter - 1)], defines.STATIC_FILES_URL_LIST[this.mRequestFailCounter]);
                _loc_2 = new LoaderContext(true);
                _loc_2.checkPolicyFile = true;
                this.mImageLoader.load(this.mRequest, _loc_2);
            }
            else
            {
                gErrorMessages.ShowIOErrorMessage(this.mRequest.url);
            }
            return;
        }// end function

        public function LoadGfx(param1:String, param2:Function) : void
        {
            var lc:LoaderContext;
            var _fileName_string:* = param1;
            var _completeFunction:* = param2;
            gAssetManager.CheckGraphicsFileNameExtension(_fileName_string);
            this.mLoadingFinished = false;
            this.mDispatcherLoadPNG.addEventListener(cCustomDispatcher.mAction_string, _completeFunction);
            this.mImageLoader = new Loader();
            this.mImageLoader.contentLoaderInfo.addEventListener(Event.COMPLETE, this.CompleteHandlerLoadPNG);
            this.mFilename_string = _fileName_string;
            this.mImageLoader.contentLoaderInfo.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.ioSecurityErrorHandler);
            this.mImageLoader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, this.ioSecurityErrorHandler);
            try
            {
                lc = new LoaderContext(true);
                lc.checkPolicyFile = true;
                this.mRequest = new URLRequest(_fileName_string);
                this.mImageLoader.load(this.mRequest, lc);
            }
            catch (error:Error)
            {
                gErrorMessages.ShowIOErrorMessage(mRequest.url);
            }
            return;
        }// end function

        public function Rescale() : void
        {
            if (Math.floor(this.mCurrentScaleFactor) == Math.floor(global.ui.mZoom.GetScaleFactor()))
            {
                return;
            }
            var _loc_1:* = this.mOriginalGraphicsImage.width;
            var _loc_2:* = this.mOriginalGraphicsImage.height;
            _loc_1 = global.ui.mZoom.InvScale(_loc_1, this.mOriginalScaleFactor);
            _loc_2 = global.ui.mZoom.InvScale(_loc_2, this.mOriginalScaleFactor);
            gMisc.Assert(_loc_1 * _loc_2 < 2048 * 2048, "Bitmap to large!\nFile: " + this.mFilename_string);
            var _loc_3:* = global.ui.mZoom.CalculateZoomMatrix(this.mOriginalScaleFactor);
            gMisc.Assert(false, "optimize before use");
            this.mCurrentScaleFactor = global.ui.mZoom.GetScaleFactor();
            return;
        }// end function

        private function CompleteHandlerLoadPNG(event:Event) : void
        {
            Application.application.mMemoryMonitor.RegisterLoadedGraphic(this.mImageLoader.contentLoaderInfo.bytesTotal);
            this.mOriginalGraphicsImage = this.mImageLoader.content;
            this.mOriginalGraphicsImageBitmapData = Bitmap(this.mImageLoader.content).bitmapData;
            this.mImageLoader = null;
            this.mLoadingFinished = true;
            this.mDispatcherLoadPNG.doAction();
            return;
        }// end function

        private function dummyFinished(event:Event) : void
        {
            return;
        }// end function

        public function Clone() : Object
        {
            var _loc_1:* = new cSprite();
            _loc_1.SetContainer(this);
            return _loc_1;
        }// end function

    }
}
