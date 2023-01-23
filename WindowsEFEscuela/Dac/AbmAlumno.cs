using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Dac
{
    public class AbmAlumno
    {
        private static DbEscuelaEF context = new DbEscuelaEF();

        public static List<Alumno> SelectAll() 
        {
            return context.Alumnos.ToList(); 
        }



        public static Alumno SelectWhereById(int id) //Traer una por ID
        {
            return context.Alumnos.Find(id);

        }

        public static int Insert(Alumno alumno) // Inserto en el obj categoria
        {
            context.Alumnos.Add(alumno);
            return context.SaveChanges();
        }

        public static int Update(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.AlumnoId); // Busca el objeto primero. Despues modificar
            alumnoOrigen.Name = alumno.Name;
            alumnoOrigen.Apellido = alumno.Apellido;
            alumnoOrigen.FechaNacimiento = alumno.FechaNacimiento;

            return context.SaveChanges();

        }

        public static int Delete(Alumno alumno)
        {
            Alumno alumnoOrigen = context.Alumnos.Find(alumno.AlumnoId); //Busca el objeto primero por ID ingresado.
            if (alumnoOrigen != null) // Si la posición indicada NO está vacía continúa para borrar
            {
                context.Alumnos.Remove(alumnoOrigen);
                return context.SaveChanges(); // Entro a la BD, borra y actualiza y vuelve. 
            }
            return 0; // Si no se pudo eliminar porque no existe el id de esa categoría retorna 0. No borra nada. 
        }
    }
}
