package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Goldmine extends GenericMineBuilding {
    public Goldmine() {
        super();
        this.name = "Goldmine";
        this.type = BuildingTypes.GOLDMINE;
        this.productionTime = 12*60;
        this.needs.put(Products.GOLDDEPOSIT, 1);
        this.produces.put(Products.GOLDORE, 1);
    }
}
