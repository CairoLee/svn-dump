/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.util;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author nspecht
 */
public class LinkedArrayList<K, V> {
    private ArrayList keys;
    private ArrayList values;
    
    public LinkedArrayList() {
        this.keys = new ArrayList<K>();
        this.values = new ArrayList<V>();
    }
    
    public int size() {
        return this.keys.size();                
    }
    
    public boolean isEmpty() {
        return this.keys.isEmpty();
    }
    
    public void put(K key, V value) {
        this.add(key, value);
    }
    
    public void add(K key, V value) {
        this.keys.add(key);
        this.values.add(this.keys.indexOf(key),value);
        this.keys.trimToSize();
        this.values.trimToSize();
    }
    
    public V get(K key) {
        if (!this.keys.contains(key)) return null;
        return (V) this.values.get(this.keys.indexOf(key));
    }
    
    public Collection<V> values() {
        Collection<V> ret = (Collection<V>) this.values.clone();
        //ret.addAll(this.values);
        return ret;
    }
    
    public Collection<K> keySet() {
        Collection<K> ret = (Collection<K>) this.keys.clone();
        //ret.addAll(this.keys);
        return ret;
    }
    
    public void remove(K key) {
        this.values.remove(this.keys.indexOf(key));
        this.keys.remove(key);
        this.keys.trimToSize();
        this.values.trimToSize();
    }
    
    public void clear() {
        this.keys.clear();
        this.values.clear();
        this.keys.trimToSize();
        this.values.trimToSize();
    }
    
    public int indexOf(K key) {
        return this.keys.indexOf(key);
    }
    
    public boolean containsKey(K key) {
        return this.keys.contains(key);
    }
    
    public boolean containsValue(V value) {
        return this.values.contains(value);
    }
}
