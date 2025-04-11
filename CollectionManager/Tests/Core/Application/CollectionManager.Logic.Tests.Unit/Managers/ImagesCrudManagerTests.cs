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
    public sealed class ImagesCrudManagerTests
    {
        private readonly Mock<ICollectionManagerDbContext> _dbContextMock = new(MockBehavior.Strict);

        [TearDown]
        public void TearDown() => this._dbContextMock.Reset();

        #region RemoveAsync()
        [Test]
        public async Task RemoveAsync_ValidId_Found_Removed_Saved_ReturnsSuccess()
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

            MockFind_Success(imageEntity);
            MockRemove_Success(imageEntity);
            MockSave_Success();

            CrudManager crudManager = new(this._dbContextMock.Object);

            // Act
            CrudResult result = await crudManager.RemoveAsync<ImageEntity>(testId, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                Assert.That(result.Message, Is.EqualTo($"The operation succeeded: The object with ID: '{testId}' was removed successfully."));

                MockFind_Verify();
                MockRemove_Verify(imageEntity);
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