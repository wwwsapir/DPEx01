namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Drawing.Imaging;

    // System.Drawing.Imaging.ColorMatrix Wrapper
    public class Filter : IFilter
    {
        public ColorMatrix PixelFilter { get; set; }

        public FilterValues FilterValues { get; set; }

        public void SetFilter(FilterValues i_FilterValues)
        {
            FilterValues = i_FilterValues;
        }

        public void ApplyFilter()
        {
            PixelFilter = ColorMatrixUtilities.AdjustColorMatrix(PixelFilter, FilterValues);
            FilterValues = new FilterValues();
        }

        public string Name { get; set; }

        public Filter(ColorMatrix i_Filter, string i_Name = "Untitled Filter")
        {
            FilterValues = new FilterValues();
            PixelFilter = i_Filter;
            Name = i_Name;
        }

        public Filter(float[][] i_Filter, string i_Name = "Untitled Filter")
        {
            FilterValues = new FilterValues();
            PixelFilter = new ColorMatrix(i_Filter);
            Name = i_Name;
        }

        public ColorMatrix GetColorMatrixWithAdjustments()
        {
            return ColorMatrixUtilities.AdjustColorMatrix(PixelFilter, FilterValues);
        }

        // Used for Xml serialization
        public Filter()
        {
        }
    }
}
