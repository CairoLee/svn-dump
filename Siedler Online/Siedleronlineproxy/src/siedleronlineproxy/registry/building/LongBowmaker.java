package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class LongBowmaker extends GenericBuilding {
    public LongBowmaker() {
        super();
        this.name = "Langbogenmacherei";
        this.type = BuildingTypes.LONGBOWMAKER;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 24*60;
        this.needs.put(Products.REALWOOD, 16);
        this.produces.put(Products.LONGBOW, 1);
    }
}
