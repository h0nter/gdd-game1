using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hud;
    private bool invincible;
    private float invincibilityTime = 3.0f;
    public int flashingSpeed;
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
            StartCoroutine(Invulnerability(collision.gameObject));
            StartCoroutine(redColour());
            StartCoroutine(flashing());
        }
    }

    IEnumerator Invulnerability(GameObject enemy)
    {
        invincible = true;
        enemy.GetComponent<AICharacterControl>().enabled = false;
        enemy.GetComponent<ThirdPersonCharacter>().Move(Vector3.zero, false, false);
        yield return new WaitForSeconds(invincibilityTime);
        enemy.GetComponent<AICharacterControl>().enabled = true;
        invincible = false;
    }

    IEnumerator redColour()
    {
        this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(invincibilityTime);
        this.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    IEnumerator flashing()
    {
        for (int i = 0; i < flashingSpeed; i++)
        {
            this.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().gameObject.SetActive(false);
            yield return new WaitForSeconds(invincibilityTime / (2*flashingSpeed));
            this.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>().gameObject.SetActive(true);
            yield return new WaitForSeconds(invincibilityTime / (2 * flashingSpeed));
        }

    }
}
