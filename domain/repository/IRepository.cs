using System.Linq.Expressions;

namespace e07.domain.repository;

// Generic implementation of the repository pattern, applying DRY principle
public interface IRepository<T> where T : class, new() // why new()?
{
    Task<T> Get(String id); // this is async 'cause some database operations can block our threads
    Task<T> Find(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> GetAll();

    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    void Add(T entity);
    void AddRange(IEnumerable<T> entities);

    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);

    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
/*
    - Create a developer: This functionality should receive and validate as a parameter the developers attributes such as:
        - First name: 3 characters of minimum length and 20 characters of max
        - Last name: 3 characters of minimum length and 30 characters of max
        - Age: Greater than 10 and numeric
        - Worked hours: Greater than 30 and less than 50
        - Salary by hours: Greater than 13
        - Developer type: Must be one of the accepted dev type Junior, Intermediate, Senior, and Lead
    - Get the developer list information
    - Search a developer by criteria: First name, Last name, Age, Worked Hours (Return a list of devs that met the criteria)
    - Get developer by email (Return dev object is found and null/empty if not)
    - Delete a developer by passing the email
    - Update the developer information: For this the payload can be the same passed in the create developer and the validations should be the same
*/