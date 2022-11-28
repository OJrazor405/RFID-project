using System.Configuration;
using System.Threading;

namespace Project_Data_Logger
{
    public partial class LoggerUI : Form
    {
        DBhandler dbHandler;
        Access access;
        public LoggerUI()
        {
            InitializeComponent();
        }

        public void IndicateAccess(string cardCode, TextBox textBox)
        {
            try
            {
                dbHandler = new DBhandler(cardCode);
                access = new Access(dbHandler.AccessBool, textBox);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtCardCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string cardCode = txtCardCode.Text;

                IndicateAccess(cardCode, txtAccess);

                txtCardCode.Text = "";
                txtCardCode.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}