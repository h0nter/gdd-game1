using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hud;
    private bool invincible;
    private float invincibilityTime = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !invincible)
        {
            hud.GetComponent<Heart_Counter>().health-- ;
            Invulnerability();
        }
    }

    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
}
