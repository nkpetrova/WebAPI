using WebAPI.Domain;

namespace WebAPI.Dto
{
    public static class TurfirmaDtoExtensions
    {
        public static TurFirma ConvertToTurfirma(this TurfirmaDto turfirmaDto )
        {
            return new TurFirma
            (
                turfirmaDto.Id,
                turfirmaDto.Name,
                turfirmaDto.Address,
                turfirmaDto.Commission

            );
        }

        public static TurfirmaDto ConvertToTurfirmaDto( this TurFirma turfirma )
        {
            return new TurfirmaDto
            {
                Id = turfirma.Id,
                Name = turfirma.Name,
                Address = turfirma.Address,
                Commission = turfirma.Commission
            };
        }
    }
}
