using DataAccess;

namespace DataAccess
{
    public interface IDaoFactory
    {
        IAccountDao AccountDao { get; }
    }
}

