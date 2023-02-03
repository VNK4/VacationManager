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
    public partial class MainMenu__CEO_ : Form
    {
        public MainMenu__CEO_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewUsers viewUsers = new ViewUsers();
            viewUsers.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewTeams viewTeams = new ViewTeams();
            viewTeams.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewProjects viewProjects = new ViewProjects();    
            viewProjects.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewVactions__CEO_ viewVacations = new ViewVactions__CEO_();
            viewVacations.Show();
        }
    }
}
