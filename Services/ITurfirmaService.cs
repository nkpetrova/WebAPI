using WebAPI.Domain;
using WebAPI.Dto;

namespace WebAPI.Services
{
    public interface ITurfirmaService
    {
        List<TurFirma> GetTurfirmas();
        TurFirma GetTurfirmaById( int turfirmaId );
        int CreateTurfirma(TurfirmaDto turfirmaDto );
        void DeleteTurfirma( int turfirmaId);
        List<Tuple<TurFirma, int>> GroupByAddress();
        int UpdateTurfirma(TurfirmaDto turfirma);
    }
}