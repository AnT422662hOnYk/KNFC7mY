// 代码生成时间: 2025-08-24 10:19:47
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

// Represents a simple database connection pool using C# and Unity framework.
public class DatabaseConnectionPool
{
    private ConcurrentQueue<IDbConnection> availableConnections;
    private ConcurrentQueue<IDbConnection> inUseConnections;
    private readonly string connectionString;
    private readonly int maxConnections;
    private readonly DbProviderFactory factory;

    // Constructor for the DatabaseConnectionPool class.
    public DatabaseConnectionPool(string connectionString, int maxConnections, DbProviderFactory factory)
    {
        this.connectionString = connectionString;
        this.maxConnections = maxConnections;
        this.factory = factory;
        this.availableConnections = new ConcurrentQueue<IDbConnection>();
        this.inUseConnections = new ConcurrentQueue<IDbConnection>();

        // Initialize the connection pool with the specified number of connections.
        for (int i = 0; i < maxConnections; i++)
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            availableConnections.Enqueue(connection);
        }
    }

    // Gets a connection from the pool, or creates a new one if the pool is empty.
    public async Task<IDbConnection> GetConnectionAsync()
    {
        if (availableConnections.TryDequeue(out var connection))
        {
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
            return connection;
        }
        else if (inUseConnections.Count < maxConnections)
        {
            var newConnection = factory.CreateConnection();
            newConnection.ConnectionString = connectionString;
            await newConnection.OpenAsync();
            inUseConnections.Enqueue(newConnection);
            return newConnection;
        }
        else
        {
            throw new InvalidOperationException("Connection pool is full.");
        }
    }

    // Returns a connection to the pool.
    public void ReturnConnection(IDbConnection connection)
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
        availableConnections.Enqueue(connection);
        inUseConnections.TryDequeue(out _); // Remove from in-use queue.
    }

    // Releases all connections in the pool.
    public void ReleaseAll()
    {
        foreach (var connection in availableConnections)
        {
            connection.Dispose();
        }
        foreach (var connection in inUseConnections)
        {
            connection.Dispose();
        }
        availableConnections = new ConcurrentQueue<IDbConnection>();
        inUseConnections = new ConcurrentQueue<IDbConnection>();
    }
}
