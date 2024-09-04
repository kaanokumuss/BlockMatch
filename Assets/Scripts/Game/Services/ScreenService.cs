using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenService : MonoBehaviour
{
    private void Awake()
    {
        PrepareCamera();
    }

    private void PrepareCamera()
    {
        var cam = GetComponent<Camera>();
        cam.orthographicSize = (10 / cam.aspect) / 2;
    }
}
