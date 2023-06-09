﻿using Shared_Resources.Data.IO;

namespace SharedResourcesTests.SharedResources.Data.IO.SessionKeySerializerTests
{
    public class JsonSerializerTests
    {
        [Test]
        public void ShouldSaveAndLoadSessionKey()
        {
            SessionKeySerializers.SaveSessionKey("test", "test.txt");
            var fileContent = SessionKeySerializers.LoadSessionKey("test.txt");
            Assert.That(fileContent, Is.EqualTo("test"));
        }

        [Test]
        public void ShouldHandleLoadingIfFileDoesNotExist()
        {
            var fileContent = SessionKeySerializers.LoadSessionKey("thisFileDoesNotExist.txt");
            Assert.That(fileContent, Is.Empty);
        }
    }
}