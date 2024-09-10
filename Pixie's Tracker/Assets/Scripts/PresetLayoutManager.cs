using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// is located on preset buttons

public class PresetLayoutManager : MonoBehaviour
{
    [Header("Parent objects")]
    public GameObject regularItems; // parent of individual item toggles
    public GameObject bossesParent; // parent of dungeon toggles

    [Header("Settings links")]
    public Slider itemColumns;
    public Slider dungeonCount;
    public Toggle fixedHeight;
    public Toggle showLightVessels;
    public Toggle showOverworldKeys;
    public Toggle showDungeonKeys;

    public void OnClick(string size)
    {
        showOverworldKeys.isOn = true;
        showDungeonKeys.isOn = true;

        ResetDungeons();

        if (size == "Large")
        {
            itemColumns.value = 7;
            fixedHeight.isOn = true;
            showLightVessels.isOn = true;
            dungeonCount.value = 8;
        }

        if (size == "Medium")
        {
            itemColumns.value = 6;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
            dungeonCount.value = 3;
        }

        if (size == "Small")
        {
            itemColumns.value = 5;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
            dungeonCount.value = 3;
        }

        if (size == "Race")
        {
            itemColumns.value = 6;
            fixedHeight.isOn = false;
            showLightVessels.isOn = false;
            dungeonCount.value = 3;
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

    public void ResetDungeons()
    {
        for (int i = 0; i < 8; i++)
        {
            Transform child1 = bossesParent.transform.GetChild(i);
            Transform child2 = child1.GetChild(1);
            child2.GetComponent<ItemBehaviour>().currentItemCount = 0;
            child2.GetComponent<ItemBehaviour>().currentBossIndex = i;
            child2.GetComponent<ItemBehaviour>().BossItemRefresh();
        }
    }
}
