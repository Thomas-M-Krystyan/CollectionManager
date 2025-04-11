using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Logic.Managers;
using CollectionManager.Logic.Models.Results;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Results;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace CollectionManager.Logic.Tests.Unit.Managers
{
    [TestFixture]
    public sealed class ImagesCrudManagerTests
    {
        private readonly Mock<ICollectionManagerDbContext> _dbContextMock = new(MockBehavior.Strict);

        [TearDown]
        public void TearDown() => this._dbContextMock.Reset();

        #region RemoveAsync()
        [Test]
        public async Task RemoveAsync_ValidId_ReturnsSuccess()
        {
            // Arrange
            const ulong testId = 1;

            ImageEntity imageEntity = new()
            {
                Id = testId,
                Name = "Test image",
                Extension = (byte)GraphicFileExtensions.Jpg,
                Bytes = []
            };

            this._dbContextMock
                .Setup(db => db.Images.FindAsync(It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(imageEntity);

            this._dbContextMock
                .Setup(db => db.Images.Remove(imageEntity))
                .Returns(It.IsAny<EntityEntry<ImageEntity>>);

            DatabaseResult expectedResult =
                new(true, 1, "The database operation was successful. Rows changed: 1.");

            this._dbContextMock
                .Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            ImagesCrudManager imagesCrudManager = new(this._dbContextMock.Object);

            // Act
            CrudResult result = await imagesCrudManager.RemoveAsync(testId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Message, Is.EqualTo($"The object with ID '{testId}' was removed successfully."));
            });
        }
        #endregion
    }
}