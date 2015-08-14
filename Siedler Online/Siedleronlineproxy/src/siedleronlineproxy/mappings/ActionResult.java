/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class ActionResult extends GenericMapping {
    public Integer clientTime;
    public flex.messaging.io.ArrayCollection data;
    public Integer errorCode;

    @Override
    public void proceed() {

    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
