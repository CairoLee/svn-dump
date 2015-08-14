package Communication.VO.UpdateVO
{
    import Communication.VO.*;

    public class dTravellingSpecialistArivalVO extends Object
    {
        public var specialistVO:dSpecialistVO;

        public function dTravellingSpecialistArivalVO()
        {
            return;
        }// end function

        public function Init(param1:dSpecialistVO) : dTravellingSpecialistArivalVO
        {
            this.specialistVO = param1;
            return this;
        }// end function

    }
}
