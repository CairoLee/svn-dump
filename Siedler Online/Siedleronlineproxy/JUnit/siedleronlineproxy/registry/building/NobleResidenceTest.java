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
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class NobleResidenceTest {
    
    private GenericBuilding _object;
    
    public NobleResidenceTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        this._object = new NobleResidence();
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuildingProperties() {
        assertTrue(GenericBuilding.class.isInstance(this._object));
        assertTrue(GenericDoNothingBuilding.class.isInstance(this._object));
        assertEquals("Gehobenes Wohnhaus", this._object.getName());
        assertEquals(Building.BuildingTypes.NOBLERESIDENCE, this._object.getType());
        assertEquals(Building.BuildingCategory.__MISC, this._object.category);
        assertEquals(24 * 60 * 60, this._object.getCycleTime());
    }
    
    @Test
    public void testNeeds() {
        assertTrue(this._object.getNeeds().isEmpty());
    }
    
    @Test
    public void testProducts() {
        assertSame(1, this._object.getProducts().size());
        assertTrue(this._object.getProducts().containsKey(Products.POPULATION));
        assertSame(10 , this._object.getProducts().get(Products.POPULATION));
    }

    /**
     * Test of getProducesPerDayByLevel method, of class NobleResidence.
     */
    @Test
    public void testGetProducesPerDayByLevel() {
        for (int level = 1; level < 5; level++) {
            CollectionEnumTable<Products, Double> prods = this._object.getProducesPerDayByLevel(level);
            assertSame(1, prods.size());
            assertTrue(prods.containsKey(Products.POPULATION));
            assertEquals((double)(10 * level + 20) , prods.get(Products.POPULATION), 0);
        }
    }
}
