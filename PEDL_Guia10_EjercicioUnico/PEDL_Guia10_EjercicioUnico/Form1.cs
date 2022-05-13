using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace PEDL_Guia10_EjercicioUnico
{
    public partial class Simulador : Form
    {

        /*
            ======================================= Investigación Complementaria ===========================================


            1) Identificar que tipo de estructura es utilizada para el manejo del grafo
            R/ Se utiliza una lista creada desde 0, con cada una de sus funciones
        */

        private CGrafo grafo;           //Instanciamos la clase CGrafo
        private CVertice nuevoNodo;     //Instanciamos la clase CVertice para crear el nodo "nuevoNodo"
        private CVertice NodoOrigen;    //Instanciamos la clase CVertice para crear el nodo "NuevoOrigen"
        private CVertice NodoDestino;   //Instanciamos la clase CVertice para crear el nodo "NodoDestino"
        private int var_control = 0;     //0: Sin acción. 1: Dibujando arco. 2: Nuevo Vertice

        //Variable para el control de ventanas modales
        private Vertice ventanaVertice;     //Ventrana para agregar los vertices 
        private Arco ventanaArco;           //Ventana para agregar los arcos

        List<CVertice> nodosRuta;           //Lista de nodos utilizada para almacenar la ruta
        List<CVertice> nodosOrdenados;      //Lista de nodos ordenadas a partir del nodo origen

        bool buscarRuta = false, nuevoVetice = false, nuevoArco = false;
        private int numeronodos = 0;        //Enteros para definir las diferentes opciones y el número de nodos

        bool profundidad = false, anchura = false, nodoEncontrado = false;

        Queue<CVertice> cola = new Queue<CVertice>(); //Para recorridos de anchura

        private string destino = "", origen = "";

        private int distancia = 0;


        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);

                if (nuevoVetice)
                {
                    CBVertice.Items.Clear();
                    CBVertice.SelectedIndex = -1;
                    CBNodoPartida.Items.Clear();
                    CBNodoPartida.SelectedIndex = -1;

                    foreach (CVertice nodo in grafo.nodos)
                    {
                        CBVertice.Items.Add(nodo.Valor);
                        CBNodoPartida.Items.Add(nodo.Valor);
                    }
                    nuevoVetice = false;
                }
                if (nuevoArco)
                {
                    CBArco.Items.Clear();

                    CBArco.SelectedIndex = -1;

                    foreach (CVertice nodo in grafo.nodos)
                    {
                        foreach (CArco arco in nodo.ListaAdyacencia)
                        {
                            CBArco.Items.Add("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso);
                        }
                    }
                    nuevoArco = false;
                }
                if (buscarRuta)
                {
                    foreach (CVertice nodo in nodosRuta)
                    {
                        nodo.colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    buscarRuta = false;
                }

                if (profundidad)
                {
                    //ordenando los nodos desde el que indica el usuario
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado)
                            recorridoProfundidad(nodo, e.Graphics);
                    }
                    profundidad = false;
                    //reestablecer los valroes
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }

                if (anchura)
                {
                    distancia = 0;
                    //ordenando los nodos desde el que indica el usuario
                    cola = new Queue<CVertice>();
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado && !nodoEncontrado)
                            recorridoAnchura(nodo, e.Graphics, destino);
                    }
                    anchura = false;
                    nodoEncontrado = false;
                    //reestablecer los valroes
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ordenarNodos()
        {
            nodosOrdenados = new List<CVertice>();
            bool est = false;
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    nodosOrdenados.Add(nodo);
                    est = true;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    est = false;
                    break;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
        }


        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh();
        }

        private void Simulador_Load(object sender, EventArgs e)
        {

        }

        private void CMSCrearVertice_Opening(object sender, CancelEventArgs e)
        {

        }

        private void CMSCrearVertice_Click(object sender, EventArgs e)
        {

        }

        private void btneliminarvertice_Click(object sender, EventArgs e)
        {
            if (CBVertice.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    if (nodo.Valor == CBVertice.SelectedItem.ToString())
                    {
                        grafo.nodos.Remove(nodo);
                        //Borrando arcos que posea el nodo eliminado
                        nodo.ListaAdyacencia = new List<CArco>();
                        break;
                    }
                }
            }
            foreach (CVertice nodo in grafo.nodos)
            {
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    if (arco.nDestino.Valor == CBVertice.SelectedItem.ToString())
                    {
                        nodo.ListaAdyacencia.Remove(arco);
                        break;
                    }
                }
            }
            nuevoArco = true;
            nuevoVetice = true;
            CBVertice.SelectedIndex = -1;
            Pizarra.Refresh();


        }

        private void btnelimarco_Click(object sender, EventArgs e)
        {
            if (CBArco.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if ("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso:" + arco.peso == CBArco.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoVetice = true;
                nuevoArco = true;
                CBArco.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un arco");
            }
        }

        private void recorridoProfundidad(CVertice vertice, Graphics g)
        {
            vertice.Visitado = true;
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            foreach (CArco adya in vertice.ListaAdyacencia)
            {
                if (!adya.nDestino.Visitado) recorridoProfundidad(adya.nDestino, g);
            }
        }

        private void recorridoAnchura(CVertice vertice, Graphics g, string destino)
        {
            vertice.Visitado = true;
            cola.Enqueue(vertice);
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            if (vertice.Valor == destino)
            {
                nodoEncontrado = true;
                return;
            }
            while (cola.Count > 0)
            {
                CVertice aux = (CVertice)cola.Dequeue();
                foreach (CArco adya in aux.ListaAdyacencia)
                {
                    if (!adya.nDestino.Visitado)
                    {
                        if (!nodoEncontrado)
                        {
                            adya.nDestino.Visitado = true;

                            adya.nDestino.colorear(g);
                            Thread.Sleep(1000);
                            adya.nDestino.DibujarVertice(g);
                            if (destino != "")
                                distancia += adya.peso;
                            cola.Enqueue(adya.nDestino);
                            if (adya.nDestino.Valor == destino)
                            {
                                nodoEncontrado = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void btnprofundidad_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                profundidad = true;
                origen = CBNodoPartida.SelectedItem.ToString();
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un nodo de partida");
            }
        }

        private void btnanchura_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                origen = CBNodoPartida.SelectedItem.ToString();
                anchura = true;
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Seleccione un nodo de partida");
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscarvert.Text.Trim() != "")
            {
                if (grafo.BuscarVertice(txtbuscarvert.Text) != null)
                {
                    MessageBox.Show("Si se encuentra el vértice " + txtbuscarvert.Text);

                }
                else
                {
                    MessageBox.Show("No se encuentra el vértice" + txtbuscarvert.Text);
                }
            }
        }

        private int totalNodos; //Lista de nodos
        int[] parent; //Padre de los nodos
        bool[] visitados; //variable para comprobar los nodos ya visitados

        private void calcularMatricesIniciales() //Se calculan las matrices iniciales de distancia y de nodos
        {

            nodosRuta = new List<CVertice>(); //lista de nodos
            totalNodos = grafo.nodos.Count; //cuenta el numero de nodos en la lista "nodos"
            parent = new int[totalNodos];
            visitados = new bool[totalNodos];
            //calculamos la matriz inicial de distancias
            for (int i = 0; i < totalNodos; i++)
            {
                List<int> filaDistancia = new List<int>();
                for (int j = 0; j < totalNodos; j++)
                {
                    //si el origen-al destino
                    if (i == j)
                    {
                        filaDistancia.Add(0);
                    }
                    else
                    {
                        //buscamos si existe la relacion i,j; de existir obtenemos la distancia
                        int distancia = -1;
                        for (int k = 0; k < grafo.nodos[i].ListaAdyacencia.Count; k++)
                        {
                            if (grafo.nodos[i].ListaAdyacencia[k].nDestino == grafo.nodos[j])
                                distancia = grafo.nodos[i].ListaAdyacencia[k].peso;
                        }
                        filaDistancia.Add(distancia);
                    }
                }
            }
        }
    

        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1: //Dibujando arco
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.Visible = false;
                        ventanaArco.control = false;
                        ventanaArco.ShowDialog();
                        if (ventanaArco.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino)) //Creando la arista
                            {
                                int distancia = 0;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                            nuevoArco = true;
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;

                    Pizarra.Refresh();
                    break;
            }

        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {

            switch (var_control)
            {
                case 2: //Creando nuevo nodo
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;

                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;

                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2;

                        nuevoNodo.Posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;

                case 1: //Dibujando el arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    { CustomEndCap = bigArrow },
                    NodoOrigen.Posicion, e.Location);
                    break;

            }
        }

        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) //Si se ha presionado el botón izquierdo del mouse
            {

                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1; //Como var_control = 1, significa que la pizarra esta en el estado
                                     //de dibujando arco
                }

                if (nuevoNodo != null && NodoOrigen == null)
                {
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                            grafo.AgregarVertice(nuevoNodo);
                        }
                        else
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    nuevoNodo = null;
                    nuevoVetice = true;
                    var_control = 0;
                    Pizarra.Refresh();
                }
                if (e.Button == System.Windows.Forms.MouseButtons.Right) // Si se ha presionado el botón derecho del mouse
                {
                    if (var_control == 0)
                    {
                        if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                        {
                            nuevoVerticeToolStripMenuItem.Text = "Nodo" + NodoOrigen.Valor;
                        }
                    }
                    //else
                        //Pizarra.ContextMenuStrip = this.ContextMenuStrip1;
                
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right) //Si se ha presionado el botón derecho del mouse
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo" + NodoOrigen.Valor;
                    }
                    else
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                }
            }
        }

        private void nuevoVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice();
            var_control = 2;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
