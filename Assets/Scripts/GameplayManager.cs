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

    private void Start()
    {
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.rotateLft);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.rotateRight);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.rotateRight);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.moveFwd);
        AddMotionToList(MotionType.moveFwd);

        StartExecution();
    }


    public void StartExecution()
    {
        StartCoroutine(PlayerMovement.s_Instance.StartExecution(1.25f));

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
