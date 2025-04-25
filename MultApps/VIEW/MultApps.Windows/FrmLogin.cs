using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultApps.Models.Enums;
using MultApps.Models.Repositories;
using MultApps.Models.Services;

namespace MultApps.Windows
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Usuário é obrigatorio");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Senha é obrigatoria");
                txtSenha.Focus();
                return;
            }

            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.ObterUsuarioPorEmail(txtUsuario.Text);

            //se o objeto usuário for nulo ou o email do banco é diferente do txtUsuario
            if (usuario == null || usuario.Email != txtUsuario.Text)
            {
                MessageBox.Show("Usuário não encontrado");
                txtUsuario.Focus();
                return;
            }
            
            if (usuario.Status == StatusEnum.Inativo)
            {
                MessageBox.Show("O usuário está inativo");
                txtUsuario.Focus();
                return;
            }

            var senhaConfere = CriptografiaService.Verificar(txtSenha.Text, usuario.Senha);

            if (senhaConfere)
            {
                MessageBox.Show("Usuarios e senha correto");
                return;
            }
            else
            {
                MessageBox.Show("Usuário ou senha invalida");
                return;

            }
        }
    }
}
