using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Inventory
{
    [UsedImplicitly]
    public sealed class InventoryModel : IModel
    {
        public event Action OnDataLoading;
        public event Action<IEnumerable<InventoryItem>> OnDataLoaded;

        private List<InventoryItem> _items = new();

        public async Task LoadInventoryAsync(CancellationToken cancellationToken)
        {
            OnDataLoading?.Invoke();
            await Task.Delay(1000, cancellationToken);
            _items = await FetchItemsFromServerAsync();
            OnDataLoaded?.Invoke(_items);
        }

        private UniTask<List<InventoryItem>> FetchItemsFromServerAsync()
        {
            var placeHolderInventory = new List<InventoryItem>
            {
                new()
                {
                    Id = 1,
                    Name = "Sword",
                    Quantity = 1,
                    SpritePath = "Sprites/sword.png"
                },
                new()
                {
                    Id = 2,
                    Name = "Shield",
                    Quantity = 1,
                    SpritePath = "Sprites/shield.png"
                },
                new()
                {
                    Id = 1,
                    Name = "Sword",
                    Quantity = 1,
                    SpritePath = "Sprites/sword.png"
                }
            };

            return UniTask.FromResult(placeHolderInventory);
        }
    }
}