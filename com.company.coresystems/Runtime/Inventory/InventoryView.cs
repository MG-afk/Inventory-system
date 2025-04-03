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
            foreach (Transform child in inventoryItemContainer)
            {
                Destroy(child.gameObject);
            }
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

                newItem.transform.localScale = Vector3.zero;
                var canvasGroup = newItem.GetComponent<CanvasGroup>();
                if (canvasGroup == null)
                {
                    canvasGroup = newItem.AddComponent<CanvasGroup>();
                }

                canvasGroup.alpha = 0f;

                newItem.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(index * .2f);
                canvasGroup.DOFade(1f, 0.5f).SetDelay(index * .2f);

                index++;
            }
        }
    }
}