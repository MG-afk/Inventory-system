using Inventory;
using SaveLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CoreSystemLifetimeScope : LifetimeScope
{
    [SerializeField] private Transform canvasParent;
    [SerializeField] private InventoryView inventoryView;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(canvasParent);
        builder.Register<SaveSystem>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.RegisterComponentInNewPrefab(inventoryView, Lifetime.Transient)
            .As<InventoryView>()
            .AsSelf();

        builder.Register<InventoryModel>(Lifetime.Transient)
            .As<InventoryModel>()
            .AsSelf();

        builder.Register<PresenterStagger>(Lifetime.Singleton)
            .AsSelf();

        builder.RegisterEntryPoint<Bootstrapper>();
    }
}