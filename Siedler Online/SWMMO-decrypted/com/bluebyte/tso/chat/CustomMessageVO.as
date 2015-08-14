package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.extensions.*;
    import com.bluebyte.bluefire.api.model.vo.*;

    public class CustomMessageVO extends MessageVO
    {
        private var _bluebyte:Boolean;

        public function CustomMessageVO(param1:MessageVO)
        {
            var _loc_3:IMessageExtension = null;
            this.room = param1.room;
            this.clickable = param1.clickable;
            this.groupMessage = param1.groupMessage;
            this.important = param1.important;
            this.moderator = param1.moderator;
            this.ownname = param1.ownname;
            this.receiver = param1.receiver;
            this.sender = param1.sender;
            this.text = param1.text;
            this.time = param1.time;
            var _loc_2:* = param1.getAllExtensions();
            for each (_loc_3 in _loc_2)
            {
                
                this.addExtension(_loc_3);
            }
            return;
        }// end function

        public function get bluebyte() : Boolean
        {
            return this._bluebyte;
        }// end function

        public function set bluebyte(param1:Boolean) : void
        {
            this._bluebyte = param1;
            return;
        }// end function

    }
}
