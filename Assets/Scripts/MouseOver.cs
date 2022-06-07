using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IEndDragHandler, IDragHandler, IPointerDownHandler
{
    RectTransform rectTransform;
    public float smoothTime = 0.01f;
    private Vector3 velocity = Vector3.zero;

    Vector3 startPosition;
    Vector3 lastPosition;
    bool change = true;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = new Vector3(rectTransform.localPosition.x, -324, 0);
        lastPosition = new Vector3(rectTransform.localPosition.x, -274, 0);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localPosition = startPosition;

        if (!GameManager.globalColisionAttack)
        {
            GameManager.particles[0].Play();
            DamagePopUp.Create(new Vector3(9.35f, 1.31f, 0), GameManager.globalName + "-");
            GameManager.globalColisionAttack = true;
            Destroy(gameObject);
            EndAttack();
        }
        else 
        {
            EndAttack();
        }

        if (!GameManager.globalColisionDefense)
        {
            GameManager.particles[1].Play();
            DamagePopUp.Create(new Vector3(-2.25f, 1.31f, 0), GameManager.globalName + "+");
            Destroy(gameObject);
            GameManager.globalColisionDefense = true;
            
        }

       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.tag == "Attack")
        {
            BeginAttack();
        }
        else if (gameObject.tag == "Defense")
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
       
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        GameManager.globalName = gameObject.name;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        smoothChange1();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        smoothChange2();
    }

    public void BeginAttack()
    {
        GameManager.instance.BeginAttack(this);
    }

    public void EndAttack()
    {
        GameManager.instance.EndAttack();
    }
    void smoothChange1()
    {
        rectTransform.localPosition = Vector3.SmoothDamp(lastPosition,startPosition,ref velocity, smoothTime);
    }

    void smoothChange2()
    {
       
        rectTransform.localPosition = Vector3.SmoothDamp(startPosition, lastPosition, ref velocity, smoothTime);
    }
}
