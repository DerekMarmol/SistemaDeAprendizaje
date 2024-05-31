using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10Notificaciones
{
    public partial class CentroDeNotificaciones : Form
    {
        private string myEmail = "proyecto.Progra00@gmail.com";
        private readonly string myPassword = "ruoovbweuxihsifh";
        private string myAlias = "Proyecto Daniel, Derek y Andreina";
        private string[] myAdjuntos;
        private MailMessage mCorreo;

        public CentroDeNotificaciones()
        {
            InitializeComponent();
        }
        private void CrearCuerpoCorreo()
        {
            mCorreo = new MailMessage();
            mCorreo.From = new MailAddress(myEmail, myAlias, System.Text.Encoding.UTF8);
            mCorreo.To.Add(txtEmailFrom.Text.Trim());
            mCorreo.Subject = txtSubject.Text.Trim();
            mCorreo.Body = txtMessage.Text.Trim();
            mCorreo.IsBodyHtml = true;
            mCorreo.Priority = MailPriority.High;

            for (int i = 0; i < myAdjuntos.Length; i++)
            {
                mCorreo.Attachments.Add(new Attachment(myAdjuntos[i]));
            }
        }
        private void Enviar()
        {
            try
            {
                SmtpClient smpt = new SmtpClient();
                smpt.UseDefaultCredentials = false;
                smpt.Port = 587;
                smpt.Host = "smtp.gmail.com";
                smpt.Credentials = new System.Net.NetworkCredential(myEmail, myPassword);
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    X509Certificate certificate, X509Chain chain, SslPolicyErrors erros)
                { return true; };
                smpt.EnableSsl = true;
                smpt.Send(mCorreo);
                MessageBox.Show("Enviado");
                lblFiles.Text = "";

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }
        private void AdjuntarArchivos()
        {
            var names = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Adjutar Archivos al Correo";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                myAdjuntos = ofd.FileNames;
            }

            for (int i = 0; i < myAdjuntos.Length; i++)
            {
                names += myAdjuntos[i] + "\n";
            }
            lblFiles.Text = names;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFiles_Click_1(object sender, EventArgs e)
        {
            AdjuntarArchivos();
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            CrearCuerpoCorreo();
            Enviar();
        }

        private void txtEmailFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
