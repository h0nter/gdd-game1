using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart_Counter : MonoBehaviour
{
    public int health;
    private int shownHearts = 3;
    public GameObject heartCont;
    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        if(shownHearts > health)
        {
            loseHeart();
        }
    }

    private void loseHeart()
    {
        shownHearts--;
        heartCont.transform.GetChild(shownHearts).gameObject.SetActive(false);
    }
}
