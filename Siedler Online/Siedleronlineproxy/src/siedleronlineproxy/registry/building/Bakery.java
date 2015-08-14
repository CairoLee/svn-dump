package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Bakery extends GenericBuilding {
    public Bakery() {
        super();
        this.name = "Bäckerei";
        this.type = BuildingTypes.BAKERY;
        this.category = BuildingCategory.FOOD;
        this.productionTime = 3*60;
        this.needs.put(Products.FLOUR, 1);
        this.needs.put(Products.WATER, 2);
        this.produces.put(Products.BREAD, 1);
    }
}
