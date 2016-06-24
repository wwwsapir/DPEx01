using System.Drawing;
using System.Windows.Forms;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public class ComplexControlPainter
    {
        private readonly Control r_FormReference;

        public ComplexControlPainter(Control i_FormToPaint)
        {
            r_FormReference = i_FormToPaint;
        }

        public void ChangeToRedColorScheme()
        {
            changeColorScheme(Color.LightCoral, Color.IndianRed, Color.Crimson, Color.Tomato);
        }

        public void ChangeToBlueColorScheme()
        {
            changeColorScheme(Color.Aquamarine, Color.Aqua, Color.Teal, Color.DarkTurquoise);
        }

        public void ChangeToGreenColorScheme()
        {
            changeColorScheme(Color.LightGreen, Color.Chartreuse, Color.ForestGreen, Color.MediumSeaGreen);
        }

        public void ChangeToYellowColorScheme()
        {
            changeColorScheme(Color.LightYellow, Color.PaleGoldenrod, Color.Gold, Color.Yellow);
        }

        private void changeColorScheme(
            Color i_BackColor,
            Color i_TextBoxAndListBoxColor,
            Color i_ButtonColor,
            Color i_DefaultColor)
        {
            r_FormReference.BackColor = i_BackColor;
            foreach (Control control in r_FormReference.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.BackColor = i_TextBoxAndListBoxColor;
                }
                else if (control.GetType() == typeof(ListBox))
                {
                    control.BackColor = i_TextBoxAndListBoxColor;
                }
                else if (control.GetType() == typeof(Label))
                {
                    control.BackColor = i_BackColor;
                }
                else if (control.GetType() == typeof(LinkLabel))
                {
                    control.BackColor = i_BackColor;
                }
                else if (control.GetType() == typeof(Button))
                {
                    control.BackColor = i_ButtonColor;
                }
                else if (control.GetType() == typeof(RadioButton))
                {
                    control.BackColor = i_BackColor;
                }
                else if (control.GetType() == typeof(TrackBar))
                {
                    control.BackColor = i_BackColor;
                }
                else
                {
                    control.BackColor = i_DefaultColor;
                }
                if (control.Controls.Count > 0)
                {
                    ComplexControlPainter innerComplexControlPainter = new ComplexControlPainter(control);
                    innerComplexControlPainter.changeColorScheme(
                        i_BackColor,
                        i_TextBoxAndListBoxColor,
                        i_ButtonColor,
                        i_DefaultColor);
                }
            }
        }
    }
}
