using System;
using System.Windows.Forms;
using MultApps.Models.Entities;

namespace MultApps.Windows
{
    public partial class Principal: Form
    {
        public Usuario UsuarioLogado { get; set; }

        public Principal()
        {
            InitializeComponent();
        }

        //Polimorfismo de construtor com sobrecarga diferente
        public Principal(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogado = usuario;
        }

        private void menuCalculadoraImc_Click(object sender, EventArgs e)
        {
            var form = new FrmCalculadoraIMC();
            form.MdiParent = this;
            form.Show();
        }

        private void MDIPrincipal_Shown(object sender, EventArgs e)
        {
            var loading = new SplashScreen();
            loading.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            statusLabelUsuario.Text = UsuarioLogado.Nome;
        }
    }
}
