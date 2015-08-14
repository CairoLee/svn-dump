package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class WitchTower extends GenericNPCBuilding {
    public WitchTower() {
        super();
        this.name = "Hexenturm";
        this.type = BuildingTypes.WITCHTOWER;
    }
}
