package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Pumpkinfield03 extends GenericBuilding {

    public Pumpkinfield03() {
        super();
        this.name = "Edler Fiedhof der Kürbisse";
        this.type = BuildingTypes.PUMPKINFIELD_03;
        this.category = BuildingCategory.AKTION;
        this.productionTime = 1 * 60 * 60;
        this.produces.put(Products.HALLOWEENRESOURCE, 1);
    }
}
