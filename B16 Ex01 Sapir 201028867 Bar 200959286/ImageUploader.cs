using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Drawing;

    public interface IImageUploader
    {
        void UploadImage(Image i_ImageToUpload, string i_Title);
    }
}
