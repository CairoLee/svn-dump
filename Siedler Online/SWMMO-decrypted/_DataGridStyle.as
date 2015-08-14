package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _DataGridStyle extends Object
    {
        private static var _embed_css_Assets_swf_cursorStretch_1966285931:Class = _DataGridStyle__embed_css_Assets_swf_cursorStretch_1966285931;

        public function _DataGridStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("DataGrid");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("DataGrid", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.sortArrowSkin = this;
                this.columnDropIndicatorSkin = DataGridColumnDropIndicator;
                this.columnResizeSkin = DataGridColumnResizeSkin;
                this.stretchCursor = _embed_css_Assets_swf_cursorStretch_1966285931;
                this.alternatingItemColors = [16250871, 16777215];
                this.headerStyleName = "dataGridStyles";
                this.headerSeparatorSkin = DataGridHeaderSeparator;
                this.headerBackgroundSkin = DataGridHeaderBackgroundSkin;
                this.headerColors = [16777215, 15132390];
                this.headerDragProxyStyleName = "headerDragProxyStyle";
                this.verticalGridLineColor = 13421772;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
