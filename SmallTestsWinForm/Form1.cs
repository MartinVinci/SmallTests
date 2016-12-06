﻿using SmallTestsWinForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SmallTestsWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Example 1
        private async void button1_Click(object sender, EventArgs e)
        {
            // Call the method that runs asynchronously.  
            string result = await WaitAsynchronouslyAsync();

            // Display the result.  
            MessageBox.Show(result);

        }
        public async Task<string> WaitAsynchronouslyAsync()
        {
            await Task.Delay(5000);
            return "Finished";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text += "x";
        }


        // Example 2        
        public delegate bool MyDelegateMethod();


        private void button3_Click(object sender, EventArgs e)
        {
            var worker = new MyDelegateMethod(DoStuff);

            var fireAndForget = worker.BeginInvoke(new AsyncCallback(asyncResult), null);


        }
        public void asyncResult(IAsyncResult inputResult)
        {
            // Retrieve the delegate.
            AsyncResult result = (AsyncResult)inputResult;
            MyDelegateMethod caller = (MyDelegateMethod)result.AsyncDelegate;

            // Call EndInvoke to retrieve the results.
            bool returnValue = caller.EndInvoke(inputResult);

            MessageBox.Show(returnValue.ToString());
        }

        public bool DoStuff()
        {

            Thread.Sleep(5000);


            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text += "x";

        }
        static HttpClient client;
        private async void button5_Click(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://microsoft-apiapp9361797a53664fbfaff4ee3f582f2d9e.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string subPath = "api/contact/";

            string finalPath = client.BaseAddress + subPath;
            HttpResponseMessage response = await client.GetAsync(finalPath);

            var adam = response.Content.ReadAsStringAsync().Result;


            List<Contact> contact;
            if (response.IsSuccessStatusCode)
            {
                contact = await response.Content.ReadAsAsync<List<Contact>>();
            }
        }
        

    }
}
