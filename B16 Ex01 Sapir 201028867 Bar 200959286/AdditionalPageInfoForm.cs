﻿using System;
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
    public partial class AdditionalPageInfoForm : Form
    {
        public AdditionalPageInfoForm(Page i_Page)
        {
            InitializeComponent();
            pageBindingSource.DataSource = i_Page;        
        }
    }
}
