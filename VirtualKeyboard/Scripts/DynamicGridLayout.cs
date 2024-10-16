using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridLayout : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    public int columnCount = 2; // Sabit kolon sayýsý
    public int spacing = 10;    // Hücreler arasý boþluk

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();

        AdjustCellSize();
    }

    void Update()
    {
        AdjustCellSize();
    }

    void AdjustCellSize()
    {
        float totalWidth = rectTransform.rect.width; // Container'ýn geniþliði
        float cellWidth = (totalWidth - (spacing * (columnCount - 1))) / columnCount; // Her hücre için geniþlik

        // Hücre boyutlarýný ayarla
        gridLayoutGroup.cellSize = new Vector2(cellWidth, gridLayoutGroup.cellSize.y);
        gridLayoutGroup.spacing = new Vector2(spacing, gridLayoutGroup.spacing.y);
    }
}
