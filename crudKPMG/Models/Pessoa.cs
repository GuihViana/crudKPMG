using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace crudKPMG.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        public int    Id           { get; set; }
        public string Nome         { get; set; }
        public string Email        { get; set; }
        public int    DDD          { get; set; }
        public int    Telefone     { get; set; }
        public string Endereco     { get; set; }
        public int    Num_endereco { get; set; }
    }
}