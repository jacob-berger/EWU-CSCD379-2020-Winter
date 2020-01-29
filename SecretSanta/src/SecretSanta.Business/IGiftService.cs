using SecretSanta.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.Business
{
    public interface IGiftService
    {
        public abstract Task<List<Gift>> FetchAllAsync();
        abstract Task<Gift> FetchByIdAsync(int id);
        public abstract Task<Gift> InsertAsync(Gift gift);
        public abstract Task<Gift[]> InsertAsync(params Gift[] gifts);
        public abstract Task<Gift> UpdateAsync(int id, Gift gift);
        public abstract Task<bool> DeleteAsync(int id);
    }
}
