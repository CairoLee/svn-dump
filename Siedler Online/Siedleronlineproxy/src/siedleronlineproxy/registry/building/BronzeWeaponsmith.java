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
public class BronzeWeaponsmith extends GenericBuilding {
    public BronzeWeaponsmith() {
        super();
        this.name = "Bronzewaffenschmiede";
        this.type = BuildingTypes.BRONZEWEAPONSMITH;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 6*60;
        this.needs.put(Products.BRONZE, 1);
        this.needs.put(Products.COAL, 2);
        this.produces.put(Products.BRONZESWORD, 1);
    }
}
