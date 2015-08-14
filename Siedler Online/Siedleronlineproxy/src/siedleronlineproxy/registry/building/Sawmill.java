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
public class Sawmill extends GenericBuilding {
    public Sawmill() {
        super();
        this.name = "Nadelholzsägemühle";
        this.type = BuildingTypes.SAWMILL;
        this.category = BuildingCategory.WOOD;
        this.productionTime = 3*60;
        this.needs.put(Products.WOOD, 1);
        this.produces.put(Products.PLANK, 1);
    }
}
