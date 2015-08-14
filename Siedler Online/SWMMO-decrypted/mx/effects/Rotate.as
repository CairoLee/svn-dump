package mx.effects
{
    import mx.effects.effectClasses.*;

    public class Rotate extends TweenEffect
    {
        public var originY:Number;
        public var angleTo:Number = 360;
        public var originX:Number;
        public var angleFrom:Number = 0;
        static const VERSION:String = "3.5.0.12683";
        private static var AFFECTED_PROPERTIES:Array = ["rotation"];

        public function Rotate(param1:Object = null)
        {
            super(param1);
            instanceClass = RotateInstance;
            hideFocusRing = true;
            return;
        }// end function

        override protected function initInstance(param1:IEffectInstance) : void
        {
            super.initInstance(param1);
            var _loc_2:* = RotateInstance(param1);
            _loc_2.angleFrom = angleFrom;
            _loc_2.angleTo = angleTo;
            _loc_2.originX = originX;
            _loc_2.originY = originY;
            return;
        }// end function

        override public function get hideFocusRing() : Boolean
        {
            return super.hideFocusRing;
        }// end function

        override public function set hideFocusRing(param1:Boolean) : void
        {
            super.hideFocusRing = param1;
            return;
        }// end function

        override public function getAffectedProperties() : Array
        {
            return AFFECTED_PROPERTIES;
        }// end function

    }
}
