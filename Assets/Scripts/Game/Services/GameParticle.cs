using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ParticleSystem))]
public class GameParticle : MonoBehaviour
{
   [Inject] private ParticleService _particleService;
   
   public ParticleSystem Particle { get; private set; }

   private string _id;
   private CancellationTokenSource _cts;

   private void Awake()
   {
      _cts = new CancellationTokenSource();
      Particle = gameObject.GetComponent<ParticleSystem>();
   }

   private void OnDestroy()
   {
      _cts.Cancel();
   }
   
   public void SetID(string id)
   {
      _id = id;
   }

   private async void WaitDesapwn()
   {
      try
      {
         await UniTask.WaitWhile(IsPlaying, cancellationToken: _cts.Token);
         
         _particleService.Despawn(_id, this);
      }
      catch (OperationCanceledException) { }
   }

   private bool IsPlaying()
   {
      return Particle.IsAlive(true)
         || GetComponentsInChildren<ParticleSystem>().Any(c => c.IsAlive(true));
   }

   public class Pool : MemoryPool<GameParticle>
   {
      protected override void OnSpawned(GameParticle item)
      {
         base.OnSpawned(item);
         item.WaitDesapwn();
      }
   }
}