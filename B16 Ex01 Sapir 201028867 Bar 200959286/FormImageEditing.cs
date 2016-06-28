using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Linq;

    public partial class FormImageEditing : Form
    {
        private const bool k_SetSelected = true;

        private const int k_FilterNone = 0;

        private static readonly int sr_ValueRange = 10;

        public Image CurrentImage { get; set; }

        public FilterGroup m_MainFilterGroup = FiltersManager.GetFiltersList();

        public FilterGroup m_CurrentFilterGroup;

        private IImageUploader m_ImageUploader;

        private readonly ComplexControlPainter r_ComplexControlPainter;

        public FormImageEditing(Image i_ImageToEdit, IImageUploader i_ImageUploader)
        {
            m_CurrentFilterGroup = this.m_MainFilterGroup;
            m_ImageUploader = i_ImageUploader;
            r_ComplexControlPainter = new ComplexControlPainter(this);
            InitializeComponent();
            this.loadFiltersToListBox();

            // check if image was given
            UseGivenPicture(i_ImageToEdit);
        }

        public void UseGivenPicture(Image i_ImageToEdit)
        {
            CurrentImage = i_ImageToEdit;
            pictureBoxFilteredPicture.Image = CurrentImage;
            pictureBoxFilteredPicture.Show();
            listBoxUserFilters.SelectedIndex = k_FilterNone;
            resetColorControls();
        }

        private void loadFiltersToListBox()
        {
            if (this.m_CurrentFilterGroup.FilterList.Any())
            {
                this.listBoxUserFilters.Items.Clear();
                foreach (IFilter filter in this.m_CurrentFilterGroup.FilterList)
                {
                    this.listBoxUserFilters.Items.Add(filter.Name);
                }
            }
        }

        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();
        }

        private void trackBarGreen_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();

        }

        private void trackBarBlue_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();
        }

        private void trackBarSaturation_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();

        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            this.readjustImageAndShow();
        }

        private void readjustImageAndShow()
        {
            IFilter chosenFilter;
            chosenFilter = new Filter(new ColorMatrix());

            int chosenIndex = this.listBoxUserFilters.SelectedIndex;
            if (chosenIndex != ListBox.NoMatches)
            {
                chosenFilter = this.m_CurrentFilterGroup.FilterList[chosenIndex];
                chosenFilter.SetFilter(this.getFilterValuesFromSliders());
            }

            //// Adjust image
            Bitmap filteredImage = ColorMatrixUtilities.AdjustImage(chosenFilter.GetColorMatrixWithAdjustments(), this.CurrentImage);
            this.pictureBoxFilteredPicture.Image = filteredImage;
            this.pictureBoxFilteredPicture.Show();
        }

        private void resetColorControls()
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control innerControl in control.Controls)
                    {
                        TrackBar trackBarBar = innerControl as TrackBar;
                        if (trackBarBar != null)
                        {
                            trackBarBar.Value = 0;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.resetColorControls();
            readjustImageAndShow();
        }

        private void listBoxUserDefinedFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int chosenIndex = this.listBoxUserFilters.SelectedIndex;
            if (chosenIndex != ListBox.NoMatches)
            {
                IFilter selectedFilter = this.m_CurrentFilterGroup.FilterList[chosenIndex];
                ColorMatrix generatedColorMatrix = selectedFilter.GetColorMatrixWithAdjustments();
                setSlidersValues(selectedFilter.FilterValues);
                this.pictureBoxFilteredPicture.Image = ColorMatrixUtilities.AdjustImage(generatedColorMatrix, this.CurrentImage);

                if (chosenIndex != 0)
                {
                    this.textBoxNewFilterName.Text = string.Empty;
                }
            }
        }

        private void buttonSaveFilters_Click(object sender, EventArgs e)
        {
            try
            {
                FiltersManager.SaveFilterListToFile(FiltersManager.GetFiltersList());
                MessageBox.Show(
                    @"Filters Saved succesfully!",
                    @"Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    @"We couldn't save your filter data locally..Please check your permission settings",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private FilterValues getFilterValuesFromSliders()
        {
            return new FilterValues(
                this.trackBarSaturation.Value,
                this.trackBarBrightness.Value,
                this.trackBarContrast.Value,
                this.trackBarRed.Value,
                this.trackBarGreen.Value,
                this.trackBarBlue.Value,
                sr_ValueRange);
        }

        private void setSlidersValues(FilterValues i_FilterValues)
        {
            this.trackBarSaturation.Value = (int)i_FilterValues.SaturationValue;
            this.trackBarBrightness.Value = (int)i_FilterValues.BrightnessValue;
            this.trackBarContrast.Value = (int)i_FilterValues.ContrastValue;
            this.trackBarRed.Value = (int)i_FilterValues.RedValue;
            this.trackBarGreen.Value = (int)i_FilterValues.GreenValue;
            this.trackBarBlue.Value = (int)i_FilterValues.BlueValue;
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            if (this.textBoxNewFilterName.Text != string.Empty)
            {
                int chosenIndex = this.listBoxUserFilters.SelectedIndex;
                if (chosenIndex != ListBox.NoMatches)
                {
                    IFilter newFilter;
                    IFilter selectedFilter = this.m_CurrentFilterGroup.FilterList[chosenIndex];
                    newFilter = new Filter(
                        selectedFilter.GetColorMatrixWithAdjustments(),
                        this.textBoxNewFilterName.Text);

                    // create filter
                    this.textBoxNewFilterName.Text = string.Empty;

                    // add filter to list
                    this.m_CurrentFilterGroup.FilterList.Add(newFilter);
                    this.loadFiltersToListBox();
                }
            }
            else
            {
                MessageBox.Show(
                    @"You Must Choose a Name For The Filter",
                    @"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_ImageUploader.UploadImage(this.pictureBoxFilteredPicture.Image, this.textBoxPostTitle.Text);
                MessageBox.Show(@"Upload Completed!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Upload Faild!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxUserFilters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxUserFilters.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                IFilter selectedFilter = this.m_CurrentFilterGroup.FilterList[index];
                FilterGroup filterGroup = selectedFilter as FilterGroup;

                if (filterGroup != null)
                {
                    m_CurrentFilterGroup = filterGroup;
                    loadFiltersToListBox();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChooseGroupMembers chooseGroupDialog = new ChooseGroupMembers(this.m_CurrentFilterGroup.FilterList);
            if (chooseGroupDialog.ShowDialog() == DialogResult.OK)
            {
                List<IFilter> newFilterList = new List<IFilter>();
                foreach (int index in chooseGroupDialog.SelectedIndices)
                {
                    newFilterList.Add(this.m_CurrentFilterGroup.FilterList[index + 1]);
                }

                foreach (IFilter filter in newFilterList)
                {
                    this.m_CurrentFilterGroup.FilterList.Remove(filter);
                }

                this.m_CurrentFilterGroup.FilterList.Add(new FilterGroup(newFilterList, this.m_CurrentFilterGroup, chooseGroupDialog.NewName));
                this.loadFiltersToListBox();
                this.listBoxUserFilters.SetSelected(0, k_SetSelected);
            }
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            int chosenIndex = this.listBoxUserFilters.SelectedIndex;
            if (chosenIndex != ListBox.NoMatches)
            {
                IFilter selectedFilter = this.m_CurrentFilterGroup.FilterList[chosenIndex];
                selectedFilter.ApplyFilter();
                setSlidersValues(selectedFilter.FilterValues);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            bool v_NotCaseSensitive = true;
            if (this.textBoxSearch.Text == string.Empty)
            {
                this.m_CurrentFilterGroup = this.m_MainFilterGroup;
                this.loadFiltersToListBox();
            }
            else
            {
                var queryResult = from IFilter filter in this.m_MainFilterGroup
                                  where filter.Name.StartsWith(this.textBoxSearch.Text, v_NotCaseSensitive, null) || filter.Name.StartsWith("<< " + this.textBoxSearch.Text, v_NotCaseSensitive, null)
                                  select filter;
                this.listBoxUserFilters.Items.Clear();
                FilterGroup searchResult = new FilterGroup(queryResult.ToList(), null, "Search Result");
                this.m_CurrentFilterGroup = searchResult;
                this.loadFiltersToListBox();
            }
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