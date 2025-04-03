using System.Threading;
using Cysharp.Threading.Tasks;

namespace SaveLoad
{
    public interface ILoader
    {
        UniTask<T> LoadAsync<T>(CancellationToken cancellationToken);
    }
}