using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMamondezAutoEvaluacion
{
    public partial class frmPrincipal : Form
    {
        clsLocalidades clsLocalidades;
        DataTable Tabla;
        DataTable tabla;
        clsTemperaturas Temperaturas;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            try
            {
                clsLocalidades = new clsLocalidades();
                //Hace que me muestre el nombre de la especialidad
                lstLocalidad.DisplayMember = "nombre";
                //Hace que retorne el valor nominal de la especialidad
                lstLocalidad.ValueMember = "localidad";
                lstLocalidad.DataSource = clsLocalidades.getAll();
                Tabla = clsLocalidades.getAll();
                lstLocalidad.SelectedIndex = -1;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Problemas con la base de datos", "Error");
                this.Close();
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Text;
            int localidad = Convert.ToInt32(lstLocalidad.SelectedValue);
            Temperaturas = new clsTemperaturas();
            tabla = Temperaturas.getAll();
            foreach (DataRow fila in tabla.Rows)
            {
                if (localidad == Convert.ToInt32(fila[0]))
                {
                    DateTime fechahora = Convert.ToDateTime(fila["fecha"]);
                    string varfecha = fechahora.ToString("dd/MM/yyyy");

                    if (varfecha == fecha)
                    {
                        txtMinima.Text = fila[2].ToString();
                        txtMaxima.Text = fila[3].ToString();


                    }
                    else
                    {
                        MessageBox.Show("no hay fecha");
                    }
                }
            }
        }
    }
}
