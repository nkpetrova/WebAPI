using System.Data;
using System.Data.SqlClient;
using WebAPI.Domain;

namespace WebAPI.Repositories
{
    public class TurfirmaRepository : ITurfirmaRepository
    {
        private readonly string _connectionString;

        public TurfirmaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TurFirma> GetAll()
        {
            var result = new List<TurFirma>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Address], [Commission] from [TurFirma]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new TurFirma(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Address"]),
                    Convert.ToInt32(reader["Commission"])
                ));
            }

            return result;
        }

        public int Create(TurFirma turfirma)
        {
            if (turfirma == null)
            {
                throw new ArgumentNullException(nameof(turfirma));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO [TurFirma] VALUES ([@name], [@address], [@commission])";

            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = turfirma.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = turfirma.Name;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = turfirma.Address;
            sqlCommand.Parameters.Add("@commission", SqlDbType.Int).Value = turfirma.Commission;
            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

        public void Delete(TurFirma turfirma)
        {
            if (turfirma == null)
            {
                throw new ArgumentNullException(nameof(turfirma));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [TurFirma] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = turfirma.Id;

            sqlCommand.ExecuteNonQuery();
        }

        public TurFirma GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [Name], [Address], [Commission] from [TurFirma] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new TurFirma(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Address"]),
                    Convert.ToInt32(reader["Commission"])
                    );
            }
            else
            {
                return null;
            }
        }

        public int Update(TurFirma turfirma)
        {
            if (turfirma == null)
            {
                throw new ArgumentNullException(nameof(turfirma));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [TurFirma] set [Name] = @name, [Commission] = @commission, [Address] = " +
                "@address where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = turfirma.Id;
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = turfirma.Name;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = turfirma.Address;
            sqlCommand.Parameters.Add("@commission", SqlDbType.Int).Value = turfirma.Commission;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }


        public List<Tuple<TurFirma, int>> GroupByAddress()
        {
            var result = new List<Tuple<TurFirma, int>>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();

            sqlCommand.CommandText = "select [Id], [Name], [Address], [Commission], AVG([Commission]) AS [AvgCommission] from [TurFirma] " +
                "GROUP BY [Id], [Name], [Address], [Commission]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                TurFirma turfirma = new TurFirma(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToString(reader["Address"]),
                    Convert.ToInt32(reader["Commission"])
                    );
                result.Add(new Tuple<TurFirma, int>(turfirma, Convert.ToInt32(reader["AvgCommission"])));
            }
            return result;
        }
    }
}