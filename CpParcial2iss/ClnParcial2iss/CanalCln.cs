using CadParcial2iss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnParcial2iss
{
    public class CanalCln
    {
        public static int crear(Canal canal)
        {
            using (var context = new Parcial2IssEntities())
            {
                context.Canal.Add(canal);
                context.SaveChanges();
                return canal.id;
            }
        }

        public static int modificar(Canal canal)
        {
            using (var context = new Parcial2IssEntities())
            {
                var existente = context.Canal.Find(canal.id);
                if (existente != null)
                {
                    existente.nombre = canal.nombre;
                    existente.frecuencia = canal.frecuencia;
                    existente.usuarioRegistro = canal.usuarioRegistro;
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
                var existente = context.Canal.Find(id);
                if (existente != null)
                {
                    existente.estado = -1;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Canal obtenerUno(int id)
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.Canal.Find(id);
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

        public static List<paCanalLeer_Result> Leerpa(string parametro)
        {
            using (var context = new Parcial2IssEntities())
            {
                return context.paCanalLeer(parametro.Trim()).ToList();
            }
        }
    }
}
