using System.Collections.Generic;
using UnityEngine;

public class SelecterColor : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;

    private void Start()
    {
        Color randomColor = _colors[Random.Range(0, _colors.Count)];
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = randomColor;
        }
    }
}