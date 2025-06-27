using APIESTUDOPROVA.DTO;
using APIESTUDOPROVA.Entities;
using APIESTUDOPROVA.Response;
using APIESTUDOPROVA.Response.Pessoa;

namespace APIESTUDOPROVA.Contracts.Service
{
    public interface IPessoaService
    {
        Task<MessageResponse> Delete(int id);
        Task<PessoaGetAllResponse> GetAll();
        Task<PessoaEntity> GetById(int id);
        Task<MessageResponse> Post(PessoaInsertDTO mecanico);
        Task<MessageResponse> Update(PessoaEntity mecanico);

        Task<PessoaLoginTokenResponse> Login(PessoaLoginDTO user);
    }
}
