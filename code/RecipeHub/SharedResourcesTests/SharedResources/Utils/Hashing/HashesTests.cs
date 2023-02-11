using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Hashing;

namespace SharedResourcesTests.SharedResources.Utils.Hashing
{
    public class HashesTests
    {
        [Test]
        public void ShouldNotHashNullString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                Hashes.HashToSha512(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(HashesErrorMessages.PasswordToHashCannotBeNull));
        }

        [Test]
        public void ShouldNotHashEmptyString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                Hashes.HashToSha512("   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(HashesErrorMessages.PasswordToHashCannotBeEmpty));
        }

        [Test]
        public void ShouldHashValidString()
        {
            var hashedString = Hashes.HashToSha512("000000");
            const string expectedHashedString =
                "64fcc6f6bc7a815041b4db51f00f4bea8e51c13b27f422da0a8522c94641c7e483c3f17b28d0a59add0c8a44a4e4fc1dd3a9ea48bad8cf5b707ac0f44a5f3536";

            Assert.That(hashedString, Is.EqualTo(expectedHashedString));
        }
    }
}
