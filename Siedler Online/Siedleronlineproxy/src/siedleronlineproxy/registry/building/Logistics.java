package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class Logistics extends GenericDoNothingBuilding {
    public Logistics() {
        super();
        this.name = "Händlergilde";
        this.type = BuildingTypes.LOGISTICS;
        this.category = BuildingCategory.__MISC;
    }
}
