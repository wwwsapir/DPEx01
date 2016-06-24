using System.Dynamic;
using System.Windows.Forms;

using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    class PageLanguageEssentials
    {
        public static bool IsPageInEnglish(Page i_CurrentPage)
        {
            // Choose the language according to both description and name of the page
            if (i_CurrentPage.Description != null)
            {
                // Choose the language according to both description and name of the page
                if (isTextInEnglish(i_CurrentPage.Name) && isTextInEnglish(i_CurrentPage.Description))
                {
                    return true;
                }
            }
            else
            {
                // No description - Choose language according to name only
                if (isTextInEnglish(i_CurrentPage.Name))
                {
                    return true;
                }
            }

            // Default is Hebrew
            return false;
        }

        private static bool isTextInEnglish(string i_TextToCheck)
        {
            bool hebrewLetterFound = false;
            foreach (char character in i_TextToCheck)
            {
                if (character >= 'א' && character <= 'ת')
                {
                    hebrewLetterFound = true;
                    break;
                }
            }

            return !hebrewLetterFound;
        }
    }
}
