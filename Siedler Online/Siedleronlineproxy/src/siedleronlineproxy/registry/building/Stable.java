package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Stable extends GenericBuilding {
    public Stable() {
        super();
        this.name = "Stall";
        this.type = BuildingTypes.STABLE;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 6*60;
        this.needs.put(Products.CORN, 2);
        this.needs.put(Products.WATER, 4);
        this.produces.put(Products.HORSE, 1);
    }
}
