/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class ServerActionResult extends GenericMapping {
    public Object data;
    public Integer type;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
