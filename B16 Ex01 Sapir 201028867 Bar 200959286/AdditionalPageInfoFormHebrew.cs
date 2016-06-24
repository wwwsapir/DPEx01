using System;
using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public partial class AdditionalPageInfoFormHebrew : AdditionalPageInfoForm
    {
        public AdditionalPageInfoFormHebrew(Page i_CurrentPage)
            : base(i_CurrentPage)
        {
            InitializeComponent();
            pageBindingSource.DataSource = CurrentPage;
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            r_ComplexControlPainter.ChangeToRedColorScheme();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            r_ComplexControlPainter.ChangeToBlueColorScheme();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            r_ComplexControlPainter.ChangeToGreenColorScheme();
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            r_ComplexControlPainter.ChangeToYellowColorScheme();
        }
    }
}
