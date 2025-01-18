using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ColorAnimator : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _targetColor = Color.red;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private int _loopCount = -1; 

    private void Start()
    {
        _image.DOColor(_targetColor, _duration).SetLoops(_loopCount, LoopType.Yoyo);
    }
}