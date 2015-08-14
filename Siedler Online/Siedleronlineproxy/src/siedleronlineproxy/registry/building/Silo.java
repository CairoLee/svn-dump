package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Silo extends GenericBuilding {

    public Silo() {
        super();
        this.name = "Silo";
        this.type = BuildingTypes.SILO;
        this.category = BuildingCategory.CORN;
        this.productionTime =  12 * 60;
        this.produces.put(Products.CORNDEPOSIT, 1);
    }
}
