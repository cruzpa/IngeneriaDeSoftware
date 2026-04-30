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
    public partial class frmBitacora : Form
    {
        List<BE_Bitacora> lista;
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipo.SelectedIndex = 0;
                dtpDesde.Value = DateTime.Now.AddDays(-7);
                dtpHasta.Value = DateTime.Now;
                CargarLista();
                ActualizarGrilla();
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                try
                {
                    BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GetInstance.usuario.Username, DateTime.UtcNow, "CRITICAL", ex.Message);
                    BitacoraService.Crear(bitacora);
                    MessageBox.Show("Error crítico, contacte al administrador.");
                }
                catch { throw new Exception("HAY QUE HACER EL LOG DE BITACORA LOCAL EN TXT"); }
            }
        }

        private void CargarLista()
        {
            try
            {
                DateTime desde = dtpDesde.Value.ToUniversalTime().Date;
                DateTime hasta = dtpHasta.Value.AddDays(1).ToUniversalTime().Date;//Sumo un día, porque en la DB cuenta las horas, de esta forma toma hasta el día ingresado a las 23:59:59
                if (cmbTipo.Text == "TODOS") { lista = BitacoraService.Buscar(desde, hasta); }
                else { lista = BitacoraService.Buscar(cmbTipo.Text, desde, hasta); }
            }
            catch (Exception ex)
            {
                try
                {
                    BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GetInstance.usuario.Username, DateTime.UtcNow, "CRITICAL", ex.Message);
                    BitacoraService.Crear(bitacora);
                    MessageBox.Show("Error crítico, contacte al administrador.");
                }
                catch { throw new Exception("HAY QUE HACER EL LOG DE BITACORA LOCAL EN TXT"); }
            }
        }
        private void ActualizarGrilla()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Usuario");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Descripcion");
                if (lista == null) return;
                foreach (BE_Bitacora b in lista)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = b.Id;
                    dr[1] = b.Username;
                    dr[2] = (b.FechaYHora).ToLocalTime();
                    dr[3] = b.Tipo;
                    dr[4] = b.Descripcion;
                    dt.Rows.Add(dr);
                }
                dgvBitacora.DataSource = dt;
            }
            catch (Exception ex)
            {
                try
                {
                    BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GetInstance.usuario.Username, DateTime.UtcNow, "CRITICAL", ex.Message);
                    BitacoraService.Crear(bitacora);
                    MessageBox.Show("Error crítico, contacte al administrador.");
                }
                catch { throw new Exception("HAY QUE HACER EL LOG DE BITACORA LOCAL EN TXT"); }
            }
        }
        private void ConfigurarGrilla()
        {
            try
            {
                if (lista == null) return;
                if (lista.Count == 0) return;
                dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvBitacora.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBitacora.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvBitacora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                try
                {
                    BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GetInstance.usuario.Username, DateTime.UtcNow, "CRITICAL", ex.Message);
                    BitacoraService.Crear(bitacora);
                    MessageBox.Show("Error crítico, contacte al administrador.");
                }
                catch { throw new Exception("HAY QUE HACER EL LOG DE BITACORA LOCAL EN TXT"); }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarLista();
            ActualizarGrilla();
        }
    }
}
