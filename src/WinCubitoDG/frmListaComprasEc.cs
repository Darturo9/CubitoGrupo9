using CapaEntidadesDG;
using CapaLogicaNegocioDG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCubitoDG
{
    public partial class frmListaComprasEc : Form
    {
        private readonly LogicaListaComprasEc gObjLogicaEC = new LogicaListaComprasEc();
        private List<ItemCompraEC> gLstTodosEC = new List<ItemCompraEC>();
        private List<ItemCompraEC> gLstVistaEC = new List<ItemCompraEC>();

        public frmListaComprasEc()
        {
            InitializeComponent();
            SubConfigurarControlesEC();

            TemaDG.SubAplicarTemaDG(this);
            TemaDG.SubBotonDG(btnExportarEC, EstiloBotonDG.Primario, IconoDG.GuardarDG); // AJUSTAR ícono si hay uno mejor en IconoDG

            btnActualizarEC.Click += (s, e) => SubCargarListaEC();
            btnExportarEC.Click += (s, e) => SubExportarCsvEC();
            cmbTipoEC.SelectedIndexChanged += (s, e) => SubAplicarFiltroEC();
            dgvComprasEC.DataBindingComplete += (s, e) => SubPintarAgotadosEC();
            Load += (s, e) => SubCargarListaEC();
        }

        private void SubConfigurarControlesEC()
        {
            cmbTipoEC.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEC.Items.Clear();
            cmbTipoEC.Items.AddRange(new object[] { "Todos", "Prenda", "Insumo" });
            cmbTipoEC.SelectedIndex = 0;

            dgvComprasEC.AutoGenerateColumns = false;
            dgvComprasEC.Columns.Clear();
            SubAgregarColumnaEC("Estado", "Estado", 70, null);
            SubAgregarColumnaEC("Codigo", "Código", 65, null);
            SubAgregarColumnaEC("Nombre", "Artículo", 150, null);
            SubAgregarColumnaEC("Talla", "Talla", 45, null);
            SubAgregarColumnaEC("Color", "Color", 65, null);
            SubAgregarColumnaEC("Stock", "Stock", 55, "N2");
            SubAgregarColumnaEC("ComprarTexto", "Comprar", 85, null);
            SubAgregarColumnaEC("CostoEstimado", "Estimado (Q)", 85, "N2");
        }

        private void SubAgregarColumnaEC(string pStrPropiedadEC, string pStrTituloEC, int pIntPesoEC, string pStrFormatoEC)
        {
            var lObjColEC = new DataGridViewTextBoxColumn
            {
                DataPropertyName = pStrPropiedadEC,
                HeaderText = pStrTituloEC,
                FillWeight = pIntPesoEC
            };
            if (pStrFormatoEC != null)
            {
                lObjColEC.DefaultCellStyle.Format = pStrFormatoEC;
                lObjColEC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvComprasEC.Columns.Add(lObjColEC);
        }

        private void SubCargarListaEC()
        {
            try
            {
                gLstTodosEC = gObjLogicaEC.FncObtenerListaComprasEC();
                SubAplicarFiltroEC();
            }
            catch (Exception lObjExEC)
            {
                MessageBox.Show("No se pudo cargar la lista de compras: " + lObjExEC.Message,
                                "Lista de compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubAplicarFiltroEC()
        {
            string lStrTipoEC = cmbTipoEC.SelectedItem == null ? "Todos" : cmbTipoEC.SelectedItem.ToString();
            gLstVistaEC = gObjLogicaEC.FncFiltrarPorTipoEC(gLstTodosEC, lStrTipoEC);

            dgvComprasEC.DataSource = null;
            dgvComprasEC.DataSource = gLstVistaEC;

            decimal lDcmTotalEC = gObjLogicaEC.FncCalcularTotalEC(gLstVistaEC);
            int lIntAgotadosEC = gObjLogicaEC.FncContarAgotadosEC(gLstVistaEC);
            lblTotalEC.Text = string.Format("{0} artículos  |  {1} agotados  |  Total estimado: Q{2:N2}",
                                            gLstVistaEC.Count, lIntAgotadosEC, lDcmTotalEC);
        }

        private void SubPintarAgotadosEC()
        {
            foreach (DataGridViewRow lObjFilaEC in dgvComprasEC.Rows)
            {
                var lObjItemEC = lObjFilaEC.DataBoundItem as ItemCompraEC;
                if (lObjItemEC != null && lObjItemEC.Stock <= 0)
                {
                    lObjFilaEC.DefaultCellStyle.BackColor = Color.MistyRose;
                    lObjFilaEC.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }


        private void SubExportarCsvEC()
        {
            if (gLstVistaEC.Count == 0)
            {
                MessageBox.Show("No hay artículos por comprar.", "Lista de compras",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var lObjDialogoEC = new SaveFileDialog())
            {
                lObjDialogoEC.Filter = "CSV (Excel)|*.csv";
                lObjDialogoEC.FileName = "ListaCompras_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                if (lObjDialogoEC.ShowDialog() != DialogResult.OK) return;

                var lObjSbEC = new StringBuilder();
                lObjSbEC.AppendLine("Estado,Codigo,Articulo,Talla,Color,Stock,Minimo,Comprar,Unidad,Costo unitario,Costo estimado");
                foreach (ItemCompraEC lObjItemEC in gLstVistaEC)
                {
                    lObjSbEC.AppendLine(string.Join(",", new[]
                    {
                        FncCsvEC(lObjItemEC.Estado), FncCsvEC(lObjItemEC.Codigo), FncCsvEC(lObjItemEC.Nombre),
                        FncCsvEC(lObjItemEC.Talla), FncCsvEC(lObjItemEC.Color),
                        FncNumEC(lObjItemEC.Stock), FncNumEC(lObjItemEC.StockMinimo),
                        FncNumEC(lObjItemEC.CantidadSugerida), FncCsvEC(lObjItemEC.Unidad),
                        FncNumEC(lObjItemEC.CostoUnitario), FncNumEC(lObjItemEC.CostoEstimado)
                    }));
                }
                lObjSbEC.AppendLine(",,,,,,,,,Total," + FncNumEC(gObjLogicaEC.FncCalcularTotalEC(gLstVistaEC)));

                File.WriteAllText(lObjDialogoEC.FileName, lObjSbEC.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Lista exportada correctamente.", "Lista de compras",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private static string FncCsvEC(string pStrValorEC)
        {
            return "\"" + (pStrValorEC ?? "").Replace("\"", "\"\"") + "\"";
        }

        private static string FncNumEC(decimal pDcmValorEC)
        {
            return pDcmValorEC.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
}
