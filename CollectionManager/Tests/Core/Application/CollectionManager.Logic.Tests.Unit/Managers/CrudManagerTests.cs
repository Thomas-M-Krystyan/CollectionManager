using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Logic.Managers;
using CollectionManager.Logic.Models.Responses;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Responses;
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
            Extension = (byte)Graphics.Jpg,
            Bytes = []
        };
        #endregion

        #region Setup
        [TearDown]
        public void TearDown() => this._dbContextMock.Reset();
        #endregion

        #region RemoveAsync()
        [Test]
        public async Task RemoveAsync_NotFound_ReturnsFailure()
        {
            // Arrange
            MockFind_Failure(_imageEntity);
            MockRemove_Failure(_imageEntity);
            MockSave_Failure();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResponse response = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.False);
                Assert.That(response.Message, Is.EqualTo($"The operation failed: The object with ID '{TestId}' could not be removed. Reason: Find failed."));

                MockFind_Verify(1);
                MockRemove_Verify(0, _imageEntity);
                MockSave_Verify(0);

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }

        [Test]
        public async Task RemoveAsync_Found_NotRemoved_ReturnsFailure()
        {
            // Arrange
            MockFind_Success(_imageEntity);
            MockRemove_Failure(_imageEntity);
            MockSave_Failure();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResponse response = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.False);
                Assert.That(response.Message, Is.EqualTo($"The operation failed: The object with ID '{TestId}' could not be removed. Reason: Remove failed."));

                MockFind_Verify(1);
                MockRemove_Verify(1, _imageEntity);
                MockSave_Verify(0);

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }

        [Test]
        public async Task RemoveAsync_Found_Removed_Saved_ReturnsSuccess()
        {
            // Arrange
            MockFind_Success(_imageEntity);
            MockRemove_Success(_imageEntity);
            MockSave_Success();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResponse response = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.True);
                Assert.That(response.Message, Is.EqualTo($"The operation succeeded: The object with ID '{TestId}' was removed successfully."));

                MockFind_Verify(1);
                MockRemove_Verify(1, _imageEntity);
                MockSave_Verify(1);

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
            CrudResponse response = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.False);
                Assert.That(response.Message, Is.EqualTo($"The operation failed: The object with ID '{TestId}' could not be removed. Reason: Save failed."));

                MockFind_Verify(1);
                MockRemove_Verify(1, _imageEntity);
                MockSave_Verify(1);

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }

        [Test]
        public async Task RemoveAsync_ExceptionThrown_ReturnsFailure()
        {
            // Arrange
            this._dbContextMock
                .Setup(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Test exception."));

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResponse response = await crudManager.RemoveAsync<ImageEntity>(TestId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.False);
                Assert.That(response.Message, Is.EqualTo($"The operation failed: The object with ID '{TestId}' could not be removed. Reason: Test exception."));

                MockFind_Verify(1);
                MockRemove_Verify(0, _imageEntity);
                MockSave_Verify(0);

                this._dbContextMock.VerifyNoOtherCalls();
            });
        }
        #endregion

        #region Mocks
        private void MockFind_Success(ImageEntity imageEntity)
        {
            DatabaseResponse<ImageEntity> findResponse = new(true, 0, imageEntity, "Find succeeded.");

            this._dbContextMock
                .Setup(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(findResponse);
        }

        private void MockFind_Failure(ImageEntity imageEntity)
        {
            DatabaseResponse<ImageEntity> findResponse = new(false, 0, imageEntity, "Find failed.");

            this._dbContextMock
                .Setup(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(findResponse);
        }

        private void MockRemove_Success(ImageEntity imageEntity)
        {
            DatabaseResponse removeResponse = new(true, 0, "Remove succeeded.");

            this._dbContextMock
                .Setup(mock => mock.Remove(imageEntity))
                .Returns(removeResponse);
        }

        private void MockRemove_Failure(ImageEntity imageEntity)
        {
            DatabaseResponse removeResponse = new(false, 0, "Remove failed.");

            this._dbContextMock
                .Setup(mock => mock.Remove(imageEntity))
                .Returns(removeResponse);
        }

        private void MockSave_Success()
        {
            DatabaseResponse saveResponse = new(true, 1, "Save succeeded.");

            this._dbContextMock
                .Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(saveResponse);
        }

        private void MockSave_Failure()
        {
            DatabaseResponse saveResponse = new(false, 0, "Save failed.");

            this._dbContextMock
                .Setup(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(saveResponse);
        }
        #endregion

        #region Verify
        private void MockFind_Verify(int count)
            => this._dbContextMock.Verify(mock => mock.FindAsync<ImageEntity>(It.IsAny<ulong>(), It.IsAny<CancellationToken>()), Times.Exactly(count));

        private void MockRemove_Verify(int count, ImageEntity imageEntity)
            => this._dbContextMock.Verify(mock => mock.Remove(imageEntity), Times.Exactly(count));

        private void MockSave_Verify(int count)
            => this._dbContextMock.Verify(mock => mock.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(count));
        #endregion
    }
}