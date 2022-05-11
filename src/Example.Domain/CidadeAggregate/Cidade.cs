using Example.Domain.CidadeAggregate;
using Example.Domain.Exceptions;
using Example.Domain.Validations;

namespace Example.Domain
{
    public sealed class Cidade : Entity
    {
        private Cidade()
        {
        }

        private Cidade(string nome, string uF)
        {
            Nome = nome;
            UF = uF;
            Pessoas = new List<Pessoa>();
        }

        public string Nome { get; private set; }
        public string UF { get; private set; }
        public IEnumerable<Pessoa> Pessoas { get; set; }
        
        public static Cidade Create(string nome, string uF)
        {   
            Validate(nome, uF);
            return new Cidade(nome, uF);
        }

        public void Update(string nome, string uF)
        {
            Validate(nome, uF); 
            Nome= nome;
            UF = uF;
        }


        private static void Validate(string nome, string uF)
        {
            if(Helpers.VerifyIsNullOrEmpity(nome) || nome.Length > 200)
                throw new InvalidNomeExceptions(200);
            if(Helpers.VerifyIsNullOrEmpity(uF) || uF.Length > 2)
                throw new InvalidUfExceptions();
        }
    }
}