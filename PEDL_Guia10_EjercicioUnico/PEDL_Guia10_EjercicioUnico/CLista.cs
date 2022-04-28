﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEDL_Guia10_EjercicioUnico
{
    class CLista
    {

        //-------------------------------------------------- Atributos -----------------------------------------

        private CVertice aElemento; //Elemento que estará en el nodo
        private CLista aSubLista;   //Lista secundaria para las operaciones internas
        private int aPeso;          //Distancia que hay entre 2 aristas


        //----------------------------------------- Constructores ----------------------------------


        public CLista()
        {
            aElemento = null;
            aSubLista = null;
            aPeso = 0;
        }

        public CLista(CLista pLista)
        {
            if (pLista != null)
            {

                aElemento = pLista.aElemento;
                aSubLista = pLista.aSubLista;
                aPeso = pLista.aPeso;
            }
        }

        public CLista(CVertice pElemento, CLista pSubLista, int pPeso)
        {
            aElemento = pElemento;
            aSubLista = pSubLista;
            aPeso = pPeso;
        }


        //--------------------------------------------- Porpiedades -------------------------


        public CVertice Elemento
        {
            get { return aElemento; }
            set { aElemento = value; }
        }

        public CLista SubLista
        {
            get { return aSubLista; }
            set { aSubLista = value; }
        }

        public int Peso
        {
            get { return aPeso; }
            set { aPeso = value; }
        }


        //-------------------------------------- Metodos --------------------------------------


        public bool EsVacia()           //Verifica si la lista está vacía
        {
            return aElemento == null;
        }

        public void Agregar(CVertice pElemento, int pPeso) //Agrega un vertice junto con su respectivo peso
        {
            if (pElemento != null)
            {
                if (aElemento == null)
                {

                    aElemento = new CVertice(pElemento.Valor);
                    aPeso = pPeso;
                    aSubLista = new CLista();

                }
                else
                {
                    if (!ExisteElemento(pElemento))
                        aSubLista.Agregar(pElemento, pPeso);
                }
            }
        }


        public void Eliminar(CVertice pElemento)    //Elimina una arista de la lista unicamente
        {
            if (aElemento != null)
            {
                if (aElemento.Equals(pElemento))
                {
                    aElemento = aSubLista.aElemento;
                    aSubLista = aSubLista.SubLista;
                }
                else
                    aSubLista.Eliminar(pElemento);
            }
        }

        public int NroElementos()       //Devuelve ala cantidad de aristas que hay dentro de la lista
        {
            if (aElemento != null)
                return 1 + aSubLista.NroElementos();
            else
                return 0;
        }

        public object lesimoElemento(int posicion)      //Devuelve la posicion de un elemtento en especifico
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
                if (posicion == 1)
                    return aElemento;
                else
                    return aSubLista.lesimoElemento(posicion - 1);
            else
                return null;
        }

        public object lesimoElementoPeso(int posicion)      //Devulve el peso de un elemento en especifico
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
                if (posicion == 1)
                    return aPeso;
                else
                    return aSubLista.lesimoElementoPeso(posicion - 1);
            else
                return 0;
        }

        public bool ExisteElemento(CVertice pElemento)      //Verifica si el elemento existe (lo devuelve) o si no existe (False)
        {
            if ((aElemento != null) && (pElemento != null))
            {
                return (aElemento.Equals(pElemento) || (aSubLista.ExisteElemento(pElemento)));
            }
            else
                return false;
        }

        public int PosicionElemento(CVertice pElemento)     
        {

            if ((aElemento != null) || (ExisteElemento(pElemento)))
                if (aElemento.Equals(pElemento))
                    return 1;
                else
                    return 1 + aSubLista.PosicionElemento(pElemento);
            else
                return 0;
        }
    }
}
