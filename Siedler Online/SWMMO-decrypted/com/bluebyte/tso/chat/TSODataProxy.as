package com.bluebyte.tso.chat
{
    import org.puremvc.as3.multicore.patterns.proxy.*;

    public class TSODataProxy extends Proxy
    {
        private var _playerTag:String;
        public static const NAME:String = "TSODataProxy";

        public function TSODataProxy()
        {
            super(NAME);
            return;
        }// end function

        public function get playerTag() : String
        {
            return this._playerTag;
        }// end function

        public function set playerTag(param1:String) : void
        {
            this._playerTag = param1;
            return;
        }// end function

    }
}
