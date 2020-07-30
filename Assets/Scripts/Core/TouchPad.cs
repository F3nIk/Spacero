using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler,IPointerUpHandler
{
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothingDirection;
    private float smoothingValue = 0.05f;

    private void Awake()
    {
        origin = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;    
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = eventData.position;
        Vector2 dir = currentPosition - origin;
        direction = dir.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        smoothingDirection = Vector2.MoveTowards(smoothingDirection, direction, smoothingValue);
        return smoothingDirection;
    }
}
