using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{

    //public enum identity
    //{
    //    EnemyTrack1,
    //    EnemyTrack2,
    //    EnemyTrack3,
    //    EnemyTrack4,
    //    EnemyTrack5,
    //    EnemyTrack6,
    //}
    //public int identityNumber = 0;
    //public string TrackName = "EnemyTrack";

    public float maxRadius = 100f;
    public float collectRadius = 5f;
    public float speed = 5f;
    public float followSpeed = 10f;
    public float audioVolume = 1;

    private bool tagged = false;

    public Transform target;
    public AudioSource childNoise;

    private MeshRenderer meshR;
    private SoundManager SMan;

    void Start()
    {
        target = Player.instance.transform;
        meshR = gameObject.GetComponent<MeshRenderer>();
        SMan = FindObjectOfType<SoundManager>();
        childNoise = gameObject.GetComponentInChildren<AudioSource>();
        //SMan.Play(TrackName);
    }

    void Update()
    {
        // Get the distance to the player
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= maxRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1 * speed * Time.deltaTime);
        }

        if (distance <= collectRadius)
        {
            tagged = true;
            if (tagged)
            {
                Tagged();
            }
        }

    }

    private void Tagged()
    {
        target.GetComponent<Player>().score++;
        if (target.GetComponent<Player>().score >= 6)
        {
            SMan.Play("AllTracksCombinedSFX");
        }
        meshR.material.color = Color.yellow;
        collectRadius = 0.1f;
        maxRadius = 3;
        speed = followSpeed;
        childNoise.volume = audioVolume;
        //SMan.ChangeVolume("EnemyTrack" + identityNumber, 1f);
        SMan.Play("CollectionSFX");
        //child.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }

}