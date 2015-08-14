/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;
import siedleronlineproxy.registry.BuildingRegistry;

/**
 *
 * @author nspecht
 */
public class BuildQueueVO extends GenericMapping {
    public ArrayCollection buildings;
    public Integer maxCount;

    public BuildQueueVO() {
        this.registerProceed();
    }

    @Override
    public void proceed() {
        for(Object o : this.buildings) {
            BuildingVO bvo = (BuildingVO)o;
            BuildingRegistry.getInstance().add(bvo);
        }
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
