package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Coinage extends GenericBuilding {
    public Coinage() {
        super();
        this.name = "Münzprägerei";
        this.type = BuildingTypes.COINAGE;
        this.category = BuildingCategory.METAL;
        this.productionTime = 24*60;
        this.needs.put(Products.GOLD, 4);
        this.produces.put(Products.COIN, 1);
    }
}
