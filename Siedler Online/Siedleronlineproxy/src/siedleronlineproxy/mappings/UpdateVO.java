/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class UpdateVO extends GenericMapping {
    public Integer gameTickMissedError;
    public Integer serverClientGameTickError;
    public Integer serverClientSynchronisationError;
    public ServerClientSynchronizeCheck serverClientSynchronizeCheck;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
