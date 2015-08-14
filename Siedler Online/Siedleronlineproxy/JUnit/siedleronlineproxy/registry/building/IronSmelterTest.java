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
public class IronSmelterTest {
    
    private GenericBuilding _object;
    
    public IronSmelterTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new IronSmelter();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertEquals("Eisenschmelze", this._object.getName());
        assertEquals(Building.BuildingTypes.IRONSMELTER, this._object.getType());
        assertEquals(Building.BuildingCategory.METAL, this._object.category);
        assertEquals(12 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertSame(2, this._object.getNeeds().size());
        assertTrue(this._object.getNeeds().containsKey(Products.COAL));
        assertTrue(this._object.getNeeds().containsKey(Products.IRONORE));
        assertSame(6 , this._object.getNeeds().get(Products.COAL));
        assertSame(4 , this._object.getNeeds().get(Products.IRONORE));
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.IRON));
        assertSame(1 , this._object.getProducts().get(Products.IRON));
    }
}
