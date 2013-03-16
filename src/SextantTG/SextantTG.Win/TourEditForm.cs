using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;
using SextantTG.Util;

namespace SextantTG.Win
{
    public partial class TourEditForm : Form
    {
        private string tourId = string.Empty;
        private string userId = string.Empty;
        //private List<SubTour> subTours = null;
        private List<SubTour> removedSubTours = null;
        private Dictionary<int, string> statusDict = null;
        private Tour tour = null;

        public TourEditForm()
        {
            InitializeComponent();
            removedSubTours = new List<SubTour>();
            statusDict = UIUtil.GetTourStatusDict();

            foreach (KeyValuePair<int, string> kvp in statusDict)
            {
                this.comboBox_Status.Items.Add(kvp.Value);
            }

            this.dataGridView_SubTour.AutoGenerateColumns = true;
            this.bindingSource.DataSource = new List<SubTour>();
        }

        public void SetTour(Tour tour)
        {
            //string status;
            //statusDict.TryGetValue(tour.Status.Value, out status);
            this.tour = tour;
            this.textBox_TourName.Text = tour.TourName;
            this.dateTimePicker_Begin.Value = tour.BeginDate.Value;
            this.dateTimePicker_End.Value = tour.EndDate.Value;
            this.numericUpDown_Cost.Value = CustomTypeConverter.ToInt32Null(tour.Cost, true).Value;
            this.comboBox_Status.SelectedIndex = tour.Status.Value;
            this.textBox_Memos.Text = tour.Memos;

            this.bindingSource.DataSource = UIUtil.GetSubToursByTourId(tour.TourId);
        }

        private void TourEditForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            using (SubTourEditForm form = new SubTourEditForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    form.SubTour.TourId = tourId;
                    this.bindingSource.Add(form.SubTour);
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (this.bindingSource.Current != null)
            {
                using (SubTourEditForm form = new SubTourEditForm())
                {
                    form.SetSubTour(this.bindingSource.Current as SubTour);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.bindingSource.Remove(this.bindingSource.Current as SubTour);
                        this.bindingSource.Add(form.SubTour);
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.bindingSource.Current != null)
            {
                SubTour subTour = this.bindingSource.Current as SubTour;
                if (!string.IsNullOrEmpty(subTour.SubTourId))
                {
                    this.removedSubTours.Add(subTour);
                }
                this.bindingSource.Remove(subTour);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            List<SubTour> subTours = this.bindingSource.DataSource as List<SubTour>;
            if (string.IsNullOrEmpty(this.textBox_TourName.Text.Trim()))
            {
                MessageBox.Show("旅行名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.comboBox_Status.SelectedIndex < 0)
            {
                MessageBox.Show("旅行状态不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (subTours.Count < 1)
            {
                MessageBox.Show("至少填写一项行程", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tour == null)
            {
                tour = new Tour();
                tour.UserId = Config.AppConfig.User.UserId;
            }

            tour.TourName = this.textBox_TourName.Text.Trim();
            tour.BeginDate = this.dateTimePicker_Begin.Value.Date;
            tour.EndDate = this.dateTimePicker_End.Value.Date;
            tour.Cost = (int?)this.numericUpDown_Cost.Value;
            tour.Status = this.comboBox_Status.SelectedIndex;
            tour.Memos = this.textBox_Memos.Text;

            string msg;
            if (UIUtil.SaveTour(tour, subTours, removedSubTours, out msg))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败\r\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
