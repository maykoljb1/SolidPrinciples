using SolidPrinciples.SingleResponsability.Before.infrastructure;

namespace SolidPrinciples
{
    public class CustomerDbContext: DbContext
    {
        public void Add(Customer customer)
        {
            base.Add(customer);
        }
    }

    public abstract class DbContext
    {
        public void Add<T>(T model)
        {
        }
    }
}