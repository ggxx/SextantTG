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
    public partial class CommentEditForm : Form
    {
        private int kind = 0;
        private string targetId = "";

        public CommentEditForm(Sights sights)
        {
            InitializeComponent();
            this.kind = 1;
            this.targetId = sights.SightsId;
        }

        public CommentEditForm(User user)
        {
            InitializeComponent();
            this.kind = 2;
        }

        public CommentEditForm(Picture picture)
        {
            InitializeComponent();
            this.kind = 3;
        }

        public CommentEditForm(Tour tour)
        {
            InitializeComponent();
            this.kind = 4;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            bool val;
            string msg;

            switch (this.kind)
            {
                case 1:
                    SightsComment comment = new SightsComment();
#error Now I am here
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }


    }
}
