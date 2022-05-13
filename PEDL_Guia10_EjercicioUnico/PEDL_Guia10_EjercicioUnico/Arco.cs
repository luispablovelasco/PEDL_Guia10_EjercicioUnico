using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEDL_Guia10_EjercicioUnico
{
    public partial class Arco : Form
    {

        public bool control; //Variable de control
        public int dato; //El dato que almacenará el vertice

        public Arco()
        {
            InitializeComponent();
            control = false;
            dato = 0;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                dato = Convert.ToInt16(txtpeso.Text.Trim());

                if (dato < 0)
                {
                    MessageBox.Show("Debes ingresar un valor positivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    control = true;
                    Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Debes ingresar un valor numérico");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            control = false;
        }

        private void Arco_Load(object sender, EventArgs e)
        {

        }

        private void txtpeso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
