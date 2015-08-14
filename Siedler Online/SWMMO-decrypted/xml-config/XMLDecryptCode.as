package 
{
    import com.hurlant.crypto.*;
    import com.hurlant.crypto.symmetric.*;
    import com.hurlant.util.*;
    import flash.display.*;
    import flash.utils.*;

    public class XMLDecryptCode extends Sprite
    {

        public function XMLDecryptCode()
        {
            return;
        }// end function

        public function hello() : String
        {
            return "Hello";
        }// end function

        public function render(param1)
        {
            var _loc_2:* = new ByteArray();
            _loc_2.writeUTFBytes("O99vUyAPaGXHNo");
            var _loc_3:* = new PKCS5();
            var _loc_4:* = Crypto.getCipher("blowfish-ecb", _loc_2, _loc_3);
            _loc_3.setBlockSize(_loc_4.getBlockSize());
            var _loc_5:* = Base64.decodeToByteArray(String(param1));
            _loc_4.decrypt(_loc_5);
            return _loc_5;
        }// end function

    }
}
