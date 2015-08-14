/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class TradeVO extends GenericMapping {
    public Integer receiverPlayerId;
    public ResourceVO resourceToAdd;
    public Integer senderPlayerId;
    public Integer mailId;
    public ResourceVO resourceToDeduct;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
