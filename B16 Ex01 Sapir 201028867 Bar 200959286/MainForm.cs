using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{

    public partial class MainForm : Form
    {
        LoginResult m_user;

        public MainForm()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 30;    // The current maximum allowed by facebook graph for pages is 100
            m_user = FacebookService.Login("1085758691487251", "user_likes");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacebookObjectCollection<Page> likedPagesCollection = m_user.LoggedInUser.LikedPages;
            LabelLikedPages.Text = 
                "You have " + likedPagesCollection.Count + " inactive liked pages on Facebook:";
            FacebookObjectCollection<Post> latestPostsFromPage;
            foreach (Page likedPage in likedPagesCollection)
            {
                latestPostsFromPage = likedPage.Posts;
                bool isActive = false;
                foreach (Post pagePost in latestPostsFromPage)
                {
                    isActive = false;
                    int textBoxDaysToInactive;
                    bool isDaysTextBocValueValid = int.TryParse(TextBoxDaysToInactive.Text, out textBoxDaysToInactive);
                    if (!isDaysTextBocValueValid)
                    {
                        throw new NotImplementedException(); // TODO decide what to do in this case.
                        //TODO Maybe message window that tells the user to choose 
                    }
                    if (pagePost.CreatedTime.GetValueOrDefault() >
                        DateTime.Now - TimeSpan.FromDays(textBoxDaysToInactive))
                    {
                        isActive = true;
                        break;
                    }
                }
                if (!isActive)
                {
                    ListBoxLikedPages.Items.Add(likedPage.Name);
                }
            }
            
        }
    }
}
