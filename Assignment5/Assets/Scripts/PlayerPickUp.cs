using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    // Other Player Scripts
    private PlayerController _playerController;
    private PlayerResources _playerResources;
    void Start()
    {
        // Other Player Scripts
        _playerController = GetComponent<PlayerController>();
        _playerResources = GetComponent<PlayerResources>();
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
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                    
                        break;
                    case ItemData.ItemType.Apple: // Apple - Gives more health
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Bananna: // Bananna - Gives mana
                        _playerResources.AdjustMana(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Kiwi: // Kiwi - Gives damage buff
                        _playerResources.AdjustDamageMultiplier(hitObject.Quantity, 10f);
                        break;
                    case ItemData.ItemType.Melon: // Melon - Gives permenant Health
                        _playerResources.IncreaseMaxHealth(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Orange: // Orange - Gives more mana
                        _playerResources.AdjustMana(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Pineapple: // Pineapple - Gives permenant mana 
                        _playerResources.IncreaseMaxMana(hitObject.Quantity);
                        break;
                    case ItemData.ItemType.Strawberry: // Strawberry - Gives health
                        _playerResources.AdjustHitPoints(hitObject.Quantity);
                        break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
}
