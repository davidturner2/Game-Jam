using UnityEngine;
using UnityEngine.XR;

public class CursorScript : MonoBehaviour
{
    public RectTransform cursorImage;
    public Canvas canvas;
    public Vector2 tipOffset;
    void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out Vector2 localPos);

        cursorImage.localPosition = localPos + tipOffset;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }

}
