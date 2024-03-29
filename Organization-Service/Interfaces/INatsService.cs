﻿using NATS.Client;

namespace Organization_Service.Interfaces;

public interface INatsService
{
    public IConnection Connect();
    public void Publish<T>(string topic, string tenantId, T data);
    public void Subscribe(string target);
}