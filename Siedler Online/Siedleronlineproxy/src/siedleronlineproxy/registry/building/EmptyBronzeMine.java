package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class EmptyBronzeMine extends GenericEmptyDeposit {
    public EmptyBronzeMine() {
        super();
        this.name = "Leere Kupfermine";
        this.type = BuildingTypes.MINEDEPLETEDDEPOSITBRONZEORE;
    }
}
