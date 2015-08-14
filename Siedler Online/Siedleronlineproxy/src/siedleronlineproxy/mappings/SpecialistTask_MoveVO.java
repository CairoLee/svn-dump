package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.BuildingRegistry;

/**
 *
 * @author nspecht
 */
public class SpecialistTask_MoveVO extends GenericMapping {
    public Integer pathPos;
    public Integer currentGarrisonGridIdx;
    public Integer newGarrisonGridIdx;
    public Integer collectedTime;
    public Integer type;
    public Integer phase;

    public SpecialistTask_MoveVO() {
        this.registerProceed();
    }
    
    @Override
    public void proceed() {
        BuildingRegistry.getInstance().moveBuilding(this.currentGarrisonGridIdx, this.newGarrisonGridIdx);
    }

    @Override
    public void manipulate(boolean incoming) {
    }
    
}
