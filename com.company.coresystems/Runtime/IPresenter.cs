public interface IPresenter<out TModel, out TView>
    where TModel : IModel
    where TView : IView
{
    TModel Model { get; }
    TView View { get; }
}