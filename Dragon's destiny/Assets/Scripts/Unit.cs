using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public AudioSource damageSoundForMonsters;

    public virtual void ReceiveDamage()
    {
        damageSoundForMonsters.Play();
        Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}