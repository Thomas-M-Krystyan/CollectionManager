namespace CollectionManager.Logic.Models.DTOs
{
    public readonly struct FileDto<TExtension>
        where TExtension : Enum
    {
        public string Name { get; init; }

        public TExtension Extension { get; init; }

        public byte[] Bytes { get; init; }
    }
}