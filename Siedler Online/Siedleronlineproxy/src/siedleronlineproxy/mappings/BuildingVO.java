/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;
import siedleronlineproxy.registry.BuildingRegistry;

/**
 *
 * @author nspecht
 */
public class BuildingVO extends GenericMapping {
    public Integer offsetY = 0;
    public Integer offsetX = 0;
    public Integer hitPoints = 1;
    public Integer upgradeLevel = 1;
    public ArrayCollection buffs = new ArrayCollection();
    public Integer playerID = 0;
    public boolean isProductionActive = true;
    public boolean isEngagedInCombat = false;
    public boolean upgradeIsInProgress = false;
    public Number buildingCreationTime = 0;
    public Integer recoveringHitPoints = 1;
    public Integer buildingGrid = 0;
    public Integer buildingProgress = 0;
    public Integer startWorkCounter = 0;
    public Integer upgradeProgress = 0;
    public Number destructionTime = 0;
    public Integer origin = 0;
    public UniqueID uniqueID = new UniqueID();
    public ArmyVO armyVO = new ArmyVO();
    public boolean initialSetOnXMLMap = false;
    public Integer buildingMode = 0;
    public Number lastRepairTime = 0;
    public Object recurringBuffVO = null;
    public boolean isBought = false;
    public Number upgradeStartTime = 0;
    public String buildingName_string = "";

    public BuildingVO() {
        this.registerProceedLater();
    }
    
    public BuildingVO(boolean dummy) {
        
    }

    @Override
    public void proceed() {
        BuildingRegistry.getInstance().add(this);
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
