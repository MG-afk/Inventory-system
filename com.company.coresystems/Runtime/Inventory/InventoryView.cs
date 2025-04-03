using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : BaseView
    {
        [SerializeField] private GameObject inventoryItemPrefab;
        [SerializeField] private Transform inventoryItemContainer;

        public void OnDataLoading()
        {
            // Clear existing items
            foreach (Transform child in inventoryItemContainer)
            {
                Destroy(child.gameObject);
            }
            // Show loading indicator
        }

        public void OnDataLoaded(IEnumerable<InventoryItem> items, IEnumerable<Sprite> sprites)
        {
            var spriteArray = sprites.ToArray();
            var index = 0;
            
            foreach (var inventoryItem in items)
            {
                var newItem = Instantiate(inventoryItemPrefab, inventoryItemContainer);
                var itemComponent = newItem.GetComponent<InventoryItemComponent>();
                itemComponent.SetItem(inventoryItem, index < spriteArray.Length ? spriteArray[index] : null);
                
                // Apply DoTween animation (fade in and scale up)
                newItem.transform.localScale = Vector3.zero;
                CanvasGroup canvasGroup = newItem.GetComponent<CanvasGroup>();
                if (canvasGroup == null)
                {
                    canvasGroup = newItem.AddComponent<CanvasGroup>();
                }
                canvasGroup.alpha = 0f;

                // Animate with delay for each item
                newItem.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(index * .2f);
                canvasGroup.DOFade(1f, 0.5f).SetDelay(index * .2f);
                
                index++;
            }
        }
    }
}