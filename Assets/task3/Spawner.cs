using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ÑreatureCreatures _template;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnMouseUpAsButton()
    {
        Spawn(_player.transform.position);
    }

    private List<Rigidbody> GetExplosionObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> barrels = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                barrels.Add(hit.attachedRigidbody);
            }
        }

        return barrels;
    }

    private void Spawn(Vector3 position)
    {
        float initialProbability = 100;
        float probabilityDecreaseRate = 0.5f;
        float magnifyingFactor = 2f;
        float reductionFactor = 0.5f;

        int minValueFirst = 2;
        int maxValueFirst = 7; 
        int numberOfObjectsToSpawn = Random.Range(minValueFirst, maxValueFirst);

        float minValueSecond = 0;
        float maxValueSecond = 99;
        float randomNumber = Random.Range(minValueSecond, maxValueSecond);


        initialProbability *= probabilityDecreaseRate;
        _explosionForce *= magnifyingFactor;
        _explosionRadius *= magnifyingFactor;

        if (initialProbability > randomNumber)
        {

            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                Transform spawnedEnemy = _template.Create(position);
                spawnedEnemy.transform.localScale *= reductionFactor;
            }

        }
        else
        {

            foreach (Rigidbody explodableObject in GetExplosionObjects())
            {
                explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }

        }

        Destroy(_player);
    }
}