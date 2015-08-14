/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.forms.buildings;

import java.text.DecimalFormat;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableRowSorter;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.forms.AdvancedCellRenderer;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.building.GenericBuilding;
import siedleronlineproxy.util.CollectionTable;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class BuildingProductivityTable extends JTable {

    private final DefaultTableModel model;
    private GenericBuilding building;
    private int level = 1;

    public BuildingProductivityTable() {
        super();
        TableRowSorter<DefaultTableModel> sorter = new TableRowSorter<DefaultTableModel>();
        AdvancedCellRenderer acr = AdvancedCellRenderer.setCellRenderer(this);

        this.setRowSorter(sorter);
        this.setAutoCreateRowSorter(true);

        this.model = new DefaultTableModel() {

            @Override
            public boolean isCellEditable(int a, int b) {
                return false;
            }
        };

        this.setModel(this.model);

        this.model.addColumn("Resource");
        this.model.addColumn("Produktion");
        this.model.addColumn("pro Zyklus");
        this.model.addColumn("pro Tag");
        this.model.addColumn("Gesamt");
    }

    public void setBuilding(GenericBuilding b) {
        this.building = b;
        this.level = b.getBuildingVO().upgradeLevel;
        this.update();
    }

    public void setLevel(int l) {
        this.level = l;
        this.update();
    }

    public void update() {
        this.clearSelection();
        int rowcount = this.model.getRowCount();
        for (int i = 0; i < rowcount; i++) {
            this.model.removeRow(0);
        }

        CollectionEnumTable<Products, Double>[] others = BuildingRegistry.getInstance().getProductivity(this.building.getBuildingVO().buildingGrid);
        CollectionEnumTable<Products, Double> needs = this.building.getNeedsPerDayByLevel(this.level);
        CollectionEnumTable<Products, Double> prods = this.building.getProducesPerDayByLevel(this.level);

        DecimalFormat df = new DecimalFormat("0.00");

        for (Products p : Products.values()) {
            double need = 0;
            double prod = 0;
            if (needs.containsKey(p)) need = needs.get(p);
            if (prods.containsKey(p)) prod = prods.get(p);

            if (need != 0 || prod != 0) {
                double other = 0;
                if (others[0].containsKey(p)) other -= others[0].get(p);
                if (others[1].containsKey(p)) other += others[1].get(p);
                double single = 0;
                if (this.building.getNeeds().containsKey(p)) single -= this.building.getNeeds().get(p)*this.level;
                if (this.building.getProducts().containsKey(p)) single += this.building.getProducts().get(p)*this.level;

                this.model.addRow(new Object[]{
                            p,
                            other,
                            single,
                            (prod - need),
                            (other + prod - need)
                        });
            }
        }
    }
}
