using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PEDL_Guia10_EjercicioUnico
{
    class CGrafo
    {

        public List<CVertice> nodos; //Lista de nodos del grafo

        public CGrafo()
        {
            nodos = new List<CVertice>();
        }

        // ====================================== Operaciones basicas =====================================

        //Construye un nodo a partir de su valor y lo agrega a la lista de nodos

        public CVertice AgregarVertice(string valor)
        {
            CVertice nodo = new CVertice(valor);
            nodos.Add(nodo);

            return nodo;
        }

        public CVertice EliminarVertice(string valor)
        {
            CVertice nodo = new CVertice(valor);
            nodos.Remove(nodo);

            return nodo;
        }

        //Agrega un nodo a la lusta de nodods del grafo
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo);
        }

        //Busca un nodo en la lista de nodos del grafo
        public CVertice BuscarVertice(string valor)
        {
            return nodos.Find(v => v.Valor == valor);
        }

        //Crea una arista a partir de los valores de los nodos de origen y de destino
        public bool AgregarArco(string origen, string nDestino, int peso = 1)
        {

            CVertice vOrigen, vnDestino;

            //Si alguno de los nodos no existe, se activa una excepción
            if ((vOrigen = nodos.Find(v => v.Valor == origen)) == null)
                throw new Exception("El nodo " + origen + " no existe dentro del grafo");
            if ((vnDestino = nodos.Find(v => v.Valor == nDestino)) == null)
                throw new Exception("El nodo " + nDestino + " no existe dentro del grafo");

            return AgregarArco(vOrigen, vnDestino);
        }

        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso = 1) //Sobrecarga de la funcion AgregarArco
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
            {
                origen.ListaAdyacencia.Add(new
                CArco(nDestino, peso));
                return true;
            }
            return false;
        }

        //Metodo para dibujar el grafo
        public void DibujarGrafo(Graphics g)
        {

            //Dibujando los arcos
            foreach (CVertice nodo in nodos)
                nodo.DibujarArco(g);

            //Dibujando los vertices
            foreach (CVertice nodo in nodos)
                nodo.DibujarVertice(g);
        }

        //Metodo para detectar si se ha posicionado sobre algun nodo y lo devuelve
        public CVertice DetectarPunto(Point posicionMouse)
        {
            foreach (CVertice nodoActual in nodos)
                if (nodoActual.DetectarPunto(posicionMouse)) return nodoActual;
            return null;
        }

        //Metodo para regresar al estado original
        public void ReestablecerGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Color = Color.White;
                nodo.FontColor = Color.Black;
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.Black;
                }
            }

            DibujarGrafo(g);
        }

        public void ColoArista(string o, string d)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo.Valor == o && a.nDestino.Valor == d)
                    {
                        a.color = Color.Red;
                        a.grosor_flecha = 4;
                    }
                }
            }
        }

        public void Colorear(CVertice nodo)
        {
            nodo.Color = Color.AliceBlue;
            nodo.FontColor = Color.Black;
        }

        public CVertice nododistanciaminima()
        {
            int min = int.MaxValue;
            CVertice temp = null;
            foreach (CVertice origen in nodos)
            {
                if (origen.Visitado)
                {
                    foreach (CVertice destino in nodos)
                    {
                        if (!destino.Visitado)
                        {
                            foreach (CArco a in origen.ListaAdyacencia)
                            {
                                if (a.nDestino == destino && min > a.peso)
                                {
                                    min = a.peso;
                                    temp = destino;
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }

        public int posicionNodo(string Nodo)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (String.Compare(nodos[i].Valor, Nodo) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //Funcion para re-dibujar los arcos que 1leganaun nodo
        public void DibujarEntrantes(CVertice nDestino)
        {
            foreach (CVertice nodo in nodos)
            {
                foreach (CArco a in nodo.ListaAdyacencia)
                {
                    if (nodo.ListaAdyacencia != null && nodo != nDestino)
                        if (a.nDestino == nDestino)
                        {
                            a.color = Color.Black;
                            a.grosor_flecha = 2;
                            break;
                        }
                }
            }
        }

        //funcion que desmarca como visitados todos los nodos del grafo
        public void Desmarcar()
        {
            foreach (CVertice n in nodos)
            {
                n.Visitado = false;
                n.Padre = null;
                n.distancianodo = int.MaxValue;
                n.pesoasignado = false;
            }
        }
}
}
