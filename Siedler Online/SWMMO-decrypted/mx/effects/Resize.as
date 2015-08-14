package mx.effects
{
    import mx.effects.effectClasses.*;

    public class Resize extends TweenEffect
    {
        public var hideChildrenTargets:Array;
        public var widthTo:Number;
        public var heightTo:Number;
        public var widthFrom:Number;
        public var heightFrom:Number;
        public var widthBy:Number;
        public var heightBy:Number;
        static const VERSION:String = "3.5.0.12683";
        private static var AFFECTED_PROPERTIES:Array = ["width", "height", "explicitWidth", "explicitHeight", "percentWidth", "percentHeight"];

        public function Resize(param1:Object = null)
        {
            super(param1);
            instanceClass = ResizeInstance;
            return;
        }// end function

        override protected function initInstance(param1:IEffectInstance) : void
        {
            super.initInstance(param1);
            var _loc_2:* = ResizeInstance(param1);
            if (!isNaN(widthFrom))
            {
                _loc_2.widthFrom = widthFrom;
            }
            if (!isNaN(widthTo))
            {
                _loc_2.widthTo = widthTo;
            }
            if (!isNaN(widthBy))
            {
                _loc_2.widthBy = widthBy;
            }
            if (!isNaN(heightFrom))
            {
                _loc_2.heightFrom = heightFrom;
            }
            if (!isNaN(heightTo))
            {
                _loc_2.heightTo = heightTo;
            }
            if (!isNaN(heightBy))
            {
                _loc_2.heightBy = heightBy;
            }
            _loc_2.hideChildrenTargets = hideChildrenTargets;
            return;
        }// end function

        override public function getAffectedProperties() : Array
        {
            return AFFECTED_PROPERTIES;
        }// end function

    }
}
