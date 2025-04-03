using System;

public abstract class BasePresenter<TModel, TView> : IPresenter<TModel, TView>, IDisposable
    where TModel : IModel
    where TView : IView
{
    public TModel Model { get; }
    public TView View { get; }

    protected BasePresenter(TModel model, TView view)
    {
        Model = model;
        View = view;
    }

    public virtual void Dispose()
    {
    }
}