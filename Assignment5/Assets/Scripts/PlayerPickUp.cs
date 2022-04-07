using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    // Other Player Scripts
    private PlayerController _playerController;
    private PlayerResources _playerResources;
    private PlayerAudio _playerAudio;
    // Inventory
    private Inventory _inventory;
    void Start()
    {
        // Other Player Scripts
        _playerController = GetComponent<PlayerController>();
        _playerResources = GetComponent<PlayerResources>();
        _playerAudio = GetComponent<PlayerAudio>();
        // Inventory
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.
            GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                _inventory.AddItem(hitObject);
                // switch (hitObject.Type)
                // {
                    
                // }
                collision.gameObject.SetActive(false);
            }
        }
    }
    public void UseItem(ItemData item){
        if (item != null){
            _playerAudio.Play("eat");
            switch (item.Type)
                {
                    case ItemData.ItemType.Coin:
                        break;
                    case ItemData.ItemType.Apple: // Apple - Gives more health
                        _playerResources.AdjustHitPoints(item.Quantity);
                        break;
                    case ItemData.ItemType.Bananna: // Bananna - Gives mana
                        _playerResources.AdjustMana(item.Quantity);
                        break;
                    case ItemData.ItemType.Kiwi: // Kiwi - Gives damage buff
                        _playerResources.AdjustDamageMultiplier(item.Quantity);
                        break;
                    case ItemData.ItemType.Melon: // Melon - Gives permenant Health
                        _playerResources.IncreaseMaxHealth(item.Quantity);
                        break;
                    case ItemData.ItemType.Orange: // Orange - Gives more mana
                        _playerResources.AdjustMana(item.Quantity);
                        break;
                    case ItemData.ItemType.Pineapple: // Pineapple - Gives permenant mana 
                        _playerResources.IncreaseMaxMana(item.Quantity);
                        break;
                    case ItemData.ItemType.Strawberry: // Strawberry - Gives health
                        _playerResources.AdjustHitPoints(item.Quantity);
                        break;
                    case ItemData.ItemType.Cherries: // Cherries - Increase Mana Regen
                        _playerResources.IncreaseManaRegen(item.Quantity);
                        break;
                }
        }
    }
}
