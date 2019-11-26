using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Image Health1;
    public Image Health2;
    public Image Health3;
    public AudioClip Impact;
    public AudioClip Explosion;
    public ParticleSystem Boom;
    public ParticleSystem Damage1;
    public ParticleSystem Damage2;
    private bool dmg1 = false;
    private bool dmg2 = false;

    int health = 3;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Damage1.Stop();
        Damage2.Stop();
    }

    
    void Update()
    {
        if(health == 2)
        {
            Health3.enabled = false;
            Invoke("Damage", 0);
        }
        else if(health == 1)
        {
            Health2.enabled = false;
            Invoke("Damage", 0);
        }
        else if(health == 0)
        {
            Health1.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mine")
        {
            health -= 1;
            Instantiate(Boom, other.gameObject.transform.position, Quaternion.identity);
            audio.PlayOneShot(Explosion, 1);
            Destroy(other.gameObject);
        }
        else
        {

        }
    }

    private void Damage()
    {
        if(health == 2 && dmg1 == false)
        {
            Damage1.Play();
            dmg1 = true;
        }
        else if(health == 1 && dmg2 == false)
        {
            Damage2.Play();
            dmg2 = true;
        }
    }
}
