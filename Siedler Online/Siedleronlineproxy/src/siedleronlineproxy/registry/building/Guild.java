package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class Guild extends GenericDoNothingBuilding {
    public Guild() {
        super();
        this.name = "Gildenhaus";
        this.type = BuildingTypes.GUILD_BUILDING;
        this.category = BuildingCategory.__MISC;
    }
}
