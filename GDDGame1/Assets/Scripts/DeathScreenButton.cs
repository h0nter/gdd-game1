using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                //animatorFunctions.disableOnce = true;
                switch (thisIndex)
                {
                    case 0:
                        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
                        break;

                    case 1:
                        SceneManager.LoadScene(0);
                        break;

                    default:
                        break;
                }
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}

