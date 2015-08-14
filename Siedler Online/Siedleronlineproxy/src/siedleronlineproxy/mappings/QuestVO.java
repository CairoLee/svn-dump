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
public class QuestVO extends GenericMapping {
    public boolean rewardWindowShowState;
    public boolean questWindowShowState;
    public ArrayCollection questTriggersFinished;
    public Integer activeQuestMode;
    public String activeQuest_string;
    public Number startQuestTime;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
