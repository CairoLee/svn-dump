package 
{
    import Enums.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _SWMMOWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _SWMMOWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[8] = new PropertyWatcher("label1", {propertyChange:true}, [bindings[31]], propertyGetter);
            watchers[38] = new PropertyWatcher("GAMESTATE_ID_LIST_CL2_BUILDINGS", {propertyChange:true}, [bindings[78], bindings[79]], propertyGetter);
            watchers[40] = new PropertyWatcher("height", {heightChanged:true}, [bindings[79]], null);
            watchers[39] = new PropertyWatcher("width", {widthChanged:true}, [bindings[78]], null);
            watchers[4] = new PropertyWatcher("mDepositGroupData", {propertyChange:true}, [bindings[14]], propertyGetter);
            watchers[13] = new PropertyWatcher("GAMESTATE_ID_ACTIONBAR", {propertyChange:true}, [bindings[51], bindings[70], bindings[71], bindings[83], bindings[82], bindings[78], bindings[79], bindings[74], bindings[75]], propertyGetter);
            watchers[15] = new PropertyWatcher("height", {heightChanged:true}, [bindings[51]], null);
            watchers[21] = new FunctionReturnWatcher("getAnchorX", target, function () : Array
            {
                return [target.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar01];
            }// end function
            , {enterFrame:true}, [bindings[70]], null);
            watchers[36] = new FunctionReturnWatcher("getAnchorX", target, function () : Array
            {
                return [null.actionBarLeft.btnActionBar03];
            }// end function
            , {enterFrame:true}, [bindings[78]], null);
            watchers[43] = new FunctionReturnWatcher("getAnchorX", target, function () : Array
            {
                return [target.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar04];
            }// end function
            , {enterFrame:true}, [bindings[82]], null);
            watchers[29] = new FunctionReturnWatcher("getAnchorX", target, function () : Array
            {
                return [target.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar02];
            }// end function
            , {enterFrame:true}, [bindings[74]], null);
            watchers[22] = new PropertyWatcher("actionBarLeft", {propertyChange:true}, [bindings[70], bindings[82], bindings[78], bindings[74]], null);
            watchers[23] = new PropertyWatcher("btnActionBar01", {propertyChange:true}, [bindings[70]], null);
            watchers[30] = new PropertyWatcher("btnActionBar02", {propertyChange:true}, [bindings[74]], null);
            watchers[37] = new PropertyWatcher("btnActionBar03", {propertyChange:true}, [bindings[78]], null);
            watchers[44] = new PropertyWatcher("btnActionBar04", {propertyChange:true}, [bindings[82]], null);
            watchers[14] = new PropertyWatcher("y", {yChanged:true}, [bindings[51], bindings[71], bindings[83], bindings[79], bindings[75]], null);
            watchers[1] = new PropertyWatcher("mTileListDataProviderGO", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[11] = new PropertyWatcher("GAMESTATE_ID_AVATAR", {propertyChange:true}, [bindings[47]], propertyGetter);
            watchers[12] = new PropertyWatcher("width", {widthChanged:true}, [bindings[47]], null);
            watchers[5] = new PropertyWatcher("mAssignUnitsData", {propertyChange:true}, [bindings[17]], propertyGetter);
            watchers[2] = new PropertyWatcher("menuBarCollection", {propertyChange:true}, [bindings[4]], propertyGetter);
            watchers[7] = new PropertyWatcher("mSectorListData", {propertyChange:true}, [bindings[20]], propertyGetter);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[73]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "CL2Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[73]], null);
            watchers[18] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[69]], null);
            watchers[19] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "CL01Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[69]], null);
            watchers[3] = new PropertyWatcher("mTileListDataProviderSetMode", {propertyChange:true}, [bindings[9]], propertyGetter);
            watchers[9] = new PropertyWatcher("GAMESTATE_ID_FRIENDS_LIST", {propertyChange:true}, [bindings[49], bindings[41], bindings[90]], propertyGetter);
            watchers[10] = new PropertyWatcher("height", {heightChanged:true}, [bindings[49], bindings[41], bindings[90]], null);
            watchers[0] = new PropertyWatcher("myCanvas", {propertyChange:true}, [bindings[0], bindings[2], bindings[3], bindings[5], bindings[6], bindings[7], bindings[8], bindings[10], bindings[11], bindings[12], bindings[13], bindings[15], bindings[16], bindings[19], bindings[21], bindings[23], bindings[22], bindings[25], bindings[24], bindings[27], bindings[26], bindings[29], bindings[28], bindings[30], bindings[34], bindings[35], bindings[32], bindings[33], bindings[38], bindings[39], bindings[36], bindings[37], bindings[42], bindings[43], bindings[40], bindings[46], bindings[44], bindings[45], bindings[50], bindings[48], bindings[55], bindings[54], bindings[52], bindings[59], bindings[58], bindings[57], bindings[56], bindings[63], bindings[62], bindings[61], bindings[60], bindings[68], bindings[64], bindings[65], bindings[66], bindings[67], bindings[76], bindings[72], bindings[85], bindings[84], bindings[87], bindings[86], bindings[80], bindings[93], bindings[92], bindings[95], bindings[94], bindings[89], bindings[91], bindings[102], bindings[103], bindings[100], bindings[101], bindings[98], bindings[99], bindings[96], bindings[97], bindings[110], bindings[108], bindings[106], bindings[107], bindings[104], bindings[105]], propertyGetter);
            watchers[31] = new PropertyWatcher("GAMESTATE_ID_LIST_CL01_BUILDINGS", {propertyChange:true}, [bindings[74], bindings[75]], propertyGetter);
            watchers[33] = new PropertyWatcher("height", {heightChanged:true}, [bindings[75]], null);
            watchers[32] = new PropertyWatcher("width", {widthChanged:true}, [bindings[74]], null);
            watchers[24] = new PropertyWatcher("GAMESTATE_ID_LIST_BASE_BUILDINGS", {propertyChange:true}, [bindings[70], bindings[71]], propertyGetter);
            watchers[26] = new PropertyWatcher("height", {heightChanged:true}, [bindings[71]], null);
            watchers[25] = new PropertyWatcher("width", {widthChanged:true}, [bindings[70]], null);
            watchers[45] = new PropertyWatcher("GAMESTATE_ID_LIST_CL3_BUILDINGS", {propertyChange:true}, [bindings[83], bindings[82]], propertyGetter);
            watchers[47] = new PropertyWatcher("height", {heightChanged:true}, [bindings[83]], null);
            watchers[46] = new PropertyWatcher("width", {widthChanged:true}, [bindings[82]], null);
            watchers[34] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[77]], null);
            watchers[35] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "CL3Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[77]], null);
            watchers[6] = new PropertyWatcher("mUnitListData", {propertyChange:true}, [bindings[18]], propertyGetter);
            watchers[50] = new PropertyWatcher("mResourceProductionWindowDataGridDataProvider", {propertyChange:true}, [bindings[109]], propertyGetter);
            watchers[41] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[81]], null);
            watchers[42] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "CLSBuildings"];
            }// end function
            , {languageChanged:true}, [bindings[81]], null);
            watchers[48] = new StaticPropertyWatcher("application", null, [bindings[88]], null);
            watchers[49] = new PropertyWatcher("height", null, [bindings[88]], null);
            watchers[16] = new PropertyWatcher("GAMESTATE_ID_BUILD_QUEUE", {propertyChange:true}, [bindings[53]], propertyGetter);
            watchers[17] = new PropertyWatcher("height", {heightChanged:true}, [bindings[53]], null);
            watchers[8].updateParent(target);
            watchers[38].updateParent(target);
            watchers[38].addChild(watchers[40]);
            watchers[38].addChild(watchers[39]);
            watchers[4].updateParent(target);
            watchers[13].updateParent(target);
            watchers[13].addChild(watchers[15]);
            watchers[21].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[21]);
            watchers[36].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[36]);
            watchers[43].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[43]);
            watchers[29].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[29]);
            watchers[13].addChild(watchers[22]);
            watchers[22].addChild(watchers[23]);
            watchers[22].addChild(watchers[30]);
            watchers[22].addChild(watchers[37]);
            watchers[22].addChild(watchers[44]);
            watchers[13].addChild(watchers[14]);
            watchers[1].updateParent(target);
            watchers[11].updateParent(target);
            watchers[11].addChild(watchers[12]);
            watchers[5].updateParent(target);
            watchers[2].updateParent(target);
            watchers[7].updateParent(target);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[18].updateParent(cLocaManager);
            watchers[19].parentWatcher = watchers[18];
            watchers[18].addChild(watchers[19]);
            watchers[3].updateParent(target);
            watchers[9].updateParent(target);
            watchers[9].addChild(watchers[10]);
            watchers[0].updateParent(target);
            watchers[31].updateParent(target);
            watchers[31].addChild(watchers[33]);
            watchers[31].addChild(watchers[32]);
            watchers[24].updateParent(target);
            watchers[24].addChild(watchers[26]);
            watchers[24].addChild(watchers[25]);
            watchers[45].updateParent(target);
            watchers[45].addChild(watchers[47]);
            watchers[45].addChild(watchers[46]);
            watchers[34].updateParent(cLocaManager);
            watchers[35].parentWatcher = watchers[34];
            watchers[34].addChild(watchers[35]);
            watchers[6].updateParent(target);
            watchers[50].updateParent(target);
            watchers[41].updateParent(cLocaManager);
            watchers[42].parentWatcher = watchers[41];
            watchers[41].addChild(watchers[42]);
            watchers[48].updateParent(Application);
            watchers[48].addChild(watchers[49]);
            watchers[16].updateParent(target);
            watchers[16].addChild(watchers[17]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            SWMMO.watcherSetupUtil = new _SWMMOWatcherSetupUtil;
            return;
        }// end function

    }
}
