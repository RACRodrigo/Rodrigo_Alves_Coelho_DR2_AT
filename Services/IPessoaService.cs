using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rodrigo_Alves_Coelho_DR2_AT.Models;

namespace Rodrigo_Alves_Coelho_DR2_AT.Services
{
    public interface IPessoaService
    {
        int Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(int id);
        void Update(int id, Pessoa pessoa);
        void Delete(int id);
    }
}
