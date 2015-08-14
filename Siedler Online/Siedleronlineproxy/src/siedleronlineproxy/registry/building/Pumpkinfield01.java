package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Pumpkinfield01 extends GenericBuilding {

    public Pumpkinfield01() {
        super();
        this.name = "Kleiner Fiedhof der Kürbisse";
        this.type = BuildingTypes.PUMPKINFIELD_01;
        this.category = BuildingCategory.AKTION;
        this.productionTime = 8 * 60 * 60;
        this.produces.put(Products.HALLOWEENRESOURCE, 1);
    }
}
