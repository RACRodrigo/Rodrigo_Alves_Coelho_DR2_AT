using System;
using System.Collections.Generic;
using System.Linq;
using Rodrigo_Alves_Coelho_DR2_AT.Models;
using Rodrigo_Alves_Coelho_DR2_AT.Repositories;

namespace Rodrigo_Alves_Coelho_DR2_AT.Services.Implementations
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(
            IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public int Add(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentNullException("Não é possível cadastrar sem Pessoa");

            if (string.IsNullOrWhiteSpace(pessoa.Nome) || pessoa.Nome.Length < 4)
                throw new ArgumentException("Nome da pessoa inválido");

            var id = _pessoaRepository.Add(pessoa);

            return id;
        }

        public void Delete(int id)
        {
            _pessoaRepository.Delete(id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Pessoa GetById(int id)
        {
            return _pessoaRepository.GetById(id);
        }

        public void Update(int id, Pessoa pessoaUpdated)
        {
            _pessoaRepository.Update(id, pessoaUpdated);
        }
    }
}
