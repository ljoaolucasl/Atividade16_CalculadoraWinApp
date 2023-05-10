using Atividade16_Calculadora.WinApp.Extension;

namespace Atividade16_Calculadora.WinApp
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
            Limpar();
        }

        public string primeiroNumero;
        public string segundoNumero;
        public string sinalEscolhido;

        private void btnNumeroClicado(object sender, EventArgs e)
        {
            Button button = sender as Button;

            FiltrarCampo();

            switch (button.Text)
            {
                case "0": textEntrada.Text += "0"; break;
                case "1": textEntrada.Text += "1"; break;
                case "2": textEntrada.Text += "2"; break;
                case "3": textEntrada.Text += "3"; break;
                case "4": textEntrada.Text += "4"; break;
                case "5": textEntrada.Text += "5"; break;
                case "6": textEntrada.Text += "6"; break;
                case "7": textEntrada.Text += "7"; break;
                case "8": textEntrada.Text += "8"; break;
                case "9": textEntrada.Text += "9"; break;
            }
        }

        private void btnSinalClicado(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Text)
            {
                case "+": InserirSinal("+"); break;
                case "–": InserirSinal("–"); break;
                case "×": InserirSinal("×"); break;
                case "÷": InserirSinal("÷"); break;
            }
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            switch (sinalEscolhido)
            {
                case "+": textEntrada.Text = (primeiroNumero.ToDouble() * (textEntrada.Text.ToDouble() / 100)).ToString(); break;
                case "–": textEntrada.Text = (primeiroNumero.ToDouble() * (textEntrada.Text.ToDouble() / 100)).ToString(); break;
                case "×": textEntrada.Text = (textEntrada.Text.ToDouble() / 100).ToString(); break;
                case "÷": textEntrada.Text = (textEntrada.Text.ToDouble() / 100).ToString(); break;
            }
        }

        private void btnMudaSinal_Click(object sender, EventArgs e)
        {
            double numero = double.Parse(textEntrada.Text) * -1;
            textEntrada.Text = numero.ToString();
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (textEntrada.Text != "" && !textEntrada.Text.Contains(","))
                textEntrada.Text += ",";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (textEntrada.Text != "")
                textEntrada.Text = textEntrada.Text.Substring(0, textEntrada.Text.Length - 1);
        }

        private void Calculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    FiltrarCampo();

                    textEntrada.Text += e.KeyChar.ToString();
                }

                if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
                {
                    switch (e.KeyChar)
                    {
                        case '+': InserirSinal("+"); break;
                        case '-': InserirSinal("–"); break;
                        case '*': InserirSinal("×"); break;
                        case '/': InserirSinal("÷"); break;
                    }
                }

                if (e.KeyChar == (char)Keys.Back && textEntrada.Text != "")
                    textEntrada.Text = textEntrada.Text.Substring(0, textEntrada.Text.Length - 1);

                e.Handled = true;
            }
            else
                Calcular();
        }

        private void Calcular()
        {
            if (primeiroNumero != "" && textEntrada.Text != "")
            {
                if (!labelViewConta.Text.Contains("="))
                    labelViewConta.Text += " " + textEntrada.Text + "  =";

                if (primeiroNumero == "0")
                {
                    textEntrada.Text = "Impossível dividir por zero";
                    return;
                }

                switch (sinalEscolhido)
                {
                    case "+": textEntrada.Text = (primeiroNumero.ToDouble() + textEntrada.Text.ToDouble()).ToString(); break;
                    case "–": textEntrada.Text = (primeiroNumero.ToDouble() - textEntrada.Text.ToDouble()).ToString(); break;
                    case "×": textEntrada.Text = (primeiroNumero.ToDouble() * textEntrada.Text.ToDouble()).ToString(); break;
                    case "÷": textEntrada.Text = (primeiroNumero.ToDouble() / textEntrada.Text.ToDouble()).ToString(); break;
                }
            }
        }

        private void InserirSinal(string tipo)
        {
            if (primeiroNumero == "")
            {
                labelViewConta.Text = textEntrada.Text;
                primeiroNumero = textEntrada.Text;
                textEntrada.Text = "";
            }

            sinalEscolhido = tipo;

            if (labelViewConta.Text.Contains(" "))
                labelViewConta.Text = labelViewConta.Text.Substring(0, labelViewConta.Text.Length - 1) + sinalEscolhido;
            else
                labelViewConta.Text += " " + sinalEscolhido;
        }

        private void FiltrarCampo()
        {
            if (labelViewConta.Text.Contains("="))
                Limpar();

            if (textEntrada.Text == "0")
                textEntrada.Text = "";
        }

        private void Limpar()
        {
            textEntrada.Text = "";

            labelViewConta.Text = "";

            primeiroNumero = "";
            segundoNumero = "";
            sinalEscolhido = "";
        }
    }
}