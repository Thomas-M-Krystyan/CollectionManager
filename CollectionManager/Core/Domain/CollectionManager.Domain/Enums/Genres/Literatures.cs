using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Domain.Enums.Genres
{
    /// <summary>
    /// Supported item ategories.
    /// </summary>
    public enum Literatures
    {
        Action,

        Adventure,

        Comedy,

        Crime,

        Cyberpunk,

        Detective,

        Documentary,

        Drama,

        Dystopian,

        Erotic,

        Family,

        Fantasy,

        Fiction,

        Historical,

        Horror,

        Manga,

        Mystery,

        Mythology,

        [Display(Name = "Non-Fiction")]
        NonFiction,

        Parody,

        Philosophical,

        Political,

        Pornographic,

        [Display(Name = "Post-Apocalyptic")]
        PostApocalyptic,

        Psychological,

        Romance,

        Satire,

        Science,

        [Display(Name = "Science-Fiction")]
        ScienceFiction,

        [Display(Name = "Slice of Life")]
        SliceOfLife,

        Space,

        [Display(Name = "Space Opera")]
        SpaceOpera,

        Sports,

        [Display(Name = "Steampunk")]
        Steampunk,

        [Display(Name = "Super Hero")]
        Superhero,

        [Display(Name = "Super Heroine")]
        Superheroine,

        Supernatural,

        [Display(Name = "Super Villain")]
        Supervillain,

        Suspense,

        [Display(Name = "Sword & Sorcery")]
        SwordAndSorcery,

        Technology,

        Thriller,

        [Display(Name = "Time Travel")]
        TimeTravel,

        Tragedy,

        Urban,

        Utopian,

        Vampire,

        War,

        Western,

        Other
    }
}