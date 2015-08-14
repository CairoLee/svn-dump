package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class RealWoodSawmill extends GenericBuilding {
    public RealWoodSawmill() {
        super();
        this.name = "Laubholzsägemühle";
        this.type = BuildingTypes.REALWOODSAWMILL;
        this.category = BuildingCategory.REALWOOD;
        this.productionTime = 9*60;
        this.needs.put(Products.REALWOOD, 1);
        this.produces.put(Products.REALPLANK, 1);
    }
}
