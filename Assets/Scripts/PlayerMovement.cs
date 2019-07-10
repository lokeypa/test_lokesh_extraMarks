using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement s_Instance;
    public GameObject finalPanel;

    private void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
    }

    public IEnumerator StartExecution(float timeDelay)
    {
        for (int i = 0; i < GameplayManager.s_Instance.lst_MotionQueue.Count; i++)
        {
           yield return  StartCoroutine(DoMotionOfPlayer(GameplayManager.s_Instance.lst_MotionQueue[i]));
        }
    }

    IEnumerator DoMotionOfPlayer(MotionType motionType)
    {
        yield return new WaitForSeconds(1.25f);
        switch (motionType)
        {
            case MotionType.moveFwd:
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 2);
                }
                break;

            case MotionType.rotateLft:
                {
                    transform.Rotate(0,-90,0);
                }
                break;

            case MotionType.rotateRight:
                {
                    transform.Rotate(0,90,0);
                }
                break;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NonWalkable"))
        {
            //los the game.
            Debug.Log("you lost!");
            finalPanel.SetActive(true);
            finalPanel.transform.GetChild(0).GetComponent<Text>().text = "You Lost!!!";

        }

        else if(collision.gameObject.CompareTag("Goal"))
        {
            //win the game.
            Debug.Log("you won!");
            finalPanel.SetActive(true);
            finalPanel.transform.GetChild(0).GetComponent<Text>().text = "You Won!!!";
        }
    }
}
