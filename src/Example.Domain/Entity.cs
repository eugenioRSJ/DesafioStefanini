namespace Example.Domain
{
    public class Entity
    {
        public int Id { get; private set; }

        public void setId(int id)
        {
            Id = id;
        }
    }
}