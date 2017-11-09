using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlumnosSQL
{
    class Alumno
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string materia;
        public string Materia
        {
            get { return materia; }
            set { materia = value; }
        }

        private int calificacion;
        public int Calificacion
        {
            get { return calificacion; }
            set { calificacion = value; }
        }

        public Alumno(string nombre, string materia, int calificacion)
        {
            this.nombre = nombre;
            this.materia = materia;
            this.calificacion = calificacion;
        }

        public Alumno(int id, string nombre, string materia, int calificacion): this(nombre, materia, calificacion){
            this.id = id;
        }
        
    }
}
