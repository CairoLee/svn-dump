/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SpecialistTask_AttackBuildingVO extends GenericMapping {
    public String battleScript_string;
    public Integer attackBuildingMode;
    public Integer pathPos;
    public Integer armyDestinationBuildingGridPos;
    public String battleReport_string;
    public Integer targetBuildingGridPos;
    public Integer startingArmySize;
    public Integer collectedTime;
    public Integer type;
    public BattleResultVO battleResultVO;
    public Integer phase;
    public Number lastRound;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
