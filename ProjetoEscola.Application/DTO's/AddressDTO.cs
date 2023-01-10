using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string AddressName { get; set; }

        public string Number { get; set; }

        public string Cep { get; set; }
   }
}
