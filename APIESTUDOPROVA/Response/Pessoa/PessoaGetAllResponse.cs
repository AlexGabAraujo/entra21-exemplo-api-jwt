using APIESTUDOPROVA.Entities;

namespace APIESTUDOPROVA.Response.Pessoa
{
    public class PessoaGetAllResponse
    {
        public IEnumerable<PessoaEntity> Data { get; set; }
    }
}
