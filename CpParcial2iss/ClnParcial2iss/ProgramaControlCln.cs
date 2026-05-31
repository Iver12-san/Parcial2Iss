using CadParcial2iss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnParcial2iss
{
    public class ProgramaControlCln
    {
        public static List<ProgramaControl> listar()
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.ProgramaControl
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }
    }
}
