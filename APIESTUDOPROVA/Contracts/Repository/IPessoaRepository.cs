using APIESTUDOPROVA.DTO;
using APIESTUDOPROVA.Entities;

namespace APIESTUDOPROVA.Contracts.Repository
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<PessoaEntity>> GetAll();

        Task<PessoaEntity> GetById(int id);

        Task Insert(PessoaInsertDTO user);

        Task Delete(int id);

        Task Update(PessoaEntity user);

        Task<PessoaEntity> Login(PessoaLoginDTO user);
    }
}
