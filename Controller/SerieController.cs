using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySeries.Interface;

namespace MySeries.Controller
{
    class SerieController : IRepo<Serie>
    {

        private List<Serie> listaSeries = new List<Serie>();

        public List<Serie> Listar()
        {
            return listaSeries;
        }
        public void Inserir(Serie objeto)
        {
            listaSeries.Add(objeto);
        }


        public void Atualizar(int Id, Serie objeto)
        {
            listaSeries[Id] = objeto;
        }

        public void MarcarAssistido(int Id)
        {
            listaSeries[Id].Assistido = true;
        }

        public void DesmarcarAssistido(int Id)
        {
            listaSeries[Id].Assistido = false;
        }

        public Serie RetornaPorId(int Id)
        {
            return listaSeries[Id];
        }

        public void Excluir(int Id)
        {
            listaSeries[Id].Excluir();
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

    }
}
