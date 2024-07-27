using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ConstructionIceTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name = "", surname="",company="",ID="";

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr = null;
        public MainWindow()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddInput();
        }
        public void AddInput()
        {
            try
            {
                con.Open();
                string na = txtName.Text;
                if (String.IsNullOrEmpty(na))
                {
                    MessageBox.Show("Please enter your name...");
                }
                else
                {
                    name = na;
                }
                string su = txtSurname.Text;
                if (String.IsNullOrEmpty(su))
                {
                    MessageBox.Show("Please enter your surname...");
                }
                else
                {
                    surname = su;
                }
                string ids = txtID.Text;
                if (String.IsNullOrEmpty(na))
                {
                    MessageBox.Show("Please enter your ID...");
                }
                else
                {
                    ID = ids;
                }
                string com = txtCompany.Text;
                if (String.IsNullOrEmpty(na))
                {
                    MessageBox.Show("Please enter your company name...");
                }
                else
                {
                    company = com;
                }


                string command = String.Format("insert into Employee values('{0}','{1}','{2}','{3}')", name,surname,ID,company);
                cmd = new SqlCommand(command, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data submitted");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
