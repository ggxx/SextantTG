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
    public partial class ViewTourForm : Form
    {
        public ViewTourForm()
        {
            InitializeComponent();
        }

        private void ViewTourForm_Load(object sender, EventArgs e)
        {
            if (Config.AppConfig.User == null)
            {
                this.tabControl1.TabPages.Remove(tabPage4);
            }
            else
            {

            }

            this.Column_ST_SightsId.DisplayMember = "SightsName";
            this.Column_ST_SightsId.ValueMember = "SightsId";
            this.Column_ST_SightsId.DataSource = UIUtil.GetSights();

            this.Column_C_CommentUserId.DisplayMember = "LoginName";
            this.Column_C_CommentUserId.ValueMember = "UserId";
            this.Column_C_CommentUserId.DataSource = UIUtil.GetUsers();

            this.Column_B_SightsId.DisplayMember = "SightsName";
            this.Column_B_SightsId.ValueMember = "SightsId";
            this.Column_B_SightsId.DataSource = UIUtil.GetSights();

            this.Column_B_SubTourId.DisplayMember = "SubTourName";
            this.Column_B_SubTourId.ValueMember = "SubTourId";

            this.Column_B_TourId.DisplayMember = "TourName";
            this.Column_B_TourId.ValueMember = "TourId";

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.comboBox_City.DisplayMember = "CityName";
            this.comboBox_City.ValueMember = "CityId";

            this.comboBox_Sights.DisplayMember = "SightsName";
            this.comboBox_Sights.ValueMember = "SightsId";

            this.listBox_Tour.DisplayMember = "TourName";
            this.listBox_Tour.ValueMember = "TourId";

            List<Country> countries = UIUtil.GetCountries();
            Country country = new Country();
            country.CountryId = "*";
            country.CountryName = "<全部>";
            countries.Insert(0, country);
            this.comboBox_Country.DataSource = countries;
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                if (comboBox_Country.SelectedValue.ToString() != "*")
                {
                    List<Province> provinces = UIUtil.GetProvincesByCountryId(comboBox_Country.SelectedValue.ToString());
                    Province province = new Province();
                    province.ProvinceId = "*";
                    province.ProvinceName = "<全部>";
                    provinces.Insert(0, province);
                    this.comboBox_Province.DataSource = provinces;
                }
                else
                {
                    List<Province> provinces = UIUtil.GetProvinces();
                    Province province = new Province();
                    province.ProvinceId = "*";
                    province.ProvinceName = "<全部>";
                    provinces.Insert(0, province);
                    this.comboBox_Province.DataSource = provinces;
                }
            }
            else
            {
                this.comboBox_Province.DataSource = null;
                this.comboBox_City.DataSource = null;
            }
        }

        private void comboBox_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Province.SelectedValue != null)
            {
                if (comboBox_Province.SelectedValue.ToString() != "*")
                {
                    List<City> cities = UIUtil.GetCitiesByProvinceId(comboBox_Province.SelectedValue.ToString());
                    City city = new City();
                    city.CityId = "*";
                    city.CityName = "<全部>";
                    cities.Insert(0, city);
                    this.comboBox_City.DataSource = cities;
                }
                else
                {
                    if (comboBox_Country.SelectedValue.ToString() != "*")
                    {
                        List<City> cities = UIUtil.GetCitiesByCountryId(comboBox_Country.SelectedValue.ToString());
                        City city = new City();
                        city.CityId = "*";
                        city.CityName = "<全部>";
                        cities.Insert(0, city);
                        this.comboBox_City.DataSource = cities;
                    }
                    else
                    {
                        List<City> cities = UIUtil.GetCities();
                        City city = new City();
                        city.CityId = "*";
                        city.CityName = "<全部>";
                        cities.Insert(0, city);
                        this.comboBox_City.DataSource = cities;
                    }
                }
            }
            else
            {
                this.comboBox_City.DataSource = null;
            }
        }

        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_City.SelectedValue != null)
            {
                if (comboBox_City.SelectedValue.ToString() != "*")
                {
                    List<Sights> sights = UIUtil.GetSightsByCityId(comboBox_City.SelectedValue.ToString());
                    Sights s = new Sights();
                    s.SightsId = "*";
                    s.SightsName = "<全部>";
                    sights.Insert(0, s);
                    comboBox_Sights.DataSource = sights;
                }
                else
                {
                    if (comboBox_Province.SelectedValue.ToString() != "*")
                    {
                        List<Sights> sights = UIUtil.GetSightsByProvinceId(comboBox_Province.SelectedValue.ToString());
                        Sights s = new Sights();
                        s.SightsId = "*";
                        s.SightsName = "<全部>";
                        sights.Insert(0, s);
                        comboBox_Sights.DataSource = sights;
                    }
                    else
                    {
                        if (comboBox_Country.SelectedValue.ToString() != "*")
                        {
                            List<Sights> sights = UIUtil.GetSightsByCountryId(comboBox_Country.SelectedValue.ToString());
                            Sights s = new Sights();
                            s.SightsId = "*";
                            s.SightsName = "<全部>";
                            sights.Insert(0, s);
                            comboBox_Sights.DataSource = sights;
                        }
                        else
                        {
                            List<Sights> sights = UIUtil.GetSights();
                            Sights s = new Sights();
                            s.SightsId = "*";
                            s.SightsName = "<全部>";
                            sights.Insert(0, s);
                            comboBox_Sights.DataSource = sights;
                        }
                    }
                }
            }
            else
            {
                comboBox_Sights.DataSource = null;
            }
        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            if (this.radioButton_Sights.Checked)
            {
                if (this.comboBox_Sights.SelectedValue != null && this.comboBox_Sights.SelectedValue.ToString() != "*")
                {
                    this.listBox_Tour.DataSource = UIUtil.GetToursBySightsId(this.comboBox_Sights.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("请指定一个景点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (this.radioButton_Date.Checked)
            {
                if (this.dateTimePicker.Value > DateTime.MinValue)
                {
                    this.listBox_Tour.DataSource = UIUtil.GetToursByDate(this.dateTimePicker.Value);
                }
                else
                {
                    MessageBox.Show("请指定一个有效的日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (this.radioButton_Both.Checked)
            {
                if (this.comboBox_Sights.SelectedValue != null && this.comboBox_Sights.SelectedValue.ToString() != "*")
                {
                    if (this.dateTimePicker.Value > DateTime.MinValue)
                    {
                        this.listBox_Tour.DataSource = UIUtil.GetToursBySightsIdAndDate(this.comboBox_Sights.SelectedValue.ToString(), this.dateTimePicker.Value);
                    }
                    else
                    {
                        MessageBox.Show("请指定一个有效的日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("请指定一个景点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("至少选择一种查询方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void listBox_Tour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox_Tour.SelectedValue != null)
            {
                BindItem(this.listBox_Tour.SelectedItem as Tour);
            }
            else
            {
                ClearBindItem();
            }
        }

        private void BindItem(Tour tour)
        {
            this.bindingSource_Blog.DataSource = null;

            List<Tour> ds = new List<Tour>();
            ds.Add(tour);
            this.Column_B_TourId.DataSource = ds;
            this.Column_B_SubTourId.DataSource = UIUtil.GetSubToursByTourId(tour.TourId);

            string status = string.Empty;
            UIUtil.GetTourStatusDict().TryGetValue(tour.Status.Value, out status);

            this.textBox_TourName.Text = tour.TourName;
            this.textBox_User.Text = UIUtil.GetUserByUserId(tour.UserId).LoginName;
            this.textBox_Cost.Text = CustomTypeConverter.ToString(tour.Cost, "n2");
            this.textBox_BeginDate.Text = CustomTypeConverter.ToString(tour.BeginDate, "yyyy-MM-dd");
            this.textBox_EndDate.Text = CustomTypeConverter.ToString(tour.EndDate, "yyyy-MM-dd");
            this.textBox_Status.Text = status;
            this.textBox_Memos.Text = tour.Memos;

            //
            //this.stgReadonlyPictures.SetPicturesForTour(tour.TourId);

            //
            this.bindingSource_SubTour.DataSource = UIUtil.GetSubToursByTourId(tour.TourId);

            //
            this.bindingSource_Comment.DataSource = UIUtil.GetTourCommentsByTourId(tour.TourId);

            //
            this.bindingSource_Blog.DataSource = UIUtil.GetBlogsByTourId(tour.TourId);
        }

        private void ClearBindItem()
        {
            this.textBox_TourName.Text = string.Empty;
            this.textBox_User.Text = string.Empty;
            this.textBox_Cost.Text = string.Empty;
            this.textBox_BeginDate.Text = string.Empty;
            this.textBox_EndDate.Text = string.Empty;
            this.textBox_Status.Text = string.Empty;
            this.textBox_Memos.Text = string.Empty;

            //
            //this.stgReadonlyPictures.SetPicturesForTour(tour.TourId);

            //
            this.dataGridView_SubTour.AutoGenerateColumns = true;
            this.bindingSource_SubTour.DataSource = null;

            //
            this.dataGridView_Comment.AutoGenerateColumns = true;
            this.bindingSource_Comment.DataSource = null;

            //
            this.dataGridView_Blog.AutoGenerateColumns = true;
            this.bindingSource_Blog.DataSource = null;
        }

        private void button_Comment_Click(object sender, EventArgs e)
        {
            if (listBox_Tour.SelectedItem != null)
            {
                using (CommentEditForm form = new CommentEditForm(this.listBox_Tour.SelectedItem as Tour))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_Blog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.bindingSource_Blog.Current != null)
            {
                using (BlogEditForm form = new BlogEditForm(this.bindingSource_Blog.Current as Blog, false))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindItem(this.listBox_Tour.SelectedItem as Tour);
                    }
                }
            }
        }
    }
}
