using System;
using System.ComponentModel.DataAnnotations;

namespace crudmysql.Models
{
  public class Candidatos
  {
    [Key]
    public int Idcandidatos { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public float Valorp { get; set; }
    public string Situacao { get; set; }
    public int Numurna { get; set; }
    public string Ocupacao { get; set; }
    public Boolean Vice { get; set; }
    public Boolean Ver { get; set; }
    public string Partido { get; set; }
    public string VicePref { get; set; }
    public DateTime Datanasc { get; set; }
  }
}