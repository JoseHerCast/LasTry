using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;
    public float radius;
    public int enemyCount;
    public static GenerateEnemies generateEnemies;
    private Vector3 randomPos;
    // Start is called before the first frame update
    void Start()
    {
        generateEnemies = this;
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        if (enemyCount < 15)
        {
            randomPos = Random.insideUnitSphere * radius;
            Instantiate(enemy, new Vector3(this.transform.position.x + randomPos.x, this.transform.position.y, this.transform.position.z + randomPos.z), Quaternion.identity, this.transform);
            enemyCount++;
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 15)
        {
            randomPos = Random.insideUnitSphere * radius;
            Instantiate(enemy, new Vector3(this.transform.position.x+randomPos.x, this.transform.position.y, this.transform.position.z+randomPos.z),Quaternion.identity,this.transform);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
