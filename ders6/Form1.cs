using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace ders6
{
    
    public partial class Form1 : Form
    {
        
        bool t1run = false;
        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
            timer1.Start();
        }

        
        int counter;
        public void updateData()
        {
            counter++;
            label2.Text = DateTime.Now.ToString();
           
            if (t1run)
            {
                if (counter > 10000)
                {
                    convertUpCurrency();
                    counter = 0;
                }
                label2.Text = DateTime.Now.ToString() ;


            }

            else {
                if (counter > 10000)
                {
                    converDownCurrency();
                    counter = 0;
                }
                
                label2.Text = DateTime.Now.ToString();


            }





        }









        public void converDownCurrency()
        {

            try
            {
                if (textBox2.Text != "" && textBox2.Text != "0" && t1run == false)
                {

                    string t2 = comboBox1.Text;
                    string t1 = comboBox2.Text;
                    int startIndex = t1.IndexOf('(');
                    int endIndex = t1.IndexOf(')');
                    string newT1 = "";
                    for (int i = startIndex + 1; i < endIndex; i++)
                    {
                        newT1 += t1[i];


                    }


                    int startIndexx = t2.IndexOf('(');
                    int endIndexx = t2.IndexOf(')');
                    string newT2 = "";
                    for (int i = startIndexx + 1; i < endIndexx; i++)
                    {
                        newT2 += t2[i];


                    }

                    if (newT1 == "TL" || newT2 == "TL")
                    {


                        if (newT1 != "TL")
                        {
                            //tl = true;

                            XmlDocument xmlll = new XmlDocument();
                            xmlll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                            XmlNode roottt = xmlll.DocumentElement;
                            XmlNode usdNodeee = roottt.SelectSingleNode($"//Currency[@Kod='{newT1}']");





                            CultureInfo culturee = CultureInfo.InvariantCulture;
                            XmlNode forexBuyingNodeee = usdNodeee.SelectSingleNode("ForexBuying");
                            double valueee = double.Parse(forexBuyingNodeee.InnerText, culturee);
                            double p = double.Parse(textBox2.Text);
                            double resulttt = ((valueee)) * p;
                            textBox1.Text = resulttt.ToString();

                        }

                        if (newT2 != "TL")
                        {
                            //tll = true;

                            XmlDocument xmlll = new XmlDocument();
                            xmlll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                            XmlNode roottt = xmlll.DocumentElement;
                            XmlNode usdNodeee = roottt.SelectSingleNode($"//Currency[@Kod='{newT2}']");





                            CultureInfo culturee = CultureInfo.InvariantCulture;
                            XmlNode forexBuyingNodeee = usdNodeee.SelectSingleNode("ForexBuying");
                            double valueee = double.Parse(forexBuyingNodeee.InnerText, culturee);
                            double p = double.Parse(textBox2.Text);
                            double resulttt = 1/(valueee) * p;
                            textBox1.Text = resulttt.ToString();

                        }



                    }
                    else
                    {

                        XmlDocument xmll = new XmlDocument();
                        xmll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                        XmlNode roott = xmll.DocumentElement;
                        XmlNode usdNodee = roott.SelectSingleNode($"//Currency[@Kod='{newT2}']");


                        Console.WriteLine(newT2);


                        CultureInfo culture = CultureInfo.InvariantCulture;
                        XmlNode forexBuyingNodee = usdNodee.SelectSingleNode("ForexBuying");
                        double valuee = double.Parse(forexBuyingNodee.InnerText, culture);








                        XmlDocument xml = new XmlDocument();
                        xml.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                        XmlNode root = xml.DocumentElement;
                        XmlNode usdNode = root.SelectSingleNode($"//Currency[@Kod='{newT1}']");


                        Console.WriteLine(newT1);




                        XmlNode forexBuyingNode = usdNode.SelectSingleNode("ForexBuying");
                        double value = double.Parse(forexBuyingNode.InnerText, culture);
                        Console.WriteLine(forexBuyingNode.InnerText + "+asdsada");

                        string k = forexBuyingNode.InnerText.Split(',')[0];

                        Console.WriteLine(value + " ...." + valuee);

                        double rate = value / valuee;
                        Console.WriteLine(rate);

                        double result = rate * Double.Parse(textBox2.Text);


                        Console.WriteLine(result);
                        string resultt = result.ToString();

                        textBox1.Text = result.ToString();


                    }
                }
            }

            catch (Exception e) { 
            
            MessageBox.Show(e.Message); 
            
            }   


        }
        public void convertUpCurrency()
        {

            try
            {
                if (textBox1.Text != "" && textBox1.Text != "0" && t1run == true)
                {
                    string t1 = comboBox1.Text;
                    string t2 = comboBox2.Text;
                    int startIndex = t1.IndexOf('(');
                    int endIndex = t1.IndexOf(')');
                    string newT1 = "";
                    for (int i = startIndex + 1; i < endIndex; i++)
                    {
                        newT1 += t1[i];


                    }




                    int startIndexx = t2.IndexOf('(');
                    int endIndexx = t2.IndexOf(')');
                    string newT2 = "";
                    for (int i = startIndexx + 1; i < endIndexx; i++)
                    {
                        newT2 += t2[i];


                    }


                    if (newT1 == "TL" || newT2 == "TL")
                    {


                        if (newT1 != "TL")
                        {
                            

                            XmlDocument xmlll = new XmlDocument();
                            xmlll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                            XmlNode roottt = xmlll.DocumentElement;
                            XmlNode usdNodeee = roottt.SelectSingleNode($"//Currency[@Kod='{newT1}']");





                            CultureInfo culturee = CultureInfo.InvariantCulture;
                            XmlNode forexBuyingNodeee = usdNodeee.SelectSingleNode("ForexBuying");
                            double valueee = double.Parse(forexBuyingNodeee.InnerText, culturee);
                            double p = double.Parse(textBox1.Text);
                            double resulttt = (valueee) * p;
                            textBox2.Text = resulttt.ToString();

                        }

                        if (newT2 != "TL")
                        {

                            XmlDocument xmlll = new XmlDocument();
                            xmlll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                            XmlNode roottt = xmlll.DocumentElement;
                            XmlNode usdNodeee = roottt.SelectSingleNode($"//Currency[@Kod='{newT2}']");





                            CultureInfo culturee = CultureInfo.InvariantCulture;
                            XmlNode forexBuyingNodeee = usdNodeee.SelectSingleNode("ForexBuying");
                            double valueee = double.Parse(forexBuyingNodeee.InnerText, culturee);
                            double p = double.Parse(textBox1.Text);
                            double resulttt = (1/(valueee)) * p;
                            textBox2.Text = resulttt.ToString();

                        }



                    }

                    else
                    {
                       

                        CultureInfo culture = CultureInfo.InvariantCulture;


                        XmlDocument xmll = new XmlDocument();
                        xmll.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                        XmlNode roott = xmll.DocumentElement;

                        XmlNode usdNodee = roott.SelectSingleNode($"//Currency[@Kod='{newT2}']");


                        Console.WriteLine(newT2);



                        XmlNode forexBuyingNodee = usdNodee.SelectSingleNode("ForexBuying");
                        double valuee = Double.Parse(forexBuyingNodee.InnerText, culture);





                        XmlDocument xml = new XmlDocument();
                        xml.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                        XmlNode root = xml.DocumentElement;
                        XmlNode usdNode = root.SelectSingleNode($"//Currency[@Kod='{newT1}']");

                        Console.WriteLine(newT1);




                        XmlNode forexBuyingNode = usdNode.SelectSingleNode("ForexBuying");
                        double value = Double.Parse(forexBuyingNode.InnerText, culture);


                        double rate = value / valuee;


                        double result = rate * Double.Parse(textBox1.Text);

                        string resultt = result.ToString();
                        Console.WriteLine(result);

                        textBox2.Text = resultt;




                    }
                }
            }
            catch (Exception e) { 
            
                MessageBox.Show(e.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

             convertUpCurrency();

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            converDownCurrency();
           
           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            convertUpCurrency();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            converDownCurrency();
        }

       

      

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            t1run = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            t1run = true;

            


        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            t1run = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            updateData();
            
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            t1run = false;
        }

    }
}

