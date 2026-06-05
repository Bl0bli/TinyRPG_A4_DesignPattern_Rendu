using System;
using System.Collections.Generic;
using UnityEngine;

public static class PoolingServiceLocator
{

    private static readonly Dictionary<string, ObjectPooling> Services = new Dictionary<string, ObjectPooling>();

    public static void Register(string id, ObjectPooling service)
    {
        if (!Services.TryAdd(id, service))
        {
            Debug.LogWarning($"{id} already registered. Overwriting.");
            Services[id] = service;
            return;
        }
    }

    public static ObjectPooling GetService(string id)
    {
        if(!Services.TryGetValue(id, out ObjectPooling service)) throw new Exception($"Service {id} is not registered.");
        return service;

    }
    public static void Unregister(string id) => Services.Remove(id);
    public static void Clear() => Services.Clear();

}
