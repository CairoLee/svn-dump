package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class SmallWatchtower extends GenericNPCBuilding {
    public SmallWatchtower() {
        super();
        this.name = "Wachturm";
        this.type = BuildingTypes.SMALLWATCHTOWER;
    }
}
