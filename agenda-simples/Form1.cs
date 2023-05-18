using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agenda_simples
{
    public partial class Form1 : Form
    {
        private contato[] listaDeContatos = new contato[1];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            AtualizarLista();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddContato_Click(object sender, EventArgs e)
        {
            contato objContato = new contato(txtNome.Text, txtSobrenome.Text, txtEmail.Text, txtTelefone.Text);
            Escrever(objContato);
            Ordenar();
            Ler();
            AtualizarLista();
            LimparFormulario();

        }

        private void Escrever(contato contato)
        {
            StreamWriter escritorDeArquivos = new StreamWriter("Contato.txt");
            escritorDeArquivos.WriteLine(listaDeContatos.Length + 1);
            escritorDeArquivos.WriteLine(contato.PrimeiroNome);
            escritorDeArquivos.WriteLine(contato.Sobrenome);
            escritorDeArquivos.WriteLine(contato.Telefone);
            escritorDeArquivos.WriteLine(contato.Email);


            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                escritorDeArquivos.WriteLine(contato.PrimeiroNome);
                escritorDeArquivos.WriteLine(contato.Sobrenome);
                escritorDeArquivos.WriteLine(contato.Telefone);
                escritorDeArquivos.WriteLine(contato.Email);
            }
            escritorDeArquivos.Close();
        }

        private void Ler()
        {
            StreamReader leitorDeArquivos = new StreamReader("Contato.txt");
            listaDeContatos = new contato[Convert.ToInt32(leitorDeArquivos.ReadLine())];
            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                listaDeContatos[i] = new contato();
                listaDeContatos[i].PrimeiroNome = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Sobrenome = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Telefone = leitorDeArquivos.ReadLine();
                listaDeContatos[i].Email = leitorDeArquivos.ReadLine();
            }

            leitorDeArquivos.Close();
        }

        private void AtualizarLista()
        {
           lstContatos.Items.Clear();
            for (int i = 0; i < listaDeContatos.Length; i++)
            {
                lstContatos.Items.Add(listaDeContatos[i].ToString());
            }
        }

        private void LimparFormulario()
        {
            txtNome.Text = String.Empty;
            txtSobrenome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Ordenar();
            AtualizarLista();
        }

        private void Ordenar()
        {
            contato temporario;
            bool trocar;
            do {
                trocar = false;
                for (int i = 0; i < listaDeContatos.Length - 1; i++)
                {
                    if (listaDeContatos[i].PrimeiroNome.CompareTo(listaDeContatos[i+1].PrimeiroNome)>0)
                    {
                        temporario = listaDeContatos[i];
                        listaDeContatos[i] = listaDeContatos[i+ 1];
                        listaDeContatos[i + 1] = temporario;
                        trocar = true;
                    }
                }
            } while (trocar == true);
        }
    }
}
