/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building;
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
public class GuildTest {
    
    private GenericBuilding _object;
    
    public GuildTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new Guild();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertTrue(GenericDoNothingBuilding.class.isInstance(this._object));
        
        assertEquals("Gildenhaus", this._object.getName());
        assertEquals(Building.BuildingTypes.GUILD_BUILDING, this._object.getType());
        assertEquals(Building.BuildingCategory.__MISC, this._object.category);
        assertSame(0, this._object.getCycleTime());
    }
    
    @Test
    public void testNeedsAndProducts() {
        assertTrue(this._object.getNeeds().isEmpty());
        
        assertTrue(this._object.getProducts().isEmpty());
    }
}
