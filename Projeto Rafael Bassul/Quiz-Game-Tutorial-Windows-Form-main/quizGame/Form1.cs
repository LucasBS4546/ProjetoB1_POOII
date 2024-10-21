using System.Media;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace quizGame
{

    public partial class Form1 : Form
    {
        // variables list for this quiz game
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int flag = 0;
        int flagdois = 0;
        int totalQuestions;
        public SoundPlayer Tema;
        public SoundPlayer um;
        public SoundPlayer dois;
        public SoundPlayer tres;
        public SoundPlayer quatro;
        public SoundPlayer cinco;
        public SoundPlayer seis;
        public SoundPlayer sete;
        public SoundPlayer oito;
        public SoundPlayer nove;
        public SoundPlayer dez;
        public SoundPlayer onze;
        public SoundPlayer tchau;
        public SoundPlayer certa;
        public SoundPlayer errou;
        public SoundPlayer parabens;


        public Form1()
        {
            InitializeComponent();

            certa = new SoundPlayer(@"Resources/certa.wav");
            Tema = new SoundPlayer(@"Resources/pergunta.wav");
            um = new SoundPlayer(@"Resources/1.wav");
            dois = new SoundPlayer(@"Resources/2.wav");
            tres = new SoundPlayer(@"Resources/3.wav");
            quatro = new SoundPlayer(@"Resources/4.wav");
            cinco = new SoundPlayer(@"Resources/5.wav");
            seis = new SoundPlayer(@"Resources/6.wav");
            sete = new SoundPlayer(@"Resources/7.wav");
            oito = new SoundPlayer(@"Resources/8.wav");
            nove = new SoundPlayer(@"Resources/9.wav");
            dez = new SoundPlayer(@"Resources/10.wav");
            onze = new SoundPlayer(@"Resources/11.wav");
            errou = new SoundPlayer(@"Resources/errou.wav");
            parabens = new SoundPlayer(@"Resources/parabens.wav");
            askQuestion(questionNumber);
            totalQuestions = 11;
            botoesDesativados();

        }
        public void botoesDesativados()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }

        public void botoesAtivados()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        public void processando()
        {
            botoesDesativados();
            lblQuestion.Text = "Processando...";
            button1.Text = "Processando...";
            button2.Text = "Processando...";
            button3.Text = "Processando...";
            button4.Text = "Processando...";
        }
        public void ajuda()
        {
            if (flag >= 0 && flag < 3)
            {
                button6.Enabled = true;
            }
            else if (flag > 2)
            {
                button6.Enabled = false;
            }
        }

        public void passar()
        {
            if (flagdois == 0)
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
        }


        private async void ClickAnswerEvent(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);




            if (buttonTag == correctAnswer)
            {
                botoesDesativados();
                Tema.Stop();
                certa.Load();
                certa.Play();
                score++;
                await Task.Delay(1000);

                if (questionNumber == totalQuestions)
                {
                    parabens.Load();
                    parabens.Play();
                    MessageBox.Show("Parabens!!! tirou onda!");
                    await Task.Delay(3742);

                    
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    this.Close();

                }


            }
            else if (buttonTag == 100)
            {
                button5.Enabled = false;
                flagdois = 1;
            }
            else
            {
                errou.Load();
                errou.Play();
                await Task.Delay(2000);
                Form4 form4 = new Form4();
                this.Hide();
                form4.ShowDialog();
                this.Close();


            }


            if (questionNumber == totalQuestions)
            {
                parabens.Load();
                parabens.Play();
            }

            questionNumber++;

            askQuestion(questionNumber);



        }

        private async void askQuestion(int qnum)
        {



            switch (qnum)
            {
                case 1:
                    um.Load();
                    um.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();


                    await Task.Delay(8300);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/tomate.jpg");
                    lblQuestion.Text = "Que tipo de alimento � o tomate?";

                    button1.Text = "Fruta";
                    button2.Text = "Legume";
                    button3.Text = "Verdura";
                    button4.Text = "Vegetal";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 1;

                    break;

                case 2:

                    dois.Load();
                    dois.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(5700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/rosalem.png"); //perd�o errei seu nome :(
                    lblQuestion.Text = "Qual � o melhor professor do mundo?";
                    button1.Text = "Albert Einstein";
                    button2.Text = "Vinicius Rosalen da Silva";
                    button3.Text = "Robert Oppenheimer";
                    button4.Text = "Dennis Ritchie";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 2;

                    break;
                case 3:
                    tres.Load();
                    tres.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(5700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/ptero.jpg");
                    lblQuestion.Text = "O pterossauro � um:";
                    button1.Text = "S�urio";
                    button2.Text = "Ave";
                    button3.Text = "Nenhuma das alternativas";
                    button4.Text = "Pterosauromorpha";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 4;

                    break;
                case 4:
                    quatro.Load();
                    quatro.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(5700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/cachorro.jpg");
                    lblQuestion.Text = "Robalo � um:";
                    button1.Text = "Ave";
                    button2.Text = "Peixe";
                    button3.Text = "Time";
                    button4.Text = "Dinossauro";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 2;

                    break;
                case 5:
                    cinco.Load();
                    cinco.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(7700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/romance.jpg");
                    lblQuestion.Text = "Qual dos escritores abaixo n�o escreveu livros do g�nero romance policial?";
                    button1.Text = "Emilie Bront�";
                    button2.Text = "Sidney Sheldon";
                    button3.Text = "Dan Brown";
                    button4.Text = "Agatha Christie";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 1;

                    break;
                case 6:
                    seis.Load();
                    seis.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(11700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/dompedro.jpeg");
                    lblQuestion.Text = "Quem foi a segunda esposa de Dom Pedro I?";
                    button1.Text = "Maria Isabel";
                    button2.Text = "Domitila de Castro";
                    button3.Text = "Am�lia de Leuchtenberg";
                    button4.Text = "Carlota Joaquina";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 3;

                    break;
                case 7:
                    sete.Load();
                    sete.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(6700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/estoicismo.jpg");
                    lblQuestion.Text = "Qual era a ideologia do estoicismo?";
                    button1.Text = "A Felicidade vem das virtudes";
                    button2.Text = "A Felicidade vem dos prazeres";
                    button3.Text = "A Felicidade vem de uma vida simples";
                    button4.Text = "A Felicidade consiste em n�o julgar coisa alguma";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 1;

                    break;
                case 8:
                    oito.Load();
                    oito.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(6700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/jupter.jpg");
                    lblQuestion.Text = "Qual destes planetas n�o possui luas?";
                    button1.Text = "Marte";
                    button2.Text = "J�piter";
                    button3.Text = "V�nus";
                    button4.Text = "Saturno";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 3;

                    break;
                case 9:
                    nove.Load();
                    nove.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(5700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/esporte.jpg");
                    lblQuestion.Text = "Em qual esporte se utiliza uma raquete e uma pequena bola amarela?";
                    button1.Text = "Squash";
                    button2.Text = "Ping pong";
                    button3.Text = "T�nis";
                    button4.Text = "Badminton";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 3;

                    break;
                case 10:
                    dez.Load();
                    dez.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(6700);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/luz.jpeg");
                    lblQuestion.Text = "Qual fen�meno explica a capacidade da luz de se comportar como onda e part�cula simultaneamente?";
                    button1.Text = "Efeito fotoel�trico";
                    button2.Text = "Relatividade";
                    button3.Text = "Dualidade onda-part�cula";
                    button4.Text = "Princ�pio da incerteza";
                    botoesAtivados();
                    ajuda();
                    passar();

                    correctAnswer = 3;

                    break;
                case 11:
                    onze.Load();
                    onze.Play();
                    pictureBox1.Image = Image.FromFile(@"Resources/questions.png");
                    processando();

                    await Task.Delay(8200);
                    Tema.Load();
                    Tema.PlayLooping();

                    pictureBox1.Image = Image.FromFile(@"Resources/atomo.png");
                    lblQuestion.Text = "Qual part�cula subat�mica, com carga positiva, forma o n�cleo at�mico e define o elemento?";
                    button1.Text = "El�tron";
                    button2.Text = "N�utron";
                    button3.Text = "Pr�ton";
                    button4.Text = "P�sitron";
                    botoesAtivados();
                    button6.Enabled = false;
                    button5.Enabled = false;

                    correctAnswer = 3;

                    break;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (questionNumber == 1)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Ent�o... technically � uma FRUTA, j� que vem de flor e tem semente, mas no dia a dia a galera chama de legume, sabe como � n�? Confus�o bot�nica...", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 2)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "EASY, n�? A resposta � o mito: Vinicius Rosalen da Silva! Se ele n�o � o melhor de POO, ningu�m �. Ponto.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 3)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Cara, pterossauros eram sinistros... e o grupo deles � o Pterosauromorpha. N�o s�o dinossauros, mas davam medo igual!", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 4)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Quer saber? Isso � peixe de respeito! T� l� no mar, nadando suave, enquanto a gente tenta n�o errar essa quest�o.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 5)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Aqui tem pegadinha! Emilie Bront� n�o era da galera dos detetives, ela curtia mais uma vibe rom�ntica e melanc�lica tipo O Morro dos Ventos Uivantes.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 6)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Ah, hist�ria do Brasil, sempre uma novela! Se precisar, dou um spoiler hist�rico nessa aqui, � a Am�lia de Leuchtenberg.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 7)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Os estoicos eram tipo os zen masters da Antiguidade! Pra eles, felicidade n�o � dinheiro nem fama: � ter virtude e aceitar o que a vida manda.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 8)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Hmm... Plut�o nem planeta � mais! Mas entre os planetas �s�rios�, V�nus � solit�rio. Nem uma lua pra chamar de sua...", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 9)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "R�! Isso � T�nis, sem d�vidas. Se tiver sorte, voc� ainda saca um ace e leva essa.", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }
            else if (questionNumber == 10)
            {
                MessageBox.Show("Opa! Bora mandar ver nessa quest�o?" + Environment.NewLine +
                    "Deixa eu te dar uma forcinha nerd, porque conhecimento nunca � demais! Vamos l�..." + Environment.NewLine + " " + Environment.NewLine +
                    "Ahhh, o charme da f�sica qu�ntica! O nome bonito pra isso � Dualidade Onda-Part�cula. Nem a luz gosta de ser definida por uma caixinha s�!", "Ajudinha Nerd", MessageBoxButtons.OK);
                button6.Enabled = false;
                flag++;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
