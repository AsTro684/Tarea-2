using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiojasPrograma2
{
    internal class AccionesComunes
    {
        public static  void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje,"AVISO!!",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        public static void LlenarCombo(string consulta, ComboBox combo, string id, string nombre)
        {
            combo.Items.Clear();
            DataTable dt;
           
            dt =CargarDatos.EjecutarSeleccion(consulta);
         //  dt.Rows.Add(0, "Mostrar TODOS");  
            if (dt==null)
            {
                return;
            }
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Mostrar Todos";
            dt.Rows.InsertAt(dr, 0);


            combo.DataSource = dt; 
            combo.DisplayMember = nombre;
            combo.ValueMember = id;
            
            


        }
    }
}
