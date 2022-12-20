using GetTextTool.Models;
using GetTextTool.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetTextTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HttpClientInit();
        }

        public Point StartPoint;
        public Point EndPoint;
        public List<CropForm> CropForms = new List<CropForm>();

        private void StartCropping()
        {
            CropForms.Clear();

            foreach (Screen screen in Screen.AllScreens)
            {
                CropForm tempCropForm = new CropForm(this, screen);
                tempCropForm.Show();
                CropForms.Add(tempCropForm);
            }
        }

        public async void GetScreenshot()
        {
            //isCropping = false;

            if (EndPoint.X < StartPoint.X)
            {
                Point temp = EndPoint;
                EndPoint.X = StartPoint.X;
                StartPoint.X = temp.X;
            }
            else if (EndPoint.X == StartPoint.X)
                return;

            if (EndPoint.Y < StartPoint.Y)
            {
                Point temp = EndPoint;
                EndPoint.Y = StartPoint.Y;
                StartPoint.Y = temp.Y;
            }
            else if (EndPoint.Y == StartPoint.Y)
                return;

            Size resolution = new Size(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);

            Bitmap bmpScreenshot = new Bitmap(resolution.Width, resolution.Height, PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(StartPoint.X, StartPoint.Y, 0, 0, resolution, CopyPixelOperation.SourceCopy);

            if (bmpScreenshot != null)
            {
                string errMsg = "";
                var imgBytes = ImageToByteArray(bmpScreenshot);
                var base64 = Convert.ToBase64String(imgBytes);

                var googleVisionService = new GoogleVisionService();
                var listText = googleVisionService.GetTextDetectionFromImage(base64, out errMsg);
                if (listText.Count > 0) listText.RemoveAt(0);

                var textReq = String.Join("", listText);

                Form2 frm = new Form2(textReq, await GetPinyin(textReq));
                frm.Show();
            }
        }

        static HttpClient client = new HttpClient();

        private void HttpClientInit()
        {
            // Put the following code where you want to initialize the class
            // It can be the static constructor or a one-time initializer
            client.BaseAddress = new Uri("http://127.0.0.1:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<string> GetPinyin(string textReq)
        {
            try
            {
                var request = new { text = textReq };
                var response = await client.PostAsJsonAsync("pinyin", request);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Pinyin>(data.Result);

                    return result.pinyin;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                //imageIn.Save(ms, imageIn.RawFormat);
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartCropping();
        }
    }
}
