package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_GuildWindowWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_GuildWindowWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[49] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[26]], null);
            watchers[50] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildRank"];
            }// end function
            , {languageChanged:true}, [bindings[26]], null);
            watchers[29] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[30] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildMember"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[14]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildLog"];
            }// end function
            , {languageChanged:true}, [bindings[14]], null);
            watchers[73] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[42]], null);
            watchers[74] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildEditDetails"];
            }// end function
            , {languageChanged:true}, [bindings[42]], null);
            watchers[71] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[41]], null);
            watchers[72] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Discard"];
            }// end function
            , {languageChanged:true}, [bindings[41]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildInfo"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildFound"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildMy"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[5] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildPlayerCount"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[25] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[13]], null);
            watchers[26] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildDescription"];
            }// end function
            , {languageChanged:true}, [bindings[13]], null);
            watchers[23] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[24] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildLeader"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildTag"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[47] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[25]], null);
            watchers[48] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildRank"];
            }// end function
            , {languageChanged:true}, [bindings[25]], null);
            watchers[0] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[1] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Guild"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[45] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[24]], null);
            watchers[46] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildEditRanks"];
            }// end function
            , {languageChanged:true}, [bindings[24]], null);
            watchers[69] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[40]], null);
            watchers[70] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Save"];
            }// end function
            , {languageChanged:true}, [bindings[40]], null);
            watchers[43] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[23]], null);
            watchers[44] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildKick"];
            }// end function
            , {languageChanged:true}, [bindings[23]], null);
            watchers[41] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[22]], null);
            watchers[42] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildNote"];
            }// end function
            , {languageChanged:true}, [bindings[22]], null);
            watchers[39] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[21]], null);
            watchers[40] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildOfficerNote"];
            }// end function
            , {languageChanged:true}, [bindings[21]], null);
            watchers[17] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[18] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildIncreaseSize"];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildList"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildInvite"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildMail"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[15] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[16] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildLeave"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[51] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[27]], null);
            watchers[52] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildRank"];
            }// end function
            , {languageChanged:true}, [bindings[27]], null);
            watchers[53] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[28]], null);
            watchers[54] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildRank"];
            }// end function
            , {languageChanged:true}, [bindings[28]], null);
            watchers[35] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[19]], null);
            watchers[36] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildMemberDetails"];
            }// end function
            , {languageChanged:true}, [bindings[19]], null);
            watchers[55] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[29]], null);
            watchers[56] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Save"];
            }// end function
            , {languageChanged:true}, [bindings[29]], null);
            watchers[37] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[20]], null);
            watchers[38] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildCurrentAdventures"];
            }// end function
            , {languageChanged:true}, [bindings[20]], null);
            watchers[57] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[30]], null);
            watchers[58] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Discard"];
            }// end function
            , {languageChanged:true}, [bindings[30]], null);
            watchers[31] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[32] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "GuildLevel"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[59] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[31]], null);
            watchers[60] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "GuildEdit"];
            }// end function
            , {languageChanged:true}, [bindings[31]], null);
            watchers[33] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[18]], null);
            watchers[34] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "GuildRank"];
            }// end function
            , {languageChanged:true}, [bindings[18]], null);
            watchers[49].updateParent(cLocaManager);
            watchers[50].parentWatcher = watchers[49];
            watchers[49].addChild(watchers[50]);
            watchers[29].updateParent(cLocaManager);
            watchers[30].parentWatcher = watchers[29];
            watchers[29].addChild(watchers[30]);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[73].updateParent(cLocaManager);
            watchers[74].parentWatcher = watchers[73];
            watchers[73].addChild(watchers[74]);
            watchers[71].updateParent(cLocaManager);
            watchers[72].parentWatcher = watchers[71];
            watchers[71].addChild(watchers[72]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[7].updateParent(cLocaManager);
            watchers[8].parentWatcher = watchers[7];
            watchers[7].addChild(watchers[8]);
            watchers[5].updateParent(cLocaManager);
            watchers[6].parentWatcher = watchers[5];
            watchers[5].addChild(watchers[6]);
            watchers[25].updateParent(cLocaManager);
            watchers[26].parentWatcher = watchers[25];
            watchers[25].addChild(watchers[26]);
            watchers[23].updateParent(cLocaManager);
            watchers[24].parentWatcher = watchers[23];
            watchers[23].addChild(watchers[24]);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[47].updateParent(cLocaManager);
            watchers[48].parentWatcher = watchers[47];
            watchers[47].addChild(watchers[48]);
            watchers[0].updateParent(cLocaManager);
            watchers[1].parentWatcher = watchers[0];
            watchers[0].addChild(watchers[1]);
            watchers[45].updateParent(cLocaManager);
            watchers[46].parentWatcher = watchers[45];
            watchers[45].addChild(watchers[46]);
            watchers[69].updateParent(cLocaManager);
            watchers[70].parentWatcher = watchers[69];
            watchers[69].addChild(watchers[70]);
            watchers[43].updateParent(cLocaManager);
            watchers[44].parentWatcher = watchers[43];
            watchers[43].addChild(watchers[44]);
            watchers[41].updateParent(cLocaManager);
            watchers[42].parentWatcher = watchers[41];
            watchers[41].addChild(watchers[42]);
            watchers[39].updateParent(cLocaManager);
            watchers[40].parentWatcher = watchers[39];
            watchers[39].addChild(watchers[40]);
            watchers[17].updateParent(cLocaManager);
            watchers[18].parentWatcher = watchers[17];
            watchers[17].addChild(watchers[18]);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[11].updateParent(cLocaManager);
            watchers[12].parentWatcher = watchers[11];
            watchers[11].addChild(watchers[12]);
            watchers[13].updateParent(cLocaManager);
            watchers[14].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[14]);
            watchers[15].updateParent(cLocaManager);
            watchers[16].parentWatcher = watchers[15];
            watchers[15].addChild(watchers[16]);
            watchers[51].updateParent(cLocaManager);
            watchers[52].parentWatcher = watchers[51];
            watchers[51].addChild(watchers[52]);
            watchers[53].updateParent(cLocaManager);
            watchers[54].parentWatcher = watchers[53];
            watchers[53].addChild(watchers[54]);
            watchers[35].updateParent(cLocaManager);
            watchers[36].parentWatcher = watchers[35];
            watchers[35].addChild(watchers[36]);
            watchers[55].updateParent(cLocaManager);
            watchers[56].parentWatcher = watchers[55];
            watchers[55].addChild(watchers[56]);
            watchers[37].updateParent(cLocaManager);
            watchers[38].parentWatcher = watchers[37];
            watchers[37].addChild(watchers[38]);
            watchers[57].updateParent(cLocaManager);
            watchers[58].parentWatcher = watchers[57];
            watchers[57].addChild(watchers[58]);
            watchers[31].updateParent(cLocaManager);
            watchers[32].parentWatcher = watchers[31];
            watchers[31].addChild(watchers[32]);
            watchers[59].updateParent(cLocaManager);
            watchers[60].parentWatcher = watchers[59];
            watchers[59].addChild(watchers[60]);
            watchers[33].updateParent(cLocaManager);
            watchers[34].parentWatcher = watchers[33];
            watchers[33].addChild(watchers[34]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            GuildWindow.watcherSetupUtil = new _GUI_Components_GuildWindowWatcherSetupUtil;
            return;
        }// end function

    }
}
