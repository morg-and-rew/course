using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAnimator : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _text1 = "замена";
    [SerializeField] private string _text2 = "добавление";
    [SerializeField] private string _text3 = "перебор";
    [SerializeField] private float _duration = 3f;
    [SerializeField] private int _loopCount = -1; 

    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_text.DOText(_text1, _duration));
        _sequence.Append(_text.DOText(_text2, _duration).SetRelative());
        _sequence.Append(_text.DOText(_text3, _duration, true, ScrambleMode.All));
        _sequence.SetLoops(_loopCount);
    }
}