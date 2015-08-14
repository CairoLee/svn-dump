/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.constants;

import javax.swing.Icon;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.registry.building.Bakery;
import siedleronlineproxy.registry.building.GenericBuilding;

/**
 *
 * @author nspecht
 */
public class BuildingTest {
    
    public BuildingTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of getInstance method, of class Building.
     */
    @Test
    public void testGetInstance() {
        assertNotNull(Building.getInstance());
    }

    /**
     * Test of getIconByType method, of class Building.
     */
    @Test
    public void testGetIconByType() {
        assertNotNull(Building.getIconByType(BuildingTypes.BAKERY));
    }

    /**
     * Test of getBuildingInstanceByType method, of class Building.
     */
    @Test
    public void testGetBuildingInstanceByType() {
        Object ret = Building.getInstance().
                getBuildingInstanceByType(BuildingTypes.BAKERY);
        assertNotNull(ret);
        assertTrue(Bakery.class.isInstance(ret));
    }
    
    /**
     * Test count of building types and categories
     */
    @Test
    public void testCount() {
        assertEquals(187,BuildingTypes.values().length);
        assertEquals(19,BuildingCategory.values().length);
    }
}
