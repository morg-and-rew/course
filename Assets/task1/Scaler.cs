using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField]private float _growthRate = 0.1f;

    private void Update()
    {
        transform.localScale += new Vector3(_growthRate, _growthRate, _growthRate) * Time.deltaTime;
    }
}