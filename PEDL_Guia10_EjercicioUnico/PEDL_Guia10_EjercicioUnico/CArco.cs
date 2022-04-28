using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PEDL_Guia10_EjercicioUnico
{
    class CArco
    {

        //Atributos

        public CVertice nDestino;       //Nodo que estara en la punta del arco
        public int peso;                //Peso (Valor) de cada arco (Arista)
        public float grosor_flecha;     //Parametro para saber cual será el valor de grosor del arco a la hora de ser dibujado
        public Color color;             //Establece el color del arco


        // Métodos
        public CArco(CVertice destino) : this(destino, 1)
        {
            this.nDestino = destino;
        }

        public CArco(CVertice destino, int peso)
        {

            this.nDestino = destino;
            this.peso = peso;
            this.grosor_flecha = 2;
            this.color = Color.Red;

        }
    }
}
