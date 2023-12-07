using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TerminatorModel.DTO;

namespace TerminatorModel.DAL
{
    public class TerminatorDAL
    {
        private static List<Terminator> terminators = new List<Terminator>();

        public void Save(Terminator t)
        {
            terminators.Add(t);
        }

        public List<Terminator> GetAll()
        {
            return terminators;
        }

        public List<Terminator> FindByModeloAndYear(Tipo tipo, int year)
        {
            return terminators.FindAll(t => t.Tipo == tipo && t.YearDestino == year);
        }

        public Terminator FindByNumeroSerie(string numeroSerie)
        {
            return terminators.Find(t => t.NumeroSerie == numeroSerie);
        }

        public void Delete(Terminator t)
        {
            terminators.Remove(t);
        }
    }
}
