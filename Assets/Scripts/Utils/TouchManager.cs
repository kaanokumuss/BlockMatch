using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private CancellationTokenSource _cts;
    [SerializeField] private float firstTapDelayDuration;
    private Camera _cam;
    bool _canTouch;

    private void Awake()
    {
        _cts = new CancellationTokenSource();
        _cam = Camera.main;
    }

    void Start()
    {
        _canTouch = false;
        WaitForOpenTouch();
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }

    void Update()
    {
        if (_canTouch)
        {
            GetTouch(Input.mousePosition);
        }
    }

    void GetTouch(Vector3 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked at: " + pos);
            var hit = Physics2D.OverlapPoint(_cam.ScreenToWorldPoint(pos));
            if (CanTouch(hit))
            {
                Debug.Log("Hit: " + hit.gameObject.name);
                if (hit.gameObject.TryGetComponent(out ITouchable selectedElement))
                {
                    TouchEvents.OnElementTapped?.Invoke(selectedElement);
                }
            }
            else
            {
                Debug.Log("No hit detected.");
                TouchEvents.OnEmptyTapped?.Invoke();
            }
        }
    }


    bool CanTouch(Collider2D hit)
    {
        return hit != null;
    }

    private async void WaitForOpenTouch()
    {
        try
        {
            var duration = TimeSpan.FromSeconds(firstTapDelayDuration);
            await UniTask.Delay(duration , cancellationToken : _cts.Token);
            _canTouch = true;
        }
        catch (OperationCanceledException e)
        {
            Debug.Log(e);
        }
    }
}

public static class TouchEvents
{
    public static Action<ITouchable> OnElementTapped;
    public static Action OnEmptyTapped;
}

public interface ITouchable
{
    GameObject gameObject { get; }
}