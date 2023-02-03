using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer_Forms_
{
    public partial class MainMenu__user_ : Form
    {
        public MainMenu__user_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateVacation create = new CreateVacation();
            create.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewVacations__User_ view = new ViewVacations__User_();
            view.Show();
        }
    }
}
