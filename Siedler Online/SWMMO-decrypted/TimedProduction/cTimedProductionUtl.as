package TimedProduction
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import MilitarySystem.*;
    import nLib.*;

    public class cTimedProductionUtl extends Object
    {

        public function cTimedProductionUtl()
        {
            return;
        }// end function

        public static function CreateProductionOrderFromVO(param1:dStartTimedProductionVO) : iProductionOrder
        {
            var _loc_2:iProductionOrder = null;
            switch(param1.productionType)
            {
                case TIMED_PRODUCTION_TYPE.BUFF:
                {
                    _loc_2 = new cBuffProductionOrder(param1.type_string, param1.amount);
                    _loc_2.AddUniqueIds(param1.uniqueIds);
                    return _loc_2;
                }
                case TIMED_PRODUCTION_TYPE.MILITARY_UNIT:
                {
                    _loc_2 = new cMilitaryUnitProductionOrder(param1.type_string, param1.amount);
                    _loc_2.AddUniqueIds(param1.uniqueIds);
                    return _loc_2;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret productionType " + param1.productionType);
                    break;
                    break;
                }
            }
            return null;
        }// end function

    }
}
