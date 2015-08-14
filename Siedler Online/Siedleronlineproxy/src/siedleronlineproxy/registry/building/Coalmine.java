package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Coalmine extends GenericMineBuilding {
    public Coalmine() {
        super();
        this.name = "Kohlemine";
        this.type = BuildingTypes.COALMINE;
        this.productionTime = 1*60 + 30;
        this.needs.put(Products.COALDEPOSIT, 1);
        this.produces.put(Products.COAL, 1);
    }
}
