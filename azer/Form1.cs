using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace azer
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"server=desktop-gvadpv4\isaac;database=northwind;integrated security=true;");
        SqlDataAdapter dAdapter;
        DataSet dSet = new DataSet();
        DataTable dTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
            dAdapter = new SqlDataAdapter("select oD.OrderID,oD.UnitPrice,oD.Quantity from [Order Details] as oD where UnitPrice between 9 and 10 and Quantity between 10 and 11", con);
            //with DataSET
            //dAdapter.Fill(dSet,"oDetails");
            //DGV1.DataSource = dSet.Tables["oDetails"];

            //with DataTable
            dAdapter.Fill(dTable);
            DGV1.DataSource = dTable;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn champ = new DataGridViewTextBoxColumn();
            champ.HeaderText = "Montant";
            DGV1.Columns.Add(champ);
            //DGV1.Columns["Montant"].DisplayIndex = 1;
            // DGV1.Rows[3].Cells[3].Value = "kharbacha";
            //int quantity,rate;
            //int price = quantity * rate;
            //DGV1.Rows[e.RowIndex].Cells["price"].Value = price.ToString();
            //==================================================================================================================
            //          for (int i = 0; i < DGV1.Rows.Count-1;i++)
            //{
            //              int a = DGV1.Rows[i][0].va;
            //              int b = DGV1.Rows[i][1].value;

            //              int c = a * b;

            //              c = DGV1.Rows[i][2].value;


            //         }
            //==========================================================================
            //foreach (DataGridViewRow row in DGV1.Rows)
            //{
            //    //row.Cells[DGV1.Columns["Montant"].Index].Value = (Convert.ToDouble(row.Cells[DGV1.Columns["quantity"].Index].Value) * (Convert.ToDouble(row.Cells[DGV1.Columns["UnitPrice"].Index].Value)));

            //}

            double sum=0;
            for (int i = 0; i < DGV1.Rows.Count-1 ; i++)
            {
                
                //DGV1.Rows[i].Cells[5].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                DGV1.Rows[i].Cells[3].Value = double.Parse(DGV1.Rows[i].Cells[2].Value.ToString()) * double.Parse(DGV1.Rows[i].Cells[1].Value.ToString());
                sum++;
                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = sum;

                // DOESN'T WOOOORK ====>      DGV1.Rows[i].Cells["Montant"].Value = double.Parse(DGV1.Rows[i].Cells["quantity"].Value.ToString()) * double.Parse(DGV1.Rows[i].Cells["UnitPrice"].Value.ToString());
                DGV1.Rows[DGV1.Rows.Count-1].Cells[2].Value = "Somme:";
                DGV1.Rows[DGV1.Rows.Count-1].Cells[2].Style.Font = new Font("Arial", 20, FontStyle.Bold);
               
            }

            for (int i = 0; i < DGV1.Rows.Count - 1; i++)
            {

                sum += double.Parse(DGV1.Rows[DGV1.Rows.Count - 1].Cells[3].Value.ToString());

            }
           
            //DGV1.Rows[11].Cells[2].Value = "Somme:";
            //DGV1.Rows[11].Cells[2].Style.Font = new Font("Arial", 20, FontStyle.Bold);

        }
    }
}

