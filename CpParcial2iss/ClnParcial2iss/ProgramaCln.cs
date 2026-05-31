using CadParcial2iss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnParcial2iss
{
    public class ProgramaCln
    {
        public static int crear(Programa programa)
        {
            using (var context = new Parcial2IssEntities())
            {
                context.Programa.Add(programa);
                context.SaveChanges();
                return programa.id;
            }
        }

        public static int modificar(Programa programa)
        {
            using (var context = new Parcial2IssEntities())
            {
                var existente = context.Programa.Find(programa.id);
                if (existente != null)
                {
                    existente.idCanal = programa.idCanal;
                    existente.titulo = programa.titulo;
                    existente.descripcion = programa.descripcion;
                    existente.duracion = programa.duracion;
                    existente.productor = programa.productor;
                    existente.fechaEstreno = programa.fechaEstreno;
                    existente.idProgramaControl = programa.idProgramaControl;
                    existente.usuarioRegistro = programa.usuarioRegistro;
                    existente.fechaRegistro = DateTime.Now;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new Parcial2IssEntities())
            {
                var existente = context.Programa.Find(id);
                if (existente != null)
                {
                    existente.estado = -1;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Programa obtenerUno(int id)
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.Programa.Find(id);
            }
        }

        public static List<Canal> listar()
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.Canal
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }

        public static List<paProgramaLeer_Result> Leerpa(string parametro)
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.paProgramaLeer(parametro.Trim()).ToList();
            }
        }
    }
}
