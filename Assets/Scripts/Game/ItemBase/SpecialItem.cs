using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SpecialItem : Item
{
    [Inject] private ParticleService _particleService;
    
    /*
    public override void SetHint(int groupCount)
    {
        if (groupCount >= 2)
        {
            if (_hintParticle == null)
            {
                _hintParticle = _particleService.Spawn("ComboParticle", transform.position);
            }
        }
        else
        {
            if (_hintParticle != null)
            {
                _particleService.Despawn("ComboParticle", _hintParticle);
            }
        }
    }
    */
    
    public override MatchType GetMatchType()
    {
        return MatchType.SpecialType;
    }

    public abstract override SpecialType GetSpecialType();
    
    protected virtual List<Cell> GetExplosionCells()
    {
        return null;
    }
}