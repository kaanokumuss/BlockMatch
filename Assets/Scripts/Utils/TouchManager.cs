using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private float firstTapDelayDuration;

    [Inject] private SignalBus _signalBus;

    private CancellationTokenSource _cts;
    private Camera _cam;
    private bool _canTouch;

    private void Awake()
    {
        _cts = new CancellationTokenSource();
        _cam = Camera.main;
    }

    private void Start()
    {
        _canTouch = false;
        WaitForOpenTouch();
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }

    private void Update()
    {
        if (_canTouch)
        {
            GetTouch(Input.mousePosition);
        }
    }

    private void GetTouch(Vector3 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.OverlapPoint(_cam.ScreenToWorldPoint(pos));
            if (CanTouch(hit))
            {
                if (hit.gameObject.TryGetComponent(out ITouchable selectedElement))
                {
                    _signalBus.Fire(new OnElementTappedSignal(selectedElement));
                }
            }
            else
            {
                _signalBus.Fire<OnEmptyTappedSignal>();
            }
        }
    }

    private bool CanTouch(Collider2D hit)
    {
        return hit != null;
    }

    private async void WaitForOpenTouch()
    {
        try
        {
            var duration = TimeSpan.FromSeconds(firstTapDelayDuration);
            await UniTask.Delay(duration, cancellationToken: _cts.Token);
            
            _canTouch = true;
        }
        catch (OperationCanceledException e)
        {
            Debug.Log(e);
        }
    } 
}

public struct OnElementTappedSignal
{
    public readonly ITouchable Touchable;
    
    public OnElementTappedSignal(ITouchable touchable)
    {
        Touchable = touchable;
    }
}

public struct OnEmptyTappedSignal { }

public interface ITouchable
{
    GameObject gameObject { get; }
}