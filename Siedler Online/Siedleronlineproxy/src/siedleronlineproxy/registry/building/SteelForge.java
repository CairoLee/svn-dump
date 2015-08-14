package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class SteelForge extends GenericBuilding {
    public SteelForge() {
        super();
        this.name = "Stahlschmelze";
        this.type = BuildingTypes.STEELFORGE;
        this.category = BuildingCategory.METAL;
        this.productionTime = 12*60;
        this.needs.put(Products.IRON, 2);
        this.needs.put(Products.COAL, 6);
        this.produces.put(Products.STEEL, 1);
    }
}
