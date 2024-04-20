using DataBases.Models;
using Npgsql;

namespace DataBases.Entities.Repositories;

public class BankRepository : CommonRepositoryBase<BankUnit>
{
    public BankRepository(string connectionString)
        : base(connectionString)
    { }

    public override async Task<OperationResult> Create(BankUnit item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          INSERT INTO bank_accounts (id, pin_code, budget)
                                          VALUES (@id, @pin_code, @budget)
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", item.BankAccount);
        command.Parameters.AddWithValue("pin_code", item.PinCode);
        command.Parameters.AddWithValue("budget", item.Budget);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("User added successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<OperationResult> Delete(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          DELETE FROM bank_accounts 
                                          WHERE id = @id
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", id);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("User deleted successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<OperationResult> Update(string id, BankUnit item)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        if (item is null) throw new ArgumentNullException(nameof(item));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          UPDATE bank_accounts
                                          SET id = @new_id,
                                          pin_code = @pin_code,
                                          budget = @budget
                                          WHERE id = @id
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("new_id", item.BankAccount);
        command.Parameters.AddWithValue("pin_code", item.PinCode);
        command.Parameters.AddWithValue("budget", item.Budget);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("User updated successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<BankUnit?> GetObject(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          SELECT *
                                          FROM bank_accounts
                                          WHERE id = @id
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("id", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!reader.HasRows) return null;

        await reader.ReadAsync();
        return new BankUnit(
            reader.GetString(0),
            reader.GetString(1),
            reader.GetInt32(2));
    }

    public override async Task<IEnumerable<BankUnit>?> GetObjectsList()
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          SELECT *
                                          FROM bank_accounts
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!reader.HasRows) return null;

        var result = new List<BankUnit>();
        while (await reader.ReadAsync())
        {
            var bankUnit = new BankUnit(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetInt32(2));

            result.Add(bankUnit);
        }

        return result;
    }
}