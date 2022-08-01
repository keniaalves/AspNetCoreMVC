using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDemoMVC.Models
{
	public class Filme
	{
		//[RegularExpression(@"^[0-4]*$")] Não dá pra usar annotation regular expression em enum
		public enum TipoAvaliacao { pessimo, ruim, medio, bom, otimo }
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "O campo título é obrigatório")]
		[StringLength(60, MinimumLength = 5, ErrorMessage = "O título deve ter de 5 a 60 caracteres")]
		public string Titulo { get; set; }
		[Required(ErrorMessage = "O campo data de lançamento é obrigatório")]
		[DataType(DataType.DateTime, ErrorMessage = "A data está em formato incorreto")]
		[Display(Name = "Data de lançamento")] //O nome que vai ser exibido nas views
		public DateTime DataLancamento { get; set; }
		[RegularExpression (@"(?i)^[a-z’'()/.,\s-]+$", ErrorMessage = "Gênero em formato inválido")]
		[StringLength(30, ErrorMessage = "Por favor, não ultrapasse 30 caracteres ao especificar o gênero")]
		public string Genero { get; set; }
		[Range(1,1000, ErrorMessage = "Valores permitidos entre 1 e mil")]
		[Column(TypeName = "decimal(18,2)")]//Como vai ser a coluna do banco de dados em relação a essa propriedade
		public decimal Valor { get; set; }
		[Display(Name = "Avaliação")]
		public TipoAvaliacao Avaliacao { get; set; }

	}
}
