package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Pumpkinfield02 extends GenericBuilding {

    public Pumpkinfield02() {
        super();
        this.name = "Normaler Fiedhof der Kürbisse";
        this.type = BuildingTypes.PUMPKINFIELD_02;
        this.category = BuildingCategory.AKTION;
        this.productionTime = 4 * 60* 60;
        this.produces.put(Products.HALLOWEENRESOURCE, 1);
    }
}
