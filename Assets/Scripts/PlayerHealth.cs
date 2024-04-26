using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TakeDamage() 
    {
        if (invincible)
        {
            yield break;
        }
        health -= 1;
        if(health == 0)
        {
            //bakacaz
        }
        invincible = true;
        yield return new WaitForSeconds(1);
        invincible = false;

    }
    
    
}
