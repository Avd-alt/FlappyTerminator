using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private MeshRenderer _meshRenderer;

    private float _lenghtScreen = 1;
    private Vector2 _meshOffset;

    private void Start()
    {
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * _speed, _lenghtScreen);
        var offset = new Vector2(x, _meshOffset.y);

        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}