using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LayoutBehaviour : MonoBehaviour
{
    // Used on ItemColumns, ItemFixedHeight, and ShowBoxes in the Visual Panel

    [Header("Width Slider")]
    public Slider slider;
    public TMP_Text Label;

    [Header("Fixed height and box toggles")]
    public Toggle toggle;

    [Header("Parent links")]
    public GameObject LongBoxes;
    public GridLayoutGroup regularItemsGrid; // parent of just regular items
    public VerticalLayoutGroup fullItemsGrid; // parent of all items (includes dungeons, long boxes, keys)

    public void Start()
    {
        if (Label != null)
            Label.text = "Item Columns: " + slider.value;
    }

    public void OnValueChangedColumn()
    {
        regularItemsGrid.constraintCount = (int)slider.value;
        Label.text = "Item Columns: " + slider.value;
    }

    public void OnValueChangedSpacing()
    {
        if (toggle.isOn)
        {
            fullItemsGrid.spacing = 0;
            fullItemsGrid.childForceExpandHeight = true;
        }
        else
        {
            fullItemsGrid.spacing = 30;
            fullItemsGrid.childForceExpandHeight = false;
        }
    }

    public void OnValueChangedBoxes()
    {
        if (toggle.isOn)
        {
            foreach (Transform child1 in regularItemsGrid.gameObject.transform)
            {
                Transform child2 = child1.GetChild(0);
                child2.gameObject.SetActive(true);
            }

            foreach (Transform child1 in LongBoxes.transform)
            {
                Transform child2 = child1.GetChild(0);
                child2.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child1 in regularItemsGrid.gameObject.transform)
            {
                Transform child2 = child1.GetChild(0);
                child2.gameObject.SetActive(false);
            }

            foreach (Transform child1 in LongBoxes.transform)
            {
                Transform child2 = child1.GetChild(0);
                child2.gameObject.SetActive(false);
            }
        }
    }
}
