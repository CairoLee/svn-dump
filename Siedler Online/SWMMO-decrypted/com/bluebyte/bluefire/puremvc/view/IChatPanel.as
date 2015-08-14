package com.bluebyte.bluefire.puremvc.view
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import flash.events.*;

    public interface IChatPanel extends IEventDispatcher
    {

        public function IChatPanel();

        function set selectedChannel(param1:ChannelVO) : void;

        function get whispers() : IBFList;

        function get visible() : Boolean;

        function get messageInput() : IBFTextInput;

        function set visible(param1:Boolean) : void;

        function activateWhisper() : void;

        function get mucs() : IBFList;

        function deactivateWhisper() : void;

        function get selectedChannel() : ChannelVO;

    }
}
