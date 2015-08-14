/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class TradeOfferVO extends GenericMapping {
    public ResourceVO offer;
    public ResourceVO costs;
    public Integer receipientId;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
