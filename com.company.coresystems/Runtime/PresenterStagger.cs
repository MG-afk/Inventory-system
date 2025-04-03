using Inventory;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

[UsedImplicitly]
public class PresenterStagger
{
    private readonly Transform _canvasParent;
    private readonly IObjectResolver _objectResolver;
    private readonly InventoryView _inventoryView;
    private readonly InventoryModel _inventoryModel;

    public PresenterStagger(
        Transform canvasParent,
        IObjectResolver objectResolver,
        InventoryView inventoryView,
        InventoryModel inventoryModel)
    {
        _canvasParent = canvasParent;
        _objectResolver = objectResolver;
        _inventoryView = inventoryView;
        _inventoryModel = inventoryModel;
    }

    public InventoryPresenter StageInventory()
    {
        _inventoryView.transform.SetParent(_canvasParent, false);
        _inventoryView.transform.localPosition = Vector3.zero;
        
        var presenter = new InventoryPresenter(_inventoryModel, _inventoryView);

        presenter.Initialize();

        return presenter;
    }

    public void UnstageInventory()
    {
        
    }
}