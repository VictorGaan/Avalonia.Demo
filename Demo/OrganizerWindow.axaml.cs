using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Demo.Helpers;
using Demo.Models;
using MessageBox.Avalonia;
using System;
using System.IO;
using System.Linq;

namespace Demo
{
    public partial class OrganizerWindow : Window
    {
        public OrganizerWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            CmbGender.Items = Helper.GetContext().Genders.ToList();
            CmbRole.Items = Helper.GetContext().Roles.ToList();
            CmbSpecification.Items = Helper.GetContext().Specifications.ToList();
            CmbGender.SelectedIndex = 0;
            CmbRole.SelectedIndex = 0;
        }

        private string _pathImage;
        private async void BtnAttach_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter { Name = "Image files", Extensions = { "jpg", "jpeg", "png" } });
            string[] result = null;
            result = await openFileDialog.ShowAsync(this);
            if (result is not null)
            {
                _pathImage = result[0];
                var bitmap = new Bitmap(_pathImage);
                Img.Source = bitmap;
            }
        }

        private string GetFileName(string path) => path.Split("\\")[^1];

        private void CopyImage(string path, string fileName, string role)
        {
            var projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\.."));
            var imagesDir = $"\\{role}\\";
            var outputImagePath = $"{projectDir}{imagesDir}{fileName}";
            if (!File.Exists(outputImagePath))
            {
                File.Copy(path, outputImagePath, true);
            }
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLastName.Text) ||
                string.IsNullOrWhiteSpace(TbFirstName.Text) ||
                string.IsNullOrWhiteSpace(TbPhone.Text) ||
                string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBoxManager.GetMessageBoxStandardWindow("Информация", "Заполните все поля.").Show();
                return;
            }
            var specification = Helper.GetContext().Specifications.SingleOrDefault(x => x.Title == CmbSpecification.Text);
            if (specification == null)
            {
                specification = new Specification()
                {
                    Title = CmbSpecification.Text,
                };
                Helper.GetContext().Add(specification);
            }
            var role = CmbRole.SelectedItem as Role;
            string photo = null;
            if (!string.IsNullOrWhiteSpace(_pathImage))
            {
                photo = GetFileName(_pathImage);
            }
            switch (role.Title)
            {
                case "Жюри":
                    var jury = new Jury()
                    {
                        LastName = TbLastName.Text,
                        FirstName = TbFirstName.Text,
                        MiddleName = TbMiddleName.Text,
                        Email = TbEmail.Text,
                        Phone = TbPhone.Text,
                        Role = role,
                        Specification = specification,
                        Photo = photo
                    };
                    Helper.GetContext().Add(jury);
                    CopyImage(_pathImage, photo, role.Title);
                    break;
            }
            Helper.GetContext().SaveChanges();
        }
    }
}
