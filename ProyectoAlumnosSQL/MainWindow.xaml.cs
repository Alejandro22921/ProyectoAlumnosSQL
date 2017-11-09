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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoAlumnosSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBAlumnos.DBConectar();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno(txtNombre.Text, txtMateria.Text, Convert.ToInt16(txtCalificacion.Text));
                DBAlumnos.Agregar(alumno);
                txtNombre.Text = "";
                txtMateria.Text = "";
                txtCalificacion.Text = "";
                MessageBox.Show("Registro Añadido Exitosamente :)");
            }
            catch (Exception) {
                MessageBox.Show("Error Al Añadir Registro :(");
            }

        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            (new WBuscar()).Show();
        }
    }
}
