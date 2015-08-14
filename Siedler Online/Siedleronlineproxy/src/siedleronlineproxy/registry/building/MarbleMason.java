package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class MarbleMason extends GenericBuilding {
    public MarbleMason() {
        super();
        this.name = "Mamorsteinbruch";
        this.type = BuildingTypes.MARBLEMASON;
        this.category = BuildingCategory.STONE;
        this.productionTime = 9*60;
        this.needs.put(Products.MARBLEDEPOSIT, 1);
        this.produces.put(Products.MARBLE, 1);
    }
}
