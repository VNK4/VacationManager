using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PresentationLayer_Forms_
{
    public partial class Login : Form
    {
        private IdentityContext _identityContext;
        private User user;
        public Login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}