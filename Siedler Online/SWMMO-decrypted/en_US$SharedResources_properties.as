package 
{
    import en_US$SharedResources_properties.*;
    import mx.resources.*;

    public class en_US$SharedResources_properties extends ResourceBundle
    {

        public function en_US$SharedResources_properties()
        {
            super("en_US", "SharedResources");
            return;
        }// end function

        override protected function getContent() : Object
        {
            var _loc_1:Object = {dateFormat:"MM/DD/YYYY", dayNames:"Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday", thousandsSeparatorFrom:",", monthNames:"January,February,March,April,May,June,July,August,September,October,November,December", decimalSeparatorFrom:".", currencySymbol:"$", decimalSeparatorTo:".", thousandsSeparatorTo:",", monthSymbol:"", alignSymbol:"left"};
            return _loc_1;
        }// end function

    }
}
