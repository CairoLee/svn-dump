/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

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
public class GenericMineBuildingTest {
    
    public GenericMineBuildingTest() {
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
     * Test of getResourceTime method, of class GenericMineBuilding.
     */
    @Test
    public void testGetResourceTime() {
        GenericMineBuilding instance = new GenericMineBuilding();
        assertEquals(0, instance.getResourceTime());
    }
}
