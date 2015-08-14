package unitTest
{
    import Interface.*;
    import nLib.*;

    public class cUnitTest extends Object
    {
        private static var currentStep:int = 0;
        public static var UNIT_TESTS_ENABLED:Boolean = false;
        private static var currentTest:Object = FPP_MAP_TEST;
        private static const FPP_MAP_TEST:Object = {testName:"FPP-MapTest", mapName:"world/FPP_Map_1_1.xml", steps:100, timeInc:10000, resourceCount:54, Population:607, Wood:899689, RealWood:0, ExoticWood:0, Plank:900177, RealPlank:900000, ExoticPlank:0, BronzeOre:0, Bronze:899876, IronOre:0, Iron:0, GoldOre:0, Gold:0, Alloy:0, Coal:899937, Coin:900000, Steel:0, AlloyedSteel:0, Tool:900063, Attire:0, Stone:900017, Granite:900000, Marble:0, Corn:0, Flour:0, Water:899940, FancyFood:900032, Beer:14, Fish:43, Meat:0, PlainFood:900000, Wool:0, Textiles:0, Clothing:0, Paper:0, Book:0, Wheel:0, Horse:0, Carriage:0, Salpeter:0, Gunpowder:0, BronzeBullet:0, IronBullet:0, SteelBullet:0, BronzePike:61, IronPike:0, AlloyedPike:0, Recruit:0, Militia:0, Soldier:0, EliteSoldier:0, Cavalry:0, Cannoneer:0, Musketeer:0};
        private static var generalInterface:cGeneralInterface;

        public function cUnitTest()
        {
            return;
        }// end function

        public static function init(param1:cGeneralInterface) : void
        {
            gMisc.ConsoleOut("cUnitTest.init(" + param1 + ")");
            param1.SetClientTime(0);
            generalInterface = param1;
            return;
        }// end function

        public static function isInitialized() : Boolean
        {
            if (generalInterface == null)
            {
                return false;
            }
            return true;
        }// end function

        public static function runTests() : void
        {
            if (currentStep >= currentTest.steps)
            {
                return;
            }
            if (generalInterface == null || generalInterface.mServer == null)
            {
                return;
            }
            while (currentStep < currentTest.steps)
            {
                
                if (currentStep % 10 == 0)
                {
                    gMisc.ConsoleOut("Performing step " + currentStep);
                }
                generalInterface.SetClientTime(generalInterface.GetClientTime() + currentTest.timeInc);
                generalInterface.Compute();
                var _loc_4:* = currentStep + 1;
                currentStep = _loc_4;
            }
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            if (_loc_2 != currentTest.resourceCount)
            {
                gMisc.ConsoleOut("We have calculated " + _loc_2 + " resources but we expect " + currentTest.resourceCount + "!");
                _loc_1++;
            }
            gMisc.ConsoleOut("Test \'" + currentTest.testName + "\' was finished with " + _loc_1 + " errors!");
            return;
        }// end function

    }
}
