using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResizePanel : MonoBehaviour, IPointerDownHandler, IDragHandler {
	
	public Vector2 minSize = new Vector2 (100, 100);
	public Vector2 maxSize = new Vector2 (400, 400);
    public float yoffset=30;
	private RectTransform panelRectTransform;
	private Vector2 originalLocalPointerPosition;
	private Vector2 originalSizeDelta;
    public DragPanel dragPanel;
	void Awake () {
		panelRectTransform = transform.parent.GetComponent<RectTransform> ();
	}
	
	public void OnPointerDown (PointerEventData data) {
		originalSizeDelta = panelRectTransform.sizeDelta;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
        dragPanel.
	}
	
	public void OnDrag (PointerEventData data) {
		if (panelRectTransform == null)
			return;
		
		Vector2 localPointerPosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out localPointerPosition);
		Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
		
		Vector2 sizeDelta = originalSizeDelta + new Vector2 (offsetToOriginal.x, -offsetToOriginal.y);
        var a = (sizeDelta.x + sizeDelta.y) / 2.0f;
		sizeDelta = new Vector2 (
			Mathf.Clamp (a, minSize.x, maxSize.x),
			Mathf.Clamp (a+yoffset, minSize.y, maxSize.y)
		);
		
		panelRectTransform.sizeDelta = sizeDelta;
	}
}