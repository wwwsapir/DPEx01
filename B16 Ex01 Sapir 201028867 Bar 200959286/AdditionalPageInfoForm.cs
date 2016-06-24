using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public abstract partial class AdditionalPageInfoForm : Form
    {
        private readonly Page r_CurrentPage;
        protected readonly ComplexControlPainter r_ComplexControlPainter;

        protected Page CurrentPage
        {
            get { return r_CurrentPage; }
        }

        protected AdditionalPageInfoForm(Page i_CurrentPage)
        {
            r_CurrentPage = i_CurrentPage;
            r_ComplexControlPainter = new ComplexControlPainter(this);
        }

        public static AdditionalPageInfoForm 
            CreateLanguageCompatibleAdditionalPageInfoForm(Page i_CurrentPage)
        {
            // Choose the language and create a form
            if (PageLanguageEssentials.IsPageInEnglish(i_CurrentPage))
            {
                return new AdditionalPageInfoFormEnglish(i_CurrentPage);
            }
            else
            {
                return new AdditionalPageInfoFormHebrew(i_CurrentPage);
            }
        }
    }
}
