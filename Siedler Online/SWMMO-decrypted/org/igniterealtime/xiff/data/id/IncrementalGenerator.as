package org.igniterealtime.xiff.data.id
{
    import org.igniterealtime.xiff.data.id.*;

    public class IncrementalGenerator extends Object implements IIDGenerator
    {
        private var myCounter:int = 0;
        private static var instance:IIDGenerator;

        public function IncrementalGenerator()
        {
            return;
        }// end function

        public function getID(param1:String) : String
        {
            var _loc_2:String = null;
            var _loc_4:* = myCounter + 1;
            myCounter = _loc_4;
            if (param1 != null)
            {
                _loc_2 = param1 + myCounter;
            }
            else
            {
                _loc_2 = myCounter.toString();
            }
            return _loc_2;
        }// end function

        public static function getInstance() : IIDGenerator
        {
            if (instance == null)
            {
                instance = new IncrementalGenerator;
            }
            return instance;
        }// end function

    }
}
