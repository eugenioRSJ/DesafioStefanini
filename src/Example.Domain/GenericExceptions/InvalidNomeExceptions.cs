namespace Example.Domain.Exceptions
{
    public class InvalidNomeExceptions : ArgumentException
    {
        public InvalidNomeExceptions(int tamanho) : base($"O nome deve existir e conter no máximo {tamanho} caracteres")
        {
        }
    }
}