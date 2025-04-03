using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItemComponent : MonoBehaviour
    {
        public void SetItem(InventoryItem inventoryItem, Sprite sprite)
        {
            var image = GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}