using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace TestSelenium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            textBox1.Text = "cuonguet123";
            textBox2.Text = "cuonguet123@gmail.com";
            textBox3.Text = "cuong123";
        }
        int sott = 0;
        ChromeDriver chromeDriver;
        bool check(string text,string text2=null)
        {
            text = text.Trim();
            int count = 0;
            while(!chromeDriver.PageSource.Contains(text)&&count<1000)
            {
                if(text2==null)
                {
                    count++;
                    Thread.Sleep(10);
                }
                else if(chromeDriver.PageSource.Contains(text2))
                {
                    return false;
                }
                else
                {
                    count++;
                    Thread.Sleep(10);
                }
                
            }
            if(count<1000)
            {
                if(text2==null)
                {
                    return true;
                }
                else if (chromeDriver.PageSource.Contains(text2))
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
            return true;
        }
        void wait()
        {
            WebDriverWait wait = new WebDriverWait(this.chromeDriver, TimeSpan.FromSeconds(300));

            wait.Until((x) =>

            {

                return ((IJavaScriptExecutor)this.chromeDriver).ExecuteScript("return document.readyState").Equals("complete");

            });

        }
        void delay(int giay)
        {
            Thread.Sleep(TimeSpan.FromSeconds(giay));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chromeDriver = new ChromeDriver();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (var off in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    off.Kill();
                }
                catch
                {

                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread openweb = new Thread(() => {


                //Thời gian bắt đầu
                TimeSpan time;
                DateTime startdate = DateTime.Now, finishDate = DateTime.Now;
                try
                {
                    startdate = DateTime.Now;
                    chromeDriver.Url = "https://demo.realworld.io/";
                    chromeDriver.Navigate();
                    finishDate = DateTime.Now;
                    time = finishDate - startdate;
                    sott++;
                    if (chromeDriver.PageSource.Contains("Home — Conduit"))
                    {
                        dataGridView1.Rows.Add(sott, "Mở trang web", time.TotalMilliseconds, "Thành công");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(sott, "Mở trang web", time.TotalMilliseconds, "Thất bại");
                    }
                }
                catch
                {
                    time = finishDate - startdate;
                    dataGridView1.Rows.Add(sott, "Mở trang web", time.TotalMilliseconds, "Thất bại");
                }

            });
            openweb.Start();
            openweb.IsBackground = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            chromeDriver.Manage().Cookies.DeleteAllCookies();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread dangky = new Thread(() => {


  
                TimeSpan time;
                DateTime startdate = DateTime.Now, finishDate = DateTime.Now;
                try
                {
                    startdate = DateTime.Now;
                    chromeDriver.Url = "https://demo.realworld.io/#/register";
                    chromeDriver.Navigate();
                    var user = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[1]/input");
                    user.SendKeys(textBox1.Text);
                    var email = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[2]/input");
                    email.SendKeys(textBox2.Text);
                    var pass = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[3]/input");
                    pass.SendKeys(textBox3.Text);                    
                    var submit = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/button");
                    submit.Click();                    
                    bool checkdangky = check("Your Feed", "has already been taken");
                    finishDate = DateTime.Now;
                    time = finishDate - startdate;
                    sott++;

                    if (checkdangky)
                    {
                        dataGridView1.Rows.Add(sott, "Đăng ký", time.TotalMilliseconds, "Thành công");
                    }
                    else if(chromeDriver.PageSource.Contains("email has already been taken")| chromeDriver.PageSource.Contains("username has already been taken"))
                    {
                        dataGridView1.Rows.Add(sott, "Đăng ký", time.TotalMilliseconds, "Email hoặc username tồn tại");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(sott, "Đăng ký", time.TotalMilliseconds, "Thất bại");
                    }
                }
                catch
                {
                    sott++;
                    dataGridView1.Rows.Add(sott, "Đăng ký", "Error", "Thất bại");
                }

            });
            dangky.Start();
            dangky.IsBackground = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread login = new Thread(() => {


                //Thời gian bắt đầu
                TimeSpan time;
                DateTime startdate = DateTime.Now, finishDate = DateTime.Now;
                try
                {
                    startdate = DateTime.Now;
                    chromeDriver.Url = "https://demo.realworld.io/#/login";
                    chromeDriver.Navigate();
                    var user = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[2]/input");
                    user.SendKeys(textBox4.Text);
                    var pass = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[3]/input");
                    pass.SendKeys(textBox5.Text);
                    var signin = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/button");
                    signin.Click();
                    bool checklogin = check("Popular Tags", "is invalid");
                    finishDate = DateTime.Now;
                    time = finishDate - startdate;
                    sott++;
                    if (checklogin)
                    {
                        dataGridView1.Rows.Add(sott, "Đăng nhập", time.TotalMilliseconds, "Thành công");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(sott, "Đăng nhập", time.TotalMilliseconds, "Thất bại");
                    }
                }
                catch
                {
                    time = finishDate - startdate;
                    dataGridView1.Rows.Add(sott, "Đăng nhập", "Error", "Thất bại");
                }

            });
            login.Start();
            login.IsBackground = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread post = new Thread(() => {


                //Thời gian bắt đầu
                TimeSpan time;
                DateTime startdate = DateTime.Now, finishDate = DateTime.Now;
                try
                {
                    Actions action = new Actions(chromeDriver);
                    startdate = DateTime.Now;
                    chromeDriver.Url = "https://demo.realworld.io/#/editor/";
                    chromeDriver.Navigate();
                    var tieude = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[1]/input");
                    tieude.SendKeys(textBox6.Text);
                    var mota = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[2]/input");
                    mota.SendKeys(textBox7.Text);
                    var noidung = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[3]/textarea");
                    noidung.SendKeys(textBox8.Text);
                    string[] tag1 = textBox10.Text.Split('|');
                    foreach(string tagz in tag1)
                    {
                        var tag = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/fieldset[4]/input");
                        tag.SendKeys(tagz);
                        action.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
                    }
                    var submit = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div/div/div/form/fieldset/button");
                    submit.Click();
                    bool checkdangbai = check("Edit Article");
                    finishDate = DateTime.Now;
                    time = finishDate - startdate;
                    sott++;
                    if (checkdangbai)
                    {
                        dataGridView1.Rows.Add(sott, "Đăng bài", time.TotalMilliseconds, "Thành công");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(sott, "Đăng bài", time.TotalMilliseconds, "Thất bại");
                    }
                }
                catch
                {
                    time = finishDate - startdate;
                    dataGridView1.Rows.Add(sott, "Đăng bài", "Error", "Thất bại");
                }

            });
            post.Start();
            post.IsBackground = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread comment = new Thread(() => {


                //Thời gian bắt đầu
                TimeSpan time;
                DateTime startdate = DateTime.Now, finishDate = DateTime.Now;
                try
                {                                        
                    if(textBox11.Text!="")
                    {
                        chromeDriver.Url = textBox11.Text;
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập link bài viết cần bình luận");
                    }                    
                    chromeDriver.Navigate();
                    delay(2);                    
                    var cmt = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div[2]/div[3]/div/div/form/div[1]/textarea");
                    cmt.SendKeys(textBox9.Text);
                    startdate = DateTime.Now;
                    var submit = chromeDriver.FindElementByXPath(@"/html/body/div/div/div/div[2]/div[3]/div/div/form/div[2]/button");                    
                    submit.Click();
                    bool checkbinhluan = check(textBox9.Text);
                    finishDate = DateTime.Now;
                    time = finishDate - startdate;
                    sott++;
                    delay(2);
                    if (checkbinhluan)
                    {
                        dataGridView1.Rows.Add(sott, "Viết comment", time.TotalMilliseconds, "Thành công");
                    }
                    else
                    {
                        dataGridView1.Rows.Add(sott, "Viết comment", time.TotalMilliseconds, "Thất bại");
                    }
                }
                catch
                {
                    time = finishDate - startdate;
                    dataGridView1.Rows.Add(sott, "Đăng nhập", time.TotalMilliseconds, "Thất bại");
                }

            });
            comment.Start();
            comment.IsBackground = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
