namespace Example.Domain.CidadeAggregate
{
    public class InvalidUfExceptions : ArgumentException
    {
        public InvalidUfExceptions() : base("A UF deve existir conter no máximo 2 caracteres")
        {
        }
    }
}