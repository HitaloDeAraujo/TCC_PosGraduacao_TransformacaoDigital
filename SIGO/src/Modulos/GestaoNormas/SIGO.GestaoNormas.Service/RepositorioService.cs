using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Domain.Interfaces;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Service
{
    public class RepositorioService : IRepositorioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INormaService _normaService;

        public RepositorioService(IUnitOfWork unitOfWork, INormaService normaService)
        {
            _unitOfWork = unitOfWork;
            _normaService = normaService;
        }

        public async Task<Repositorio> Salvar(Repositorio repositorio)
        {
            try
            {
                await _unitOfWork.Repositorios.Salvar(repositorio);
                await _unitOfWork.CommitAsync();

                await _normaService.ObterNormasExternas(repositorio);
            }
            catch
            {
                throw;
            }

            return repositorio;
        }

        public async Task Atualizar(Repositorio repositorio)
        {
            try
            {
                _unitOfWork.Repositorios.Atualizar(repositorio);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Excluir(string guid)
        {
            try
            {
                await _unitOfWork.Repositorios.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Repositorio> ObterRepositorio(string guid)
        {
            var repositorio = new Repositorio();

            try
            {
                repositorio = await _unitOfWork.Repositorios.ObterRepositorio(guid);
            }
            catch
            {
                throw;
            }

            return repositorio;
        }

        public async Task<List<Repositorio>> ObterRepositorios()
        {
            try
            {
                return await _unitOfWork.Repositorios.ObterRepositorios();
            }
            catch
            {
                throw;
            }
        }
    }
}
