using app_card.Models.Interfaces;
using app_card.Repositories;

namespace app_card.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IConfiguration _config;


        public  RepositoryFactory(IConfiguration config){
        _config= config;    
        }
        public ICardRepository GetCardRepository()
        {
        
            return new CardRepository(_config);
        }
    }
}
