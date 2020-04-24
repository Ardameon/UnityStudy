using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior)
        {
            behavior.setAlive(false);
        }

        transform.Rotate(-75, 0, 0);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.None;
        }

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
