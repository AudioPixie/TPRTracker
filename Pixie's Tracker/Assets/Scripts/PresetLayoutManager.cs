using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// is located on preset buttons

public class PresetLayoutManager : MonoBehaviour
{
    [Header("Parent objects")]
    public GameObject regularItems; // parent of individual item toggles
    public GameObject requiredDungeons; // parent of dungeon toggles

    [Header("Settings links")]
    public Slider itemColumns;
    public Toggle fixedHeight;
    public Toggle showLightVessels;
    public Toggle showOverworldKeys;
    public Toggle showDungeonKeys;

    public void OnClick(string size)
    {
        showOverworldKeys.isOn = true;
        showDungeonKeys.isOn = true;

        if (size == "Large")
        {
            itemColumns.value = 7;
            fixedHeight.isOn = true;
            showLightVessels.isOn = true;
        }

        if (size == "Medium")
        {
            itemColumns.value = 6;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
        }

        if (size == "Small")
        {
            itemColumns.value = 5;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
        }

        if (size == "Race")
        {
            itemColumns.value = 6;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
        }

        for (int i = 0; i < requiredDungeons.transform.childCount; i++) // sets dungeons
        {
            Transform child = requiredDungeons.transform.GetChild(i);
            child.GetComponent<Toggle>().isOn = true;

            if (i > 2 && (size == "Medium" || size == "Small" || size == "Race"))
                child.GetComponent<Toggle>().isOn = false;
        }

        for (int i = 0; i < regularItems.transform.childCount; i++) // sets regular items
        {
            Transform child = regularItems.transform.GetChild(i);
            child.GetComponent<Toggle>().isOn = true;

            if (size == "Medium")
            {
                if (i == 6 || i == 25 || i == 38)
                {
                    child.GetComponent<Toggle>().isOn = false;
                }
            }

            if (size == "Small")
            {
                if (i == 1
                    || i == 6
                    || i == 8
                    || i == 9
                    || i == 16
                    || i == 22
                    || i == 25
                    || i == 27
                    || (i >= 30 && i <= 34)
                    || i == 38)
                {
                    child.GetComponent<Toggle>().isOn = false;
                }
            }

            if (size == "Race")
            {
                if (i == 18
                    || i == 25
                    || i == 30
                    || i == 31
                    || i == 32
                    || i == 34
                    || i == 35
                    || i == 36
                    || i == 38)
                {
                    child.GetComponent<Toggle>().isOn = false;
                }
            }
        }
    }
}
