using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiojasPrograma2
{
    internal class AccionesComunes
    {
        static ListViewItem obj;
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void LlenarCombo(string consulta, ComboBox combo, string id, string nombre,DataGridView dgv)
        {
            DataTable dt;
            dt = CargarDatos.EjecutarSeleccion(consulta);

            //  dt.Rows.Add(0, "Mostrar TODOS");
            // combo.Items.Clear();
            if (dt == null)
            {
                return;
            }
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Mostrar Todos";
            
            dt.Rows.InsertAt(dr,0);
            combo.DataSource = dt;
            combo.DisplayMember = nombre;
            combo.ValueMember = id;
            dgv.DataSource = dt;
            combo.SelectedValue = 0;
            Properties.Settings.Default.prueba = combo.SelectedValue.ToString();
            MessageBox.Show(Properties.Settings.Default.prueba);
            Properties.Settings.Default.prueba2 = true;
        }
        public static object LlenarDataGridView(string consulta, DataGridView dgv)
        {
            dgv.Columns.Clear();
            DataTable dt = new DataTable();
            dt = CargarDatos.EjecutarSeleccion(consulta);
            dgv.DataSource = dt;

            return dt;
        }
        public static object LlenarListView(string consulta, ListView ltv)
        {
            DataTable dt = new DataTable();
            ltv.GridLines = true;
            ltv.View = View.Details;
            dt = CargarDatos.EjecutarSeleccion(consulta);
           
            ltv.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                  ltv.Columns.Add(dt.Columns[i].ColumnName, 100);        
                 }

                for (int j = 0; j < (dt.Rows.Count); j++)
                {
                    DataRow fila = dt.Rows[j];
                    
                    obj = new ListViewItem(fila[dt.Columns[0].ColumnName].ToString());
                    for (int k = 1; k < dt.Columns.Count; k++)
                    {
                        obj.SubItems.Add(fila[dt.Columns[k].ColumnName].ToString());
                    }
                  
                    ltv.Items.Add(obj);
                }
            
                 
            return dt;
        } 
    }
    }

