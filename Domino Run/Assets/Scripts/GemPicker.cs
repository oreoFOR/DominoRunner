using UnityEngine;

public class GemPicker : MonoBehaviour
{
    public GameObject gemPs;
    public GameObject gemImage;
    public RectTransform canvasRect;
    public RectTransform counterRect;
    public GemManager gemManager;
    public void CollectGem(Vector3 psPos)
    {
        Instantiate(gemPs, psPos, Quaternion.identity);
        GemPosition(psPos);
        gemManager.IncrementGems();
    }
    void GemPosition(Vector3 worldPos)
    {
        RectTransform _gemImage = Instantiate(gemImage,canvasRect).GetComponent<RectTransform>();
        _gemImage.GetComponent<GemImage>().counter = counterRect;
        print("assigned gem image");
        float offsetPosY = worldPos.y + 1.5f;
        Vector3 offsetPos = new Vector3(worldPos.x, offsetPosY, worldPos.z);
        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);
        _gemImage.localPosition = canvasPos;
    }
}
