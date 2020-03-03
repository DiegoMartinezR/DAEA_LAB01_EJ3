using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PjConexion3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Diego"].ConnectionString);

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ListaProductos()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Productos");
                    dgProductos.DataSource = Da.Tables["Productos"];
                    lblproductos.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
