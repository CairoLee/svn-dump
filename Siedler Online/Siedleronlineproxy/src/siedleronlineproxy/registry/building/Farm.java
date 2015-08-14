/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Farm extends GenericBuilding {
    public Farm() {
        super();
        this.name = "Bauernhof";
        this.type = BuildingTypes.FARM;
        this.category = BuildingCategory.CORN;
        this.productionTime = 12*60;
        this.needs.put(Products.CORNDEPOSIT, 1);
        this.produces.put(Products.CORN, 1);
    }
}
