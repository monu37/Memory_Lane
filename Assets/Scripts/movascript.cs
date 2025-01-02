using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class movascript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] int ChildNo;
    [SerializeField] RectTransform RectTrans;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject HighlightObj;
    [SerializeField] bool IsCorrectCollection;

    [SerializeField] Vector3 StartPos;
    bool isDragging;
    private void Awake()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        HighlightObj = transform.GetChild(0).gameObject;

        RectTrans = GetComponent<RectTransform>();
    }

    private void Start()
    {
        StartPos = transform.localPosition;
    }

    //public void drag(BaseEventData data)
    //{
    //    if (isDragging)
    //    {
    //        PointerEventData pointerdata = (PointerEventData)data;

    //        Vector2 position;
    //        RectTransformUtility.ScreenPointToLocalPointInRectangle
    //            ((RectTransform)canvas.transform,
    //            pointerdata.position,
    //            canvas.worldCamera,
    //            out position);

    //        transform.position = canvas.transform.TransformPoint(position);
    //        //print("bb");
    //    }

    //}

    public void setchildno(int i)
    {
        ChildNo = i;
    }

    public void activatedeactivatehighlight(bool b)
    {
        isDragging = b;
        HighlightObj.SetActive(b);
    }

    public bool GetCorrectCollection()
    {
        return IsCorrectCollection;
    }

    [SerializeField] Vector3 CurrentPos;
    public void resetpos(GameObject Obj)
    {
        print("aa");
        transform.DOLocalMove(StartPos, 1f).OnComplete(() =>
        {
            Obj.SetActive(false);
        });
        //transform.localPosition = StartPos;//

    }

    public void boundarycheck()
    {
        transform.DOLocalMove(StartPos, 1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        print("pointer down");
        activatedeactivatehighlight(true);
        level1manager.instance.pickclothes(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("pointer up");
        activatedeactivatehighlight(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        print("drag begin");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("drag end");
        //throw new System.NotImplementedException();
        //activatedeactivatehighlight(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("drag");
        RectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
