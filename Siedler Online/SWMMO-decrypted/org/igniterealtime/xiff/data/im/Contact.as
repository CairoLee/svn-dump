package org.igniterealtime.xiff.data.im
{
    import org.igniterealtime.xiff.core.*;

    public interface Contact
    {

        public function Contact();

        function set jid(param1:UnescapedJID) : void;

        function get online() : Boolean;

        function get show() : String;

        function get jid() : UnescapedJID;

        function set online(param1:Boolean) : void;

        function set show(param1:String) : void;

        function set displayName(param1:String) : void;

        function get displayName() : String;

    }
}
