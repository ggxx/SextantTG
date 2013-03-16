using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;

namespace SextantTG.Win
{
    public partial class FindSubTourForm : Form
    {
        public SubTour SubTour { get; private set; }

        public FindSubTourForm(string userId)
        {
            InitializeComponent();

            this.bindingSource_Tour.DataSource = UIUtil.GetToursByUserId(userId).FindAll(delegate(Tour t) { return t.Status != 0; });
            this.listBox_Tour.DisplayMember = "TourName";
            this.listBox_Tour.ValueMember = "TourId";

            this.bindingSource_SubTour.DataSource = UIUtil.GetSubToursByTourId(this.listBox_Tour.SelectedValue.ToString());
            this.listBox_SubTour.DisplayMember = "SubTourName";
            this.listBox_SubTour.ValueMember = "SubTourId";
        }

        public FindSubTourForm(string userId, string tourId)
        {
            InitializeComponent();

            List<Tour> ds = new List<Tour>();
            ds.Add(UIUtil.GetTourByTourId(tourId));
            this.bindingSource_Tour.DataSource = ds.FindAll(delegate(Tour t) { return t.Status != 0; }); ;
            this.listBox_Tour.DisplayMember = "TourName";
            this.listBox_Tour.ValueMember = "TourId";

            this.bindingSource_SubTour.DataSource = UIUtil.GetSubToursByTourId(this.listBox_Tour.SelectedValue.ToString());
            this.listBox_SubTour.DisplayMember = "SubTourName";
            this.listBox_SubTour.ValueMember = "SubTourId";
        }

        public void SetListSelectedItem(string tourId, string subTourId)
        {
            this.listBox_Tour.SelectedValue = tourId;
            if (!string.IsNullOrEmpty(subTourId))
                this.listBox_SubTour.SelectedValue = subTourId;
        }

        private void listBox_Tour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox_Tour.SelectedValue != null)
            {
                this.bindingSource_SubTour.DataSource = UIUtil.GetSubToursByTourId(this.listBox_Tour.SelectedValue.ToString());
            }
            else
            {
                this.bindingSource_SubTour.DataSource = null;
            }
        }

        private void listBox_SubTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SubTour = this.bindingSource_SubTour.Current as SubTour;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
