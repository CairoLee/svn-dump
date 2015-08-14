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
public class QuestDefinitionVO extends GenericMapping {
    public boolean showQuestWindow;
    public boolean showRewardWindow;
    public String questName_string;
    public ArrayCollection questPostrequisits;
    public ArrayCollection questTriggers;
    public ArrayCollection questReward;
    public String specialType_string;
    public ArrayCollection questHints;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
