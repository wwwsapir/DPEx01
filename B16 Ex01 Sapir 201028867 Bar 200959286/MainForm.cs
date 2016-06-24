using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Threading;

using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public partial class MainForm : Form
    {
        private readonly LoginResult r_Result;
        private readonly bool r_LoggedIn;
        private FacebookObjectCollection<Photo> m_ProfilePicturesFromAlbum;
        private int? m_CurrentPhotoIndexInAlbum = null;
        private Thread m_FormImgaeEditingThread;
        private FormImageEditing m_FormImageEditing;
        private FacebookObjectCollection<Page> m_FilteredLikedPages = new FacebookObjectCollection<Page>();
        private FacebookObjectCollection<Page> m_LikedPagesCollection;
        private int m_DaysToInactive;
        private int m_LikesToFilter;
        private Func<Page, bool> m_PagesFilterer;
        private ComplexControlPainter m_ComplexControlPainter;

        public MainForm()
        {
            InitializeComponent();
            m_ComplexControlPainter = new ComplexControlPainter(this);
            FacebookService.s_CollectionLimit = 30;
            r_Result = FacebookService.Login(
                                        "1085758691487251",
                                        "public_profile",
                                        "user_photos",
                                        "user_likes",
                                        "publish_actions");
            r_LoggedIn = r_Result.AccessToken != null;
        }

        public bool LoggedIn
        {
            get { return r_LoggedIn; }
        }

        private void buttonProfilePicture_Click(object i_Sender, EventArgs e)
        {
            FacebookObjectCollection<Album> photoAlbums = r_Result.LoggedInUser.Albums;
            foreach (Album album in photoAlbums)
            {
                if (album.Name == "Profile Pictures")
                {
                    m_ProfilePicturesFromAlbum = album.Photos;
                    break;
                }
            }
            m_CurrentPhotoIndexInAlbum = 0;
            if (m_ProfilePicturesFromAlbum != null)
            {
                pictureBoxProfilePicture.LoadAsync(
                    m_ProfilePicturesFromAlbum[m_CurrentPhotoIndexInAlbum.Value].PictureNormalURL);
            }
            else
            {
                MessageBox.Show(@"Couldn't find 'Profile Pictures' album");
            }

            (i_Sender as Button).Enabled = false;
        }

        private void buttonPrevPicture_Click(object i_Sender, EventArgs e)
        {
            const bool v_Next = true;
            changePresentedPicture(!v_Next);
        }

        private void buttonNextPicture_Click(object i_Sender, EventArgs e)
        {
            const bool v_Next = true;
            changePresentedPicture(v_Next);
        }

        private void changePresentedPicture(bool i_Next)
        {   
            //Check if the photos are shown yet
            if (!m_CurrentPhotoIndexInAlbum.HasValue)
            {
                return;
            }
            // Changes the presented profile picture to next or previous picture in the album
            if (i_Next)
            {
                ++m_CurrentPhotoIndexInAlbum;
            }
            else
            {
                m_CurrentPhotoIndexInAlbum--;
            }

            // If we have reached the end - go back to the beginning (and vise versa):
            m_CurrentPhotoIndexInAlbum = m_ProfilePicturesFromAlbum.Count + m_CurrentPhotoIndexInAlbum;
            m_CurrentPhotoIndexInAlbum = 
                m_CurrentPhotoIndexInAlbum % m_ProfilePicturesFromAlbum.Count;  
            Photo currentPicture = m_ProfilePicturesFromAlbum[m_CurrentPhotoIndexInAlbum.Value];
            pictureBoxProfilePicture.LoadAsync(currentPicture.PictureNormalURL);
            if (m_CurrentPhotoIndexInAlbum != 0)
            {
                labelProfilePictureDate.Text = @"Profile Picture From " + 
                    currentPicture.CreatedTime.Value.Date.ToShortDateString();
            }
            else
            {
                labelProfilePictureDate.Text = @"Latest Profile Picture";
            }
        }

        private void buttonButtonShowLikedPages_Click(object i_Sender, EventArgs e)
        {
            m_LikedPagesCollection = r_Result.LoggedInUser.LikedPages;
            if (radioButtonInactive.Checked)
            {
                bool isDaysTextBoxValueValid = int.TryParse(this.textBoxDaysToInactive.Text, out m_DaysToInactive);
                if (!isDaysTextBoxValueValid || m_DaysToInactive < 1 || m_DaysToInactive > 60)
                {
                    MessageBox.Show(@"Please insert a number between 1 to 60 (days).");
                    return;
                }
                m_PagesFilterer = isPageActive; // Check inactive days strategy
            }
            else if (radioButtonLikes.Checked)
            {
                bool isLikesTextBoxValueValid = int.TryParse(this.textBoxFilterLikes.Text, out m_LikesToFilter);
                if (!isLikesTextBoxValueValid || m_LikesToFilter < 1 || m_LikesToFilter > 9999)
                {
                    MessageBox.Show(@"Please insert a number between 1 to 9999 (likes).");
                    return;
                }
                m_PagesFilterer = (i_Page) => i_Page.LikesCount <= m_LikesToFilter; // Check Likes Number Strategy
            }
            else if (radioButtonEnglish.Checked)
            {
                m_PagesFilterer = (i_Page) => !PageLanguageEssentials.IsPageInEnglish(i_Page);   // Hebrew Pages Only Strategy
            }
            else
            {
                // else: radioButtonHebrew.Checked == True
                m_PagesFilterer = PageLanguageEssentials.IsPageInEnglish;   // English Pages Only Strategy
            }

            m_FilteredLikedPages.Clear();
            buttonShowLikedPages.Enabled = false;
            textBoxDaysToInactive.Enabled = false;
            textBoxFilterLikes.Enabled = false;
            radioButtonInactive.Enabled = false;
            radioButtonLikes.Enabled = false;
            radioButtonEnglish.Enabled = false;
            radioButtonHebrew.Enabled = false;
            new Thread(addFilteredPagesToList).Start();
        }

        private void addFilteredPagesToList()
        {
            FacebookPagesFilterer pagesFilterer = new FacebookPagesFilterer(m_PagesFilterer);
            m_FilteredLikedPages = pagesFilterer.FilterPagesCollection(m_LikedPagesCollection);
            fillPagesList();
            labelLikedPages.Invoke(new Action(() =>
                labelLikedPages.Text =
                @"You have " + m_FilteredLikedPages.Count + @" inactive liked pages on Facebook:"));
        }

        private bool isPageActive(Page i_LikedPage)
        {

            FacebookObjectCollection<Post> latestPostsFromPage = i_LikedPage.Posts;
            bool isActive = false;
            foreach (Post pagePost in latestPostsFromPage)
            {
                if (pagePost.CreatedTime.GetValueOrDefault() >
                    DateTime.Now - TimeSpan.FromDays(m_DaysToInactive))
                {
                    isActive = true;
                    break;
                }
            }

            return isActive;
        }

        private void fillPagesList()
        {
             if (!listBoxLikedPages.InvokeRequired)
             {
                pageBindingSource.DataSource = m_FilteredLikedPages;
             }
             else
             {
                 // In case of cross-thread operation, invoking the binding code on the listBox's thread:
                 listBoxLikedPages.Invoke(new Action(() => 
                     pageBindingSource.DataSource = m_FilteredLikedPages));
             }
        }


        private void startFormImgaeEditing()
        {
            m_FormImageEditing = new FormImageEditing(this.pictureBoxProfilePicture.Image, new FacebookImageUploader(this.r_Result.LoggedInUser));
            m_FormImageEditing.ShowDialog();
        }

        private void buttonEditImage_Click(object sender, EventArgs e)
        {
            if (!m_CurrentPhotoIndexInAlbum.HasValue)
            {
                MessageBox.Show("No image to edit!");
                return;
            }
            if (m_FormImgaeEditingThread == null)
            {
                m_FormImgaeEditingThread = new Thread(startFormImgaeEditing);
                m_FormImgaeEditingThread.Start();
            }
            else if (!m_FormImgaeEditingThread.IsAlive)
            {
                m_FormImgaeEditingThread.Abort();
                m_FormImgaeEditingThread = new Thread(startFormImgaeEditing);
                m_FormImgaeEditingThread.Start();
            }
            else
            {
                m_FormImageEditing.Invoke(new Action(
                        () =>
                            {
                                m_FormImageEditing.UseGivenPicture(pictureBoxProfilePicture.Image);
                            }
                                          )         );
            }
        }

        private void buttonAdditionalPageInfo_Click(object sender, EventArgs e)
        {
            if (listBoxLikedPages.SelectedItem == null)
            {
                MessageBox.Show("Please select a page first");
                return;
            }
            AdditionalPageInfoForm additionalPageInfoForm = 
                AdditionalPageInfoForm.CreateLanguageCompatibleAdditionalPageInfoForm(
                listBoxLikedPages.SelectedItem as Page);
            additionalPageInfoForm.ShowDialog();
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            m_ComplexControlPainter.ChangeToRedColorScheme();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            m_ComplexControlPainter.ChangeToBlueColorScheme();
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            m_ComplexControlPainter.ChangeToGreenColorScheme();
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            m_ComplexControlPainter.ChangeToYellowColorScheme();
        }
    }
}
