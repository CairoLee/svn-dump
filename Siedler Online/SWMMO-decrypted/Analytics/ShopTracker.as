package Analytics
{
    import com.google.analytics.*;
    import mx.core.*;

    public class ShopTracker extends GATracker
    {
        private var mCurrentShop:String;
        private var mCurrentGroup:String;
        private var mCurrentItem:String;

        public function ShopTracker()
        {
            super(Application.application.GAMESTATE_ID_SHOP_WINDOW, defines.TRACKING_ID, "AS3", false);
            return;
        }// end function

        public function trackShowShop(param1:String) : void
        {
            this.mCurrentShop = param1;
            this.trackPageview("/" + param1);
            return;
        }// end function

        override public function trackPageview(param1:String = "") : void
        {
            if (definesMaster.MASTER_VERSION)
            {
                super.trackPageview(param1);
            }
            return;
        }// end function

        public function trackSelectGroup(param1:String) : void
        {
            this.mCurrentGroup = param1;
            this.trackPageview("/" + this.mCurrentShop + "/" + param1);
            return;
        }// end function

        public function trackSelectItem(param1:String) : void
        {
            this.mCurrentItem = param1;
            this.trackPageview("/" + this.mCurrentShop + "/" + this.mCurrentGroup + "/" + param1);
            return;
        }// end function

    }
}
