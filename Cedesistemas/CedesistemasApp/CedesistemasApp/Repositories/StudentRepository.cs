using CedesistemasApp.Interfaces;
using CedesistemasApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CedesistemasApp.Repositories
{
    public class StudentRepository
    {
        public IDeviceService DeviceService { get; set; }
        public IStorageService StorageService { get; set; }
        public StudentRepository()
        {
            DeviceService = DependencyService.Get<IDeviceService>();
            StorageService = DependencyService.Get<IStorageService>();
        }
        async public Task<bool> SaveStudent(StudentModel student)
        {
            if (DeviceService.CheckConnectivity())
            {
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(student);
                    var body = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(
                        "https://cedesistemas-app-api.azurewebsites.net/api/Estudiantes", body);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            } 
            return false;
        }

    }
}
