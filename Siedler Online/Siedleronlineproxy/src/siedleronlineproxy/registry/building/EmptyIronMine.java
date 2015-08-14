package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyIronMine extends GenericEmptyDeposit {
    public EmptyIronMine() {
        super();
        this.name = "Leere Eisenmine";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITIRONORE;
    }
}
