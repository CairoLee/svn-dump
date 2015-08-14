/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.BuildingRegistry;

/**
 *
 * @author nspecht
 */
public class ResourceCreationVO extends GenericMapping {
    public Integer pathPos = 0;
    public PathVO pathVO = new PathVO();
    public boolean assignedSettler = false;
    public Integer protocollResourceCreationLastbuildingMode = 0;
    public Integer resourceCreationHouseGrid = 0;
    public Number lastCreationTime = 0;
    public Integer playerId = 0;
    public Integer productionState = 0;
    public Integer gatheredResource = 0;
    public Integer settlerKIState = 0;
    public Integer resourceDefinitionID = 0;
    public Integer depositBuildingGridPos = 0;
    public Integer protocollResourceCreationProcessCntr = 0;

    public ResourceCreationVO() {        
        this.registerProceedLater();
    }
    
    public ResourceCreationVO(boolean dummy) {
    }

    @Override
    public void proceed() {
        BuildingRegistry.getInstance().addResourceCreation(this);
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
