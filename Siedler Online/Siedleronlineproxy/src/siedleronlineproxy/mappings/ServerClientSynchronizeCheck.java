/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;

/**
 *
 * @author nspecht
 */
public class ServerClientSynchronizeCheck extends GenericMapping {
    public Integer gameTickRefreshCounter;
    public Object resourceListVO;
    public ArrayCollection resourceProcoll;
    public ArrayCollection resourceProcollCheck;
    public Integer time;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
