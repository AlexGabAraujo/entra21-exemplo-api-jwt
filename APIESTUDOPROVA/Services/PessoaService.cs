using APIESTUDOPROVA.Contracts.InfraStructure;
using APIESTUDOPROVA.Contracts.Repository;
using APIESTUDOPROVA.Contracts.Service;
using APIESTUDOPROVA.DTO;
using APIESTUDOPROVA.Entities;
using APIESTUDOPROVA.InfraStructure;
using APIESTUDOPROVA.Response;
using APIESTUDOPROVA.Response.Pessoa;

namespace APIESTUDOPROVA.Services
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _repository;
        private IAuthentication _authentication;

        public PessoaService(IPessoaRepository repository, IAuthentication authentication)
        {
            _repository = repository;
            _authentication = authentication;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Pessoa excluida com sucesso!"
            };
        }

        public async Task<PessoaGetAllResponse> GetAll()
        {
            return new PessoaGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<PessoaEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<PessoaLoginTokenResponse> Login(PessoaLoginDTO pessoa)
        {

            pessoa.Senha = Criptografia.Criptografar(pessoa.Senha);
            PessoaEntity newPessoa = await _repository.Login(pessoa);
            string token = _authentication.GenerateToken(newPessoa);
            return new PessoaLoginTokenResponse
            {
                Pessoa = newPessoa,
                Token = token
            };


        }

        public async Task<MessageResponse> Post(PessoaInsertDTO pessoa)
        {
            pessoa.Senha = Criptografia.Criptografar(pessoa.Senha);
            await _repository.Insert(pessoa);
            return new MessageResponse
            {
                Message = "Pessoa inserida com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(PessoaEntity pessoa)
        {
            await _repository.Update(pessoa);
            return new MessageResponse
            {
                Message = "Pessoa alterada com sucesso!"
            };
        }
    }
}
