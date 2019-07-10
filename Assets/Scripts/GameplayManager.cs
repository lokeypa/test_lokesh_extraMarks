using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager s_Instance;
    public List<MotionType> lst_MotionQueue = new List<MotionType>();


    private void Awake()
    {
        if (s_Instance == null) {
            s_Instance = this;
        }
    }

    public void StartExecution()
    {
        if (lst_MotionQueue.Count != 0)
            StartCoroutine(PlayerMovement.s_Instance.StartExecution(1.25f));
        else
            Debug.LogError("phele drag to kro!!");

    }

    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void AddMotionToList(MotionType motionType)
    {
        lst_MotionQueue.Add(motionType);
    }


}

public enum MotionType
{
    moveFwd,
    rotateLft,
    rotateRight,
}
