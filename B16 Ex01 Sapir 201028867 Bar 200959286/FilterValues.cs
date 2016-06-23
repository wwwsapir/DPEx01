using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public class FilterValues
    {
        public float SaturationValue { get; set; }

        public float BrightnessValue { get; set; }

        public float ContrastValue { get; set; }

        public float RedValue { get; set; }

        public float GreenValue { get; set; }

        public float BlueValue { get; set; }

        public float Range { get; set; }

        public FilterValues(
            float i_SaturationValue = 0,
            float i_BrightnessValue = 0,
            float i_ContrastValue = 0,
            float i_RedValue = 0,
            float i_GreenValue = 0,
            float i_BlueValue = 0,
            float i_Range = 10)
        {
            SaturationValue = i_SaturationValue;
            BrightnessValue = i_BrightnessValue;
            ContrastValue = i_ContrastValue;
            RedValue = i_RedValue;
            GreenValue = i_GreenValue;
            BlueValue = i_BlueValue;
            Range = i_Range;
        }
    }
}
