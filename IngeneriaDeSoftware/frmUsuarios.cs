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
            BLL_Usuario u = new BLL_Usuario();
            usuarios = u.BuscarUsuarios(incluirEliminados);
            u = null;
        }
        private void ActualizarGrillaUsuarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Password");
            dt.Columns.Add("Eliminado");
            dt.Columns.Add("Intentos Fallidos");
            dt.Columns.Add("Bloqueado");
            if (usuarios == null) return;
            foreach (BE_Usuario u in usuarios)
            {
                DataRow dr = dt.NewRow();
                dr[0] = u.Username;
                dr[1] = u.Password;
                dr[2] = u.Eliminado;
                dr[3] = u.IntentosFallidos;
                dr[4] = u.Bloqueado;
                dt.Rows.Add(dr);
            }
            dgvUsuarios.DataSource = dt;
            
            if (bool.Parse(dgvUsuarios.Rows[0].Cells[2].Value.ToString())) btnBorrar.Text = "Habilitar"; //Fuerza la actualización del botón borrar
            else btnBorrar.Text = "Borrar";
            if (bool.Parse(dgvUsuarios.Rows[0].Cells[4].Value.ToString())) btnDesbloquear.Enabled = true; //Fuerza la actualización del botón desbloquear
        }

        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0) 
                {
                    txtUsuario.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    
                    if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString())) btnBorrar.Text = "Habilitar";
                    else btnBorrar.Text = "Borrar";
                    
                    if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString())) btnDesbloquear.Enabled = true;
                    else btnDesbloquear.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema con la grilla");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario usuario = new BLL_Usuario();
                BE_Usuario u = new BE_Usuario();
                u.Username = txtUsuario.Text;
                u.Password = SecurityService.Encriptar("cambiar");
                usuario.Crear(u);
                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception ex)
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
                BLL_Usuario u = new BLL_Usuario();
                usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                
                if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString())) //Si eliminado = true
                {
                    usuario.Eliminado = false;
                }
                else //Si eliminado = false
                {
                    usuario.Eliminado= true;
                }
                u.Modificar(usuario);

                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception ex)
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
                    BLL_Usuario u = new BLL_Usuario();
                    usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    usuario.Password = SecurityService.Encriptar("cambiar");
                    u.CambiarPassword(usuario);

                    CargarListaUsuarios(true);
                    ActualizarGrillaUsuarios();
                }
            }
            catch (Exception ex)
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
                BLL_Usuario u = new BLL_Usuario();
                usuario.Username = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();

                if (bool.Parse(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString())) //Si bloqueado = true
                {
                    usuario.Bloqueado = false;
                }
                u.Modificar(usuario);
                u.ReiniciarIntentosFallidos(usuario);

                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema durante el desbloqueo del usuario");
            }
        }
    }
}
