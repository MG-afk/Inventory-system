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
        private List<InventoryItem> _items = new();

        public event Action OnDataLoading;
        public event Func<IEnumerable<InventoryItem>, UniTask> OnDataLoaded;

        public async Task LoadInventoryAsync(CancellationToken cancellationToken)
        {
            try
            {
                OnDataLoading?.Invoke();

                await Task.Delay(1000, cancellationToken);

                _items = await FetchItemsFromServerAsync();

                if (OnDataLoaded != null)
                {
                    await OnDataLoaded.Invoke(_items);
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
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
                },
                new()
                {
                    Id = 2,
                    Name = "Shield",
                    Quantity = 1,
                    SpritePath = "Sprites/shield.png"
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },new()
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
                },
                new()
                {
                    Id = 2,
                    Name = "Shield",
                    Quantity = 1,
                    SpritePath = "Sprites/shield.png"
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },new()
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
                },
                new()
                {
                    Id = 2,
                    Name = "Shield",
                    Quantity = 1,
                    SpritePath = "Sprites/shield.png"
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                },    new()
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
                }
            };

            return UniTask.FromResult(placeHolderInventory);
        }
    }
}