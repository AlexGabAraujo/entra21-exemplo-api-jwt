using APIESTUDOPROVA.Entities;

namespace APIESTUDOPROVA.Contracts.InfraStructure
{
    public interface IAuthentication
    {
        string GenerateToken(PessoaEntity user);
    }
}
