using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmUsuarios : Form
    {
        List<BE_Usuario> usuarios;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarListaUsuarios(true);
            ActualizarGrillaUsuarios();
        }

        private void CargarListaUsuarios(bool incluirEliminados) 
        {
            usuarios = UsuarioService.BuscarUsuarios(incluirEliminados);
        }
        private void ActualizarGrillaUsuarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Intentos Fallidos");
            dt.Columns.Add("Bloqueado");
            dt.Columns.Add("Eliminado");
            if (usuarios == null) return;
            foreach (BE_Usuario u in usuarios)
            {
                DataRow dr = dt.NewRow();
                dr[0] = u.Id;
                dr[1] = u.Username;
                dr[2] = u.Password;
                dr[3] = u.Nombre;
                dr[4] = u.Apellido;
                dr[5] = u.Email;
                dr[6] = u.Telefono;
                dr[7] = u.IntentosFallidos;
                dr[8] = u.Bloqueado;
                dr[9] = u.Eliminado;
                dt.Rows.Add(dr);
            }
            dgvUsuarios.DataSource = dt;
            
            if (bool.Parse(dgvUsuarios.Rows[0].Cells[9].Value.ToString())) btnBorrar.Text = "Habilitar"; //Fuerza la actualización del botón borrar
            else btnBorrar.Text = "Borrar";
            if (bool.Parse(dgvUsuarios.Rows[0].Cells[8].Value.ToString())) btnDesbloquear.Enabled = true; //Fuerza la actualización del botón desbloquear
        }

        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0) 
                {
                    txtUsername.Text = dgvUsuarios.SelectedRows[0].Cells["Username"].Value.ToString();
                    txtNombre.Text = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = dgvUsuarios.SelectedRows[0].Cells["Apellido"].Value.ToString();
                    txtEmail.Text = dgvUsuarios.SelectedRows[0].Cells["Email"].Value.ToString();
                    txtTelefono.Text = dgvUsuarios.SelectedRows[0].Cells["Telefono"].Value.ToString();
                    
                    if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells["Eliminado"].Value.ToString())) btnBorrar.Text = "Habilitar";
                    else btnBorrar.Text = "Borrar";
                    
                    if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells["Bloqueado"].Value.ToString())) btnDesbloquear.Enabled = true;
                    else btnDesbloquear.Enabled = false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema con la grilla");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Username = txtUsername.Text;
                usuario.Password = SeguridadService.Encriptar("cambiar");
                UsuarioService.Crear(usuario);
                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema durante la creación del usuario");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count <= 0) return;
                BE_Usuario usuario = new BE_Usuario();
                usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                
                if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString())) //Si eliminado = true
                {
                    usuario.Eliminado = false;
                }
                else //Si eliminado = false
                {
                    usuario.Eliminado= true;
                }
                UsuarioService.Modificar(usuario);

                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema durante el borrado del usuario");
            }
        }

        private void btnReestablecerPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    BE_Usuario usuario = new BE_Usuario();
                    usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    usuario.Password = SeguridadService.Encriptar("cambiar");
                    UsuarioService.CambiarPassword(usuario);

                    CargarListaUsuarios(true);
                    ActualizarGrillaUsuarios();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema al intentar reestablecer la contraseña");
            }

        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count <= 0) return;
                BE_Usuario usuario = new BE_Usuario();
                usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();

                if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString())) //Si bloqueado = true
                {
                    usuario.Bloqueado = false;
                }
                UsuarioService.Modificar(usuario);
                UsuarioService.ReiniciarIntentosFallidos(usuario);

                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un problema durante el desbloqueo del usuario");
            }
        }
    }
}
