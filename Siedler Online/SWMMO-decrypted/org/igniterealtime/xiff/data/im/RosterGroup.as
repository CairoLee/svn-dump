package org.igniterealtime.xiff.data.im
{
    import org.igniterealtime.xiff.collections.*;

    public class RosterGroup extends Object
    {
        private var _items:ArrayCollection;
        public var label:String;
        public var shared:Boolean = false;

        public function RosterGroup(param1:String)
        {
            this.label = param1;
            _items = new ArrayCollection();
            return;
        }// end function

        public function get items() : ArrayCollection
        {
            return _items;
        }// end function

        public function removeItem(param1:RosterItemVO) : Boolean
        {
            return _items.removeItem(param1);
        }// end function

        public function addItem(param1:RosterItemVO) : void
        {
            if (!_items.contains(param1))
            {
                _items.addItem(param1);
            }
            return;
        }// end function

        public function contains(param1:RosterItemVO) : Boolean
        {
            return _items.contains(param1);
        }// end function

    }
}
