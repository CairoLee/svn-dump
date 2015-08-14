/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class BuffVO extends GenericMapping {
    public Integer amount = 0;
    public Number startTime = 0;
    public Integer remaining = 0;
    public String buffName_string = "";
    public Integer uniqueId2 = 0;
    public Integer applianceMode = 0;
    public Integer uniqueId1 = 0;
    public Integer recurringChance = 0;
    public String resourceName_string = "";

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
