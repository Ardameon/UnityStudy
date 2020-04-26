using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject projectile;
    private Rigidbody projectileRB;

    [Tooltip("Force strength applyed to projectile when it appeares")]
    [Range(1, 100)]
    public float forceMultiplyer = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            projectile.transform.rotation = transform.rotation;
            
            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.AddForce(transform.TransformDirection(Vector3.forward * forceMultiplyer), ForceMode.Impulse);
        }
    }
}
