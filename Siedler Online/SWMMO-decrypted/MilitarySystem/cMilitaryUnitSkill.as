package MilitarySystem
{
    import Enums.*;

    public class cMilitaryUnitSkill extends Object
    {
        private var mType:int;
        private var mData:int;

        public function cMilitaryUnitSkill(param1:int, param2:int)
        {
            this.mType = param1;
            this.mData = param2;
            return;
        }// end function

        public function GetType() : int
        {
            return this.mType;
        }// end function

        public function toString() : String
        {
            return "<Skill " + MILLITARY_UNIT_SKILLS.toString(this.mType) + ", data=" + this.mData + ">";
        }// end function

        public function GetData() : int
        {
            return this.mData;
        }// end function

    }
}
