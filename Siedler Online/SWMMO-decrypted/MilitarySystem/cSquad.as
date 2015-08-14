package MilitarySystem
{
    import Communication.VO.*;
    import Enums.*;
    import flash.events.*;
    import mx.events.*;
    import nLib.*;

    public class cSquad extends dSquadVO implements IEventDispatcher
    {
        private var _2088099370mHealthBar:Number = 1;
        private var casualties:int;
        public var dirtyIndicator:int;
        private var _bindingEventDispatcher:EventDispatcher;

        public function cSquad(param1:String, param2:int, param3:int, param4:Boolean)
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            init(param1, param2, param3);
            if (param4)
            {
                this.dirtyIndicator = this.dirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function GetHealthBar() : Number
        {
            return this.mHealthBar;
        }// end function

        public function Heal(param1:int) : void
        {
            currentHitPoints = Math.min(currentHitPoints + param1, militaryUnitDescription.GetHitPoints());
            this.mHealthBar = Math.min(currentHitPoints / militaryUnitDescription.GetHitPoints(), 1);
            this.dirtyIndicator = this.dirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        private function AddCasualty() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.casualties + 1;
            _loc_1.casualties = _loc_2;
            if (this.GetLivingUnits() > 0)
            {
                currentHitPoints = GetUnitDescription().GetHitPoints();
            }
            this.dirtyIndicator = this.dirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        private function set mHealthBar(param1:Number) : void
        {
            var _loc_2:* = this._2088099370mHealthBar;
            if (_loc_2 !== param1)
            {
                this._2088099370mHealthBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mHealthBar", _loc_2, param1));
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function GetBuildingDamage() : int
        {
            var _loc_1:* = militaryUnitDescription.GetHitDamage();
            var _loc_2:* = militaryUnitDescription.GetSkill(MILLITARY_UNIT_SKILLS.BONUS_DAMAGE_BUILDINGS);
            if (_loc_2 != null)
            {
                _loc_1 = _loc_1 + _loc_1 * _loc_2.GetData() / 100;
            }
            return _loc_1;
        }// end function

        public function applyCasualties() : Boolean
        {
            amount = amount - this.casualties;
            this.casualties = 0;
            return amount <= 0;
        }// end function

        public function GetCasualties() : int
        {
            return this.casualties;
        }// end function

        public function GetUnitDamage() : int
        {
            var _loc_1:int = 0;
            var _loc_2:* = gMisc.GetRandomMinMaxInt(1, 100);
            if (_loc_2 <= militaryUnitDescription.GetHitPercentage())
            {
                _loc_1 = militaryUnitDescription.GetHitDamage();
            }
            else
            {
                _loc_1 = militaryUnitDescription.GetMissDamage();
            }
            var _loc_3:* = militaryUnitDescription.GetSkill(MILLITARY_UNIT_SKILLS.BONUS_DAMAGE_UNITS);
            if (_loc_3 != null)
            {
                _loc_1 = _loc_1 + _loc_1 * _loc_3.GetData() / 100;
            }
            return _loc_1;
        }// end function

        private function get mHealthBar() : Number
        {
            return this._2088099370mHealthBar;
        }// end function

        public function toString() : String
        {
            return "<Squad type=\'" + GetType_string() + "\' amount=\'" + GetAmount() + "\' currentHitPoints=\'" + GetCurrentHitPoints() + "\' />";
        }// end function

        public function AddUnits(param1:int, param2:Boolean) : void
        {
            amount = amount + param1;
            if (param2)
            {
                this.dirtyIndicator = this.dirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            return;
        }// end function

        public function GetLivingUnits() : int
        {
            return amount - this.casualties;
        }// end function

        public function GetTotalHealth() : int
        {
            if (this.GetLivingUnits() == 0)
            {
                return 0;
            }
            return (this.GetLivingUnits() - 1) * GetUnitDescription().GetHitPoints() + GetCurrentHitPoints();
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function CreateSquadVO() : dSquadVO
        {
            return new dSquadVO().init(GetType_string(), GetAmount(), GetCurrentHitPoints());
        }// end function

        public function SetAmount(param1:int) : void
        {
            amount = param1;
            this.dirtyIndicator = this.dirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetSortIndex() : int
        {
            return militaryUnitDescription.GetPlayerLevel();
        }// end function

    }
}
