using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeToWait = 0;
    private float timeBetweenEnemies = 2.5f;

    [SerializeField] private GameObject enemy;
    [SerializeField] private float LeftLimit, RightLimit;

    public Stack<GameObject> EnemiesStack = new Stack<GameObject>();

    void Update()
    {
        if (Time.time >= timeToWait)
        {
            if (EnemiesStack.Count == 0)
            {
                InstantiateEnemies();
            }
            else
            {
                Pop();
                Debug.Log(EnemiesStack.Count);
            }
            timeToWait = Time.time + timeBetweenEnemies;
        }
    }
    public void Push(GameObject go)
    {
        EnemiesStack.Push(go);
        go.SetActive(false);
    }
    public GameObject Pop()
    {
        GameObject go = EnemiesStack.Pop();
        go.SetActive(true);
        go.transform.position = transform.position;
        go.GetComponent<Rigidbody2D>().linearVelocityX = 2f;
        return go;
    }
    public void InstantiateEnemies()
    {
        GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity);
        enem.GetComponent<Enemy>()._enemyLimitPositionXNegative = LeftLimit;
        enem.GetComponent<Enemy>()._enemyLimitPositionXPositive = RightLimit;
        enem.GetComponent<Enemy>().spawner = this;
    }
}