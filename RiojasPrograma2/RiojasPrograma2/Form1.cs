using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiojasPrograma2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mostrar todo");
            string id = "id_departamento";
            string nombre = "nombre_departamento";
            int registrosafectados = 0;
            registrosafectados = CargarDatos.EjecturaConsulta(textBox1.Text);
            AccionesComunes.Mensaje("Registros Afectados" + registrosafectados);
            AccionesComunes.LlenarCombo(textBox1.Text,comboBox1,id,nombre);
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            label1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
