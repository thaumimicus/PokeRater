using System.Data;
using System.Data.SqlClient;

namespace PokeRater.Adapters
{
    class PokeRaterSqlAdapter : IPokeRaterAdapter
    {
        private SqlConnection _sqlConnection;
        public SqlConnection SqlConnection
        {
            get
            {
                return _sqlConnection;
            }
        }

        public PokeRaterSqlAdapter(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Gets a DataTable of Pokemon from the database.
        /// </summary>
        /// <returns>DataTable of Pokemon.</returns>
        public DataTable GetAllPokemon()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pokemon", _sqlConnection))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Updates Pokemon in the database.
        /// </summary>
        /// <param name="dt">DataTable of Pokemon.</param>
        public void UpdatePokemon(DataTable dt)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pokemon", _sqlConnection))
            {
                adapter.UpdateCommand.Parameters.AddWithValue("UPDATE Pokemon SET Rating = @Rating WHERE DexNum = @DexNum", 0);
                adapter.Update(dt);
            }
        }
    }
}
