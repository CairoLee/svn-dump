/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SpecialistVO extends GenericMapping {
    public Integer garrisonBuildingGridPos;
    public Integer diceBonus;
    public Object task;
    public Integer buildingsDestroyed;
    public Integer specialistType;
    public UniqueID uniqueID;
    public ArmyVO armyVO;
    public Integer xp;
    public Integer unitsDefeated;
    public Integer playerID;
    public Integer currentHitPoints;
    public Integer xpProduced;
    public Integer faceType;
    public Integer retreatThreshold;
    public Integer battlesWon;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
