using Microsoft.EntityFrameworkCore;

namespace crudmysql.Models
{
  public class CandidatosContexto : DbContext
  {
    public CandidatosContexto(DbContextOptions<CandidatosContexto> options) : base(options)
    {

    }
    public DbSet<Candidatos> Candidatos { get; set; }
  }
}