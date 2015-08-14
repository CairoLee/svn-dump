/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Resource.Products;
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
public class GoldSmelterTest {
    
    private GenericBuilding _object;
    
    public GoldSmelterTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new GoldSmelter();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Goldschmelze", this._object.getName());
        assertEquals(Building.BuildingTypes.GOLDSMELTER, this._object.getType());
        assertEquals(Building.BuildingCategory.METAL, this._object.category);
        assertEquals(12 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertSame(2, this._object.getNeeds().size());
        assertTrue(this._object.getNeeds().containsKey(Products.COAL));
        assertTrue(this._object.getNeeds().containsKey(Products.GOLDORE));
        assertSame(8 , this._object.getNeeds().get(Products.COAL));
        assertSame(2 , this._object.getNeeds().get(Products.GOLDORE));
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.GOLD));
        assertSame(1 , this._object.getProducts().get(Products.GOLD));
    }
}
