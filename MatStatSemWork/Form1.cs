namespace MatStatSemWork
{
    public partial class Form1 : Form
    {
        private readonly Label label;
        private readonly Button CompactnesButton;
        private readonly Button AreaButton;
        private readonly Button ExtentButton;
        private readonly Button ExtentButtonOnlyForCERCEVELIK;
        private readonly Button EquivDiameterOnlyForURGUP_SIVRISIButton;
        private readonly Button EquivDiameterOnlyForCERCEVELIKButton;
        public Form1()
        {
            label = new Label
            {
                Size = new Size(2000, 400),
                AutoSize = true,
                Font = new Font(FontFamily.GenericMonospace, 14)
            };
            label.Text += "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            CompactnesButton = new Button
            {
                Location = new Point(0, label.Bottom),
                Text = "Compactness",
                Size = new Size(90,90)
            };
            AreaButton = new Button
            {
                Location = new Point(CompactnesButton.Right + 10, label.Bottom),
                Text = "Area",
                Size = new Size(90,90)
            };
            ExtentButton = new Button
            {
                Location = new Point(AreaButton.Right + 10, label.Bottom),
                Text = "Extent",
                Size = new Size(90,90)
            };
            ExtentButtonOnlyForCERCEVELIK = new Button
            {
                Location = new Point(ExtentButton.Right + 10, label.Bottom),
                Text = "Extent Only For CERCEVELIK",
                Size = new Size(90,90)
            };
            EquivDiameterOnlyForURGUP_SIVRISIButton = new Button
            {
                Location = new Point(ExtentButtonOnlyForCERCEVELIK.Right + 10, label.Bottom),
                Text = "Equiv Diameter Only For URGUP_SIVRISI",
                Size = new Size(90,90)
            };
            EquivDiameterOnlyForCERCEVELIKButton = new Button
            {
                Location = new Point(EquivDiameterOnlyForURGUP_SIVRISIButton.Right + 10, label.Bottom),
                Text = "Equiv Diameter Only For CERCEVELIK",
                Size = new Size(90,90)
            };
            AreaButton.Click += GetArea;
            CompactnesButton.Click += GetCompactness;
            ExtentButton.Click += GetExtent;
            ExtentButtonOnlyForCERCEVELIK.Click += GetExtentForCERCEVELIK;
            EquivDiameterOnlyForURGUP_SIVRISIButton.Click += GetEquivDiameterOnlyForURGUP_SIVRISI;
            EquivDiameterOnlyForCERCEVELIKButton.Click += GetEquivDiameterOnlyForCERCEVELIK;
            Controls.Add(label);
            Controls.Add(CompactnesButton);
            Controls.Add(AreaButton);
            Controls.Add(ExtentButton);
            Controls.Add(ExtentButtonOnlyForCERCEVELIK);
            Controls.Add(EquivDiameterOnlyForURGUP_SIVRISIButton);
            Controls.Add(EquivDiameterOnlyForCERCEVELIKButton);
        }
        
        public async void GetEquivDiameterOnlyForURGUP_SIVRISI(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var extent = pumpkins.Where(pum => pum.PumpkinType == "URGUP_SIVRISI").Select(pum => pum.EquivDiameter).ToList();
            MakeWithField(extent);
        }
        
        public async void GetEquivDiameterOnlyForCERCEVELIK(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var extent = pumpkins.Where(pum => pum.PumpkinType == "CERCEVELIK").Select(pum => pum.EquivDiameter).ToList();
            MakeWithField(extent);
        }
        
        public async void GetExtentForCERCEVELIK(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var extent = pumpkins.Where(pum => pum.PumpkinType == "CERCEVELIK").Select(pum => pum.Extent).ToList();
            MakeWithField(extent);
        }
        
        public async void GetExtent(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var extent = pumpkins.Select(pum => pum.Extent).ToList();
            MakeWithField(extent);
        }
        public async void GetArea(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var area = pumpkins.Select(pum => pum.Area).ToList();
            MakeWithField(area);
        }

        public async void GetCompactness(object sender, EventArgs e)
        {
            label.Text = "start - finish        ni        wi         zi         nAccumulated        x medial \n";
            var parser = new Parser();
            var pumpkins = await parser.Parse();
            var compactness = pumpkins.Select(pum => pum.Compactness).ToList();
            MakeWithField(compactness);
        }

        private void MakeWithField(List<double> field)
        {
            var result = field.GetResult();
            foreach (var interval in result.Intervals)
            {
                label.Text += interval.Start + "   -   " + interval.Finish + "        ";
                label.Text += interval.ni + "        " + interval.wi + "        " + interval.zi + "        " + interval.nAccumulated + "        " +
                              interval.XMedial;
                label.Text += "\n";
            }

            label.Text += "Дисперсия = " + result.variance + "; Среднеквадратическое отклонение" + result.standardDeviationOfTheSample
                          + "; Выборочное среднее = " + result.xWaved + "; \n"
                          + "M0 = " + result.M0 + "; me = " + result.Me + "; Коэффициент ассиметрии = " + result.A3
                          + "; Коэффициент эксцесса = " + result.Ek;
        }
    }
}