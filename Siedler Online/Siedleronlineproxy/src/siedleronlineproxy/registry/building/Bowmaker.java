package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Bowmaker extends GenericBuilding {
    public Bowmaker() {
        super();
        this.name = "Bogenmacherei";
        this.type = BuildingTypes.BOWMAKER;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 12*60;
        this.needs.put(Products.WOOD, 8);
        this.produces.put(Products.BOW, 1);
    }
}
