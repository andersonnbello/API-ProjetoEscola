namespace ProjetoEscola.Application.DTO_s
{
    public class StudentsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public int Age { get; set; }

        public DateTime CreatAt { get; set; }

        public DateTime? UpdatAt { get; set; }

        public bool isActive { get; set; }

    }
}
