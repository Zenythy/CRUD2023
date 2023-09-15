using CRUD_BUSINESS;
using CRUD_DAO;
using CRUD_DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD2023
{
    public partial class frm_clientes : Form
    {


        CRUD_BUSINESS.PessoaBLL pessoaBLL = new CRUD_BUSINESS.PessoaBLL();

        Pessoa_DTO pessoaDto = new Pessoa_DTO();

        Endereco_DTO enderecoDto = new Endereco_DTO();

        public frm_clientes()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            pessoaDto.nome = txt_nome.Text;
            pessoaDto.sexo = cb_sexo.Text;
            pessoaDto.email = txt_email.Text;
            pessoaDto.cpf = txt_cpf.Text;
            pessoaDto.telefone = txt_telefone.Text;
            

            enderecoDto.rua = txt_endereco.Text;
            enderecoDto.cidade = txt_cidade.Text;
            enderecoDto.estado = cb_estado.Text;
            pessoaDto.endereco = enderecoDto;

            Cadastrar(pessoaDto);

            MessageBox.Show("Cliente Cadastrado com Sucesso!");
        }

        
        public bool Cadastrar(Pessoa_DTO pessoa)
        {

            return pessoaBLL.Cadastro(pessoa);

        }

        public void frm_clientes_Load(object sender, EventArgs e)
        {

            string comando_select = @"select * from clientes;";

            Conexao con = new Conexao();

            try
            {

                

                SqlDataAdapter data_adapt = new SqlDataAdapter(comando_select, con.conectar());

                DataTable data_tab = new DataTable();

                data_adapt.Fill(data_tab);

                dgv_clientes.DataSource = data_tab;

                
                //Muda o cabeçalho de cada coluna
                dgv_clientes.Columns[0].HeaderText = "ID";
                dgv_clientes.Columns[1].HeaderText = "Nome";
                dgv_clientes.Columns[2].HeaderText = "Sexo";
                dgv_clientes.Columns[3].HeaderText = "E-Mail";
                dgv_clientes.Columns[4].HeaderText = "CPF";
                dgv_clientes.Columns[5].HeaderText = "Telefone";
                dgv_clientes.Columns[6].HeaderText = "Endereço";
                dgv_clientes.Columns[7].HeaderText = "Cidade";
                dgv_clientes.Columns[8].HeaderText = "Estado";

                //Muda o tamanho de cada coluna
                dgv_clientes.Columns[0].Width = 50;
                dgv_clientes.Columns[1].Width = 175;
                dgv_clientes.Columns[2].Width = 80;
                dgv_clientes.Columns[3].Width = 150;
                dgv_clientes.Columns[4].Width = 100;
                dgv_clientes.Columns[5].Width = 100;
                dgv_clientes.Columns[6].Width = 200;
                dgv_clientes.Columns[7].Width = 100;
                dgv_clientes.Columns[8].Width = 50;

                //Esconde a coluna id
                dgv_clientes.Columns[0].Visible= false;


            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);

            }
            finally
            {
                
                con.desconectar();
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_clientes_Load(sender, e);
        }

        private void dgv_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dados_Selecionados(sender, e);
        }

        private void Dados_Selecionados(object sender, DataGridViewCellEventArgs e)
        {
            txt_nome.Text = dgv_clientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            cb_sexo.Text = dgv_clientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_email.Text = dgv_clientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_cpf.Text = dgv_clientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_telefone.Text = dgv_clientes.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_endereco.Text = dgv_clientes.Rows[e.RowIndex].Cells[6].Value.ToString();
            txt_cidade.Text = dgv_clientes.Rows[e.RowIndex].Cells[7].Value.ToString();
            cb_estado.Text = dgv_clientes.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private Pessoa_DTO Obter_Dados_Selecionados(object sender, DataGridViewCellEventArgs e)
        {

            pessoaDto= new Pessoa_DTO();
            enderecoDto= new Endereco_DTO();

            pessoaDto.id = int.Parse(dgv_clientes.Rows[e.RowIndex].Cells[0].Value.ToString());
            pessoaDto.nome = dgv_clientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            pessoaDto.sexo = dgv_clientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            pessoaDto.email = dgv_clientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            pessoaDto.cpf = dgv_clientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            pessoaDto.telefone = dgv_clientes.Rows[e.RowIndex].Cells[5].Value.ToString();
            enderecoDto.cidade = dgv_clientes.Rows[e.RowIndex].Cells[7].Value.ToString();
            enderecoDto.estado = dgv_clientes.Rows[e.RowIndex].Cells[8].Value.ToString();
            pessoaDto.endereco = enderecoDto;

            return pessoaDto;

        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_nome.Text = string.Empty;
            cb_sexo.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_cpf.Text = string.Empty;
            txt_telefone.Text = string.Empty;
            txt_endereco.Text = string.Empty;
            txt_cidade.Text = string.Empty;
            cb_estado.Text = string.Empty;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

            // Supondo que você tenha um DataGridView chamado dataGridView1

            // Verifica se pelo menos uma linha está selecionada
            if (dgv_clientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv_clientes.SelectedRows[0]; // Pega a primeira linha selecionada

                // Acessa os valores das células da linha selecionada
                pessoaDto.id = int.Parse(row.Cells["id_cliente"].Value.ToString());
                
                // ... e assim por diante para outras colunas

                // Faça o que for necessário com os valores obtidos
            }
            else
            {
                // Nenhuma linha selecionada
            }


            pessoaDto.nome = txt_nome.Text;
            pessoaDto.sexo = cb_sexo.Text;
            pessoaDto.email = txt_email.Text;
            pessoaDto.cpf = txt_cpf.Text;
            pessoaDto.telefone = txt_telefone.Text;


            enderecoDto.rua = txt_endereco.Text;
            enderecoDto.cidade = txt_cidade.Text;
            enderecoDto.estado = cb_estado.Text;
            pessoaDto.endereco = enderecoDto;

            pessoaBLL.Editar(pessoaDto);

            MessageBox.Show("Atualizado com Sucesso!");

        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (dgv_clientes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv_clientes.SelectedRows[0]; // Pega a primeira linha selecionada

                // Acessa os valores das células da linha selecionada
                int id_pessoa = int.Parse(row.Cells["id_cliente"].Value.ToString());

                pessoaBLL.Deletar(id_pessoa);

                MessageBox.Show("Deletado com Sucesso!");
            }
            else
            {
                // Nenhuma linha selecionada
            }

            

        }
    }
}