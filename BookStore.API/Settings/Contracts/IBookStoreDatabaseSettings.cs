namespace BookStore.API.Settings.Contracts
{
    public interface IBookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string BooksCollectionName { get; set; }
    }
}
