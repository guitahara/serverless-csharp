using MongoDB.Driver;

namespace coreService.db
{
    public class mongodb
    {
        public MongoClient create(){
            return new MongoClient("mongodb://tahara:tahara12@ds259144.mlab.com:59144/serverlessdb");
        }
        
    }
}