package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class GoldSmelter extends GenericBuilding {
    public GoldSmelter() {
        super();
        this.name = "Goldschmelze";
        this.type = BuildingTypes.GOLDSMELTER;
        this.category = BuildingCategory.METAL;
        this.productionTime = 12*60;
        this.needs.put(Products.GOLDORE, 2);
        this.needs.put(Products.COAL, 8);
        this.produces.put(Products.GOLD, 1);
    }
}
