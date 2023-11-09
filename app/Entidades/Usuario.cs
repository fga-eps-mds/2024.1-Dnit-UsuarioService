using api;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace app.Entidades
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public UF UfLotacao { get; set; }

        [Required, MaxLength(150)]
        public string Nome { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(200)]
        public string Senha { get; set; }

        public List<RedefinicaoSenha> RedefinicaoSenha { get; set; }

        [JsonIgnore]
        public List<Empresa>? Empresas { get; set; }

        public Guid? PerfilId { get; set; }
        public Perfil? Perfil { get; set; }

        public string? TokenAtualizacao { get; set; }
        public DateTime? TokenAtualizacaoExpiracao { get; set; }
        public int? MunicipioId { get; set; }
        public Municipio? Municipio { get; set; }
    }
}