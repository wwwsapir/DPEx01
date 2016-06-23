using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    public partial class ChooseGroupMembers : Form
    {

        public ListBox.SelectedIndexCollection SelectedIndices { get; set; }

        public string NewName { get; set; }

        public ChooseGroupMembers(List<IFilter> i_ListToChooseFrom)
        {
            InitializeComponent();
            this.listBoxGroupMembers.DisplayMember = "Name";
            this.listBoxGroupMembers.Items.Clear();

            for (int i = 1; i < i_ListToChooseFrom.Count; i++)
            {
                this.listBoxGroupMembers.Items.Add(i_ListToChooseFrom[i]);
            }
        }

        private void ChooseGroupMembers_Load(object sender, EventArgs e)
        {
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.listBoxGroupMembers.SelectedIndices.Count == 0)
            {
                MessageBox.Show(@"No group members selected!");
            }
            else if(this.textBoxName.Text == string.Empty)
            {
                MessageBox.Show(@"A name must be entered!");
            }
            else
            {
               this.DialogResult = DialogResult.OK;
                NewName = this.textBoxName.Text;
                SelectedIndices = this.listBoxGroupMembers.SelectedIndices;
               this.Close();
            }


        }
    }
}
