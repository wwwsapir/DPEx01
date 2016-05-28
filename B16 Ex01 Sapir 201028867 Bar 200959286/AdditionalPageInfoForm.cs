using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public abstract partial class AdditionalPageInfoForm : Form
    {
        private readonly Page r_CurrentPage;
        protected Page CurrentPage
        {
            get { return r_CurrentPage; }
        }

        protected AdditionalPageInfoForm(Page i_CurrentPage)
        {
            r_CurrentPage = i_CurrentPage;
        }

        public static AdditionalPageInfoForm 
            CreateLanguageCompatibleAdditionalPageInfoForm(Page i_CurrentPage)
        {
            char firstNameLetter = i_CurrentPage.Name.ToString()[0];
            if (i_CurrentPage.Description != null)
            {
                // Choose the language according to both description and name of the page
                char firstDescriptionLetter = i_CurrentPage.Description.ToString()[0];
                if (firstNameLetter <= 'z' && firstDescriptionLetter <= 'z')
                {
                    return new AdditionalPageInfoFormEnglish(i_CurrentPage);
                }
                else
                {
                    // Default is Hebrew
                    return new AdditionalPageInfoFormHebrew(i_CurrentPage);
                }
            }
            else
            {
                // No description - Choose language according to name only
                if (firstNameLetter <= 'z')
                {
                    return new AdditionalPageInfoFormEnglish(i_CurrentPage);
                }
                else
                {
                    // Default is Hebrew
                    return new AdditionalPageInfoFormHebrew(i_CurrentPage);
                }
            }
        }
    }
}
