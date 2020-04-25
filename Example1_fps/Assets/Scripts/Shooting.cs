using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject projectile;
    private Rigidbody projectileRB;
    private GameObject player;
    [Range(1, 100)]
    public float multiolyer = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            projectile.transform.rotation = player.transform.rotation;
            
            

            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.AddForce(transform.TransformPoint(Vector3.forward * multiolyer), ForceMode.Impulse);
        }
    }
}
