using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridLayout : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    public int columnCount = 2; // Sabit kolon say�s�
    public int spacing = 10;    // H�creler aras� bo�luk

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
        float totalWidth = rectTransform.rect.width; // Container'�n geni�li�i
        float cellWidth = (totalWidth - (spacing * (columnCount - 1))) / columnCount; // Her h�cre i�in geni�lik

        // H�cre boyutlar�n� ayarla
        gridLayoutGroup.cellSize = new Vector2(cellWidth, gridLayoutGroup.cellSize.y);
        gridLayoutGroup.spacing = new Vector2(spacing, gridLayoutGroup.spacing.y);
    }
}
