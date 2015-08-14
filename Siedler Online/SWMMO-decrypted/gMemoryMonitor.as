package 
{
    import GO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.system.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.events.*;
    import mx.formatters.*;
    import nLib.*;
    import nLib.SpriteLibDataClass.*;

    public class gMemoryMonitor extends Object implements IEventDispatcher
    {
        public var mLoadedGFXCount:uint = 0;
        public var mLoadedBinData:uint = 0;
        public var mLoadedXMLCount:uint = 0;
        public var mLoadedXMLData:uint = 0;
        private var _93406797mUsedBytesSprites:uint = 0;
        private var _969911684mOtherMemory:uint = 0;
        private var _bindingEventDispatcher:EventDispatcher;
        private var _1659820945mLoadedGFXData:uint = 0;
        private var mGeneralInterface:cGeneralInterface;
        public var mLoadedBinCount:uint = 0;
        private var mContainerList_vector:Vector.<cSpriteLibContainer>;
        private var _333785108mUsedBytesUnscaled:uint = 0;
        private var mObjects:Dictionary;
        private var _840780677mUsedBytesScaled:uint = 0;
        private var _1931678392mTotalMemory:uint = 0;
        private const LF_string:String = "\n";
        public static const DETAIL_LEVEL_NORMAL:int = 1;
        public static const DETAIL_LEVEL_COMPLETE:int = 2;
        public static const DETAIL_LEVEL_SHORT:int = 0;

        public function gMemoryMonitor()
        {
            this.mContainerList_vector = new Vector.<cSpriteLibContainer>;
            this.mObjects = new Dictionary();
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function RegisterSpriteLibContainer(param1:cSpriteLibContainer) : void
        {
            if (param1)
            {
                this.mContainerList_vector.push(param1);
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get mOtherMemory() : uint
        {
            return this._969911684mOtherMemory;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        private function CalculateMemorySize(param1:BitmapData) : Number
        {
            if (param1 == null)
            {
                return 0;
            }
            return param1.width * param1.height * 4;
        }// end function

        public function get mLoadedGFXData() : uint
        {
            return this._1659820945mLoadedGFXData;
        }// end function

        public function get mUsedBytesUnscaled() : uint
        {
            return this._333785108mUsedBytesUnscaled;
        }// end function

        public function set mOtherMemory(param1:uint) : void
        {
            var _loc_2:* = this._969911684mOtherMemory;
            if (_loc_2 !== param1)
            {
                this._969911684mOtherMemory = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mOtherMemory", _loc_2, param1));
            }
            return;
        }// end function

        private function AlignRight_string(param1:String) : String
        {
            var _loc_2:* = 10 - param1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                param1 = " " + param1;
                _loc_3++;
            }
            return param1;
        }// end function

        public function set mUsedBytesSprites(param1:uint) : void
        {
            var _loc_2:* = this._93406797mUsedBytesSprites;
            if (_loc_2 !== param1)
            {
                this._93406797mUsedBytesSprites = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mUsedBytesSprites", _loc_2, param1));
            }
            return;
        }// end function

        public function set mLoadedGFXData(param1:uint) : void
        {
            var _loc_2:* = this._1659820945mLoadedGFXData;
            if (_loc_2 !== param1)
            {
                this._1659820945mLoadedGFXData = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mLoadedGFXData", _loc_2, param1));
            }
            return;
        }// end function

        private function AlignLeft_string(param1:String) : String
        {
            var _loc_2:* = 24 - param1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                param1 = param1 + " ";
                _loc_3++;
            }
            return param1;
        }// end function

        private function GenerateReportForGOs_string(param1:int) : String
        {
            var _loc_4:Object = null;
            var _loc_5:Object = null;
            var _loc_6:int = 0;
            var _loc_7:cGOSpriteLibContainer = null;
            var _loc_8:int = 0;
            var _loc_9:dSubtypeCalculated = null;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:dFrameCalculated = null;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:uint = 0;
            var _loc_16:uint = 0;
            var _loc_17:int = 0;
            var _loc_2:Array = [];
            var _loc_3:String = "";
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "MEMORY USAGE BY GAME OBJECT:");
            if (param1 != -1)
            {
                _loc_3 = _loc_3 + (this.LF_string + "and all Alpha Areas below Alphavalue " + param1 + " in %");
            }
            _loc_3 = _loc_3 + (this.LF_string + "==================================");
            for (_loc_4 in this.mObjects)
            {
                
                _loc_6 = 0;
                for each (_loc_7 in this.mObjects[_loc_4])
                {
                    
                    if (!_loc_7.mStreamingInProgress && !_loc_7.mStream)
                    {
                        _loc_8 = this.CalculateMemorySize(_loc_7.mOriginalGraphicsImageBitmapData);
                        for each (_loc_9 in _loc_7.mSubtypeCalculated_vector)
                        {
                            
                            _loc_10 = 0;
                            _loc_11 = 0;
                            for each (_loc_12 in _loc_9.frameList_vector)
                            {
                                
                                _loc_8 = _loc_8 + this.CalculateMemorySize(_loc_12.orginalBitmap);
                                _loc_8 = _loc_8 + this.CalculateMemorySize(_loc_12.scaledBitmap);
                                if (param1 != -1)
                                {
                                    _loc_13 = 0;
                                    while (_loc_13 < _loc_12.orginalBitmap.height)
                                    {
                                        
                                        _loc_14 = 0;
                                        while (_loc_14 < _loc_12.orginalBitmap.width)
                                        {
                                            
                                            _loc_15 = _loc_12.orginalBitmap.getPixel32(_loc_14, _loc_13);
                                            _loc_16 = _loc_15 >> 24;
                                            if (_loc_16 < param1)
                                            {
                                                _loc_10++;
                                            }
                                            else
                                            {
                                                _loc_11++;
                                            }
                                            _loc_14++;
                                        }
                                        _loc_13++;
                                    }
                                }
                            }
                            if (param1 != -1)
                            {
                                if (_loc_11 + _loc_10 > 0)
                                {
                                    _loc_17 = _loc_10 * 100 / (_loc_11 + _loc_10);
                                    if (_loc_17 > _loc_6)
                                    {
                                        _loc_6 = _loc_17;
                                    }
                                }
                            }
                        }
                    }
                }
                if (param1 != -1)
                {
                    _loc_2.push({name:_loc_4 as String, size:_loc_8, alphaPercentage:_loc_6});
                    continue;
                }
                _loc_2.push({name:_loc_4 as String, size:_loc_8});
            }
            if (param1 != -1)
            {
                _loc_2 = _loc_2.sortOn("alphaPercentage", Array.NUMERIC | Array.DESCENDING);
            }
            else
            {
                _loc_2 = _loc_2.sortOn("size", Array.NUMERIC | Array.DESCENDING);
            }
            for each (_loc_5 in _loc_2)
            {
                
                if (param1 != -1)
                {
                    _loc_3 = _loc_3 + (this.LF_string + this.AlignLeft_string(_loc_5.name) + this.AlignRight_string(this.FormatAsMB_string(_loc_5.size) + "   Alpha " + _loc_5.alphaPercentage + "%"));
                    continue;
                }
                _loc_3 = _loc_3 + (this.LF_string + this.AlignLeft_string(_loc_5.name) + this.AlignRight_string(this.FormatAsMB_string(_loc_5.size)));
            }
            return _loc_3;
        }// end function

        public function RegisterLoadedGraphic(param1:int) : void
        {
            this.mLoadedGFXData = this.mLoadedGFXData + param1;
            var _loc_2:String = this;
            var _loc_3:* = this.mLoadedGFXCount + 1;
            _loc_2.mLoadedGFXCount = _loc_3;
            return;
        }// end function

        public function set mUsedBytesUnscaled(param1:uint) : void
        {
            var _loc_2:* = this._333785108mUsedBytesUnscaled;
            if (_loc_2 !== param1)
            {
                this._333785108mUsedBytesUnscaled = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mUsedBytesUnscaled", _loc_2, param1));
            }
            return;
        }// end function

        private function GetBuildingCount() : int
        {
            var _loc_2:cIsoElement = null;
            var _loc_1:int = 0;
            for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_2)
                {
                    _loc_1++;
                }
            }
            return _loc_1;
        }// end function

        public function Init(param1:cGeneralInterface) : void
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function RegisterGOSpriteLibContainer(param1:cGOSpriteLibContainer) : void
        {
            var _loc_2:Vector.<cGOSpriteLibContainer> = null;
            if (param1 == null)
            {
                return;
            }
            if (this.mObjects[param1.mGfxResourceListName_string])
            {
                _loc_2 = this.mObjects[param1.mGfxResourceListName_string];
            }
            else
            {
                _loc_2 = new Vector.<cGOSpriteLibContainer>;
            }
            _loc_2.push(param1);
            this.mObjects[param1.mGfxResourceListName_string] = _loc_2;
            return;
        }// end function

        private function GetStreetCount() : int
        {
            var _loc_2:cIsoElement = null;
            var _loc_1:int = 0;
            for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_2)
                {
                    _loc_1++;
                }
            }
            return _loc_1;
        }// end function

        public function get mTotalMemory() : uint
        {
            return this._1931678392mTotalMemory;
        }// end function

        public function RegisterLoadedBin(param1:int) : void
        {
            this.mLoadedBinData = this.mLoadedBinData + param1;
            var _loc_2:String = this;
            var _loc_3:* = this.mLoadedBinCount + 1;
            _loc_2.mLoadedBinCount = _loc_3;
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function get mUsedBytesSprites() : uint
        {
            return this._93406797mUsedBytesSprites;
        }// end function

        public function RegisterLoadedXML(param1:int) : void
        {
            this.mLoadedXMLData = this.mLoadedXMLData + param1;
            var _loc_2:String = this;
            var _loc_3:* = this.mLoadedXMLCount + 1;
            _loc_2.mLoadedXMLCount = _loc_3;
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function GenerateReport_string(param1:int, param2:int) : String
        {
            var _loc_3:String = "";
            var _loc_4:* = new Date();
            var _loc_5:* = new DateFormatter();
            new DateFormatter().formatString = "DD.MM.YYYY J:NN";
            _loc_3 = _loc_3 + "SWMMO MEMORY MONITOR";
            _loc_3 = _loc_3 + (this.LF_string + "Report created: " + _loc_5.format(_loc_4));
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "TRAFFIC:");
            _loc_3 = _loc_3 + (this.LF_string + "==================================");
            _loc_3 = _loc_3 + (this.LF_string + "Client size:            " + this.AlignRight_string(this.FormatAsMB_string(Application.application.loaderInfo.bytesTotal)));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded xml files:       " + this.AlignRight_string(this.mLoadedXMLCount.toString()));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded xml data:        " + this.AlignRight_string(this.FormatAsMB_string(this.mLoadedXMLData)));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded gfx files:       " + this.AlignRight_string(this.mLoadedGFXCount.toString()));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded gfx data:        " + this.AlignRight_string(this.FormatAsMB_string(this.mLoadedGFXData)));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded bin files:       " + this.AlignRight_string(this.mLoadedBinCount.toString()));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded bin data:        " + this.AlignRight_string(this.FormatAsMB_string(this.mLoadedBinData)));
            _loc_3 = _loc_3 + (this.LF_string + "Loaded game data:       " + this.AlignRight_string("---"));
            _loc_3 = _loc_3 + (this.LF_string + "----------------------------------");
            _loc_3 = _loc_3 + (this.LF_string + "Total traffic:          " + this.AlignRight_string(this.FormatAsMB_string(Application.application.loaderInfo.bytesTotal + this.mLoadedXMLData + this.mLoadedGFXData + this.mLoadedBinData)));
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "GAME DETAILS:");
            _loc_3 = _loc_3 + (this.LF_string + "==================================");
            _loc_3 = _loc_3 + (this.LF_string + "Stage size:             " + this.AlignRight_string(Application.application.stage.stageWidth + " x " + Application.application.stage.stageHeight));
            _loc_3 = _loc_3 + (this.LF_string + "Buildings on map:       " + this.AlignRight_string(this.GetBuildingCount().toString()));
            _loc_3 = _loc_3 + (this.LF_string + "Street segments on map: " + this.AlignRight_string(this.GetStreetCount().toString()));
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "");
            _loc_3 = _loc_3 + (this.LF_string + "MEMORY USAGE:");
            _loc_3 = _loc_3 + (this.LF_string + "==================================");
            _loc_3 = _loc_3 + (this.LF_string + "Original Sprites:       " + this.AlignRight_string(this.FormatAsMB_string(this.mUsedBytesSprites)));
            _loc_3 = _loc_3 + (this.LF_string + "Unscaled Bitmaps:       " + this.AlignRight_string(this.FormatAsMB_string(this.mUsedBytesUnscaled)));
            _loc_3 = _loc_3 + (this.LF_string + "Scaled Bitmaps:         " + this.AlignRight_string(this.FormatAsMB_string(this.mUsedBytesScaled)));
            _loc_3 = _loc_3 + (this.LF_string + "Other:                  " + this.AlignRight_string(this.FormatAsMB_string(this.mOtherMemory)));
            _loc_3 = _loc_3 + (this.LF_string + "----------------------------------");
            _loc_3 = _loc_3 + (this.LF_string + "Total memory used:      " + this.AlignRight_string(this.FormatAsMB_string(this.mTotalMemory)));
            _loc_3 = _loc_3 + (this.LF_string + this.GenerateReportForGOs_string(param2));
            return _loc_3;
        }// end function

        public function set mTotalMemory(param1:uint) : void
        {
            var _loc_2:* = this._1931678392mTotalMemory;
            if (_loc_2 !== param1)
            {
                this._1931678392mTotalMemory = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mTotalMemory", _loc_2, param1));
            }
            return;
        }// end function

        public function FormatAsMB_string(param1:uint) : String
        {
            var _loc_3:int = 0;
            var _loc_2:* = param1 / 1024;
            if (_loc_2 > 1024)
            {
                _loc_3 = _loc_2 / 1024;
                return _loc_3.toFixed(2) + " MB";
            }
            return _loc_2.toFixed(2) + " KB";
        }// end function

        public function set mUsedBytesScaled(param1:uint) : void
        {
            var _loc_2:* = this._840780677mUsedBytesScaled;
            if (_loc_2 !== param1)
            {
                this._840780677mUsedBytesScaled = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mUsedBytesScaled", _loc_2, param1));
            }
            return;
        }// end function

        public function CalculateMemoryUsage() : void
        {
            var _loc_4:cSpriteLibContainer = null;
            var _loc_5:dSubtypeCalculated = null;
            var _loc_6:dFrameCalculated = null;
            var _loc_1:uint = 0;
            var _loc_2:uint = 0;
            var _loc_3:uint = 0;
            for each (_loc_4 in this.mContainerList_vector)
            {
                
                _loc_1 = _loc_1 + this.CalculateMemorySize(_loc_4.mOriginalGraphicsImageBitmapData);
                for each (_loc_5 in _loc_4.mSubtypeCalculated_vector)
                {
                    
                    for each (_loc_6 in _loc_5.frameList_vector)
                    {
                        
                        _loc_2 = _loc_2 + this.CalculateMemorySize(_loc_6.orginalBitmap);
                        _loc_3 = _loc_3 + this.CalculateMemorySize(_loc_6.scaledBitmap);
                    }
                }
            }
            this.mUsedBytesSprites = _loc_1;
            this.mUsedBytesUnscaled = _loc_2;
            this.mUsedBytesScaled = _loc_3;
            this.mTotalMemory = System.totalMemory;
            this.mOtherMemory = this.mTotalMemory - (this.mUsedBytesSprites + this.mUsedBytesUnscaled + this.mUsedBytesScaled);
            return;
        }// end function

        public function get mUsedBytesScaled() : uint
        {
            return this._840780677mUsedBytesScaled;
        }// end function

    }
}
