using CRUD_com_banco_de_dados.Data;
using CRUD_com_banco_de_dados.Models;
using CRUD_com_banco_de_dados.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_com_banco_de_dados.Repositories {
    public class PessoaRepository : IPessoaRepository {

        private readonly ApplicationDbContext _dbContext;

        public PessoaRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Pessoa Buscar(int id) {
            return _dbContext.Pessoas.FirstOrDefault(p => p.Id == id);
        }

        public void Cadastrar(Pessoa pessoa) {
            _dbContext.Add(pessoa);
            _dbContext.SaveChanges();
        }

        public void Editar(Pessoa pessoa) {
             _dbContext.Update(pessoa);
            _dbContext.SaveChanges();
        }

        public void Excluir(int id) {
            var pessoa = Buscar(id);
            _dbContext.Remove(pessoa);
            _dbContext.SaveChanges();
        }

        public List<Pessoa> Listar() {
            return _dbContext.Pessoas.ToList();
        }
    }
}
