using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy)
        {
            enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position + new Vector3(0, 1, 0);
            enemy.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
}
