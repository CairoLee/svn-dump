/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import siedleronlineproxy.registry.ServerActionHandler;

/**
 *
 * @author nspecht
 */
public class ServerAction extends GenericMapping {
    public Object data = null;
    public Integer endGrid = 0;
    public Integer grid = 0;
    public Integer type = 0;

    public ServerAction() {
        this.registerProceedLater();
    }
    
    @Override
    public void proceed() {
        ServerActionHandler.handle(this);
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
