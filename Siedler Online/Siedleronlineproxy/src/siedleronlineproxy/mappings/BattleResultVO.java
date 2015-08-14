/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class BattleResultVO extends GenericMapping {
    public ArmyVO defendingArmyVO;
    public ArmyVO attackingArmyVO;
    public Integer casualtiesAttacker;
    public String battleScript;
    public Integer combatDuration;
    public Integer unitFightDuration;
    public Integer casualtiesDefender;
    public Integer gainedXp;
    public Integer buildingHitPoints;
    public Integer lostPopulationDefender;
    public Integer battleResult; //0=Angreifer gewinnt ???
    public Integer lostPopulationAttacker;
    public UniqueID specialistUniqueID;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
