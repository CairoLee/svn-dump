package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class Garrison extends GenericDoNothingBuilding {
    public Garrison() {
        super();
        this.name = "Garnison";
        this.type = BuildingTypes.GARRISON;
        this.category = BuildingCategory.ARMY;
    }
}
