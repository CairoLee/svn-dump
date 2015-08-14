package 
{
    import en_US$formatters_properties.*;
    import mx.resources.*;

    public class en_US$formatters_properties extends ResourceBundle
    {

        public function en_US$formatters_properties()
        {
            super("en_US", "formatters");
            return;
        }// end function

        override protected function getContent() : Object
        {
            var _loc_1:Object = {zipCodeFormat:"#####", defaultInvalidFormatError:"Invalid format", pm:"PM", useThousandsSeparator:"true", useNegativeSign:"true", am:"AM", areaCode:"-1", validPatternChars:"+()#- .", phoneNumberFormat:"(###) ###-####", defaultInvalidValueError:"Invalid value", areaCodeFormat:"(###)", monthNamesShort:"Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", numberFormatterPrecision:"-1", dayNamesShort:"Sun,Mon,Tue,Wed,Thu,Fri,Sat", rounding:"none", currencyFormatterPrecision:"-1"};
            return _loc_1;
        }// end function

    }
}
