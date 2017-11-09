using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAlumnosSQL
{
    /// <summary>
    /// Interaction logic for WBuscar.xaml
    /// </summary>
    public partial class WBuscar : Window
    {
        static Alumno alumnoSeleccionado = null;
        public WBuscar()
        {
            InitializeComponent();
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                DGAlumnos.ItemsSource = DBAlumnos.Buscar(txtBuscarNombre.Text);
                DGAlumnos.Items.Refresh();
            }
        }

        private void DGAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DGAlumnos.SelectedItems.Count == 1)
                {
                    alumnoSeleccionado = (Alumno)DGAlumnos.SelectedItem;
                    txtNombre.Text = alumnoSeleccionado.Nombre;
                    txtMateria.Text = alumnoSeleccionado.Materia;
                    txtCalificacion.Text = Convert.ToString(alumnoSeleccionado.Calificacion);
                }
                else
                {
                    txtNombre.Text = "";
                    txtMateria.Text = "";
                    txtCalificacion.Text = "";
                }
            }catch(Exception){}
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGAlumnos.SelectedItems.Count == 1)
                {
                    DBAlumnos.Eliminar((Alumno)DGAlumnos.SelectedItem);
                    txtNombre.Text = "";
                    txtMateria.Text = "";
                    txtCalificacion.Text = "";
                    DGAlumnos.ItemsSource = null;
                    DGAlumnos.Items.Refresh();
                    MessageBox.Show("Registro Eliminado Exitosamente :)");
                }
            }catch(Exception){}
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGAlumnos.SelectedItems.Count == 1)
                {
                    Alumno aux = (Alumno)DGAlumnos.SelectedItem;
                    DBAlumnos.Modificar(new Alumno(aux.Id, txtNombre.Text, txtMateria.Text, Convert.ToInt16(txtCalificacion.Text)));
                    txtNombre.Text = "";
                    txtMateria.Text = "";
                    txtCalificacion.Text = "";
                    DGAlumnos.ItemsSource = null;
                    DGAlumnos.Items.Refresh();
                    MessageBox.Show("Registro Modificado Exitosamente :)");
                }
            }catch(Exception){}
        }
    }
}
