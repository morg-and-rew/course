using DG.Tweening;
using UnityEngine;

public class Scaler1 : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale = new Vector3(1, 5, 1);
    [SerializeField] private float _duration = 3f;
    [SerializeField] private int _loopCount = -1; 

    private void Start()
    {
        transform.DOScale(_targetScale, _duration).SetLoops(_loopCount, LoopType.Yoyo);
    }
}