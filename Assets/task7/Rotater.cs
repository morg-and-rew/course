using DG.Tweening;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private Vector3 _targetRotation = new Vector3(180, 180, 180);
    [SerializeField] private float _duration = 3f;
    [SerializeField] private int _loopCount = -1;

    private void Start()
    {
        transform.DORotate(_targetRotation, _duration).SetLoops(_loopCount, LoopType.Yoyo);
    }
}