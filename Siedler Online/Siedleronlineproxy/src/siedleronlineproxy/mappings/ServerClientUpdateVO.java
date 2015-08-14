/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.GameRegistry;

/**
 *
 * @author nspecht
 */
public class ServerClientUpdateVO extends GenericMapping {
    public Number serverClientSynchronizationTime;
    public Integer zoneId;

    public ServerClientUpdateVO() {
        this.registerProceed();
    }

    @Override
    public void proceed() {
        GameRegistry.getInstance().setServerTime(serverClientSynchronizationTime);
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
