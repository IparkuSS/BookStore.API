using BookStore.API.Settings.Contracts;

namespace BookStore.API.Settings
{
    public class BookStoreDatabaseSettings : IBookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string BooksCollectionName { get; set; }
    }
}
