using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dtaction_desktop
{
    static class RequestWebApi
    {
        private static string Uri = "http://dtaction.azurewebsites.net/";

        public static User GetUser(string pseudo, string psw)
        {  
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/user/getbypseudopsw/{pseudo}/{psw}").Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }

        public static User GetUserPseudo(string pseudo)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/user/getbypseudo/{pseudo}").Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }

        public static User GetUserEmail(string email)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync($"api/user/postbyemail?email={email}", email).Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }

        public static User GetLastUser()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/getlastuser").Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }

        public static User PostUser(User newUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/User", newUser).Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }

        public static List<ToDoList> GetToDoList(int IdUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/getbyuser/{IdUser}").Result;

            if (response.IsSuccessStatusCode)
            {
                List<ToDoList> todolist = null;
                todolist = response.Content.ReadAsAsync<IEnumerable<ToDoList>>().Result.ToList();
                return todolist;
            }
            return null;
        }

        public static ToDoList PostList(ToDoList newList)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/List", newList).Result;

            if (response.IsSuccessStatusCode)
            {
                ToDoList newToDoList = null;
                newToDoList = response.Content.ReadAsAsync<ToDoList>().Result;
                return newToDoList;
            }
            return null;
        }

        public static Task GetTask(int IdTask)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/Task/{IdTask}").Result;

            if (response.IsSuccessStatusCode)
            {
                Task task = null;
                task = response.Content.ReadAsAsync<Task>().Result;
                return task;
            }
            return null;
        }

        public static Task GetLastTask()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/getlasttask").Result;

            if (response.IsSuccessStatusCode)
            {
                Task task = null;
                task = response.Content.ReadAsAsync<Task>().Result;
                return task;
            }
            return null;
        }

        public static List<Task> GetTasks(int IdList)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/getbylist/{IdList}").Result;

            if (response.IsSuccessStatusCode)
            {
                List<Task> tasks = null;
                tasks = response.Content.ReadAsAsync<IEnumerable<Task>>().Result.ToList();
                return tasks;
            }
            return null;
        }

        public static Task PutTask(Task Task)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsJsonAsync("api/Task", Task).Result;

            if (response.IsSuccessStatusCode)
            {
                Task task = null;
                task = response.Content.ReadAsAsync<Task>().Result;
                return task;
            }
            return null;
        }

        public static Task PostTask(Task newTask)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/Task", newTask).Result;

            if (response.IsSuccessStatusCode)
            {
                Task task = null;
                task = response.Content.ReadAsAsync<Task>().Result;
                return task;
            }
            return null;
        }

        public static Task DeleteTask(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync($"api/Task/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                Task task = null;
                task = response.Content.ReadAsAsync<Task>().Result;
                return task;
            }
            return null;
        }
    }
}
