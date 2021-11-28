using System;
using System.Threading.Tasks;
using HomeWork.Models;
using HomeWork.Services;

namespace HomeWork
{
    public class Starter
    {
        public async Task Run()
        {
            var httpClient = new HttpService("https://reqres.in/api");
            var userService = new ResourceService<User>(httpClient, "/users");
            var shadeService = new ResourceService<Shade>(httpClient, "/shades");
            var registerService = new RegisterService<AuthToken>(httpClient, "/register");

            try
            {
                var getShadesTask = Task.Run(async () => await shadeService.List(2));
                var getUsersTask = Task.Run(async () => await userService.List(2));
                var getUserTask = Task.Run(async () => await userService.Get(2));
                var updateUserTask = Task.Run(async () => await userService.Update(new User()
                {
                    Name = "morpheus",
                    Job = "zion resident"
                }));
                var deleteUserTask = Task.Run(async () => await userService.Delete(2));
                var registerTask = Task.Run(async () => await registerService.Register(new Login()
                {
                    Email = "eve.holt@reqres.in",
                    Password = "pistol"
                }));

                await Task.WhenAll(
                    getShadesTask,
                    getUsersTask,
                    getUserTask,
                    updateUserTask,
                    deleteUserTask,
                    registerTask);

                /*var getShades = await getShadesTask;
                var getUsers = await getUsersTask;
                var getUser = await getUserTask;
                var updateUser = await updateUserTask;
                var deleteUser = await deleteUserTask;
                var register = await registerTask;*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}