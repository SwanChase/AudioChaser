using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{

    public float maxRadius = 100f;
    public float collectRadius = 5f;
    public float speed = 5f;

    public Transform target;
    public GameObject child;

    private MeshRenderer meshR;

    void Start()
    {
        target = Player.instance.transform;
        meshR = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Get the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= maxRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
        }

        if(distance <= collectRadius)
        {
            Tagged();
        }
        

    }

    private void Tagged()
    {
        meshR.material.color = Color.yellow;
        child.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }

}