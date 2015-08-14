package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class MediumWatchtower extends GenericNPCBuilding {
    public MediumWatchtower() {
        super();
        this.name = "Verstärkter Wachturm";
        this.type = BuildingTypes.MEDIUMWATCHTOWER;
    }
}
