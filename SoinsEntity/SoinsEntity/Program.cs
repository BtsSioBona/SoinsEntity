using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SoinsEntity
{
        class Program
    {
        static void Main(string[] args)
        {
            using (OracleEntities oracleContexte = new OracleEntities())
            {
                var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYEs
                                      select EMPLOYE;
                var lesEmployes = requeteEmployes.ToList();
                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("-------------------------------");
                var unCodeProjet = "PR1";
                var requeteEmployeProjet = from EMPLOYE in oracleContexte.EMPLOYEs
                                           where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                           select EMPLOYE;

                lesEmployes = requeteEmployeProjet.ToList();

                foreach (var unEm in lesEmployes)
                {
                    Console.WriteLine(unEm.NUMEMP + " - " + unEm.NOMEMP);
                }


                Console.WriteLine("-------------------------------");

                var employeId = 3;
                var requeteEmployesById = from EMPLOYE in oracleContexte.EMPLOYEs
                                          where EMPLOYE.NUMEMP == employeId
                                          select EMPLOYE;

                var e = requeteEmployesById.FirstOrDefault();
                if (e != null) Console.WriteLine(e.NOMEMP + " - " + e.PRENOMEMP + " - " + e.SALAIRE);
                else Console.WriteLine("L'employé numéro : " + employeId + " n'éxiste pas.");

                Console.WriteLine("-------------------------------");

                var requete = from s in oracleContexte.SEMINAIREs
                              join COUR in oracleContexte.COURS on s.CODECOURS equals COUR.CODECOURS
                              select s;
                var lesSeminaires = requete.ToList();

                foreach (var sem in lesSeminaires)
                {
                    Console.WriteLine(sem.CODESEMI + " - " + sem.CODECOURS + " - " + sem.COUR.LIBELLECOURS);
                }
                Console.WriteLine("-------------------------------");

               // var requeteCSem = from s in oracleContexte.SEMINAIREs
                              //    join COUR in oracleContexte.COURS on s.CODECOURS equals COUR.CODECOURS
                              //    select COUR.CODECOURS + COUR.LIBELLECOURS + COUR.NBJOURS + s.DATEDEBUTSEM;

                //var lesCoursSeminaire = requeteCSem.ToList();

                



            }



            Console.ReadLine();
        }
    }
}
}
