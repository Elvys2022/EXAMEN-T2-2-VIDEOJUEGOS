using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int vidas = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidas <= 0){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bala1"))
        {
            vidas -= 1;
            
        }
        if (other.gameObject.CompareTag("bala2"))
        {
            vidas -= 3;
            
        }
        if (other.gameObject.CompareTag("bala3"))
        {
            vidas -= 5;
            
        }
    }
}
