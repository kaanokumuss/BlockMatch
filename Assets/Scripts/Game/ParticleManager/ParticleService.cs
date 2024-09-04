using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ParticleService : IInitializable
{
    [Inject] private ParticleServiceSettings settings;
    [Inject] private DiContainer _diContainer;

    private Dictionary<string, GameParticle.Pool> _particleMap;
    
    public void Initialize()
    {
        _particleMap = new Dictionary<string, GameParticle.Pool>();
        
        foreach (var particleData in settings.particles)
        {
            var pool = _diContainer.ResolveId<GameParticle.Pool>(particleData.id);
            _particleMap.Add(particleData.id, pool);
        }
    }

    public GameParticle Spawn(string id, Vector3 position, bool autoPlay = true)
    {
        if (_particleMap.TryGetValue(id, out var pool))
        {
            var particle = pool.Spawn();
            particle.transform.position = position;
            if (autoPlay)
            {
                particle.Particle.Play();
            }
            particle.SetID(id);
            return particle;
        }

        Debug.LogError("Particle not found: " + id);
        return null;
    }
    
    public GameParticle Spawn(string id, Item item, bool autoPlay = true)
    {
        if (_particleMap.TryGetValue(id, out var pool))
        {
            var particle = pool.Spawn();
            particle.transform.position = item.transform.position;
            if (autoPlay)
            {
                particle.Particle.Play();
            }
            particle.SetID(id);
            return particle;
        }

        Debug.LogError("Particle not found: " + id);
        return null;
    }
    
    public void Despawn(string id, GameParticle particle)
    {
        if (_particleMap.TryGetValue(id, out var pool))
        {
            particle.Particle.Stop();
            particle.transform.SetParent(null);
            pool.Despawn(particle);
        }
        else
        {
            Debug.LogError("Particle not found: " + id);
        }
    }
}
