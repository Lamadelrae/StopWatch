using Dapper;
using StopWatch.Domain.Models;
using System.Data.SqlClient;

namespace StopWatch.Infra.Data.Repositories
{
    public class StopWatchData
    {
        SqlConnection _connection = Connection.Get();

        public async Task Insert(StopWatchModel model)
        {
            string sql = "INSERT INTO StopWatch (Id, Start, Stop, IsActive) VALUES (@Id, @Start, @Stop, @IsActive)";

            await _connection.ExecuteAsync(sql, model);
        }

        public async Task<int> GetStopWatchCount()
        {
            string sql = "SELECT COUNT(*) FROM StopWatch";

            return await _connection.QueryFirstAsync<int>(sql);
        }

        public async Task Update(StopWatchModel model)
        {
            string sql = @"UPDATE StopWatch 
                           SET
                             Start = @Start,
                             Stop = @Stop,
                             IsActive = @IsActive
                           WHERE 
                             Id = @Id";

            await _connection.ExecuteAsync(sql, model);
        }

        public async Task Delete(Guid id)
        {
            string sql = "DELETE FROM StopWatch WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<StopWatchModel>> GetAll()
        {
            string sql = "SELECT * FROM StopWatch";

            return await _connection.QueryAsync<StopWatchModel>(sql);
        }

        public async Task<StopWatchModel> GetById(Guid id)
        {
            string sql = "SELECT * FROM StopWatch WHERE Id = @Id";

            return await _connection.QueryFirstAsync<StopWatchModel>(sql, new { Id = id });
        }
    }
}
