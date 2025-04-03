using System.Threading;
using Cysharp.Threading.Tasks;

namespace SaveLoad
{
    public interface ISaver
    {
        UniTask SaveAsync<T>(T data, CancellationToken cancellationToken);
    }
}