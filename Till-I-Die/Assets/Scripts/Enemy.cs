using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health = 10;
	
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void Update()
    {
        if (Health < 0)
        {
            Destroy(this.gameObject);
        }

    }
}
