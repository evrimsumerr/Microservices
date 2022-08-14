﻿using StackExchange.Redis;

namespace Basket.API.Services;

public class RedisService
{
    private readonly string _host;
    private readonly int _port;
    private ConnectionMultiplexer _connection;
    
    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    } 
    
    public void Connect()
    {
        _connection = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    }
    
    public IDatabase GetDatabase(int db = 1)
    {
        return _connection.GetDatabase(db);
    }
}