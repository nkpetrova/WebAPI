using WebAPI.Domain;

namespace WebAPI.Repositories
{
    public interface ITurfirmaRepository
    {
        List<TurFirma> GetAll();
        TurFirma GetById( int id );
        int Create(TurFirma turfirma );
        void Delete(TurFirma turfirma);
        int Update(TurFirma turfirma);
        List<Tuple<TurFirma, int>> GroupByAddress();
    }
}