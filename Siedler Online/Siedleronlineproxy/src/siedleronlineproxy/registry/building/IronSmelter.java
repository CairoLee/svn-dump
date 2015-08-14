package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class IronSmelter extends GenericBuilding {
    public IronSmelter() {
        super();
        this.name = "Eisenschmelze";
        this.type = BuildingTypes.IRONSMELTER;
        this.category = BuildingCategory.METAL;
        this.productionTime = 12*60;
        this.needs.put(Products.IRONORE, 4);
        this.needs.put(Products.COAL, 6);
        this.produces.put(Products.IRON, 1);
    }
}
