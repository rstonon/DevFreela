using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDBContext
    {
        public DevFreelaDBContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu Projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000),
                new Project("Meu Projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000),
            };

            Users = new List<User>
            {
                new User("Rafael Tonon", "rstonon@gmail.com", new DateTime(1991, 8, 7)),
                new User("Luis Dev", "luisdev@gmail.com", new DateTime(1992, 1, 1)),
                new User("Micael Otowicz", "micael@gmail.com", new DateTime(1994, 6, 5)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL"),
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> Comments { get; set; }

    }
}
