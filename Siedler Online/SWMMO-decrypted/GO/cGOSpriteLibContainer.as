package GO
{
    import Enums.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cGOSpriteLibContainer extends cSpriteLibContainer
    {
        public var mAddDepositAmount:int = 0;
        public var mShowMissingResources:Boolean;
        public var mWatchAreaId:int = 0;
        public var mIsWarehouse:Boolean = false;
        public var mFlagEffectSetName_string:String = null;
        public var mUITyp:int = -1;
        public var mConstructionDuration:int = 100;
        public var mBuildInstantCosts:int = 0;
        public var mSmokeEffectSetName_string:String = null;
        public var buildingMovementCosts_vector:Vector.<Vector.<dResource>> = null;
        public var mGfxResourceListNr:int = 0;
        public var buildingUpgradeBonuses_vector:Vector.<cBuffDefinition> = null;
        public var mLootTableId:int = 0;
        public var mEnumGoSubType:int;
        public var mXP:int = 0;
        public var mMaxBuildingLimit:int;
        public var mDamagePercentForDefendingUnits:int = 100;
        public var mEnumSettlerKiTyp:int;
        public var mAddDepositName:String = null;
        public var mGOTyp:int = -1;
        public var mDestructionDuration:int = 50;
        public var mIncreaseMaxResourceLimit:int = 0;
        public var mDepositAnimName_string:String = null;
        public var mUpgradeInstantBonusPercentage:int = 0;
        public var mGlobalSnapping:Number = 0;
        public var mBattleAnimation_string:String = null;
        public var mCostList_vector:Vector.<dResource> = null;
        public var mBlocking_vector:Vector.<cBlockingData>;
        public var mGoGroup:cGOGroup;
        public var mRestrictPlacingToDeposit:String = null;
        public var mHitPoints:int = 500;
        public var mGfxResourceListName_string:String = "";
        public var mXML:cXML;
        public var mEffectDefaultAnimSpeed:Number = 0;
        public var mPlayerLevel:int = 0;
        public var mMaxUnits:int = 0;
        public var mShowInGui:int = 1;
        public var mConstructBuildingWithoutSettler:Boolean = false;
        public var mConstructionAnimSpeed:Number = 1;
        public static const UI_TYPE_CL3_BUILDING:int = 3;
        public static const UI_TYPE_CL2_BUILDING:int = 2;
        public static const GO_TYP_UNDEFINED:int = -1;
        public static const UI_TYPE_CL01_BUILDING:int = 1;
        public static const GO_TYP_BASEBUILDING:int = 1;
        public static const UI_TYPE_UNDEFINED:int = -1;
        public static const UI_TYPE_BASEBUILDING:int = 0;

        public function cGOSpriteLibContainer(param1:cGOGroup, param2:String, param3:Function, param4:int, param5:Boolean, param6:Boolean, param7:int)
        {
            this.mEnumGoSubType = GO_SUBTYPE.DEFAULT;
            this.mBlocking_vector = new Vector.<cBlockingData>;
            this.mMaxBuildingLimit = global.defaultMaximumBuildingCount;
            this.mEnumSettlerKiTyp = SETTLER_KI_TYP.UNSET;
            super(param2, param3, param4, param5, param6, param7);
            this.mGoGroup = param1;
            return;
        }// end function

    }
}
