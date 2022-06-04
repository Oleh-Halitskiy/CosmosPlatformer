using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("Sell items")]
    [SerializeField] private Item item1;
    [SerializeField] private Item item2;
    [SerializeField] private Item item3;
    [SerializeField] private Item item4;
    [Header("Prices")]
    [SerializeField] private int FirstPrice;
    [SerializeField] private int SecondPrice;
    [SerializeField] private int ThirdPrice;
    [SerializeField] private int FourthPrice;
    [Header("Utils")]
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private GameObject shopPanel;
    private BoxCollider2D boxCollider;
    private Inventory playerInventory;
    private InventorySlot coins;
    private InventorySlot crystals;
    private bool ShopOpened = false;
    void Start()
    {
       boxCollider = GetComponent<BoxCollider2D>();
        playerInventory = NewPlayer.Instance.PlayerInventory;
    }
    private void CheckBuyer()
    {
        for (int i = 0; i < playerInventory.Container.Count; i++)
        {
           if(playerInventory.Container[i].item.type == ItemType.Coin)
            {
                coins = playerInventory.Container[i];
            }
           else if(playerInventory.Container[i].item.type == ItemType.Crystal)
            {
                crystals = playerInventory.Container[i];
            }
        }
    }
    void Update()
    {
        if (ShopOpened)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(coins != null && coins.amount >= FirstPrice)
                {
                    coins.RemoveAmount(10);
                    playerInventory.AddItem(item1,1);

                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (crystals != null && crystals.amount >= SecondPrice)
                {
                    crystals.RemoveAmount(SecondPrice);
                    playerInventory.AddItem(item2, 1);

                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //buy item 3
                Debug.Log("Three is pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //buy item 4
                Debug.Log("Four is pressed");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            CheckBuyer();
            shopPanel.SetActive(true);
            ShopOpened = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            shopPanel.SetActive(false);
            ShopOpened = false;
        }
    }
}
