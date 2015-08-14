/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry;

import flex.messaging.io.amf.ASObject;
import siedleronlineproxy.PropertyManager;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.debug.DebugLog.LogLevel;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.mappings.ResourceCreationVO;
import siedleronlineproxy.mappings.ServerAction;
import siedleronlineproxy.debug.UnknownClassPrinter;
import siedleronlineproxy.registry.building.GenericBuilding;

/**
 *
 * @author nspecht
 */
public class ServerActionHandler {

    public static void handle(ServerAction action) {
        DepositVO deposit = DepositRegistry.getInstance().getDepositByPosition(action.grid);
        if (deposit != null) { //Hier wird wohl ein Gebäude auf einem Deposit gebaut
            ServerActionHandler.rebuildOnDeposit(action, deposit);
        } else if (action.type==0 && action.data == null) {
            BuildingRegistry.getInstance().pausePosition(action.grid);
        } else if (action.type==1 && action.data == null) { 
            BuildingRegistry.getInstance().unpausePosition(action.grid);
        } else if (action.type==2 && action.data instanceof String) {
            //fordere Gebäudeinformationen
        } else if (action.type==3 && action.data == null) {
            //entferne oberstes Gebäude aus Bauschlange
        } else {
            //TODO: andere Aktionen festlegen
            switch (action.type) {
                case  14 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.SAWMILL);         break;
                case  43 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.FARMFIELD);       break;
                case  44 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.FISHER);          break;
                case  45 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.FORESTER);        break;
                case  55 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.MASON);           break;
                case  57 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.NOBLERESIDENCE);  break;
                case  64 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.SIMPLERESIDENCE); break;
                case  71 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.WAREHOUSE);       break;    
                case  72 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.WELL);            break;
                case  73 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.WOODCUTTER);      break;
                case 176 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.WELL_03);         break;
                case 247 : ServerActionHandler.registerNewBuilding(action, BuildingTypes.FARMFIELD_03);    break;
                default:
                    DebugLog.put(ServerActionHandler.class, "Unknown ServerAction:"
                            + " Type=" + action.type
                            + " Grid=" + action.grid
                            + " EndGrid=" + action.endGrid
                            + " Data=" + (action.data == null ? "null" : action.data.getClass().getCanonicalName()),
                            LogLevel.ERROR);
                    if (action.data != null && action.data instanceof ASObject && new Boolean(PropertyManager.getInstance().get("PrintMissingTypes", "false"))) {
                        DebugLog.put(ServerActionHandler.class,
                                UnknownClassPrinter.printASObject((ASObject)action.data,false), 
                                LogLevel.ERROR);
                    }
            }
        }
    }

    private static void rebuildOnDeposit(ServerAction action, DepositVO deposit) {
        BuildingTypes t = null;
        //TODO: gibt es hier noch andere Minen?
        switch (Resource.getTypeByString(deposit.name_string)) {
            case BRONZEORE: t=BuildingTypes.BRONZEMINE; break;
            case IRONORE  : t=BuildingTypes.IRONMINE;   break;
            case GOLDORE  : t=BuildingTypes.GOLDMINE;   break;
            case COAL     : t=BuildingTypes.COALMINE;   break;
            default       : DebugLog.put(ServerActionHandler.class, "Unknown deposit-building relation", LogLevel.WARNING);
        }
        if (t != null) {
            GenericBuilding b = Building.getInstance().getBuildingInstanceByType(t);
            BuildingRegistry.getInstance().add(b, action.grid);
            
            ResourceCreationVO rc = new ResourceCreationVO(false);
            rc.resourceCreationHouseGrid = action.grid;
            rc.depositBuildingGridPos = action.grid;
            BuildingRegistry.getInstance().addResourceCreation(rc);
        }
    }
    
    private static void registerNewBuilding(ServerAction action, BuildingTypes t) {
        BuildingRegistry.getInstance().removePosition(action.grid);
        BuildingRegistry.getInstance().add(
                Building.getInstance().getBuildingInstanceByType(t), 
                action.grid
                );
    }
}
