package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Watermill extends GenericBuilding {
    public Watermill() {
        super();
        this.name = "Wassermühle";
        this.type = BuildingTypes.WATERMILL;
        this.category = BuildingCategory.WATER;
        this.productionTime = 3*60;
        this.produces.put(Products.WATER, 1);
    }
}
