using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LayoutBehaviour : MonoBehaviour
{
    // Used on ItemColumns, ItemFixedHeight, and ShowBoxes in the Visual Panel

    [Header("Slider")]
    public Slider slider;
    public TMP_Text Label;
    public string labelText;

    [Header("Toggle")]
    public Toggle toggle;

    [Header("Long Boxes")]
    public GameObject Twilight;
    public GameObject OverworldKeys;

    [Header("Parent links")]
    public GameObject LongBoxes;
    public GridLayoutGroup regularItemsGrid; // parent of just regular items
    public VerticalLayoutGroup fullItemsGrid; // parent of all items (includes dungeons, long boxes, keys)
    public Transform bossesParent;

    public void Start()
    {
        if (Label != null)
            Label.text = labelText + slider.value;
    }

    public void OnValueChangedColumn()
    {
        regularItemsGrid.constraintCount = (int)slider.value;
        Label.text = labelText + slider.value;
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
            fullItemsGrid.spacing = 20;
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

    public void OnValueChangedDungeons()
    {
        if ((int)slider.value == 0)
            bossesParent.gameObject.SetActive(false);
        else
            bossesParent.gameObject.SetActive(true);

        for (int i = 0; i < 8; i++)
        {
            bossesParent.GetChild(i).gameObject.SetActive(i < (int)slider.value);
        }
        Label.text = labelText + slider.value;
    }

    public void OnValueChangedLongBox()
    {
        if ((Twilight.activeInHierarchy == false) && (OverworldKeys.activeInHierarchy == false))
        {
            LongBoxes.SetActive(false);
        }
    }
}
