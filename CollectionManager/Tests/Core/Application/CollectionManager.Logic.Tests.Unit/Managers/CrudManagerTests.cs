using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Logic.Managers;
using CollectionManager.Logic.Models.Results;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Results;
using Moq;

namespace CollectionManager.Logic.Tests.Unit.Managers
{
    [TestFixture]
    public sealed class CrudManagerTests
    {
        private readonly Mock<ICollectionManagerDbContext> _dbContextMock = new(MockBehavior.Strict);

        #region Test data
        private const ulong TestId = 1;

        private readonly ImageEntity _imageEntity = new()
        {
            Id = TestId,
            Name = "Test image",
            Extension = (byte)GraphicFileExtensions.Jpg,
            Bytes = []
        };
        #endregion

        #region Setup
        [TearDown]
        public void TearDown() => this._dbContextMock.Reset();
        #endregion

        #region RemoveAsync()
        [Test]
        public async Task RemoveAsync_Found_Removed_Saved_ReturnsSuccess()
        {
            // Arrange
            MockFind_Success(_imageEntity);
            MockRemove_Success(_imageEntity);
            MockSave_Success();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResult result = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Message, Is.EqualTo($"The operation succeeded: The object with ID: '{TestId}' was removed successfully."));

                MockFind_Verify();
                MockRemove_Verify(_imageEntity);
                MockSave_Verify();

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }

        [Test]
        public async Task RemoveAsync_Found_Removed_NotSaved_ReturnsFailure()
        {
            // Arrange
            MockFind_Success(_imageEntity);
            MockRemove_Success(_imageEntity);
            MockSave_Failure();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResult result = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Message, Is.EqualTo("The operation failed: The object with ID: '1' could not be removed. Reason: The saving failed. Nothing was changed."));

                MockFind_Verify();
                MockRemove_Verify(_imageEntity);
                MockSave_Verify();

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }
        #endregion

        #region Mocks
        private void MockFind_Success(ImageEntity imageEntity)
        {
            DatabaseResult<ImageEntity> findResult = new(true, 0, imageEntity, "The object with given ID was found.");

            this._dbContextMock
                .Setup(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(findResult);
        }

        private void MockRemove_Success(ImageEntity imageEntity)
        {
            DatabaseResult removeResult = new(true, 0, "The object with given ID was removed.");

            this._dbContextMock
                .Setup(mock => mock.Remove(imageEntity))
                .Returns(removeResult);
        }

        private void MockSave_Success()
        {
            DatabaseResult saveResult = new(true, 1, "The saving succeeded. Database was changed.");

            this._dbContextMock
                .Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(saveResult);
        }

        private void MockSave_Failure()
        {
            DatabaseResult saveResult = new(false, 0, "The saving failed. Nothing was changed.");

            this._dbContextMock
                .Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(saveResult);
        }
        #endregion

        #region Verify
        private void MockFind_Verify()
            => this._dbContextMock.Verify(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()), Times.Once);

        private void MockRemove_Verify(ImageEntity imageEntity)
            => this._dbContextMock.Verify(mock => mock.Remove(imageEntity), Times.Once);

        private void MockSave_Verify()
            => this._dbContextMock.Verify(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        #endregion
    }
}