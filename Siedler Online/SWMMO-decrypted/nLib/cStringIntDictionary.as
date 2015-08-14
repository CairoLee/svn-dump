package nLib
{
    import flash.utils.*;

    public class cStringIntDictionary extends Object
    {
        private var mDictionary:Object;

        public function cStringIntDictionary()
        {
            this.mDictionary = new Object();
            this.Reset();
            return;
        }// end function

        public function Add(param1:String, param2:int) : int
        {
            var _loc_3:int = 0;
            if (this.mDictionary[param1] != null)
            {
                _loc_3 = this.mDictionary[param1];
                _loc_3 = _loc_3 + param2;
                this.mDictionary[param1] = _loc_3;
                return _loc_3;
            }
            return defines.ILLEGAL_INT_POS;
        }// end function

        public function Values() : Object
        {
            return this.mDictionary;
        }// end function

        public function DeleteKeyNC(param1:String) : void
        {
            delete this.mDictionary[param1];
            return;
        }// end function

        public function GetNC(param1:String, param2:int) : int
        {
            return this.mDictionary[param1];
        }// end function

        public function Reset() : void
        {
            this.mDictionary = new Dictionary();
            return;
        }// end function

        public function DeleteKey(param1:String) : Boolean
        {
            if (this.mDictionary[param1] != null)
            {
                delete this.mDictionary[param1];
                return true;
            }
            return false;
        }// end function

        public function AddNC(param1:String, param2:int) : int
        {
            var _loc_3:* = this.mDictionary[param1];
            _loc_3 = _loc_3 + param2;
            this.mDictionary[param1] = _loc_3;
            return _loc_3;
        }// end function

        public function Get(param1:String) : int
        {
            if (this.mDictionary[param1] != null)
            {
                return this.mDictionary[param1];
            }
            return defines.ILLEGAL_INT_POS;
        }// end function

        public function Put(param1:String, param2:int) : void
        {
            this.mDictionary[param1] = param2;
            return;
        }// end function

        public function Contains(param1:String) : Boolean
        {
            return this.mDictionary[param1] != null;
        }// end function

    }
}
