package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_SpecialistPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_SpecialistPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[99] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[62]], null);
            watchers[100] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[62]], null);
            watchers[97] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[61]], null);
            watchers[98] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "CostsDuration"];
            }// end function
            , {languageChanged:true}, [bindings[61]], null);
            watchers[29] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[30] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Commands"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[94] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[59]], null);
            watchers[95] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindDepositGranite"];
            }// end function
            , {languageChanged:true}, [bindings[59]], null);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[91] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[57]], null);
            watchers[92] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindDepositCoal"];
            }// end function
            , {languageChanged:true}, [bindings[57]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[13]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "CurrentMission"];
            }// end function
            , {languageChanged:true}, [bindings[13]], null);
            watchers[101] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[63]], null);
            watchers[102] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[63]], null);
            watchers[23] = new PropertyWatcher("progressProxy", {propertyChange:true}, [bindings[14]], propertyGetter);
            watchers[24] = new PropertyWatcher("progress", {propertyChange:true}, [bindings[14]], null);
            watchers[25] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[15]], null);
            watchers[26] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[15]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[62] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[38]], null);
            watchers[63] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "FindTreasureMedium"];
            }// end function
            , {languageChanged:true}, [bindings[38]], null);
            watchers[65] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[40]], null);
            watchers[66] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindTreasureEvenLonger"];
            }// end function
            , {languageChanged:true}, [bindings[40]], null);
            watchers[68] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[42]], null);
            watchers[69] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Commands"];
            }// end function
            , {languageChanged:true}, [bindings[42]], null);
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Retreat"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Retreat"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Transfer"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[50] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[30]], null);
            watchers[51] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindAdventureLong"];
            }// end function
            , {languageChanged:true}, [bindings[30]], null);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Transfer"];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[53] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[32]], null);
            watchers[54] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindAdventureMedium"];
            }// end function
            , {languageChanged:true}, [bindings[32]], null);
            watchers[56] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[34]], null);
            watchers[57] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindTreasureShort"];
            }// end function
            , {languageChanged:true}, [bindings[34]], null);
            watchers[59] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[36]], null);
            watchers[60] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindTreasureLong"];
            }// end function
            , {languageChanged:true}, [bindings[36]], null);
            watchers[76] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[47]], null);
            watchers[77] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindDepositGold"];
            }// end function
            , {languageChanged:true}, [bindings[47]], null);
            watchers[79] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[49]], null);
            watchers[80] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "FindDepositAlloy"];
            }// end function
            , {languageChanged:true}, [bindings[49]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[73] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[45]], null);
            watchers[74] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindDepositMarble"];
            }// end function
            , {languageChanged:true}, [bindings[45]], null);
            watchers[70] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[43]], null);
            watchers[71] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "FindDepositStone"];
            }// end function
            , {languageChanged:true}, [bindings[43]], null);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Attack"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Attack"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Commands"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[47] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[28]], null);
            watchers[48] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindAdventureShort"];
            }// end function
            , {languageChanged:true}, [bindings[28]], null);
            watchers[44] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[26]], null);
            watchers[45] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindWildZone"];
            }// end function
            , {languageChanged:true}, [bindings[26]], null);
            watchers[42] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[25]], null);
            watchers[43] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "FindAdventure"];
            }// end function
            , {languageChanged:true}, [bindings[25]], null);
            watchers[85] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[53]], null);
            watchers[86] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindDepositBronze"];
            }// end function
            , {languageChanged:true}, [bindings[53]], null);
            watchers[88] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[55]], null);
            watchers[89] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindDepositIron"];
            }// end function
            , {languageChanged:true}, [bindings[55]], null);
            watchers[39] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[23]], null);
            watchers[40] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindAdventure"];
            }// end function
            , {languageChanged:true}, [bindings[23]], null);
            watchers[82] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[51]], null);
            watchers[83] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "FindDepositSalpeter"];
            }// end function
            , {languageChanged:true}, [bindings[51]], null);
            watchers[34] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[20]], null);
            watchers[35] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "FindTreasure"];
            }// end function
            , {languageChanged:true}, [bindings[20]], null);
            watchers[37] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[22]], null);
            watchers[38] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "FindTreasure"];
            }// end function
            , {languageChanged:true}, [bindings[22]], null);
            watchers[31] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[18]], null);
            watchers[32] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ExploreSector"];
            }// end function
            , {languageChanged:true}, [bindings[18]], null);
            watchers[2] = new PropertyWatcher("confirmFooter", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[99].updateParent(cLocaManager);
            watchers[100].parentWatcher = watchers[99];
            watchers[99].addChild(watchers[100]);
            watchers[97].updateParent(cLocaManager);
            watchers[98].parentWatcher = watchers[97];
            watchers[97].addChild(watchers[98]);
            watchers[29].updateParent(cLocaManager);
            watchers[30].parentWatcher = watchers[29];
            watchers[29].addChild(watchers[30]);
            watchers[94].updateParent(cLocaManager);
            watchers[95].parentWatcher = watchers[94];
            watchers[94].addChild(watchers[95]);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[91].updateParent(cLocaManager);
            watchers[92].parentWatcher = watchers[91];
            watchers[91].addChild(watchers[92]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[101].updateParent(cLocaManager);
            watchers[102].parentWatcher = watchers[101];
            watchers[101].addChild(watchers[102]);
            watchers[23].updateParent(target);
            watchers[23].addChild(watchers[24]);
            watchers[25].updateParent(cLocaManager);
            watchers[26].parentWatcher = watchers[25];
            watchers[25].addChild(watchers[26]);
            watchers[0].updateParent(target);
            watchers[62].updateParent(cLocaManager);
            watchers[63].parentWatcher = watchers[62];
            watchers[62].addChild(watchers[63]);
            watchers[65].updateParent(cLocaManager);
            watchers[66].parentWatcher = watchers[65];
            watchers[65].addChild(watchers[66]);
            watchers[68].updateParent(cLocaManager);
            watchers[69].parentWatcher = watchers[68];
            watchers[68].addChild(watchers[69]);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[11].updateParent(cLocaManager);
            watchers[12].parentWatcher = watchers[11];
            watchers[11].addChild(watchers[12]);
            watchers[50].updateParent(cLocaManager);
            watchers[51].parentWatcher = watchers[50];
            watchers[50].addChild(watchers[51]);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            watchers[53].updateParent(cLocaManager);
            watchers[54].parentWatcher = watchers[53];
            watchers[53].addChild(watchers[54]);
            watchers[56].updateParent(cLocaManager);
            watchers[57].parentWatcher = watchers[56];
            watchers[56].addChild(watchers[57]);
            watchers[59].updateParent(cLocaManager);
            watchers[60].parentWatcher = watchers[59];
            watchers[59].addChild(watchers[60]);
            watchers[76].updateParent(cLocaManager);
            watchers[77].parentWatcher = watchers[76];
            watchers[76].addChild(watchers[77]);
            watchers[79].updateParent(cLocaManager);
            watchers[80].parentWatcher = watchers[79];
            watchers[79].addChild(watchers[80]);
            watchers[1].updateParent(target);
            watchers[73].updateParent(cLocaManager);
            watchers[74].parentWatcher = watchers[73];
            watchers[73].addChild(watchers[74]);
            watchers[70].updateParent(cLocaManager);
            watchers[71].parentWatcher = watchers[70];
            watchers[70].addChild(watchers[71]);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[47].updateParent(cLocaManager);
            watchers[48].parentWatcher = watchers[47];
            watchers[47].addChild(watchers[48]);
            watchers[44].updateParent(cLocaManager);
            watchers[45].parentWatcher = watchers[44];
            watchers[44].addChild(watchers[45]);
            watchers[42].updateParent(cLocaManager);
            watchers[43].parentWatcher = watchers[42];
            watchers[42].addChild(watchers[43]);
            watchers[85].updateParent(cLocaManager);
            watchers[86].parentWatcher = watchers[85];
            watchers[85].addChild(watchers[86]);
            watchers[88].updateParent(cLocaManager);
            watchers[89].parentWatcher = watchers[88];
            watchers[88].addChild(watchers[89]);
            watchers[39].updateParent(cLocaManager);
            watchers[40].parentWatcher = watchers[39];
            watchers[39].addChild(watchers[40]);
            watchers[82].updateParent(cLocaManager);
            watchers[83].parentWatcher = watchers[82];
            watchers[82].addChild(watchers[83]);
            watchers[34].updateParent(cLocaManager);
            watchers[35].parentWatcher = watchers[34];
            watchers[34].addChild(watchers[35]);
            watchers[37].updateParent(cLocaManager);
            watchers[38].parentWatcher = watchers[37];
            watchers[37].addChild(watchers[38]);
            watchers[31].updateParent(cLocaManager);
            watchers[32].parentWatcher = watchers[31];
            watchers[31].addChild(watchers[32]);
            watchers[2].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            SpecialistPanel.watcherSetupUtil = new _GUI_Components_SpecialistPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
