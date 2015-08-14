package com.bluebyte.bluefire.flex3.defaultClient
{
    import com.bluebyte.bluefire.puremvc.view.*;
    import mx.controls.*;

    public class ChatToggleButtonBar extends List implements IBFList
    {

        public function ChatToggleButtonBar()
        {
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            if (super.dataProvider == param1)
            {
                return;
            }
            super.dataProvider = param1;
            if (param1 == null)
            {
                return;
            }
            if (this.dataProvider.length > 0)
            {
                this.selectedIndex = 0;
            }
            else
            {
                this.selectedIndex = -1;
            }
            return;
        }// end function

    }
}
