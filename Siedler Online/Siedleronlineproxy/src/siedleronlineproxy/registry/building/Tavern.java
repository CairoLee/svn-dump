package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class Tavern extends GenericDoNothingBuilding {
    public Tavern() {
        super();
        this.name = "Taverne";
        this.type = BuildingTypes.TAVERN;
        this.category = BuildingCategory.__MISC;
    }
}
