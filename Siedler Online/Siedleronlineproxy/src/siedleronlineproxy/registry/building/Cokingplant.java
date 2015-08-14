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
public class Cokingplant extends GenericBuilding {
    public Cokingplant() {
        super();
        this.name = "Köhlerei";
        this.type = BuildingTypes.COKINGPLANT;
        this.category = BuildingCategory.METAL;
        this.productionTime = 3*60;
        this.needs.put(Products.WOOD, 2);
        this.produces.put(Products.COAL, 1);
    }
}
