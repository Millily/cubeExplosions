using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _explosionRadius = 10f;
    [SerializeField] private float _explosionForse = 2;

    private void OnEnable()
    {
        _cube.ObjectSplitting += Spawn;
    }

    private void OnDisable()
    {
        _cube.ObjectSplitting -= Spawn;
    }

    private Cube Create()
    {
        Cube miniObject = Instantiate(_cube);

        miniObject.transform.localScale = gameObject.transform.localScale / 2;
        miniObject.ChangeChance();

        Renderer renderer = miniObject.GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();

        return miniObject;
    }

    private void Spawn()
    {
        List<Cube> cubeList = new List<Cube>();

        int minCount = 2;
        int maxCount = 6;
        int count = Random.Range(minCount, maxCount);

        for (int i = 0; i < count; i++)
        {
            cubeList.Add(Create());
        }

        foreach (Cube cube in cubeList)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForse, _cube.transform.position / 2, _explosionRadius);
        }
    }
}