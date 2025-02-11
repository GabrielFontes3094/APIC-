using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.Models;

namespace ProjetoAPI.Services
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> ObterTodas()
        {
            return await _context.Pessoa.ToListAsync();
        }
        public async Task<Pessoa?> ObterPorId(Guid id)
        {
            return await _context.Pessoa.FindAsync(id);
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Atualizar(Guid id, Pessoa pessoaAtualizada)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null) return false;

            pessoa.Nome = pessoaAtualizada.Nome;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null) return false;

            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
