package com.google.analytics.campaign
{
    import com.google.analytics.utils.*;

    public class CampaignInfo extends Object
    {
        private var _new:Boolean;
        private var _empty:Boolean;

        public function CampaignInfo(param1:Boolean = true, param2:Boolean = false)
        {
            _empty = param1;
            _new = param2;
            return;
        }// end function

        public function toURLString() : String
        {
            var _loc_1:* = toVariables();
            return _loc_1.toString();
        }// end function

        public function isNew() : Boolean
        {
            return _new;
        }// end function

        public function get utmcn() : String
        {
            return "1";
        }// end function

        public function isEmpty() : Boolean
        {
            return _empty;
        }// end function

        public function toVariables() : Variables
        {
            var _loc_1:* = new Variables();
            _loc_1.URIencode = true;
            if (!isEmpty() && isNew())
            {
                _loc_1.utmcn = utmcn;
            }
            if (!isEmpty() && !isNew())
            {
                _loc_1.utmcr = utmcr;
            }
            return _loc_1;
        }// end function

        public function get utmcr() : String
        {
            return "1";
        }// end function

    }
}
