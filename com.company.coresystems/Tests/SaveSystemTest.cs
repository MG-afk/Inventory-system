using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SaveLoad;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class SaveSystemTest
    {
        private SaveSystem _saveSystem;
        private string _testFilePath;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _saveSystem = new SaveSystem();
            _testFilePath = Path.Combine(Application.persistentDataPath, "save.json");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Test]
        public async Task Save_ValidData_SavedSuccessfully()
        {
            var testData = new TestSaveData()
            {
                PlayerName = "TestPlayer",
                Score = 100,
                Level = 5
            };

            await _saveSystem.SaveAsync(testData, CancellationToken.None);

            Assert.That(File.Exists(_testFilePath), Is.True, "Save file should be created");
        }

        [Test]
        public async Task Load_ExistingData_LoadedSuccessfully()
        {
            var originalData = new TestSaveData()
            {
                PlayerName = "TestPlayer",
                Score = 100,
                Level = 5
            };
            await _saveSystem.SaveAsync(originalData, CancellationToken.None);

            var loadedData = await _saveSystem.LoadAsync<TestSaveData>(CancellationToken.None);

            Assert.That(loadedData, Is.Not.Null, "Loaded data should not be null");
            Assert.That(loadedData.PlayerName, Is.EqualTo(originalData.PlayerName));
            Assert.That(loadedData.Score, Is.EqualTo(originalData.Score));
            Assert.That(loadedData.Level, Is.EqualTo(originalData.Level));
        }

        [Test]
        public async Task Save_NullData_ThrowsArgumentNullException()
        {
            try
            {
                await _saveSystem.SaveAsync<TestSaveData>(null, CancellationToken.None);
                Assert.Fail("Expected ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Save_CancelledToken_OperationCancelled()
        {
            var cts = new CancellationTokenSource();
            var testData = new TestSaveData()
            {
                PlayerName = "TestPlayer",
                Score = 100,
                Level = 5
            };

            cts.Cancel();
            try
            {
                await _saveSystem.SaveAsync(testData, cts.Token);
                Assert.Fail("Expected OperationCanceledException was not thrown");
            }
            catch (OperationCanceledException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Load_NonExistentFile_ThrowsFileNotFoundException()
        {
            try
            {
                await _saveSystem.LoadAsync<TestSaveData>(CancellationToken.None);
                Assert.Fail("Expected FileNotFoundException was not thrown");
            }
            catch (FileNotFoundException)
            {
                Assert.Pass();
            }
        }

        private class TestSaveData
        {
            public string PlayerName;
            public int Score;
            public int Level;
        }
    }
}