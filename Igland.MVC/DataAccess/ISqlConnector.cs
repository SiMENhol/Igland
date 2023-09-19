using Igland.MVC.Entities;
using System.Data;

namespace Igland.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IDbConnection GetDbConnection();
    }
}