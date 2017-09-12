using DataAccess.Ado.Net;
namespace DataAccess
{
    public class DaoFactories
    {
        // gets a provider specific (i.e. database specific) factory 

        // ** GoF Design Pattern: Factory

        public static IDaoFactory GetFactory(string dataProvider)
        {
            // return the requested DaoFactory

            switch (dataProvider.ToLower())
            {
                case "ado.net": return new DaoFactory(new AppConfigConnectionFactory("cnn"));
                //case "linq2sql": return new Linq2Sql.DaoFactory();
                //case "entityframework": return new EntityFramework.DaoFactory();

                default: return new DaoFactory(new AppConfigConnectionFactory("cnn"));
            }
        }
    }
}
