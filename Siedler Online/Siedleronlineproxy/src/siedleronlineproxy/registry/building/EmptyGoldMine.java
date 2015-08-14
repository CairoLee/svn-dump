package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyGoldMine extends GenericEmptyDeposit {
    public EmptyGoldMine() {
        super();
        this.name = "Leere Goldmine";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITGOLDORE;
    }
}
