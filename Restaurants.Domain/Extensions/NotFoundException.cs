namespace Restaurants.Domain.Extensions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, string key)
            : base($"Entity '{entityName}' with key '{key}' was not found.")
        {
        }
    }
}
