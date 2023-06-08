using DG.Tweening;
using System;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Vector3 _positionStrength;
    [SerializeField] Vector3 _rotationStrength;

    static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake;
    private void OnDisable() => Shake -= CameraShake;

    private void CameraShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, _positionStrength);
        _camera.DOShakeRotation(0.3f, _rotationStrength);
    }
}
