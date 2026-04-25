using BE;
using BLL;
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
            cmbTipo.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
            CargarLista();
            ActualizarGrilla();
        }

        private void CargarLista()
        {
            DateTime desde = dtpDesde.Value.ToUniversalTime().Date;
            DateTime hasta = dtpHasta.Value.AddDays(1).ToUniversalTime().Date;//Sumo un día, porque en la DB cuenta las horas, de esta forma toma hasta el día ingresado a las 23:59:59
            lista = BitacoraService.Buscar(cmbTipo.Text, desde.ToString(), hasta.ToString());
        }
        private void ActualizarGrilla()
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
                dr[1] = b.Usuario;
                dr[2] = (b.FechaYHora).ToLocalTime();
                dr[3] = b.Tipo;
                dr[4] = b.Descripcion;
                dt.Rows.Add(dr);
            }
            dgvBitacora.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarLista();
            ActualizarGrilla();
        }
    }
}
