package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_BuildingInfoPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_BuildingInfoPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ProductionStatus"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "BuildingIntegrity"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "NotPossible"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[25] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[15]], null);
            watchers[26] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Repair"];
            }// end function
            , {languageChanged:true}, [bindings[15]], null);
            watchers[48] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[28]], null);
            watchers[49] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Workyard"];
            }// end function
            , {languageChanged:true}, [bindings[28]], null);
            watchers[1] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[2] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Upgrade"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[46] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[27]], null);
            watchers[47] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Workyard"];
            }// end function
            , {languageChanged:true}, [bindings[27]], null);
            watchers[43] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[25]], null);
            watchers[44] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "DetailsProductionTime"];
            }// end function
            , {languageChanged:true}, [bindings[25]], null);
            watchers[41] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[24]], null);
            watchers[42] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "DetailsDeposit"];
            }// end function
            , {languageChanged:true}, [bindings[24]], null);
            watchers[38] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[22]], null);
            watchers[39] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Workyard"];
            }// end function
            , {languageChanged:true}, [bindings[22]], null);
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Buff"];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[18] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[19] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ComingSoon"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[4] = new PropertyWatcher("upgradeTime", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[5] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[2]], null);
            watchers[10] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[11] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ComingSoon"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Buff"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[51] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[30]], null);
            watchers[52] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.BUILDINGS, "Warehouse"];
            }// end function
            , {languageChanged:true}, [bindings[30]], null);
            watchers[34] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[20]], null);
            watchers[35] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.BUILDINGS, "Warehouse"];
            }// end function
            , {languageChanged:true}, [bindings[20]], null);
            watchers[54] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[32]], null);
            watchers[55] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "DetailsTotalTime"];
            }// end function
            , {languageChanged:true}, [bindings[32]], null);
            watchers[56] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[33]], null);
            watchers[57] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ProductionDetailsCycle"];
            }// end function
            , {languageChanged:true}, [bindings[33]], null);
            watchers[30] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[18]], null);
            watchers[31] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Worker"];
            }// end function
            , {languageChanged:true}, [bindings[18]], null);
            watchers[32] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[19]], null);
            watchers[33] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "ProductionDetailsTime"];
            }// end function
            , {languageChanged:true}, [bindings[19]], null);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[25].updateParent(cLocaManager);
            watchers[26].parentWatcher = watchers[25];
            watchers[25].addChild(watchers[26]);
            watchers[48].updateParent(cLocaManager);
            watchers[49].parentWatcher = watchers[48];
            watchers[48].addChild(watchers[49]);
            watchers[1].updateParent(cLocaManager);
            watchers[2].parentWatcher = watchers[1];
            watchers[1].addChild(watchers[2]);
            watchers[46].updateParent(cLocaManager);
            watchers[47].parentWatcher = watchers[46];
            watchers[46].addChild(watchers[47]);
            watchers[43].updateParent(cLocaManager);
            watchers[44].parentWatcher = watchers[43];
            watchers[43].addChild(watchers[44]);
            watchers[41].updateParent(cLocaManager);
            watchers[42].parentWatcher = watchers[41];
            watchers[41].addChild(watchers[42]);
            watchers[38].updateParent(cLocaManager);
            watchers[39].parentWatcher = watchers[38];
            watchers[38].addChild(watchers[39]);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[18].updateParent(cLocaManager);
            watchers[19].parentWatcher = watchers[18];
            watchers[18].addChild(watchers[19]);
            watchers[4].updateParent(target);
            watchers[4].addChild(watchers[5]);
            watchers[10].updateParent(cLocaManager);
            watchers[11].parentWatcher = watchers[10];
            watchers[10].addChild(watchers[11]);
            watchers[13].updateParent(cLocaManager);
            watchers[14].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[14]);
            watchers[51].updateParent(cLocaManager);
            watchers[52].parentWatcher = watchers[51];
            watchers[51].addChild(watchers[52]);
            watchers[34].updateParent(cLocaManager);
            watchers[35].parentWatcher = watchers[34];
            watchers[34].addChild(watchers[35]);
            watchers[54].updateParent(cLocaManager);
            watchers[55].parentWatcher = watchers[54];
            watchers[54].addChild(watchers[55]);
            watchers[56].updateParent(cLocaManager);
            watchers[57].parentWatcher = watchers[56];
            watchers[56].addChild(watchers[57]);
            watchers[30].updateParent(cLocaManager);
            watchers[31].parentWatcher = watchers[30];
            watchers[30].addChild(watchers[31]);
            watchers[32].updateParent(cLocaManager);
            watchers[33].parentWatcher = watchers[32];
            watchers[32].addChild(watchers[33]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            BuildingInfoPanel.watcherSetupUtil = new _GUI_Components_BuildingInfoPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
