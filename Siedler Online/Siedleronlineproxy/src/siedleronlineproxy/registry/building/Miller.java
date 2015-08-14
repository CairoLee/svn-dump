package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Miller extends GenericBuilding {
    public Miller() {
        super();
        this.name = "Mühle";
        this.type = BuildingTypes.MILLER;
        this.category = BuildingCategory.FOOD;
        this.productionTime = 6*60;
        this.needs.put(Products.CORN,1);
        this.produces.put(Products.FLOUR,1);
    }
}
