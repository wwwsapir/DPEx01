using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Drawing.Imaging;
    using System.Security.Cryptography.X509Certificates;

    public interface IFilter
    {
        string Name { get; set; }

        ColorMatrix PixelFilter { get; set; }

        FilterValues FilterValues { get; set; }

        void ApplyFilter();

        void SetFilter(FilterValues i_FilterValues);

        ColorMatrix GetColorMatrixWithAdjustments();
    }
}
