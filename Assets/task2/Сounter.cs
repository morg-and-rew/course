using UnityEngine;
using TMPro;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Coroutine _countRoutine;
    private int _count = 0;

    private void Start()
    {
        _text.text = _count.ToString(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_countRoutine == null)
            {
                _countRoutine = StartCoroutine(IncrementCounter());
            }
            else
            {
                StopCoroutine(_countRoutine);
                _countRoutine = null;
            }
        }
    }

    private IEnumerator IncrementCounter()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            yield return wait;
            _count++; 
            DisplayCounter();
        }
    }

    private void DisplayCounter()
    {
        _text.text = _count.ToString();
    }
}
