using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        // if (!item)
        {
            Debug.Log("On drop called!!");
            if (UIDragHandler.itemBeingDragged != null)
            {
            GameObject previousObject = UIDragHandler.itemBeingDragged.gameObject;
                GameObject tempObject = Instantiate(previousObject, previousObject.transform.position, previousObject.transform.rotation, previousObject.transform.parent); ;
                tempObject.transform.SetParent(transform.GetChild(0).GetChild(0));
                tempObject.GetComponent<UIDragHandler>().enabled = false;
                tempObject.GetComponent<CanvasGroup>().enabled = false;
                switch (tempObject.tag)
                {
                    case "FwdArrow":
                        {
                            GameplayManager.s_Instance.lst_MotionQueue.Add(MotionType.moveFwd);

                        }
                        break;
                    case "RightArrow":
                        {
                            GameplayManager.s_Instance.lst_MotionQueue.Add(MotionType.rotateRight);

                        }
                        break;
                    case "LeftArrow":
                        {
                            GameplayManager.s_Instance.lst_MotionQueue.Add(MotionType.rotateLft);

                        }
                        break;
                }
                ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
            }
        }
    }
    #endregion
}
