package com.bluebyte.bluefire.api.model.vo
{

    public class MessageVOContainer extends Object
    {
        private var _messageVO:MessageVO;

        public function MessageVOContainer(param1:MessageVO)
        {
            this._messageVO = param1;
            return;
        }// end function

        public function set message(param1:MessageVO) : void
        {
            this._messageVO = param1;
            return;
        }// end function

        public function get message() : MessageVO
        {
            return this._messageVO;
        }// end function

    }
}
