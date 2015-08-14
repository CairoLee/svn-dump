package nLib
{
    import flash.geom.*;

    public class cSprite extends Object
    {
        protected var mSpriteContainer:cSpriteContainer = null;
        private var zDepth:int = 0;
        protected var mPosition:cPosInt;
        private var mFinalPosition:cPosInt;
        private static var mTempRect:Rectangle = new Rectangle();
        private static var mIntTempPos:cPosInt = new cPosInt();
        private static var mNumberPosition:Point = new Point();

        public function cSprite()
        {
            this.mPosition = new cPosInt();
            this.mFinalPosition = new cPosInt();
            this.Reset();
            return;
        }// end function

        public function SetZDepth(param1:int) : void
        {
            this.zDepth = param1;
            return;
        }// end function

        public function Render() : void
        {
            this.RenderPos(this.mPosition.x, this.mPosition.y);
            return;
        }// end function

        public function GetPosition() : cPosInt
        {
            return this.mPosition;
        }// end function

        public function GetContainer() : cSpriteContainer
        {
            return this.mSpriteContainer;
        }// end function

        public function RenderPos(param1:int, param2:int) : void
        {
            this.mSpriteContainer.Rescale();
            this.mFinalPosition.x = param1;
            this.mFinalPosition.y = param2;
            global.ui.mZoom.CalculateScrollPos(this.mFinalPosition);
            mNumberPosition.x = this.mFinalPosition.x;
            mNumberPosition.y = this.mFinalPosition.y;
            cBackbuffer.CopyPixels(this.mSpriteContainer.mScaledGraphics, this.mSpriteContainer.mScaledGraphics.rect, mNumberPosition, false);
            return;
        }// end function

        public function GetZDepth() : int
        {
            return this.zDepth;
        }// end function

        public function Reset() : void
        {
            this.SetPosition(0, 0);
            this.SetZDepth(0);
            this.mSpriteContainer = null;
            return;
        }// end function

        public function GetWidth() : int
        {
            return this.mSpriteContainer.mOriginalGraphicsImage.width;
        }// end function

        public function RenderUV(param1:int, param2:int, param3:int, param4:int, param5:int, param6:int) : void
        {
            this.mSpriteContainer.Rescale();
            mTempRect.x = global.ui.mZoom.InvScale(param5, this.mSpriteContainer.mOriginalScaleFactor);
            mTempRect.y = global.ui.mZoom.InvScale(param6, this.mSpriteContainer.mOriginalScaleFactor);
            mTempRect.width = global.ui.mZoom.InvScale(param3, this.mSpriteContainer.mOriginalScaleFactor);
            mTempRect.height = global.ui.mZoom.InvScale(param4, this.mSpriteContainer.mOriginalScaleFactor);
            this.mFinalPosition.x = param1;
            this.mFinalPosition.y = param2;
            global.ui.mZoom.CalculateScrollPos(this.mFinalPosition);
            mNumberPosition.x = this.mFinalPosition.x;
            mNumberPosition.y = this.mFinalPosition.y;
            cBackbuffer.CopyPixels(this.mSpriteContainer.mScaledGraphics, mTempRect, mNumberPosition, false);
            return;
        }// end function

        public function RenderTransform(param1:String) : void
        {
            this.RenderPos(this.mPosition.x, this.mPosition.y);
            return;
        }// end function

        public function SetPosition(param1:int, param2:int) : void
        {
            this.mPosition.x = param1;
            this.mPosition.y = param2;
            return;
        }// end function

        public function GetHeight() : int
        {
            return this.mSpriteContainer.mOriginalGraphicsImage.height;
        }// end function

        public function SetContainer(param1:Object) : void
        {
            this.mSpriteContainer = param1 as cSpriteContainer;
            return;
        }// end function

    }
}
