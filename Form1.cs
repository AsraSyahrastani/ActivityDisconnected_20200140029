using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Disconnected_PABD
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        private object hRDataSet;
        private object cmdAdd;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.dataSet1.empdetails);

            textcode.Enabled = false;
            textName.Enabled = false;
            textAddress.Enabled = false;
            textState.Enabled = false;
            textCountry.Enabled = false;
            cbdesignation.Enabled = false;
            cbdepartment.Enabled = false;

            cbdesignation.Items.Add("MANAGER");
            cbdesignation.Items.Add("AUTHOR");
            cbdesignation.Items.Add("Designer");
            cbdesignation.Items.Add("MARKETING");
            cbdesignation.Items.Add("FINANCE");
            cbdesignation.Items.Add("IDD");

            cmdsave.Enabled = false;
        }

        private void cmdadd_Click(object sender, EventArgs e)
        {
            cmdsave.Enabled = true;
            textName.Enabled = true;
            textAddress.Enabled = true;
            textState.Enabled = true;
            textCountry.Enabled = true;
            cbdesignation.Enabled = true;
            cbdepartment.Enabled = true;

            textName.Text = "";
            textAddress.Text = "";
            textState.Text = "";
            textCountry.Text = "";
            cbdesignation.Text = "";
            cbdepartment.Text = "";

            int ctr, len;
            string codeval;

            dt = dataSet1.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);

            if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                textcode.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                textcode.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                textcode.Text = "C" + ctr;
            }

            cmdadd.Enabled = false;

        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            dt = dataSet1.Tables["empdetails"];
            dr = dt.NewRow();

            dr[0] = textcode.Text;
            dr[1] = textName.Text;
            dr[2] = textAddress.Text;
            dr[3] = textState.Text;
            dr[4] = textCountry.Text;
            dr[5] = cbdesignation.Text;
            dr[6] = cbdepartment.Text;
            dt.Rows.Add(dr);

            empdetailsTableAdapter.Update(dataSet1);
            textcode.Text = System.Convert.ToString(dr[0]);
            textcode.Enabled = false;
            textName.Enabled = false;
            textAddress.Enabled = false;
            textState.Enabled = false;
            textCountry.Enabled = false;
            cbdesignation.Enabled = false;
            cbdepartment.Enabled = false;
            this.empdetailsTableAdapter.Fill(this.dataSet1.empdetails);
            cmdadd.Enabled = true;
            cmdsave.Enabled = false;
        }
    }
}
