using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using System.Data;

namespace Igland.MVC.Repositories
{
    public class SqlUserRepository : UserRepositoryBase, IUserRepository
    {
        private readonly ISqlConnector sqlConnector;

        public SqlUserRepository(ISqlConnector sqlConnector, UserManager<IdentityUser> userManager) : base(userManager)
        {
            this.sqlConnector = sqlConnector;
        }
        public void Delete(string email)
        {
            var sql = $"delete from users where email = '{email}'";
            RunCommand(sql);
        }
        public void Upsert(UserEntity entity)
        {
            UserEntity existingUser = GetUser(entity.Email);

            if (existingUser == null)
            {
                // User does not exist, so insert the new user
                Add(entity);
            }
            else
            {
                // User exists, so update the existing user
                Update(entity, roles: null); // You can pass null for roles if roles don't need to be updated
            }
        }
        public UserEntity Get(int id)
        {
            using (var connection = sqlConnector.GetDbConnection())
            {
                var reader = ReadData($"SELECT Id, Name, Email FROM users WHERE Id = {id};", connection);
                while (reader.Read())
                {
                    return MapUserFromReader(reader);
                }
            }
            return null; // User not found
        }

        public List<UserEntity> GetAll()
        {
            return GetUsers();
        }
        public List<UserEntity> GetUsers()
        {
            using (var connection = sqlConnector.GetDbConnection())
            {
                var reader = ReadData("Select id, Name, Email, Password,EmployeeNumber,Team, Role from users;", connection);
                var users = new List<UserEntity>();
                while (reader.Read())
                {
                    UserEntity user = MapUserFromReader(reader);
                    users.Add(user);
                }
                connection.Close();
                return users;

            }
        }

        private static UserEntity MapUserFromReader(IDataReader reader)
        {
            var user = new UserEntity();
            user.Id = reader.GetInt32(0);
            user.Name = reader.GetString(1);
            user.Email = reader.GetString(2);
            return user;
        }

        public void Update(UserEntity user, List<string> roles)
        {
            UserEntity existingUser = GetUser(user.Email);
            if (existingUser == null)
            {
                throw new Exception("User does not exist");
            }

            var command = new MySqlCommand();
            command.CommandType = CommandType.Text;

            var sql = $@"update users 
                                set 
                                   Name = '{user.Name}', 
                                where email = '{user.Email}';";
            RunCommand(sql);
            SetRoles(user.Email, roles);
        }

        public void Add(UserEntity user)
        {
            UserEntity existingUser = GetUser(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var sql = $"insert into users(Name, Email) values('{user.Name}', '{user.Email}');";
            RunCommand(sql);
        }

        private UserEntity GetUser(string email)
        {
            UserEntity existingUser = null;
            using (var connection = sqlConnector.GetDbConnection())
            {
                var reader = ReadData($"Select id, Name, Email from users where email = {email};", connection);

                while (reader.Read())
                {
                    existingUser = MapUserFromReader(reader);
                }
                connection.Close();
            }

            return existingUser;
        }

        private void RunCommand(string sql)
        {
            using (var connection = sqlConnector.GetDbConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private IDataReader ReadData(string query, IDbConnection connection)
        {
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }
    }
}

