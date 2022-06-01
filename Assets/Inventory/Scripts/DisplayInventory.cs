using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private Inventory PlayerInventory;
    [SerializeField] private int X_SPACE_B_I;
    [SerializeField] private int Y_SPACE_B_I;
    [SerializeField] private int X_START;
    [SerializeField] private int Y_START;
    [SerializeField] private int NumberOfColumns;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    private Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_B_I *(i % NumberOfColumns)), Y_START + (-Y_SPACE_B_I * (i / NumberOfColumns)),0f);
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < PlayerInventory.Container.Count; i++)
        {
            var obj = Instantiate(PlayerInventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = PlayerInventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(PlayerInventory.Container[i], obj);
        }
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < PlayerInventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(PlayerInventory.Container[i]))
            {
                itemsDisplayed[PlayerInventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = PlayerInventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(PlayerInventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = PlayerInventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(PlayerInventory.Container[i], obj);
            }
        }
    }
    void Start()
    {
        CreateDisplay();
    }
    void Update()
    {
        UpdateDisplay();
    }

    
}
