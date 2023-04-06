using Avalonia.Controls;
using Avalonia.Interactivity;
using Demo.Helpers;
using MessageBox.Avalonia;
using System;
using System.Diagnostics;
using System.Linq;

namespace Demo
{
    public partial class AuthWindow : Window
    {
        private string _captcha;
        public AuthWindow()
        {
            InitializeComponent();
            SetCapthcha();
        }

        private void BtnAuth_OnClick(object sender, RoutedEventArgs e)
        {
            new OrganizerWindow().Show();
            //var user = Helper.GetContext().Users.ToList().SingleOrDefault(x => x.Email == TbLogin.Text && x.Password == TbPassword.Text);
            //if (user is null)
            //{
            //    MessageBoxManager.GetMessageBoxStandardWindow("Информация", "Авторизация не пройдена.").Show();
            //    return;
            //}

            //if (TbReCaptcha.Text != _captcha)
            //{
            //    MessageBoxManager.GetMessageBoxStandardWindow("Информация", "Неправильно введена капча.").Show();
            //    SetCapthcha();
            //    return;
            //}

            //switch (user.GetType().Name)
            //{
            //    case "JuryProxy":
            //        new JuryWindow().Show();
            //        Close();
            //        break;
            //    case "OrganizerProxy":
            //        new OrganizerWindow().Show();
            //        Close();
            //        break;
            //}
        }

        private void SetCapthcha()
        {
            _captcha = GenerateCaptcha();
            TbCaptcha.Text = _captcha;
        }

        private string GenerateCaptcha()
        {
            var captcha = string.Empty;
            var random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 10; i++)
            {
                captcha += combination[random.Next(combination.Length)];
            }
            return captcha;
        }
    }
}
