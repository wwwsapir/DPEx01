namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class ColorMatrixUtilities
    {
        private const float k_RedColorWeight = 0.3086f;
        private const float k_GreenColorWeight = 0.6094f;
        private const float k_BlueColorWeight = 0.0820f;

        public static ColorMatrix GetColorMatrixWithAllFilters(
            float i_SaturationValue,
            float i_BrightnessValue,
            float i_ContrastValue,
            float i_RedValue,
            float i_GreenValue,
            float i_BlueValue,
            float i_Range)
        {
            ColorMatrix satBrightContrMatrix = GetBrightnessSaturationContrastMatrix(i_SaturationValue, i_BrightnessValue, i_ContrastValue);
            ColorMatrix rgbMatrix = GetRedGreenBlueMatrix(i_RedValue, i_GreenValue, i_BlueValue, i_Range);

            return MultiplyColorMatrices(satBrightContrMatrix, rgbMatrix);
        }

        public static ColorMatrix GetBrightnessSaturationContrastMatrix(
            float i_SaturationValue,
            float i_BrightnessValue,
            float i_ContrastValue)
        {
            // TODO: add slider-range values as parameteres
            float saturation = (i_SaturationValue / 5f) + 1;
            float contrast = (i_ContrastValue / 5f) + 1;
            float brightness = ((i_BrightnessValue + 10) / 10f) - 1;

            float baseSaturation = 1.0f - saturation;
            float redSaturationWeight = k_RedColorWeight * baseSaturation;
            float greenSaturationWeight = k_GreenColorWeight * baseSaturation;
            float blueSaturationWeight = k_BlueColorWeight * baseSaturation;
            float brightnessBalance = (1.0f - contrast) / 2f;

            ColorMatrix resultMatrix = new ColorMatrix(new[]
            {
                new float[] { contrast * (redSaturationWeight + saturation), contrast * redSaturationWeight, contrast * redSaturationWeight, 0, 0 },
                new float[] { contrast * greenSaturationWeight, contrast * (greenSaturationWeight + saturation),  contrast * greenSaturationWeight, 0, 0 },
                new float[] { contrast * blueSaturationWeight, contrast * blueSaturationWeight, contrast * (blueSaturationWeight + saturation), 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { brightnessBalance + brightness, brightnessBalance + brightness, brightnessBalance + brightness, 0, 1 }
            });

            return resultMatrix;
        }

        public static ColorMatrix GetRedGreenBlueMatrix(
            float i_RedValue,
            float i_GreenValue,
            float i_BlueValue,
            float i_Range)
        {
            // normalize Values
            i_RedValue /= i_Range;
            i_GreenValue /= i_Range;
            i_BlueValue /= i_Range;
            ColorMatrix newColorMatrix = new ColorMatrix(new[]
            {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { i_RedValue, i_GreenValue, i_BlueValue, 0, 1 }
            });

            return newColorMatrix;
        }

        public static ColorMatrix MultiplyColorMatrices(ColorMatrix i_Matrix1, ColorMatrix i_Matrix2)
        {
            ColorMatrix newMatrix = new ColorMatrix();
            newMatrix.Matrix00 = newMatrix.Matrix11 = newMatrix.Matrix22 = newMatrix.Matrix33 = newMatrix.Matrix44 = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        newMatrix[i, j] += i_Matrix1[i, k] * i_Matrix2[k, j];
                    }
                }
            }

            return newMatrix;
        }

        public static Bitmap AdjustImage(ColorMatrix i_NewColorMatrix, Image i_ImageToAdjust)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            Image sourceImage = i_ImageToAdjust;
            Bitmap sourceBitmap = new Bitmap(sourceImage);
            imageAttributes.SetColorMatrix(i_NewColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap result = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImage(
                    sourceBitmap,
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    0,
                    0,
                    sourceBitmap.Width,
                    sourceBitmap.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);

                // Dispose
                sourceBitmap.Dispose();
                graphics.Dispose();
            }

            return result;
        }
    }
}
