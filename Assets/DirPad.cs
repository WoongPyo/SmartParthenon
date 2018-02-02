using UnityEngine;
using UnityEngine.EventSystems;

public class DirPad : EventTrigger {

    private Vector2 startPosition;
    private Vector2 currentPosition;
    public bool dragging { get; private set; }
    public Vector2 dir { get { return currentPosition - startPosition; } }

    public override void OnBeginDrag(PointerEventData eventData) {
        base.OnBeginDrag(eventData);
        startPosition = eventData.position;
        dragging = true;
    }
    public override void OnDrag(PointerEventData eventData) {
        base.OnDrag(eventData);
        currentPosition = eventData.position;
    }
    public override void OnEndDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        dragging = false;
    }

    private void Update() {
        //Debug.LogFormat("Dragging = {0}, Dir = {1}", dragging, dir);
    }
}
