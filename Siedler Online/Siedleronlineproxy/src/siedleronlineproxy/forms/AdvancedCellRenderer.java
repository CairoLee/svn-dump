/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.forms;

import java.awt.Image;
import java.text.DecimalFormat;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JTable;
import javax.swing.ListSelectionModel;
import javax.swing.table.DefaultTableCellRenderer;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.registry.building.GenericBuilding;

/**
 *
 * @author nspecht
 */
public class AdvancedCellRenderer extends DefaultTableCellRenderer {
    public int iconSize = 16;
    private JTable table;

    public static AdvancedCellRenderer setCellRenderer(JTable t) {
        AdvancedCellRenderer ret = new AdvancedCellRenderer();
        ret.setTable(t);
        return ret;
    }

    @Override
    public void setValue(Object value) {
        if (value instanceof DepositVO) this.renderDepositVO((DepositVO) value);
        else if (value instanceof Resource.Products) this.renderResourceProducts((Products) value);
        else if (value instanceof GenericBuilding) this.renderGenericBuilding((GenericBuilding) value);
        else if (value instanceof GridPosition) this.renderGridPosition((GridPosition) value);
        else if (value instanceof Double) this.renderDouble((Double)value);
        else if (value instanceof Integer) this.renderInteger((Integer)value);
        else {
            setIcon(null);
            super.setValue(value);
        }
    }

    public void setIconSize(int size) {
        this.iconSize = size;
        this.table.setRowHeight(this.iconSize);
    }

    public void setTable(JTable t) {
        this.table = t;
        this.table.setDefaultRenderer(Object.class, this);
        this.table.setRowHeight(this.iconSize);
        
        this.table.setCellSelectionEnabled(false);
        this.table.setColumnSelectionAllowed(false);
        this.table.setRowSelectionAllowed(true);
        
        this.table.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
    }

    private void renderDepositVO(DepositVO value) {
        setIcon(this.resizeIcon((ImageIcon) value.getIcon()));
        setText(value.getName());
    }

    private void renderResourceProducts(Resource.Products value) {
        setIcon(this.resizeIcon((ImageIcon) Resource.getIconByType(value)));
        setText(Resource.getNameByType(value));
    }

    private void renderGridPosition(GridPosition p) {
        setIcon(null);
        setText(p.toString());

    }

    private void renderGenericBuilding(GenericBuilding value) {
        setIcon(this.resizeIcon((ImageIcon) value.getIcon()));
        setText(value.getName());
    }

    private void renderDouble(Double value) {
        DecimalFormat df = new DecimalFormat("0.00");
        String font = df.format(value);
        if (value < 0) font = "<b style=\"color:#FF0000:\">"+font+"</b>";
        setText("<html><body>"+font+"</body></html>");
        setIcon(null);
    }

    private void renderInteger(Integer value) {
        String font = value.toString();
        if (value < 0) font = "<b style=\"color:#FF0000:\">"+font+"</b>";
        setText("<html><body>"+font+"</body></html>");
        setIcon(null);
    }

    private Icon resizeIcon(ImageIcon i) {
        Image img = i.getImage();
        img = img.getScaledInstance(this.iconSize, this.iconSize, Image.SCALE_SMOOTH);
        return new ImageIcon(img);
    }
}
