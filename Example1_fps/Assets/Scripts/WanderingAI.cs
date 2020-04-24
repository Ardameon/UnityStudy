using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject fireBall;
    public float speed = 3;
    public float obstacleRange = 3;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    public void setAlive(bool alive)
    {
        isAlive = alive;
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (!fireBall)
                {
                    fireBall = Instantiate(fireballPrefab) as GameObject;
                    fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireBall.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
