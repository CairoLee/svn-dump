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
public class QuestDefinitionRewardVO extends GenericMapping {
    public Integer amount;
    public ArrayCollection rewardTriggers;
    public String name_string;
    public Integer type;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
