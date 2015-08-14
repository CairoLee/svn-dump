package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class ExoticWoodSawmill extends GenericBuilding {
    public ExoticWoodSawmill() {
        super();
        this.name = "Edelholzsägemühle";
        this.type = BuildingTypes.EXOTICWOODSAWMILL;
        this.category = BuildingCategory.EXOTICWOOD;
        this.productionTime = 12*60;
        this.needs.put(Products.EXOTICWOOD, 1);
        
        this.produces.put(Products.EXOTICPLANK, 1);
    }
}
