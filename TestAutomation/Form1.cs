using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using Gma.System.MouseKeyHook;
using System.Threading;

namespace TestAutomation
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents globalMouseHook;

        public Form1()
        {
            
           
            InitializeComponent();
            // Note: for the application hook, use the Hook.AppEvents() instead.
            globalMouseHook = Hook.GlobalEvents();

            // Bind MouseDoubleClick event with a function named MouseDoubleClicked.
            globalMouseHook.MouseDoubleClick += MouseDoubleClicked;

            // Bind DragFinished event with a function.
            // Same as double click, so I didn't write here.
            //globalMouseHook.MouseDragFinished += MouseDragFinished;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;
        }

        // I make the function async to avoid GUI lags.
        private async void MouseDoubleClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Save clipboard's current content to restore it later.
            IDataObject tmpClipboard = Clipboard.GetDataObject();

            Clipboard.Clear();

            // I think a small delay will be more safe.
            // You could remove it, but be careful.
            await Task.Delay(50);

            // Send Ctrl+C, which is "copy"
            System.Windows.Forms.SendKeys.SendWait("^c");

            // Same as above. But this is more important.
            // In some softwares like Word, the mouse double click will not select the word you clicked immediately.
            // If you remove it, you will not get the text you selected.
            await Task.Delay(50);

            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                
                // Your code
                checkedListBox1.Items.Add(text);
                

            }
            else
            {
                // Restore the Clipboard.
                Clipboard.SetDataObject(tmpClipboard);
            }
        }


        private void Pay_Click(object sender, EventArgs e)
        {

            try
            {
                //split items
                var items = checkedListBox1.CheckedItems;
                List<string> items1 = new List<string>();
                List<string> items2 = new List<string>();
                int toss = 0;
                foreach (var item in items)
                {
                    if (toss == 0)
                    {
                        items1.Add(item.ToString());
                        toss = 1;
                    }
                    else
                    {
                        items2.Add(item.ToString());
                        toss = 0;
                    }
                }

                Thread t1 = new Thread(() => runPaymentAsync(items1));
                Thread t2 = new Thread(() => runPaymentAsync(items2));

                t1.Start();
                t2.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void runPaymentAsync(List<string> items)
        {
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeDriver drv = new ChromeDriver(driverService, new ChromeOptions());
                
                drv.Navigate().GoToUrl("https://localhost:44395/payment");
                string title = drv.Title;
                List<string> nums = new List<string>();

                foreach (var item in items)
                {
                    var divs = drv.FindElements(By.ClassName("row"));
                    try
                    {
                        var div = divs.FirstOrDefault(x => x.FindElement(By.TagName("p")).Text == item.ToString());
                        string num = div.FindElement(By.TagName("p")).Text;

                        if (div != null)
                        {
                            var btn = div.FindElement(By.TagName("a"));
                            btn.Click();
                            await Task.Delay(1000);
                            var tempDivs = drv.FindElements(By.ClassName("row"));
                            div = tempDivs.FirstOrDefault(x => x.FindElement(By.TagName("p")).Text == "assert payments");
                            btn = div.FindElement(By.TagName("a"));
                            btn.Click();
                            await Task.Delay(1000);
                            nums.Add(num);

                        }
                    }
                    catch
                    {

                    }

                }

                foreach (var p in nums)
                {
                    txtPhones.Text += p + ' ' + '\n';
                    checkedListBox1.Items.Remove(p);
                }

                drv.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0;i<checkedListBox1.Items.Count;i++)
            {
                checkedListBox1.SetItemChecked(i, cbxAll.Checked);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                var items = checkedListBox1.SelectedItems;
                for (int i = 0; i < items.Count; i++)
                {
                    checkedListBox1.Items.Remove(items[i]);
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //delete all shortcut ctrl+R
            if (e.Control == true && e.KeyCode == System.Windows.Forms.Keys.R)
            {
                checkedListBox1.Items.Clear();
            }
            //select all shortcut ctrl+A
            if (e.Control == true && e.KeyCode == System.Windows.Forms.Keys.A)
            {
                cbxAll.Checked = !cbxAll.Checked;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, cbxAll.Checked);
                }
                
            }
        }
    }
}
