using System;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SaveLoad
{
    public class SaveSystem : ISaver, ILoader
    {
        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "save.json");

        public SaveSystem()
        {
        }

        public async UniTask SaveAsync<T>(T data, CancellationToken cancellationToken)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var json = JsonUtility.ToJson(data, prettyPrint: true);
                await File.WriteAllTextAsync(FilePath, json, cancellationToken);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Save failed: {ex.Message}");
                throw;
            }
        }

        public async UniTask<T> LoadAsync<T>(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!File.Exists(FilePath))
                throw new FileNotFoundException("Save file not found", FilePath);

            try
            {
                var json = await File.ReadAllTextAsync(FilePath, cancellationToken);
                var data = JsonUtility.FromJson<T>(json);

                if (data == null)
                    throw new InvalidOperationException("Failed to deserialize data");

                return data;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Load failed: {ex.Message}");
                throw;
            }
        }
    }
}