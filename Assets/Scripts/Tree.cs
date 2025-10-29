using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamageable
{
    [SerializeField] private List<string> _items;
    [SerializeField] private int _maxNumberOfDrops = 5;

    private int _currentDrops = 0;
    public void Hurt(int damage)
    {
        Drop();
    }
    public void Drop()
    {
        Debug.Log("Drop " + _items[0]);
        Debug.Log("Drop " + _items[1]);
        int rand = Random.Range(0, 5);
        if (rand == 0 && _currentDrops < _maxNumberOfDrops)
        {
            // Per dropejar pomes xd, una mica chapussa skdjhfdsajhfal
            _currentDrops++;
            Debug.Log("Drop " + _items[2]);
        }
    }
}