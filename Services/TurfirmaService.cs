using WebAPI.Domain;
using WebAPI.Dto;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class TurfirmaService : ITurfirmaService
    {
        private readonly ITurfirmaRepository _turfirmaRepository;

        public TurfirmaService(ITurfirmaRepository turfirmaRepository)
        {
            _turfirmaRepository = turfirmaRepository;
        }

        public List<TurFirma> GetTurfirmas()
        {
            return _turfirmaRepository.GetAll();
        }

        public int CreateTurfirma( TurfirmaDto turfirma )
        {
            if (turfirma == null )
            {
                throw new Exception( $"{nameof( TurFirma )} is not found!" );
            }

            TurFirma turfirmaEntity = turfirma.ConvertToTurfirma();

            return _turfirmaRepository.Create(turfirmaEntity);
        }

        public void DeleteTurfirma( int turfirmaId )
        {
            TurFirma turfirma = _turfirmaRepository.GetById( turfirmaId );
            if (turfirma == null )
            {
                throw new Exception( $"{nameof(TurFirma)} not found, #Id - {turfirmaId}" );
            }

            _turfirmaRepository.Delete(turfirma);
        }

        public TurFirma GetTurfirmaById( int turfirmaId )
        {
            TurFirma turfirma = _turfirmaRepository.GetById(turfirmaId);
            if (turfirma == null )
            {
                throw new Exception( $"{nameof(TurFirma)} not found, #Id - {turfirmaId}" );
            }

            return turfirma;
        }

        public List<Tuple<TurFirma, int>> GroupByAddress()
        {
            return _turfirmaRepository.GroupByAddress();
        }

        public int UpdateTurfirma(TurfirmaDto turfirma)
        {
            if (turfirma == null)
            {
                throw new Exception($"{nameof(TurFirma)} is not found!");
            }
            TurFirma turfirmaEntity = turfirma.ConvertToTurfirma();
            TurFirma turfirmaTemp = _turfirmaRepository.GetById(turfirmaEntity.Id);
            if (turfirmaTemp == null)
            {
                throw new Exception($"{nameof(TurFirma)} is not found!");
            }
            return _turfirmaRepository.Update(turfirmaEntity);
        }

    }
}