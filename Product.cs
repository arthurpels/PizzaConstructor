namespace PizzaConstructor
{
    public abstract class Product : IIdentifiable, IPriceable
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; }
        public virtual decimal Price { get; set; } 

        protected Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}