using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fogLampConfigurationTool
{
    public partial class Form1 : Form
    {
        DataSet configData;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            configData = dal.GetConfiguration();
            // List<Config> clist=dal.GetConfiguration(); // NORBERT PUT HERE
            gridViewConfigValue.DataSource = configData.Tables[0]; // Get the first Table from dataset
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            dal.SaveConfiguration(configData);
        }



    }
}
