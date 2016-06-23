using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using FacebookWrapper.ObjectModel;

    public class FacebookImageUploader : IImageUploader
    {
        private string k_DefaultPrivacySettings = "{'value':'SELF'}";

        private User m_LoggedInUser;

        public string PrivacySettings { get; set; }

        public FacebookImageUploader(User i_LoggedInUser)
        {
            PrivacySettings = this.k_DefaultPrivacySettings;
            this.m_LoggedInUser = i_LoggedInUser;
        }

        public void UploadImage(Image i_ImageToUpload, string i_Title)
        {
            byte[] imageInBytes = ImageToByteArray(i_ImageToUpload);
            this.m_LoggedInUser.PostPhoto(
                imageInBytes,
                i_Title,
                i_PrivacyParameterValue: PrivacySettings);
        }

        public byte[] ImageToByteArray(Image i_ImageIn)
        {
            using (var ms = new MemoryStream())
            {
                i_ImageIn.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
        }

    }
}
