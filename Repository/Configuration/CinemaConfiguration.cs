using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasData
        (
            new Cinema
            {
                Uuid = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "De Studio",
                City = "Antwerp",
                Country = "Belgium",
                Color = "place",
                LogoUrl = "https://www.destudio.com/sites/default/files/2021-08/DeStudio_logo.svg"
            },
            new Cinema
            {
                Uuid = new Guid("a6479f2a-963b-490f-ba92-6bdb99eb1f04"),
                Name = "Lumières",
                City = "Antwerp",
                Country = "Belgium",
                Color = "place",
                LogoUrl = "https://www.lumiere-antwerpen.be/wp-content/uploads/2019/12/logo-lumiere-cinema.svg"
            },
            new Cinema
            {
                Uuid = new Guid("8b659e03-0435-485b-8f77-9dff6e1f40e6"),
                Name = "Cartoon's",
                City = "Antwerp",
                Country = "Belgium",
                Color = "place",
                LogoUrl = "https://cinemacartoons.be/wp-content/uploads/2019/12/logo-cartoons-cinema-black.svg"
            }
        );
    }
}