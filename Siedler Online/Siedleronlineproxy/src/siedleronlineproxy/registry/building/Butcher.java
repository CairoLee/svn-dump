package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Butcher extends GenericBuilding {
    public Butcher() {
        super();
        this.name = "Metzgerei";
        this.type = BuildingTypes.BUTCHER;
        this.category = BuildingCategory.FOOD;
        this.productionTime = 12*60;
        this.needs.put(Products.MEAT, 4);
        this.produces.put(Products.SAUSAGE, 1);
    }
}
