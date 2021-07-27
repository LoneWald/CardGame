using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent, DefaultTempCardParent;
    GameObject TempCardGo;
    GameManagerScript GameManager;
    public bool isDraggable;

    private void Awake() {
        MainCamera = Camera.allCameras[0];
        TempCardGo = GameObject.FindGameObjectWithTag("TempCardGo");
        GameManager = FindObjectOfType<GameManagerScript>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = DefaultTempCardParent = transform.parent;

        isDraggable = DefaultParent.GetComponent<DropPlaceScript>().Type == FieldType.SELF_HAND &&
                      GameManager.IsPlayerTurn;
        if (!isDraggable)
            return;

        TempCardGo.transform.SetParent(DefaultParent);
        TempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable)
            return;

        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        transform.position = newPos + offset;

        if (TempCardGo.transform.parent != DefaultTempCardParent)
            TempCardGo.transform.SetParent(DefaultTempCardParent);

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable)
            return;

        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.SetSiblingIndex(TempCardGo.transform.GetSiblingIndex());
        TempCardGo.transform.SetParent(GameObject.Find("Canvas").transform);
        TempCardGo.transform.localPosition = new Vector3(3000, -700);
    }

    void CheckPosition(){
        int newIndex = DefaultTempCardParent.childCount;

        for (int i = 0; i < DefaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (TempCardGo.transform.GetSiblingIndex() < newIndex)
                    newIndex--;
                break;

            }
            
        }
        TempCardGo.transform.SetSiblingIndex(newIndex);
    }
}
