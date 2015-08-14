package nLib
{
    import GUI.Assets.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.core.*;
    import nLib.SpriteLibDataClass.*;

    public class cSpriteLibContainer extends Object
    {
        public var mStreamingFinished:Boolean = false;
        private var mSpriteContainer:cSpriteContainer;
        private var mUsedCntr:int = 0;
        public var mSubtypeCalculated_vector:Vector.<dSubtypeCalculated>;
        public var mSpriteLib:dMain;
        public var mDeltaCompression:Boolean = true;
        public var mStreamFrame:int = -1;
        public var mLoadingFinished:Boolean = false;
        public var mExternalData:Object = null;
        public var mLoadingFinishedLib:Boolean = false;
        public var mNofStreamUpgrades:int = 0;
        private var mDispatcherLoadLib:cCustomDispatcher;
        private var mRequestFailCounter:int = 0;
        public var mStreamingInProgress:Boolean = false;
        public var mStream:Boolean = true;
        public var mLoadedSpriteLib:dMain;
        public var mOriginalGraphicsImage:DisplayObject = null;
        public var mSubtypeCalculatedNof:int;
        private var mDispatcherLoadAll:cCustomDispatcher;
        private var mRequest:URLRequest;
        public var mId:int = -1;
        public var mOriginalGraphicsImageBitmapData:BitmapData = null;
        public var mStreamSubtype:int = -1;
        public var mStreamSubtypeAndFrameState:int = 0;
        public var mAnimationSpeed:Number = 1;
        public var mRefreshAfterStream:Boolean;
        public var mOriginalScaleFactor:Number = 1000;
        public var mFileName_string:String;
        private static var mSwitchToAntialiasingCntr:int = 0;
        private static var mTempPoint2:Point = new Point();
        private static var mTempRect:Rectangle = new Rectangle();
        private static var mTempRect2:Rectangle = new Rectangle();
        private static var mTempPoint:Point = new Point();
        public static var mActivateAntialiasing:Boolean = false;
        public static var mApplyFilter:Boolean = false;
        private static var mNullPoint:Point = new Point(0, 0);

        public function cSpriteLibContainer(param1:String, param2:Function, param3:int, param4:Boolean, param5:Boolean, param6:int)
        {
            this.mSpriteLib = new dMain();
            this.mSubtypeCalculated_vector = new Vector.<dSubtypeCalculated>;
            this.mDispatcherLoadLib = new cCustomDispatcher();
            this.mDispatcherLoadAll = new cCustomDispatcher();
            Application.application.mMemoryMonitor.RegisterSpriteLibContainer(this);
            this.mStreamingInProgress = false;
            if (param1 == null)
            {
                return;
            }
            if (param2 == null)
            {
                param2 = this.dummyFinished;
            }
            this.mOriginalScaleFactor = param3;
            this.mStream = param5;
            this.mStreamingFinished = false;
            this.mNofStreamUpgrades = param6;
            if (param5)
            {
                this.mDeltaCompression = param4;
                this.SetToStreamDummyGfxReplacement();
                this.mFileName_string = param1;
                this.mLoadingFinished = false;
                this.mDispatcherLoadAll = new cCustomDispatcher();
                this.mDispatcherLoadAll.addEventListener(cCustomDispatcher.mAction_string, param2);
            }
            else
            {
                this.mStreamSubtypeAndFrameState = 1;
                this.mStreamSubtype = 0;
                this.mStreamFrame = 0;
                this.LoadAll(param1, param2, param4);
            }
            return;
        }// end function

        public function CreateObject() : Object
        {
            var _loc_1:* = new cSpriteLib();
            _loc_1.SetContainer(this);
            return _loc_1;
        }// end function

        public function GetSpritePackIDByNameNr(param1:String) : int
        {
            var _loc_2:* = param1.toLowerCase();
            var _loc_3:int = 0;
            while (_loc_3 < this.mSpriteLib.spriteIndices_vector.length)
            {
                
                if (this.mSpriteLib.spriteIndices_vector[_loc_3].name_string == _loc_2)
                {
                    return _loc_3;
                }
                _loc_3++;
            }
            return -1;
        }// end function

        public function IsStreamingActiveIfNotActivate(param1:int, param2:int) : Boolean
        {
            var _loc_3:String = this;
            var _loc_4:* = this.mUsedCntr + 1;
            _loc_3.mUsedCntr = _loc_4;
            if (this.mNofStreamUpgrades != 0)
            {
                if (this.mStreamSubtypeAndFrameState == 0)
                {
                    this.mStreamSubtypeAndFrameState = 1;
                    this.mStreamSubtype = param1;
                    this.mStreamFrame = param2;
                    this.mStreamingInProgress = false;
                    return true;
                }
                if (this.mStreamSubtypeAndFrameState != 4)
                {
                    return true;
                }
                if (this.mStreamSubtypeAndFrameState == 4)
                {
                    if (param1 >= this.mSubtypeCalculatedNof)
                    {
                        this.mStreamSubtypeAndFrameState = 1;
                        this.mStreamSubtype = param1;
                        this.mStreamFrame = param2;
                        this.mStreamingInProgress = false;
                        this.mStream = true;
                        this.mStreamingFinished = false;
                        return true;
                    }
                    if (param2 >= this.mSubtypeCalculated_vector[param1].numFrames)
                    {
                        this.mStreamSubtypeAndFrameState = 1;
                        this.mStreamSubtype = param1;
                        this.mStreamFrame = param2;
                        this.mStreamingInProgress = false;
                        this.mStream = true;
                        this.mStreamingFinished = false;
                        return true;
                    }
                    if (this.mSubtypeCalculated_vector[param1].frameList_vector[param2].orginalBitmap == null)
                    {
                        this.mStreamSubtypeAndFrameState = 1;
                        this.mStreamSubtype = param1;
                        this.mStreamFrame = param2;
                        this.mStreamingInProgress = false;
                        this.mStream = true;
                        this.mStreamingFinished = false;
                        return true;
                    }
                }
            }
            if (this.mStream)
            {
                return true;
            }
            return false;
        }// end function

        private function LoadLib(param1:String, param2:Function) : void
        {
            var variables:URLLoader;
            var _fileName_string:* = param1;
            var _completeFunction:* = param2;
            this.mLoadingFinishedLib = false;
            this.mDispatcherLoadLib = new cCustomDispatcher();
            this.mDispatcherLoadLib.addEventListener(cCustomDispatcher.mAction_string, _completeFunction);
            var fileName:* = _fileName_string + ".bin";
            if (this.mNofStreamUpgrades != 0)
            {
                fileName = this.CheckForSplitLibStreaming(fileName, 1);
            }
            if (!this.LoadBinLib(fileName))
            {
                this.mRequest = new URLRequest(fileName);
                variables = new URLLoader();
                variables.dataFormat = URLLoaderDataFormat.BINARY;
                variables.addEventListener(Event.COMPLETE, this.CompleteHandlerLoadLib);
                variables.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.ioSecurityErrorHandler);
                variables.addEventListener(IOErrorEvent.IO_ERROR, this.ioSecurityErrorHandler);
                try
                {
                    variables.load(this.mRequest);
                }
                catch (error:Error)
                {
                    gErrorMessages.ShowIOErrorMessage(mRequest.url);
                }
            }
            return;
        }// end function

        public function ActivateDispatcherEvent() : void
        {
            if (this.mStream)
            {
                this.mLoadingFinished = true;
                this.mDispatcherLoadAll.doActionWithData(this.mFileName_string, this);
            }
            return;
        }// end function

        public function SetDirty() : void
        {
            var _loc_1:dSubtypeCalculated = null;
            var _loc_2:dFrameCalculated = null;
            for each (_loc_1 in this.mSubtypeCalculated_vector)
            {
                
                for each (_loc_2 in _loc_1.frameList_vector)
                {
                    
                    _loc_2.scaled = false;
                    _loc_2.antialiased = false;
                }
            }
            return;
        }// end function

        public function PrepareScaling(param1:Boolean) : void
        {
            var _loc_5:dSubtypeCalculated = null;
            var _loc_6:int = 0;
            var _loc_7:BitmapData = null;
            var _loc_8:int = 0;
            var _loc_9:dFrameCalculated = null;
            var _loc_10:Rectangle = null;
            var _loc_11:Point = null;
            var _loc_12:BitmapData = null;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:uint = 0;
            mTempRect2.x = 0;
            mTempRect2.y = 0;
            var _loc_2:* = this.mSpriteLib.spriteIndices_vector[0];
            var _loc_3:* = _loc_2.subtypeCalculated_vector.length;
            this.mSubtypeCalculated_vector = _loc_2.subtypeCalculated_vector;
            this.mSubtypeCalculatedNof = this.mSubtypeCalculated_vector.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_5 = _loc_2.subtypeCalculated_vector[_loc_4];
                _loc_6 = _loc_5.frameList_vector.length;
                _loc_7 = null;
                _loc_8 = 0;
                while (_loc_8 < _loc_6)
                {
                    
                    _loc_9 = _loc_5.frameList_vector[_loc_8];
                    _loc_10 = _loc_9.calculateRect;
                    if (_loc_10 == null)
                    {
                    }
                    else if (_loc_9.orginalBitmap != null)
                    {
                    }
                    else
                    {
                        _loc_11 = _loc_9.calculatePoint;
                        _loc_12 = new BitmapData(_loc_10.width + _loc_11.x, _loc_10.height + _loc_11.y, true, 0);
                        if (_loc_7 != null && param1)
                        {
                            mTempRect2.x = 0;
                            mTempRect2.y = 0;
                            mTempRect2.width = _loc_7.width;
                            mTempRect2.height = _loc_7.height;
                            mTempPoint2.x = 0;
                            mTempPoint2.y = 0;
                            _loc_12.copyPixels(_loc_7, mTempRect2, mTempPoint2, null, null, false);
                            _loc_16 = _loc_11.y;
                            _loc_14 = _loc_10.y;
                            while (_loc_14 < _loc_10.y + _loc_10.height)
                            {
                                
                                _loc_15 = _loc_11.x;
                                _loc_13 = _loc_10.x;
                                while (_loc_13 < _loc_10.x + _loc_10.width)
                                {
                                    
                                    _loc_17 = this.mOriginalGraphicsImageBitmapData.getPixel32(_loc_13, _loc_14);
                                    if (_loc_17 != 4294902015)
                                    {
                                        _loc_12.setPixel32(_loc_15, _loc_16, _loc_17);
                                    }
                                    _loc_15++;
                                    _loc_13++;
                                }
                                _loc_16++;
                                _loc_14++;
                            }
                        }
                        else
                        {
                            _loc_12.copyPixels(this.mOriginalGraphicsImageBitmapData, _loc_10, _loc_11, null, null, false);
                        }
                        _loc_9.orginalBitmap = _loc_12;
                        _loc_7 = _loc_12;
                        _loc_9.scaledBitmap = new BitmapData(_loc_9.size_u, _loc_9.size_v, true, 0);
                        _loc_9.scaledBitmapRectangle = new Rectangle(0, 0, _loc_9.size_u, _loc_9.size_v);
                    }
                    _loc_8++;
                }
                _loc_4++;
            }
            return;
        }// end function

        private function dummyFinished(event:Event) : void
        {
            return;
        }// end function

        public function LoadAll(param1:String, param2:Function, param3:Boolean) : void
        {
            this.mDeltaCompression = param3;
            this.mLoadingFinished = false;
            this.mDispatcherLoadAll = new cCustomDispatcher();
            this.mDispatcherLoadAll.addEventListener(cCustomDispatcher.mAction_string, param2);
            this.mFileName_string = param1;
            var _loc_4:* = gMisc.GetFileNameWithoutExtensionString(this.mFileName_string);
            this.LoadLib(_loc_4, this.CompleteHandlerLoadAllLib);
            return;
        }// end function

        public function SetToStreamDummyGfxReplacement() : void
        {
            var _loc_1:* = gGfxResource.mStreamReplacementSpriteContainer;
            this.mSubtypeCalculated_vector = _loc_1.mSubtypeCalculated_vector;
            this.mSubtypeCalculatedNof = this.mSubtypeCalculated_vector.length;
            this.mSpriteContainer = _loc_1.mSpriteContainer;
            return;
        }// end function

        private function CompleteHandlerLoadAllLib(event:Event) : void
        {
            this.mSpriteContainer = new cSpriteContainer();
            var _loc_2:* = this.mFileName_string + "";
            if (this.mNofStreamUpgrades != 0)
            {
                _loc_2 = this.CheckForSplitLibStreaming(_loc_2, 2);
            }
            this.mSpriteContainer.LoadGfx(_loc_2, this.CompleteHandlerLoadAll);
            return;
        }// end function

        private function ioSecurityErrorHandler(event:Event) : void
        {
            var _loc_2:URLLoader = null;
            var _loc_3:String = this;
            var _loc_4:* = this.mRequestFailCounter + 1;
            _loc_3.mRequestFailCounter = _loc_4;
            if (this.mRequestFailCounter < defines.STATIC_FILES_URL_LIST.length)
            {
                this.mRequest.url = this.mRequest.url.replace(defines.STATIC_FILES_URL_LIST[(this.mRequestFailCounter - 1)], defines.STATIC_FILES_URL_LIST[this.mRequestFailCounter]);
                _loc_2 = event.target as URLLoader;
                _loc_2.load(this.mRequest);
            }
            else
            {
                gErrorMessages.ShowIOErrorMessage(this.mRequest.url);
            }
            return;
        }// end function

        public function GetSpritePackIDByName(param1:String) : dIndices
        {
            var _loc_3:dIndices = null;
            var _loc_2:* = param1.toLowerCase();
            for each (_loc_3 in this.mSpriteLib.spriteIndices_vector)
            {
                
                if (_loc_3.name_string == _loc_2)
                {
                    return _loc_3;
                }
            }
            return null;
        }// end function

        private function CompleteHandlerLoadLib(event:Event) : void
        {
            var _loc_3:dMain = null;
            var _loc_4:dIndices = null;
            var _loc_2:* = URLLoader(event.target);
            Application.application.mMemoryMonitor.RegisterLoadedBin(_loc_2.bytesTotal);
            if (this.mNofStreamUpgrades != 0)
            {
                _loc_3 = this.LoadSpriteLibFromBinaryData(_loc_2.data);
                if (this.mLoadedSpriteLib == null)
                {
                    this.mLoadedSpriteLib = new dMain();
                    _loc_4 = new dIndices();
                    this.mLoadedSpriteLib.spriteIndices_vector.push(_loc_4);
                }
                if (this.mStreamSubtypeAndFrameState == 2)
                {
                    this.InsertSubTypeAndFrame(_loc_3, this.mStreamSubtype, this.mStreamFrame);
                }
            }
            else
            {
                this.mLoadedSpriteLib = this.LoadSpriteLibFromBinaryData(_loc_2.data);
            }
            this.mLoadingFinishedLib = true;
            this.mDispatcherLoadLib.doAction();
            return;
        }// end function

        public function Rescale(param1:int, param2:int) : void
        {
            var _loc_5:Matrix = null;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_3:* = this.mSubtypeCalculated_vector[param1];
            var _loc_4:* = _loc_3.frameList_vector[param2];
            if (!_loc_3.frameList_vector[param2].scaled)
            {
                _loc_5 = global.ui.mZoom.CalculateZoomMatrix(this.mOriginalScaleFactor);
                mTempRect2.x = 0;
                mTempRect2.y = 0;
                _loc_6 = this.mOriginalScaleFactor;
                _loc_4.scaled = true;
                _loc_3.seqFootXScaled = _loc_3.seqFootX * 1000 / _loc_6;
                _loc_3.seqFootYScaled = _loc_3.seqFootY * 1000 / _loc_6;
                _loc_4.scaledBitmapRectangle.width = global.ui.mZoom.InvScale(_loc_4.size_u, _loc_6);
                _loc_4.scaledBitmapRectangle.height = global.ui.mZoom.InvScale(_loc_4.size_v, _loc_6);
                mTempRect2.width = _loc_4.size_u;
                mTempRect2.height = _loc_4.size_v;
                if (mApplyFilter)
                {
                    _loc_4.scaledBitmap.applyFilter(_loc_4.orginalBitmap, _loc_4.scaledBitmapRectangle, mNullPoint, gGfxResource.mCurrent_ShaderFilter);
                }
                else
                {
                    _loc_4.scaledBitmap.fillRect(mTempRect2, 0);
                    _loc_4.scaledBitmap.draw(_loc_4.orginalBitmap, _loc_5, null, null, _loc_4.scaledBitmapRectangle, global.ui.mZoom.mSmoothing);
                    if (global.ui.mZoom.GetScaleFactor() < 300)
                    {
                        _loc_4.antialiased = false;
                    }
                }
                _loc_4.frameOffsXScaled = _loc_4.frameOffsX * 1000 / _loc_6;
                _loc_4.frameOffsYScaled = _loc_4.frameOffsY * 1000 / _loc_6;
                _loc_7 = -_loc_3.seqFootXScaled + _loc_4.frameOffsXScaled;
                _loc_8 = -_loc_3.seqFootYScaled + _loc_4.frameOffsYScaled;
                _loc_7 = _loc_7 * global.ui.mZoom.mFactorDivDefaultZoom;
                _loc_8 = _loc_8 * global.ui.mZoom.mFactorDivDefaultZoom;
                _loc_4.frameOffsXScaledCache = Math.floor(_loc_7);
                _loc_4.frameOffsYScaledCache = Math.floor(_loc_8);
            }
            else if (!mApplyFilter)
            {
                if (!_loc_4.antialiased)
                {
                    if (mSwitchToAntialiasingCntr < 5)
                    {
                        var _loc_10:* = mSwitchToAntialiasingCntr + 1;
                        mSwitchToAntialiasingCntr = _loc_10;
                        gGfxResource.mAntialiasingZoom_Shader.data.dimension.value = [global.ui.mZoom.GetInvScaleFactor()];
                        _loc_4.scaledBitmap.applyFilter(_loc_4.orginalBitmap, _loc_4.scaledBitmapRectangle, mNullPoint, gGfxResource.mAntialiasingZoom_ShaderFilter);
                        _loc_4.antialiased = true;
                    }
                }
            }
            return;
        }// end function

        public function CheckForSplitLibStreaming(param1:String, param2:int) : String
        {
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_3:String = null;
            if (this.mStreamSubtypeAndFrameState == param2)
            {
                var _loc_6:String = this;
                var _loc_7:* = this.mStreamSubtypeAndFrameState + 1;
                _loc_6.mStreamSubtypeAndFrameState = _loc_7;
                _loc_4 = gMisc.GetExtensionString(param1);
                _loc_5 = gMisc.GetFileNameWithoutExtensionString(param1);
                _loc_3 = _loc_5 + "[" + this.mStreamSubtype + "_" + this.mStreamFrame + "]" + _loc_4;
            }
            return _loc_3;
        }// end function

        public function LoadSpriteLibFromBinaryData(param1:ByteArray) : dMain
        {
            var _loc_8:dIndices = null;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:dIndices = null;
            var _loc_12:int = 0;
            var _loc_13:Vector.<int> = null;
            var _loc_14:int = 0;
            var _loc_15:dSubtypeCalculated = null;
            var _loc_16:int = 0;
            var _loc_17:int = 0;
            var _loc_18:int = 0;
            var _loc_19:int = 0;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_23:int = 0;
            var _loc_24:int = 0;
            var _loc_25:int = 0;
            var _loc_26:int = 0;
            var _loc_27:int = 0;
            var _loc_28:int = 0;
            var _loc_29:int = 0;
            var _loc_30:int = 0;
            var _loc_31:int = 0;
            var _loc_32:int = 0;
            var _loc_33:int = 0;
            var _loc_34:int = 0;
            var _loc_35:int = 0;
            var _loc_36:int = 0;
            var _loc_37:int = 0;
            var _loc_38:int = 0;
            var _loc_39:int = 0;
            var _loc_40:int = 0;
            var _loc_41:dFrameCalculated = null;
            var _loc_2:* = new dMain();
            gBinaryStream.InitBinaryStream(param1, 0);
            var _loc_3:* = gBinaryStream.ReadInt();
            var _loc_4:* = param1;
            var _loc_5:* = new Vector.<int>;
            _loc_2.spriteIndices_vector = new Vector.<dIndices>;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_3)
            {
                
                _loc_8 = new dIndices();
                _loc_9 = gBinaryStream.ReadInt();
                _loc_10 = gBinaryStream.ReadInt();
                _loc_8.name_string = gBinaryStream.ReadCStringAtPos_string(_loc_9);
                _loc_5.push(_loc_10);
                _loc_2.spriteIndices_vector.push(_loc_8);
                _loc_6++;
            }
            var _loc_7:int = 0;
            while (_loc_7 < _loc_3)
            {
                
                _loc_11 = _loc_2.spriteIndices_vector[_loc_7];
                gBinaryStream.InitBinaryStream(_loc_4, _loc_5[_loc_7]);
                _loc_12 = gBinaryStream.ReadInt();
                _loc_13 = new Vector.<int>(_loc_12);
                _loc_14 = 0;
                while (_loc_14 < _loc_12)
                {
                    
                    _loc_13[_loc_14] = gBinaryStream.ReadInt();
                    _loc_14++;
                }
                _loc_11.subtypeCalculated_vector = new Vector.<dSubtypeCalculated>;
                _loc_14 = 0;
                while (_loc_14 < _loc_12)
                {
                    
                    _loc_15 = new dSubtypeCalculated();
                    _loc_16 = _loc_13[_loc_14];
                    gBinaryStream.InitBinaryStream(_loc_4, _loc_16);
                    _loc_17 = gBinaryStream.ReadShort();
                    _loc_18 = gBinaryStream.ReadShort();
                    _loc_19 = gBinaryStream.ReadShort();
                    _loc_20 = gBinaryStream.ReadShort();
                    _loc_21 = gBinaryStream.ReadShort();
                    _loc_22 = gBinaryStream.ReadShort();
                    _loc_15.seqFootX = _loc_18;
                    _loc_15.seqFootY = _loc_19;
                    _loc_15.numFrames = _loc_22;
                    _loc_23 = gBinaryStream.a;
                    _loc_24 = 32767;
                    _loc_25 = 32767;
                    _loc_26 = 0;
                    while (_loc_26 < _loc_22)
                    {
                        
                        gBinaryStream.a = gBinaryStream.a + 16;
                        _loc_28 = gBinaryStream.ReadShort();
                        _loc_29 = gBinaryStream.ReadShort();
                        if (_loc_28 < _loc_24)
                        {
                            _loc_24 = _loc_28;
                        }
                        if (_loc_29 < _loc_25)
                        {
                            _loc_25 = _loc_29;
                        }
                        _loc_26++;
                    }
                    gBinaryStream.a = _loc_23;
                    _loc_27 = 0;
                    while (_loc_27 < _loc_22)
                    {
                        
                        _loc_30 = gBinaryStream.ReadShort();
                        gBinaryStream.ReadShort();
                        _loc_31 = gBinaryStream.ReadShort();
                        _loc_32 = gBinaryStream.ReadShort();
                        _loc_33 = gBinaryStream.ReadShort();
                        _loc_34 = gBinaryStream.ReadShort();
                        _loc_35 = gBinaryStream.ReadShort();
                        _loc_36 = gBinaryStream.ReadShort();
                        _loc_37 = gBinaryStream.ReadShort();
                        _loc_38 = gBinaryStream.ReadShort();
                        _loc_39 = _loc_37 - _loc_24;
                        _loc_40 = _loc_38 - _loc_25;
                        _loc_41 = new dFrameCalculated();
                        _loc_41.size_u = _loc_35 + _loc_39;
                        _loc_41.size_v = _loc_36 + _loc_40;
                        _loc_41.frameOffsX = _loc_24;
                        _loc_41.frameOffsY = _loc_25;
                        _loc_41.calculateRect = new Rectangle(_loc_33, _loc_34, (_loc_35 - 1), (_loc_36 - 1));
                        _loc_41.calculatePoint = new Point(_loc_39, _loc_40);
                        _loc_15.frameList_vector.push(_loc_41);
                        _loc_27++;
                    }
                    _loc_11.subtypeCalculated_vector.push(_loc_15);
                    _loc_14++;
                }
                _loc_7++;
            }
            return _loc_2;
        }// end function

        public function IsStreamingEnabled() : Boolean
        {
            if (this.mNofStreamUpgrades != 0)
            {
                if (this.mStreamSubtypeAndFrameState != 1)
                {
                    return false;
                }
            }
            return true;
        }// end function

        private function LoadBinLib(param1:String) : Boolean
        {
            var _loc_3:dMain = null;
            var _loc_4:dIndices = null;
            var _loc_2:* = gAssetManager.GetBin(param1);
            if (_loc_2 == null)
            {
                return false;
            }
            if (this.mNofStreamUpgrades != 0)
            {
                _loc_3 = this.LoadSpriteLibFromBinaryData(_loc_2);
                if (this.mLoadedSpriteLib == null)
                {
                    this.mLoadedSpriteLib = new dMain();
                    _loc_4 = new dIndices();
                    this.mLoadedSpriteLib.spriteIndices_vector.push(_loc_4);
                }
                if (this.mStreamSubtypeAndFrameState == 2)
                {
                    this.InsertSubTypeAndFrame(_loc_3, this.mStreamSubtype, this.mStreamFrame);
                }
            }
            else
            {
                this.mLoadedSpriteLib = this.LoadSpriteLibFromBinaryData(_loc_2);
            }
            this.mLoadingFinishedLib = true;
            this.mDispatcherLoadLib.doAction();
            return true;
        }// end function

        public function GetUsageCounter() : int
        {
            return this.mUsedCntr;
        }// end function

        public function PostProcessGfxLoading() : void
        {
            this.mSpriteLib = this.mLoadedSpriteLib;
            this.mOriginalGraphicsImage = this.mSpriteContainer.mOriginalGraphicsImage;
            this.mOriginalGraphicsImageBitmapData = this.mSpriteContainer.mOriginalGraphicsImageBitmapData;
            this.PrepareScaling(this.mDeltaCompression);
            this.mOriginalGraphicsImage = null;
            this.mOriginalGraphicsImageBitmapData = null;
            this.mSpriteContainer.mOriginalGraphicsImage = null;
            this.mSpriteContainer.mOriginalGraphicsImageBitmapData = null;
            this.SetDirty();
            this.mStreamingFinished = true;
            this.mSpriteContainer = null;
            return;
        }// end function

        private function InsertSubTypeAndFrame(param1:dMain, param2:int, param3:int) : void
        {
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:dSubtypeCalculated = null;
            var _loc_9:dFrameCalculated = null;
            var _loc_10:int = 0;
            var _loc_4:* = param2;
            var _loc_5:* = param3;
            if (_loc_4 >= this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector.length)
            {
                _loc_6 = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector.length - 1;
                while (_loc_6 < _loc_4)
                {
                    
                    _loc_8 = new dSubtypeCalculated();
                    this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector.push(_loc_8);
                    _loc_6++;
                }
                _loc_7 = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length - 1;
                while (_loc_7 < _loc_5)
                {
                    
                    _loc_9 = new dFrameCalculated();
                    this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.push(_loc_9);
                    this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].numFrames = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length;
                    _loc_7++;
                }
            }
            else if (_loc_5 >= this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length)
            {
                _loc_10 = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length - 1;
                while (_loc_10 < _loc_5)
                {
                    
                    this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.push(_loc_9);
                    this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].numFrames = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length;
                    _loc_10++;
                }
            }
            this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector[_loc_5] = param1.spriteIndices_vector[0].subtypeCalculated_vector[0].frameList_vector[0];
            this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].seqFootX = param1.spriteIndices_vector[0].subtypeCalculated_vector[0].seqFootX;
            this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].seqFootY = param1.spriteIndices_vector[0].subtypeCalculated_vector[0].seqFootY;
            this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].numFrames = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector[_loc_4].frameList_vector.length;
            this.mSubtypeCalculated_vector = this.mLoadedSpriteLib.spriteIndices_vector[0].subtypeCalculated_vector;
            this.mSubtypeCalculatedNof = this.mSubtypeCalculated_vector.length;
            return;
        }// end function

        private function CompleteHandlerLoadAll(event:Event) : void
        {
            this.mLoadingFinished = true;
            this.PostProcessGfxLoading();
            if (this.mNofStreamUpgrades != 0)
            {
                if (this.mStreamSubtypeAndFrameState == 3)
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mStreamSubtypeAndFrameState + 1;
                    _loc_2.mStreamSubtypeAndFrameState = _loc_3;
                }
            }
            this.mDispatcherLoadAll.doActionWithData(this.mFileName_string, this);
            return;
        }// end function

        public function SetUsageCounter(param1:int) : void
        {
            this.mUsedCntr = param1;
            return;
        }// end function

        public static function ResetSwitchAntialiasingRenderCntr() : void
        {
            mSwitchToAntialiasingCntr = 0;
            return;
        }// end function

    }
}
