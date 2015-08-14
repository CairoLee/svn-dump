package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class RealWoodForester extends GenericForesterBuilding {
    public RealWoodForester() {
        super();
        this.name = "Laubholzforsthütte";
        this.type = BuildingTypes.REALWOODFORESTER;
        this.category = BuildingCategory.REALWOOD;
        this.productionTime = 6*60 + 45;
        this.needs.put(Products.SEED, 1);
        this.produces.put(Products.REALTREE, 1);
    }
}
