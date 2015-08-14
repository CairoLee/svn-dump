/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import siedleronlineproxy.mappings.BuildingVO;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author nspecht
 */
public class GenericDoNothingBuildingTest {
    
    public GenericDoNothingBuildingTest() {
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
     * Test of getResourceTime method, of class GenericDoNothingBuilding.
     */
    @Test
    public void testGetResourceTime() {
        GenericDoNothingBuilding instance = new GenericDoNothingBuilding();
        assertEquals(0, instance.getResourceTime());
    }

    /**
     * Test of getWarehouseTime method, of class GenericDoNothingBuilding.
     */
    @Test
    public void testGetWarehouseTime() {
        GenericDoNothingBuilding instance = new GenericDoNothingBuilding();
        assertEquals(0, instance.getWarehouseTime());
    }

    /**
     * Test of pause method, of class GenericDoNothingBuilding.
     */
    @Test
    public void testPause() {
        GenericDoNothingBuilding instance = new GenericDoNothingBuilding();
        instance.setBuildingVO(new BuildingVO());
        instance.pause();
        assertSame(true, instance.getBuildingVO().isProductionActive);
    }
}
