package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class RealWoodCutter extends GenericBuilding {
    public RealWoodCutter() {
        super();
        this.name = "Laubholzfällerhütte";
        this.type = BuildingTypes.REALWOODCUTTER;
        this.category = BuildingCategory.REALWOOD;
        this.productionTime = 4*60 + 30;
        this.needs.put(Products.REALTREE, 1);
        this.produces.put(Products.REALWOOD, 1);
    }
}
