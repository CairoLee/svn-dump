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
public class Mason extends GenericBuilding {
    public Mason() {
        super();
        this.name = "Steinbruch";
        this.type = BuildingTypes.MASON;
        this.category = BuildingCategory.STONE;
        this.productionTime = 5 * 60;
        this.needs.put(Products.STONEDEPOSIT, 1);
        this.produces.put(Products.STONE, 1);
    }
}
