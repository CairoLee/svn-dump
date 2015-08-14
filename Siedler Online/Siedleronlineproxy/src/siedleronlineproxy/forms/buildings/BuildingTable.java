/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.forms.buildings;

import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.JOptionPane;
import org.apache.commons.lang.ArrayUtils;
import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.GenericTable;
import siedleronlineproxy.forms.GridPosition;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.building.GenericBuilding;

/**
 *
 * @author nspecht
 */
public class BuildingTable extends GenericTable {

    private static final long serialVersionUID = 1L;
    
    public BuildingCategory[] filter = new BuildingCategory[0];

    public BuildingTable() {
        super();
        this.acr.setIconSize(32);
        this.model.addColumn("Position");
        this.model.addColumn("Name");
        this.model.addColumn("Level");
        this.model.addColumn("Buffs");
        this.model.addColumn("Lagerzeit");
        this.model.addColumn("Resourcenzeit");

        this.getColumnModel().getColumn(0).setMaxWidth(140);
        this.getColumnModel().getColumn(0).setMinWidth(140);

        this.getColumnModel().getColumn(2).setMaxWidth(80);
        this.getColumnModel().getColumn(2).setMinWidth(80);

        this.getColumnModel().getColumn(4).setMaxWidth(80);
        this.getColumnModel().getColumn(4).setMinWidth(80);

        this.getColumnModel().getColumn(5).setMaxWidth(120);
        this.getColumnModel().getColumn(5).setMinWidth(120);

        this.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                if (e.getClickCount() == 2) {
                    int position = ((GridPosition)getValueAt(getSelectedRow(),0)).position;
                    GenericBuilding b = BuildingRegistry.getInstance().getBuildingByPosition(position);
                    if (b!=null) {
                        BuildingCalculation calc = new BuildingCalculation();
                        calc.setBuilding(b);
                        JOptionPane.showMessageDialog(null, calc, "Was wäre wenn ...", JOptionPane.PLAIN_MESSAGE | JOptionPane.OK_OPTION);
                    }
                }
            }
        });
    }

    public void perform_update() {
        if (BuildingRegistry.getInstance().lastChange.getTime() <= this.lastUpdate.getTime()) {
            return;
        }

        this.flushElements();

        Object[] items = BuildingRegistry.getInstance().getItems().toArray();
        for (Object i : items) {
            try {
                if (i != null) {
                    GenericBuilding item = (GenericBuilding)i;
                    boolean add = false;

                    if (this.filter.length == 0) {
                        add = true;
                    } else if (ArrayUtils.contains(this.filter, item.getCategory())) {
                        add = true;
                    }

                    if (add) {
                        this.model.addRow(new Object[]{
                                    new GridPosition(item.getBuildingVO().buildingGrid),
                                    item,
                                    item.getBuildingVO().upgradeLevel,
                                    item.getBuffs(),
                                    item.getWarehouseTime(),
                                    item.getResourceTime()
                                });
                    }
                }
            } catch (java.util.ConcurrentModificationException e) {
                this.update();
            } catch (Exception e) {
                DebugLog.put(this, e);
            }
        }
    }

    public BuildingTable addFilter(BuildingCategory t) {
        this.filter = (BuildingCategory[]) ArrayUtils.add(filter, t);
        return this;
    }
}
