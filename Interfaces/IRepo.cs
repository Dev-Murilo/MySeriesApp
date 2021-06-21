using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries.Interface
{
    interface IRepo<T>
    {
        List<T> Listar();
        void Inserir(T objeto);
        void Atualizar(int Id, T objeto);
        void MarcarAssistido(int Id);
        void DesmarcarAssistido(int Id);
        T RetornaPorId(int Id);
        void Excluir(int Id);
        int ProximoId();


    }
}
