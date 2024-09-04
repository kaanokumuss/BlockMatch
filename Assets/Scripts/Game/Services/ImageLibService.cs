using Game.Services;
using UnityEngine;

public class ImageLibService : MonoBehaviour
{
    [SerializeField] private ImageDataSO _imageDataSO;
    public ImageDataSO Images => _imageDataSO;
}