/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SpecialistTask_FindDepositVO extends GenericMapping {
    public DepositVO exploredDeposit;
    public Integer collectedTime;
    public Integer type;
    public Integer exploredDepositResult;
    public Integer phase;
    public String depositToSearch_string;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
