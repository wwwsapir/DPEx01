using System;
using System.Windows.Forms;
using System.Threading;

using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public partial class MainForm : Form
    {
        private LoginResult m_Result;
        private bool m_LoggedIn;
        private FacebookObjectCollection<Photo> m_ProfilePicturesFromAlbum;
        private int? m_CurrentPhotoIndexInAlbum = null;
        private Thread m_FormImgaeEditingThread;
        private FormImageEditing m_FormImageEditing;

        public MainForm()
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 30;
            m_Result = FacebookService.Login(
                                        "1085758691487251",
                                        "public_profile",
                                        "user_photos",
                                        "user_likes",
                                        "publish_actions");
            m_LoggedIn = m_Result.AccessToken != null;
        }

        public bool LoggedIn
        {
            get { return m_LoggedIn; }
        }

        private void buttonProfilePicture_Click(object i_Sender, EventArgs e)
        {
            FacebookObjectCollection<Album> photoAlbums = m_Result.LoggedInUser.Albums;
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
            FacebookObjectCollection<Page> likedPagesCollection = m_Result.LoggedInUser.LikedPages;
            int numOfDaysToInactive;
            bool isDaysTextBocValueValid = int.TryParse(this.textBoxDaysToInactive.Text, out numOfDaysToInactive);
            if (!isDaysTextBocValueValid ||
                numOfDaysToInactive < 1 ||
                numOfDaysToInactive > 60)
            {
                MessageBox.Show(@"Please insert a number between 1 to 60.");
                return;
            }

            listBoxLikedPages.Items.Clear();
            addInactivePagedToListBox(likedPagesCollection, numOfDaysToInactive);
        }

        private void addInactivePagedToListBox(
            FacebookObjectCollection<Page> i_LikedPagesCollection,
            int i_DaysToInactive)
        {
            FacebookObjectCollection<Post> latestPostsFromPage;
            int pagesCounter = 0;
            foreach (Page likedPage in i_LikedPagesCollection)
            {
                latestPostsFromPage = likedPage.Posts;
                bool isActive = false;
                foreach (Post pagePost in latestPostsFromPage)
                {
                    if (pagePost.CreatedTime.GetValueOrDefault() >
                        DateTime.Now - TimeSpan.FromDays(i_DaysToInactive))
                    {
                        isActive = true;
                        break;
                    }
                }

                if (!isActive)
                {
                    listBoxLikedPages.Items.Add(likedPage.Name);
                    pagesCounter++;
                }
            }

            labelLikedPages.Text =
                @"You have " + pagesCounter + @" inactive liked pages on Facebook:";
        }

        private void startFormImgaeEditing()
        {
            m_FormImageEditing = new FormImageEditing(this.pictureBoxProfilePicture.Image, this.m_Result.LoggedInUser);
            m_FormImageEditing.ShowDialog();
        }

        private void buttonEditImage_Click(object sender, EventArgs e)
        {
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
    }
}
