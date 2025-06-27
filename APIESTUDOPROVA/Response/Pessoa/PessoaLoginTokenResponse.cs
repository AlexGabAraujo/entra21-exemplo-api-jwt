using APIESTUDOPROVA.Entities;

namespace APIESTUDOPROVA.Response.Pessoa
{
    public class PessoaLoginTokenResponse
    {
        public string Token { get; set; }
        public PessoaEntity Pessoa { get; set; }
    }
}
