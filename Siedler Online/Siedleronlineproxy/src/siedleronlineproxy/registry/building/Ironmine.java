package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Ironmine extends GenericMineBuilding {
    public Ironmine() {
        super();
        this.name = "Eisenmine";
        this.type = BuildingTypes.IRONMINE;
        this.productionTime = 6*60;
        this.needs.put(Products.IRONDEPOSIT, 1);
        this.produces.put(Products.IRONORE, 1);
    }
}
