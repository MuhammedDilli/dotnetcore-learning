namespace ParalelForForeachCancellation
{
    public partial class Form1 : Form
    {
        public int Counter { get; set; } = 0;

        CancellationTokenSource ct;
        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ct = new CancellationTokenSource();

            List<string> urls = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com" ,
                "https://www.amazon.com" ,
                "https://www.google.com",
                "https://www.microsoft.com" ,
                "https://www.amazon.com" ,
                "https://www.google.com",
                "https://www.microsoft.com" ,
                "https://www.amazon.com" ,
                "https://www.google.com",
                "https://www.microsoft.com" ,
                "https://www.amazon.com" ,
                "https://www.google.com",
                "https://www.microsoft.com" ,
                "https://www.amazon.com"
            };
            HttpClient client = new HttpClient();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken=ct.Token;

            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach<String>(urls, parallelOptions, (url) =>
                    {
                        String content = client.GetStringAsync(url).Result;
                        string data = $"{url} : {content.Length} ";
                        ct.Token.ThrowIfCancellationRequested();
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });

                    });
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ýþlem iptal edildi :" + ex.Message);
                }



            });

        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = Counter++.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
