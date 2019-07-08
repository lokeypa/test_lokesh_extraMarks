using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement s_Instance;

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
        yield return new WaitForSeconds(1.5f);
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
}
