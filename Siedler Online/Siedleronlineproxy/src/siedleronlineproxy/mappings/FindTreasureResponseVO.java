/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class FindTreasureResponseVO extends GenericMapping {
    public LootItemsVO lootItemsVO;
    public UniqueID specialistUniqueId;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
