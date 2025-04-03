using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Inventory
{
    [UsedImplicitly]
    public class InventoryPresenter : BasePresenter<InventoryModel, InventoryView>
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly CancellationToken _cancellationToken;

        public InventoryPresenter(InventoryModel model, InventoryView view) : base(model, view)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        public void Initialize()
        {
            Model.OnDataLoading += View.OnDataLoading;
            Model.OnDataLoaded += HandleInventoryDataLoaded;

            UniTask.Create(async token => { await Model.LoadInventoryAsync(token); }, _cancellationToken).Forget();
        }

        private void HandleInventoryDataLoaded(IEnumerable<InventoryItem> items)
        {
            var spriteLoadTasks = items
                .Select(item => LoadSpriteForInventoryItemAsync(item, _cancellationToken))
                .Where(task => task != null)
                .Select(task => task!.Value)
                .ToList();

            UniTask.Create(async () =>
            {
                var sprites = await UniTask.WhenAll(spriteLoadTasks);
                View.OnDataLoaded(items, sprites);
            }).Forget();
        }

        private UniTask<Sprite>? LoadSpriteForInventoryItemAsync(InventoryItem item,
            CancellationToken cancellationToken)
        {
            var handle = Addressables.LoadAssetAsync<Sprite>(item.SpritePath);

            try
            {
                return handle.ToUniTask(cancellationToken: cancellationToken).ContinueWith(sprite =>
                {
                    Addressables.Release(handle);
                    return sprite;
                });
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning($"Sprite loading for '{item.Name}' was canceled.");
                Addressables.Release(handle);
                return null;
            }
            catch
            {
                Debug.LogError($"Failed to load sprite for item: {item.Name}");
                Addressables.Release(handle);
                return null;
            }
        }

        public override void Dispose()
        {
            Model.OnDataLoading -= View.OnDataLoading;
            Model.OnDataLoaded -= HandleInventoryDataLoaded;

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();

            base.Dispose();
        }
    }
}