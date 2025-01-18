using UnityEngine;

public class ÑreatureCreatures: MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;

    public Transform Create(Vector3 position)
    {
        Transform enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        return enemy;
    }
}