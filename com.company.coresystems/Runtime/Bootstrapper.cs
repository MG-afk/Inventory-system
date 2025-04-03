using JetBrains.Annotations;
using VContainer.Unity;

[UsedImplicitly]
public class Bootstrapper : IStartable
{
    private readonly PresenterStagger _presenterStagger;

    public Bootstrapper(PresenterStagger presenterStagger)
    {
        _presenterStagger = presenterStagger;
    }

    public void Start()
    {
        _presenterStagger.StageInventory();
    }

}