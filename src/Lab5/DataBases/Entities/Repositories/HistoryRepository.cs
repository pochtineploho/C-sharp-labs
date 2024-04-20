using DataBases.Models;
using Npgsql;

namespace DataBases.Entities.Repositories;

public class HistoryRepository : ComplexRepositoryBase<HistoryUnit>
{
    public HistoryRepository(string connectionString)
        : base(connectionString)
    { }

    public override async Task<OperationResult> Create(HistoryUnit item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          INSERT INTO operations_history (account_id, datetime, operation)
                                          VALUES (@bankAccount, @time, @money)
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("bankAccount", item.BankAccount);
        command.Parameters.AddWithValue("time", item.DateTime);
        command.Parameters.AddWithValue("money", item.Amount);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("Added operation to history successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<OperationResult> DeleteAll(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          DELETE FROM operations_history
                                          WHERE account_id = @id
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", id);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("Operations deleted successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<IEnumerable<HistoryUnit>?> GetObjectsList(string id)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          SELECT *
                                          FROM operations_history
                                          WHERE account_id = @id
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var result = new List<HistoryUnit>();

        while (await reader.ReadAsync())
        {
            var historyUnit = new HistoryUnit(
                reader.GetString(1),
                reader.GetInt32(3),
                reader.GetDateTime(2));

            result.Add(historyUnit);
        }

        return result;
    }
}