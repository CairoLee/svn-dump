package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyMarbleDeposit extends GenericEmptyDeposit {
    public EmptyMarbleDeposit() {
        super();
        this.name = "Leeres Mamorvorkommen";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITMARBLE;
    }
}
