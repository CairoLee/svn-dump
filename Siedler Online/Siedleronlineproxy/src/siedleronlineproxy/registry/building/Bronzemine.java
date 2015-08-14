/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class Bronzemine extends GenericMineBuilding {
    public Bronzemine() {
        super();
        this.name = "Kupfermine";
        this.type = BuildingTypes.BRONZEMINE;
        this.productionTime = 3*60;
        this.needs.put(Products.BRONZEDEPOSIT, 1);
        this.produces.put(Products.BRONZEORE, 1);
    }
}
