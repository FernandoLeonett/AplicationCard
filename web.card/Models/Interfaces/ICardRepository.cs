namespace app_card.Models.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll(DataSource DataSource1, DataSource DataSource2);
        Card GetById(int id, DataSource db);
        bool Add(Card card);
        bool Update(Card card);
        bool Delete(string id, DataSource db);
    }
}
