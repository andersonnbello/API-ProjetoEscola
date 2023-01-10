namespace ProjetoEscola.Application.DTO_s
{
    public class StudentsAddressDTO
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public int AddressId { get; set; }

        public int Number { get; set; }

        public virtual StudentsDTO Students { get; set; }

        public virtual CountryDTO Countrys { get; set; }

        public virtual StateDTO States { get; set; }

        public virtual CityDTO Citys { get; set; }

        public virtual AddressDTO Address { get; set; }
    }
}
