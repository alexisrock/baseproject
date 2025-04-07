namespace Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    
        public Producto( string name)
        {           
            Name = name;
        }
    }
}
