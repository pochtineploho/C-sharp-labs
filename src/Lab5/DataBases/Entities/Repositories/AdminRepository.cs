using DataBases.Models;
using Npgsql;

namespace DataBases.Entities.Repositories;

public class AdminRepository : CommonRepositoryBase<AdminUnit>
{
    public AdminRepository(string connectionString)
        : base(connectionString)
    { }

    public override async Task<OperationResult> Create(AdminUnit item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          INSERT INTO admin_info (username, password)
                                          VALUES (@username, @password)
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("username", item.Username);
        command.Parameters.AddWithValue("password", item.Password);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("Admin added successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<OperationResult> Delete(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          DELETE FROM admin_info
                                          WHERE username = @username
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("username", id);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("Admin deleted successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<OperationResult> Update(string id, AdminUnit item)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        if (item is null) throw new ArgumentNullException(nameof(item));
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          UPDATE admin_info
                                          SET username = @new_username,
                                          password = @password
                                          WHERE username = @username
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("username", id);
        command.Parameters.AddWithValue("new_username", item.Username);
        command.Parameters.AddWithValue("password", item.Password);

        return await command.ExecuteNonQueryAsync() > 0
            ? new OperationResult.Success("Admin updated successfully")
            : new OperationResult.Fail("Operation failed");
    }

    public override async Task<AdminUnit?> GetObject(string id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          SELECT *
                                          FROM admin_info
                                          WHERE username = @username
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);
        command.Parameters.AddWithValue("username", id);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!reader.HasRows) return null;

        await reader.ReadAsync();
        return new AdminUnit(
            reader.GetString(0),
            reader.GetString(1));
    }

    public override async Task<IEnumerable<AdminUnit>?> GetObjectsList()
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sqlRequest = """
                                          SELECT *
                                          FROM admin_info
                                  """;

        await using var command = new NpgsqlCommand(sqlRequest, connection);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!reader.HasRows) return null;

        var result = new List<AdminUnit>();
        while (await reader.ReadAsync())
        {
            var adminUnit = new AdminUnit(
                reader.GetString(0),
                reader.GetString(1));

            result.Add(adminUnit);
        }

        return result;
    }
}