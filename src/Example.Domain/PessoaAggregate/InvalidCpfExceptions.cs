namespace Example.Domain.PessoaAggregate
{
    public class InvalidCpfExceptions : ArgumentException
    {
        public InvalidCpfExceptions() : base("O CPF informado não é válido!")
        {
        }
    }
}