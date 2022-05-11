using Example.Domain.Exceptions;
using Example.Domain.PessoaAggregate;
using Example.Domain.Validations;
namespace Example.Domain
{
    public sealed class Pessoa : Entity
    {
        public string Nome { get; private set; }
        public  string CPF { get; private set; }
        public  int Idade { get; private set; }

        public int CidadeId { get; private set; }
        public Cidade Cidade { get; private set; }

        private Pessoa(){}
        private Pessoa(string nome, string cPF, int idade, int cidadeId)
        {
            Nome = nome;
            CPF = cPF;
            Idade = idade;
            CidadeId = cidadeId;
        }
        public static Pessoa Create(string nome, string cPF, int idade, int cidadeId)
        {
            Validate(nome, cPF, idade, cidadeId);
            return new Pessoa(nome, cPF, idade, cidadeId);
        }

        public void Update(string nome, string cPF, int idade, int cidadeId)
        {
            Validate(nome, cPF, idade, cidadeId);
            Nome= nome;
            CPF = cPF;
            Idade = idade;
            CidadeId = cidadeId;
        }

        public static void Validate(string nome, string cPF, int idade, int cidadeId)
        {
            if(Helpers.VerifyIsNullOrEmpity(nome) || nome.Length > 300)
                throw new InvalidNomeExceptions(300);
            if(!Helpers.IsCpf(cPF))
                throw new InvalidCpfExceptions();
            if(idade == 0)
                throw new ArgumentException("Invalid " + nameof(idade));
            if(cidadeId == 0)
                throw new ArgumentException("Invalid " + nameof(cidadeId));
        }
    }
}