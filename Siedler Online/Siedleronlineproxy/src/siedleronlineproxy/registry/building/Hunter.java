package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Hunter extends GenericBuilding {
    public Hunter() {
        super();
        this.name = "Jägerhütte";
        this.type = BuildingTypes.HUNTER;
        this.category = BuildingCategory.FOOD;
        this.productionTime = 6*60;
        this.needs.put(Products.MEATDEPOSIT, 1);
        this.produces.put(Products.MEAT, 1);
    }
}
