using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Used for coins, health, inventory items, and even ammo if you want to create a gun shooting mechanic!*/

public class Collectable : MonoBehaviour
{

    enum ItemTypeCol { InventoryItem, Coin, Health, Ammo }; //Creates an ItemType category
    [SerializeField] ItemTypeCol itemType; //Allows us to select what type of item the gameObject is in the inspector
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioClip[] collectSounds;
    [SerializeField] private int itemAmount;
    [SerializeField] private string itemName; //If an inventory item, what is its name?
    [SerializeField] private Sprite UIImage; //What image will be displayed if we collect an inventory item?
    private int MoneyCount;
    private int AddScore = 10;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            Collect();
        }

        //Collect me if I trigger with an object tagged "Death Zone", aka an area the player can fall to certain death
        if (col.gameObject.layer == 14)
        {
            Collect();
        }
    }

    public void Collect()
    {
        if (itemType == ItemTypeCol.InventoryItem)
        {
            if (itemName != "")
            {
                GameManager.Instance.GetInventoryItem(itemName, UIImage);
            }
        }
        else if (itemType == ItemTypeCol.Coin)
        {
            ItemGO itemGo = GetComponentInParent<ItemGO>();
            NewPlayer.Instance.PlayerInventory.AddItem(itemGo.item, 1);
            Debug.Log(NewPlayer.Instance.PlayerInventory.Container.Count);
            if(itemGo.item.type == ItemType.Coin)
            {
                PlayerPrefs.SetInt("MoneyCount", ++MoneyCount);
            }
            AddScore += PlayerPrefs.GetInt("CurrentScore", 0);
            PlayerPrefs.SetInt("CurrentScore", AddScore);   
           // NewPlayer.Instance.coins += itemAmount;
        }
        else if (itemType == ItemTypeCol.Health)
        {
            if (NewPlayer.Instance.health < NewPlayer.Instance.maxHealth)
            {
                GameManager.Instance.hud.HealthBarHurt();
                NewPlayer.Instance.health += itemAmount;
            }
        }
        else if (itemType == ItemTypeCol.Ammo)
        {
            if (NewPlayer.Instance.ammo < NewPlayer.Instance.maxAmmo)
            {
                GameManager.Instance.hud.HealthBarHurt();
                NewPlayer.Instance.ammo += itemAmount;
            }
        }

        GameManager.Instance.audioSource.PlayOneShot(collectSounds[Random.Range(0, collectSounds.Length)], Random.Range(.6f, 1f));

        NewPlayer.Instance.FlashEffect();


        //If my parent has an Ejector script, it means that my parent is actually what needs to be destroyed, along with me, once collected
        if (transform.parent.GetComponent<Ejector>() != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
