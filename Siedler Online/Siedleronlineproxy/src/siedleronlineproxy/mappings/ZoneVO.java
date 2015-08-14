/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.GridPosition;
import siedleronlineproxy.forms.map.Map;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.DepositRegistry;
import siedleronlineproxy.registry.StockRegistry;

/**
 *
 * @author nspecht
 */
public class ZoneVO extends GenericMapping {
    public ArrayCollection depositGroups;
    public ArrayCollection mapValues;
    public String questFileName;
    public ArrayCollection deposits;
    public ArrayCollection specialist_vector;
    public Integer zoneID;
    public ArrayCollection backgroundTiles;
    public BuildQueueVO buildQueue; 
    public ArrayCollection militaryUnitRecruitments_vector;
    public QuestVO activeQuest;
    public ArrayCollection playersOnMap;
    public Number serverTime;
    public ArrayCollection buildings;
    public String zoneMapName;
    public Integer gameTickRefreshCounter;
    public ResourcesVO resourcesVO;
    public Number lastGameTickRefreshTime;
    public ArrayCollection freeLandscapes;
    public Object map_PlayerID_Army;
    public ArrayCollection sectors;
    public ArrayCollection gameTickCommands_vector;
    public ArrayCollection depositQualities;
    public QuestDefinitionContainerVO questDefinitionContainer;
    public ArrayCollection buffProduction_vector;
    public Integer zoneOwnerPlayerID;
    public Integer zoneVisitorPlayerID;
    public ArrayCollection resourceCreations;
    public ArrayCollection streets;
    public ArrayCollection dataTracking_vector;
    public ArrayCollection landscapes;
    public ArrayCollection landingFields;

    public ZoneVO() {
        DebugLog.put(this, "REFRESH REFRESH REFRESH");
        DepositRegistry.getInstance().reset();
        StockRegistry.getInstance().reset();
        BuildingRegistry.getInstance().reset();

        MappingRegistry.getInstance().registerProceed(this);
        Map.getInstance().setMap(this.zoneMapName);
        Map.getInstance().updateMap();
    }

    @Override
    public void proceed() {
        if (this.mapValues == null) return;
        for (int i = 0; i < this.mapValues.size(); i++) {
            MapValueItemVO mvi = (MapValueItemVO)this.mapValues.get(i);
            GridPosition.registerPosition(i, mvi.mSectorId);
        }
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
