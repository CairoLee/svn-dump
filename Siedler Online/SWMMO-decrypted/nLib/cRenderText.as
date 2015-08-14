package nLib
{
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.geom.*;
    import flash.text.*;
    import mx.core.*;

    public class cRenderText extends Object
    {
        private var mTempMatrix:Matrix;
        private var rect2:Rectangle;
        private var flash_align_left_string:String = "left";
        private var point:Point;
        private var mTextFormat:TextFormat;
        private var mFontCharHeight:int;
        private var mFontTextWidth:int;
        private var mCachedFont:BitmapData;
        private var mTextField:TextField;
        private var mCharWidthList:Vector.<int>;
        private var rect:Rectangle;
        private var mCharRenderedList:Vector.<int>;
        private var mCharXPosList:Vector.<int>;
        private static var mFontText:String;

        public function cRenderText(param1:String, param2:int, param3:Boolean, param4:String, param5:uint, param6:String, param7:int = -1, param8:int = -1)
        {
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            this.mTextField = new TextField();
            this.mTempMatrix = new Matrix();
            this.mTextFormat = new TextFormat();
            this.mCharXPosList = new Vector.<int>(65535, 0);
            this.mCharRenderedList = new Vector.<int>(65535, 0);
            this.mCharWidthList = new Vector.<int>(65535, 0);
            this.rect = new Rectangle();
            this.rect2 = new Rectangle();
            this.point = new Point();
            this.mTextFormat.font = param1;
            this.mTextFormat.size = param2;
            this.mTextFormat.align = param4;
            this.mTextFormat.bold = param3;
            this.mTextField.embedFonts = Application.application.systemManager.isFontFaceEmbedded(this.mTextFormat);
            this.mTextField.defaultTextFormat = this.mTextFormat;
            this.mTextField.selectable = false;
            this.mTextField.cacheAsBitmap = false;
            if (param7 == -1)
            {
                this.mTextField.autoSize = param6;
            }
            else
            {
                this.mTextField.width = param7;
                this.mTextField.height = param8;
            }
            this.mTextField.textColor = param5;
            return;
        }// end function

        public function WriteCenterBackground(param1:BitmapData, param2:String, param3:int, param4:int, param5:int) : void
        {
            var _loc_6:int = 0;
            var _loc_8:int = 0;
            var _loc_7:* = param2.length;
            var _loc_9:int = 0;
            _loc_6 = 0;
            while (_loc_6 < _loc_7)
            {
                
                _loc_8 = param2.charCodeAt(_loc_6);
                _loc_9 = _loc_9 + this.mCharWidthList[_loc_8];
                _loc_6++;
            }
            this.point.x = param3 - (_loc_9 >> 1);
            this.point.y = param4 - (this.rect.height >> 1);
            this.rect2.y = this.point.y;
            this.rect2.height = this.rect.height;
            _loc_6 = 0;
            while (_loc_6 < _loc_7)
            {
                
                _loc_8 = param2.charCodeAt(_loc_6);
                if (!this.mCharXPosList[_loc_8])
                {
                    this.InitChar(param2.charAt(_loc_6));
                }
                this.rect.x = this.mCharXPosList[_loc_8];
                this.rect.width = this.mCharWidthList[_loc_8];
                this.rect2.x = this.point.x;
                this.rect2.width = this.rect.width;
                param1.fillRect(this.rect2, param5);
                param1.copyPixels(this.mCachedFont, this.rect, this.point, null, null, true);
                this.point.x = this.point.x + this.rect.width;
                _loc_6++;
            }
            return;
        }// end function

        public function InitChar(param1:String) : void
        {
            this.mTextField.text = param1;
            var _loc_2:* = this.mTextField.getLineMetrics(0);
            this.mFontTextWidth = this.mFontTextWidth + (_loc_2.width + _loc_2.x);
            var _loc_3:* = _loc_2.height + _loc_2.descent;
            if (_loc_3 > this.mFontCharHeight)
            {
                this.mFontCharHeight = _loc_3;
            }
            var _loc_4:* = new BitmapData(this.mFontTextWidth, this.mFontCharHeight);
            var _loc_5:int = 0;
            this.rect.y = 0;
            this.rect.x = 0;
            this.rect.width = this.mFontTextWidth;
            this.rect.height = this.mFontCharHeight;
            _loc_4.fillRect(this.rect, 0);
            if (this.mCachedFont)
            {
                _loc_5 = this.mCachedFont.width;
                _loc_4.copyPixels(this.mCachedFont, this.mCachedFont.rect, new Point());
            }
            var _loc_6:* = param1.charCodeAt(0);
            this.WriteSlow(_loc_4, param1, _loc_5 - _loc_2.x, 0);
            this.mCharXPosList[_loc_6] = _loc_5;
            this.mCharWidthList[_loc_6] = _loc_2.width + _loc_2.x;
            this.mCachedFont = _loc_4;
            return;
        }// end function

        public function WriteSlow(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mTextField.text = param2;
            this.mTextField.textColor = 2105376;
            this.mTempMatrix.tx = param3 + 1;
            this.mTempMatrix.ty = param4 + 1;
            param1.draw(this.mTextField, this.mTempMatrix);
            this.mTempMatrix.tx = param3 - 1;
            this.mTempMatrix.ty = param4 - 1;
            param1.draw(this.mTextField, this.mTempMatrix);
            this.mTempMatrix.tx = param3 + 1;
            this.mTempMatrix.ty = param4 - 1;
            param1.draw(this.mTextField, this.mTempMatrix);
            this.mTempMatrix.tx = param3 - 1;
            this.mTempMatrix.ty = param4 + 1;
            param1.draw(this.mTextField, this.mTempMatrix);
            this.mTempMatrix.tx = param3;
            this.mTempMatrix.ty = param4;
            this.mTextField.textColor = 16775143;
            param1.draw(this.mTextField, this.mTempMatrix);
            return;
        }// end function

        public function WriteCenter(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            var _loc_5:int = 0;
            var _loc_7:int = 0;
            var _loc_6:* = param2.length;
            var _loc_8:int = 0;
            _loc_5 = 0;
            while (_loc_5 < _loc_6)
            {
                
                _loc_7 = param2.charCodeAt(_loc_5);
                _loc_8 = _loc_8 + this.mCharWidthList[_loc_7];
                _loc_5++;
            }
            this.point.x = param3 - (_loc_8 >> 1);
            this.point.y = param4 - (this.rect.height >> 1);
            _loc_5 = 0;
            while (_loc_5 < _loc_6)
            {
                
                _loc_7 = param2.charCodeAt(_loc_5);
                if (!this.mCharXPosList[_loc_7])
                {
                    this.InitChar(param2.charAt(_loc_5));
                }
                this.rect.x = this.mCharXPosList[_loc_7];
                this.rect.width = this.mCharWidthList[_loc_7];
                param1.copyPixels(this.mCachedFont, this.rect, this.point, null, null, true);
                this.point.x = this.point.x + this.rect.width;
                _loc_5++;
            }
            return;
        }// end function

        public function Write(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            var _loc_6:int = 0;
            var _loc_5:* = param2.length;
            this.point.x = param3;
            this.point.y = param4;
            var _loc_7:int = 0;
            while (_loc_7 < _loc_5)
            {
                
                _loc_6 = param2.charCodeAt(_loc_7);
                if (_loc_6 == 10)
                {
                    this.point.x = param3;
                    this.point.y = this.point.y + this.mFontCharHeight;
                }
                if (!this.mCharXPosList[_loc_6])
                {
                    this.InitChar(param2.charAt(_loc_7));
                }
                this.rect.x = this.mCharXPosList[_loc_6];
                this.rect.width = this.mCharWidthList[_loc_6];
                param1.copyPixels(this.mCachedFont, this.rect, this.point, null, null, true);
                this.point.x = this.point.x + this.rect.width;
                _loc_7++;
            }
            return;
        }// end function

    }
}
