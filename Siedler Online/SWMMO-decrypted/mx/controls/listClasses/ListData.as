package mx.controls.listClasses
{
    import mx.core.*;

    public class ListData extends BaseListData
    {
        public var icon:Class;
        public var labelField:String;
        static const VERSION:String = "3.5.0.12683";

        public function ListData(param1:String, param2:Class, param3:String, param4:String, param5:IUIComponent, param6:int = 0, param7:int = 0)
        {
            super(param1, param4, param5, param6, param7);
            this.icon = param2;
            this.labelField = param3;
            return;
        }// end function

    }
}
