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
public class QuestElementVO extends GenericMapping {
    public ArrayCollection mQuestTriggersFinished_vector;
    public Integer mDirtyIndicator;
    public Object mLastBuildingSelected;
    public Number mSartTime;
    public ArrayCollection mLootItemsVO_vector;
    public UniqueID mUniqueID;
    public ArrayCollection mQuestTriggersFinishedTextCache_vector;
    public Integer mQuestMode;
    public boolean mRewardWindowShowState;
    public ArrayCollection mOtherQuestDefinition_vector;
    public Object mLastBuildingUpgraded;
    public boolean mQuestWindowShowState;
    public String mQuestName_string;
    public QuestDefinitionVO mQuestDefinition;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
