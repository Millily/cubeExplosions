using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    public int Chance { get; private set; } = 100;
    
    public event UnityAction ObjectSplitting;

    public void ChangeChance()
    {
        int divider = 2;
        Chance /= divider;
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        int chance = Random.Range(0, 100);

        if (chance <= Chance)
        {
            ObjectSplitting?.Invoke();
        }

        Destroy(gameObject);
    }
}