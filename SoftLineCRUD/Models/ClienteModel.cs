using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SoftLineCRUD.Models
{
    public class DocumentoValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Documento é obrigatório.");

            string doc = value.ToString() ?? string.Empty;
            // Remover máscara e espaços
            doc = Regex.Replace(doc, @"[\s\.\-\/]", string.Empty);

            if (IsCpf(doc) || IsCnpj(doc))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "Documento inválido.");
        }

        private static bool IsCpf(string cpf)
        {
            if (cpf.Length != 11) return false;
            if (cpf.All(c => c == cpf[0])) return false;

            int[] t1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] t2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp = cpf.Substring(0, 9);
            int sum = 0;
            for (int i = 0; i < 9; i++) sum += (temp[i] - '0') * t1[i];
            int r = sum % 11;
            int d1 = r < 2 ? 0 : 11 - r;

            temp += d1.ToString();
            sum = 0;
            for (int i = 0; i < 10; i++) sum += (temp[i] - '0') * t2[i];
            r = sum % 11;
            int d2 = r < 2 ? 0 : 11 - r;

            return cpf.EndsWith(d1.ToString() + d2.ToString());
        }

        private static bool IsCnpj(string cnpj)
        {
            if (cnpj.Length != 14) return false;
            if (cnpj.All(c => c == cnpj[0])) return false;

            int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp = cnpj.Substring(0, 12);
            int sum = 0;
            for (int i = 0; i < 12; i++) sum += (temp[i] - '0') * mult1[i];
            int r = sum % 11;
            int d1 = r < 2 ? 0 : 11 - r;

            temp += d1.ToString();
            sum = 0;
            for (int i = 0; i < 13; i++) sum += (temp[i] - '0') * mult2[i];
            r = sum % 11;
            int d2 = r < 2 ? 0 : 11 - r;

            return cnpj.EndsWith(d1.ToString() + d2.ToString());
        }
    }
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o codigo do cliente!")]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage ="Digite o nome do cliente!")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo 60 caracteres.")]
        public required string Nome { get; set; }
        [Required(ErrorMessage ="Digite a Fantasia do Cliente!")]
        [StringLength(100, ErrorMessage = "Fantasia deve ter no máximo 100 caracteres.")]
        public required string Fantasia { get; set; }
        [Required(ErrorMessage ="Digite o Documento do Cliente!")]
        [DocumentoValido(ErrorMessage = "Documento inválido. Informe CPF ou CNPJ válidos.")]
        public required string Documento { get; set; }
        [Required(ErrorMessage ="Digite o endereço do Cliente!")]
        public required string Endereco { get; set; }
    }
}
