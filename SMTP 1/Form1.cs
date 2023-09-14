using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            // Email configuration
            string smtpServer = "mail.smtp2go.com";
            int smtpPort = 2525;
            string smtpUsername = "no.reply@hertex.co.za";
            string smtpPassword = "VBvYuziubNtQ4Tl9";
            string fromEmail = "danie@hertex.co.za";

            // Recipients
            List<string> recipients = new List<string>
            {
                "jadejallahrs@gmail.com",
                "jade@createchconsulting.co.za"
            };

            // Folder containing files to send
            string folderPath = @"C:\dj";

            // Loop through recipients
            foreach (string recipient in recipients)
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;
                    string[] fileEntries = Directory.GetFiles(folderPath);

                    using (MailMessage message = new MailMessage(fromEmail, recipient))
                    {
                        message.Subject = "Subject";
                        message.Body = "Email Body";

                        // Attach files
                        foreach (string filePath in fileEntries)
                            message.Attachments.Add(new Attachment(filePath));

                        // Send email
                        smtpClient.Send(message);
                    }

                    foreach (string filePath in fileEntries)
                        File.Delete(filePath);
                }
            }
        }
    }
}
