using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsEFEscuela.Dac;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela
{
    public partial class FrmAlumnos : Form
    {
        public FrmAlumnos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmAlumnos_Load(object sender, EventArgs e)
        {
            MostrarTodosAlumnos();

           
        }
        private void MostrarTodosAlumnos()
        {
            GridAlumnos.DataSource = AbmAlumno.SelectAll();


        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Creamos un objeto instancia de Categoria que toma los datos del FORMULARIO
            Alumno alumno = new Alumno() { Name = txtName.Text, Apellido = txtApellido.Text, FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text) };

            int filasAfectadas = AbmAlumno.Insert(alumno);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Insert ok");
                MostrarTodosAlumnos();


            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno() { Name = txtName.Text, Apellido = txtApellido.Text, FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text) };

            int filasAfectadas = AbmAlumno.Update(alumno);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Modificar ok");
                MostrarTodosAlumnos();


            }

           


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno() { Name = txtName.Text, Apellido = txtApellido.Text, FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text) };

            int filasAfectadas = AbmAlumno.Delete(alumno);
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Insert ok");
                MostrarTodosAlumnos();


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Alumno alumno = AbmAlumno.SelectWhereById(id);
            MessageBox.Show(alumno.Name);
        }
    }
}