package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyCoalMine extends GenericEmptyDeposit {
    public EmptyCoalMine() {
        super();
        this.name = "Leere Kohlemine";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITCOAL;
    }
}
