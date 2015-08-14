/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class StreetVO extends GenericMapping {
    public Integer steetBits;
    public Integer streetCityLevel;
    public Integer playerID;
    public Integer streetVariation;
    public Integer grid;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
