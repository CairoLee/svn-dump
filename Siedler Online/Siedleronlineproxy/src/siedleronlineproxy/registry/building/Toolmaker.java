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
public class Toolmaker extends GenericBuilding {
    public Toolmaker() {
        super();
        this.name = "Werkzeugschmiede";
        this.type = BuildingTypes.TOOLMAKER;
        this.category = BuildingCategory.METAL;
        this.productionTime = 6*60;
        this.needs.put(Products.BRONZE, 1);
        this.produces.put(Products.TOOL, 1);
    }
}
